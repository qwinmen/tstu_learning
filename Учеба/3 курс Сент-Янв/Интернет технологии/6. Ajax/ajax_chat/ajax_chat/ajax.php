<?php

try {
    // конект к СУБД
    $dbh = new PDO("mysql:dbname=test;host=localhost", "root", "", array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES 'utf8'"));

    // получаем id последнего сообщения
    $last_id = isset($_POST['last_id']) ? (int)$_POST['last_id'] : 0;
    
    // текст
    $text = isset($_POST['text']) ? trim($_POST['text']) : '';
    if (!empty($text)) {
        // вставка новой записи
        $sth = $dbh->prepare("INSERT INTO `chat` (`text`) VALUES (:text)");
        $sth->execute(array(':text' => $text));
    }

    // загружаем сообщения, которые были после последнего полученного нами, но не более 20
    $sth = $dbh->prepare("SELECT * FROM `chat` WHERE `id` > :last_id ORDER BY `id` DESC LIMIT 20");
    $sth->bindParam(':last_id', $last_id, PDO::PARAM_INT);
    $sth->execute();
    
    // отдаём массив сообщений в формате JSON
    echo json_encode(array_reverse($sth->fetchall()));
} catch (PDOException $e) {
    echo 'Ошибка подключения: ' . $e->getMessage();
}
