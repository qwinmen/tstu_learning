<html>
<head><title>php example</title></head>
<body>
<?
$file_pointer = fopen("info2.txt","w") or die("Ошибка открытия файла.");
fwrite($file_pointer,"Hello, world!\n") or die("Ошибка записи файла.");
fclose($file_pointer) or die("Ошибка закрытия файла.");
echo "Запись в файл прошла успешно!";
?>
</body>
</html>