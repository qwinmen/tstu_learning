<?php

// если нет функции ftok, то напишем её сами
if( !function_exists('ftok') )
{
    // взята с php.net
    function ftok($pathname, $proj_id) {
       $st = stat($pathname);
       if (!$st) {
           return -1;
       }
      
       $key = sprintf("%u", (($st['ino'] & 0xffff) | (($st['dev'] & 0xff) << 16) | (($proj_id & 0xff) << 24)));
       return $key;
    }
}

// возьмём для хранения, код с примера чата с ajax
// и доработаем его
try {
    // конект к СУБД
    $dbh = new PDO("mysql:dbname=test;host=localhost", "root", "", array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES 'utf8'"));

    // получаем id последнего сообщения
    $last_id = isset($_REQUEST['last_id']) ? (int)$_REQUEST['last_id'] : 0;
    // текст
    $text = isset($_POST['text']) ? trim($_POST['text']) : '';
    
    // преобразуем имя файла в идентификатор блока памяти
    $key = ftok(__FILE__, 't');
    // получаем доступ к памяти
    // мы будем хранить максимальный ID, а значит, нам хватит 4 байта памяти
    $memory = shmop_open($key, 'c', 0600, 4);
    
    if (!empty($text)) {
        // вставка новой записи
        $sth = $dbh->prepare("INSERT INTO `chat` (`text`) VALUES (:text)");
        $sth->execute(array(':text' => $text));
        
        // последний сгенерированный ID
        $id = $dbh->lastInsertId();
        // пишем его в разделяемую память
        // используем pack, так как данные нужно передать как строку
        shmop_write($memory, pack('I', $id), 0);
    }
    
    // результирующий массив
    $result = array();
    
    //достаём id из памяти
    $data = unpack('I', shmop_read($memory, 0, 4));
    // если id = 0, возможно сервер перезапускали
    if (!$data[1]) {
        // получим последний id
        $sth = $dbh->query("SELECT MAX(`id`) FROM `chat`");
        $max = (int)$sth->fetchColumn();
        if ($max) {
            // запишем максимальный ID в память
            shmop_write($memory, pack('I', $max), 0);
            $data[1] = $max;
        }
    }
    // если ид в памяти меньше того что мы знаем
    while ($data[1] <= $last_id) {
        // зацикливаем в ожидании ид который мы не знаем, но что бы не грузить процессор ставим sleep в 1 секунду
        sleep(1);
        $data = unpack('I', shmop_read($memory, 0, 4));
    }
    
    // загружаем сообщения, которые были после последнего полученного нами, но не более 20
    $sth = $dbh->prepare("SELECT * FROM `chat` WHERE `id` > :last_id ORDER BY `id` DESC LIMIT 20");
    $sth->bindParam(':last_id', $last_id, PDO::PARAM_INT);
    $sth->execute();
    $result = array_reverse($sth->fetchall());
    
    // отдаём массив сообщений в формате JSON
    echo json_encode($result);
} catch (PDOException $e) {
    echo 'Ошибка подключения: ' . $e->getMessage();
}
