<html>
<head><title>Example</title></head>
<body>

<?
$perem = 2;
$variable = "���������������";

if($perem==1){
echo "<h1>Hello, World!</h1>";
echo "<p>$perem</p>";
}
else{
echo <<<mytext
<p align="left">
����� ������������ ��������� 
"here document" ��� ������
���������� ����� � 
������������ ���������� $variable.
</p>
<br/>
<p align="right">
��������,��� ����������� 
������������� ������ 
������������� � 
��������� <a href = "#">������</a>.
</p>
mytext;
echo "<p>$perem</p>";
}

for($i=1;$i<25;$i++){
echo "<br/>I'm don't repeat!";
}

?>

</body>
</html>