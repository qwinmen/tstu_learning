<html>
<head><title>php example</title></head>
<body>
<?
$file_pointer = fopen("info.txt","r") or die("Ошибка открытия файла.");
$txt = fread($file_pointer,5) or die("Ошибка чтения файла.");
echo $txt; 
fclose($file_pointer) or die("Ошибка закрытия файла.");
?>
</body>
</html>