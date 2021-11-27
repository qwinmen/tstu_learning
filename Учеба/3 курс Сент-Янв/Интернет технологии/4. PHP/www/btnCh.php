<?php
	print "интернет технологии среда 5 число<br>";
	$btn11 = $_POST['btn1'];	$btn55 = $_POST['btn5'];
	$btn22 = $_POST['btn2'];	$btn66 = $_POST['btn6'];
	$btn33 = $_POST['btn3'];	$btn77 = $_POST['btn7'];
	$btn44 = $_POST['btn4'];	$btn88 = $_POST['btn8'];
								$btn00  = $_POST['btn-']; 
	$btnArr = array($btn11, $btn22, $btn33, $btn44, $btn55, $btn66, $btn77, $btn88, $btn00);
	foreach($btnArr as $key)
	{		if($key) $tempVal = $key;	}	
	
	//если нажали btn1 то инициализируем класс
	$cBtn = new ChBtn($tempVal);
	

class ChBtn
	{	
		
		public function __construct($tmpVal)
		{						
			//touch( "temp.txt" );
			//создать файл-контейнер	чтение и запись. Указатель файла устанавливается на его начало 
			$fp = fopen( "temp.txt", "r+" ) or die ( "Не удалось открыть файл" );
			$string = "";
			while (!feof ( $fp ) )
				$string = ( fgets( $fp, 1024 ) );
			//закрыть файл-контейнер
			fclose( $fp );
			//выдернуть\вырезать из СТРОКИ цифру на позиции $tmpVal
			$tempChar = array();
			$tempChar = str_split($string);//строку перегнать в массив		
			//($tmpVal-1)=1_кнопка и цифра в файле=$tempChar[]
			
			//нажатая кнопка с цыфрой:
			$digitBtn = $tempChar[$tmpVal-1];
			$ziroPoz = "";
			//положение ноля в файле:
			$ziroPoz = strrpos($string, "0");
			if ($ziroPoz === false) { print "<p>Положение 0 не найдено</p>"; }
			else
			switch ($ziroPoz) 
			{
				case 0:
					{
						//if($tmpVal!=1){//типо не нажали на сам ноль
						//если расстояние от нажатой кнопки до ноля равно 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 1:
					{
						//if($tmpVal!=2){//типо не нажали на сам ноль
						//если расстояние от нажатой кнопки до ноля равно 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 1-	//интервал [0..8]
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 2:
					{
						//if($tmpVal!=3){//типо не нажали на сам ноль
						//если расстояние от нажатой кнопки до ноля равно 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 3:
					{
						//if($tmpVal!=4){//типо не нажали на сам ноль
						//если расстояние от нажатой кнопки до ноля равно 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 4:
					{
						//if($tmpVal!=5){//типо не нажали на сам ноль
						//если расстояние от нажатой кнопки до ноля равно 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//типо можно двигать		
						//если расстояние от нажатой кнопки до ноля равно 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 5:
					{
						//if($tmpVal!=6){//типо не нажали на сам ноль						
						//если расстояние от нажатой кнопки до ноля равно 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//типо можно двигать		
						//если расстояние от нажатой кнопки до ноля равно 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 6:
					{
						//if($tmpVal!=7){//типо не нажали на сам ноль						
						//если расстояние от нажатой кнопки до ноля равно 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//типо можно двигать								
						//если расстояние от нажатой кнопки до ноля равно 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 7:
					{
						//if($tmpVal!=8){//типо не нажали на сам ноль
						//если расстояние от нажатой кнопки до ноля равно 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//типо можно двигать							
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 8:
					{
						//if($tmpVal!=9){//типо не нажали на сам ноль
						//если расстояние от нажатой кнопки до ноля равно 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//типо можно двигать
						//если расстояние от нажатой кнопки до ноля равно 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//типо можно двигать							
						//если $stateP = true то поменять местами 0 И нажатая_кнопа 						
						//-1: в файле //-2: на форме		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						
						//}
					}
					break;				
				default: 	echo 'The value is NOT';				
			}
			
			//если флаг==false то нажали НОЛЬ или ЛЕВУЮ_ЦИФРУ
			if(!$stateP) $this->toForm($tempChar);//выводим старый массив без перестановок			
			
		}	
		
		//# поменять местами ноль и цифру в файле и на форме
		public function replaceDigit($digit)
		{
			$fop = fopen( "temp.txt", "r+" ) or die ( "Не удалось открыть файл" );
			$string = "";
			while (!feof ( $fop ) )
				$string = ( fgets( $fop, 1024 ) );
			$newArr = array();
			$newArr = str_split($string);//строку перегнать в массив
			//найти ноль, найти цифру и поменять						
			for($i=0; $i < count($newArr); $i++)
			{
				$tmp = $newArr[$i];				
				if($tmp == $digit)
				{					
					$newArr[$i] = 0;					
					//если 8 правее чем 0:
					if(strrpos($string, $digit) > strrpos($string, "0")) $i=0;else $i=$i+1;
					for(; $i < count($newArr); $i++)
					{
						$tmp = $newArr[$i];
						if($tmp == 0)
						{							
							$newArr[$i] = $digit;
							break;
						}
					}
				}
			}		
			
			//print_r( $newArr);				
			//на начало
				fseek($fop,0);
				//перезаписать
				foreach($newArr as $key)
					{fputs( $fop, $key );}
			
			//закрыть файл-контейнер
			fclose( $fop );
			return $newArr;
		}		
		
		public function toForm($arrToForm)
		{
			global $gloB1;global $gloB2;global $gloB3;
			global $gloB4;global $gloB5;global $gloB6;
			global $gloB7;global $gloB8;global $gloB9;
		
			//Если значение a меньше b, то возвращается a, иначе возвращается b
			$gloB1 = ( $arrToForm[0] == 0 ? "" :  $arrToForm[0]);$gloB2 = ( $arrToForm[1] == 0 ? "" :  $arrToForm[1]);
			$gloB3 = ( $arrToForm[2] == 0 ? "" :  $arrToForm[2]);$gloB4 = ( $arrToForm[3] == 0 ? "" :  $arrToForm[3]);
			$gloB5 = ( $arrToForm[4] == 0 ? "" :  $arrToForm[4]);$gloB6 = ( $arrToForm[5] == 0 ? "" :  $arrToForm[5]);
			$gloB7 = ( $arrToForm[6] == 0 ? "" :  $arrToForm[6]);$gloB8 = ( $arrToForm[7] == 0 ? "" :  $arrToForm[7]);
			$gloB9 = ( $arrToForm[8] == 0 ? "" :  $arrToForm[8]);
			
			$etalon = array(1, 2, 3, 4, 5, 6, 7, 8, 0); $index = 0;
			//если в массиве все цифры по порядку от 1 до 9 ТО ПОБЕДА
			for($i=0;$i<count($arrToForm); $i++)
			{
				if($arrToForm[$i] == $etalon[$i]) $index++;//сколько совпадений				
			}
			if($index == count($etalon)) 
				print "<h2 style=\"border-style:dashed;width:140px;\">&nbsp;&nbsp;YOU WIN!</h2>";
			
		}
	
	}


?>