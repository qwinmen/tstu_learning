<html>
<head><title>php example</title></head>
<body>
<?
$authors = array("Хаджи-Мурат" => "Толстой","Игрок" => "Достоевский","Вишневый сад" => "Чехов");
foreach ($authors as $key => $value)
{
 echo $value." написал \"".$key."\"<br/>";
}
?>
</body>
</html>