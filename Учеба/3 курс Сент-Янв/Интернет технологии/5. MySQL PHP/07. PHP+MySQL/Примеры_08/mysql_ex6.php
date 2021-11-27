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
echo "<br/>Соединение с сервером баз данных произошло успешно.<br/>";
if (!mysql_select_db($db_name,$link))
 {
  echo "<br/>Не могу выбрать базу данных.<br/>";
  exit();
 }
mysql_query("SET NAMES 'cp1251'");

$str_sql_query = "UPDATE rus_classic_books SET num_pages ='450' WHERE name ='Война и мир. Том 1'";
if (!mysql_query($str_sql_query,$link))
 {
  echo "<br/>Не могу выполнить запрос.<br/>";
  exit();
 }
echo "<br/>Запись успешно изменена.<br/>";
mysql_close($link);
?>
</body>
</html>