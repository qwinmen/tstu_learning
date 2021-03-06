/**
 * Суть лагранжа в следующем:
 * задаём массив из иксов и игриков, каждая пара - это точка
 * допустим, (0, 0), (1, 1), (2, 4). Такими точками мы "загадали"
 * параболу. Далее нас спрашивают "Где посчитать значение функции?",
 * и мы вводим, например "1.5" (вводить желательно между 0 и 2).
 *
 * Компьютер ничего не знал, мы не говорили ему, что мы загадали,
 * но он правильно отвечает нам - значение игрика в иксе равном 1.5
 * равно 2.25. В этом и заключается смысл программы и математический
 * смысл полинома (многочлена) Лагранжа. Он выдаёт такой полином, что
 * график его функции проходит через все точки, которые мы ввели.
 *
 * Конечно, можно ввести такие точки, что он не угадает, что мы имели
 * в виду. Особенно, если вводилось большое количество точек.
 **/

class lagrange
{
	double *x, *y;
	//будущие массивы
	int n;
	//количество точек (см. конструктор в lagrange.cpp)
	
public:
	lagrange();
	//конструктор (кроме чем как по-умолчанию не используем)
	~lagrange (void);
	//деконструктор (можно и не использовать вообще)
	void show (void);
	//распечатка созданного объекта
	double polynomial (double);
	//вычисление полинома по формуле
};
