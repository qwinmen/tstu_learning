<html>
<head><title>mysql example</title></head>
<body>
<?
$link = mysql_connect("localhost","root","");
if (!$link)
 {
  echo "�� ���� ����������� � �������� ��� ������";
  exit();
 }
echo "���������� � �������� ��� ������ ��������� �������";
mysql_close($link);
?>
</body>
</html>