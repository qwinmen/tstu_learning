<!-- сформировать строку стиля из чекбоксов и её применить при клике на див-->
<!--инпуты поместить в контейнер с onclick. Опрашивать все отмеченые чекбоксы и формировать строку стилей-->

var text = document.querySelector("textarea"),    
	globalStyle = "", flag="0";	
	
	function SwitchCheked()
	{
	globalStyle = "";
	var f=document.forms['GetStyle'];
	 var mas=f.getElementsByTagName('input');
	 for(i=0; i<mas.length; i++)
	 {	  
	  if(mas[i].checked)
		switch(mas[i].name)
		{
			case "a": globalStyle += " apply-red";  		break
			case "b": globalStyle += " apply-bold"; 		break
			case "c": globalStyle += " apply-crossed"; 		break
			case "d": globalStyle += " apply-background"; 	break
			case "e": globalStyle += " apply-font";  		break
			case "f": globalStyle += " apply-weight";  		break
			case "g": globalStyle += " apply-cursor";  		break
			case "h": globalStyle += " apply-vseVodin";		break
			case "j": globalStyle += " apply-nocoment";		break
			case "k": globalStyle += " apply-overflow";		break
			default:
		}
	  
	  
	 }
	 
	 
	}
	
	function kodimg(id) { 		
	
	switch(id)
	{	
		case "10":
			if(flag==id){ text.className = " just"; flag="0";}
			else 
			{
				flag="10";
				text = document.getElementById(id);
				text.className = globalStyle;	 
			}	break
		case "11":	
			if(flag==id){ text.className = " just"; flag="0";}
			else 
			{
				flag="11";
				text = document.getElementById(id);
				text.className = globalStyle;	 
			}	break
		case "22": 
			if(flag==id){ text.className = " just"; flag="0";}
			else 
			{
				flag="22";
				text = document.getElementById(id);
				text.className = globalStyle;	 
			}	break
		case "33":
			if(flag==id){ text.className = " just"; flag="0";}
			else 
			{
				flag="33";
				text = document.getElementById(id);	
				text.className = globalStyle;	 
			}	break
		default:		
	}
	
  }
	
