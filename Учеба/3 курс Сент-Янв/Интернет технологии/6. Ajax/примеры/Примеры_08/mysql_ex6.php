<html>
<head><title>mysql example</title></head>
<body>
<?
$sdb_name = "localhost";
$user_name = "root";
$user_password = "";
$db_name = "books";
$link = mysql_connect($sdb_name,$user_name,$user_password);
if (!$link)
 {
  echo "<br/>�� ���� ����������� � �������� ��� ������.<br/>";
  exit();
 }
echo "<br/>���������� � �������� ��� ������ ��������� �������.<br/>";
if (!mysql_select_db($db_name,$link))
 {
  echo "<br/>�� ���� ������� ���� ������.<br/>";
  exit();
 }
mysql_query("SET NAMES 'cp1251'");

$str_sql_query = "UPDATE rus_classic_books SET num_pages ='450' WHERE name ='����� � ���. ��� 1'";
if (!mysql_query($str_sql_query,$link))
 {
  echo "<br/>�� ���� ��������� ������.<br/>";
  exit();
 }
echo "<br/>������ ������� ��������.<br/>";
mysql_close($link);
?>
</body>
</html>