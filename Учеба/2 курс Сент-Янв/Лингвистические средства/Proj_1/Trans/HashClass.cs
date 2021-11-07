using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//LPO_4
namespace Trans
{//in text - textBoxIn//Out result - listViewHashTable
    class HashClass
    {
        private static int obshIndex = 0;

        #region//Блок ОБЯЗАТЕЛЬНО на СТАТИКЕ!//

        public static int vol = 10;
        static int[] _Num=new int[vol];
        static string[] _Id=new string[vol];
        static string[] _Type=new string[vol];
        static int[] _Hash=new int[vol];
        static int[] _Ch=new int[vol];

        #endregion//Блок ОБЯЗАТЕЛЬНО на СТАТИКЕ!//

        private string a;
        private string[] words;//Тк идет перезапись, надо ток 2 ячейки

        public void GlobalSbros(bool statys)
        {//Глобальный сброс всех массивов
            if (statys)
            {//Всю статику нулим
                for (int i = 0; i < _Num.Length; i++)
                {
                    _Num[i]=0;
                    _Id[i]=null;
                    _Type[i]=null;
                    _Hash[i]=0;
                    _Ch[i]=0;
                }
                obshIndex = 0;
            }
        }

        public void BufferWords(string[] text)
        {//Имеем string text[] с [0]=type && [1]=id
            char[] razdelenie = { ' ' };
            a = text[obshIndex];
            words = a.Split(razdelenie); //Делим строку на ПОД_СТРОКИ
            TxtFromTextBoxIn();
        }

        void TxtFromTextBoxIn()
        {
            if (obshIndex>=_Num.Length)
            {
                obshIndex = 0;
            }
            _Num[obshIndex]=obshIndex;//AddNum(obshIndex);//Numer[obshIndex] = obshIndex;
            if (!Bastion(words[1]))
            {
                _Id[obshIndex] = words[1];//AddId(words[1]); //Ids[obshIndex] = words[1];//Ячейка под id
                _Type[obshIndex] = words[0];//AddType(words[0]); //Types[obshIndex] = words[0];//Ячейка под type
            
            int key;
            if (!FormMain.tactic)
            {//false
                key = Hash(words[1]);//В key ХЕШ//В words[1] ID
            }
            else//При повторном вводе
            {//true
                key = 42;//"*"=42 ascii
            }
            
                bool flag=false; int ent = 0;
                
                    
                    for (int i = 0; i < _Hash.Length; i++)
                    {
                        if (_Hash[i] == key)
                        {
                            ent = i; //
                            //MessageBox.Show("-------" + i);
                            //_Ch[i]=obshIndex; //znak
                            flag = true;
                            //break;
                        }
                    }

                    
                    Param(key, obshIndex, flag, ent);
                
                _Hash[obshIndex] = key;
            obshIndex++;
            }
            else
            {
                MessageBox.Show("Повторение по ID");
                _Id[obshIndex] = "*";
                _Type[obshIndex] = words[0];
                _Hash[obshIndex] = -42;
                obshIndex++;
                FormMain.flag = false;
            }
        }
        private void Param(int keyHash,int index,bool flag,int ent)
        {
            FormMain.key = keyHash;//formMain.key = keyHash;
            FormMain.index=index;//formMain.index = index;
            FormMain.flag = flag;
            FormMain.ent = ent;
        }
        
        private int Hash(string text)
        {//Вычислим хеш id
            int a = 0;
            for (int i = 0; i < text.Length; i++)
            {
                a += text[i];
            }
            int h = (a%_Num.Length);
            return h;
        }
        private bool Bastion(string word)
        {//Защита от повторного ввода
            bool key = false;
            for (int i = 0; i < _Id.Length-1; i++)
            {
                if (_Id[i] == word)//dd)
                {
                    key = true;
                }
            }
            return key;
        }
        //===================Вывод=============================//
        public int Num()
        { return _Num[obshIndex - 1]; }
        public string Id()
        { return _Id[obshIndex - 1]; }
        public string Type()
        { return _Type[obshIndex - 1]; }
        public int Hasher()
        { return _Hash[obshIndex - 1]; }
        public int Kollizi()
        { return _Ch[obshIndex - 1]; }
    }//end Class
}
