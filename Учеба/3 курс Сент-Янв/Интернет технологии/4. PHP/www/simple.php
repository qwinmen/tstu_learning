<?php
echo 12*2;
	$name = "Billy";
	$age = 23;
	//comment
	echo $name." ".$age;
	4 > 5;
	if($age > 18){ echo "<br>����� �����"; }
	elseif($age != 20){echo"<br>������� �� ������";}
	else { print("������� �� ���������"); }
	
	min = (� < b ? a : b);//���� �������� a ������ b, �� ������������ a, ����� ������������ b
	
	switch (2) 
	{
        case 0:
            echo 'The value is 0';
            break;
        case 1:
            echo 'The value is 1';
            break;
        case 2:
            echo 'The value is 2';
            break;
        default:
            echo "The value isn't 0, 1 or 2";
    }
	
	$arr = array();//����������� ������������ ������
	
	$arr = array("Book", "Name", "Value");
	echo $br.$arr[0];
	echo $br.$arr{1};
	
	unset($arr[0]);//������� �����\�������
	array_pop($arr);//������� ��������� �������
	array_push($arr, "wwwww");//�������� � ����� �������
	print_r($arr);//������� ���� ������ �� �����
	
	foreach($arr as $tmp) 
		print "<p>$tmp</p>";
		
	for ($tmp = 2004; $tmp < 2050; $tmp = $tmp + 4) 
	{        echo "<p>$tmp</p>";      }
	$flip = rand(0,10);
	$len = strlen("Boby");
	str_replace("stroka", 0, 2);
	str_split("karas");//������ ��������� � ������
	strrpos();// � ���������� ������� ���������� ��������� ��������� � ������
			$ziroPoz = strrpos($string, "0");
			if ($ziroPoz === false) { print "<p>��������� 0 �� �������</p>"; }			
    print $len;
	$ewq = "12304567";//�������� ������ �� ������
	$nn = str_replace ( "0", "e", $ewq);
	print $nn;//"123e4567"
	
	$leng = count($arr2);//����� ������
	
	function abo()
	{  }
	
	
	$drupal = "";	
	class Person
        {
				const stealth = "MAXIMUM";
				public static $tupik = "Static";
            public $isAlive = true;
            public $firstname; 
            public $lastname; 
            public $age;
			
            public function __construct($firstname, $lastname ,$age)
            {
                $this->firstname = $firstname;
                $this->lastname=$lastname;
                $this->age =$age;
				$this->BlaBla();
				$this->drupal = $age;
            }
			
			final public function BlaBla(){}
			
			public function Zamena()
			{
			//�������� ������� 0 � 8 � ������
				$der = "182304567";//"123045687"
				print $der."<br>";
				$newrr = array();
				$newrr = str_split($der);//������ ��������� � ������
				$dig = 8;
				for($i=0; $i < count($newrr); $i++)
				{
					$tmp = $newrr[$i];				
					if($tmp == $dig)
					{					
						$newrr[$i] = 0;					
						//���� 8 ������ ��� 0:
						if(strrpos($der, "8") > strrpos($der, "0")) $i=0;else $i=$i+1;
						for(; $i < count($newrr); $i++)
						{
							$tmp = $newrr[$i];
							if($tmp == 0)
							{							
								$newrr[$i] = $dig;
								break;
							}
						}//break;
					}
				}		
				
				print_r( $newrr);
			
			}
			
            
        }            
            $teacher = new Person("99","88",98);
            $student = new Person("99","88",98);
            echo $teacher->isAlive;
			echo $teacher->drupal;
			
			echo Person::stealth;
			print "<p>".Person::$tupik."</p>";
			
		class Shape		{          public $hasSides = true;        }
        
        class Square extends Shape		{         }
        
        $square = new Square();
        // Add your code below!
        if (property_exists($square,"hasSides") ) {
          echo "I have sides!";
        }
		
		$myArray = array(2012, 'blue', 5);
		$myAssocArray = array('year' => 2012, 'colour' => 'blue', 'doors' => 5);
		echo $myAssocArray['colour'];
		
		$salad = array('lettuce' => 'with', 'tomato' => 'without', 'onions' => 'with');
		foreach ($salad as $ingredient=>$include) 
		{
			echo $include . ' ' . $ingredient . '<br />';
		}
		
		$arr = array('a'=>'about', 'b'=>'boxer','c'=>'colored');
    foreach($arr as $value=>$key)
		print $value.' '.$key;

		$arr2 = array(array('key','value'),array('key2','value2'),array('key3','value3'));
		echo $arr2[1][0];
		
		include 'b.inc';//���������� ��� ���� ����-������ php
		
?>