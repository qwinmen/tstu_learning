<?
$s_author = iconv("utf-8", "windows-1251", $sauthor);
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
$str_sql_query = "SELECT * FROM rus_classic_books WHERE author LIKE'" . $s_author . "%'";
$result = mysql_query($str_sql_query,$link);
$sum_pages = 0;
$i = 0;
if ($myrow = mysql_fetch_array($result))
{
 header("Content-Type: text/xml");
 echo "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
 ?>
 <books>
 <?
 do
 {
 $i++;
 $sum_pages=$sum_pages+$myrow['num_pages'];
 $buf = "".iconv("windows-1251","utf-8", "".$myrow['name']);
 echo "<books_name>".$buf."</books_name>";
 }
while($myrow = mysql_fetch_array($result));
?>
<num><?echo $i;?></num>
<pages><?echo $sum_pages;?></pages>
</books>
<?
}
else
{
echo "false";
}
mysql_close($link);
?>