<html>
<head><title>php example</title></head>
<body>
<?
if (is_writable("info.txt")) echo "���� �������� ��������.";
 else echo "���� ���������� ��������.";
if (is_readable("info.txt")) echo "���� �������� ������.";
 else echo "���� ���������� ������.";
?>
</body>
</html>