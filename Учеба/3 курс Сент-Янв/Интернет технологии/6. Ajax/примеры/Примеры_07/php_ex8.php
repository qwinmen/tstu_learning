<html>
<head><title>php example</title></head>
<body>
<?
$authors = array(0 => "�������",1 => "�����������",2 => "�����");
$l = count($authors);
for ($i = 0;$i < $l;$i++)
{
echo $authors[$i]."<br/>";
}
?>
</body>
</html>