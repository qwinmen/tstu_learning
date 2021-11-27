<html>
<head><title>php example</title></head>
<body>
<?
$authors = array(0 => "Толстой",1 => "Достоевский",2 => "Чехов");
array_pop($authors);// удалится элемент "Чехов"
echo "<pre>";
print_r($authors);
echo "</pre>";
?>
</body>
</html>