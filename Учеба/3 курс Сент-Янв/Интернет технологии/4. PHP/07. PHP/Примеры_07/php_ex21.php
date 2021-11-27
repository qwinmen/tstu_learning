<html>
<head><title>php example</title></head>
<body>
<?
$file_pointer = fopen("info.txt","r") or die("Ошибка открытия файла.");
$txt = fread($file_pointer,5) or die("Ошибка чтения файла.");
echo $txt."<br/>"; 
$cur_pos = ftell($file_pointer)or die("Невозможно узнать позицию указателя.");
echo "Текущая позиция файлового указателя - ".$cur_pos;
fclose($file_pointer) or die("Ошибка закрытия файла.");
?>
</body>
</html>