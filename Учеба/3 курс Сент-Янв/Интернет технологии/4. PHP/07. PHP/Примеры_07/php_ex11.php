<html>
<head><title>php example</title></head>
<body>
<?
$authors = array(0 => "�������",1 => "�����������",2 => "�����");
unset($authors[1]);// �������� ������� "�����������"
echo "<pre>";
print_r($authors);
echo "</pre>";
?>
</body>
</html>