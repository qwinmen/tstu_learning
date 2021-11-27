--Insert into page (`Name`, `Price`, `litraj`) values 
--('Пиво', 149, 40), ('Кола', 14, 0.5), ('Водка', 250, 10),
--('Квас', 70, 5), ('Швепс', 70, 40), ('Ликер', 149, 10),
--('Махито', 30, 1.6), ('Баржоми', 30, 40), ('Кифир', 11, 0.1);

Select * From page;
--Select Name as Имя, Price as Цена, litraj as Литры from page WHERE Price = 30 order by Name;
--Select Name as Имя, Price as Цена, litraj as Литры from page WHERE Name = "Махито" and Price = 30 order by Name;
--Select `Name`, `Price`, `litraj` from `page` WHERE `Price` = 30 AND `Name` = "Махито" order by id;
--Select `Name`, `Price`, `litraj` from `page` WHERE Length(`Price`) > 1;