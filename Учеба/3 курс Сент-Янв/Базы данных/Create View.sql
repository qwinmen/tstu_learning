--create view reginfo as Select max(`Год`) from рег_даные
--create or replace view nameinfo as Select `Год` + `Число` as ЧислоГод From рег_даные ;
--create or replace view nameinfo as Select * from рег_даные where (`Год` between 1980 and 1990);

Select min(`Имя`) from рег_даные where (`Год`);
--Select * from рег_даные;
--Select * from reginfo;
--Select distinct `Имя`, `Пол`, `Год` From рег_даные where `Пол` = 'М' and (`Год` not between 1980 and 1990) order by `Имя`
--create or replace view nameinfo as Select рег_даные (`Имя`,`Год`) where `Год` = "1970";

--create or replace view allTab as Select * From рег_даные  where  (`Год` between 1980 and 1990) order by `Имя`;
--Select * from allTab;
