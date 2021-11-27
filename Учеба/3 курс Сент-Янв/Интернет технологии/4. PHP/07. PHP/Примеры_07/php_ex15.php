<html>
<head><title>php example</title></head>
<body>
<?
$authors = array("Толстой" => array("Война и мир","Анна Каренина","Воскресение"), "Достоевский" => array("Преступление и наказание","Идиот"),"Чехов" => array("Вишневый сад"));
foreach ($authors as $key => $value)
{
echo $key." написал произведения :<br/>";
foreach ($value as $subkey => $subvalue)
 {
  echo "___\"".$subvalue."\"<br/>";
 } 
}
?>
</body>
</html>