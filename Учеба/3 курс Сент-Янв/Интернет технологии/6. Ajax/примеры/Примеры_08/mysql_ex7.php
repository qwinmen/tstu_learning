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
  echo "<br/>Не могу соединиться с сервером баз данных.<br/>";
  exit();
 }
if (!mysql_select_db($db_name,$link))
 {
  echo "<br/>Не могу выбрать базу данных.<br/>";
  exit();
 }
mysql_query("SET NAMES 'cp1251'");

$str_sql_query = "SELECT * FROM rus_classic_books";
if (!$result = mysql_query($str_sql_query,$link))
 {
  echo "<br/>Не могу выполнить запрос.<br/>";
  exit();
 }
echo "<table border = 2>";
$myrow = mysql_fetch_array($result); 
do
{
echo "<tr>";
echo "<td>".$myrow['id']."</td>";
echo "<td>".$myrow['name']."</td>";
echo "<td>".$myrow['author']."</td>";
echo "<td>".$myrow['num_pages']."</td>";
echo "</tr>";
}
while($myrow = mysql_fetch_array($result));
echo "</table>";
mysql_close($link);
?>
</body>
</html>