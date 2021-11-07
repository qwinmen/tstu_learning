
int sort_bin (int* data, int size) //data - массив, size - размер массива
{
    int i;
    for (i = 0; i < size; i++)
	{
        int pos = -1;
        int start = 0;
        int end = i - 1;
        int numToInsert = data[i];
        // Ќаходим место вставки с помощью бинарного поиска
        while (start <= end && !(pos != -1)) 
		{
            int middle = (start + end) / 2;
            if (numToInsert > data[middle])
			{
                start = middle + 1;
            }
			else if (numToInsert < data[middle]) 
			{

                end = middle - 1;
            }
			else 
			{
                pos = middle;
            }
        }
		
        if(end < 0)
		{
            // определ€ем позицию в случае если элемент меньше всех отсортированных
            pos = 0;
        }

		else if(start >= i)
		{


            // определ€ем позицию в случае если элемент больше всех отсортированных
            pos = i;
        }
		
        if (pos < i) 
		{
            // сдвигаем элементы вправо на одну позицию
            int j;
            for (j = i; j > pos; j--) 
			{
                data[j] = data[j - 1];
            }








            data[pos] = numToInsert;
        }
    }
    return *data;//¬озвращает отсорт масив
}