<html>
<head><title>php example</title></head>
<body>
<?
$file_pointer = fopen("info.txt","r") or die("������ �������� �����.");
$txt = fread($file_pointer,5) or die("������ ������ �����.");
echo $txt."<br/>"; 
$cur_pos = ftell($file_pointer)or die("���������� ������ ������� ���������.");
echo "������� ������� ��������� ��������� - ".$cur_pos;
fclose($file_pointer) or die("������ �������� �����.");
?>
</body>
</html>