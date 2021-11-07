#include <iostream.h>
#include <stdlib.h>
#include <stdio.h>

int main()
{
        int number;
        char letter;
        int option,y,i=0;
		int rotor1[20] = {59,88,28,31,49,69,58,15,45,81,20,57,46,25,87,3,4,1,11,83};
int rotor2[20] = {83,41,66,65,96,2,8,93,40,70,55,24,90,95,34,89,98,24,44,85};
int rotor3[20] = {58,91,18,60,36,54,100,90,47,50,12,52,62,78,57,18,35,36,33,43};



do{
        cout<<"Choose 1 to decrypt and choose 2 to encrypt the messege";
        cout<<endl<<"[1] * Decryption"
                <<endl<<"[2] * Encryption"
                <<endl<<"[3] * EXIT"<<endl;;
        
        cin>>option;
        switch (option) //Detects the option
               {
                case 1:
					{cout<<"Enter a letter : ";
                        cin >> letter; //Inputs the letter
                        cout<<"The character you entered is : \""<<int(letter)<<"\" in ASCII"<<endl; //Outputs the same letter in int
                      

				y=letter-rotor1[i];
		                if (y < 32)
							y = 126-(32-y);

						else if (y > 126)
							y = (y-126)+32;
						y=y+rotor2[i];
						if (y < 32)
							y = 126-(32-y);
						else if (y > 126)
						y = (y-126)+32;
						y=y+rotor3[i];
						if (y < 32)
							y = 126-(32-y);
						else if(y > 126)
							y = (y-126)+32;
						
							printf("%d",y);
							cout<<"The number you entered is : \""<<char(y)<<"\" in ASCII"<<endl; //Ouputs the same number in char
							i++;
                        break;
		}

                case 2:
					{               cout<<"Enter a letter : ";
                        cin >> letter; //Inputs the letter
                        cout<<"The character you entered is : \""<<int(letter)<<"\" in ASCII"<<endl; //Outputs the same letter in int
						

				y=letter+rotor1[i];
		if (y < 32)
							y = 126-(32-y);

						else if (y > 126)
									y = (y-126)+32;
						y=y+rotor2[i];
						if (y < 32)
							y = 126-(32-y);
						else if (y > 126)
							y = (y-126)+32;
							y=y+rotor3[i];
						if (y < 32)
							y = 126-(32-y);
						else if(y > 126)
							y = (y-126)+32;

							printf("%d",y);
							cout<<"The number you entered is : \""<<char(y)<<"\" in ASCII"<<endl; //Ouputs the same number in char
                        i++;
                        break;
					}
                case 3:
					{   return 0;}

                default: {//If user chooses anything else besides options given
                        cout<<"Invalid Option!";
                        system("PAUSE");
                        break;
		}}
}while (option !=3);

        system("PAUSE");
        return 0;
}
