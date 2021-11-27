<html>
<head><title>mysql example</title></head>
<body>
<?
$link = mysql_connect("localhost","root","");
if (!$link)
 {
  echo "<br/>Ќе могу соединитьс€ с сервером баз данных.<br/>";
  exit();
 }
echo "<br/>—оединение с сервером баз данных произошло успешно.<br/>";

$str_sql_query = "CREATE DATABASE books DEFAULT CHARACTER SET cp1251 COLLATE cp1251_bin";
if (!mysql_query($str_sql_query,$link))
 {
  echo "<br/>Ќе могу создать базу данных.<br/>";
  exit();
 }
echo "<br/>—оздание базы данных произошло успешно.<br/>";
mysql_close($link);
?>
</body>
</html>