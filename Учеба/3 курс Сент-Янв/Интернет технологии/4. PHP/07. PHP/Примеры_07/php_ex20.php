<html>
<head><title>php example</title></head>
<body>
<?
if (is_writable("info.txt")) echo "Файл возможно записать.";
 else echo "Файл невозможно записать.";
if (is_readable("info.txt")) echo "Файл возможно читать.";
 else echo "Файл невозможно читать.";
?>
</body>
</html>