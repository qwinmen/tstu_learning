<html>
<head><title>php example</title></head>
<body>
<?
$authors = array("�������" => array("����� � ���","���� ��������","�����������"), "�����������" => array("������������ � ���������","�����"),"�����" => array("�������� ���"));
foreach ($authors as $key => $value)
{
echo $key." ������� ������������ :<br/>";
foreach ($value as $subkey => $subvalue)
 {
  echo "___\"".$subvalue."\"<br/>";
 } 
}
?>
</body>
</html>