<?php
	
	class DataSave
	{		
		public $svArr = array();
		
		public function __construct()
		{	
			$svArr[0] = ""; unset($svArr[0]);//������� �����\�������
		//�������� ������� ���� �� �����, �� ��� ���������� �������������� �������
			$efp = fopen( "temp.txt", "r+" ) or die ( "�� ������� ������� ����" );
			while (!feof ( $efp ) )
			{			
				$char = ( fgetc( $efp ) );				
				if($char < 9 && $char > -1)				
					array_push($svArr, $char);//�������� � ����� �������
			}
			fclose( $efp );			
			
			$this->save(true, $svArr);
			//$btn1 = 34;
			//print $this->btn1;		
			
		}
		
	
		
		//��������� ���������� $arr � ����
		public function save($stateJS, $svArr)
		{	
			global $DSbtn1, $DSbtn2, $DSbtn3, $DSbtn4,
					$DSbtn5, $DSbtn6, $DSbtn7, $DSbtn8;			
			
			if($stateJS)
			{
				//���� �������� a ������ b, �� ������������ a, ����� ������������ b
				$DSbtn1 = ( $arrToForm[1] == 0 ? "" :  $arrToForm[1]);$DSbtn2 = ( $arrToForm[2] == 0 ? "" :  $arrToForm[2]);
				$DSbtn3 = ( $arrToForm[3] == 0 ? "" :  $arrToForm[3]);$DSbtn4 = ( $arrToForm[4] == 0 ? "" :  $arrToForm[4]);
				$DSbtn5 = ( $arrToForm[5] == 0 ? "" :  $arrToForm[5]);$DSbtn6 = ( $arrToForm[6] == 0 ? "" :  $arrToForm[6]);
				$DSbtn7 = ( $arrToForm[7] == 0 ? "" :  $arrToForm[7]);$DSbtn8 = ( $arrToForm[8] == 0 ? "" :  $arrToForm[8]);
							
				touch( "save.txt" );
				//������� ����-���������	������ � ������. ��������� ����� ��������������� �� ��� ������ 
				$fp = fopen( "save.txt", "r+" ) or die ( "�� ������� ������� ����" );
				//�� ������
				fseek($fp,0);
				//������������
				foreach($svArr as $key)
					fputs( $fp, $key );
				//echo "->".$svArr[2];
			
				//������� ����-���������
				fclose( $fp );
				//return "SAVEDDDD.....";
			}//else return "NOT";			
		}
			
		
	}
	
	//�������� ������� ������ Save game
	$saveGame = $_POST['btnSAVE'];	
	
	//���� ������ Save Game �� �������������� �����
	if($saveGame==200) {$sBtn = new DataSave();}
	
	

?>