<html>
<head><title>php example</title></head>
<body>
<?
$file_pointer = fopen("info.txt","r") or die("������ �������� �����.");
$txt = fread($file_pointer,5) or die("������ ������ �����.");
echo $txt; 
fclose($file_pointer) or die("������ �������� �����.");
?>
</body>
</html>