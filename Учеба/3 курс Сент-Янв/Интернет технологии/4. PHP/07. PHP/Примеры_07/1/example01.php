<html>
<head><title>Example</title></head>
<body>

<?
$perem = 2;
$variable = "всевозможнейших";

if($perem==1){
echo "<h1>Hello, World!</h1>";
echo "<p>$perem</p>";
}
else{
echo <<<mytext
<p align="left">
Здесь используется синтаксис 
"here document" для вывода
нескольких строк с 
подстановкой переменных $variable.
</p>
<br/>
<p align="right">
Заметьте,что закрывающий 
идентификатор должен 
располагаться в 
отдельной <a href = "#">строке</a>.
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