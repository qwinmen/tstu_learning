<html>
<head><title>php example</title></head>
<body>
<?
$file_pointer = fopen("info2.txt","w") or die("������ �������� �����.");
fwrite($file_pointer,"Hello, world!\n") or die("������ ������ �����.");
fclose($file_pointer) or die("������ �������� �����.");
echo "������ � ���� ������ �������!";
?>
</body>
</html>