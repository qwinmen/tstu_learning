<?php
	print "�������� ���������� ����� 5 �����<br>";
	$btn11 = $_POST['btn1'];	$btn55 = $_POST['btn5'];
	$btn22 = $_POST['btn2'];	$btn66 = $_POST['btn6'];
	$btn33 = $_POST['btn3'];	$btn77 = $_POST['btn7'];
	$btn44 = $_POST['btn4'];	$btn88 = $_POST['btn8'];
								$btn00  = $_POST['btn-']; 
	$btnArr = array($btn11, $btn22, $btn33, $btn44, $btn55, $btn66, $btn77, $btn88, $btn00);
	foreach($btnArr as $key)
	{		if($key) $tempVal = $key;	}	
	
	//���� ������ btn1 �� �������������� �����
	$cBtn = new ChBtn($tempVal);
	

class ChBtn
	{	
		
		public function __construct($tmpVal)
		{						
			//touch( "temp.txt" );
			//������� ����-���������	������ � ������. ��������� ����� ��������������� �� ��� ������ 
			$fp = fopen( "temp.txt", "r+" ) or die ( "�� ������� ������� ����" );
			$string = "";
			while (!feof ( $fp ) )
				$string = ( fgets( $fp, 1024 ) );
			//������� ����-���������
			fclose( $fp );
			//���������\�������� �� ������ ����� �� ������� $tmpVal
			$tempChar = array();
			$tempChar = str_split($string);//������ ��������� � ������		
			//($tmpVal-1)=1_������ � ����� � �����=$tempChar[]
			
			//������� ������ � ������:
			$digitBtn = $tempChar[$tmpVal-1];
			$ziroPoz = "";
			//��������� ���� � �����:
			$ziroPoz = strrpos($string, "0");
			if ($ziroPoz === false) { print "<p>��������� 0 �� �������</p>"; }
			else
			switch ($ziroPoz) 
			{
				case 0:
					{
						//if($tmpVal!=1){//���� �� ������ �� ��� ����
						//���� ���������� �� ������� ������ �� ���� ����� 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 1:
					{
						//if($tmpVal!=2){//���� �� ������ �� ��� ����
						//���� ���������� �� ������� ������ �� ���� ����� 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 1-	//�������� [0..8]
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 2:
					{
						//if($tmpVal!=3){//���� �� ������ �� ��� ����
						//���� ���������� �� ������� ������ �� ���� ����� 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 3:
					{
						//if($tmpVal!=4){//���� �� ������ �� ��� ����
						//���� ���������� �� ������� ������ �� ���� ����� 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 4:
					{
						//if($tmpVal!=5){//���� �� ������ �� ��� ����
						//���� ���������� �� ������� ������ �� ���� ����� 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//���� ����� �������		
						//���� ���������� �� ������� ������ �� ���� ����� 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 5:
					{
						//if($tmpVal!=6){//���� �� ������ �� ��� ����						
						//���� ���������� �� ������� ������ �� ���� ����� 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//���� ����� �������		
						//���� ���������� �� ������� ������ �� ���� ����� 3+
							if($tempChar[($tmpVal-1)-3] == 0 && ( (($tmpVal-1)-3) >=0 && (($tmpVal-1)-3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 6:
					{
						//if($tmpVal!=7){//���� �� ������ �� ��� ����						
						//���� ���������� �� ������� ������ �� ���� ����� 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//���� ����� �������								
						//���� ���������� �� ������� ������ �� ���� ����� 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 7:
					{
						//if($tmpVal!=8){//���� �� ������ �� ��� ����
						//���� ���������� �� ������� ������ �� ���� ����� 1+
							if($tempChar[($tmpVal-1)-1] == 0 && ( (($tmpVal-1)-1) >=0 && (($tmpVal-1)-1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//���� ����� �������							
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						//}
					}
					break;
				case 8:
					{
						//if($tmpVal!=9){//���� �� ������ �� ��� ����
						//���� ���������� �� ������� ������ �� ���� ����� 1-
							if($tempChar[($tmpVal-1)+1] == 0 && ( (($tmpVal-1)+1) >=0 && (($tmpVal-1)+1) <=8) )//-->0?
								$stateP = true;//���� ����� �������
						//���� ���������� �� ������� ������ �� ���� ����� 3-
							if($tempChar[($tmpVal-1)+3] == 0 && ( (($tmpVal-1)+3) >=0 && (($tmpVal-1)+3) <=8) )//-->0?
								$stateP = true;//���� ����� �������							
						//���� $stateP = true �� �������� ������� 0 � �������_����� 						
						//-1: � ����� //-2: �� �����		
						if($stateP) $this->toForm($this->replaceDigit($digitBtn));
						
						//}
					}
					break;				
				default: 	echo 'The value is NOT';				
			}
			
			//���� ����==false �� ������ ���� ��� �����_�����
			if(!$stateP) $this->toForm($tempChar);//������� ������ ������ ��� ������������			
			
		}	
		
		//# �������� ������� ���� � ����� � ����� � �� �����
		public function replaceDigit($digit)
		{
			$fop = fopen( "temp.txt", "r+" ) or die ( "�� ������� ������� ����" );
			$string = "";
			while (!feof ( $fop ) )
				$string = ( fgets( $fop, 1024 ) );
			$newArr = array();
			$newArr = str_split($string);//������ ��������� � ������
			//����� ����, ����� ����� � ��������						
			for($i=0; $i < count($newArr); $i++)
			{
				$tmp = $newArr[$i];				
				if($tmp == $digit)
				{					
					$newArr[$i] = 0;					
					//���� 8 ������ ��� 0:
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
			//�� ������
				fseek($fop,0);
				//������������
				foreach($newArr as $key)
					{fputs( $fop, $key );}
			
			//������� ����-���������
			fclose( $fop );
			return $newArr;
		}		
		
		public function toForm($arrToForm)
		{
			global $gloB1;global $gloB2;global $gloB3;
			global $gloB4;global $gloB5;global $gloB6;
			global $gloB7;global $gloB8;global $gloB9;
		
			//���� �������� a ������ b, �� ������������ a, ����� ������������ b
			$gloB1 = ( $arrToForm[0] == 0 ? "" :  $arrToForm[0]);$gloB2 = ( $arrToForm[1] == 0 ? "" :  $arrToForm[1]);
			$gloB3 = ( $arrToForm[2] == 0 ? "" :  $arrToForm[2]);$gloB4 = ( $arrToForm[3] == 0 ? "" :  $arrToForm[3]);
			$gloB5 = ( $arrToForm[4] == 0 ? "" :  $arrToForm[4]);$gloB6 = ( $arrToForm[5] == 0 ? "" :  $arrToForm[5]);
			$gloB7 = ( $arrToForm[6] == 0 ? "" :  $arrToForm[6]);$gloB8 = ( $arrToForm[7] == 0 ? "" :  $arrToForm[7]);
			$gloB9 = ( $arrToForm[8] == 0 ? "" :  $arrToForm[8]);
			
			$etalon = array(1, 2, 3, 4, 5, 6, 7, 8, 0); $index = 0;
			//���� � ������� ��� ����� �� ������� �� 1 �� 9 �� ������
			for($i=0;$i<count($arrToForm); $i++)
			{
				if($arrToForm[$i] == $etalon[$i]) $index++;//������� ����������				
			}
			if($index == count($etalon)) 
				print "<h2 style=\"border-style:dashed;width:140px;\">&nbsp;&nbsp;YOU WIN!</h2>";
			
		}
	
	}


?>