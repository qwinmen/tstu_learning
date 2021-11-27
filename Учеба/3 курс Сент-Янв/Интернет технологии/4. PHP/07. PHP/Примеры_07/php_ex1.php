<html>
<head><title>php example</title></head>
<body>
<?
echo "<h1>Hello, World!</h1><br/>";//вывод строки
echo <<<text
«десь используетс€ синтаксис "here document" дл€ вывода
нескольких строк с подстановкой переменных $variable.
<br/>
«аметьте,что закрывающий идентификатор должен 
располагатьс€ в отдельной <a href = "#">строке</a>.
text;
?>
</body>
</html>