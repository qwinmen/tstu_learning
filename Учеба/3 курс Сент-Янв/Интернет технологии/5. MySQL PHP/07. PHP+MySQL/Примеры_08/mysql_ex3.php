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

$str_sql_query = "DROP DATABASE books";
if (!mysql_query($str_sql_query,$link))
 {
  echo "<br/>Ќе могу удалить базу данных.<br/>";
  exit();
 }
echo "<br/>”даление базы данных произошло успешно.<br/>";
mysql_close($link);
?>
</body>
</html>