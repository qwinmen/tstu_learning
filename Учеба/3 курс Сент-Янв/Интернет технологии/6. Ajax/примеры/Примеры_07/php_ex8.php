<html>
<head><title>php example</title></head>
<body>
<?
$authors = array(0 => "Толстой",1 => "Достоевский",2 => "Чехов");
$l = count($authors);
for ($i = 0;$i < $l;$i++)
{
echo $authors[$i]."<br/>";
}
?>
</body>
</html>