<html>
<head><title>mysql example</title></head>
<body>
<?
$link = mysql_connect("localhost","root","");
if (!$link)
 {
  echo "<br/>�� ���� ����������� � �������� ��� ������.<br/>";
  exit();
 }
echo "<br/>���������� � �������� ��� ������ ��������� �������.<br/>";

$str_sql_query = "CREATE DATABASE books DEFAULT CHARACTER SET cp1251 COLLATE cp1251_bin";
if (!mysql_query($str_sql_query,$link))
 {
  echo "<br/>�� ���� ������� ���� ������.<br/>";
  exit();
 }
echo "<br/>�������� ���� ������ ��������� �������.<br/>";
mysql_close($link);
?>
</body>
</html>