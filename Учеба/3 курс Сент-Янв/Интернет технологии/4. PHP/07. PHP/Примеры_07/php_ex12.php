<html>
<head><title>php example</title></head>
<body>
<?
$authors = array(0 => "�������",1 => "�����������",2 => "�����");
array_pop($authors);// �������� ������� "�����"
echo "<pre>";
print_r($authors);
echo "</pre>";
?>
</body>
</html>