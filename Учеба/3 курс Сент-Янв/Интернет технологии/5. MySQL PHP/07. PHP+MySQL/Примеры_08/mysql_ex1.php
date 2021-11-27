<html>
<head><title>mysql example</title></head>
<body>
<?
$link = mysql_connect("localhost","root","");
if (!$link)
 {
  echo "Ќе могу соединитьс€ с сервером баз данных";
  exit();
 }
echo "—оединение с сервером баз данных произошло успешно";
mysql_close($link);
?>
</body>
</html>