<html>
<head><title>php example</title></head>
<body>
<?
$dir = "..";
$arr = scandir($dir);
echo "<pre>";
print_r($arr);
echo "</pre>";
?>
</body>
</html>