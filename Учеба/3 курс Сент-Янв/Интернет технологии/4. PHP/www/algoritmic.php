<?php	
	
	$a =  $_POST['intA']; 
	$b =  $_POST['intB']; 
	$n =  $_POST['intN']; 	
	$f = $_POST['fun']; 	
	
	
	function result($a, $b, $n, $f)
	{	
		$s = 0.0; $index = 0.0;		
		$h = ($b - $a)/$n;				
        $x = $a + $h;		
		$srt = "";
		
		while ($x < $b)
            {
                $s = $s + (4.0 * Y($x,$f));
                $str = $str."������� $index ����� $s";
                $x = $x + $h;
                $s = $s + (2.0 * Y($x,$f));
				$index = $index + 1.0;
                $str = $str."\t������� $index ����� $s\r\n";
                $x = $x + $h;
            }
		$s = $h / 3.0 * ($s + Y($a,$f) - Y($b,$f));		
        return $str."\t\t�������� = $s\r\n";
	}
	
	function Y($p, $f)
	{	
		switch ($f) 
		{        
			case 1:
				return 1.0 / (1.0 + $p * $p);
				break;
			case 2:
				return 2.0 / (1.0 + $p * $p);
				break;
			case 3:
				return 3.0 / (1.0 + $p * $p);
				break;
			default:
				return 4.0 / (2.0 + $p * $p);
		}
		
	}	
	
	if($a=='' || $b=='' || $n=='') print "<textarea cols=72 rows=5>".result(0.4,1.2,8.0, $f)."</textarea>";
	 else print "<textarea cols=72 rows=5>".result($a, $b, $n, $f)."</textarea>";
/*--------------------------------------------------------------------------------	
//+----+----+----+
//| 1  |  2 | 3  |
//+--------------+
//| 4  |  5 | 6  |
//+--------------+
//|  7 |  8 |    |
//+----+----+----+
*/
/*
feof() - �������� ����� �����. ��������: ��������� �����.

fgetc() - ������ ���������� ������� �� �����. ��������: ��������� �����.
fgets() - ������ ��������� ������ �����.
fread() - ����� ������� ������ �� �����. ���������: ��������� ����� � ���������� ����������� ��������.
fseek() - ������ �� ������ �����. ���������: ��������� ����� � ��������. 

fputs() - ������ ������ � ����. ���������: ��������� ����� � ������.
fwrite() - ������ ������ ������� fputs( ). 

unlink() - ������� �������� ����.
*/
	
	$btn1 = "";	$btn5 = "";
	$btn2 = "";	$btn6 = "";
	$btn3 = "";	$btn7 = "";
	$btn4 = "";	$btn8 = "";
				$btn0 = ""; 
	
	
	$globalArr = "";
	
	class DataAlg
	{		
		public $arr = array();
		public static $flag;		
		
		public function __construct()
		{	
			$this->globalArr = $this->newGame();
		}		
		
		
		//# ������� ������ ������ ��������� �����
		public function newGame()
		{//��������� ������ �������� ��� ����������:			
			$tmp = 0;
			for($i=1; $i < 8; $i++)
			{
				if($i==1) {$arr[0] = rand(1,8); $tmp = $arr[0];}				
				
				//������ �� ������ �� �����
				for($j=0; $j<count($arr);$j++)
				{
					//���� tmp ��� ����
					while($tmp==$arr[$j])
					{						
						//�� ����� ���������
						$tmp = rand(1,8);
						$j=0;
					}
				}
				//� ����� ������� ���������� �����
				$arr[$i] = $tmp;
			} 
			
			//sort($arr);
			//foreach($arr as $key)
			 //echo $key;
			//echo count($arr);		
			$this->btn1 = $arr[0];	$this->btn5 = $arr[4];
			$this->btn2 = $arr[1];	$this->btn6 = $arr[5];
			$this->btn3 = $arr[2];	$this->btn7 = $arr[6];
			$this->btn4 = $arr[3];	$this->btn8 = $arr[7];
											$this->btn0 = "-"; 
			//								
			array_push($arr, "0");//�������� � ����� �������
			
			return $arr;
			
			
		}
	
	
	}//end class
	
	
	//�������� ������� ������ New Game
	$startNewGame = $_POST['newGame'];			
	
	//���� ������ New Game �� �������������� �����
	if($startNewGame==123) {$work = new DataAlg();}	
	
	
	
/*******************��������� ������������� ����**************************************/		
		touch( "temp.txt" );		
		$fop = fopen( "temp.txt", "r+" ) or die ( "�� ������� ������� ����" );
		//�� ������
		fseek($fop,0);
		if(count($work->globalArr)>3)
		//������������
		foreach($work->globalArr as $key)			 
			fputs( $fop, $key );//����� � ���� ������			
		fclose( $fop );
/*******************��������� ������������� ����**************************************/
	
	//echo "<p>---".$sBtn->save(true, $sBtn->_globalState)."===</p>";
	//echo DataAlg::newGame();
	
	//echo "<p>---".$work->fltmp."===</p>";
	//echo "<p>---".$work->drupal."===</p>";
	//echo "<p>---".$work->globalArr[3]."===</p>";
	
	//if($flag)
	//$btn3val = 3;
	//else $btn3val = 33;
	
	
	
	
	?>
	
	
