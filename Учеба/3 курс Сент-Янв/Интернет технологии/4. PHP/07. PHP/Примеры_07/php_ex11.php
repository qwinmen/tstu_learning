<html>
<head><title>php example</title></head>
<body>
<?
$authors = array(0 => "Толстой",1 => "Достоевский",2 => "Чехов");
unset($authors[1]);// удалится элемент "Достоевский"
echo "<pre>";
print_r($authors);
echo "</pre>";
?>
</body>
</html>