<html>
<head><title>php example</title></head>
<body>
<?
$authors = array("�����-�����" => "�������","�����" => "�����������","�������� ���" => "�����");
foreach ($authors as $key => $value)
{
 echo $value." ������� \"".$key."\"<br/>";
}
?>
</body>
</html>