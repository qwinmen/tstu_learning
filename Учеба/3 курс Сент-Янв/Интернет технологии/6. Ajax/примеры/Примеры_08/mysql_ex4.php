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
$str_sql_query = "CREATE TABLE rus_classic_books (id INT NOT NULL AUTO_INCREMENT,PRIMARY KEY (id),name VARCHAR(50),author VARCHAR(50),num_pages INT(10))";
if (!mysql_query($str_sql_query,$link))
 {
  echo "<br/>�� ���� ������� ������� ������.<br/>";
  exit();
 }
echo "<br/>�������� ������� ������ ��������� �������.<br/>";
mysql_close($link);
?>
</body>
</html>