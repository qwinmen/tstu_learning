--Select distinct `Имя` From рег_даные

--Select distinct `Имя`, `Пол`, `Год` From рег_даные where `Пол` = 'М' and (`Год` not between 1980 and 1990) order by `Имя`

--Select distinct `Имя`, `Пол`, `Год` From рег_даные where `Пол` = 'М' and (`Год` in(1990, 1972, 1963)) order by `Имя`

--Select distinct `Имя`, `Пол`, `Год` From рег_даные where `Пол` = 'М' and (`Год` in(select `Год` From рег_даные where `Год` between 1980 and 1990)) order by `Имя`

--Select `Год` + `Число` as ЧислоГод From рег_даные where `Пол` = 'Ж'

--Select max(`Год`) from рег_даные

--distinct - вывод без совпадений
--Имя As Name - вывод псевдонима вместо названия
--Order by `Номер паспорта` asc|desc - сортировка вывода
--where - сформировать правила вывода
--between - попадание в интервал
--in(список_значений)
--Select From where in(Select ..) вложеный запрос будет списком при выводе внешним селектом

/*
Delete from справочная_информация where
 `Номер паспорта` = 1976438250792800
*/