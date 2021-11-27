<html>
<head><title>php example</title></head>
<body>
<?
function invert($num)
{
if ($num == 0) return;
 else return 1/$num;
}

define("N_PI",3.14);
define("S_PI","„исло пи");
echo invert(N_PI);
?>
</body>
</html>