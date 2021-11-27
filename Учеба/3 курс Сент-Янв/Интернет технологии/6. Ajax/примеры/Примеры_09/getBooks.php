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
$hstr = "";
$lstr = "";
$sum_pages = 0;
$i = 0;
if ($myrow = mysql_fetch_array($result))
{ 
 do
 {
 $i++;
 $sum_pages=$sum_pages+$myrow['num_pages'];
 $buf = "".iconv("windows-1251","utf-8", "".$myrow['name']);
 $lstr = $lstr."|".$buf;
 }
while($myrow = mysql_fetch_array($result));
$hstr = $i."|".$sum_pages.$lstr;
echo $hstr;
}
else
{
echo "false|_";
}
mysql_close($link);
?>