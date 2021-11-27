CREATE TABLE `Рег_даные` (
  `№` int,
  `Имя` varchar(100),
  `Фамилия` varchar(100),
  `Отчество` varchar(100),
  `Число` int,
  `Месяц` int,
  `Год` int,
  `Пол` varchar(1),  
  `Номер паспорта` bigint,
  `Прописка` varchar(256),
  Primary key(`Номер паспорта`)  
)
;Select * From рег_даные
/********************************************************************************************/
Create table справочная_информация(`№` int, `Номер паспорта` bigint, `Состояние` varchar(40),		
	Primary key(`Состояние`) ,
	Foreign Key(`Номер паспорта`) References рег_даные(`Номер паспорта`)
	on delete cascade
	on update cascade
	);Select * From справочная_информация

	
/*
CREATE TABLE customers(
  id INT(11) NOT NULL,
  name VARCHAR(255) DEFAULT NULL,
  city VARCHAR(255) DEFAULT NULL,
  notes VARCHAR(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB;
 
CREATE TABLE jobs(
  id INT(11) DEFAULT NULL,
  customer_id INT(11) DEFAULT NULL,
  about VARCHAR(255) DEFAULT NULL,
  INDEX FK_jobs_customers_id (customer_id),
  CONSTRAINT FK_jobs_customers_id FOREIGN KEY (customer_id) REFERENCES customers (id)
)
ENGINE = INNODB;
*/