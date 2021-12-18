-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Апр 10 2016 г., 16:23
-- Версия сервера: 5.6.24
-- Версия PHP: 5.6.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `cdcol`
--

-- --------------------------------------------------------

--
-- Структура таблицы `cds`
--

CREATE TABLE IF NOT EXISTS `cds` (
  `titel` varchar(200) COLLATE latin1_general_ci DEFAULT NULL,
  `interpret` varchar(200) COLLATE latin1_general_ci DEFAULT NULL,
  `jahr` int(11) DEFAULT NULL,
  `id` bigint(20) unsigned NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Дамп данных таблицы `cds`
--

INSERT INTO `cds` (`titel`, `interpret`, `jahr`, `id`) VALUES
('Beauty', 'Ryuichi Sakamoto', 1990, 1),
('Goodbye Country (Hello Nightclub)', 'Groove Armada', 2001, 4),
('Glee', 'Bran Van 3000', 1997, 5);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `cds`
--
ALTER TABLE `cds`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `cds`
--
ALTER TABLE `cds`
  MODIFY `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;--
-- База данных: `diplom`
--

-- --------------------------------------------------------

--
-- Структура таблицы `aglomerator`
--

CREATE TABLE IF NOT EXISTS `aglomerator` (
  `имя` varchar(100) NOT NULL,
  `цена` int(11) NOT NULL,
  `фото` text NOT NULL,
  `производительность` int(11) NOT NULL,
  `размергранулы` int(11) NOT NULL,
  `чвротор` int(11) NOT NULL,
  `мощность` int(11) NOT NULL,
  `габариты` varchar(100) NOT NULL,
  `загрузпроем` int(11) NOT NULL,
  `ножи` int(11) NOT NULL,
  `масса` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `aglomerator`
--

INSERT INTO `aglomerator` (`имя`, `цена`, `фото`, `производительность`, `размергранулы`, `чвротор`, `мощность`, `габариты`, `загрузпроем`, `ножи`, `масса`) VALUES
('АГМТ30', 570000, 'agm90s.jpg', 100, 8, 1500, 30, '1800 х 950 х 1465', 200, 12, 400),
('АГМ-15', 300000, 'agglomerator.jpg', 70, 9, 1500, 15, '1400х650х1250', 510, 4, 600),
('АГМ-75', 450000, 'agm55.gif', 250, 5, 2000, 75, '2200х1000х1900', 820, 6, 1750),
('OULI-300', 645000, 'ouli-200.jpg', 300, 5, 2000, 37, '2000 x 1000 x 1400', 300, 9, 1400);

-- --------------------------------------------------------

--
-- Структура таблицы `drobilka`
--

CREATE TABLE IF NOT EXISTS `drobilka` (
  `имя` varchar(100) NOT NULL,
  `цена` int(11) NOT NULL,
  `фото` text NOT NULL,
  `производительность` int(11) NOT NULL,
  `мощность` double NOT NULL,
  `загрузпроем` varchar(100) NOT NULL,
  `ротацнож` int(11) NOT NULL,
  `стационнож` int(11) NOT NULL,
  `габариты` varchar(100) NOT NULL,
  `масса` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `drobilka`
--

INSERT INTO `drobilka` (`имя`, `цена`, `фото`, `производительность`, `мощность`, `загрузпроем`, `ротацнож`, `стационнож`, `габариты`, `масса`) VALUES
('HSS200', 80000, 'hss_a.jpg', 100, 5.5, '250х400', 20, 2, '795х770х1300', 500),
('HSS 230 A', 84368, 'hss_a.jpg', 200, 4, '230x160', 6, 2, '1080x760x1200', 500),
('HSS 300 A', 84368, 'hss_a.jpg', 300, 5.5, '300x210', 9, 2, '1310x930x1310', 540),
('HSS 400 A', 84368, 'hss_a.jpg', 550, 7.5, '400x250', 12, 2, '1420x1070x1530\r\n', 550),
('HSS 500 A', 84368, 'hss_a.jpg', 580, 11, '500x250', 15, 2, '1530x1170x1530', 500),
('HSS 600 A', 84368, 'hss_a.jpg', 600, 15, '600x310', 18, 4, '1610x1290x1820', 550),
('HSS 700 A', 100000, 'hss_a.jpg', 700, 18.5, '700x310', 21, 4, '1610x1390x1820', 550),
('HSS 800 A', 100000, 'hss_a.jpg', 800, 22, '800x420', 24, 4, '1860x1610x2280', 560),
('HSS 800 C', 130000, 'hss_c.jpg', 800, 22, '800x420', 39, 4, '1860x1610x2280', 1850),
('HSS 300 B', 193343, 'hss_b.jpg', 50, 5.5, '300x210', 3, 2, '1310х930х1310', 428),
('WT 30-80', 124600, '1x_shreder.jpg', 500, 30, '1280х880', 42, 4, '2466x1677x1700', 1950);

-- --------------------------------------------------------

--
-- Структура таблицы `ekstruder`
--

CREATE TABLE IF NOT EXISTS `ekstruder` (
  `имя` varchar(100) NOT NULL,
  `цена` int(11) NOT NULL,
  `фото` text NOT NULL,
  `производительность` int(11) NOT NULL,
  `скоростьшнека` int(11) NOT NULL,
  `регулиртемпература` varchar(100) NOT NULL,
  `погрешностьтемператур` double NOT NULL,
  `мощность` int(11) NOT NULL,
  `габариты` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `ekstruder`
--

INSERT INTO `ekstruder` (`имя`, `цена`, `фото`, `производительность`, `скоростьшнека`, `регулиртемпература`, `погрешностьтемператур`, `мощность`, `габариты`) VALUES
('SJSZ', 1900000, 'shekkovuy_ekstruder_iz_kitaya.jpg', 500, 25, 'от 100 до 400', 0.1, 37, '4200 х 680 х 1200');

-- --------------------------------------------------------

--
-- Структура таблицы `konteiner`
--

CREATE TABLE IF NOT EXISTS `konteiner` (
  `имя` varchar(100) NOT NULL,
  `описание` text NOT NULL,
  `цена` double NOT NULL,
  `фото` text,
  `температура` varchar(100) NOT NULL,
  `размеры` text NOT NULL,
  `грузоподьемность` int(11) NOT NULL,
  `вес` int(11) NOT NULL,
  `толщина` int(11) NOT NULL,
  `конструкция` varchar(100) NOT NULL,
  `окраска` varchar(100) NOT NULL,
  `цвет` varchar(100) NOT NULL,
  `обьем` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `konteiner`
--

INSERT INTO `konteiner` (`имя`, `описание`, `цена`, `фото`, `температура`, `размеры`, `грузоподьемность`, `вес`, `толщина`, `конструкция`, `окраска`, `цвет`, `обьем`) VALUES
('КГ-12', 'Тара (контейнер металлический) предназначен для хранения и перемещения изделий.\r\nИзготовлен в соответствии с нормативными документами.\r\nКонтейнер прошел испытания, проверен и принят службой контроля продукции (ОТК) предприятия изготовителя.\r\nКонтейнер признан годным для эксплуатации с указанными в паспорте параметрами.\r\nУсловия, при которых может эксплуатироваться контейнер от -40С до +40С.\r\n', 23873, 'i-423211-01.jpg', 'от -40С до +40С', '1000х1700х1000', 1200, 220, 3, 'сварная', 'ПФ-эмаль', 'серый', 100),
('КГ-01', '•	Грузовой контейнер типа КГ предназначен для транспортировки и хранения мелкоштучных грузов.\r\n•	Контейнер металлический представляет собой сварную неразборную конструкцию.\r\n•	Контейнер для склада и производства покрыт грунтом гф-021.\r\n•	Грузоподъемность  - до 500 кг.\r\n•	Изделие может быть изготовлено на заказ:\r\n- с откидным бортом. \r\n- порошковая окраска с откидным бортом. \r\n•	Стоимость изготовления нестандартных контейнеров уточняйте у менеджеров компании "Версия".\r\n•	Основные параметры и данные по окружающей среде:\r\n- наименьшая температура,  - 40С \r\n- наибольшая температура,  +40С \r\n•	Изделие изготовлено в соответствии с требованиями ГОСТ 19822 - 88 «Контейнер тара производственная. Технические условия», ГОСТ 12.3. 1 0 - 82 «ССБТ. Контейнер тара производственная. Требования безопасности при эксплуатации», а так же с соблюдением правил эксплуатации техники предусмотренных ПБ - 10 - 382 - 00 «Правила устройства и безопасной эксплуатации грузоподъёмных кранов», СНиП 12 - 03 - 2001 «Безопасность труда в строительстве», по рабочим чертежам, утвержденным в установленном порядке. \r\n•	Контейнер имеет фиксирующие устройства, обеспечивающие устойчивость при его штабелировании.\r\n•	Срок службы контейнера грузового металлического – 6 лет, контейнера, используемого с применением только автоматических средств транспортирования - 8 лет.', 5283, 'kg01_a_big.jpg', 'от +40С до -40С', '450x600x400', 500, 22, 3, 'сварная', 'ПФ-эмаль', 'серый или синий', 40),
('КГ-17', '•	Металлический контейнер типа КГ предназначен для транспортировки и хранения мелкоштучных грузов.\r\n•	Контейнер металлический представляет собой сварную неразборную конструкцию.\r\n•	Контейнер для склада и производства покрыт грунтом гф-021.\r\n•	Грузоподъемность- до 800 кг.\r\n•	Изделие может быть изготовлено на заказ:\r\n- с откидным бортом. \r\n- порошковая окраска с откидным бортом. \r\n•	Купить грузовой контейнер недорого можно только от производителя – изготавливаем изделия из металла уже более 20 лет!\r\n•	Стоимость изготовления нестандартных контейнеров уточняйте у менеджеров компании "Версия".\r\n•	Основные параметры и данные по окружающей среде:\r\n- наименьшая температура- 40С \r\n- наибольшая температура+40С \r\n•	Изделие изготовлено в соответствии с требованиями ГОСТ 19822 - 88 «Контейнер тара производственная. Технические условия», ГОСТ 12.3. 1 0 - 82 «ССБТ. Контейнер тара производственная. Требования безопасности при эксплуатации», а так же с соблюдением правил эксплуатации техники предусмотренных ПБ - 10 - 382 - 00 «Правила устройства и безопасной эксплуатации грузоподъёмных кранов», СНиП 12 - 03 - 2001 «Безопасность труда в строительстве», по рабочим чертежам, утвержденным в установленном порядке. \r\n•	Контейнер имеет фиксирующие устройства, обеспечивающие устойчивость при его штабелировании.\r\n•	Срок службы контейнера металлического металлического – 6 лет, контейнера, используемого с применением только автоматических средств транспортирования - 8 лет.\r\n', 13600, 'kg17_big.jpg', 'от +40С до -40С', '1050х1600х1000', 800, 106, 3, 'сварная', 'ПФ-эмаль', 'серый или синий', 1300),
('КС-03', '•	Контейнер металлический типа КС предназначен для хранения и транспортировки изделий в производственных, складских комплексах. Контейнер сетчатый для склада представляет собой сварную конструкцию.\r\n•	Наличие опорных швеллеров позволяет устанавливать контейнер на ригеля стеллажей, обеспечивает возможность транспортировки вилочными погрузчиками, гидравлическими ручными тележками. Наличие кронштейнов на верхней поверхности металлического контейнера позволяет обеспечивать их транспортировку грузоподъемным транспортом и надежно устанавливать контейнеры друг на друга (штабелирование до 5-ти рядов).\r\n•	Стойки и перекладины изготовлены из стальных гнутых профилей толщиной 2 мм.\r\n•	Дно контейнера изготовлено из стального листа толщиной 2 мм с дополнительными зигами для увеличения жесткости.\r\n•	Металлическая сетка на боковых сторонах с ячейкой 50*50 мм, толщина проволоки - 4 мм.\r\n•	Возможна установка открывающейся боковой створки с задвижками.\r\n•	Контейнер сетчатый для склада металлический (ящичная тара) изготовлен в соответствии с требованиями ГОСТ 19822 - 88 «Тара производственная. Технические условия», а так же с соблюдением правил эксплуатации техники предусмотренных ПБ - 10- 382 - 00 «Правила устройства и безопасной эксплуатации грузоподъёмных кранов».\r\n•	Срок службы контейнера металлического – 6 лет, срок службы контейнера, используемого с применением только автоматических средств транспортирования - 8 лет.\r\n•	Металлический контейнер типа КС может быть изготовлен на заказ в следующих модификациях:\r\n- с крышкой;\r\n- с откидным бортом\r\n- окрашен порошковой краской.\r\n', 6796, 'ks03_big_2.jpg', 'от +40С до -40С', '600х600х800', 1200, 33, 4, 'сетчатый', 'ПФ-эмаль', 'серый или синий', 180),
('КС-08', '•	Контейнер металлический типа КС предназначен для хранения и транспортировки изделий в производственных, складских комплексах. Контейнер представляет собой сварную конструкцию.\r\n•	Наличие опорных швеллеров позволяет устанавливать контейнер сетчатый для склада на ригеля стеллажей, обеспечивает возможность транспортировки вилочными погрузчиками, гидравлическими ручными тележками.Наличие кронштейнов на верхней поверхности металлического контейнера позволяет обеспечивать их транспортировку грузоподъемным транспортом и надежно устанавливать контейнеры друг на друга (штабелирование до 5-ти рядов).\r\n•	Стойки и перекладины изготовлены из стальных гнутых профилей толщиной 2 мм.\r\n•	Дно контейнера сетчатого для склада изготовлено из стального листа толщиной 2 мм с дополнительными зигами для увеличения жесткости.\r\n•	Металлическая сетка на боковых сторонах с ячейкой 50*50 мм, толщина проволоки - 4 мм.\r\n•	Возможна установка открывающейся боковой створки с задвижками.\r\n•	Контейнер металлический (ящичная тара) изготовлен в соответствии с требованиями ГОСТ 19822 - 88 «Тара производственная. Технические условия», а так же с соблюдением правил эксплуатации техники предусмотренных ПБ - 10- 382 - 00 «Правила устройства и безопасной эксплуатации грузоподъёмных кранов».\r\n•	Срок службы контейнера металлического – 6 лет, срок службы контейнера, используемого с применением только автоматических средств транспортирования - 8 лет.\r\n•	Металлический контейнер сетчатый для склада типа КС может быть изготовлен на заказ в следующих модификациях:\r\n- с крышкой;\r\n- с откидным бортом\r\n- окрашен порошковой краской.\r\n', 8724, 'ks08_big_1.jpg', 'от -40С до +40С', '600х800х1200', 900, 48, 4, 'сетчатый', 'ПФ-эмаль', 'серый или синий', 350),
('КС-18', '•	Контейнер металлический типа КС предназначен для хранения и транспортировки изделий в производственных, складских комплексах. Контейнер представляет собой сварную конструкцию.\r\n•	Наличие опорных швеллеров позволяет устанавливать контейнер сетчатый для склада на ригеля стеллажей, обеспечивает возможность транспортировки вилочными погрузчиками, гидравлическими ручными тележками.Наличие кронштейнов на верхней поверхности металлического контейнера позволяет обеспечивать их транспортировку грузоподъемным транспортом и надежно устанавливать контейнеры друг на друга (штабелирование до 5-ти рядов).\r\n•	Стойки и перекладины изготовлены из стальных гнутых профилей толщиной 2 мм.\r\n•	Дно контейнера сетчатого для склада изготовлено из стального листа толщиной 2 мм с дополнительными зигами для увеличения жесткости.\r\n•	Металлическая сетка на боковых сторонах с ячейкой 50*50 мм, толщина проволоки - 4 мм.\r\n•	Возможна установка открывающейся боковой створки с задвижками.\r\n•	Контейнер металлический (ящичная тара) изготовлен в соответствии с требованиями ГОСТ 19822 - 88 «Тара производственная. Технические условия», а так же с соблюдением правил эксплуатации техники предусмотренных ПБ - 10- 382 - 00 «Правила устройства и безопасной эксплуатации грузоподъёмных кранов».\r\n•	Срок службы контейнера металлического – 6 лет, срок службы контейнера, используемого с применением только автоматических средств транспортирования - 8 лет.\r\n•	Металлический контейнер сетчатый для склада типа КС может быть изготовлен на заказ в следующих модификациях:\r\n- с крышкой;\r\n- с откидным бортом\r\n- окрашен порошковой краской.\r\n', 10744, 'ks18_big_3.jpg', 'от +40С до -40С', '1150х1000х1600', 700, 82, 4, 'сетчатый', 'ПФ-эмаль', 'серый или синий', 1470);

-- --------------------------------------------------------

--
-- Структура таблицы `konveer`
--

CREATE TABLE IF NOT EXISTS `konveer` (
  `имя` varchar(100) NOT NULL,
  `цена` int(11) NOT NULL,
  `фото` text NOT NULL,
  `ширина` int(11) NOT NULL,
  `длина` double NOT NULL,
  `скорость` text NOT NULL,
  `наклон` text NOT NULL,
  `привод` text NOT NULL,
  `дипривод` text NOT NULL,
  `динатяжного` text NOT NULL,
  `дироликов` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `konveer`
--

INSERT INTO `konveer` (`имя`, `цена`, `фото`, `ширина`, `длина`, `скорость`, `наклон`, `привод`, `дипривод`, `динатяжного`, `дироликов`) VALUES
('КЛС4', 90000, 'tr7_300.jpg', 400, 200, '0.2-2.2', '0-18', 'Мотор-редуктор', '220-420', '220-420', '51-108'),
('КЛС5', 90000, 'tr7_300.jpg', 500, 250, '0.2-2.5', '0-18', 'Мотор-редуктор', '220-530', '220-530', '51-127'),
('КЛС6', 105000, '99e8b20e608b86227f56703b58bffb34.jpg', 650, 300, '0.2-2.5', '0-18', 'Мотор-редуктор', '220-530', '220-530', '51-159'),
('КЛС8', 105000, '99e8b20e608b86227f56703b58bffb34.jpg', 800, 500, '0.25-2.5', '0-18', 'Мотор-редуктор', '220-530', '220-530', '76-159'),
('КЛС10', 113500, '99e8b20e608b86227f56703b58bffb34.jpg', 1000, 500, '0.25-3.2', '19-45', 'Мотор-редуктор', '320-530', '320-530', '76-159'),
('КЛС12', 120000, '99e8b20e608b86227f56703b58bffb34.jpg', 1200, 500, '0.25-3.5', '19-45', 'Мотор-редуктор', '320-530', '320-530', '76-159'),
('КЛС14', 120000, '99e8b20e608b86227f56703b58bffb34.jpg', 1400, 500, '0.25-3.5', '19-45', 'Мотор-редуктор', '420-630', '420-630', '108-159'),
('КЛС16', 125000, '99e8b20e608b86227f56703b58bffb34.jpg', 1600, 700, '0.4-3.5', '19-45', 'Цилиндро-конический', '420-630', '420-630', '108-159'),
('КЛС18', 125000, '99e8b20e608b86227f56703b58bffb34.jpg', 1800, 700, '0.4-3.5', '19-45', 'Планетарный', '420-830', '420-830', '127-159'),
('КЛС20', 125000, '99e8b20e608b86227f56703b58bffb34.jpg', 2000, 700, '0.4-3.5', '0-45', 'Мотор-барабан', '530-830', '530-830', '127-159'),
('КЛС22', 130000, '99e8b20e608b86227f56703b58bffb34.jpg', 2200, 700, '0.6-3.5', '45-90', 'Мотор-барабан', '530-830', '530-830', '127-159'),
('КЛС11ф', 130000, '99e8b20e608b86227f56703b58bffb34.jpg', 2100, 750, '0.6-3.5', '19-45', 'Цилиндро-конический', '530-630', '530-630', '76-159'),
('КЛ-600-7', 240000, '104857807_w640_h640_500_produce_1370329021.jpg', 600, 700, '0.6', '35', 'Мотор-барабан', '220-420', '220-420', '51-108');

-- --------------------------------------------------------

--
-- Структура таблицы `magnit`
--

CREATE TABLE IF NOT EXISTS `magnit` (
  `имя` varchar(100) NOT NULL,
  `цена` int(11) NOT NULL,
  `фото` text NOT NULL,
  `габариты` varchar(100) NOT NULL,
  `ширина` int(11) NOT NULL,
  `глубина` int(11) NOT NULL,
  `масса` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `magnit`
--

INSERT INTO `magnit` (`имя`, `цена`, `фото`, `габариты`, `ширина`, `глубина`, `масса`) VALUES
('СМПА 500', 15000, '12ed41a4e08de10d7b6696134afb454a.png', '1115х1073х380', 500, 300, 450),
('СМПА 650 ', 15000, 'Снимок.PNG', '1320х1073х380', 650, 350, 600),
('СМПА-ТМ 1200', 25000, '12ed41a4e08de10d7b6696134afb454a.png', '2185х1950х490', 1200, 450, 2700),
('СМПА-М 1600', 25000, '12ed41a4e08de10d7b6696134afb454a.png', '2521х1748х490', 1600, 450, 2150);

-- --------------------------------------------------------

--
-- Структура таблицы `peskosuwilka`
--

CREATE TABLE IF NOT EXISTS `peskosuwilka` (
  `имя` varchar(100) NOT NULL,
  `цена` int(11) NOT NULL,
  `фото` text NOT NULL,
  `производительность` int(11) NOT NULL,
  `фракциявыход` double NOT NULL,
  `влажностьвыход` int(11) NOT NULL,
  `чвротор` int(11) NOT NULL,
  `мощность` int(11) NOT NULL,
  `температуракамеры` int(11) NOT NULL,
  `времянагревакамеры` int(11) NOT NULL,
  `времясушки` int(11) NOT NULL,
  `загрузка` int(11) NOT NULL,
  `габариты` varchar(100) NOT NULL,
  `масса` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `peskosuwilka`
--

INSERT INTO `peskosuwilka` (`имя`, `цена`, `фото`, `производительность`, `фракциявыход`, `влажностьвыход`, `чвротор`, `мощность`, `температуракамеры`, `времянагревакамеры`, `времясушки`, `загрузка`, `габариты`, `масса`) VALUES
('Р-03', 150000, '422.jpg', 300, 3, 1, 4, 9, 120, 40, 12, 50, '2475 х 950 х1465', 1000),
('Р-07л', 119000, '2090109200.jpg', 250, 3.8, 1, 4, 9, 130, 45, 11, 40, '2475 х 950 х1465', 1000);
--
-- База данных: `modx`
--

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_actiondom`
--

CREATE TABLE IF NOT EXISTS `modx_access_actiondom` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_actions`
--

CREATE TABLE IF NOT EXISTS `modx_access_actions` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_category`
--

CREATE TABLE IF NOT EXISTS `modx_access_category` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0',
  `context_key` varchar(100) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_context`
--

CREATE TABLE IF NOT EXISTS `modx_access_context` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_access_context`
--

INSERT INTO `modx_access_context` (`id`, `target`, `principal_class`, `principal`, `authority`, `policy`) VALUES
(1, 'web', 'modUserGroup', 0, 9999, 3),
(2, 'mgr', 'modUserGroup', 1, 0, 2),
(3, 'web', 'modUserGroup', 1, 0, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_elements`
--

CREATE TABLE IF NOT EXISTS `modx_access_elements` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0',
  `context_key` varchar(100) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_media_source`
--

CREATE TABLE IF NOT EXISTS `modx_access_media_source` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0',
  `context_key` varchar(100) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_menus`
--

CREATE TABLE IF NOT EXISTS `modx_access_menus` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_permissions`
--

CREATE TABLE IF NOT EXISTS `modx_access_permissions` (
  `id` int(10) unsigned NOT NULL,
  `template` int(10) unsigned NOT NULL DEFAULT '0',
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` text NOT NULL,
  `value` tinyint(1) unsigned NOT NULL DEFAULT '1'
) ENGINE=MyISAM AUTO_INCREMENT=215 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_access_permissions`
--

INSERT INTO `modx_access_permissions` (`id`, `template`, `name`, `description`, `value`) VALUES
(1, 1, 'about', 'perm.about_desc', 1),
(2, 1, 'access_permissions', 'perm.access_permissions_desc', 1),
(3, 1, 'actions', 'perm.actions_desc', 1),
(4, 1, 'change_password', 'perm.change_password_desc', 1),
(5, 1, 'change_profile', 'perm.change_profile_desc', 1),
(6, 1, 'charsets', 'perm.charsets_desc', 1),
(7, 1, 'class_map', 'perm.class_map_desc', 1),
(8, 1, 'components', 'perm.components_desc', 1),
(9, 1, 'content_types', 'perm.content_types_desc', 1),
(10, 1, 'countries', 'perm.countries_desc', 1),
(11, 1, 'create', 'perm.create_desc', 1),
(12, 1, 'credits', 'perm.credits_desc', 1),
(13, 1, 'customize_forms', 'perm.customize_forms_desc', 1),
(14, 1, 'dashboards', 'perm.dashboards_desc', 1),
(15, 1, 'database', 'perm.database_desc', 1),
(16, 1, 'database_truncate', 'perm.database_truncate_desc', 1),
(17, 1, 'delete_category', 'perm.delete_category_desc', 1),
(18, 1, 'delete_chunk', 'perm.delete_chunk_desc', 1),
(19, 1, 'delete_context', 'perm.delete_context_desc', 1),
(20, 1, 'delete_document', 'perm.delete_document_desc', 1),
(21, 1, 'delete_eventlog', 'perm.delete_eventlog_desc', 1),
(22, 1, 'delete_plugin', 'perm.delete_plugin_desc', 1),
(23, 1, 'delete_propertyset', 'perm.delete_propertyset_desc', 1),
(24, 1, 'delete_snippet', 'perm.delete_snippet_desc', 1),
(25, 1, 'delete_template', 'perm.delete_template_desc', 1),
(26, 1, 'delete_tv', 'perm.delete_tv_desc', 1),
(27, 1, 'delete_role', 'perm.delete_role_desc', 1),
(28, 1, 'delete_user', 'perm.delete_user_desc', 1),
(29, 1, 'directory_chmod', 'perm.directory_chmod_desc', 1),
(30, 1, 'directory_create', 'perm.directory_create_desc', 1),
(31, 1, 'directory_list', 'perm.directory_list_desc', 1),
(32, 1, 'directory_remove', 'perm.directory_remove_desc', 1),
(33, 1, 'directory_update', 'perm.directory_update_desc', 1),
(34, 1, 'edit_category', 'perm.edit_category_desc', 1),
(35, 1, 'edit_chunk', 'perm.edit_chunk_desc', 1),
(36, 1, 'edit_context', 'perm.edit_context_desc', 1),
(37, 1, 'edit_document', 'perm.edit_document_desc', 1),
(38, 1, 'edit_locked', 'perm.edit_locked_desc', 1),
(39, 1, 'edit_plugin', 'perm.edit_plugin_desc', 1),
(40, 1, 'edit_propertyset', 'perm.edit_propertyset_desc', 1),
(41, 1, 'edit_role', 'perm.edit_role_desc', 1),
(42, 1, 'edit_snippet', 'perm.edit_snippet_desc', 1),
(43, 1, 'edit_template', 'perm.edit_template_desc', 1),
(44, 1, 'edit_tv', 'perm.edit_tv_desc', 1),
(45, 1, 'edit_user', 'perm.edit_user_desc', 1),
(46, 1, 'element_tree', 'perm.element_tree_desc', 1),
(47, 1, 'empty_cache', 'perm.empty_cache_desc', 1),
(48, 1, 'error_log_erase', 'perm.error_log_erase_desc', 1),
(49, 1, 'error_log_view', 'perm.error_log_view_desc', 1),
(50, 1, 'export_static', 'perm.export_static_desc', 1),
(51, 1, 'file_create', 'perm.file_create_desc', 1),
(52, 1, 'file_list', 'perm.file_list_desc', 1),
(53, 1, 'file_manager', 'perm.file_manager_desc', 1),
(54, 1, 'file_remove', 'perm.file_remove_desc', 1),
(55, 1, 'file_tree', 'perm.file_tree_desc', 1),
(56, 1, 'file_update', 'perm.file_update_desc', 1),
(57, 1, 'file_upload', 'perm.file_upload_desc', 1),
(58, 1, 'file_view', 'perm.file_view_desc', 1),
(59, 1, 'flush_sessions', 'perm.flush_sessions_desc', 1),
(60, 1, 'frames', 'perm.frames_desc', 1),
(61, 1, 'help', 'perm.help_desc', 1),
(62, 1, 'home', 'perm.home_desc', 1),
(63, 1, 'import_static', 'perm.import_static_desc', 1),
(64, 1, 'languages', 'perm.languages_desc', 1),
(65, 1, 'lexicons', 'perm.lexicons_desc', 1),
(66, 1, 'list', 'perm.list_desc', 1),
(67, 1, 'load', 'perm.load_desc', 1),
(68, 1, 'logout', 'perm.logout_desc', 1),
(69, 1, 'logs', 'perm.logs_desc', 1),
(70, 1, 'menu_reports', 'perm.menu_reports_desc', 1),
(71, 1, 'menu_security', 'perm.menu_security_desc', 1),
(72, 1, 'menu_site', 'perm.menu_site_desc', 1),
(73, 1, 'menu_support', 'perm.menu_support_desc', 1),
(74, 1, 'menu_system', 'perm.menu_system_desc', 1),
(75, 1, 'menu_tools', 'perm.menu_tools_desc', 1),
(76, 1, 'menu_user', 'perm.menu_user_desc', 1),
(77, 1, 'menus', 'perm.menus_desc', 1),
(78, 1, 'messages', 'perm.messages_desc', 1),
(79, 1, 'namespaces', 'perm.namespaces_desc', 1),
(80, 1, 'new_category', 'perm.new_category_desc', 1),
(81, 1, 'new_chunk', 'perm.new_chunk_desc', 1),
(82, 1, 'new_context', 'perm.new_context_desc', 1),
(83, 1, 'new_document', 'perm.new_document_desc', 1),
(84, 1, 'new_static_resource', 'perm.new_static_resource_desc', 1),
(85, 1, 'new_symlink', 'perm.new_symlink_desc', 1),
(86, 1, 'new_weblink', 'perm.new_weblink_desc', 1),
(87, 1, 'new_document_in_root', 'perm.new_document_in_root_desc', 1),
(88, 1, 'new_plugin', 'perm.new_plugin_desc', 1),
(89, 1, 'new_propertyset', 'perm.new_propertyset_desc', 1),
(90, 1, 'new_role', 'perm.new_role_desc', 1),
(91, 1, 'new_snippet', 'perm.new_snippet_desc', 1),
(92, 1, 'new_template', 'perm.new_template_desc', 1),
(93, 1, 'new_tv', 'perm.new_tv_desc', 1),
(94, 1, 'new_user', 'perm.new_user_desc', 1),
(95, 1, 'packages', 'perm.packages_desc', 1),
(96, 1, 'policy_delete', 'perm.policy_delete_desc', 1),
(97, 1, 'policy_edit', 'perm.policy_edit_desc', 1),
(98, 1, 'policy_new', 'perm.policy_new_desc', 1),
(99, 1, 'policy_save', 'perm.policy_save_desc', 1),
(100, 1, 'policy_view', 'perm.policy_view_desc', 1),
(101, 1, 'policy_template_delete', 'perm.policy_template_delete_desc', 1),
(102, 1, 'policy_template_edit', 'perm.policy_template_edit_desc', 1),
(103, 1, 'policy_template_new', 'perm.policy_template_new_desc', 1),
(104, 1, 'policy_template_save', 'perm.policy_template_save_desc', 1),
(105, 1, 'policy_template_view', 'perm.policy_template_view_desc', 1),
(106, 1, 'property_sets', 'perm.property_sets_desc', 1),
(107, 1, 'providers', 'perm.providers_desc', 1),
(108, 1, 'publish_document', 'perm.publish_document_desc', 1),
(109, 1, 'purge_deleted', 'perm.purge_deleted_desc', 1),
(110, 1, 'remove', 'perm.remove_desc', 1),
(111, 1, 'remove_locks', 'perm.remove_locks_desc', 1),
(112, 1, 'resource_duplicate', 'perm.resource_duplicate_desc', 1),
(113, 1, 'resourcegroup_delete', 'perm.resourcegroup_delete_desc', 1),
(114, 1, 'resourcegroup_edit', 'perm.resourcegroup_edit_desc', 1),
(115, 1, 'resourcegroup_new', 'perm.resourcegroup_new_desc', 1),
(116, 1, 'resourcegroup_resource_edit', 'perm.resourcegroup_resource_edit_desc', 1),
(117, 1, 'resourcegroup_resource_list', 'perm.resourcegroup_resource_list_desc', 1),
(118, 1, 'resourcegroup_save', 'perm.resourcegroup_save_desc', 1),
(119, 1, 'resourcegroup_view', 'perm.resourcegroup_view_desc', 1),
(120, 1, 'resource_quick_create', 'perm.resource_quick_create_desc', 1),
(121, 1, 'resource_quick_update', 'perm.resource_quick_update_desc', 1),
(122, 1, 'resource_tree', 'perm.resource_tree_desc', 1),
(123, 1, 'save', 'perm.save_desc', 1),
(124, 1, 'save_category', 'perm.save_category_desc', 1),
(125, 1, 'save_chunk', 'perm.save_chunk_desc', 1),
(126, 1, 'save_context', 'perm.save_context_desc', 1),
(127, 1, 'save_document', 'perm.save_document_desc', 1),
(128, 1, 'save_plugin', 'perm.save_plugin_desc', 1),
(129, 1, 'save_propertyset', 'perm.save_propertyset_desc', 1),
(130, 1, 'save_role', 'perm.save_role_desc', 1),
(131, 1, 'save_snippet', 'perm.save_snippet_desc', 1),
(132, 1, 'save_template', 'perm.save_template_desc', 1),
(133, 1, 'save_tv', 'perm.save_tv_desc', 1),
(134, 1, 'save_user', 'perm.save_user_desc', 1),
(135, 1, 'search', 'perm.search_desc', 1),
(136, 1, 'settings', 'perm.settings_desc', 1),
(137, 1, 'source_save', 'perm.source_save_desc', 1),
(138, 1, 'source_delete', 'perm.source_delete_desc', 1),
(139, 1, 'source_edit', 'perm.source_edit_desc', 1),
(140, 1, 'source_view', 'perm.source_view_desc', 1),
(141, 1, 'sources', 'perm.sources_desc', 1),
(142, 1, 'steal_locks', 'perm.steal_locks_desc', 1),
(143, 1, 'tree_show_element_ids', 'perm.tree_show_element_ids_desc', 1),
(144, 1, 'tree_show_resource_ids', 'perm.tree_show_resource_ids_desc', 1),
(145, 1, 'undelete_document', 'perm.undelete_document_desc', 1),
(146, 1, 'unpublish_document', 'perm.unpublish_document_desc', 1),
(147, 1, 'unlock_element_properties', 'perm.unlock_element_properties_desc', 1),
(148, 1, 'usergroup_delete', 'perm.usergroup_delete_desc', 1),
(149, 1, 'usergroup_edit', 'perm.usergroup_edit_desc', 1),
(150, 1, 'usergroup_new', 'perm.usergroup_new_desc', 1),
(151, 1, 'usergroup_save', 'perm.usergroup_save_desc', 1),
(152, 1, 'usergroup_user_edit', 'perm.usergroup_user_edit_desc', 1),
(153, 1, 'usergroup_user_list', 'perm.usergroup_user_list_desc', 1),
(154, 1, 'usergroup_view', 'perm.usergroup_view_desc', 1),
(155, 1, 'view', 'perm.view_desc', 1),
(156, 1, 'view_category', 'perm.view_category_desc', 1),
(157, 1, 'view_chunk', 'perm.view_chunk_desc', 1),
(158, 1, 'view_context', 'perm.view_context_desc', 1),
(159, 1, 'view_document', 'perm.view_document_desc', 1),
(160, 1, 'view_element', 'perm.view_element_desc', 1),
(161, 1, 'view_eventlog', 'perm.view_eventlog_desc', 1),
(162, 1, 'view_offline', 'perm.view_offline_desc', 1),
(163, 1, 'view_plugin', 'perm.view_plugin_desc', 1),
(164, 1, 'view_propertyset', 'perm.view_propertyset_desc', 1),
(165, 1, 'view_role', 'perm.view_role_desc', 1),
(166, 1, 'view_snippet', 'perm.view_snippet_desc', 1),
(167, 1, 'view_sysinfo', 'perm.view_sysinfo_desc', 1),
(168, 1, 'view_template', 'perm.view_template_desc', 1),
(169, 1, 'view_tv', 'perm.view_tv_desc', 1),
(170, 1, 'view_user', 'perm.view_user_desc', 1),
(171, 1, 'view_unpublished', 'perm.view_unpublished_desc', 1),
(172, 1, 'workspaces', 'perm.workspaces_desc', 1),
(173, 2, 'add_children', 'perm.add_children_desc', 1),
(174, 2, 'copy', 'perm.copy_desc', 1),
(175, 2, 'create', 'perm.create_desc', 1),
(176, 2, 'delete', 'perm.delete_desc', 1),
(177, 2, 'list', 'perm.list_desc', 1),
(178, 2, 'load', 'perm.load_desc', 1),
(179, 2, 'move', 'perm.move_desc', 1),
(180, 2, 'publish', 'perm.publish_desc', 1),
(181, 2, 'remove', 'perm.remove_desc', 1),
(182, 2, 'save', 'perm.save_desc', 1),
(183, 2, 'steal_lock', 'perm.steal_lock_desc', 1),
(184, 2, 'undelete', 'perm.undelete_desc', 1),
(185, 2, 'unpublish', 'perm.unpublish_desc', 1),
(186, 2, 'view', 'perm.view_desc', 1),
(187, 3, 'load', 'perm.load_desc', 1),
(188, 3, 'list', 'perm.list_desc', 1),
(189, 3, 'view', 'perm.view_desc', 1),
(190, 3, 'save', 'perm.save_desc', 1),
(191, 3, 'remove', 'perm.remove_desc', 1),
(192, 4, 'add_children', 'perm.add_children_desc', 1),
(193, 4, 'create', 'perm.create_desc', 1),
(194, 4, 'copy', 'perm.copy_desc', 1),
(195, 4, 'delete', 'perm.delete_desc', 1),
(196, 4, 'list', 'perm.list_desc', 1),
(197, 4, 'load', 'perm.load_desc', 1),
(198, 4, 'remove', 'perm.remove_desc', 1),
(199, 4, 'save', 'perm.save_desc', 1),
(200, 4, 'view', 'perm.view_desc', 1),
(201, 5, 'create', 'perm.create_desc', 1),
(202, 5, 'copy', 'perm.copy_desc', 1),
(203, 5, 'list', 'perm.list_desc', 1),
(204, 5, 'load', 'perm.load_desc', 1),
(205, 5, 'remove', 'perm.remove_desc', 1),
(206, 5, 'save', 'perm.save_desc', 1),
(207, 5, 'view', 'perm.view_desc', 1),
(208, 6, 'load', 'perm.load_desc', 1),
(209, 6, 'list', 'perm.list_desc', 1),
(210, 6, 'view', 'perm.view_desc', 1),
(211, 6, 'save', 'perm.save_desc', 1),
(212, 6, 'remove', 'perm.remove_desc', 1),
(213, 6, 'view_unpublished', 'perm.view_unpublished_desc', 1),
(214, 6, 'copy', 'perm.copy_desc', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_policies`
--

CREATE TABLE IF NOT EXISTS `modx_access_policies` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` mediumtext,
  `parent` int(10) unsigned NOT NULL DEFAULT '0',
  `template` int(10) unsigned NOT NULL DEFAULT '0',
  `class` varchar(255) NOT NULL DEFAULT '',
  `data` text,
  `lexicon` varchar(255) NOT NULL DEFAULT 'permissions'
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_access_policies`
--

INSERT INTO `modx_access_policies` (`id`, `name`, `description`, `parent`, `template`, `class`, `data`, `lexicon`) VALUES
(1, 'Resource', 'MODX Resource Policy with all attributes.', 0, 2, '', '{"add_children":true,"create":true,"copy":true,"delete":true,"list":true,"load":true,"move":true,"publish":true,"remove":true,"save":true,"steal_lock":true,"undelete":true,"unpublish":true,"view":true}', 'permissions'),
(2, 'Administrator', 'Context administration policy with all permissions.', 0, 1, '', '{"about":true,"access_permissions":true,"actions":true,"change_password":true,"change_profile":true,"charsets":true,"class_map":true,"components":true,"content_types":true,"countries":true,"create":true,"credits":true,"customize_forms":true,"dashboards":true,"database":true,"database_truncate":true,"delete_category":true,"delete_chunk":true,"delete_context":true,"delete_document":true,"delete_eventlog":true,"delete_plugin":true,"delete_propertyset":true,"delete_role":true,"delete_snippet":true,"delete_template":true,"delete_tv":true,"delete_user":true,"directory_chmod":true,"directory_create":true,"directory_list":true,"directory_remove":true,"directory_update":true,"edit_category":true,"edit_chunk":true,"edit_context":true,"edit_document":true,"edit_locked":true,"edit_plugin":true,"edit_propertyset":true,"edit_role":true,"edit_snippet":true,"edit_template":true,"edit_tv":true,"edit_user":true,"element_tree":true,"empty_cache":true,"error_log_erase":true,"error_log_view":true,"export_static":true,"file_create":true,"file_list":true,"file_manager":true,"file_remove":true,"file_tree":true,"file_update":true,"file_upload":true,"file_view":true,"flush_sessions":true,"frames":true,"help":true,"home":true,"import_static":true,"languages":true,"lexicons":true,"list":true,"load":true,"logout":true,"logs":true,"menus":true,"menu_reports":true,"menu_security":true,"menu_site":true,"menu_support":true,"menu_system":true,"menu_tools":true,"menu_user":true,"messages":true,"namespaces":true,"new_category":true,"new_chunk":true,"new_context":true,"new_document":true,"new_document_in_root":true,"new_plugin":true,"new_propertyset":true,"new_role":true,"new_snippet":true,"new_static_resource":true,"new_symlink":true,"new_template":true,"new_tv":true,"new_user":true,"new_weblink":true,"packages":true,"policy_delete":true,"policy_edit":true,"policy_new":true,"policy_save":true,"policy_template_delete":true,"policy_template_edit":true,"policy_template_new":true,"policy_template_save":true,"policy_template_view":true,"policy_view":true,"property_sets":true,"providers":true,"publish_document":true,"purge_deleted":true,"remove":true,"remove_locks":true,"resource_duplicate":true,"resourcegroup_delete":true,"resourcegroup_edit":true,"resourcegroup_new":true,"resourcegroup_resource_edit":true,"resourcegroup_resource_list":true,"resourcegroup_save":true,"resourcegroup_view":true,"resource_quick_create":true,"resource_quick_update":true,"resource_tree":true,"save":true,"save_category":true,"save_chunk":true,"save_context":true,"save_document":true,"save_plugin":true,"save_propertyset":true,"save_role":true,"save_snippet":true,"save_template":true,"save_tv":true,"save_user":true,"search":true,"settings":true,"sources":true,"source_delete":true,"source_edit":true,"source_save":true,"source_view":true,"steal_locks":true,"tree_show_element_ids":true,"tree_show_resource_ids":true,"undelete_document":true,"unlock_element_properties":true,"unpublish_document":true,"usergroup_delete":true,"usergroup_edit":true,"usergroup_new":true,"usergroup_save":true,"usergroup_user_edit":true,"usergroup_user_list":true,"usergroup_view":true,"view":true,"view_category":true,"view_chunk":true,"view_context":true,"view_document":true,"view_element":true,"view_eventlog":true,"view_offline":true,"view_plugin":true,"view_propertyset":true,"view_role":true,"view_snippet":true,"view_sysinfo":true,"view_template":true,"view_tv":true,"view_unpublished":true,"view_user":true,"workspaces":true}', 'permissions'),
(3, 'Load Only', 'A minimal policy with permission to load an object.', 0, 3, '', '{"load":true}', 'permissions'),
(4, 'Load, List and View', 'Provides load, list and view permissions only.', 0, 3, '', '{"load":true,"list":true,"view":true}', 'permissions'),
(5, 'Object', 'An Object policy with all permissions.', 0, 3, '', '{"load":true,"list":true,"view":true,"save":true,"remove":true}', 'permissions'),
(6, 'Element', 'MODX Element policy with all attributes.', 0, 4, '', '{"add_children":true,"create":true,"delete":true,"list":true,"load":true,"remove":true,"save":true,"view":true,"copy":true}', 'permissions'),
(7, 'Content Editor', 'Context administration policy with limited, content-editing related Permissions, but no publishing.', 0, 1, '', '{"change_profile":true,"class_map":true,"countries":true,"edit_document":true,"frames":true,"help":true,"home":true,"load":true,"list":true,"logout":true,"menu_reports":true,"menu_site":true,"menu_support":true,"menu_tools":true,"menu_user":true,"resource_duplicate":true,"resource_tree":true,"save_document":true,"source_view":true,"tree_show_resource_ids":true,"view":true,"view_document":true,"new_document":true,"delete_document":true}', 'permissions'),
(8, 'Media Source Admin', 'Media Source administration policy.', 0, 5, '', '{"create":true,"copy":true,"load":true,"list":true,"save":true,"remove":true,"view":true}', 'permissions'),
(9, 'Media Source User', 'Media Source user policy, with basic viewing and using - but no editing - of Media Sources.', 0, 5, '', '{"load":true,"list":true,"view":true}', 'permissions'),
(10, 'Developer', 'Context administration policy with most Permissions except Administrator and Security functions.', 0, 0, '', '{"about":true,"change_password":true,"change_profile":true,"charsets":true,"class_map":true,"components":true,"content_types":true,"countries":true,"create":true,"credits":true,"customize_forms":true,"dashboards":true,"database":true,"delete_category":true,"delete_chunk":true,"delete_context":true,"delete_document":true,"delete_eventlog":true,"delete_plugin":true,"delete_propertyset":true,"delete_snippet":true,"delete_template":true,"delete_tv":true,"delete_role":true,"delete_user":true,"directory_chmod":true,"directory_create":true,"directory_list":true,"directory_remove":true,"directory_update":true,"edit_category":true,"edit_chunk":true,"edit_context":true,"edit_document":true,"edit_locked":true,"edit_plugin":true,"edit_propertyset":true,"edit_role":true,"edit_snippet":true,"edit_template":true,"edit_tv":true,"edit_user":true,"element_tree":true,"empty_cache":true,"error_log_erase":true,"error_log_view":true,"export_static":true,"file_create":true,"file_list":true,"file_manager":true,"file_remove":true,"file_tree":true,"file_update":true,"file_upload":true,"file_view":true,"frames":true,"help":true,"home":true,"import_static":true,"languages":true,"lexicons":true,"list":true,"load":true,"logout":true,"logs":true,"menu_reports":true,"menu_site":true,"menu_support":true,"menu_system":true,"menu_tools":true,"menu_user":true,"menus":true,"messages":true,"namespaces":true,"new_category":true,"new_chunk":true,"new_context":true,"new_document":true,"new_static_resource":true,"new_symlink":true,"new_weblink":true,"new_document_in_root":true,"new_plugin":true,"new_propertyset":true,"new_role":true,"new_snippet":true,"new_template":true,"new_tv":true,"new_user":true,"packages":true,"property_sets":true,"providers":true,"publish_document":true,"purge_deleted":true,"remove":true,"resource_duplicate":true,"resource_quick_create":true,"resource_quick_update":true,"resource_tree":true,"save":true,"save_category":true,"save_chunk":true,"save_context":true,"save_document":true,"save_plugin":true,"save_propertyset":true,"save_snippet":true,"save_template":true,"save_tv":true,"save_user":true,"search":true,"settings":true,"source_delete":true,"source_edit":true,"source_save":true,"source_view":true,"sources":true,"tree_show_element_ids":true,"tree_show_resource_ids":true,"undelete_document":true,"unpublish_document":true,"unlock_element_properties":true,"view":true,"view_category":true,"view_chunk":true,"view_context":true,"view_document":true,"view_element":true,"view_eventlog":true,"view_offline":true,"view_plugin":true,"view_propertyset":true,"view_role":true,"view_snippet":true,"view_sysinfo":true,"view_template":true,"view_tv":true,"view_user":true,"view_unpublished":true,"workspaces":true}', 'permissions'),
(11, 'Context', 'A standard Context policy that you can apply when creating Context ACLs for basic read/write and view_unpublished access within a Context.', 0, 6, '', '{"load":true,"list":true,"view":true,"save":true,"remove":true,"copy":true,"view_unpublished":true}', 'permissions');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_policy_template_groups`
--

CREATE TABLE IF NOT EXISTS `modx_access_policy_template_groups` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` mediumtext
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_access_policy_template_groups`
--

INSERT INTO `modx_access_policy_template_groups` (`id`, `name`, `description`) VALUES
(1, 'Admin', 'All admin policy templates.'),
(2, 'Object', 'All Object-based policy templates.'),
(3, 'Resource', 'All Resource-based policy templates.'),
(4, 'Element', 'All Element-based policy templates.'),
(5, 'MediaSource', 'All Media Source-based policy templates.');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_policy_templates`
--

CREATE TABLE IF NOT EXISTS `modx_access_policy_templates` (
  `id` int(10) unsigned NOT NULL,
  `template_group` int(10) unsigned NOT NULL DEFAULT '0',
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` mediumtext,
  `lexicon` varchar(255) NOT NULL DEFAULT 'permissions'
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_access_policy_templates`
--

INSERT INTO `modx_access_policy_templates` (`id`, `template_group`, `name`, `description`, `lexicon`) VALUES
(1, 1, 'AdministratorTemplate', 'Context administration policy template with all permissions.', 'permissions'),
(2, 3, 'ResourceTemplate', 'Resource Policy Template with all attributes.', 'permissions'),
(3, 2, 'ObjectTemplate', 'Object Policy Template with all attributes.', 'permissions'),
(4, 4, 'ElementTemplate', 'Element Policy Template with all attributes.', 'permissions'),
(5, 5, 'MediaSourceTemplate', 'Media Source Policy Template with all attributes.', 'permissions'),
(6, 2, 'ContextTemplate', 'Context Policy Template with all attributes.', 'permissions');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_resource_groups`
--

CREATE TABLE IF NOT EXISTS `modx_access_resource_groups` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0',
  `context_key` varchar(100) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_resources`
--

CREATE TABLE IF NOT EXISTS `modx_access_resources` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0',
  `context_key` varchar(100) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_access_templatevars`
--

CREATE TABLE IF NOT EXISTS `modx_access_templatevars` (
  `id` int(10) unsigned NOT NULL,
  `target` varchar(100) NOT NULL DEFAULT '',
  `principal_class` varchar(100) NOT NULL DEFAULT 'modPrincipal',
  `principal` int(10) unsigned NOT NULL DEFAULT '0',
  `authority` int(10) unsigned NOT NULL DEFAULT '9999',
  `policy` int(10) unsigned NOT NULL DEFAULT '0',
  `context_key` varchar(100) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_actiondom`
--

CREATE TABLE IF NOT EXISTS `modx_actiondom` (
  `id` int(10) unsigned NOT NULL,
  `set` int(11) NOT NULL DEFAULT '0',
  `action` varchar(255) NOT NULL DEFAULT '',
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` text,
  `xtype` varchar(100) NOT NULL DEFAULT '',
  `container` varchar(255) NOT NULL DEFAULT '',
  `rule` varchar(100) NOT NULL DEFAULT '',
  `value` text NOT NULL,
  `constraint` varchar(255) NOT NULL DEFAULT '',
  `constraint_field` varchar(100) NOT NULL DEFAULT '',
  `constraint_class` varchar(100) NOT NULL DEFAULT '',
  `active` tinyint(1) unsigned NOT NULL DEFAULT '1',
  `for_parent` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `rank` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_actions`
--

CREATE TABLE IF NOT EXISTS `modx_actions` (
  `id` int(10) unsigned NOT NULL,
  `namespace` varchar(100) NOT NULL DEFAULT 'core',
  `controller` varchar(255) NOT NULL,
  `haslayout` tinyint(1) unsigned NOT NULL DEFAULT '1',
  `lang_topics` text NOT NULL,
  `assets` text NOT NULL,
  `help_url` text NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_actions_fields`
--

CREATE TABLE IF NOT EXISTS `modx_actions_fields` (
  `id` int(10) unsigned NOT NULL,
  `action` varchar(255) NOT NULL DEFAULT '',
  `name` varchar(255) NOT NULL DEFAULT '',
  `type` varchar(100) NOT NULL DEFAULT 'field',
  `tab` varchar(255) NOT NULL DEFAULT '',
  `form` varchar(255) NOT NULL DEFAULT '',
  `other` varchar(255) NOT NULL DEFAULT '',
  `rank` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=77 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_actions_fields`
--

INSERT INTO `modx_actions_fields` (`id`, `action`, `name`, `type`, `tab`, `form`, `other`, `rank`) VALUES
(1, 'resource/update', 'modx-resource-settings', 'tab', '', 'modx-panel-resource', '', 0),
(2, 'resource/update', 'modx-resource-main-left', 'tab', '', 'modx-panel-resource', '', 1),
(3, 'resource/update', 'id', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 0),
(4, 'resource/update', 'pagetitle', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 1),
(5, 'resource/update', 'longtitle', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 2),
(6, 'resource/update', 'description', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 3),
(7, 'resource/update', 'introtext', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 4),
(8, 'resource/update', 'modx-resource-main-right', 'tab', '', 'modx-panel-resource', '', 2),
(9, 'resource/update', 'template', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 0),
(10, 'resource/update', 'alias', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 1),
(11, 'resource/update', 'menutitle', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 2),
(12, 'resource/update', 'link_attributes', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 3),
(13, 'resource/update', 'hidemenu', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 4),
(14, 'resource/update', 'published', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 5),
(15, 'resource/update', 'modx-page-settings', 'tab', '', 'modx-panel-resource', '', 3),
(16, 'resource/update', 'modx-page-settings-left', 'tab', '', 'modx-panel-resource', '', 4),
(17, 'resource/update', 'parent-cmb', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 0),
(18, 'resource/update', 'class_key', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 1),
(19, 'resource/update', 'content_type', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 2),
(20, 'resource/update', 'content_dispo', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 3),
(21, 'resource/update', 'menuindex', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 4),
(22, 'resource/update', 'modx-page-settings-right', 'tab', '', 'modx-panel-resource', '', 5),
(23, 'resource/update', 'publishedon', 'field', 'modx-page-settings-right', 'modx-panel-resource', '', 0),
(24, 'resource/update', 'pub_date', 'field', 'modx-page-settings-right', 'modx-panel-resource', '', 1),
(25, 'resource/update', 'unpub_date', 'field', 'modx-page-settings-right', 'modx-panel-resource', '', 2),
(26, 'resource/update', 'modx-page-settings-right-box-left', 'tab', '', 'modx-panel-resource', '', 6),
(27, 'resource/update', 'isfolder', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 0),
(28, 'resource/update', 'searchable', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 1),
(29, 'resource/update', 'richtext', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 2),
(30, 'resource/update', 'uri_override', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 3),
(31, 'resource/update', 'uri', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 4),
(32, 'resource/update', 'modx-page-settings-right-box-right', 'tab', '', 'modx-panel-resource', '', 7),
(33, 'resource/update', 'cacheable', 'field', 'modx-page-settings-right-box-right', 'modx-panel-resource', '', 0),
(34, 'resource/update', 'syncsite', 'field', 'modx-page-settings-right-box-right', 'modx-panel-resource', '', 1),
(35, 'resource/update', 'deleted', 'field', 'modx-page-settings-right-box-right', 'modx-panel-resource', '', 2),
(36, 'resource/update', 'modx-panel-resource-tv', 'tab', '', 'modx-panel-resource', 'tv', 8),
(37, 'resource/update', 'modx-resource-access-permissions', 'tab', '', 'modx-panel-resource', '', 9),
(38, 'resource/update', 'modx-resource-content', 'field', 'modx-resource-content', 'modx-panel-resource', '', 0),
(39, 'resource/create', 'modx-resource-settings', 'tab', '', 'modx-panel-resource', '', 0),
(40, 'resource/create', 'modx-resource-main-left', 'tab', '', 'modx-panel-resource', '', 1),
(41, 'resource/create', 'id', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 0),
(42, 'resource/create', 'pagetitle', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 1),
(43, 'resource/create', 'longtitle', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 2),
(44, 'resource/create', 'description', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 3),
(45, 'resource/create', 'introtext', 'field', 'modx-resource-main-left', 'modx-panel-resource', '', 4),
(46, 'resource/create', 'modx-resource-main-right', 'tab', '', 'modx-panel-resource', '', 2),
(47, 'resource/create', 'template', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 0),
(48, 'resource/create', 'alias', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 1),
(49, 'resource/create', 'menutitle', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 2),
(50, 'resource/create', 'link_attributes', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 3),
(51, 'resource/create', 'hidemenu', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 4),
(52, 'resource/create', 'published', 'field', 'modx-resource-main-right', 'modx-panel-resource', '', 5),
(53, 'resource/create', 'modx-page-settings', 'tab', '', 'modx-panel-resource', '', 3),
(54, 'resource/create', 'modx-page-settings-left', 'tab', '', 'modx-panel-resource', '', 4),
(55, 'resource/create', 'parent-cmb', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 0),
(56, 'resource/create', 'class_key', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 1),
(57, 'resource/create', 'content_type', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 2),
(58, 'resource/create', 'content_dispo', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 3),
(59, 'resource/create', 'menuindex', 'field', 'modx-page-settings-left', 'modx-panel-resource', '', 4),
(60, 'resource/create', 'modx-page-settings-right', 'tab', '', 'modx-panel-resource', '', 5),
(61, 'resource/create', 'publishedon', 'field', 'modx-page-settings-right', 'modx-panel-resource', '', 0),
(62, 'resource/create', 'pub_date', 'field', 'modx-page-settings-right', 'modx-panel-resource', '', 1),
(63, 'resource/create', 'unpub_date', 'field', 'modx-page-settings-right', 'modx-panel-resource', '', 2),
(64, 'resource/create', 'modx-page-settings-right-box-left', 'tab', '', 'modx-panel-resource', '', 6),
(65, 'resource/create', 'isfolder', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 0),
(66, 'resource/create', 'searchable', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 1),
(67, 'resource/create', 'richtext', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 2),
(68, 'resource/create', 'uri_override', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 3),
(69, 'resource/create', 'uri', 'field', 'modx-page-settings-right-box-left', 'modx-panel-resource', '', 4),
(70, 'resource/create', 'modx-page-settings-right-box-right', 'tab', '', 'modx-panel-resource', '', 7),
(71, 'resource/create', 'cacheable', 'field', 'modx-page-settings-right-box-right', 'modx-panel-resource', '', 0),
(72, 'resource/create', 'syncsite', 'field', 'modx-page-settings-right-box-right', 'modx-panel-resource', '', 1),
(73, 'resource/create', 'deleted', 'field', 'modx-page-settings-right-box-right', 'modx-panel-resource', '', 2),
(74, 'resource/create', 'modx-panel-resource-tv', 'tab', '', 'modx-panel-resource', 'tv', 8),
(75, 'resource/create', 'modx-resource-access-permissions', 'tab', '', 'modx-panel-resource', '', 9),
(76, 'resource/create', 'modx-resource-content', 'field', 'modx-resource-content', 'modx-panel-resource', '', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_active_users`
--

CREATE TABLE IF NOT EXISTS `modx_active_users` (
  `internalKey` int(9) NOT NULL DEFAULT '0',
  `username` varchar(50) NOT NULL DEFAULT '',
  `lasthit` int(20) NOT NULL DEFAULT '0',
  `id` int(10) DEFAULT NULL,
  `action` varchar(255) NOT NULL DEFAULT '',
  `ip` varchar(20) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_categories`
--

CREATE TABLE IF NOT EXISTS `modx_categories` (
  `id` int(10) unsigned NOT NULL,
  `parent` int(10) unsigned DEFAULT '0',
  `category` varchar(45) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_categories_closure`
--

CREATE TABLE IF NOT EXISTS `modx_categories_closure` (
  `ancestor` int(10) unsigned NOT NULL DEFAULT '0',
  `descendant` int(10) unsigned NOT NULL DEFAULT '0',
  `depth` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_class_map`
--

CREATE TABLE IF NOT EXISTS `modx_class_map` (
  `id` int(10) unsigned NOT NULL,
  `class` varchar(120) NOT NULL DEFAULT '',
  `parent_class` varchar(120) NOT NULL DEFAULT '',
  `name_field` varchar(255) NOT NULL DEFAULT 'name',
  `path` tinytext,
  `lexicon` varchar(255) NOT NULL DEFAULT 'core:resource'
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_class_map`
--

INSERT INTO `modx_class_map` (`id`, `class`, `parent_class`, `name_field`, `path`, `lexicon`) VALUES
(1, 'modDocument', 'modResource', 'pagetitle', '', 'core:resource'),
(2, 'modWebLink', 'modResource', 'pagetitle', '', 'core:resource'),
(3, 'modSymLink', 'modResource', 'pagetitle', '', 'core:resource'),
(4, 'modStaticResource', 'modResource', 'pagetitle', '', 'core:resource'),
(5, 'modTemplate', 'modElement', 'templatename', '', 'core:resource'),
(6, 'modTemplateVar', 'modElement', 'name', '', 'core:resource'),
(7, 'modChunk', 'modElement', 'name', '', 'core:resource'),
(8, 'modSnippet', 'modElement', 'name', '', 'core:resource'),
(9, 'modPlugin', 'modElement', 'name', '', 'core:resource');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_content_type`
--

CREATE TABLE IF NOT EXISTS `modx_content_type` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` tinytext,
  `mime_type` tinytext,
  `file_extensions` tinytext,
  `headers` mediumtext,
  `binary` tinyint(1) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_content_type`
--

INSERT INTO `modx_content_type` (`id`, `name`, `description`, `mime_type`, `file_extensions`, `headers`, `binary`) VALUES
(1, 'HTML', 'HTML content', 'text/html', '.html', NULL, 0),
(2, 'XML', 'XML content', 'text/xml', '.xml', NULL, 0),
(3, 'text', 'plain text content', 'text/plain', '.txt', NULL, 0),
(4, 'CSS', 'CSS content', 'text/css', '.css', NULL, 0),
(5, 'javascript', 'javascript content', 'text/javascript', '.js', NULL, 0),
(6, 'RSS', 'For RSS feeds', 'application/rss+xml', '.rss', NULL, 0),
(7, 'JSON', 'JSON', 'application/json', '.json', NULL, 0),
(8, 'PDF', 'PDF Files', 'application/pdf', '.pdf', NULL, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_context`
--

CREATE TABLE IF NOT EXISTS `modx_context` (
  `key` varchar(100) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `description` tinytext,
  `rank` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_context`
--

INSERT INTO `modx_context` (`key`, `name`, `description`, `rank`) VALUES
('web', 'Website', 'The default front-end context for your web site.', 0),
('mgr', 'Manager', 'The default manager or administration context for content management activity.', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_context_resource`
--

CREATE TABLE IF NOT EXISTS `modx_context_resource` (
  `context_key` varchar(255) NOT NULL,
  `resource` int(11) unsigned NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_context_setting`
--

CREATE TABLE IF NOT EXISTS `modx_context_setting` (
  `context_key` varchar(255) NOT NULL,
  `key` varchar(50) NOT NULL,
  `value` mediumtext,
  `xtype` varchar(75) NOT NULL DEFAULT 'textfield',
  `namespace` varchar(40) NOT NULL DEFAULT 'core',
  `area` varchar(255) NOT NULL DEFAULT '',
  `editedon` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_context_setting`
--

INSERT INTO `modx_context_setting` (`context_key`, `key`, `value`, `xtype`, `namespace`, `area`, `editedon`) VALUES
('mgr', 'allow_tags_in_post', '1', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('mgr', 'modRequest.class', 'modManagerRequest', 'textfield', 'core', 'system', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_dashboard`
--

CREATE TABLE IF NOT EXISTS `modx_dashboard` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` text,
  `hide_trees` tinyint(1) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_dashboard`
--

INSERT INTO `modx_dashboard` (`id`, `name`, `description`, `hide_trees`) VALUES
(1, 'Default', '', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_dashboard_widget`
--

CREATE TABLE IF NOT EXISTS `modx_dashboard_widget` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` text,
  `type` varchar(100) NOT NULL,
  `content` mediumtext,
  `namespace` varchar(255) NOT NULL DEFAULT '',
  `lexicon` varchar(255) NOT NULL DEFAULT 'core:dashboards',
  `size` varchar(255) NOT NULL DEFAULT 'half'
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_dashboard_widget`
--

INSERT INTO `modx_dashboard_widget` (`id`, `name`, `description`, `type`, `content`, `namespace`, `lexicon`, `size`) VALUES
(1, 'w_newsfeed', 'w_newsfeed_desc', 'file', '[[++manager_path]]controllers/default/dashboard/widget.modx-news.php', 'core', 'core:dashboards', 'half'),
(2, 'w_securityfeed', 'w_securityfeed_desc', 'file', '[[++manager_path]]controllers/default/dashboard/widget.modx-security.php', 'core', 'core:dashboards', 'half'),
(3, 'w_whosonline', 'w_whosonline_desc', 'file', '[[++manager_path]]controllers/default/dashboard/widget.grid-online.php', 'core', 'core:dashboards', 'half'),
(4, 'w_recentlyeditedresources', 'w_recentlyeditedresources_desc', 'file', '[[++manager_path]]controllers/default/dashboard/widget.grid-rer.php', 'core', 'core:dashboards', 'half'),
(5, 'w_configcheck', 'w_configcheck_desc', 'file', '[[++manager_path]]controllers/default/dashboard/widget.configcheck.php', 'core', 'core:dashboards', 'full');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_dashboard_widget_placement`
--

CREATE TABLE IF NOT EXISTS `modx_dashboard_widget_placement` (
  `dashboard` int(10) unsigned NOT NULL DEFAULT '0',
  `widget` int(10) unsigned NOT NULL DEFAULT '0',
  `rank` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_dashboard_widget_placement`
--

INSERT INTO `modx_dashboard_widget_placement` (`dashboard`, `widget`, `rank`) VALUES
(1, 5, 0),
(1, 1, 1),
(1, 2, 2),
(1, 3, 3),
(1, 4, 4);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_document_groups`
--

CREATE TABLE IF NOT EXISTS `modx_document_groups` (
  `id` int(10) unsigned NOT NULL,
  `document_group` int(10) NOT NULL DEFAULT '0',
  `document` int(10) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_documentgroup_names`
--

CREATE TABLE IF NOT EXISTS `modx_documentgroup_names` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `private_memgroup` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `private_webgroup` tinyint(1) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_element_property_sets`
--

CREATE TABLE IF NOT EXISTS `modx_element_property_sets` (
  `element` int(10) unsigned NOT NULL DEFAULT '0',
  `element_class` varchar(100) NOT NULL DEFAULT '',
  `property_set` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_extension_packages`
--

CREATE TABLE IF NOT EXISTS `modx_extension_packages` (
  `id` int(10) unsigned NOT NULL,
  `namespace` varchar(40) NOT NULL DEFAULT 'core',
  `name` varchar(100) NOT NULL DEFAULT 'core',
  `path` text,
  `table_prefix` varchar(255) NOT NULL DEFAULT '',
  `service_class` varchar(255) NOT NULL DEFAULT '',
  `service_name` varchar(255) NOT NULL DEFAULT '',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_fc_profiles`
--

CREATE TABLE IF NOT EXISTS `modx_fc_profiles` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` text NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '0',
  `rank` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_fc_profiles_usergroups`
--

CREATE TABLE IF NOT EXISTS `modx_fc_profiles_usergroups` (
  `usergroup` int(11) NOT NULL DEFAULT '0',
  `profile` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_fc_sets`
--

CREATE TABLE IF NOT EXISTS `modx_fc_sets` (
  `id` int(10) unsigned NOT NULL,
  `profile` int(11) NOT NULL DEFAULT '0',
  `action` varchar(255) NOT NULL DEFAULT '',
  `description` text NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '0',
  `template` int(11) NOT NULL DEFAULT '0',
  `constraint` varchar(255) NOT NULL DEFAULT '',
  `constraint_field` varchar(100) NOT NULL DEFAULT '',
  `constraint_class` varchar(100) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_lexicon_entries`
--

CREATE TABLE IF NOT EXISTS `modx_lexicon_entries` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `value` text NOT NULL,
  `topic` varchar(255) NOT NULL DEFAULT 'default',
  `namespace` varchar(40) NOT NULL DEFAULT 'core',
  `language` varchar(20) NOT NULL DEFAULT 'en',
  `createdon` datetime DEFAULT NULL,
  `editedon` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_manager_log`
--

CREATE TABLE IF NOT EXISTS `modx_manager_log` (
  `id` int(10) unsigned NOT NULL,
  `user` int(10) unsigned NOT NULL DEFAULT '0',
  `occurred` datetime DEFAULT '0000-00-00 00:00:00',
  `action` varchar(100) NOT NULL DEFAULT '',
  `classKey` varchar(100) NOT NULL DEFAULT '',
  `item` varchar(255) NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=47 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_manager_log`
--

INSERT INTO `modx_manager_log` (`id`, `user`, `occurred`, `action`, `classKey`, `item`) VALUES
(1, 1, '2015-07-25 00:21:48', 'template_update', 'modTemplate', '1'),
(2, 1, '2015-07-25 00:31:18', 'template_update', 'modTemplate', '1'),
(3, 1, '2015-07-25 00:32:04', 'template_update', 'modTemplate', '1'),
(4, 1, '2015-07-25 00:33:18', 'template_update', 'modTemplate', '1'),
(5, 1, '2015-07-25 00:33:44', 'template_update', 'modTemplate', '1'),
(6, 1, '2015-07-25 00:34:36', 'template_update', 'modTemplate', '1'),
(7, 1, '2015-07-25 00:35:37', 'template_update', 'modTemplate', '1'),
(8, 1, '2015-07-25 00:36:20', 'template_update', 'modTemplate', '1'),
(9, 1, '2015-07-25 00:38:03', 'resource_update', 'modResource', '1'),
(10, 1, '2015-07-25 00:39:25', 'resource_update', 'modResource', '1'),
(11, 1, '2015-07-25 00:40:34', 'template_update', 'modTemplate', '1'),
(12, 1, '2015-07-25 00:44:07', 'resource_create', 'modDocument', '2'),
(13, 1, '2015-07-25 00:49:29', 'resource_update', 'modResource', '2'),
(14, 1, '2015-07-25 00:51:02', 'template_update', 'modTemplate', '1'),
(15, 1, '2015-07-25 00:51:56', 'resource_update', 'modResource', '2'),
(16, 1, '2015-07-25 00:52:47', 'resource_update', 'modResource', '2'),
(17, 1, '2015-07-25 00:53:37', 'template_update', 'modTemplate', '1'),
(18, 1, '2015-07-25 00:55:03', 'template_update', 'modTemplate', '1'),
(19, 1, '2015-07-25 00:56:21', 'resource_sort', '', 'unknown'),
(20, 1, '2015-07-25 00:56:27', 'resource_sort', '', 'unknown'),
(21, 1, '2015-07-25 00:58:46', 'resource_update', 'modResource', '2'),
(22, 1, '2015-07-25 01:01:27', 'template_update', 'modTemplate', '1'),
(23, 1, '2015-07-25 01:03:37', 'tv_create', 'modTemplateVar', '1'),
(24, 1, '2015-07-25 01:04:26', 'tv_update', 'modTemplateVar', '1'),
(25, 1, '2015-07-25 01:06:05', 'template_update', 'modTemplate', '1'),
(26, 1, '2015-07-25 01:09:45', 'resource_create', 'modSymLink', '3'),
(27, 1, '2015-07-25 01:09:58', 'resource_update', 'modResource', '2'),
(28, 1, '2015-07-25 01:10:30', 'template_update', 'modTemplate', '1'),
(29, 1, '2015-07-25 01:11:19', 'template_update', 'modTemplate', '1'),
(30, 1, '2015-07-25 01:11:43', 'template_update', 'modTemplate', '1'),
(31, 1, '2015-07-25 01:12:06', 'template_update', 'modTemplate', '1'),
(32, 1, '2015-07-25 22:02:46', 'delete_resource', 'modSymLink', '3'),
(33, 1, '2015-07-25 22:03:23', 'resource_update', 'modResource', '2'),
(34, 1, '2015-07-25 22:05:42', 'resource_update', 'modResource', '2'),
(35, 1, '2015-07-25 22:06:15', 'resource_update', 'modResource', '2'),
(36, 1, '2015-07-25 22:06:30', 'resource_update', 'modResource', '2'),
(37, 1, '2015-07-25 22:13:52', 'resource_update', 'modResource', '1'),
(38, 1, '2015-07-25 22:14:31', 'resource_update', 'modResource', '1'),
(39, 1, '2015-07-25 22:15:16', 'resource_sort', '', 'unknown'),
(40, 1, '2015-07-25 22:15:27', 'resource_update', 'modResource', '1'),
(41, 1, '2015-07-25 22:39:30', 'template_update', 'modTemplate', '1'),
(42, 1, '2015-07-25 22:40:02', 'template_update', 'modTemplate', '1'),
(43, 1, '2015-07-25 22:40:48', 'template_update', 'modTemplate', '1'),
(44, 1, '2015-07-25 22:42:57', 'resource_update', 'modResource', '2'),
(45, 1, '2015-07-25 22:46:48', 'resource_update', 'modResource', '1'),
(46, 1, '2015-07-25 22:51:23', 'template_update', 'modTemplate', '1');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_media_sources`
--

CREATE TABLE IF NOT EXISTS `modx_media_sources` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` text,
  `class_key` varchar(100) NOT NULL DEFAULT 'sources.modFileMediaSource',
  `properties` mediumtext,
  `is_stream` tinyint(1) unsigned NOT NULL DEFAULT '1'
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_media_sources`
--

INSERT INTO `modx_media_sources` (`id`, `name`, `description`, `class_key`, `properties`, `is_stream`) VALUES
(1, 'Filesystem', '', 'sources.modFileMediaSource', 'a:0:{}', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_media_sources_contexts`
--

CREATE TABLE IF NOT EXISTS `modx_media_sources_contexts` (
  `source` int(11) NOT NULL DEFAULT '0',
  `context_key` varchar(100) NOT NULL DEFAULT 'web'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_media_sources_elements`
--

CREATE TABLE IF NOT EXISTS `modx_media_sources_elements` (
  `source` int(11) unsigned NOT NULL DEFAULT '0',
  `object_class` varchar(100) NOT NULL DEFAULT 'modTemplateVar',
  `object` int(11) unsigned NOT NULL DEFAULT '0',
  `context_key` varchar(100) NOT NULL DEFAULT 'web'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_media_sources_elements`
--

INSERT INTO `modx_media_sources_elements` (`source`, `object_class`, `object`, `context_key`) VALUES
(1, 'modTemplateVar', 1, 'web');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_member_groups`
--

CREATE TABLE IF NOT EXISTS `modx_member_groups` (
  `id` int(10) unsigned NOT NULL,
  `user_group` int(10) unsigned NOT NULL DEFAULT '0',
  `member` int(10) unsigned NOT NULL DEFAULT '0',
  `role` int(10) unsigned NOT NULL DEFAULT '1',
  `rank` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_member_groups`
--

INSERT INTO `modx_member_groups` (`id`, `user_group`, `member`, `role`, `rank`) VALUES
(1, 1, 1, 2, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_membergroup_names`
--

CREATE TABLE IF NOT EXISTS `modx_membergroup_names` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` text,
  `parent` int(10) unsigned NOT NULL DEFAULT '0',
  `rank` int(10) unsigned NOT NULL DEFAULT '0',
  `dashboard` int(10) unsigned NOT NULL DEFAULT '1'
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_membergroup_names`
--

INSERT INTO `modx_membergroup_names` (`id`, `name`, `description`, `parent`, `rank`, `dashboard`) VALUES
(1, 'Administrator', NULL, 0, 0, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_menus`
--

CREATE TABLE IF NOT EXISTS `modx_menus` (
  `text` varchar(255) NOT NULL DEFAULT '',
  `parent` varchar(255) NOT NULL DEFAULT '',
  `action` varchar(255) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `icon` varchar(255) NOT NULL DEFAULT '',
  `menuindex` int(11) unsigned NOT NULL DEFAULT '0',
  `params` text NOT NULL,
  `handler` text NOT NULL,
  `permissions` text NOT NULL,
  `namespace` varchar(100) NOT NULL DEFAULT 'core'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_menus`
--

INSERT INTO `modx_menus` (`text`, `parent`, `action`, `description`, `icon`, `menuindex`, `params`, `handler`, `permissions`, `namespace`) VALUES
('topnav', '', '', 'topnav_desc', '', 0, '', '', '', 'core'),
('site', 'topnav', '', '', '', 0, '', '', 'menu_site', 'core'),
('new_resource', 'site', 'resource/create', 'new_resource_desc', '', 0, '', '', 'new_document', 'core'),
('preview', 'site', '', 'preview_desc', '', 4, '', 'MODx.preview(); return false;', '', 'core'),
('import_site', 'site', 'system/import/html', 'import_site_desc', '', 5, '', '', 'import_static', 'core'),
('import_resources', 'site', 'system/import', 'import_resources_desc', '', 6, '', '', 'import_static', 'core'),
('resource_groups', 'site', 'security/resourcegroup', 'resource_groups_desc', '', 7, '', '', 'access_permissions', 'core'),
('content_types', 'site', 'system/contenttype', 'content_types_desc', '', 8, '', '', 'content_types', 'core'),
('media', 'topnav', '', 'media_desc', '', 1, '', '', 'file_manager', 'core'),
('file_browser', 'media', 'media/browser', 'file_browser_desc', '', 0, '', '', 'file_manager', 'core'),
('sources', 'media', 'source', 'sources_desc', '', 1, '', '', 'sources', 'core'),
('components', 'topnav', '', '', '', 2, '', '', 'components', 'core'),
('installer', 'components', 'workspaces', 'installer_desc', '', 0, '', '', 'packages', 'core'),
('manage', 'topnav', '', '', '', 3, '', '', 'menu_tools', 'core'),
('users', 'manage', 'security/user', 'user_management_desc', '', 0, '', '', 'view_user', 'core'),
('refresh_site', 'manage', '', 'refresh_site_desc', '', 1, '', 'MODx.clearCache(); return false;', 'empty_cache', 'core'),
('refreshuris', 'refresh_site', '', 'refreshuris_desc', '', 0, '', 'MODx.refreshURIs(); return false;', 'empty_cache', 'core'),
('remove_locks', 'manage', '', 'remove_locks_desc', '', 2, '', '\nMODx.msg.confirm({\n    title: _(''remove_locks'')\n    ,text: _(''confirm_remove_locks'')\n    ,url: MODx.config.connectors_url\n    ,params: {\n        action: ''system/remove_locks''\n    }\n    ,listeners: {\n        ''success'': {fn:function() {\n            var tree = Ext.getCmp("modx-resource-tree");\n            if (tree && tree.rendered) {\n                tree.refresh();\n            }\n         },scope:this}\n    }\n});', 'remove_locks', 'core'),
('flush_access', 'manage', '', 'flush_access_desc', '', 3, '', 'MODx.msg.confirm({\n    title: _(''flush_access'')\n    ,text: _(''flush_access_confirm'')\n    ,url: MODx.config.connector_url\n    ,params: {\n        action: ''security/access/flush''\n    }\n    ,listeners: {\n        ''success'': {fn:function() { location.href = ''./''; },scope:this}\n    }\n});', 'access_permissions', 'core'),
('flush_sessions', 'manage', '', 'flush_sessions_desc', '', 4, '', 'MODx.msg.confirm({\n    title: _(''flush_sessions'')\n    ,text: _(''flush_sessions_confirm'')\n    ,url: MODx.config.connector_url\n    ,params: {\n        action: ''security/flush''\n    }\n    ,listeners: {\n        ''success'': {fn:function() { location.href = ''./''; },scope:this}\n    }\n});', 'flush_sessions', 'core'),
('reports', 'manage', '', 'reports_desc', '', 5, '', '', 'menu_reports', 'core'),
('site_schedule', 'reports', 'resource/site_schedule', 'site_schedule_desc', '', 0, '', '', 'view_document', 'core'),
('view_logging', 'reports', 'system/logs', 'view_logging_desc', '', 1, '', '', 'logs', 'core'),
('eventlog_viewer', 'reports', 'system/event', 'eventlog_viewer_desc', '', 2, '', '', 'view_eventlog', 'core'),
('view_sysinfo', 'reports', 'system/info', 'view_sysinfo_desc', '', 3, '', '', 'view_sysinfo', 'core'),
('usernav', '', '', 'usernav_desc', '', 0, '', '', '', 'core'),
('user', 'usernav', '', '', '<span id="user-avatar">{$userImage}</span> <span id="user-username">{$username}</span>', 5, '', '', 'menu_user', 'core'),
('profile', 'user', 'security/profile', 'profile_desc', '', 0, '', '', 'change_profile', 'core'),
('messages', 'user', 'security/message', 'messages_desc', '', 1, '', '', 'messages', 'core'),
('logout', 'user', '', 'logout_desc', '', 2, '', 'MODx.logout(); return false;', 'logout', 'core'),
('admin', 'usernav', '', '', '<i class="icon-gear icon icon-large"></i>', 6, '', '', 'settings', 'core'),
('system_settings', 'admin', 'system/settings', 'system_settings_desc', '', 0, '', '', 'settings', 'core'),
('bespoke_manager', 'admin', 'security/forms', 'bespoke_manager_desc', '', 1, '', '', 'customize_forms', 'core'),
('dashboards', 'admin', 'system/dashboards', 'dashboards_desc', '', 2, '', '', 'dashboards', 'core'),
('contexts', 'admin', 'context', 'contexts_desc', '', 3, '', '', 'view_context', 'core'),
('edit_menu', 'admin', 'system/action', 'edit_menu_desc', '', 4, '', '', 'actions', 'core'),
('acls', 'admin', 'security/permission', 'acls_desc', '', 5, '', '', 'access_permissions', 'core'),
('propertysets', 'admin', 'element/propertyset', 'propertysets_desc', '', 6, '', '', 'property_sets', 'core'),
('lexicon_management', 'admin', 'workspaces/lexicon', 'lexicon_management_desc', '', 7, '', '', 'lexicons', 'core'),
('namespaces', 'admin', 'workspaces/namespace', 'namespaces_desc', '', 8, '', '', 'namespaces', 'core'),
('about', 'usernav', 'help', '', '<i class="icon-question-circle icon icon-large"></i>', 7, '', '', 'help', 'core');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_namespaces`
--

CREATE TABLE IF NOT EXISTS `modx_namespaces` (
  `name` varchar(40) NOT NULL DEFAULT '',
  `path` text,
  `assets_path` text
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_namespaces`
--

INSERT INTO `modx_namespaces` (`name`, `path`, `assets_path`) VALUES
('core', '{core_path}', '{assets_path}');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_property_set`
--

CREATE TABLE IF NOT EXISTS `modx_property_set` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(50) NOT NULL DEFAULT '',
  `category` int(10) NOT NULL DEFAULT '0',
  `description` varchar(255) NOT NULL DEFAULT '',
  `properties` text
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_register_messages`
--

CREATE TABLE IF NOT EXISTS `modx_register_messages` (
  `topic` int(10) unsigned NOT NULL,
  `id` varchar(255) NOT NULL,
  `created` datetime NOT NULL,
  `valid` datetime NOT NULL,
  `accessed` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `accesses` int(10) unsigned NOT NULL DEFAULT '0',
  `expires` int(20) NOT NULL DEFAULT '0',
  `payload` mediumtext NOT NULL,
  `kill` tinyint(1) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_register_queues`
--

CREATE TABLE IF NOT EXISTS `modx_register_queues` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `options` mediumtext
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_register_queues`
--

INSERT INTO `modx_register_queues` (`id`, `name`, `options`) VALUES
(1, 'locks', 'a:1:{s:9:"directory";s:5:"locks";}');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_register_topics`
--

CREATE TABLE IF NOT EXISTS `modx_register_topics` (
  `id` int(10) unsigned NOT NULL,
  `queue` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `created` datetime NOT NULL,
  `updated` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `options` mediumtext
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_register_topics`
--

INSERT INTO `modx_register_topics` (`id`, `queue`, `name`, `created`, `updated`, `options`) VALUES
(1, 1, '/resource/', '2015-07-25 00:02:47', NULL, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_session`
--

CREATE TABLE IF NOT EXISTS `modx_session` (
  `id` varchar(255) NOT NULL DEFAULT '',
  `access` int(20) unsigned NOT NULL,
  `data` mediumtext
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_session`
--

INSERT INTO `modx_session` (`id`, `access`, `data`) VALUES
('35rk9tlhqs0lavjuatgjr0ull7', 1437775240, 'modx.user.contextTokens|a:0:{}'),
('d63jepdhfrstpc9112pbcmdhr3', 1437860527, 'modx.user.contextTokens|a:0:{}'),
('kv2vk26sb6hmk607g0vhkuhla2', 1438628381, 'modx.user.contextTokens|a:0:{}');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_content`
--

CREATE TABLE IF NOT EXISTS `modx_site_content` (
  `id` int(10) unsigned NOT NULL,
  `type` varchar(20) NOT NULL DEFAULT 'document',
  `contentType` varchar(50) NOT NULL DEFAULT 'text/html',
  `pagetitle` varchar(255) NOT NULL DEFAULT '',
  `longtitle` varchar(255) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `alias` varchar(255) DEFAULT '',
  `link_attributes` varchar(255) NOT NULL DEFAULT '',
  `published` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `pub_date` int(20) NOT NULL DEFAULT '0',
  `unpub_date` int(20) NOT NULL DEFAULT '0',
  `parent` int(10) NOT NULL DEFAULT '0',
  `isfolder` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `introtext` text,
  `content` mediumtext,
  `richtext` tinyint(1) unsigned NOT NULL DEFAULT '1',
  `template` int(10) NOT NULL DEFAULT '0',
  `menuindex` int(10) NOT NULL DEFAULT '0',
  `searchable` tinyint(1) unsigned NOT NULL DEFAULT '1',
  `cacheable` tinyint(1) unsigned NOT NULL DEFAULT '1',
  `createdby` int(10) NOT NULL DEFAULT '0',
  `createdon` int(20) NOT NULL DEFAULT '0',
  `editedby` int(10) NOT NULL DEFAULT '0',
  `editedon` int(20) NOT NULL DEFAULT '0',
  `deleted` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `deletedon` int(20) NOT NULL DEFAULT '0',
  `deletedby` int(10) NOT NULL DEFAULT '0',
  `publishedon` int(20) NOT NULL DEFAULT '0',
  `publishedby` int(10) NOT NULL DEFAULT '0',
  `menutitle` varchar(255) NOT NULL DEFAULT '',
  `donthit` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `privateweb` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `privatemgr` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `content_dispo` tinyint(1) NOT NULL DEFAULT '0',
  `hidemenu` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `class_key` varchar(100) NOT NULL DEFAULT 'modDocument',
  `context_key` varchar(100) NOT NULL DEFAULT 'web',
  `content_type` int(11) unsigned NOT NULL DEFAULT '1',
  `uri` text,
  `uri_override` tinyint(1) NOT NULL DEFAULT '0',
  `hide_children_in_tree` tinyint(1) NOT NULL DEFAULT '0',
  `show_in_tree` tinyint(1) NOT NULL DEFAULT '1',
  `properties` mediumtext
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_site_content`
--

INSERT INTO `modx_site_content` (`id`, `type`, `contentType`, `pagetitle`, `longtitle`, `description`, `alias`, `link_attributes`, `published`, `pub_date`, `unpub_date`, `parent`, `isfolder`, `introtext`, `content`, `richtext`, `template`, `menuindex`, `searchable`, `cacheable`, `createdby`, `createdon`, `editedby`, `editedon`, `deleted`, `deletedon`, `deletedby`, `publishedon`, `publishedby`, `menutitle`, `donthit`, `privateweb`, `privatemgr`, `content_dispo`, `hidemenu`, `class_key`, `context_key`, `content_type`, `uri`, `uri_override`, `hide_children_in_tree`, `show_in_tree`, `properties`) VALUES
(1, 'document', 'text/html', 'Главная', '', '', 'index', '', 1, 0, 0, 0, 1, '', '<h2>Как установить шаблон modx</h2>\r\n<ul>\r\n <li>1. Скачайте бесплатный шаблон сайта modx.</li>\r\n\r\n <li>2. Распакуйте его, залейте файл со расширением .css и папку images в assets/template/название шаблона.</li>\r\n\r\n <li>3. Скопируйте содержимое файла template.txt в новый шаблон (Элементы - Управление элементами - Новый шаблон). Проверьте  путь к файлу с стилей (.css) и картинкам.</li>\r\n\r\nШаблон modx установлен.\r\n</ul>', 1, 1, 1, 1, 1, 1, 1437774813, 1, 1437857208, 0, 0, 0, 0, 0, '', 0, 0, 0, 0, 0, 'modDocument', 'web', 1, '', 0, 0, 1, NULL),
(2, 'document', 'text/html', 'satelite', '', 'Моя страница', 'satelite', '', 1, 0, 0, 0, 0, '', '<div class=''sk-stl''>\r\n<div class=''txt''>Linux Mint 17</div>\r\n</div>\r\n\r\n \r\n\r\n\r\n<!-- <br><br><br> -->\r\n <div class="scene">\r\n  <div data-offset="90" class="clouds parallax"></div>\r\n  <div data-offset="30" class="trees parallax"></div>\r\n  <div data-offset="20" class="grass parallax"></div>\r\n  <div data-offset="50" class="buildings parallax"></div>\r\n  <div class="ground"></div>\r\n </div>\r\n\r\n  <!-- <script src="js/index.js"></script> -->\r\n  <script lang=''JavaScript''>\r\n	(function () \r\n	{\r\n		var h = window.outerHeight\r\n		var w = window.outerWidth\r\n		var offsetX, offsetY, offset, translate\r\n		var p = document.querySelectorAll(''.parallax'');\r\n		window.onmousemove = function (e) \r\n		{\r\n			offsetX = 0.5 - e.pageX / w;\r\n			offsetY = 0.5 - e.pageY / h;			\r\n			for (var i = 0; i < p.length; i++) \r\n			{\r\n				offset = p[i].getAttribute(''data-offset'');\r\n				translate = "translate3d(" + Math.round(offsetX * offset) + "px," + Math.round(offsetY * offset) + "px, 0px)"\r\n				p[i].style.webkitTransform = translate;\r\n				p[i].style.transform = translate;\r\n				p[i].style.MozTransform = translate;\r\n			}\r\n		}\r\n	})();\r\n  </script>', 1, 1, 2, 1, 1, 1, 1437777847, 1, 1437856977, 0, 0, 0, 1437777840, 1, '', 0, 0, 0, 0, 0, 'modDocument', 'web', 1, '', 0, 0, 1, NULL),
(3, 'reference', 'text/html', 'satelite', '', '', 'satelite', '', 1, 0, 0, 2, 0, '', 'url_satelite', 1, 1, 0, 1, 1, 1, 1437779385, 0, 0, 1, 1437854566, 1, 1437779385, 1, '', 0, 0, 0, 0, 0, 'modSymLink', 'web', 1, '', 0, 0, 1, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_htmlsnippets`
--

CREATE TABLE IF NOT EXISTS `modx_site_htmlsnippets` (
  `id` int(10) unsigned NOT NULL,
  `source` int(10) unsigned NOT NULL DEFAULT '0',
  `property_preprocess` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `name` varchar(50) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT 'Chunk',
  `editor_type` int(11) NOT NULL DEFAULT '0',
  `category` int(11) NOT NULL DEFAULT '0',
  `cache_type` tinyint(1) NOT NULL DEFAULT '0',
  `snippet` mediumtext,
  `locked` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `properties` text,
  `static` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `static_file` varchar(255) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_plugin_events`
--

CREATE TABLE IF NOT EXISTS `modx_site_plugin_events` (
  `pluginid` int(10) NOT NULL DEFAULT '0',
  `event` varchar(255) NOT NULL DEFAULT '',
  `priority` int(10) NOT NULL DEFAULT '0',
  `propertyset` int(10) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_plugins`
--

CREATE TABLE IF NOT EXISTS `modx_site_plugins` (
  `id` int(10) unsigned NOT NULL,
  `source` int(10) unsigned NOT NULL DEFAULT '0',
  `property_preprocess` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `name` varchar(50) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `editor_type` int(11) NOT NULL DEFAULT '0',
  `category` int(11) NOT NULL DEFAULT '0',
  `cache_type` tinyint(1) NOT NULL DEFAULT '0',
  `plugincode` mediumtext NOT NULL,
  `locked` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `properties` text,
  `disabled` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `moduleguid` varchar(32) NOT NULL DEFAULT '',
  `static` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `static_file` varchar(255) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_snippets`
--

CREATE TABLE IF NOT EXISTS `modx_site_snippets` (
  `id` int(10) unsigned NOT NULL,
  `source` int(10) unsigned NOT NULL DEFAULT '0',
  `property_preprocess` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `name` varchar(50) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `editor_type` int(11) NOT NULL DEFAULT '0',
  `category` int(11) NOT NULL DEFAULT '0',
  `cache_type` tinyint(1) NOT NULL DEFAULT '0',
  `snippet` mediumtext,
  `locked` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `properties` text,
  `moduleguid` varchar(32) NOT NULL DEFAULT '',
  `static` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `static_file` varchar(255) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_templates`
--

CREATE TABLE IF NOT EXISTS `modx_site_templates` (
  `id` int(10) unsigned NOT NULL,
  `source` int(10) unsigned NOT NULL DEFAULT '0',
  `property_preprocess` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `templatename` varchar(50) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT 'Template',
  `editor_type` int(11) NOT NULL DEFAULT '0',
  `category` int(11) NOT NULL DEFAULT '0',
  `icon` varchar(255) NOT NULL DEFAULT '',
  `template_type` int(11) NOT NULL DEFAULT '0',
  `content` mediumtext NOT NULL,
  `locked` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `properties` text,
  `static` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `static_file` varchar(255) NOT NULL DEFAULT ''
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_site_templates`
--

INSERT INTO `modx_site_templates` (`id`, `source`, `property_preprocess`, `templatename`, `description`, `editor_type`, `category`, `icon`, `template_type`, `content`, `locked`, `properties`, `static`, `static_file`) VALUES
(1, 0, 0, 'Начальный шаблон', 'Template', 0, 0, '', 0, '\n\n<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">\n<html xmlns="http://www.w3.org/1999/xhtml">\n<head>\n<title>[[*pagetitle]] - [[++site_name]]</title>\n<meta http-equiv="Content-Type" content="text/html; charset=[[++modx_charset]]" />\n<base href="[[site_url]]"></base>\n<link rel="stylesheet" href="css/costom.css" type="text/css" media=''screen'' />\n<link rel="stylesheet" href="assets/templates/foundation/default.css" type="text/css" />\n<link rel="alternate" type="application/rss+xml" title="RSS 2.0" href="[[++site_url]][~11~]" />\n  </head>\n<body>\n<body>\n<div id="header">\n	<h1><a href="[[++site_url]]">[[++site_name]]</a></h1>\n	<h2>QwinCor</h2>\n</div>\n<div id="left">\n	<div id="menu" class="boxed">\n		<h2 class="heading">Pages</h2>\n[[Wayfinder?startId=`0` &level=`1`]]\n\n		<h2 class="heading">Latest Entries</h2>\n[[Ditto? &startID=`2` &summarize=`3` &total=`20` &commentschunk=`Comments` &tpl=`nl_sidebar` &showarch=`0` &truncLen=`100` &truncSplit=`0`]]\n	</div>\n</div>\n<!-- end #left -->\n<div id="right">\n	<div class="boxed">\n		<h2 class="heading">Latest News</h2>\n[[ListIndexer?LIn_root=0]] \n		<h2 class="heading">Our Friends</h2>\n<ul>\n<li><a href="[[~2]]">Параллакс эффект</a></li>\n<li>List item number two</li>\n<li>List item number three </li>\n<li>List item number four </li>\n<li>List item number five </li>\n<li>List item number six </li>\n</ul>\n	</div>\n</div>\n<!-- end #right -->\n<div id="center">\n	<div class="boxed">\n		<h1 class="heading">[[*pagetitle]]</h1>\n		<p>[[*content]]</p>\n	</div>\n</div>\n<!-- end #center -->\n<div style="clear: both;">&nbsp;</div>\n<div id="footer">\n	<p id="legal">Copyright &copy; [[++site_name]]. All Rights Reserved. Designed by <a href="http://www.freecsstemplates.org/">Free CSS Templates</a>. Template by <a href="http://modxd.com">MODx Templates</a></p>\n	<p id="links"><a href="#">Privacy Policy</a> | <a href="#">Terms of Use</a></p>\n</div>\n</body>\n</html>', 0, 'a:0:{}', 0, '');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_tmplvar_access`
--

CREATE TABLE IF NOT EXISTS `modx_site_tmplvar_access` (
  `id` int(10) unsigned NOT NULL,
  `tmplvarid` int(10) NOT NULL DEFAULT '0',
  `documentgroup` int(10) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_tmplvar_contentvalues`
--

CREATE TABLE IF NOT EXISTS `modx_site_tmplvar_contentvalues` (
  `id` int(10) unsigned NOT NULL,
  `tmplvarid` int(10) NOT NULL DEFAULT '0',
  `contentid` int(10) NOT NULL DEFAULT '0',
  `value` mediumtext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_tmplvar_templates`
--

CREATE TABLE IF NOT EXISTS `modx_site_tmplvar_templates` (
  `tmplvarid` int(10) NOT NULL DEFAULT '0',
  `templateid` int(11) NOT NULL DEFAULT '0',
  `rank` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_site_tmplvar_templates`
--

INSERT INTO `modx_site_tmplvar_templates` (`tmplvarid`, `templateid`, `rank`) VALUES
(1, 1, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_site_tmplvars`
--

CREATE TABLE IF NOT EXISTS `modx_site_tmplvars` (
  `id` int(10) unsigned NOT NULL,
  `source` int(10) unsigned NOT NULL DEFAULT '0',
  `property_preprocess` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `type` varchar(20) NOT NULL DEFAULT '',
  `name` varchar(50) NOT NULL DEFAULT '',
  `caption` varchar(80) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `editor_type` int(11) NOT NULL DEFAULT '0',
  `category` int(11) NOT NULL DEFAULT '0',
  `locked` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `elements` text,
  `rank` int(11) NOT NULL DEFAULT '0',
  `display` varchar(20) NOT NULL DEFAULT '',
  `default_text` mediumtext,
  `properties` text,
  `input_properties` text,
  `output_properties` text,
  `static` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `static_file` varchar(255) NOT NULL DEFAULT ''
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_site_tmplvars`
--

INSERT INTO `modx_site_tmplvars` (`id`, `source`, `property_preprocess`, `type`, `name`, `caption`, `description`, `editor_type`, `category`, `locked`, `elements`, `rank`, `display`, `default_text`, `properties`, `input_properties`, `output_properties`, `static`, `static_file`) VALUES
(1, 1, 0, 'text', 'satelite', '', '', 0, 0, 0, '', 0, 'default', '', 'a:0:{}', 'a:3:{s:10:"allowBlank";s:4:"true";s:9:"maxLength";s:0:"";s:9:"minLength";s:0:"";}', 'a:0:{}', 0, '');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_system_eventnames`
--

CREATE TABLE IF NOT EXISTS `modx_system_eventnames` (
  `name` varchar(50) NOT NULL,
  `service` tinyint(4) unsigned NOT NULL DEFAULT '0',
  `groupname` varchar(20) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_system_eventnames`
--

INSERT INTO `modx_system_eventnames` (`name`, `service`, `groupname`) VALUES
('OnPluginEventBeforeSave', 1, 'Plugin Events'),
('OnPluginEventSave', 1, 'Plugin Events'),
('OnPluginEventBeforeRemove', 1, 'Plugin Events'),
('OnPluginEventRemove', 1, 'Plugin Events'),
('OnResourceGroupSave', 1, 'Security'),
('OnResourceGroupBeforeSave', 1, 'Security'),
('OnResourceGroupRemove', 1, 'Security'),
('OnResourceGroupBeforeRemove', 1, 'Security'),
('OnSnippetBeforeSave', 1, 'Snippets'),
('OnSnippetSave', 1, 'Snippets'),
('OnSnippetBeforeRemove', 1, 'Snippets'),
('OnSnippetRemove', 1, 'Snippets'),
('OnSnipFormPrerender', 1, 'Snippets'),
('OnSnipFormRender', 1, 'Snippets'),
('OnBeforeSnipFormSave', 1, 'Snippets'),
('OnSnipFormSave', 1, 'Snippets'),
('OnBeforeSnipFormDelete', 1, 'Snippets'),
('OnSnipFormDelete', 1, 'Snippets'),
('OnTemplateBeforeSave', 1, 'Templates'),
('OnTemplateSave', 1, 'Templates'),
('OnTemplateBeforeRemove', 1, 'Templates'),
('OnTemplateRemove', 1, 'Templates'),
('OnTempFormPrerender', 1, 'Templates'),
('OnTempFormRender', 1, 'Templates'),
('OnBeforeTempFormSave', 1, 'Templates'),
('OnTempFormSave', 1, 'Templates'),
('OnBeforeTempFormDelete', 1, 'Templates'),
('OnTempFormDelete', 1, 'Templates'),
('OnTemplateVarBeforeSave', 1, 'Template Variables'),
('OnTemplateVarSave', 1, 'Template Variables'),
('OnTemplateVarBeforeRemove', 1, 'Template Variables'),
('OnTemplateVarRemove', 1, 'Template Variables'),
('OnTVFormPrerender', 1, 'Template Variables'),
('OnTVFormRender', 1, 'Template Variables'),
('OnBeforeTVFormSave', 1, 'Template Variables'),
('OnTVFormSave', 1, 'Template Variables'),
('OnBeforeTVFormDelete', 1, 'Template Variables'),
('OnTVFormDelete', 1, 'Template Variables'),
('OnTVInputRenderList', 1, 'Template Variables'),
('OnTVInputPropertiesList', 1, 'Template Variables'),
('OnTVOutputRenderList', 1, 'Template Variables'),
('OnTVOutputRenderPropertiesList', 1, 'Template Variables'),
('OnUserGroupBeforeSave', 1, 'User Groups'),
('OnUserGroupSave', 1, 'User Groups'),
('OnUserGroupBeforeRemove', 1, 'User Groups'),
('OnUserGroupRemove', 1, 'User Groups'),
('OnBeforeUserGroupFormSave', 1, 'User Groups'),
('OnUserGroupFormSave', 1, 'User Groups'),
('OnBeforeUserGroupFormRemove', 1, 'User Groups'),
('OnDocFormPrerender', 1, 'Resources'),
('OnDocFormRender', 1, 'Resources'),
('OnBeforeDocFormSave', 1, 'Resources'),
('OnDocFormSave', 1, 'Resources'),
('OnBeforeDocFormDelete', 1, 'Resources'),
('OnDocFormDelete', 1, 'Resources'),
('OnDocPublished', 5, 'Resources'),
('OnDocUnPublished', 5, 'Resources'),
('OnBeforeEmptyTrash', 1, 'Resources'),
('OnEmptyTrash', 1, 'Resources'),
('OnResourceTVFormPrerender', 1, 'Resources'),
('OnResourceTVFormRender', 1, 'Resources'),
('OnResourceAutoPublish', 1, 'Resources'),
('OnResourceDelete', 1, 'Resources'),
('OnResourceUndelete', 1, 'Resources'),
('OnResourceBeforeSort', 1, 'Resources'),
('OnResourceSort', 1, 'Resources'),
('OnResourceDuplicate', 1, 'Resources'),
('OnResourceToolbarLoad', 1, 'Resources'),
('OnResourceRemoveFromResourceGroup', 1, 'Resources'),
('OnResourceAddToResourceGroup', 1, 'Resources'),
('OnRichTextEditorRegister', 1, 'RichText Editor'),
('OnRichTextEditorInit', 1, 'RichText Editor'),
('OnRichTextBrowserInit', 1, 'RichText Editor'),
('OnWebLogin', 3, 'Security'),
('OnBeforeWebLogout', 3, 'Security'),
('OnWebLogout', 3, 'Security'),
('OnManagerLogin', 2, 'Security'),
('OnBeforeManagerLogout', 2, 'Security'),
('OnManagerLogout', 2, 'Security'),
('OnBeforeWebLogin', 3, 'Security'),
('OnWebAuthentication', 3, 'Security'),
('OnBeforeManagerLogin', 2, 'Security'),
('OnManagerAuthentication', 2, 'Security'),
('OnManagerLoginFormRender', 2, 'Security'),
('OnManagerLoginFormPrerender', 2, 'Security'),
('OnPageUnauthorized', 1, 'Security'),
('OnUserFormPrerender', 1, 'Users'),
('OnUserFormRender', 1, 'Users'),
('OnBeforeUserFormSave', 1, 'Users'),
('OnUserFormSave', 1, 'Users'),
('OnBeforeUserFormDelete', 1, 'Users'),
('OnUserFormDelete', 1, 'Users'),
('OnUserNotFound', 1, 'Users'),
('OnBeforeUserActivate', 1, 'Users'),
('OnUserActivate', 1, 'Users'),
('OnBeforeUserDeactivate', 1, 'Users'),
('OnUserDeactivate', 1, 'Users'),
('OnBeforeUserDuplicate', 1, 'Users'),
('OnUserDuplicate', 1, 'Users'),
('OnUserChangePassword', 1, 'Users'),
('OnUserBeforeRemove', 1, 'Users'),
('OnUserBeforeSave', 1, 'Users'),
('OnUserSave', 1, 'Users'),
('OnUserRemove', 1, 'Users'),
('OnUserBeforeAddToGroup', 1, 'User Groups'),
('OnUserAddToGroup', 1, 'User Groups'),
('OnUserBeforeRemoveFromGroup', 1, 'User Groups'),
('OnUserRemoveFromGroup', 1, 'User Groups'),
('OnWebPagePrerender', 5, 'System'),
('OnBeforeCacheUpdate', 4, 'System'),
('OnCacheUpdate', 4, 'System'),
('OnLoadWebPageCache', 4, 'System'),
('OnBeforeSaveWebPageCache', 4, 'System'),
('OnSiteRefresh', 1, 'System'),
('OnFileManagerDirCreate', 1, 'System'),
('OnFileManagerDirRemove', 1, 'System'),
('OnFileManagerDirRename', 1, 'System'),
('OnFileManagerFileRename', 1, 'System'),
('OnFileManagerFileRemove', 1, 'System'),
('OnFileManagerFileUpdate', 1, 'System'),
('OnFileManagerFileCreate', 1, 'System'),
('OnFileManagerBeforeUpload', 1, 'System'),
('OnFileManagerUpload', 1, 'System'),
('OnFileManagerMoveObject', 1, 'System'),
('OnFileCreateFormPrerender', 1, 'System'),
('OnFileEditFormPrerender', 1, 'System'),
('OnManagerPageInit', 2, 'System'),
('OnManagerPageBeforeRender', 2, 'System'),
('OnManagerPageAfterRender', 2, 'System'),
('OnWebPageInit', 5, 'System'),
('OnLoadWebDocument', 5, 'System'),
('OnParseDocument', 5, 'System'),
('OnWebPageComplete', 5, 'System'),
('OnBeforeManagerPageInit', 2, 'System'),
('OnPageNotFound', 1, 'System'),
('OnHandleRequest', 5, 'System'),
('OnMODXInit', 5, 'System'),
('OnElementNotFound', 1, 'System'),
('OnSiteSettingsRender', 1, 'Settings'),
('OnInitCulture', 1, 'Internationalization'),
('OnCategorySave', 1, 'Categories'),
('OnCategoryBeforeSave', 1, 'Categories'),
('OnCategoryRemove', 1, 'Categories'),
('OnCategoryBeforeRemove', 1, 'Categories'),
('OnChunkSave', 1, 'Chunks'),
('OnChunkBeforeSave', 1, 'Chunks'),
('OnChunkRemove', 1, 'Chunks'),
('OnChunkBeforeRemove', 1, 'Chunks'),
('OnChunkFormPrerender', 1, 'Chunks'),
('OnChunkFormRender', 1, 'Chunks'),
('OnBeforeChunkFormSave', 1, 'Chunks'),
('OnChunkFormSave', 1, 'Chunks'),
('OnBeforeChunkFormDelete', 1, 'Chunks'),
('OnChunkFormDelete', 1, 'Chunks'),
('OnContextSave', 1, 'Contexts'),
('OnContextBeforeSave', 1, 'Contexts'),
('OnContextRemove', 1, 'Contexts'),
('OnContextBeforeRemove', 1, 'Contexts'),
('OnContextFormPrerender', 2, 'Contexts'),
('OnContextFormRender', 2, 'Contexts'),
('OnPluginSave', 1, 'Plugins'),
('OnPluginBeforeSave', 1, 'Plugins'),
('OnPluginRemove', 1, 'Plugins'),
('OnPluginBeforeRemove', 1, 'Plugins'),
('OnPluginFormPrerender', 1, 'Plugins'),
('OnPluginFormRender', 1, 'Plugins'),
('OnBeforePluginFormSave', 1, 'Plugins'),
('OnPluginFormSave', 1, 'Plugins'),
('OnBeforePluginFormDelete', 1, 'Plugins'),
('OnPluginFormDelete', 1, 'Plugins'),
('OnPropertySetSave', 1, 'Property Sets'),
('OnPropertySetBeforeSave', 1, 'Property Sets'),
('OnPropertySetRemove', 1, 'Property Sets'),
('OnPropertySetBeforeRemove', 1, 'Property Sets'),
('OnMediaSourceBeforeFormDelete', 1, 'Media Sources'),
('OnMediaSourceBeforeFormSave', 1, 'Media Sources'),
('OnMediaSourceGetProperties', 1, 'Media Sources'),
('OnMediaSourceFormDelete', 1, 'Media Sources'),
('OnMediaSourceFormSave', 1, 'Media Sources'),
('OnMediaSourceDuplicate', 1, 'Media Sources');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_system_settings`
--

CREATE TABLE IF NOT EXISTS `modx_system_settings` (
  `key` varchar(50) NOT NULL DEFAULT '',
  `value` text NOT NULL,
  `xtype` varchar(75) NOT NULL DEFAULT 'textfield',
  `namespace` varchar(40) NOT NULL DEFAULT 'core',
  `area` varchar(255) NOT NULL DEFAULT '',
  `editedon` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_system_settings`
--

INSERT INTO `modx_system_settings` (`key`, `value`, `xtype`, `namespace`, `area`, `editedon`) VALUES
('access_category_enabled', '1', 'combo-boolean', 'core', 'authentication', '0000-00-00 00:00:00'),
('access_context_enabled', '1', 'combo-boolean', 'core', 'authentication', '0000-00-00 00:00:00'),
('access_resource_group_enabled', '1', 'combo-boolean', 'core', 'authentication', '0000-00-00 00:00:00'),
('allow_forward_across_contexts', '', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('allow_manager_login_forgot_password', '1', 'combo-boolean', 'core', 'authentication', '0000-00-00 00:00:00'),
('allow_multiple_emails', '1', 'combo-boolean', 'core', 'authentication', '0000-00-00 00:00:00'),
('allow_tags_in_post', '', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('archive_with', '', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('auto_menuindex', '1', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('auto_check_pkg_updates', '1', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('auto_check_pkg_updates_cache_expire', '15', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('automatic_alias', '1', 'combo-boolean', 'core', 'furls', '0000-00-00 00:00:00'),
('base_help_url', '//rtfm.modx.com/display/revolution20/', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('blocked_minutes', '60', 'textfield', 'core', 'authentication', '0000-00-00 00:00:00'),
('cache_action_map', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_alias_map', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_context_settings', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_db', '0', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_db_expires', '0', 'textfield', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_db_session', '0', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_db_session_lifetime', '', 'textfield', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_default', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_disabled', '0', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_expires', '0', 'textfield', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_format', '0', 'textfield', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_handler', 'xPDOFileCache', 'textfield', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_lang_js', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_lexicon_topics', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_noncore_lexicon_topics', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_resource', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_resource_expires', '0', 'textfield', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_scripts', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('cache_system_settings', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('clear_cache_refresh_trees', '0', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('compress_css', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('compress_js', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('compress_js_max_files', '10', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('compress_js_groups', '', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('confirm_navigation', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('container_suffix', '/', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('context_tree_sort', '', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('context_tree_sortby', 'rank', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('context_tree_sortdir', 'ASC', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('cultureKey', 'ru', 'modx-combo-language', 'core', 'language', '2015-07-24 21:53:33'),
('date_timezone', '', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('debug', '', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('default_duplicate_publish_option', 'preserve', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('default_media_source', '1', 'modx-combo-source', 'core', 'manager', '0000-00-00 00:00:00'),
('default_per_page', '20', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('default_context', 'web', 'modx-combo-context', 'core', 'site', '0000-00-00 00:00:00'),
('default_template', '1', 'modx-combo-template', 'core', 'site', '0000-00-00 00:00:00'),
('default_content_type', '1', 'modx-combo-content-type', 'core', 'site', '0000-00-00 00:00:00'),
('editor_css_path', '', 'textfield', 'core', 'editor', '0000-00-00 00:00:00'),
('editor_css_selectors', '', 'textfield', 'core', 'editor', '0000-00-00 00:00:00'),
('emailsender', 'qwinmen@yandex.ru', 'textfield', 'core', 'authentication', '2015-07-24 21:53:33'),
('emailsubject', 'Your login details', 'textfield', 'core', 'authentication', '0000-00-00 00:00:00'),
('enable_dragdrop', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('error_page', '1', 'textfield', 'core', 'site', '0000-00-00 00:00:00'),
('failed_login_attempts', '5', 'textfield', 'core', 'authentication', '0000-00-00 00:00:00'),
('fe_editor_lang', 'en', 'modx-combo-language', 'core', 'language', '0000-00-00 00:00:00'),
('feed_modx_news', 'http://feeds.feedburner.com/modx-announce', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('feed_modx_news_enabled', '1', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('feed_modx_security', 'http://forums.modx.com/board.xml?board=294', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('feed_modx_security_enabled', '1', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('filemanager_path', '', 'textfield', 'core', 'file', '0000-00-00 00:00:00'),
('filemanager_path_relative', '1', 'combo-boolean', 'core', 'file', '0000-00-00 00:00:00'),
('filemanager_url', '', 'textfield', 'core', 'file', '0000-00-00 00:00:00'),
('filemanager_url_relative', '1', 'combo-boolean', 'core', 'file', '0000-00-00 00:00:00'),
('forgot_login_email', '<p>Hello [[+username]],</p>\n<p>A request for a password reset has been issued for your MODX user. If you sent this, you may follow this link and use this password to login. If you did not send this request, please ignore this email.</p>\n\n<p>\n    <strong>Activation Link:</strong> [[+url_scheme]][[+http_host]][[+manager_url]]?modahsh=[[+hash]]<br />\n    <strong>Username:</strong> [[+username]]<br />\n    <strong>Password:</strong> [[+password]]<br />\n</p>\n\n<p>After you log into the MODX Manager, you can change your password again, if you wish.</p>\n\n<p>Regards,<br />Site Administrator</p>', 'textarea', 'core', 'authentication', '0000-00-00 00:00:00'),
('form_customization_use_all_groups', '', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('forward_merge_excludes', 'type,published,class_key', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('friendly_alias_lowercase_only', '1', 'combo-boolean', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_max_length', '0', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_restrict_chars', 'pattern', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_restrict_chars_pattern', '/[\\0\\x0B\\t\\n\\r\\f\\a&=+%#<>"~:`@\\?\\[\\]\\{\\}\\|\\^''\\\\]/', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_strip_element_tags', '1', 'combo-boolean', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_translit', 'none', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_translit_class', 'translit.modTransliterate', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_translit_class_path', '{core_path}components/', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_trim_chars', '/.-_', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_word_delimiter', '-', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_alias_word_delimiters', '-_', 'textfield', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_urls', '0', 'combo-boolean', 'core', 'furls', '0000-00-00 00:00:00'),
('friendly_urls_strict', '0', 'combo-boolean', 'core', 'furls', '0000-00-00 00:00:00'),
('global_duplicate_uri_check', '0', 'combo-boolean', 'core', 'furls', '0000-00-00 00:00:00'),
('hidemenu_default', '0', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('inline_help', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('locale', '', 'textfield', 'core', 'language', '0000-00-00 00:00:00'),
('log_level', '1', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('log_target', 'FILE', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('link_tag_scheme', '-1', 'textfield', 'core', 'site', '0000-00-00 00:00:00'),
('lock_ttl', '360', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('mail_charset', 'UTF-8', 'modx-combo-charset', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_encoding', '8bit', 'textfield', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_use_smtp', '', 'combo-boolean', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_auth', '', 'combo-boolean', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_helo', '', 'textfield', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_hosts', 'localhost', 'textfield', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_keepalive', '', 'combo-boolean', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_pass', '', 'text-password', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_port', '587', 'textfield', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_prefix', '', 'textfield', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_single_to', '', 'combo-boolean', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_timeout', '10', 'textfield', 'core', 'mail', '0000-00-00 00:00:00'),
('mail_smtp_user', '', 'textfield', 'core', 'mail', '0000-00-00 00:00:00'),
('manager_date_format', 'Y-m-d', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_favicon_url', '', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_html5_cache', '0', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_js_cache_file_locking', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_js_cache_max_age', '3600', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_js_document_root', '', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_js_zlib_output_compression', '0', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_time_format', 'g:i a', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_direction', 'ltr', 'textfield', 'core', 'language', '0000-00-00 00:00:00'),
('manager_lang_attribute', 'ru', 'textfield', 'core', 'language', '2015-07-24 21:53:33'),
('manager_language', 'ru', 'modx-combo-language', 'core', 'language', '2015-07-24 21:53:33'),
('manager_login_url_alternate', '', 'textfield', 'core', 'authentication', '0000-00-00 00:00:00'),
('manager_theme', 'default', 'modx-combo-manager-theme', 'core', 'manager', '0000-00-00 00:00:00'),
('manager_week_start', '0', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('modx_browser_default_sort', 'name', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('modx_browser_default_viewmode', 'grid', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('modx_charset', 'UTF-8', 'modx-combo-charset', 'core', 'language', '0000-00-00 00:00:00'),
('principal_targets', 'modAccessContext,modAccessResourceGroup,modAccessCategory,sources.modAccessMediaSource', 'textfield', 'core', 'authentication', '0000-00-00 00:00:00'),
('proxy_auth_type', 'BASIC', 'textfield', 'core', 'proxy', '0000-00-00 00:00:00'),
('proxy_host', '', 'textfield', 'core', 'proxy', '0000-00-00 00:00:00'),
('proxy_password', '', 'text-password', 'core', 'proxy', '0000-00-00 00:00:00'),
('proxy_port', '', 'textfield', 'core', 'proxy', '0000-00-00 00:00:00'),
('proxy_username', '', 'textfield', 'core', 'proxy', '0000-00-00 00:00:00'),
('password_generated_length', '8', 'textfield', 'core', 'authentication', '0000-00-00 00:00:00'),
('password_min_length', '8', 'textfield', 'core', 'authentication', '0000-00-00 00:00:00'),
('phpthumb_allow_src_above_docroot', '', 'combo-boolean', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_cache_maxage', '30', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_cache_maxsize', '100', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_cache_maxfiles', '10000', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_cache_source_enabled', '', 'combo-boolean', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_document_root', '', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_error_bgcolor', 'CCCCFF', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_error_textcolor', 'FF0000', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_error_fontsize', '1', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_far', 'C', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_imagemagick_path', '', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nohotlink_enabled', '1', 'combo-boolean', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nohotlink_erase_image', '1', 'combo-boolean', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nohotlink_valid_domains', '{http_host}', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nohotlink_text_message', 'Off-server thumbnailing is not allowed', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nooffsitelink_enabled', '', 'combo-boolean', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nooffsitelink_erase_image', '1', 'combo-boolean', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nooffsitelink_require_refer', '', 'combo-boolean', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nooffsitelink_text_message', 'Off-server linking is not allowed', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nooffsitelink_valid_domains', '{http_host}', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_nooffsitelink_watermark_src', '', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('phpthumb_zoomcrop', '0', 'textfield', 'core', 'phpthumb', '0000-00-00 00:00:00'),
('publish_default', '', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('rb_base_dir', '', 'textfield', 'core', 'file', '0000-00-00 00:00:00'),
('rb_base_url', '', 'textfield', 'core', 'file', '0000-00-00 00:00:00'),
('request_controller', 'index.php', 'textfield', 'core', 'gateway', '0000-00-00 00:00:00'),
('request_method_strict', '0', 'combo-boolean', 'core', 'gateway', '0000-00-00 00:00:00'),
('request_param_alias', 'q', 'textfield', 'core', 'gateway', '0000-00-00 00:00:00'),
('request_param_id', 'id', 'textfield', 'core', 'gateway', '0000-00-00 00:00:00'),
('resolve_hostnames', '0', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('resource_tree_node_name', 'pagetitle', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('resource_tree_node_name_fallback', 'pagetitle', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('resource_tree_node_tooltip', '', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('richtext_default', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('search_default', '1', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('server_offset_time', '0', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('server_protocol', 'http', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('session_cookie_domain', '', 'textfield', 'core', 'session', '0000-00-00 00:00:00'),
('session_cookie_lifetime', '604800', 'textfield', 'core', 'session', '0000-00-00 00:00:00'),
('session_cookie_path', '', 'textfield', 'core', 'session', '0000-00-00 00:00:00'),
('session_cookie_secure', '', 'combo-boolean', 'core', 'session', '0000-00-00 00:00:00'),
('session_cookie_httponly', '1', 'combo-boolean', 'core', 'session', '0000-00-00 00:00:00'),
('session_gc_maxlifetime', '604800', 'textfield', 'core', 'session', '0000-00-00 00:00:00'),
('session_handler_class', 'modSessionHandler', 'textfield', 'core', 'session', '0000-00-00 00:00:00'),
('session_name', '', 'textfield', 'core', 'session', '0000-00-00 00:00:00'),
('set_header', '1', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00'),
('show_tv_categories_header', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('signupemail_message', '<p>Hello [[+uid]],</p>\n    <p>Here are your login details for the [[+sname]] MODX Manager:</p>\n\n    <p>\n        <strong>Username:</strong> [[+uid]]<br />\n        <strong>Password:</strong> [[+pwd]]<br />\n    </p>\n\n    <p>Once you log into the MODX Manager at [[+surl]], you can change your password.</p>\n\n    <p>Regards,<br />Site Administrator</p>', 'textarea', 'core', 'authentication', '0000-00-00 00:00:00'),
('site_name', 'MODX Revolution', 'textfield', 'core', 'site', '0000-00-00 00:00:00'),
('site_start', '1', 'textfield', 'core', 'site', '0000-00-00 00:00:00'),
('site_status', '1', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('site_unavailable_message', 'The site is currently unavailable', 'textfield', 'core', 'site', '0000-00-00 00:00:00'),
('site_unavailable_page', '0', 'textfield', 'core', 'site', '0000-00-00 00:00:00'),
('strip_image_paths', '1', 'combo-boolean', 'core', 'file', '0000-00-00 00:00:00'),
('symlink_merge_fields', '1', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('syncsite_default', '1', 'combo-boolean', 'core', 'caching', '0000-00-00 00:00:00'),
('topmenu_show_descriptions', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('tree_default_sort', 'menuindex', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('tree_root_id', '0', 'numberfield', 'core', 'manager', '0000-00-00 00:00:00'),
('tvs_below_content', '0', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('udperms_allowroot', '', 'combo-boolean', 'core', 'authentication', '0000-00-00 00:00:00'),
('unauthorized_page', '1', 'textfield', 'core', 'site', '0000-00-00 00:00:00'),
('upload_files', 'txt,html,htm,xml,js,css,zip,gz,rar,z,tgz,tar,htaccess,mp3,mp4,aac,wav,au,wmv,avi,mpg,mpeg,pdf,doc,docx,xls,xlsx,ppt,pptx,jpg,jpeg,png,gif,psd,ico,bmp,odt,ods,odp,odb,odg,odf', 'textfield', 'core', 'file', '0000-00-00 00:00:00'),
('upload_flash', 'swf,fla', 'textfield', 'core', 'file', '0000-00-00 00:00:00'),
('upload_images', 'jpg,jpeg,png,gif,psd,ico,bmp', 'textfield', 'core', 'file', '0000-00-00 00:00:00'),
('upload_maxsize', '2097152', 'textfield', 'core', 'file', '2015-07-24 21:53:33'),
('upload_media', 'mp3,wav,au,wmv,avi,mpg,mpeg', 'textfield', 'core', 'file', '0000-00-00 00:00:00'),
('use_alias_path', '0', 'combo-boolean', 'core', 'furls', '0000-00-00 00:00:00'),
('use_browser', '1', 'combo-boolean', 'core', 'file', '0000-00-00 00:00:00'),
('use_editor', '1', 'combo-boolean', 'core', 'editor', '0000-00-00 00:00:00'),
('use_multibyte', '1', 'combo-boolean', 'core', 'language', '2015-07-24 21:53:33'),
('use_weblink_target', '', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('webpwdreminder_message', '<p>Hello [[+uid]],</p>\n\n    <p>To activate your new password click the following link:</p>\n\n    <p>[[+surl]]</p>\n\n    <p>If successful you can use the following password to login:</p>\n\n    <p><strong>Password:</strong> [[+pwd]]</p>\n\n    <p>If you did not request this email then please ignore it.</p>\n\n    <p>Regards,<br />\n    Site Administrator</p>', 'textarea', 'core', 'authentication', '0000-00-00 00:00:00'),
('websignupemail_message', '<p>Hello [[+uid]],</p>\n\n    <p>Here are your login details for [[+sname]]:</p>\n\n    <p><strong>Username:</strong> [[+uid]]<br />\n    <strong>Password:</strong> [[+pwd]]</p>\n\n    <p>Once you log into [[+sname]] at [[+surl]], you can change your password.</p>\n\n    <p>Regards,<br />\n    Site Administrator</p>', 'textarea', 'core', 'authentication', '0000-00-00 00:00:00'),
('welcome_screen', '', 'combo-boolean', 'core', 'manager', '2015-07-24 21:54:21'),
('welcome_screen_url', '//misc.modx.com/revolution/welcome.23.html', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('welcome_action', 'welcome', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('welcome_namespace', 'core', 'textfield', 'core', 'manager', '0000-00-00 00:00:00'),
('which_editor', '', 'modx-combo-rte', 'core', 'editor', '0000-00-00 00:00:00'),
('which_element_editor', '', 'modx-combo-rte', 'core', 'editor', '0000-00-00 00:00:00'),
('xhtml_urls', '1', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('enable_gravatar', '1', 'combo-boolean', 'core', 'manager', '0000-00-00 00:00:00'),
('auto_isfolder', '1', 'combo-boolean', 'core', 'site', '0000-00-00 00:00:00'),
('settings_version', '2.3.5-pl', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('settings_distro', 'sdk', 'textfield', 'core', 'system', '0000-00-00 00:00:00'),
('ext_debug', '', 'combo-boolean', 'core', 'system', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Структура таблицы `modx_transport_packages`
--

CREATE TABLE IF NOT EXISTS `modx_transport_packages` (
  `signature` varchar(255) NOT NULL,
  `created` datetime NOT NULL,
  `updated` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `installed` datetime DEFAULT NULL,
  `state` tinyint(1) unsigned NOT NULL DEFAULT '1',
  `workspace` int(10) unsigned NOT NULL DEFAULT '0',
  `provider` int(10) unsigned NOT NULL DEFAULT '0',
  `disabled` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `source` tinytext,
  `manifest` text,
  `attributes` mediumtext,
  `package_name` varchar(255) NOT NULL,
  `metadata` text,
  `version_major` smallint(5) unsigned NOT NULL DEFAULT '0',
  `version_minor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `version_patch` smallint(5) unsigned NOT NULL DEFAULT '0',
  `release` varchar(100) NOT NULL DEFAULT '',
  `release_index` smallint(5) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_transport_providers`
--

CREATE TABLE IF NOT EXISTS `modx_transport_providers` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` mediumtext,
  `service_url` tinytext,
  `username` varchar(255) NOT NULL DEFAULT '',
  `api_key` varchar(255) NOT NULL DEFAULT '',
  `created` datetime NOT NULL,
  `updated` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_transport_providers`
--

INSERT INTO `modx_transport_providers` (`id`, `name`, `description`, `service_url`, `username`, `api_key`, `created`, `updated`) VALUES
(1, 'modx.com', 'The official MODX transport facility for 3rd party components.', 'http://rest.modx.com/extras/', '', '', '2015-06-25 18:45:24', NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_user_attributes`
--

CREATE TABLE IF NOT EXISTS `modx_user_attributes` (
  `id` int(10) unsigned NOT NULL,
  `internalKey` int(10) NOT NULL,
  `fullname` varchar(100) NOT NULL DEFAULT '',
  `email` varchar(100) NOT NULL DEFAULT '',
  `phone` varchar(100) NOT NULL DEFAULT '',
  `mobilephone` varchar(100) NOT NULL DEFAULT '',
  `blocked` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `blockeduntil` int(11) NOT NULL DEFAULT '0',
  `blockedafter` int(11) NOT NULL DEFAULT '0',
  `logincount` int(11) NOT NULL DEFAULT '0',
  `lastlogin` int(11) NOT NULL DEFAULT '0',
  `thislogin` int(11) NOT NULL DEFAULT '0',
  `failedlogincount` int(10) NOT NULL DEFAULT '0',
  `sessionid` varchar(100) NOT NULL DEFAULT '',
  `dob` int(10) NOT NULL DEFAULT '0',
  `gender` int(1) NOT NULL DEFAULT '0',
  `address` text NOT NULL,
  `country` varchar(255) NOT NULL DEFAULT '',
  `city` varchar(255) NOT NULL DEFAULT '',
  `state` varchar(25) NOT NULL DEFAULT '',
  `zip` varchar(25) NOT NULL DEFAULT '',
  `fax` varchar(100) NOT NULL DEFAULT '',
  `photo` varchar(255) NOT NULL DEFAULT '',
  `comment` text NOT NULL,
  `website` varchar(255) NOT NULL DEFAULT '',
  `extended` text
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_user_attributes`
--

INSERT INTO `modx_user_attributes` (`id`, `internalKey`, `fullname`, `email`, `phone`, `mobilephone`, `blocked`, `blockeduntil`, `blockedafter`, `logincount`, `lastlogin`, `thislogin`, `failedlogincount`, `sessionid`, `dob`, `gender`, `address`, `country`, `city`, `state`, `zip`, `fax`, `photo`, `comment`, `website`, `extended`) VALUES
(1, 1, 'Учётная запись администратора по умолчанию', 'qwinmen@yandex.ru', '', '', 0, 0, 0, 3, 1437775224, 1437851719, 0, '7lb46mqc75fkv7f33045el70a4', 0, 0, '', '', '', '', '', '', '', '', '', NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_user_group_roles`
--

CREATE TABLE IF NOT EXISTS `modx_user_group_roles` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` mediumtext,
  `authority` int(10) unsigned NOT NULL DEFAULT '9999'
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_user_group_roles`
--

INSERT INTO `modx_user_group_roles` (`id`, `name`, `description`, `authority`) VALUES
(1, 'Member', NULL, 9999),
(2, 'Super User', NULL, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_user_group_settings`
--

CREATE TABLE IF NOT EXISTS `modx_user_group_settings` (
  `group` int(10) unsigned NOT NULL DEFAULT '0',
  `key` varchar(50) NOT NULL,
  `value` text,
  `xtype` varchar(75) NOT NULL DEFAULT 'textfield',
  `namespace` varchar(40) NOT NULL DEFAULT 'core',
  `area` varchar(255) NOT NULL DEFAULT '',
  `editedon` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_user_messages`
--

CREATE TABLE IF NOT EXISTS `modx_user_messages` (
  `id` int(10) unsigned NOT NULL,
  `type` varchar(15) NOT NULL DEFAULT '',
  `subject` varchar(255) NOT NULL DEFAULT '',
  `message` text NOT NULL,
  `sender` int(10) NOT NULL DEFAULT '0',
  `recipient` int(10) NOT NULL DEFAULT '0',
  `private` tinyint(4) NOT NULL DEFAULT '0',
  `date_sent` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `read` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_user_settings`
--

CREATE TABLE IF NOT EXISTS `modx_user_settings` (
  `user` int(11) NOT NULL DEFAULT '0',
  `key` varchar(50) NOT NULL DEFAULT '',
  `value` text,
  `xtype` varchar(75) NOT NULL DEFAULT 'textfield',
  `namespace` varchar(40) NOT NULL DEFAULT 'core',
  `area` varchar(255) NOT NULL DEFAULT '',
  `editedon` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `modx_users`
--

CREATE TABLE IF NOT EXISTS `modx_users` (
  `id` int(10) unsigned NOT NULL,
  `username` varchar(100) NOT NULL DEFAULT '',
  `password` varchar(100) NOT NULL DEFAULT '',
  `cachepwd` varchar(100) NOT NULL DEFAULT '',
  `class_key` varchar(100) NOT NULL DEFAULT 'modUser',
  `active` tinyint(1) unsigned NOT NULL DEFAULT '1',
  `remote_key` varchar(255) DEFAULT NULL,
  `remote_data` text,
  `hash_class` varchar(100) NOT NULL DEFAULT 'hashing.modPBKDF2',
  `salt` varchar(100) NOT NULL DEFAULT '',
  `primary_group` int(10) unsigned NOT NULL DEFAULT '0',
  `session_stale` text,
  `sudo` tinyint(1) unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_users`
--

INSERT INTO `modx_users` (`id`, `username`, `password`, `cachepwd`, `class_key`, `active`, `remote_key`, `remote_data`, `hash_class`, `salt`, `primary_group`, `session_stale`, `sudo`) VALUES
(1, 'admin', 'WyjhoJayKv6kq4YC8jd+NHObfPOFE6P5I0yM9MS4YyA=', '', 'modUser', 1, NULL, NULL, 'hashing.modPBKDF2', 'e05ec07b005bc732b8cea8a6a3f2449e', 1, NULL, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `modx_workspaces`
--

CREATE TABLE IF NOT EXISTS `modx_workspaces` (
  `id` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `path` varchar(255) NOT NULL DEFAULT '',
  `created` datetime NOT NULL,
  `active` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `attributes` mediumtext
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `modx_workspaces`
--

INSERT INTO `modx_workspaces` (`id`, `name`, `path`, `created`, `active`, `attributes`) VALUES
(1, 'Default MODX workspace', '{core_path}', '2015-07-24 23:53:22', 1, NULL);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `modx_access_actiondom`
--
ALTER TABLE `modx_access_actiondom`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`);

--
-- Индексы таблицы `modx_access_actions`
--
ALTER TABLE `modx_access_actions`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`);

--
-- Индексы таблицы `modx_access_category`
--
ALTER TABLE `modx_access_category`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`), ADD KEY `context_key` (`context_key`);

--
-- Индексы таблицы `modx_access_context`
--
ALTER TABLE `modx_access_context`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`);

--
-- Индексы таблицы `modx_access_elements`
--
ALTER TABLE `modx_access_elements`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`), ADD KEY `context_key` (`context_key`);

--
-- Индексы таблицы `modx_access_media_source`
--
ALTER TABLE `modx_access_media_source`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`), ADD KEY `context_key` (`context_key`);

--
-- Индексы таблицы `modx_access_menus`
--
ALTER TABLE `modx_access_menus`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`);

--
-- Индексы таблицы `modx_access_permissions`
--
ALTER TABLE `modx_access_permissions`
  ADD PRIMARY KEY (`id`), ADD KEY `template` (`template`), ADD KEY `name` (`name`);

--
-- Индексы таблицы `modx_access_policies`
--
ALTER TABLE `modx_access_policies`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `parent` (`parent`), ADD KEY `class` (`class`), ADD KEY `template` (`template`);

--
-- Индексы таблицы `modx_access_policy_template_groups`
--
ALTER TABLE `modx_access_policy_template_groups`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `modx_access_policy_templates`
--
ALTER TABLE `modx_access_policy_templates`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `modx_access_resource_groups`
--
ALTER TABLE `modx_access_resource_groups`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`), ADD KEY `context_key` (`context_key`);

--
-- Индексы таблицы `modx_access_resources`
--
ALTER TABLE `modx_access_resources`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`), ADD KEY `context_key` (`context_key`);

--
-- Индексы таблицы `modx_access_templatevars`
--
ALTER TABLE `modx_access_templatevars`
  ADD PRIMARY KEY (`id`), ADD KEY `target` (`target`), ADD KEY `principal_class` (`principal_class`), ADD KEY `principal` (`principal`), ADD KEY `authority` (`authority`), ADD KEY `policy` (`policy`), ADD KEY `context_key` (`context_key`);

--
-- Индексы таблицы `modx_actiondom`
--
ALTER TABLE `modx_actiondom`
  ADD PRIMARY KEY (`id`), ADD KEY `set` (`set`), ADD KEY `action` (`action`), ADD KEY `name` (`name`), ADD KEY `active` (`active`), ADD KEY `for_parent` (`for_parent`), ADD KEY `rank` (`rank`);

--
-- Индексы таблицы `modx_actions`
--
ALTER TABLE `modx_actions`
  ADD PRIMARY KEY (`id`), ADD KEY `namespace` (`namespace`), ADD KEY `controller` (`controller`);

--
-- Индексы таблицы `modx_actions_fields`
--
ALTER TABLE `modx_actions_fields`
  ADD PRIMARY KEY (`id`), ADD KEY `action` (`action`), ADD KEY `type` (`type`), ADD KEY `tab` (`tab`);

--
-- Индексы таблицы `modx_active_users`
--
ALTER TABLE `modx_active_users`
  ADD PRIMARY KEY (`internalKey`);

--
-- Индексы таблицы `modx_categories`
--
ALTER TABLE `modx_categories`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `category` (`parent`,`category`), ADD KEY `parent` (`parent`);

--
-- Индексы таблицы `modx_categories_closure`
--
ALTER TABLE `modx_categories_closure`
  ADD PRIMARY KEY (`ancestor`,`descendant`);

--
-- Индексы таблицы `modx_class_map`
--
ALTER TABLE `modx_class_map`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `class` (`class`), ADD KEY `parent_class` (`parent_class`), ADD KEY `name_field` (`name_field`);

--
-- Индексы таблицы `modx_content_type`
--
ALTER TABLE `modx_content_type`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`);

--
-- Индексы таблицы `modx_context`
--
ALTER TABLE `modx_context`
  ADD PRIMARY KEY (`key`), ADD KEY `name` (`name`), ADD KEY `rank` (`rank`);

--
-- Индексы таблицы `modx_context_resource`
--
ALTER TABLE `modx_context_resource`
  ADD PRIMARY KEY (`context_key`,`resource`);

--
-- Индексы таблицы `modx_context_setting`
--
ALTER TABLE `modx_context_setting`
  ADD PRIMARY KEY (`context_key`,`key`);

--
-- Индексы таблицы `modx_dashboard`
--
ALTER TABLE `modx_dashboard`
  ADD PRIMARY KEY (`id`), ADD KEY `name` (`name`), ADD KEY `hide_trees` (`hide_trees`);

--
-- Индексы таблицы `modx_dashboard_widget`
--
ALTER TABLE `modx_dashboard_widget`
  ADD PRIMARY KEY (`id`), ADD KEY `name` (`name`), ADD KEY `type` (`type`), ADD KEY `namespace` (`namespace`), ADD KEY `lexicon` (`lexicon`);

--
-- Индексы таблицы `modx_dashboard_widget_placement`
--
ALTER TABLE `modx_dashboard_widget_placement`
  ADD PRIMARY KEY (`dashboard`,`widget`), ADD KEY `rank` (`rank`);

--
-- Индексы таблицы `modx_document_groups`
--
ALTER TABLE `modx_document_groups`
  ADD PRIMARY KEY (`id`), ADD KEY `document_group` (`document_group`), ADD KEY `document` (`document`);

--
-- Индексы таблицы `modx_documentgroup_names`
--
ALTER TABLE `modx_documentgroup_names`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`);

--
-- Индексы таблицы `modx_element_property_sets`
--
ALTER TABLE `modx_element_property_sets`
  ADD PRIMARY KEY (`element`,`element_class`,`property_set`);

--
-- Индексы таблицы `modx_extension_packages`
--
ALTER TABLE `modx_extension_packages`
  ADD PRIMARY KEY (`id`), ADD KEY `namespace` (`namespace`), ADD KEY `name` (`name`);

--
-- Индексы таблицы `modx_fc_profiles`
--
ALTER TABLE `modx_fc_profiles`
  ADD PRIMARY KEY (`id`), ADD KEY `name` (`name`), ADD KEY `rank` (`rank`), ADD KEY `active` (`active`);

--
-- Индексы таблицы `modx_fc_profiles_usergroups`
--
ALTER TABLE `modx_fc_profiles_usergroups`
  ADD PRIMARY KEY (`usergroup`,`profile`);

--
-- Индексы таблицы `modx_fc_sets`
--
ALTER TABLE `modx_fc_sets`
  ADD PRIMARY KEY (`id`), ADD KEY `profile` (`profile`), ADD KEY `action` (`action`), ADD KEY `active` (`active`), ADD KEY `template` (`template`);

--
-- Индексы таблицы `modx_lexicon_entries`
--
ALTER TABLE `modx_lexicon_entries`
  ADD PRIMARY KEY (`id`), ADD KEY `name` (`name`), ADD KEY `topic` (`topic`), ADD KEY `namespace` (`namespace`), ADD KEY `language` (`language`);

--
-- Индексы таблицы `modx_manager_log`
--
ALTER TABLE `modx_manager_log`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `modx_media_sources`
--
ALTER TABLE `modx_media_sources`
  ADD PRIMARY KEY (`id`), ADD KEY `name` (`name`), ADD KEY `class_key` (`class_key`), ADD KEY `is_stream` (`is_stream`);

--
-- Индексы таблицы `modx_media_sources_contexts`
--
ALTER TABLE `modx_media_sources_contexts`
  ADD PRIMARY KEY (`source`,`context_key`);

--
-- Индексы таблицы `modx_media_sources_elements`
--
ALTER TABLE `modx_media_sources_elements`
  ADD PRIMARY KEY (`source`,`object`,`object_class`,`context_key`);

--
-- Индексы таблицы `modx_member_groups`
--
ALTER TABLE `modx_member_groups`
  ADD PRIMARY KEY (`id`), ADD KEY `role` (`role`), ADD KEY `rank` (`rank`);

--
-- Индексы таблицы `modx_membergroup_names`
--
ALTER TABLE `modx_membergroup_names`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `parent` (`parent`), ADD KEY `rank` (`rank`), ADD KEY `dashboard` (`dashboard`);

--
-- Индексы таблицы `modx_menus`
--
ALTER TABLE `modx_menus`
  ADD PRIMARY KEY (`text`), ADD KEY `parent` (`parent`), ADD KEY `action` (`action`), ADD KEY `namespace` (`namespace`);

--
-- Индексы таблицы `modx_namespaces`
--
ALTER TABLE `modx_namespaces`
  ADD PRIMARY KEY (`name`);

--
-- Индексы таблицы `modx_property_set`
--
ALTER TABLE `modx_property_set`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `category` (`category`);

--
-- Индексы таблицы `modx_register_messages`
--
ALTER TABLE `modx_register_messages`
  ADD PRIMARY KEY (`topic`,`id`), ADD KEY `created` (`created`), ADD KEY `valid` (`valid`), ADD KEY `accessed` (`accessed`), ADD KEY `accesses` (`accesses`), ADD KEY `expires` (`expires`);

--
-- Индексы таблицы `modx_register_queues`
--
ALTER TABLE `modx_register_queues`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`);

--
-- Индексы таблицы `modx_register_topics`
--
ALTER TABLE `modx_register_topics`
  ADD PRIMARY KEY (`id`), ADD KEY `queue` (`queue`), ADD KEY `name` (`name`);

--
-- Индексы таблицы `modx_session`
--
ALTER TABLE `modx_session`
  ADD PRIMARY KEY (`id`), ADD KEY `access` (`access`);

--
-- Индексы таблицы `modx_site_content`
--
ALTER TABLE `modx_site_content`
  ADD PRIMARY KEY (`id`), ADD KEY `alias` (`alias`), ADD KEY `published` (`published`), ADD KEY `pub_date` (`pub_date`), ADD KEY `unpub_date` (`unpub_date`), ADD KEY `parent` (`parent`), ADD KEY `isfolder` (`isfolder`), ADD KEY `template` (`template`), ADD KEY `menuindex` (`menuindex`), ADD KEY `searchable` (`searchable`), ADD KEY `cacheable` (`cacheable`), ADD KEY `hidemenu` (`hidemenu`), ADD KEY `class_key` (`class_key`), ADD KEY `context_key` (`context_key`), ADD KEY `uri` (`uri`(333)), ADD KEY `uri_override` (`uri_override`), ADD KEY `hide_children_in_tree` (`hide_children_in_tree`), ADD KEY `show_in_tree` (`show_in_tree`), ADD KEY `cache_refresh_idx` (`parent`,`menuindex`,`id`), ADD FULLTEXT KEY `content_ft_idx` (`pagetitle`,`longtitle`,`description`,`introtext`,`content`);

--
-- Индексы таблицы `modx_site_htmlsnippets`
--
ALTER TABLE `modx_site_htmlsnippets`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `category` (`category`), ADD KEY `locked` (`locked`), ADD KEY `static` (`static`);

--
-- Индексы таблицы `modx_site_plugin_events`
--
ALTER TABLE `modx_site_plugin_events`
  ADD PRIMARY KEY (`pluginid`,`event`), ADD KEY `priority` (`priority`);

--
-- Индексы таблицы `modx_site_plugins`
--
ALTER TABLE `modx_site_plugins`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `category` (`category`), ADD KEY `locked` (`locked`), ADD KEY `disabled` (`disabled`), ADD KEY `static` (`static`);

--
-- Индексы таблицы `modx_site_snippets`
--
ALTER TABLE `modx_site_snippets`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `category` (`category`), ADD KEY `locked` (`locked`), ADD KEY `moduleguid` (`moduleguid`), ADD KEY `static` (`static`);

--
-- Индексы таблицы `modx_site_templates`
--
ALTER TABLE `modx_site_templates`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `templatename` (`templatename`), ADD KEY `category` (`category`), ADD KEY `locked` (`locked`), ADD KEY `static` (`static`);

--
-- Индексы таблицы `modx_site_tmplvar_access`
--
ALTER TABLE `modx_site_tmplvar_access`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `modx_site_tmplvar_contentvalues`
--
ALTER TABLE `modx_site_tmplvar_contentvalues`
  ADD PRIMARY KEY (`id`), ADD KEY `tmplvarid` (`tmplvarid`), ADD KEY `contentid` (`contentid`), ADD KEY `tv_cnt` (`tmplvarid`,`contentid`);

--
-- Индексы таблицы `modx_site_tmplvar_templates`
--
ALTER TABLE `modx_site_tmplvar_templates`
  ADD PRIMARY KEY (`tmplvarid`,`templateid`);

--
-- Индексы таблицы `modx_site_tmplvars`
--
ALTER TABLE `modx_site_tmplvars`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `category` (`category`), ADD KEY `locked` (`locked`), ADD KEY `rank` (`rank`), ADD KEY `static` (`static`);

--
-- Индексы таблицы `modx_system_eventnames`
--
ALTER TABLE `modx_system_eventnames`
  ADD PRIMARY KEY (`name`);

--
-- Индексы таблицы `modx_system_settings`
--
ALTER TABLE `modx_system_settings`
  ADD PRIMARY KEY (`key`);

--
-- Индексы таблицы `modx_transport_packages`
--
ALTER TABLE `modx_transport_packages`
  ADD PRIMARY KEY (`signature`), ADD KEY `workspace` (`workspace`), ADD KEY `provider` (`provider`), ADD KEY `disabled` (`disabled`), ADD KEY `package_name` (`package_name`), ADD KEY `version_major` (`version_major`), ADD KEY `version_minor` (`version_minor`), ADD KEY `version_patch` (`version_patch`), ADD KEY `release` (`release`), ADD KEY `release_index` (`release_index`);

--
-- Индексы таблицы `modx_transport_providers`
--
ALTER TABLE `modx_transport_providers`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `api_key` (`api_key`), ADD KEY `username` (`username`);

--
-- Индексы таблицы `modx_user_attributes`
--
ALTER TABLE `modx_user_attributes`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `internalKey` (`internalKey`);

--
-- Индексы таблицы `modx_user_group_roles`
--
ALTER TABLE `modx_user_group_roles`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `name` (`name`), ADD KEY `authority` (`authority`);

--
-- Индексы таблицы `modx_user_group_settings`
--
ALTER TABLE `modx_user_group_settings`
  ADD PRIMARY KEY (`group`,`key`);

--
-- Индексы таблицы `modx_user_messages`
--
ALTER TABLE `modx_user_messages`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `modx_user_settings`
--
ALTER TABLE `modx_user_settings`
  ADD PRIMARY KEY (`user`,`key`);

--
-- Индексы таблицы `modx_users`
--
ALTER TABLE `modx_users`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `username` (`username`), ADD KEY `class_key` (`class_key`), ADD KEY `remote_key` (`remote_key`), ADD KEY `primary_group` (`primary_group`);

--
-- Индексы таблицы `modx_workspaces`
--
ALTER TABLE `modx_workspaces`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `path` (`path`), ADD KEY `name` (`name`), ADD KEY `active` (`active`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `modx_access_actiondom`
--
ALTER TABLE `modx_access_actiondom`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_access_actions`
--
ALTER TABLE `modx_access_actions`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_access_category`
--
ALTER TABLE `modx_access_category`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_access_context`
--
ALTER TABLE `modx_access_context`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `modx_access_elements`
--
ALTER TABLE `modx_access_elements`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_access_media_source`
--
ALTER TABLE `modx_access_media_source`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_access_menus`
--
ALTER TABLE `modx_access_menus`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_access_permissions`
--
ALTER TABLE `modx_access_permissions`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=215;
--
-- AUTO_INCREMENT для таблицы `modx_access_policies`
--
ALTER TABLE `modx_access_policies`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT для таблицы `modx_access_policy_template_groups`
--
ALTER TABLE `modx_access_policy_template_groups`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT для таблицы `modx_access_policy_templates`
--
ALTER TABLE `modx_access_policy_templates`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT для таблицы `modx_access_resource_groups`
--
ALTER TABLE `modx_access_resource_groups`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_access_resources`
--
ALTER TABLE `modx_access_resources`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_access_templatevars`
--
ALTER TABLE `modx_access_templatevars`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_actiondom`
--
ALTER TABLE `modx_actiondom`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_actions`
--
ALTER TABLE `modx_actions`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_actions_fields`
--
ALTER TABLE `modx_actions_fields`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=77;
--
-- AUTO_INCREMENT для таблицы `modx_categories`
--
ALTER TABLE `modx_categories`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_class_map`
--
ALTER TABLE `modx_class_map`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT для таблицы `modx_content_type`
--
ALTER TABLE `modx_content_type`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT для таблицы `modx_dashboard`
--
ALTER TABLE `modx_dashboard`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_dashboard_widget`
--
ALTER TABLE `modx_dashboard_widget`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT для таблицы `modx_document_groups`
--
ALTER TABLE `modx_document_groups`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_documentgroup_names`
--
ALTER TABLE `modx_documentgroup_names`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_extension_packages`
--
ALTER TABLE `modx_extension_packages`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_fc_profiles`
--
ALTER TABLE `modx_fc_profiles`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_fc_sets`
--
ALTER TABLE `modx_fc_sets`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_lexicon_entries`
--
ALTER TABLE `modx_lexicon_entries`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_manager_log`
--
ALTER TABLE `modx_manager_log`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=47;
--
-- AUTO_INCREMENT для таблицы `modx_media_sources`
--
ALTER TABLE `modx_media_sources`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_member_groups`
--
ALTER TABLE `modx_member_groups`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_membergroup_names`
--
ALTER TABLE `modx_membergroup_names`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_property_set`
--
ALTER TABLE `modx_property_set`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_register_queues`
--
ALTER TABLE `modx_register_queues`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_register_topics`
--
ALTER TABLE `modx_register_topics`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_site_content`
--
ALTER TABLE `modx_site_content`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `modx_site_htmlsnippets`
--
ALTER TABLE `modx_site_htmlsnippets`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_site_plugins`
--
ALTER TABLE `modx_site_plugins`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_site_snippets`
--
ALTER TABLE `modx_site_snippets`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_site_templates`
--
ALTER TABLE `modx_site_templates`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_site_tmplvar_access`
--
ALTER TABLE `modx_site_tmplvar_access`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_site_tmplvar_contentvalues`
--
ALTER TABLE `modx_site_tmplvar_contentvalues`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_site_tmplvars`
--
ALTER TABLE `modx_site_tmplvars`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_transport_providers`
--
ALTER TABLE `modx_transport_providers`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_user_attributes`
--
ALTER TABLE `modx_user_attributes`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_user_group_roles`
--
ALTER TABLE `modx_user_group_roles`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT для таблицы `modx_user_messages`
--
ALTER TABLE `modx_user_messages`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `modx_users`
--
ALTER TABLE `modx_users`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `modx_workspaces`
--
ALTER TABLE `modx_workspaces`
  MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;--
-- База данных: `opencart`
--

-- --------------------------------------------------------

--
-- Структура таблицы `address`
--

CREATE TABLE IF NOT EXISTS `address` (
  `address_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `firstname` varchar(32) NOT NULL DEFAULT '',
  `lastname` varchar(32) NOT NULL DEFAULT '',
  `company` varchar(32) NOT NULL,
  `company_id` varchar(32) NOT NULL,
  `tax_id` varchar(32) NOT NULL,
  `address_1` varchar(128) NOT NULL,
  `address_2` varchar(128) NOT NULL,
  `city` varchar(128) NOT NULL,
  `postcode` varchar(10) NOT NULL,
  `country_id` int(11) NOT NULL DEFAULT '0',
  `zone_id` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `affiliate`
--

CREATE TABLE IF NOT EXISTS `affiliate` (
  `affiliate_id` int(11) NOT NULL,
  `firstname` varchar(32) NOT NULL DEFAULT '',
  `lastname` varchar(32) NOT NULL DEFAULT '',
  `email` varchar(96) NOT NULL DEFAULT '',
  `telephone` varchar(32) NOT NULL DEFAULT '',
  `fax` varchar(32) NOT NULL DEFAULT '',
  `password` varchar(40) NOT NULL DEFAULT '',
  `salt` varchar(9) NOT NULL DEFAULT '',
  `company` varchar(32) NOT NULL,
  `website` varchar(255) NOT NULL,
  `address_1` varchar(128) NOT NULL DEFAULT '',
  `address_2` varchar(128) NOT NULL,
  `city` varchar(128) NOT NULL DEFAULT '',
  `postcode` varchar(10) NOT NULL DEFAULT '',
  `country_id` int(11) NOT NULL,
  `zone_id` int(11) NOT NULL,
  `code` varchar(64) NOT NULL,
  `commission` decimal(4,2) NOT NULL DEFAULT '0.00',
  `tax` varchar(64) NOT NULL,
  `payment` varchar(6) NOT NULL,
  `cheque` varchar(100) NOT NULL DEFAULT '',
  `paypal` varchar(64) NOT NULL DEFAULT '',
  `bank_name` varchar(64) NOT NULL DEFAULT '',
  `bank_branch_number` varchar(64) NOT NULL DEFAULT '',
  `bank_swift_code` varchar(64) NOT NULL DEFAULT '',
  `bank_account_name` varchar(64) NOT NULL DEFAULT '',
  `bank_account_number` varchar(64) NOT NULL DEFAULT '',
  `ip` varchar(40) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `approved` tinyint(1) NOT NULL,
  `date_added` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `affiliate_transaction`
--

CREATE TABLE IF NOT EXISTS `affiliate_transaction` (
  `affiliate_transaction_id` int(11) NOT NULL,
  `affiliate_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `description` text NOT NULL,
  `amount` decimal(15,4) NOT NULL,
  `date_added` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `attribute`
--

CREATE TABLE IF NOT EXISTS `attribute` (
  `attribute_id` int(11) NOT NULL,
  `attribute_group_id` int(11) NOT NULL,
  `sort_order` int(3) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `attribute`
--

INSERT INTO `attribute` (`attribute_id`, `attribute_group_id`, `sort_order`) VALUES
(1, 6, 1),
(2, 6, 5),
(3, 6, 3),
(4, 3, 1),
(5, 3, 2),
(6, 3, 3),
(7, 3, 4),
(8, 3, 5),
(9, 3, 6),
(10, 3, 7),
(11, 3, 8);

-- --------------------------------------------------------

--
-- Структура таблицы `attribute_description`
--

CREATE TABLE IF NOT EXISTS `attribute_description` (
  `attribute_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `attribute_description`
--

INSERT INTO `attribute_description` (`attribute_id`, `language_id`, `name`) VALUES
(1, 1, 'Description'),
(2, 1, 'No. of Cores'),
(4, 1, 'test 1'),
(5, 1, 'test 2'),
(6, 1, 'test 3'),
(7, 1, 'test 4'),
(8, 1, 'test 5'),
(9, 1, 'test 6'),
(10, 1, 'test 7'),
(11, 1, 'test 8'),
(3, 1, 'Clockspeed'),
(1, 2, 'Description'),
(2, 2, 'No. of Cores'),
(4, 2, 'test 1'),
(5, 2, 'test 2'),
(6, 2, 'test 3'),
(7, 2, 'test 4'),
(8, 2, 'test 5'),
(9, 2, 'test 6'),
(10, 2, 'test 7'),
(11, 2, 'test 8'),
(3, 2, 'Clockspeed');

-- --------------------------------------------------------

--
-- Структура таблицы `attribute_group`
--

CREATE TABLE IF NOT EXISTS `attribute_group` (
  `attribute_group_id` int(11) NOT NULL,
  `sort_order` int(3) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `attribute_group`
--

INSERT INTO `attribute_group` (`attribute_group_id`, `sort_order`) VALUES
(3, 2),
(4, 1),
(5, 3),
(6, 4);

-- --------------------------------------------------------

--
-- Структура таблицы `attribute_group_description`
--

CREATE TABLE IF NOT EXISTS `attribute_group_description` (
  `attribute_group_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `attribute_group_description`
--

INSERT INTO `attribute_group_description` (`attribute_group_id`, `language_id`, `name`) VALUES
(3, 1, 'Память'),
(4, 1, 'Technical'),
(5, 1, 'Материнская плата'),
(6, 1, 'Процессор'),
(3, 2, 'Memory'),
(4, 2, 'Technical'),
(5, 2, 'Motherboard'),
(6, 2, 'Processor');

-- --------------------------------------------------------

--
-- Структура таблицы `banner`
--

CREATE TABLE IF NOT EXISTS `banner` (
  `banner_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `banner`
--

INSERT INTO `banner` (`banner_id`, `name`, `status`) VALUES
(6, 'HP Products', 1),
(7, 'Samsung Tab', 1),
(8, 'Manufacturers', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `banner_image`
--

CREATE TABLE IF NOT EXISTS `banner_image` (
  `banner_image_id` int(11) NOT NULL,
  `banner_id` int(11) NOT NULL,
  `link` varchar(255) NOT NULL,
  `image` varchar(255) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=83 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `banner_image`
--

INSERT INTO `banner_image` (`banner_image_id`, `banner_id`, `link`, `image`) VALUES
(81, 7, '/index.php?route=product/product&amp;path=18&amp;product_id=46', 'data/demo/sony_vaio_3.jpg'),
(77, 6, 'index.php?route=product/manufacturer/info&amp;manufacturer_id=7', 'data/demo/hp_banner.jpg'),
(75, 8, 'index.php?route=product/manufacturer/info&amp;manufacturer_id=5', 'data/demo/htc_logo.jpg'),
(73, 8, 'index.php?route=product/manufacturer/info&amp;manufacturer_id=8', 'data/demo/apple_logo.jpg'),
(74, 8, 'index.php?route=product/manufacturer/info&amp;manufacturer_id=9', 'data/demo/canon_logo.jpg'),
(71, 8, 'index.php?route=product/manufacturer/info&amp;manufacturer_id=10', 'data/demo/sony_logo.jpg'),
(72, 8, 'index.php?route=product/manufacturer/info&amp;manufacturer_id=6', 'data/demo/palm_logo.jpg'),
(76, 8, 'index.php?route=product/manufacturer/info&amp;manufacturer_id=7', 'data/demo/hp_logo.jpg'),
(80, 7, 'index.php?route=product/product&amp;path=57&amp;product_id=49', 'data/demo/samsung_banner.jpg'),
(82, 7, '', 'data/demo/gift-voucher-birthday.jpg');

-- --------------------------------------------------------

--
-- Структура таблицы `banner_image_description`
--

CREATE TABLE IF NOT EXISTS `banner_image_description` (
  `banner_image_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `banner_id` int(11) NOT NULL,
  `title` varchar(64) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `banner_image_description`
--

INSERT INTO `banner_image_description` (`banner_image_id`, `language_id`, `banner_id`, `title`) VALUES
(81, 1, 7, 'Sony vaio'),
(77, 1, 6, 'HP Banner'),
(75, 1, 8, 'HTC'),
(74, 1, 8, 'Canon'),
(73, 1, 8, 'Apple'),
(72, 1, 8, 'Palm'),
(71, 1, 8, 'Sony'),
(76, 1, 8, 'Hewlett-Packard'),
(80, 2, 7, 'Samsung Tab 10.1'),
(77, 2, 6, 'HP Banner'),
(75, 2, 8, 'HTC'),
(74, 2, 8, 'Canon'),
(73, 2, 8, 'Apple'),
(72, 2, 8, 'Palm'),
(71, 2, 8, 'Sony'),
(76, 2, 8, 'Hewlett-Packard'),
(80, 1, 7, 'Samsung Tab 10.1'),
(81, 2, 7, 'Sony vaio'),
(82, 1, 7, 'Подарки'),
(82, 2, 7, 'Gifts');

-- --------------------------------------------------------

--
-- Структура таблицы `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `category_id` int(11) NOT NULL,
  `image` varchar(255) DEFAULT NULL,
  `parent_id` int(11) NOT NULL DEFAULT '0',
  `top` tinyint(1) NOT NULL,
  `column` int(3) NOT NULL,
  `sort_order` int(3) NOT NULL DEFAULT '0',
  `status` tinyint(1) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `date_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM AUTO_INCREMENT=59 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `category`
--

INSERT INTO `category` (`category_id`, `image`, `parent_id`, `top`, `column`, `sort_order`, `status`, `date_added`, `date_modified`) VALUES
(25, '', 0, 1, 1, 3, 1, '2009-01-31 01:04:25', '2011-05-30 12:14:55'),
(27, '', 20, 0, 0, 2, 1, '2009-01-31 01:55:34', '2010-08-22 06:32:15'),
(20, 'data/demo/compaq_presario.jpg', 0, 1, 1, 1, 1, '2009-01-05 21:49:43', '2011-07-16 02:14:42'),
(24, '', 0, 1, 1, 5, 1, '2009-01-20 02:36:26', '2011-05-30 12:15:18'),
(18, 'data/demo/hp_2.jpg', 0, 1, 0, 2, 1, '2009-01-05 21:49:15', '2011-05-30 12:13:55'),
(17, '', 0, 1, 1, 4, 1, '2009-01-03 21:08:57', '2011-05-30 12:15:11'),
(28, '', 25, 0, 0, 1, 1, '2009-02-02 13:11:12', '2010-08-22 06:32:46'),
(26, '', 20, 0, 0, 1, 1, '2009-01-31 01:55:14', '2010-08-22 06:31:45'),
(29, '', 25, 0, 0, 1, 1, '2009-02-02 13:11:37', '2010-08-22 06:32:39'),
(30, '', 25, 0, 0, 1, 1, '2009-02-02 13:11:59', '2010-08-22 06:33:00'),
(31, '', 25, 0, 0, 1, 1, '2009-02-03 14:17:24', '2010-08-22 06:33:06'),
(32, '', 25, 0, 0, 1, 1, '2009-02-03 14:17:34', '2010-08-22 06:33:12'),
(33, '', 0, 1, 1, 6, 1, '2009-02-03 14:17:55', '2011-05-30 12:15:25'),
(34, 'data/demo/ipod_touch_4.jpg', 0, 1, 4, 7, 1, '2009-02-03 14:18:11', '2011-05-30 12:15:31'),
(35, '', 28, 0, 0, 0, 1, '2010-09-17 10:06:48', '2010-09-18 14:02:42'),
(36, '', 28, 0, 0, 0, 1, '2010-09-17 10:07:13', '2010-09-18 14:02:55'),
(37, '', 34, 0, 0, 0, 1, '2010-09-18 14:03:39', '2011-04-22 01:55:08'),
(38, '', 34, 0, 0, 0, 1, '2010-09-18 14:03:51', '2010-09-18 14:03:51'),
(39, '', 34, 0, 0, 0, 1, '2010-09-18 14:04:17', '2011-04-22 01:55:20'),
(40, '', 34, 0, 0, 0, 1, '2010-09-18 14:05:36', '2010-09-18 14:05:36'),
(41, '', 34, 0, 0, 0, 1, '2010-09-18 14:05:49', '2011-04-22 01:55:30'),
(42, '', 34, 0, 0, 0, 1, '2010-09-18 14:06:34', '2010-11-07 20:31:04'),
(43, '', 34, 0, 0, 0, 1, '2010-09-18 14:06:49', '2011-04-22 01:55:40'),
(44, '', 34, 0, 0, 0, 1, '2010-09-21 15:39:21', '2010-11-07 20:30:55'),
(45, '', 18, 0, 0, 0, 1, '2010-09-24 18:29:16', '2011-04-26 08:52:11'),
(46, '', 18, 0, 0, 0, 1, '2010-09-24 18:29:31', '2011-04-26 08:52:23'),
(47, '', 34, 0, 0, 0, 1, '2010-11-07 11:13:16', '2010-11-07 11:13:16'),
(48, '', 34, 0, 0, 0, 1, '2010-11-07 11:13:33', '2010-11-07 11:13:33'),
(49, '', 34, 0, 0, 0, 1, '2010-11-07 11:14:04', '2010-11-07 11:14:04'),
(50, '', 34, 0, 0, 0, 1, '2010-11-07 11:14:23', '2011-04-22 01:16:01'),
(51, '', 34, 0, 0, 0, 1, '2010-11-07 11:14:38', '2011-04-22 01:16:13'),
(52, '', 34, 0, 0, 0, 1, '2010-11-07 11:16:09', '2011-04-22 01:54:57'),
(53, '', 34, 0, 0, 0, 1, '2010-11-07 11:28:53', '2011-04-22 01:14:36'),
(54, '', 34, 0, 0, 0, 1, '2010-11-07 11:29:16', '2011-04-22 01:16:50'),
(55, '', 34, 0, 0, 0, 1, '2010-11-08 10:31:32', '2010-11-08 10:31:32'),
(56, '', 34, 0, 0, 0, 1, '2010-11-08 10:31:50', '2011-04-22 01:16:37'),
(57, '', 0, 1, 1, 3, 1, '2011-04-26 08:53:16', '2011-05-30 12:15:05'),
(58, '', 52, 0, 0, 0, 1, '2011-05-08 13:44:16', '2011-05-08 13:44:16');

-- --------------------------------------------------------

--
-- Структура таблицы `category_description`
--

CREATE TABLE IF NOT EXISTS `category_description` (
  `category_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `description` text NOT NULL,
  `meta_description` varchar(255) NOT NULL,
  `meta_keyword` varchar(255) NOT NULL,
  `seo_title` varchar(255) NOT NULL,
  `seo_h1` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `category_description`
--

INSERT INTO `category_description` (`category_id`, `language_id`, `name`, `description`, `meta_description`, `meta_keyword`, `seo_title`, `seo_h1`) VALUES
(28, 1, 'Мониторы', '', '', '', '', ''),
(33, 1, 'Камеры', '', '', '', '', ''),
(32, 1, 'Веб-камеры', '', '', '', '', ''),
(31, 1, 'Сканеры', '', '', '', '', ''),
(30, 1, 'Принтеры', '', '', '', '', ''),
(29, 1, 'Мышки', '', '', '', '', ''),
(27, 1, 'Mac', '', '', '', '', ''),
(26, 1, 'PC', '', '', '', '', ''),
(17, 1, 'Програмное обеспечение', '', '', '', '', ''),
(25, 1, 'Компоненты', '', '', '', '', ''),
(24, 1, 'Телефоны и PDA', '', '', '', '', ''),
(20, 1, 'Компьютеры', '&lt;p&gt;\r\n	Пример текста в описания категории&lt;/p&gt;\r\n', 'Пример описания категории', '', '', ''),
(35, 1, 'test 1', '', '', '', '', ''),
(36, 1, 'test 2', '', '', '', '', ''),
(37, 1, 'test 5', '', '', '', '', ''),
(38, 1, 'test 4', '', '', '', '', ''),
(39, 1, 'test 6', '', '', '', '', ''),
(40, 1, 'test 7', '', '', '', '', ''),
(41, 1, 'test 8', '', '', '', '', ''),
(42, 1, 'test 9', '', '', '', '', ''),
(43, 1, 'test 11', '', '', '', '', ''),
(34, 1, 'MP3 Плееры', '&lt;p&gt;\r\n	Shop Laptop feature only the best laptop deals on the market. By comparing laptop deals from the likes of PC World, Comet, Dixons, The Link and Carphone Warehouse, Shop Laptop has the most comprehensive selection of laptops on the internet. At Shop Laptop, we pride ourselves on offering customers the very best laptop deals. From refurbished laptops to netbooks, Shop Laptop ensures that every laptop - in every colour, style, size and technical spec - is featured on the site at the lowest possible price.&lt;/p&gt;\r\n', '', '', '', ''),
(18, 1, 'Ноутбуки', '&lt;p&gt;\r\n	Shop Laptop feature only the best laptop deals on the market. By comparing laptop deals from the likes of PC World, Comet, Dixons, The Link and Carphone Warehouse, Shop Laptop has the most comprehensive selection of laptops on the internet. At Shop Laptop, we pride ourselves on offering customers the very best laptop deals. From refurbished laptops to netbooks, Shop Laptop ensures that every laptop - in every colour, style, size and technical spec - is featured on the site at the lowest possible price.&lt;/p&gt;\r\n', '', '', '', ''),
(44, 1, 'test 12', '', '', '', '', ''),
(45, 1, 'Windows', '', '', '', '', ''),
(46, 1, 'Macs', '', '', '', '', ''),
(47, 1, 'test 15', '', '', '', '', ''),
(48, 1, 'test 16', '', '', '', '', ''),
(49, 1, 'test 17', '', '', '', '', ''),
(50, 1, 'test 18', '', '', '', '', ''),
(51, 1, 'test 19', '', '', '', '', ''),
(52, 1, 'test 20', '', '', '', '', ''),
(53, 1, 'test 21', '', '', '', '', ''),
(54, 1, 'test 22', '', '', '', '', ''),
(55, 1, 'test 23', '', '', '', '', ''),
(56, 1, 'test 24', '', '', '', '', ''),
(57, 1, 'Планшеты', '', '', '', '', ''),
(58, 1, 'test 25', '', '', '', '', ''),
(28, 2, 'Monitors', '', '', '', '', ''),
(33, 2, 'Cameras', '', '', '', '', ''),
(32, 2, 'Web Cameras', '', '', '', '', ''),
(31, 2, 'Scanners', '', '', '', '', ''),
(30, 2, 'Printers', '', '', '', '', ''),
(29, 2, 'Mice and Trackballs', '', '', '', '', ''),
(27, 2, 'Mac', '', '', '', '', ''),
(26, 2, 'PC', '', '', '', '', ''),
(17, 2, 'Software', '', '', '', '', ''),
(25, 2, 'Components', '', '', '', '', ''),
(24, 2, 'Phones &amp; PDAs', '', '', '', '', ''),
(20, 2, 'Desktops', '&lt;p&gt;\r\n	Example of category description text&lt;/p&gt;\r\n', 'Example of category description', '', '', ''),
(35, 2, 'test 1', '', '', '', '', ''),
(36, 2, 'test 2', '', '', '', '', ''),
(37, 2, 'test 5', '', '', '', '', ''),
(38, 2, 'test 4', '', '', '', '', ''),
(39, 2, 'test 6', '', '', '', '', ''),
(40, 2, 'test 7', '', '', '', '', ''),
(41, 2, 'test 8', '', '', '', '', ''),
(42, 2, 'test 9', '', '', '', '', ''),
(43, 2, 'test 11', '', '', '', '', ''),
(34, 2, 'MP3 Players', '&lt;p&gt;\r\n	Shop Laptop feature only the best laptop deals on the market. By comparing laptop deals from the likes of PC World, Comet, Dixons, The Link and Carphone Warehouse, Shop Laptop has the most comprehensive selection of laptops on the internet. At Shop Laptop, we pride ourselves on offering customers the very best laptop deals. From refurbished laptops to netbooks, Shop Laptop ensures that every laptop - in every colour, style, size and technical spec - is featured on the site at the lowest possible price.&lt;/p&gt;\r\n', '', '', '', ''),
(18, 2, 'Laptops &amp; Notebooks', '&lt;p&gt;\r\n	Shop Laptop feature only the best laptop deals on the market. By comparing laptop deals from the likes of PC World, Comet, Dixons, The Link and Carphone Warehouse, Shop Laptop has the most comprehensive selection of laptops on the internet. At Shop Laptop, we pride ourselves on offering customers the very best laptop deals. From refurbished laptops to netbooks, Shop Laptop ensures that every laptop - in every colour, style, size and technical spec - is featured on the site at the lowest possible price.&lt;/p&gt;\r\n', '', '', '', ''),
(44, 2, 'test 12', '', '', '', '', ''),
(45, 2, 'Windows', '', '', '', '', ''),
(46, 2, 'Macs', '', '', '', '', ''),
(47, 2, 'test 15', '', '', '', '', ''),
(48, 2, 'test 16', '', '', '', '', ''),
(49, 2, 'test 17', '', '', '', '', ''),
(50, 2, 'test 18', '', '', '', '', ''),
(51, 2, 'test 19', '', '', '', '', ''),
(52, 2, 'test 20', '', '', '', '', ''),
(53, 2, 'test 21', '', '', '', '', ''),
(54, 2, 'test 22', '', '', '', '', ''),
(55, 2, 'test 23', '', '', '', '', ''),
(56, 2, 'test 24', '', '', '', '', ''),
(57, 2, 'Tablets', '', '', '', '', ''),
(58, 2, 'test 25', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Структура таблицы `category_to_layout`
--

CREATE TABLE IF NOT EXISTS `category_to_layout` (
  `category_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL,
  `layout_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `category_to_store`
--

CREATE TABLE IF NOT EXISTS `category_to_store` (
  `category_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `category_to_store`
--

INSERT INTO `category_to_store` (`category_id`, `store_id`) VALUES
(17, 0),
(18, 0),
(20, 0),
(24, 0),
(25, 0),
(26, 0),
(27, 0),
(28, 0),
(29, 0),
(30, 0),
(31, 0),
(32, 0),
(33, 0),
(34, 0),
(35, 0),
(36, 0),
(37, 0),
(38, 0),
(39, 0),
(40, 0),
(41, 0),
(42, 0),
(43, 0),
(44, 0),
(45, 0),
(46, 0),
(47, 0),
(48, 0),
(49, 0),
(50, 0),
(51, 0),
(52, 0),
(53, 0),
(54, 0),
(55, 0),
(56, 0),
(57, 0),
(58, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `country`
--

CREATE TABLE IF NOT EXISTS `country` (
  `country_id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `iso_code_2` varchar(2) NOT NULL DEFAULT '',
  `iso_code_3` varchar(3) NOT NULL DEFAULT '',
  `address_format` text NOT NULL,
  `postcode_required` tinyint(1) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=MyISAM AUTO_INCREMENT=240 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `country`
--

INSERT INTO `country` (`country_id`, `name`, `iso_code_2`, `iso_code_3`, `address_format`, `postcode_required`, `status`) VALUES
(1, 'Афганистан', 'AF', 'AFG', '', 0, 1),
(2, 'Албания', 'AL', 'ALB', '', 0, 1),
(3, 'Алжир', 'DZ', 'DZA', '', 0, 1),
(4, 'Восточное Самоа', 'AS', 'ASM', '', 0, 1),
(5, 'Андорра', 'AD', 'AND', '', 0, 1),
(6, 'Ангола', 'AO', 'AGO', '', 0, 1),
(7, 'Ангилья', 'AI', 'AIA', '', 0, 1),
(8, 'Антарктида', 'AQ', 'ATA', '', 0, 1),
(9, 'Антигуа и Барбуда', 'AG', 'ATG', '', 0, 1),
(10, 'Аргентина', 'AR', 'ARG', '', 0, 1),
(11, 'Армения', 'AM', 'ARM', '', 0, 1),
(12, 'Аруба', 'AW', 'ABW', '', 0, 1),
(13, 'Австралия', 'AU', 'AUS', '', 0, 1),
(14, 'Австрия', 'AT', 'AUT', '', 0, 1),
(15, 'Азербайджан', 'AZ', 'AZE', '', 0, 1),
(16, 'Багамские острова', 'BS', 'BHS', '', 0, 1),
(17, 'Бахрейн', 'BH', 'BHR', '', 0, 1),
(18, 'Бангладеш', 'BD', 'BGD', '', 0, 1),
(19, 'Барбадос', 'BB', 'BRB', '', 0, 1),
(20, 'Белоруссия (Беларусь)', 'BY', 'BLR', '', 0, 1),
(21, 'Бельгия', 'BE', 'BEL', '', 0, 1),
(22, 'Белиз', 'BZ', 'BLZ', '', 0, 1),
(23, 'Бенин', 'BJ', 'BEN', '', 0, 1),
(24, 'Бермудские острова', 'BM', 'BMU', '', 0, 1),
(25, 'Бутан', 'BT', 'BTN', '', 0, 1),
(26, 'Боливия', 'BO', 'BOL', '', 0, 1),
(27, 'Босния и Герцеговина', 'BA', 'BIH', '', 0, 1),
(28, 'Ботсвана', 'BW', 'BWA', '', 0, 1),
(29, 'Остров Буве', 'BV', 'BVT', '', 0, 1),
(30, 'Бразилия', 'BR', 'BRA', '', 0, 1),
(31, 'Британская территория в Индийском океане', 'IO', 'IOT', '', 0, 1),
(32, 'Бруней', 'BN', 'BRN', '', 0, 1),
(33, 'Болгария', 'BG', 'BGR', '', 0, 1),
(34, 'Буркина-Фасо', 'BF', 'BFA', '', 0, 1),
(35, 'Бурунди', 'BI', 'BDI', '', 0, 1),
(36, 'Камбоджа', 'KH', 'KHM', '', 0, 1),
(37, 'Камерун', 'CM', 'CMR', '', 0, 1),
(38, 'Канада', 'CA', 'CAN', '', 0, 1),
(39, 'Кабо-Верде', 'CV', 'CPV', '', 0, 1),
(40, 'Каймановы острова', 'KY', 'CYM', '', 0, 1),
(41, 'Центрально-Африканская Республика', 'CF', 'CAF', '', 0, 1),
(42, 'Чад', 'TD', 'TCD', '', 0, 1),
(43, 'Чили', 'CL', 'CHL', '', 0, 1),
(44, 'Китайская Народная Республика', 'CN', 'CHN', '', 0, 1),
(45, 'Остров Рождества', 'CX', 'CXR', '', 0, 1),
(46, 'Кокосовые острова', 'CC', 'CCK', '', 0, 1),
(47, 'Колумбия', 'CO', 'COL', '', 0, 1),
(48, 'Коморские острова', 'KM', 'COM', '', 0, 1),
(49, 'Конго', 'CG', 'COG', '', 0, 1),
(50, 'Острова Кука', 'CK', 'COK', '', 0, 1),
(51, 'Коста-Рика', 'CR', 'CRI', '', 0, 1),
(52, 'Кот д''Ивуар', 'CI', 'CIV', '', 0, 1),
(53, 'Хорватия', 'HR', 'HRV', '', 0, 1),
(54, 'Куба', 'CU', 'CUB', '', 0, 1),
(55, 'Кипр', 'CY', 'CYP', '', 0, 1),
(56, 'Чехия', 'CZ', 'CZE', '', 0, 1),
(57, 'Дания', 'DK', 'DNK', '', 0, 1),
(58, 'Джибути', 'DJ', 'DJI', '', 0, 1),
(59, 'Доминика', 'DM', 'DMA', '', 0, 1),
(60, 'Доминиканская Республика', 'DO', 'DOM', '', 0, 1),
(61, 'Восточный Тимор', 'TP', 'TMP', '', 0, 1),
(62, 'Эквадор', 'EC', 'ECU', '', 0, 1),
(63, 'Египет', 'EG', 'EGY', '', 0, 1),
(64, 'Сальвадор', 'SV', 'SLV', '', 0, 1),
(65, 'Экваториальная Гвинея', 'GQ', 'GNQ', '', 0, 1),
(66, 'Эритрея', 'ER', 'ERI', '', 0, 1),
(67, 'Эстония', 'EE', 'EST', '', 0, 1),
(68, 'Эфиопия', 'ET', 'ETH', '', 0, 1),
(69, 'Фолклендские (Мальвинские) острова', 'FK', 'FLK', '', 0, 1),
(70, 'Фарерские острова', 'FO', 'FRO', '', 0, 1),
(71, 'Фиджи', 'FJ', 'FJI', '', 0, 1),
(72, 'Финляндия', 'FI', 'FIN', '', 0, 1),
(73, 'Франция', 'FR', 'FRA', '', 0, 1),
(74, 'Франция, Метрополия', 'FX', 'FXX', '', 0, 1),
(75, 'Французская Гвиана', 'GF', 'GUF', '', 0, 1),
(76, 'Французская Полинезия', 'PF', 'PYF', '', 0, 1),
(77, 'Французские Южные территории', 'TF', 'ATF', '', 0, 1),
(78, 'Габон', 'GA', 'GAB', '', 0, 1),
(79, 'Гамбия', 'GM', 'GMB', '', 0, 1),
(80, 'Грузия', 'GE', 'GEO', '', 0, 1),
(81, 'Германия', 'DE', 'DEU', '{company}\r\n{firstname} {lastname}\r\n{address_1}\r\n{address_2}\r\n{postcode} {city}\r\n{country}', 0, 1),
(82, 'Гана', 'GH', 'GHA', '', 0, 1),
(83, 'Гибралтар', 'GI', 'GIB', '', 0, 1),
(84, 'Греция', 'GR', 'GRC', '', 0, 1),
(85, 'Гренландия', 'GL', 'GRL', '', 0, 1),
(86, 'Гренада', 'GD', 'GRD', '', 0, 1),
(87, 'Гваделупа', 'GP', 'GLP', '', 0, 1),
(88, 'Гуам', 'GU', 'GUM', '', 0, 1),
(89, 'Гватемала', 'GT', 'GTM', '', 0, 1),
(90, 'Гвинея', 'GN', 'GIN', '', 0, 1),
(91, 'Гвинея-Бисау', 'GW', 'GNB', '', 0, 1),
(92, 'Гайана', 'GY', 'GUY', '', 0, 1),
(93, 'Гаити', 'HT', 'HTI', '', 0, 1),
(94, 'Херд и Макдональд, острова', 'HM', 'HMD', '', 0, 1),
(95, 'Гондурас', 'HN', 'HND', '', 0, 1),
(96, 'Гонконг', 'HK', 'HKG', '', 0, 1),
(97, 'Венгрия', 'HU', 'HUN', '', 0, 1),
(98, 'Исландия', 'IS', 'ISL', '', 0, 1),
(99, 'Индия', 'IN', 'IND', '', 0, 1),
(100, 'Индонезия', 'ID', 'IDN', '', 0, 1),
(101, 'Иран', 'IR', 'IRN', '', 0, 1),
(102, 'Ирак', 'IQ', 'IRQ', '', 0, 1),
(103, 'Ирландия', 'IE', 'IRL', '', 0, 1),
(104, 'Израиль', 'IL', 'ISR', '', 0, 1),
(105, 'Италия', 'IT', 'ITA', '', 0, 1),
(106, 'Ямайка', 'JM', 'JAM', '', 0, 1),
(107, 'Япония', 'JP', 'JPN', '', 0, 1),
(108, 'Иордания', 'JO', 'JOR', '', 0, 1),
(109, 'Казахстан', 'KZ', 'KAZ', '', 0, 1),
(110, 'Кения', 'KE', 'KEN', '', 0, 1),
(111, 'Кирибати', 'KI', 'KIR', '', 0, 1),
(112, 'Корейская Народно-Демократическая Республика', 'KP', 'PRK', '', 0, 1),
(113, 'Республика Корея', 'KR', 'KOR', '', 0, 1),
(114, 'Кувейт', 'KW', 'KWT', '', 0, 1),
(115, 'Киргизия (Кыргызстан)', 'KG', 'KGZ', '', 0, 1),
(116, 'Лаос', 'LA', 'LAO', '', 0, 1),
(117, 'Латвия', 'LV', 'LVA', '', 0, 1),
(118, 'Ливан', 'LB', 'LBN', '', 0, 1),
(119, 'Лесото', 'LS', 'LSO', '', 0, 1),
(120, 'Либерия', 'LR', 'LBR', '', 0, 1),
(121, 'Ливия', 'LY', 'LBY', '', 0, 1),
(122, 'Лихтенштейн', 'LI', 'LIE', '', 0, 1),
(123, 'Литва', 'LT', 'LTU', '', 0, 1),
(124, 'Люксембург', 'LU', 'LUX', '', 0, 1),
(125, 'Макао', 'MO', 'MAC', '', 0, 1),
(126, 'Македония', 'MK', 'MKD', '', 0, 1),
(127, 'Мадагаскар', 'MG', 'MDG', '', 0, 1),
(128, 'Малави', 'MW', 'MWI', '', 0, 1),
(129, 'Малайзия', 'MY', 'MYS', '', 0, 1),
(130, 'Мальдивы', 'MV', 'MDV', '', 0, 1),
(131, 'Мали', 'ML', 'MLI', '', 0, 1),
(132, 'Мальта', 'MT', 'MLT', '', 0, 1),
(133, 'Маршалловы острова', 'MH', 'MHL', '', 0, 1),
(134, 'Мартиника', 'MQ', 'MTQ', '', 0, 1),
(135, 'Мавритания', 'MR', 'MRT', '', 0, 1),
(136, 'Маврикий', 'MU', 'MUS', '', 0, 1),
(137, 'Майотта', 'YT', 'MYT', '', 0, 1),
(138, 'Мексика', 'MX', 'MEX', '', 0, 1),
(139, 'Микронезия', 'FM', 'FSM', '', 0, 1),
(140, 'Молдова', 'MD', 'MDA', '', 0, 1),
(141, 'Монако', 'MC', 'MCO', '', 0, 1),
(142, 'Монголия', 'MN', 'MNG', '', 0, 1),
(143, 'Монтсеррат', 'MS', 'MSR', '', 0, 1),
(144, 'Марокко', 'MA', 'MAR', '', 0, 1),
(145, 'Мозамбик', 'MZ', 'MOZ', '', 0, 1),
(146, 'Мьянма', 'MM', 'MMR', '', 0, 1),
(147, 'Намибия', 'NA', 'NAM', '', 0, 1),
(148, 'Науру', 'NR', 'NRU', '', 0, 1),
(149, 'Непал', 'NP', 'NPL', '', 0, 1),
(150, 'Нидерланды', 'NL', 'NLD', '', 0, 1),
(151, 'Антильские (Нидерландские) острова', 'AN', 'ANT', '', 0, 1),
(152, 'Новая Каледония', 'NC', 'NCL', '', 0, 1),
(153, 'Новая Зеландия', 'NZ', 'NZL', '', 0, 1),
(154, 'Никарагуа', 'NI', 'NIC', '', 0, 1),
(155, 'Нигер', 'NE', 'NER', '', 0, 1),
(156, 'Нигерия', 'NG', 'NGA', '', 0, 1),
(157, 'Ниуэ', 'NU', 'NIU', '', 0, 1),
(158, 'Остров Норфолк', 'NF', 'NFK', '', 0, 1),
(159, 'Северные Марианские острова', 'MP', 'MNP', '', 0, 1),
(160, 'Норвегия', 'NO', 'NOR', '', 0, 1),
(161, 'Оман', 'OM', 'OMN', '', 0, 1),
(162, 'Пакистан', 'PK', 'PAK', '', 0, 1),
(163, 'Палау', 'PW', 'PLW', '', 0, 1),
(164, 'Панама', 'PA', 'PAN', '', 0, 1),
(165, 'Папуа - Новая Гвинея', 'PG', 'PNG', '', 0, 1),
(166, 'Парагвай', 'PY', 'PRY', '', 0, 1),
(167, 'Перу', 'PE', 'PER', '', 0, 1),
(168, 'Филиппины', 'PH', 'PHL', '', 0, 1),
(169, 'Острова Питкэрн', 'PN', 'PCN', '', 0, 1),
(170, 'Польша', 'PL', 'POL', '', 0, 1),
(171, 'Португалия', 'PT', 'PRT', '', 0, 1),
(172, 'Пуэрто-Рико', 'PR', 'PRI', '', 0, 1),
(173, 'Катар', 'QA', 'QAT', '', 0, 1),
(174, 'Реюньон', 'RE', 'REU', '', 0, 1),
(175, 'Румыния', 'RO', 'ROM', '', 0, 1),
(176, 'Российская Федерация', 'RU', 'RUS', '', 0, 1),
(177, 'Руанда', 'RW', 'RWA', '', 0, 1),
(178, 'Сент-Китс и Невис', 'KN', 'KNA', '', 0, 1),
(179, 'Сент-Люсия', 'LC', 'LCA', '', 0, 1),
(180, 'Сент-Винсент и Гренадины', 'VC', 'VCT', '', 0, 1),
(181, 'Западное Самоа', 'WS', 'WSM', '', 0, 1),
(182, 'Сан-Марино', 'SM', 'SMR', '', 0, 1),
(183, 'Сан-Томе и Принсипи', 'ST', 'STP', '', 0, 1),
(184, 'Саудовская Аравия', 'SA', 'SAU', '', 0, 1),
(185, 'Сенегал', 'SN', 'SEN', '', 0, 1),
(186, 'Сейшельские острова', 'SC', 'SYC', '', 0, 1),
(187, 'Сьерра-Леоне', 'SL', 'SLE', '', 0, 1),
(188, 'Сингапур', 'SG', 'SGP', '', 0, 1),
(189, 'Словакия', 'SK', 'SVK', '{firstname} {lastname}\r\n{company}\r\n{address_1}\r\n{address_2}\r\n{city} {postcode}\r\n{zone}\r\n{country}', 0, 1),
(190, 'Словения', 'SI', 'SVN', '', 0, 1),
(191, 'Соломоновы острова', 'SB', 'SLB', '', 0, 1),
(192, 'Сомали', 'SO', 'SOM', '', 0, 1),
(193, 'Южно-Африканская Республика', 'ZA', 'ZAF', '', 0, 1),
(194, 'Южная Джорджия и Южные Сандвичевы острова', 'GS', 'SGS', '', 0, 1),
(195, 'Испания', 'ES', 'ESP', '', 0, 1),
(196, 'Шри-Ланка', 'LK', 'LKA', '', 0, 1),
(197, 'Остров Святой Елены', 'SH', 'SHN', '', 0, 1),
(198, 'Сен-Пьер и Микелон', 'PM', 'SPM', '', 0, 1),
(199, 'Судан', 'SD', 'SDN', '', 0, 1),
(200, 'Суринам', 'SR', 'SUR', '', 0, 1),
(201, 'Шпицберген и Ян Майен', 'SJ', 'SJM', '', 0, 1),
(202, 'Свазиленд', 'SZ', 'SWZ', '', 0, 1),
(203, 'Швеция', 'SE', 'SWE', '', 0, 1),
(204, 'Швейцария', 'CH', 'CHE', '', 0, 1),
(205, 'Сирия', 'SY', 'SYR', '', 0, 1),
(206, 'Тайвань (провинция Китая)', 'TW', 'TWN', '', 0, 1),
(207, 'Таджикистан', 'TJ', 'TJK', '', 0, 1),
(208, 'Танзания', 'TZ', 'TZA', '', 0, 1),
(209, 'Таиланд', 'TH', 'THA', '', 0, 1),
(210, 'Того', 'TG', 'TGO', '', 0, 1),
(211, 'Токелау', 'TK', 'TKL', '', 0, 1),
(212, 'Тонга', 'TO', 'TON', '', 0, 1),
(213, 'Тринидад и Тобаго', 'TT', 'TTO', '', 0, 1),
(214, 'Тунис', 'TN', 'TUN', '', 0, 1),
(215, 'Турция', 'TR', 'TUR', '', 0, 1),
(216, 'Туркменистан', 'TM', 'TKM', '', 0, 1),
(217, 'Острова Теркс и Кайкос', 'TC', 'TCA', '', 0, 1),
(218, 'Тувалу', 'TV', 'TUV', '', 0, 1),
(219, 'Уганда', 'UG', 'UGA', '', 0, 1),
(220, 'Украина', 'UA', 'UKR', '', 0, 1),
(221, 'Объединенные Арабские Эмираты', 'AE', 'ARE', '', 0, 1),
(222, 'Великобритания', 'GB', 'GBR', '', 1, 1),
(223, 'Соединенные Штаты Америки', 'US', 'USA', '{firstname} {lastname}\r\n{company}\r\n{address_1}\r\n{address_2}\r\n{city}, {zone} {postcode}\r\n{country}', 0, 1),
(224, 'Мелкие отдаленные острова США', 'UM', 'UMI', '', 0, 1),
(225, 'Уругвай', 'UY', 'URY', '', 0, 1),
(226, 'Узбекистан', 'UZ', 'UZB', '', 0, 1),
(227, 'Вануату', 'VU', 'VUT', '', 0, 1),
(228, 'Ватикан', 'VA', 'VAT', '', 0, 1),
(229, 'Венесуэла', 'VE', 'VEN', '', 0, 1),
(230, 'Вьетнам', 'VN', 'VNM', '', 0, 1),
(231, 'Виргинские острова (Британские)', 'VG', 'VGB', '', 0, 1),
(232, 'Виргинские острова (США)', 'VI', 'VIR', '', 0, 1),
(233, 'Уоллис и Футуна', 'WF', 'WLF', '', 0, 1),
(234, 'Западная Сахара', 'EH', 'ESH', '', 0, 1),
(235, 'Йемен', 'YE', 'YEM', '', 0, 1),
(236, 'Сербия и Черногория', 'CS', 'SCG', '', 0, 1),
(237, 'Заир', 'ZR', 'ZAR', '', 0, 1),
(238, 'Замбия', 'ZM', 'ZMB', '', 0, 1),
(239, 'Зимбабве', 'ZW', 'ZWE', '', 0, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `coupon`
--

CREATE TABLE IF NOT EXISTS `coupon` (
  `coupon_id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `code` varchar(10) NOT NULL,
  `type` char(1) NOT NULL,
  `discount` decimal(15,4) NOT NULL,
  `logged` tinyint(1) NOT NULL,
  `shipping` tinyint(1) NOT NULL,
  `total` decimal(15,4) NOT NULL,
  `date_start` date NOT NULL DEFAULT '0000-00-00',
  `date_end` date NOT NULL DEFAULT '0000-00-00',
  `uses_total` int(11) NOT NULL,
  `uses_customer` varchar(11) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `coupon`
--

INSERT INTO `coupon` (`coupon_id`, `name`, `code`, `type`, `discount`, `logged`, `shipping`, `total`, `date_start`, `date_end`, `uses_total`, `uses_customer`, `status`, `date_added`) VALUES
(4, '-10% скидка', '2222', 'P', '10.0000', 0, 0, '0.0000', '2011-01-01', '2012-01-01', 10, '10', 1, '2009-01-27 13:55:03'),
(5, 'Бесплатная доставка', '3333', 'P', '0.0000', 0, 1, '100.0000', '2009-03-01', '2009-08-31', 10, '10', 1, '2009-03-14 21:13:53'),
(6, '-10.00 скидка', '1111', 'F', '10.0000', 0, 0, '10.0000', '1970-11-01', '2020-11-01', 100000, '10000', 1, '2009-03-14 21:15:18');

-- --------------------------------------------------------

--
-- Структура таблицы `coupon_history`
--

CREATE TABLE IF NOT EXISTS `coupon_history` (
  `coupon_history_id` int(11) NOT NULL,
  `coupon_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `amount` decimal(15,4) NOT NULL,
  `date_added` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `coupon_product`
--

CREATE TABLE IF NOT EXISTS `coupon_product` (
  `coupon_product_id` int(11) NOT NULL,
  `coupon_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `currency`
--

CREATE TABLE IF NOT EXISTS `currency` (
  `currency_id` int(11) NOT NULL,
  `title` varchar(32) NOT NULL DEFAULT '',
  `code` varchar(3) NOT NULL DEFAULT '',
  `symbol_left` varchar(12) NOT NULL,
  `symbol_right` varchar(12) NOT NULL,
  `decimal_place` char(1) NOT NULL,
  `value` float(15,8) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `date_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `currency`
--

INSERT INTO `currency` (`currency_id`, `title`, `code`, `symbol_left`, `symbol_right`, `decimal_place`, `value`, `status`, `date_modified`) VALUES
(1, 'Рубль', 'RUB', '', ' р.', '2', 1.00000000, 1, '2015-08-05 22:25:57'),
(2, 'US Dollar', 'USD', '$', '', '2', 0.01570000, 1, '2015-08-05 19:31:03'),
(3, 'Euro', 'EUR', '', '€', '2', 0.01440000, 1, '2015-08-05 19:31:03');

-- --------------------------------------------------------

--
-- Структура таблицы `customer`
--

CREATE TABLE IF NOT EXISTS `customer` (
  `customer_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL DEFAULT '0',
  `firstname` varchar(32) NOT NULL DEFAULT '',
  `lastname` varchar(32) NOT NULL DEFAULT '',
  `email` varchar(96) NOT NULL DEFAULT '',
  `telephone` varchar(32) NOT NULL DEFAULT '',
  `fax` varchar(32) NOT NULL DEFAULT '',
  `password` varchar(40) NOT NULL DEFAULT '',
  `salt` varchar(9) NOT NULL DEFAULT '',
  `cart` text,
  `wishlist` text,
  `newsletter` tinyint(1) NOT NULL DEFAULT '0',
  `address_id` int(11) NOT NULL DEFAULT '0',
  `customer_group_id` int(11) NOT NULL,
  `ip` varchar(40) NOT NULL DEFAULT '0',
  `status` tinyint(1) NOT NULL,
  `approved` tinyint(1) NOT NULL,
  `token` varchar(255) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `customer_group`
--

CREATE TABLE IF NOT EXISTS `customer_group` (
  `customer_group_id` int(11) NOT NULL,
  `approval` int(1) NOT NULL,
  `company_id_display` int(1) NOT NULL,
  `company_id_required` int(1) NOT NULL,
  `tax_id_display` int(1) NOT NULL,
  `tax_id_required` int(1) NOT NULL,
  `sort_order` int(3) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `customer_group`
--

INSERT INTO `customer_group` (`customer_group_id`, `approval`, `company_id_display`, `company_id_required`, `tax_id_display`, `tax_id_required`, `sort_order`) VALUES
(1, 0, 1, 0, 0, 1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `customer_group_description`
--

CREATE TABLE IF NOT EXISTS `customer_group_description` (
  `customer_group_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `description` text NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `customer_group_description`
--

INSERT INTO `customer_group_description` (`customer_group_id`, `language_id`, `name`, `description`) VALUES
(1, 1, 'Default', 'test');

-- --------------------------------------------------------

--
-- Структура таблицы `customer_ip`
--

CREATE TABLE IF NOT EXISTS `customer_ip` (
  `customer_ip_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `ip` varchar(40) NOT NULL,
  `date_added` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `customer_ip_blacklist`
--

CREATE TABLE IF NOT EXISTS `customer_ip_blacklist` (
  `customer_ip_blacklist_id` int(11) NOT NULL,
  `ip` varchar(40) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `customer_online`
--

CREATE TABLE IF NOT EXISTS `customer_online` (
  `ip` varchar(40) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `url` text NOT NULL,
  `referer` text NOT NULL,
  `date_added` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `customer_reward`
--

CREATE TABLE IF NOT EXISTS `customer_reward` (
  `customer_reward_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL DEFAULT '0',
  `order_id` int(11) NOT NULL DEFAULT '0',
  `description` text NOT NULL,
  `points` int(8) NOT NULL DEFAULT '0',
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `customer_transaction`
--

CREATE TABLE IF NOT EXISTS `customer_transaction` (
  `customer_transaction_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `description` text NOT NULL,
  `amount` decimal(15,4) NOT NULL,
  `date_added` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `download`
--

CREATE TABLE IF NOT EXISTS `download` (
  `download_id` int(11) NOT NULL,
  `filename` varchar(128) NOT NULL DEFAULT '',
  `mask` varchar(128) NOT NULL DEFAULT '',
  `remaining` int(11) NOT NULL DEFAULT '0',
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `download_description`
--

CREATE TABLE IF NOT EXISTS `download_description` (
  `download_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `extension`
--

CREATE TABLE IF NOT EXISTS `extension` (
  `extension_id` int(11) NOT NULL,
  `type` varchar(32) NOT NULL,
  `code` varchar(32) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=428 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `extension`
--

INSERT INTO `extension` (`extension_id`, `type`, `code`) VALUES
(23, 'payment', 'cod'),
(22, 'total', 'shipping'),
(57, 'total', 'sub_total'),
(58, 'total', 'tax'),
(59, 'total', 'total'),
(410, 'module', 'banner'),
(426, 'module', 'carousel'),
(390, 'total', 'credit'),
(387, 'shipping', 'flat'),
(349, 'total', 'handling'),
(350, 'total', 'low_order_fee'),
(389, 'total', 'coupon'),
(413, 'module', 'category'),
(411, 'module', 'affiliate'),
(408, 'module', 'account'),
(393, 'total', 'reward'),
(398, 'total', 'voucher'),
(407, 'payment', 'free_checkout'),
(427, 'module', 'featured'),
(419, 'module', 'slideshow');

-- --------------------------------------------------------

--
-- Структура таблицы `geo_zone`
--

CREATE TABLE IF NOT EXISTS `geo_zone` (
  `geo_zone_id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `date_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `geo_zone`
--

INSERT INTO `geo_zone` (`geo_zone_id`, `name`, `description`, `date_modified`, `date_added`) VALUES
(3, 'НДС', 'Облагаемые НДС', '2010-02-26 22:33:24', '2009-01-06 23:26:25');

-- --------------------------------------------------------

--
-- Структура таблицы `information`
--

CREATE TABLE IF NOT EXISTS `information` (
  `information_id` int(11) NOT NULL,
  `bottom` int(1) NOT NULL DEFAULT '0',
  `sort_order` int(3) NOT NULL DEFAULT '0',
  `status` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `information`
--

INSERT INTO `information` (`information_id`, `bottom`, `sort_order`, `status`) VALUES
(3, 1, 3, 1),
(4, 1, 1, 1),
(5, 1, 4, 1),
(6, 1, 2, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `information_description`
--

CREATE TABLE IF NOT EXISTS `information_description` (
  `information_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `title` varchar(64) NOT NULL DEFAULT '',
  `description` text NOT NULL,
  `meta_description` varchar(255) NOT NULL,
  `meta_keyword` varchar(255) NOT NULL,
  `seo_title` varchar(255) NOT NULL,
  `seo_h1` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `information_description`
--

INSERT INTO `information_description` (`information_id`, `language_id`, `title`, `description`, `meta_description`, `meta_keyword`, `seo_title`, `seo_h1`) VALUES
(5, 1, 'Условия соглашения', '&lt;p&gt;\r\n	Условия соглашения&lt;/p&gt;\r\n', '', '', '', ''),
(3, 1, 'Политика Безопасности', '&lt;p&gt;\r\n	Политика Безопасности&lt;/p&gt;\r\n', '', '', '', ''),
(6, 1, 'Информация о доставке', '&lt;p&gt;\r\n	Информация о доставке&lt;/p&gt;\r\n', '', '', '', ''),
(5, 2, 'Terms &amp; Conditions', '&lt;p&gt;\r\n	Terms &amp;amp; Conditions&lt;/p&gt;\r\n', '', '', '', ''),
(3, 2, 'Privacy Policy', '&lt;p&gt;\r\n	Privacy Policy&lt;/p&gt;\r\n', '', '', '', ''),
(6, 2, 'Delivery Information', '&lt;p&gt;\r\n	Delivery Information&lt;/p&gt;\r\n', '', '', '', ''),
(4, 2, 'About Us', '&lt;p&gt;\r\n	About Us&lt;/p&gt;\r\n', '', '', '', ''),
(4, 1, 'О нас', '&lt;p&gt;\r\n	О нас&lt;/p&gt;\r\n&lt;p&gt;Наш адрес:&lt;br /&gt;\r\nг. Тамбов. ул. Максима Горького, д. 17/129.&lt;/p&gt;\r\n&lt;div&gt;\r\n&lt;script type=&quot;text/javascript&quot; charset=&quot;utf-8&quot; src=&quot;https://api-maps.yandex.ru/services/constructor/1.0/js/?sid=twGFxT5U7-LfZZHE8SrqyBrUNKABTeju&amp;width=600&amp;height=450&quot;&gt;&lt;/script&gt;\r\n&lt;/div&gt;', '', '', '', '');

-- --------------------------------------------------------

--
-- Структура таблицы `information_to_layout`
--

CREATE TABLE IF NOT EXISTS `information_to_layout` (
  `information_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL,
  `layout_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `information_to_store`
--

CREATE TABLE IF NOT EXISTS `information_to_store` (
  `information_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `information_to_store`
--

INSERT INTO `information_to_store` (`information_id`, `store_id`) VALUES
(3, 0),
(4, 0),
(5, 0),
(6, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `language`
--

CREATE TABLE IF NOT EXISTS `language` (
  `language_id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL DEFAULT '',
  `code` varchar(5) NOT NULL,
  `locale` varchar(255) NOT NULL,
  `image` varchar(64) NOT NULL,
  `directory` varchar(32) NOT NULL DEFAULT '',
  `filename` varchar(64) NOT NULL DEFAULT '',
  `sort_order` int(3) NOT NULL DEFAULT '0',
  `status` tinyint(1) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `language`
--

INSERT INTO `language` (`language_id`, `name`, `code`, `locale`, `image`, `directory`, `filename`, `sort_order`, `status`) VALUES
(1, 'Russian', 'ru', 'ru_RU.UTF-8,ru_RU,russian', 'ru.png', 'russian', 'russian', 1, 1),
(2, 'English', 'en', 'en_US.UTF-8,en_US,en-gb,english', 'gb.png', 'english', 'english', 2, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `layout`
--

CREATE TABLE IF NOT EXISTS `layout` (
  `layout_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `layout`
--

INSERT INTO `layout` (`layout_id`, `name`) VALUES
(1, 'Home'),
(2, 'Product'),
(3, 'Category'),
(4, 'Default'),
(5, 'Manufacturer'),
(6, 'Account'),
(7, 'Checkout'),
(8, 'Contact'),
(9, 'Sitemap'),
(10, 'Affiliate'),
(11, 'Information');

-- --------------------------------------------------------

--
-- Структура таблицы `layout_route`
--

CREATE TABLE IF NOT EXISTS `layout_route` (
  `layout_route_id` int(11) NOT NULL,
  `layout_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL,
  `route` varchar(255) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `layout_route`
--

INSERT INTO `layout_route` (`layout_route_id`, `layout_id`, `store_id`, `route`) VALUES
(30, 6, 0, 'account'),
(17, 10, 0, 'affiliate/'),
(29, 3, 0, 'product/category'),
(26, 1, 0, 'common/home'),
(20, 2, 0, 'product/product'),
(24, 11, 0, 'information/information'),
(22, 5, 0, 'product/manufacturer'),
(23, 7, 0, 'checkout/'),
(31, 8, 0, 'information/contact');

-- --------------------------------------------------------

--
-- Структура таблицы `length_class`
--

CREATE TABLE IF NOT EXISTS `length_class` (
  `length_class_id` int(11) NOT NULL,
  `value` decimal(15,8) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `length_class`
--

INSERT INTO `length_class` (`length_class_id`, `value`) VALUES
(1, '1.00000000'),
(2, '10.00000000');

-- --------------------------------------------------------

--
-- Структура таблицы `length_class_description`
--

CREATE TABLE IF NOT EXISTS `length_class_description` (
  `length_class_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `title` varchar(32) NOT NULL,
  `unit` varchar(4) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `length_class_description`
--

INSERT INTO `length_class_description` (`length_class_id`, `language_id`, `title`, `unit`) VALUES
(1, 1, 'Сантиметр', 'см'),
(2, 1, 'Миллиметр', 'мм'),
(1, 2, 'Centimeter', 'cm'),
(2, 2, 'Millimeter', 'mm');

-- --------------------------------------------------------

--
-- Структура таблицы `manufacturer`
--

CREATE TABLE IF NOT EXISTS `manufacturer` (
  `manufacturer_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL DEFAULT '',
  `image` varchar(255) DEFAULT NULL,
  `sort_order` int(3) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `manufacturer`
--

INSERT INTO `manufacturer` (`manufacturer_id`, `name`, `image`, `sort_order`) VALUES
(5, 'HTC', 'data/demo/htc_logo.jpg', 0),
(6, 'Palm', 'data/demo/palm_logo.jpg', 0),
(7, 'Hewlett-Packard', 'data/demo/hp_logo.jpg', 0),
(8, 'Apple', 'data/demo/apple_logo.jpg', 0),
(9, 'Canon', 'data/demo/canon_logo.jpg', 0),
(10, 'Sony', 'data/demo/sony_logo.jpg', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `manufacturer_description`
--

CREATE TABLE IF NOT EXISTS `manufacturer_description` (
  `manufacturer_id` int(11) NOT NULL DEFAULT '0',
  `language_id` int(11) NOT NULL DEFAULT '0',
  `description` text NOT NULL,
  `meta_description` varchar(255) NOT NULL,
  `meta_keyword` varchar(255) NOT NULL,
  `seo_title` varchar(255) NOT NULL,
  `seo_h1` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `manufacturer_description`
--

INSERT INTO `manufacturer_description` (`manufacturer_id`, `language_id`, `description`, `meta_description`, `meta_keyword`, `seo_title`, `seo_h1`) VALUES
(5, 1, '', '', '', '', ''),
(6, 1, '', '', '', '', ''),
(7, 1, '', '', '', '', ''),
(8, 1, '', '', '', '', ''),
(9, 1, '', '', '', '', ''),
(10, 1, '', '', '', '', ''),
(5, 2, '', '', '', '', ''),
(6, 2, '', '', '', '', ''),
(7, 2, '', '', '', '', ''),
(8, 2, '', '', '', '', ''),
(9, 2, '', '', '', '', ''),
(10, 2, '', '', '', '', '');

-- --------------------------------------------------------

--
-- Структура таблицы `manufacturer_to_store`
--

CREATE TABLE IF NOT EXISTS `manufacturer_to_store` (
  `manufacturer_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `manufacturer_to_store`
--

INSERT INTO `manufacturer_to_store` (`manufacturer_id`, `store_id`) VALUES
(5, 0),
(6, 0),
(7, 0),
(8, 0),
(9, 0),
(10, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `option`
--

CREATE TABLE IF NOT EXISTS `option` (
  `option_id` int(11) NOT NULL,
  `type` varchar(32) NOT NULL,
  `sort_order` int(3) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `option`
--

INSERT INTO `option` (`option_id`, `type`, `sort_order`) VALUES
(1, 'radio', 2),
(2, 'checkbox', 3),
(4, 'text', 4),
(5, 'select', 1),
(6, 'textarea', 5),
(7, 'file', 6),
(8, 'date', 7),
(9, 'time', 8),
(10, 'datetime', 9),
(11, 'select', 1),
(12, 'date', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `option_description`
--

CREATE TABLE IF NOT EXISTS `option_description` (
  `option_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `option_description`
--

INSERT INTO `option_description` (`option_id`, `language_id`, `name`) VALUES
(1, 1, 'Radio'),
(2, 1, 'Checkbox'),
(4, 1, 'Text'),
(6, 1, 'Textarea'),
(8, 1, 'Date'),
(7, 1, 'File'),
(5, 1, 'Select'),
(9, 1, 'Time'),
(10, 1, 'Date &amp; Time'),
(12, 1, 'Delivery Date'),
(11, 1, 'Size'),
(1, 2, 'Radio'),
(2, 2, 'Checkbox'),
(4, 2, 'Text'),
(6, 2, 'Textarea'),
(8, 2, 'Date'),
(7, 2, 'File'),
(5, 2, 'Select'),
(9, 2, 'Time'),
(10, 2, 'Date &amp; Time'),
(12, 2, 'Delivery Date'),
(11, 2, 'Size');

-- --------------------------------------------------------

--
-- Структура таблицы `option_value`
--

CREATE TABLE IF NOT EXISTS `option_value` (
  `option_value_id` int(11) NOT NULL,
  `option_id` int(11) NOT NULL,
  `image` varchar(255) NOT NULL,
  `sort_order` int(3) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `option_value`
--

INSERT INTO `option_value` (`option_value_id`, `option_id`, `image`, `sort_order`) VALUES
(43, 1, '', 3),
(32, 1, '', 1),
(45, 2, '', 4),
(44, 2, '', 3),
(42, 5, '', 4),
(41, 5, '', 3),
(39, 5, '', 1),
(40, 5, '', 2),
(31, 1, '', 2),
(23, 2, '', 1),
(24, 2, '', 2),
(46, 11, '', 1),
(47, 11, '', 2),
(48, 11, '', 3);

-- --------------------------------------------------------

--
-- Структура таблицы `option_value_description`
--

CREATE TABLE IF NOT EXISTS `option_value_description` (
  `option_value_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `option_id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `option_value_description`
--

INSERT INTO `option_value_description` (`option_value_id`, `language_id`, `option_id`, `name`) VALUES
(43, 1, 1, 'Large'),
(32, 1, 1, 'Small'),
(45, 1, 2, 'Checkbox 4'),
(44, 1, 2, 'Checkbox 3'),
(31, 1, 1, 'Medium'),
(42, 1, 5, 'Yellow'),
(41, 1, 5, 'Green'),
(39, 1, 5, 'Red'),
(40, 1, 5, 'Blue'),
(23, 1, 2, 'Checkbox 1'),
(24, 1, 2, 'Checkbox 2'),
(48, 1, 11, 'Large'),
(47, 1, 11, 'Medium'),
(46, 1, 11, 'Small'),
(43, 2, 1, 'Large'),
(32, 2, 1, 'Small'),
(45, 2, 2, 'Checkbox 4'),
(44, 2, 2, 'Checkbox 3'),
(31, 2, 1, 'Medium'),
(42, 2, 5, 'Yellow'),
(41, 2, 5, 'Green'),
(39, 2, 5, 'Red'),
(40, 2, 5, 'Blue'),
(23, 2, 2, 'Checkbox 1'),
(24, 2, 2, 'Checkbox 2'),
(48, 2, 11, 'Large'),
(47, 2, 11, 'Medium'),
(46, 2, 11, 'Small');

-- --------------------------------------------------------

--
-- Структура таблицы `order`
--

CREATE TABLE IF NOT EXISTS `order` (
  `order_id` int(11) NOT NULL,
  `invoice_no` int(11) NOT NULL DEFAULT '0',
  `invoice_prefix` varchar(26) NOT NULL,
  `store_id` int(11) NOT NULL DEFAULT '0',
  `store_name` varchar(64) NOT NULL,
  `store_url` varchar(255) NOT NULL,
  `customer_id` int(11) NOT NULL DEFAULT '0',
  `customer_group_id` int(11) NOT NULL DEFAULT '0',
  `firstname` varchar(32) NOT NULL DEFAULT '',
  `lastname` varchar(32) NOT NULL,
  `email` varchar(96) NOT NULL,
  `telephone` varchar(32) NOT NULL DEFAULT '',
  `fax` varchar(32) NOT NULL DEFAULT '',
  `payment_firstname` varchar(32) NOT NULL DEFAULT '',
  `payment_lastname` varchar(32) NOT NULL DEFAULT '',
  `payment_company` varchar(32) NOT NULL,
  `payment_company_id` varchar(32) NOT NULL,
  `payment_tax_id` varchar(32) NOT NULL,
  `payment_address_1` varchar(128) NOT NULL,
  `payment_address_2` varchar(128) NOT NULL,
  `payment_city` varchar(128) NOT NULL,
  `payment_postcode` varchar(10) NOT NULL DEFAULT '',
  `payment_country` varchar(128) NOT NULL,
  `payment_country_id` int(11) NOT NULL,
  `payment_zone` varchar(128) NOT NULL,
  `payment_zone_id` int(11) NOT NULL,
  `payment_address_format` text NOT NULL,
  `payment_method` varchar(128) NOT NULL DEFAULT '',
  `payment_code` varchar(128) NOT NULL,
  `shipping_firstname` varchar(32) NOT NULL,
  `shipping_lastname` varchar(32) NOT NULL DEFAULT '',
  `shipping_company` varchar(32) NOT NULL,
  `shipping_address_1` varchar(128) NOT NULL,
  `shipping_address_2` varchar(128) NOT NULL,
  `shipping_city` varchar(128) NOT NULL,
  `shipping_postcode` varchar(10) NOT NULL DEFAULT '',
  `shipping_country` varchar(128) NOT NULL,
  `shipping_country_id` int(11) NOT NULL,
  `shipping_zone` varchar(128) NOT NULL,
  `shipping_zone_id` int(11) NOT NULL,
  `shipping_address_format` text NOT NULL,
  `shipping_method` varchar(128) NOT NULL DEFAULT '',
  `shipping_code` varchar(128) NOT NULL,
  `comment` text NOT NULL,
  `total` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `order_status_id` int(11) NOT NULL DEFAULT '0',
  `affiliate_id` int(11) NOT NULL,
  `commission` decimal(15,4) NOT NULL,
  `language_id` int(11) NOT NULL,
  `currency_id` int(11) NOT NULL,
  `currency_code` varchar(3) NOT NULL,
  `currency_value` decimal(15,8) NOT NULL DEFAULT '1.00000000',
  `ip` varchar(40) NOT NULL,
  `forwarded_ip` varchar(40) NOT NULL,
  `user_agent` varchar(255) NOT NULL,
  `accept_language` varchar(255) NOT NULL,
  `date_added` datetime NOT NULL,
  `date_modified` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `order_download`
--

CREATE TABLE IF NOT EXISTS `order_download` (
  `order_download_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `order_product_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL DEFAULT '',
  `filename` varchar(128) NOT NULL DEFAULT '',
  `mask` varchar(128) NOT NULL DEFAULT '',
  `remaining` int(3) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `order_fraud`
--

CREATE TABLE IF NOT EXISTS `order_fraud` (
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `country_match` varchar(3) NOT NULL,
  `country_code` varchar(2) NOT NULL,
  `high_risk_country` varchar(3) NOT NULL,
  `distance` int(11) NOT NULL,
  `ip_region` varchar(255) NOT NULL,
  `ip_city` varchar(255) NOT NULL,
  `ip_latitude` decimal(10,6) NOT NULL,
  `ip_longitude` decimal(10,6) NOT NULL,
  `ip_isp` varchar(255) NOT NULL,
  `ip_org` varchar(255) NOT NULL,
  `ip_asnum` int(11) NOT NULL,
  `ip_user_type` varchar(255) NOT NULL,
  `ip_country_confidence` varchar(3) NOT NULL,
  `ip_region_confidence` varchar(3) NOT NULL,
  `ip_city_confidence` varchar(3) NOT NULL,
  `ip_postal_confidence` varchar(3) NOT NULL,
  `ip_postal_code` varchar(10) NOT NULL,
  `ip_accuracy_radius` int(11) NOT NULL,
  `ip_net_speed_cell` varchar(255) NOT NULL,
  `ip_metro_code` int(3) NOT NULL,
  `ip_area_code` int(3) NOT NULL,
  `ip_time_zone` varchar(255) NOT NULL,
  `ip_region_name` varchar(255) NOT NULL,
  `ip_domain` varchar(255) NOT NULL,
  `ip_country_name` varchar(255) NOT NULL,
  `ip_continent_code` varchar(2) NOT NULL,
  `ip_corporate_proxy` varchar(3) NOT NULL,
  `anonymous_proxy` varchar(3) NOT NULL,
  `proxy_score` int(3) NOT NULL,
  `is_trans_proxy` varchar(3) NOT NULL,
  `free_mail` varchar(3) NOT NULL,
  `carder_email` varchar(3) NOT NULL,
  `high_risk_username` varchar(3) NOT NULL,
  `high_risk_password` varchar(3) NOT NULL,
  `bin_match` varchar(10) NOT NULL,
  `bin_country` varchar(2) NOT NULL,
  `bin_name_match` varchar(3) NOT NULL,
  `bin_name` varchar(255) NOT NULL,
  `bin_phone_match` varchar(3) NOT NULL,
  `bin_phone` varchar(32) NOT NULL,
  `customer_phone_in_billing_location` varchar(8) NOT NULL,
  `ship_forward` varchar(3) NOT NULL,
  `city_postal_match` varchar(3) NOT NULL,
  `ship_city_postal_match` varchar(3) NOT NULL,
  `score` decimal(10,5) NOT NULL,
  `explanation` text NOT NULL,
  `risk_score` decimal(10,5) NOT NULL,
  `queries_remaining` int(11) NOT NULL,
  `maxmind_id` varchar(8) NOT NULL,
  `error` text NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `order_history`
--

CREATE TABLE IF NOT EXISTS `order_history` (
  `order_history_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `order_status_id` int(5) NOT NULL,
  `notify` tinyint(1) NOT NULL DEFAULT '0',
  `comment` text NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `order_option`
--

CREATE TABLE IF NOT EXISTS `order_option` (
  `order_option_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `order_product_id` int(11) NOT NULL,
  `product_option_id` int(11) NOT NULL,
  `product_option_value_id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(255) NOT NULL,
  `value` text NOT NULL,
  `type` varchar(32) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `order_product`
--

CREATE TABLE IF NOT EXISTS `order_product` (
  `order_product_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `model` varchar(64) NOT NULL,
  `quantity` int(4) NOT NULL,
  `price` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `total` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `tax` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `reward` int(8) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `order_status`
--

CREATE TABLE IF NOT EXISTS `order_status` (
  `order_status_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `order_status`
--

INSERT INTO `order_status` (`order_status_id`, `language_id`, `name`) VALUES
(2, 1, 'В обработке'),
(3, 1, 'Доставлено'),
(7, 1, 'Отменено'),
(5, 1, 'Сделка завершена'),
(8, 1, 'Возврат'),
(9, 1, 'Отмена и аннулирование'),
(10, 1, 'Неудавшийся'),
(11, 1, 'Возмещенный'),
(12, 1, 'Полностью измененный'),
(13, 1, 'Полный возврат'),
(1, 1, 'Ожидание'),
(16, 1, 'Voided'),
(15, 1, 'Processed'),
(14, 1, 'Expired'),
(2, 2, 'Processing'),
(3, 2, 'Shipped'),
(7, 2, 'Canceled'),
(5, 2, 'Complete'),
(8, 2, 'Denied'),
(9, 2, 'Canceled Reversal'),
(10, 2, 'Failed'),
(11, 2, 'Refunded'),
(12, 2, 'Reversed'),
(13, 2, 'Chargeback'),
(1, 2, 'Pending'),
(16, 2, 'Voided'),
(15, 2, 'Processed'),
(14, 2, 'Expired');

-- --------------------------------------------------------

--
-- Структура таблицы `order_total`
--

CREATE TABLE IF NOT EXISTS `order_total` (
  `order_total_id` int(10) NOT NULL,
  `order_id` int(11) NOT NULL,
  `code` varchar(32) NOT NULL,
  `title` varchar(255) NOT NULL DEFAULT '',
  `text` varchar(255) NOT NULL DEFAULT '',
  `value` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `sort_order` int(3) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `order_voucher`
--

CREATE TABLE IF NOT EXISTS `order_voucher` (
  `order_voucher_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `voucher_id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  `code` varchar(10) NOT NULL,
  `from_name` varchar(64) NOT NULL,
  `from_email` varchar(96) NOT NULL,
  `to_name` varchar(64) NOT NULL,
  `to_email` varchar(96) NOT NULL,
  `voucher_theme_id` int(11) NOT NULL,
  `message` text NOT NULL,
  `amount` decimal(15,4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `product`
--

CREATE TABLE IF NOT EXISTS `product` (
  `product_id` int(11) NOT NULL,
  `model` varchar(64) NOT NULL,
  `sku` varchar(64) NOT NULL,
  `upc` varchar(12) NOT NULL,
  `ean` varchar(14) NOT NULL,
  `jan` varchar(13) NOT NULL,
  `isbn` varchar(13) NOT NULL,
  `mpn` varchar(64) NOT NULL,
  `location` varchar(128) NOT NULL,
  `quantity` int(4) NOT NULL DEFAULT '0',
  `stock_status_id` int(11) NOT NULL,
  `image` varchar(255) DEFAULT NULL,
  `manufacturer_id` int(11) NOT NULL,
  `shipping` tinyint(1) NOT NULL DEFAULT '1',
  `price` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `points` int(8) NOT NULL DEFAULT '0',
  `tax_class_id` int(11) NOT NULL,
  `date_available` date NOT NULL,
  `weight` decimal(15,8) NOT NULL DEFAULT '0.00000000',
  `weight_class_id` int(11) NOT NULL DEFAULT '0',
  `length` decimal(15,8) NOT NULL DEFAULT '0.00000000',
  `width` decimal(15,8) NOT NULL DEFAULT '0.00000000',
  `height` decimal(15,8) NOT NULL DEFAULT '0.00000000',
  `length_class_id` int(11) NOT NULL DEFAULT '0',
  `subtract` tinyint(1) NOT NULL DEFAULT '1',
  `minimum` int(11) NOT NULL DEFAULT '1',
  `sort_order` int(11) NOT NULL DEFAULT '0',
  `status` tinyint(1) NOT NULL DEFAULT '0',
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `date_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `viewed` int(5) NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=65 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product`
--

INSERT INTO `product` (`product_id`, `model`, `sku`, `upc`, `ean`, `jan`, `isbn`, `mpn`, `location`, `quantity`, `stock_status_id`, `image`, `manufacturer_id`, `shipping`, `price`, `points`, `tax_class_id`, `date_available`, `weight`, `weight_class_id`, `length`, `width`, `height`, `length_class_id`, `subtract`, `minimum`, `sort_order`, `status`, `date_added`, `date_modified`, `viewed`) VALUES
(28, 'Товар 1', '', '', '', '', '', '', '', 939, 7, 'data/demo/htc_touch_hd_1.jpg', 5, 1, '100.0000', 200, 9, '2009-02-03', '146.40000000', 2, '0.00000000', '0.00000000', '0.00000000', 1, 1, 1, 0, 1, '2009-02-03 16:06:50', '2011-09-30 01:05:39', 0),
(29, 'Товар 2', '', '', '', '', '', '', '', 999, 6, 'data/demo/palm_treo_pro_1.jpg', 6, 1, '279.9900', 0, 9, '2009-02-03', '133.00000000', 2, '0.00000000', '0.00000000', '0.00000000', 3, 1, 1, 0, 1, '2009-02-03 16:42:17', '2011-09-30 01:06:08', 0),
(30, 'Товар 3', '', '', '', '', '', '', '', 7, 6, 'data/demo/canon_eos_5d_1.jpg', 9, 1, '100.0000', 0, 9, '2009-02-03', '0.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 1, 1, 1, 0, 1, '2009-02-03 16:59:00', '2011-09-30 01:05:23', 0),
(31, 'Товар 4', '', '', '', '', '', '', '', 1000, 6, 'data/demo/nikon_d300_1.jpg', 0, 1, '80.0000', 0, 9, '2009-02-03', '0.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 3, 1, 1, 0, 1, '2009-02-03 17:00:10', '2011-09-30 01:06:00', 0),
(32, 'Товар 5', '', '', '', '', '', '', '', 999, 6, 'data/demo/ipod_touch_1.jpg', 8, 1, '100.0000', 0, 9, '2009-02-03', '5.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 1, 1, 1, 0, 1, '2009-02-03 17:07:26', '2011-09-30 01:07:22', 0),
(33, 'Товар 6', '', '', '', '', '', '', '', 1000, 6, 'data/demo/samsung_syncmaster_941bw.jpg', 0, 1, '200.0000', 0, 9, '2009-02-03', '5.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 2, 1, 1, 0, 1, '2009-02-03 17:08:31', '2011-09-30 01:06:29', 1),
(34, 'Товар 7', '', '', '', '', '', '', '', 1000, 6, 'data/demo/ipod_shuffle_1.jpg', 8, 1, '100.0000', 0, 9, '2009-02-03', '5.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 2, 1, 1, 0, 1, '2009-02-03 18:07:54', '2011-09-30 01:07:17', 0),
(35, 'Товар 8', '', '', '', '', '', '', '', 1000, 5, '', 0, 0, '100.0000', 0, 9, '2009-02-03', '5.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 1, 1, 1, 0, 1, '2009-02-03 18:08:31', '2011-09-30 01:06:17', 0),
(36, 'Товар 9', '', '', '', '', '', '', '', 994, 6, 'data/demo/ipod_nano_1.jpg', 8, 0, '100.0000', 100, 9, '2009-02-03', '5.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 2, 1, 1, 0, 1, '2009-02-03 18:09:19', '2011-09-30 01:07:12', 0),
(40, 'Товар 11', '', '', '', '', '', '', '', 970, 5, 'data/demo/iphone_1.jpg', 8, 1, '101.0000', 0, 9, '2009-02-03', '10.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 1, 1, 1, 0, 1, '2009-02-03 21:07:12', '2011-09-30 01:06:53', 0),
(41, 'Товар 14', '', '', '', '', '', '', '', 977, 5, 'data/demo/imac_1.jpg', 8, 1, '100.0000', 0, 9, '2009-02-03', '5.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 1, 1, 1, 0, 1, '2009-02-03 21:07:26', '2011-09-30 01:06:44', 6),
(42, 'Товар 15', '', '', '', '', '', '', '', 990, 5, 'data/demo/apple_cinema_30.jpg', 8, 1, '100.0000', 400, 9, '2009-02-04', '12.50000000', 1, '1.00000000', '2.00000000', '3.00000000', 1, 1, 2, 0, 1, '2009-02-03 21:07:37', '2011-09-30 00:46:19', 4),
(43, 'Товар 16', '', '', '', '', '', '', '', 929, 5, 'data/demo/macbook_1.jpg', 8, 0, '500.0000', 0, 9, '2009-02-03', '0.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 2, 1, 1, 0, 1, '2009-02-03 21:07:49', '2011-09-30 01:05:46', 5),
(44, 'Товар 17', '', '', '', '', '', '', '', 1000, 5, 'data/demo/macbook_air_1.jpg', 8, 1, '1000.0000', 0, 9, '2009-02-03', '0.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 2, 1, 1, 0, 1, '2009-02-03 21:08:00', '2011-09-30 01:05:53', 0),
(45, 'Товар 18', '', '', '', '', '', '', '', 998, 5, 'data/demo/macbook_pro_1.jpg', 8, 1, '2000.0000', 0, 100, '2009-02-03', '0.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 2, 1, 1, 0, 1, '2009-02-03 21:08:17', '2011-09-15 22:22:01', 0),
(46, 'Товар 19', '', '', '', '', '', '', '', 1000, 5, 'data/demo/sony_vaio_1.jpg', 10, 1, '1000.0000', 0, 9, '2009-02-03', '0.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 2, 1, 1, 0, 1, '2009-02-03 21:08:29', '2011-09-30 01:06:39', 4),
(47, 'Товар 21', '', '', '', '', '', '', '', 1000, 5, 'data/demo/hp_1.jpg', 7, 1, '100.0000', 400, 9, '2009-02-03', '1.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 1, 0, 1, 0, 1, '2009-02-03 21:08:40', '2011-09-30 01:05:28', 4),
(48, 'Товар 20', 'test 1', '', '', '', '', '', 'test 2', 995, 5, 'data/demo/ipod_classic_1.jpg', 8, 1, '100.0000', 0, 9, '2009-02-08', '1.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 2, 1, 1, 0, 1, '2009-02-08 17:21:51', '2011-09-30 01:07:06', 0),
(49, 'SAM1', '', '', '', '', '', '', '', 0, 8, 'data/demo/samsung_tab_1.jpg', 0, 1, '199.9900', 0, 9, '2011-04-25', '0.00000000', 1, '0.00000000', '0.00000000', '0.00000000', 1, 1, 1, 1, 1, '2011-04-26 08:57:34', '2011-09-30 01:06:23', 6),
(64, 'Товар 01', '', '', '', '', '', '', '', 946, 7, 'data/demo/htc_touch_hd_1.jpg', 5, 1, '500.0000', 200, 9, '2009-02-03', '146.40000000', 2, '0.00000000', '0.00000000', '0.00000000', 1, 1, 1, 0, 0, '2011-05-24 23:48:34', '0000-00-00 00:00:00', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `product_attribute`
--

CREATE TABLE IF NOT EXISTS `product_attribute` (
  `product_id` int(11) NOT NULL,
  `attribute_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `text` text NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_attribute`
--

INSERT INTO `product_attribute` (`product_id`, `attribute_id`, `language_id`, `text`) VALUES
(43, 2, 1, '1'),
(47, 2, 1, '4'),
(43, 4, 1, '8гб'),
(42, 3, 1, '100мгц'),
(47, 4, 1, '16ГБ'),
(43, 2, 2, '1'),
(47, 2, 2, '4'),
(43, 4, 2, '8gb'),
(42, 3, 2, '100mhz'),
(47, 4, 2, '16GB');

-- --------------------------------------------------------

--
-- Структура таблицы `product_description`
--

CREATE TABLE IF NOT EXISTS `product_description` (
  `product_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `meta_description` varchar(255) NOT NULL,
  `meta_keyword` varchar(255) NOT NULL,
  `seo_title` varchar(255) NOT NULL,
  `seo_h1` varchar(255) NOT NULL,
  `tag` text NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=65 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_description`
--

INSERT INTO `product_description` (`product_id`, `language_id`, `name`, `description`, `meta_description`, `meta_keyword`, `seo_title`, `seo_h1`, `tag`) VALUES
(35, 1, 'Товар 8', '&lt;p&gt;\r\n	Товар 8&lt;/p&gt;\r\n', '', '', '', '', ''),
(48, 1, 'iPod Classic', '&lt;div class=&quot;cpt_product_description &quot;&gt;\r\n	&lt;div&gt;\r\n		&lt;p&gt;\r\n			&lt;strong&gt;More room to move.&lt;/strong&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			With 80GB or 160GB of storage and up to 40 hours of battery life, the new iPod classic lets you enjoy up to 40,000 songs or up to 200 hours of video or any combination wherever you go.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;strong&gt;Cover Flow.&lt;/strong&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Browse through your music collection by flipping through album art. Select an album to turn it over and see the track list.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;strong&gt;Enhanced interface.&lt;/strong&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Experience a whole new way to browse and view your music and video.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;strong&gt;Sleeker design.&lt;/strong&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Beautiful, durable, and sleeker than ever, iPod classic now features an anodized aluminum and polished stainless steel enclosure with rounded edges.&lt;/p&gt;\r\n	&lt;/div&gt;\r\n&lt;/div&gt;\r\n&lt;!-- cpt_container_end --&gt;', '', '', '', '', ''),
(40, 1, 'iPhone', '&lt;p class=&quot;intro&quot;&gt;\r\n	iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping a name or number in your address book, a favorites list, or a call log. It also automatically syncs all your contacts from a PC, Mac, or Internet service. And it lets you select and listen to voicemail messages in whatever order you want just like email.&lt;/p&gt;\r\n', '', '', '', '', ''),
(28, 1, 'HTC Touch HD', '&lt;p&gt;\r\n	HTC Touch - in High Definition. Watch music videos and streaming content in awe-inspiring high definition clarity for a mobile experience you never thought possible. Seductively sleek, the HTC Touch HD provides the next generation of mobile functionality, all at a simple touch. Fully integrated with Windows Mobile Professional 6.1, ultrafast 3.5G, GPS, 5MP camera, plus lots more - all delivered on a breathtakingly crisp 3.8&amp;quot; WVGA touchscreen - you can take control of your mobile world with the HTC Touch HD.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Features&lt;/strong&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Processor Qualcomm&amp;reg; MSM 7201A&amp;trade; 528 MHz&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Windows Mobile&amp;reg; 6.1 Professional Operating System&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Memory: 512 MB ROM, 288 MB RAM&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Dimensions: 115 mm x 62.8 mm x 12 mm / 146.4 grams&lt;/li&gt;\r\n	&lt;li&gt;\r\n		3.8-inch TFT-LCD flat touch-sensitive screen with 480 x 800 WVGA resolution&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HSDPA/WCDMA: Europe/Asia: 900/2100 MHz; Up to 2 Mbps up-link and 7.2 Mbps down-link speeds&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Quad-band GSM/GPRS/EDGE: Europe/Asia: 850/900/1800/1900 MHz (Band frequency, HSUPA availability, and data speed are operator dependent.)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Device Control via HTC TouchFLO&amp;trade; 3D &amp;amp; Touch-sensitive front panel buttons&lt;/li&gt;\r\n	&lt;li&gt;\r\n		GPS and A-GPS ready&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Bluetooth&amp;reg; 2.0 with Enhanced Data Rate and A2DP for wireless stereo headsets&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Wi-Fi&amp;reg;: IEEE 802.11 b/g&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HTC ExtUSB&amp;trade; (11-pin mini-USB 2.0)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		5 megapixel color camera with auto focus&lt;/li&gt;\r\n	&lt;li&gt;\r\n		VGA CMOS color camera&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Built-in 3.5 mm audio jack, microphone, speaker, and FM radio&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Ring tone formats: AAC, AAC+, eAAC+, AMR-NB, AMR-WB, QCP, MP3, WMA, WAV&lt;/li&gt;\r\n	&lt;li&gt;\r\n		40 polyphonic and standard MIDI format 0 and 1 (SMF)/SP MIDI&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Rechargeable Lithium-ion or Lithium-ion polymer 1350 mAh battery&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Expansion Slot: microSD&amp;trade; memory card (SD 2.0 compatible)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		AC Adapter Voltage range/frequency: 100 ~ 240V AC, 50/60 Hz DC output: 5V and 1A&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Special Features: FM Radio, G-Sensor&lt;/li&gt;\r\n&lt;/ul&gt;\r\n', '', '', '', '', ''),
(44, 1, 'MacBook Air', '&lt;div&gt;\r\n	MacBook Air is ultrathin, ultraportable, and ultra unlike anything else. But you don&amp;rsquo;t lose inches and pounds overnight. It&amp;rsquo;s the result of rethinking conventions. Of multiple wireless innovations. And of breakthrough design. With MacBook Air, mobile computing suddenly has a new standard.&lt;/div&gt;\r\n', '', '', '', '', ''),
(45, 1, 'MacBook Pro', '&lt;div class=&quot;cpt_product_description &quot;&gt;\r\n	&lt;div&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Latest Intel mobile architecture&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Powered by the most advanced mobile processors from Intel, the new Core 2 Duo MacBook Pro is over 50% faster than the original Core Duo MacBook Pro and now supports up to 4GB of RAM.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Leading-edge graphics&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			The NVIDIA GeForce 8600M GT delivers exceptional graphics processing power. For the ultimate creative canvas, you can even configure the 17-inch model with a 1920-by-1200 resolution display.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Designed for life on the road&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Innovations such as a magnetic power connection and an illuminated keyboard with ambient light sensor put the MacBook Pro in a class by itself.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Connect. Create. Communicate.&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Quickly set up a video conference with the built-in iSight camera. Control presentations and media from up to 30 feet away with the included Apple Remote. Connect to high-bandwidth peripherals with FireWire 800 and DVI.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Next-generation wireless&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Featuring 802.11n wireless technology, the MacBook Pro delivers up to five times the performance and up to twice the range of previous-generation technologies.&lt;/p&gt;\r\n	&lt;/div&gt;\r\n&lt;/div&gt;\r\n&lt;!-- cpt_container_end --&gt;', '', '', '', '', ''),
(29, 1, 'Palm Treo Pro', '&lt;p&gt;\r\n	Redefine your workday with the Palm Treo Pro smartphone. Perfectly balanced, you can respond to business and personal email, stay on top of appointments and contacts, and use Wi-Fi or GPS when you&amp;rsquo;re out and about. Then watch a video on YouTube, catch up with news and sports on the web, or listen to a few songs. Balance your work and play the way you like it, with the Palm Treo Pro.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Features&lt;/strong&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Windows Mobile&amp;reg; 6.1 Professional Edition&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Qualcomm&amp;reg; MSM7201 400MHz Processor&lt;/li&gt;\r\n	&lt;li&gt;\r\n		320x320 transflective colour TFT touchscreen&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HSDPA/UMTS/EDGE/GPRS/GSM radio&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Tri-band UMTS &amp;mdash; 850MHz, 1900MHz, 2100MHz&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Quad-band GSM &amp;mdash; 850/900/1800/1900&lt;/li&gt;\r\n	&lt;li&gt;\r\n		802.11b/g with WPA, WPA2, and 801.1x authentication&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Built-in GPS&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Bluetooth Version: 2.0 + Enhanced Data Rate&lt;/li&gt;\r\n	&lt;li&gt;\r\n		256MB storage (100MB user available), 128MB RAM&lt;/li&gt;\r\n	&lt;li&gt;\r\n		2.0 megapixel camera, up to 8x digital zoom and video capture&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Removable, rechargeable 1500mAh lithium-ion battery&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Up to 5.0 hours talk time and up to 250 hours standby&lt;/li&gt;\r\n	&lt;li&gt;\r\n		MicroSDHC card expansion (up to 32GB supported)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		MicroUSB 2.0 for synchronization and charging&lt;/li&gt;\r\n	&lt;li&gt;\r\n		3.5mm stereo headset jack&lt;/li&gt;\r\n	&lt;li&gt;\r\n		60mm (W) x 114mm (L) x 13.5mm (D) / 133g&lt;/li&gt;\r\n&lt;/ul&gt;\r\n', '', '', '', '', ''),
(36, 1, 'iPod Nano', '&lt;div&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Video in your pocket.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Its the small iPod with one very big idea: video. The worlds most popular music player now lets you enjoy movies, TV shows, and more on a two-inch display thats 65% brighter than before.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Cover Flow.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Browse through your music collection by flipping through album art. Select an album to turn it over and see the track list.&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Enhanced interface.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Experience a whole new way to browse and view your music and video.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Sleek and colorful.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		With an anodized aluminum and polished stainless steel enclosure and a choice of five colors, iPod nano is dressed to impress.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;iTunes.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Available as a free download, iTunes makes it easy to browse and buy millions of songs, movies, TV shows, audiobooks, and games and download free podcasts all at the iTunes Store. And you can import your own music, manage your whole media library, and sync your iPod or iPhone with ease.&lt;/p&gt;\r\n&lt;/div&gt;\r\n', '', '', '', '', ''),
(46, 1, 'Sony VAIO', '&lt;div&gt;\r\n	Unprecedented power. The next generation of processing technology has arrived. Built into the newest VAIO notebooks lies Intel&amp;#39;s latest, most powerful innovation yet: Intel&amp;reg; Centrino&amp;reg; 2 processor technology. Boasting incredible speed, expanded wireless connectivity, enhanced multimedia support and greater energy efficiency, all the high-performance essentials are seamlessly combined into a single chip.&lt;/div&gt;\r\n', '', '', '', '', ''),
(47, 1, 'HP LP3065', '&lt;p&gt;\r\n	Stop your co-workers in their tracks with the stunning new 30-inch diagonal HP LP3065 Flat Panel Monitor. This flagship monitor features best-in-class performance and presentation features on a huge wide-aspect screen while letting you work as comfortably as possible - you might even forget you&amp;#39;re at the office&lt;/p&gt;\r\n', '', '', '', '', ''),
(32, 1, 'iPod Touch', '&lt;p&gt;\r\n	&lt;strong&gt;Revolutionary multi-touch interface.&lt;/strong&gt;&lt;br /&gt;\r\n	iPod touch features the same multi-touch screen technology as iPhone. Pinch to zoom in on a photo. Scroll through your songs and videos with a flick. Flip through your library by album artwork with Cover Flow.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Gorgeous 3.5-inch widescreen display.&lt;/strong&gt;&lt;br /&gt;\r\n	Watch your movies, TV shows, and photos come alive with bright, vivid color on the 320-by-480-pixel display.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Music downloads straight from iTunes.&lt;/strong&gt;&lt;br /&gt;\r\n	Shop the iTunes Wi-Fi Music Store from anywhere with Wi-Fi.1 Browse or search to find the music youre looking for, preview it, and buy it with just a tap.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Surf the web with Wi-Fi.&lt;/strong&gt;&lt;br /&gt;\r\n	Browse the web using Safari and watch YouTube videos on the first iPod with Wi-Fi built in&lt;br /&gt;\r\n	&amp;nbsp;&lt;/p&gt;\r\n', '', '', '', '', ''),
(41, 1, 'iMac', '&lt;div&gt;\r\n	Just when you thought iMac had everything, now there’s even more. More powerful Intel Core 2 Duo processors. And more memory standard. Combine this with Mac OS X Leopard and iLife ’08, and it’s more all-in-one than ever. iMac packs amazing performance into a stunningly slim space.&lt;/div&gt;\r\n', '', '', '', '', ''),
(33, 1, 'Samsung SyncMaster 941BW', '&lt;div&gt;\r\n	Imagine the advantages of going big without slowing down. The big 19&amp;quot; 941BW monitor combines wide aspect ratio with fast pixel response time, for bigger images, more room to work and crisp motion. In addition, the exclusive MagicBright 2, MagicColor and MagicTune technologies help deliver the ideal image in every situation, while sleek, narrow bezels and adjustable stands deliver style just the way you want it. With the Samsung 941BW widescreen analog/digital LCD monitor, it&amp;#39;s not hard to imagine.&lt;/div&gt;\r\n', '', '', '', '', ''),
(34, 1, 'iPod Shuffle', '&lt;div&gt;\r\n	&lt;strong&gt;Born to be worn.&lt;/strong&gt;\r\n	&lt;p&gt;\r\n		Clip on the worlds most wearable music player and take up to 240 songs with you anywhere. Choose from five colors including four new hues to make your musical fashion statement.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Random meets rhythm.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		With iTunes autofill, iPod shuffle can deliver a new musical experience every time you sync. For more randomness, you can shuffle songs during playback with the slide of a switch.&lt;/p&gt;\r\n	&lt;strong&gt;Everything is easy.&lt;/strong&gt;\r\n	&lt;p&gt;\r\n		Charge and sync with the included USB dock. Operate the iPod shuffle controls with one hand. Enjoy up to 12 hours straight of skip-free music playback.&lt;/p&gt;\r\n&lt;/div&gt;\r\n', '', '', '', '', ''),
(43, 1, 'MacBook', '&lt;div&gt;\r\n	&lt;p&gt;\r\n		&lt;b&gt;Intel Core 2 Duo processor&lt;/b&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Powered by an Intel Core 2 Duo processor at speeds up to 2.16GHz, the new MacBook is the fastest ever.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;b&gt;1GB memory, larger hard drives&lt;/b&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		The new MacBook now comes with 1GB of memory standard and larger hard drives for the entire line perfect for running more of your favorite applications and storing growing media collections.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;b&gt;Sleek, 1.08-inch-thin design&lt;/b&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		MacBook makes it easy to hit the road thanks to its tough polycarbonate case, built-in wireless technologies, and innovative MagSafe Power Adapter that releases automatically if someone accidentally trips on the cord.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;b&gt;Built-in iSight camera&lt;/b&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Right out of the box, you can have a video chat with friends or family,2 record a video at your desk, or take fun pictures with Photo Booth&lt;/p&gt;\r\n&lt;/div&gt;\r\n', '', '', '', '', ''),
(31, 1, 'Nikon D300', '&lt;div class=&quot;cpt_product_description &quot;&gt;\r\n	&lt;div&gt;\r\n		Engineered with pro-level features and performance, the 12.3-effective-megapixel D300 combines brand new technologies with advanced features inherited from Nikon&amp;#39;s newly announced D3 professional digital SLR camera to offer serious photographers remarkable performance combined with agility.&lt;br /&gt;\r\n		&lt;br /&gt;\r\n		Similar to the D3, the D300 features Nikon&amp;#39;s exclusive EXPEED Image Processing System that is central to driving the speed and processing power needed for many of the camera&amp;#39;s new features. The D300 features a new 51-point autofocus system with Nikon&amp;#39;s 3D Focus Tracking feature and two new LiveView shooting modes that allow users to frame a photograph using the camera&amp;#39;s high-resolution LCD monitor. The D300 shares a similar Scene Recognition System as is found in the D3; it promises to greatly enhance the accuracy of autofocus, autoexposure, and auto white balance by recognizing the subject or scene being photographed and applying this information to the calculations for the three functions.&lt;br /&gt;\r\n		&lt;br /&gt;\r\n		The D300 reacts with lightning speed, powering up in a mere 0.13 seconds and shooting with an imperceptible 45-millisecond shutter release lag time. The D300 is capable of shooting at a rapid six frames per second and can go as fast as eight frames per second when using the optional MB-D10 multi-power battery pack. In continuous bursts, the D300 can shoot up to 100 shots at full 12.3-megapixel resolution. (NORMAL-LARGE image setting, using a SanDisk Extreme IV 1GB CompactFlash card.)&lt;br /&gt;\r\n		&lt;br /&gt;\r\n		The D300 incorporates a range of innovative technologies and features that will significantly improve the accuracy, control, and performance photographers can get from their equipment. Its new Scene Recognition System advances the use of Nikon&amp;#39;s acclaimed 1,005-segment sensor to recognize colors and light patterns that help the camera determine the subject and the type of scene being photographed before a picture is taken. This information is used to improve the accuracy of autofocus, autoexposure, and auto white balance functions in the D300. For example, the camera can track moving subjects better and by identifying them, it can also automatically select focus points faster and with greater accuracy. It can also analyze highlights and more accurately determine exposure, as well as infer light sources to deliver more accurate white balance detection.&lt;/div&gt;\r\n&lt;/div&gt;\r\n&lt;!-- cpt_container_end --&gt;', '', '', '', '', ''),
(49, 1, 'Samsung Galaxy Tab 10.1', '&lt;p&gt;\r\n	Samsung Galaxy Tab 10.1, is the world&amp;rsquo;s thinnest tablet, measuring 8.6 mm thickness, running with Android 3.0 Honeycomb OS on a 1GHz dual-core Tegra 2 processor, similar to its younger brother Samsung Galaxy Tab 8.9.&lt;/p&gt;\r\n&lt;p&gt;\r\n	Samsung Galaxy Tab 10.1 gives pure Android 3.0 experience, adding its new TouchWiz UX or TouchWiz 4.0 &amp;ndash; includes a live panel, which lets you to customize with different content, such as your pictures, bookmarks, and social feeds, sporting a 10.1 inches WXGA capacitive touch screen with 1280 x 800 pixels of resolution, equipped with 3 megapixel rear camera with LED flash and a 2 megapixel front camera, HSPA+ connectivity up to 21Mbps, 720p HD video recording capability, 1080p HD playback, DLNA support, Bluetooth 2.1, USB 2.0, gyroscope, Wi-Fi 802.11 a/b/g/n, micro-SD slot, 3.5mm headphone jack, and SIM slot, including the Samsung Stick &amp;ndash; a Bluetooth microphone that can be carried in a pocket like a pen and sound dock with powered subwoofer.&lt;/p&gt;\r\n&lt;p&gt;\r\n	Samsung Galaxy Tab 10.1 will come in 16GB / 32GB / 64GB verities and pre-loaded with Social Hub, Reader&amp;rsquo;s Hub, Music Hub and Samsung Mini Apps Tray &amp;ndash; which gives you access to more commonly used apps to help ease multitasking and it is capable of Adobe Flash Player 10.2, powered by 6860mAh battery that gives you 10hours of video-playback time.&amp;nbsp;&amp;auml;&amp;ouml;&lt;/p&gt;\r\n', '', '', '', '', ''),
(42, 1, 'Apple Cinema 30&quot;', '&lt;p&gt;\r\n	&lt;font face=&quot;helvetica,geneva,arial&quot; size=&quot;2&quot;&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;The 30-inch Apple Cinema HD Display delivers an amazing 2560 x 1600 pixel resolution. Designed specifically for the creative professional, this display provides more space for easier access to all the tools and palettes needed to edit, format and composite your work. Combine this display with a Mac Pro, MacBook Pro, or PowerMac G5 and there&amp;#39;s no limit to what you can achieve. &lt;br /&gt;\r\n	&lt;br /&gt;\r\n	&lt;/font&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;The Cinema HD features an active-matrix liquid crystal display that produces flicker-free images that deliver twice the brightness, twice the sharpness and twice the contrast ratio of a typical CRT display. Unlike other flat panels, it&amp;#39;s designed with a pure digital interface to deliver distortion-free images that never need adjusting. With over 4 million digital pixels, the display is uniquely suited for scientific and technical applications such as visualizing molecular structures or analyzing geological data. &lt;br /&gt;\r\n	&lt;br /&gt;\r\n	&lt;/font&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;Offering accurate, brilliant color performance, the Cinema HD delivers up to 16.7 million colors across a wide gamut allowing you to see subtle nuances between colors from soft pastels to rich jewel tones. A wide viewing angle ensures uniform color from edge to edge. Apple&amp;#39;s ColorSync technology allows you to create custom profiles to maintain consistent color onscreen and in print. The result: You can confidently use this display in all your color-critical applications. &lt;br /&gt;\r\n	&lt;br /&gt;\r\n	&lt;/font&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;Housed in a new aluminum design, the display has a very thin bezel that enhances visual accuracy. Each display features two FireWire 400 ports and two USB 2.0 ports, making attachment of desktop peripherals, such as iSight, iPod, digital and still cameras, hard drives, printers and scanners, even more accessible and convenient. Taking advantage of the much thinner and lighter footprint of an LCD, the new displays support the VESA (Video Electronics Standards Association) mounting interface standard. Customers with the optional Cinema Display VESA Mount Adapter kit gain the flexibility to mount their display in locations most appropriate for their work environment. &lt;br /&gt;\r\n	&lt;br /&gt;\r\n	&lt;/font&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;The Cinema HD features a single cable design with elegant breakout for the USB 2.0, FireWire 400 and a pure digital connection using the industry standard Digital Video Interface (DVI) interface. The DVI connection allows for a direct pure-digital connection.&lt;br /&gt;\r\n	&lt;/font&gt;&lt;/font&gt;&lt;/p&gt;\r\n&lt;h3&gt;\r\n	Features:&lt;/h3&gt;\r\n&lt;p&gt;\r\n	Unrivaled display performance&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		30-inch (viewable) active-matrix liquid crystal display provides breathtaking image quality and vivid, richly saturated color.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Support for 2560-by-1600 pixel resolution for display of high definition still and video imagery.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Wide-format design for simultaneous display of two full pages of text and graphics.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Industry standard DVI connector for direct attachment to Mac- and Windows-based desktops and notebooks&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Incredibly wide (170 degree) horizontal and vertical viewing angle for maximum visibility and color performance.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Lightning-fast pixel response for full-motion digital video playback.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Support for 16.7 million saturated colors, for use in all graphics-intensive applications.&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	Simple setup and operation&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Single cable with elegant breakout for connection to DVI, USB and FireWire ports&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Built-in two-port USB 2.0 hub for easy connection of desktop peripheral devices.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Two FireWire 400 ports to support iSight and other desktop peripherals&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	Sleek, elegant design&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Huge virtual workspace, very small footprint.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Narrow Bezel design to minimize visual impact of using dual displays&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Unique hinge design for effortless adjustment&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Support for VESA mounting solutions (Apple Cinema Display VESA Mount Adapter sold separately)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;h3&gt;\r\n	Technical specifications&lt;/h3&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Screen size (diagonal viewable image size)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Apple Cinema HD Display: 30 inches (29.7-inch viewable)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Screen type&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Thin film transistor (TFT) active-matrix liquid crystal display (AMLCD)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Resolutions&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		2560 x 1600 pixels (optimum resolution)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		2048 x 1280&lt;/li&gt;\r\n	&lt;li&gt;\r\n		1920 x 1200&lt;/li&gt;\r\n	&lt;li&gt;\r\n		1280 x 800&lt;/li&gt;\r\n	&lt;li&gt;\r\n		1024 x 640&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Display colors (maximum)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		16.7 million&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Viewing angle (typical)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		170&amp;deg; horizontal; 170&amp;deg; vertical&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Brightness (typical)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		30-inch Cinema HD Display: 400 cd/m2&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Contrast ratio (typical)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		700:1&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Response time (typical)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		16 ms&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Pixel pitch&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		30-inch Cinema HD Display: 0.250 mm&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Screen treatment&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Antiglare hardcoat&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;User controls (hardware and software)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Display Power,&lt;/li&gt;\r\n	&lt;li&gt;\r\n		System sleep, wake&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Brightness&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Monitor tilt&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Connectors and cables&lt;/b&gt;&lt;br /&gt;\r\n	Cable&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		DVI (Digital Visual Interface)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		FireWire 400&lt;/li&gt;\r\n	&lt;li&gt;\r\n		USB 2.0&lt;/li&gt;\r\n	&lt;li&gt;\r\n		DC power (24 V)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	Connectors&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Two-port, self-powered USB 2.0 hub&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Two FireWire 400 ports&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Kensington security port&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;VESA mount adapter&lt;/b&gt;&lt;br /&gt;\r\n	Requires optional Cinema Display VESA Mount Adapter (M9649G/A)&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Compatible with VESA FDMI (MIS-D, 100, C) compliant mounting solutions&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Electrical requirements&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Input voltage: 100-240 VAC 50-60Hz&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Maximum power when operating: 150W&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Energy saver mode: 3W or less&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Environmental requirements&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Operating temperature: 50&amp;deg; to 95&amp;deg; F (10&amp;deg; to 35&amp;deg; C)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Storage temperature: -40&amp;deg; to 116&amp;deg; F (-40&amp;deg; to 47&amp;deg; C)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Operating humidity: 20% to 80% noncondensing&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Maximum operating altitude: 10,000 feet&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Agency approvals&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		FCC Part 15 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		EN55022 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		EN55024&lt;/li&gt;\r\n	&lt;li&gt;\r\n		VCCI Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		AS/NZS 3548 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		CNS 13438 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		ICES-003 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		ISO 13406 part 2&lt;/li&gt;\r\n	&lt;li&gt;\r\n		MPR II&lt;/li&gt;\r\n	&lt;li&gt;\r\n		IEC 60950&lt;/li&gt;\r\n	&lt;li&gt;\r\n		UL 60950&lt;/li&gt;\r\n	&lt;li&gt;\r\n		CSA 60950&lt;/li&gt;\r\n	&lt;li&gt;\r\n		EN60950&lt;/li&gt;\r\n	&lt;li&gt;\r\n		ENERGY STAR&lt;/li&gt;\r\n	&lt;li&gt;\r\n		TCO &amp;#39;03&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Size and weight&lt;/b&gt;&lt;br /&gt;\r\n	30-inch Apple Cinema HD Display&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Height: 21.3 inches (54.3 cm)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Width: 27.2 inches (68.8 cm)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Depth: 8.46 inches (21.5 cm)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Weight: 27.5 pounds (12.5 kg)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;System Requirements&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Mac Pro, all graphic options&lt;/li&gt;\r\n	&lt;li&gt;\r\n		MacBook Pro&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Power Mac G5 (PCI-X) with ATI Radeon 9650 or better or NVIDIA GeForce 6800 GT DDL or better&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Power Mac G5 (PCI Express), all graphics options&lt;/li&gt;\r\n	&lt;li&gt;\r\n		PowerBook G4 with dual-link DVI support&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Windows PC and graphics card that supports DVI ports with dual-link digital bandwidth and VESA DDC standard for plug-and-play setup&lt;/li&gt;\r\n&lt;/ul&gt;\r\n', '', '', '', '', ''),
(30, 1, 'Canon EOS 5D', '&lt;p&gt;\r\n	Canon''s press material for the EOS 5D states that it ''defines (a) new D-SLR category'', while we''re not typically too concerned with marketing talk this particular statement is clearly pretty accurate. The EOS 5D is unlike any previous digital SLR in that it combines a full-frame (35 mm sized) high resolution sensor (12.8 megapixels) with a relatively compact body (slightly larger than the EOS 20D, although in your hand it feels noticeably ''chunkier''). The EOS 5D is aimed to slot in between the EOS 20D and the EOS-1D professional digital SLR''s, an important difference when compared to the latter is that the EOS 5D doesn''t have any environmental seals. While Canon don''t specifically refer to the EOS 5D as a ''professional'' digital SLR it will have obvious appeal to professionals who want a high quality digital SLR in a body lighter than the EOS-1D. It will also no doubt appeal to current EOS 20D owners (although lets hope they''ve not bought too many EF-S lenses...) ??&lt;/p&gt;\r\n', '', '', '', '', ''),
(64, 1, 'HTC Touch HD', '&lt;p&gt;\r\n	HTC Touch - in High Definition. Watch music videos and streaming content in awe-inspiring high definition clarity for a mobile experience you never thought possible. Seductively sleek, the HTC Touch HD provides the next generation of mobile functionality, all at a simple touch. Fully integrated with Windows Mobile Professional 6.1, ultrafast 3.5G, GPS, 5MP camera, plus lots more - all delivered on a breathtakingly crisp 3.8&amp;quot; WVGA touchscreen - you can take control of your mobile world with the HTC Touch HD.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Features&lt;/strong&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Processor Qualcomm&amp;reg; MSM 7201A&amp;trade; 528 MHz&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Windows Mobile&amp;reg; 6.1 Professional Operating System&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Memory: 512 MB ROM, 288 MB RAM&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Dimensions: 115 mm x 62.8 mm x 12 mm / 146.4 grams&lt;/li&gt;\r\n	&lt;li&gt;\r\n		3.8-inch TFT-LCD flat touch-sensitive screen with 480 x 800 WVGA resolution&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HSDPA/WCDMA: Europe/Asia: 900/2100 MHz; Up to 2 Mbps up-link and 7.2 Mbps down-link speeds&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Quad-band GSM/GPRS/EDGE: Europe/Asia: 850/900/1800/1900 MHz (Band frequency, HSUPA availability, and data speed are operator dependent.)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Device Control via HTC TouchFLO&amp;trade; 3D &amp;amp; Touch-sensitive front panel buttons&lt;/li&gt;\r\n	&lt;li&gt;\r\n		GPS and A-GPS ready&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Bluetooth&amp;reg; 2.0 with Enhanced Data Rate and A2DP for wireless stereo headsets&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Wi-Fi&amp;reg;: IEEE 802.11 b/g&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HTC ExtUSB&amp;trade; (11-pin mini-USB 2.0)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		5 megapixel color camera with auto focus&lt;/li&gt;\r\n	&lt;li&gt;\r\n		VGA CMOS color camera&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Built-in 3.5 mm audio jack, microphone, speaker, and FM radio&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Ring tone formats: AAC, AAC+, eAAC+, AMR-NB, AMR-WB, QCP, MP3, WMA, WAV&lt;/li&gt;\r\n	&lt;li&gt;\r\n		40 polyphonic and standard MIDI format 0 and 1 (SMF)/SP MIDI&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Rechargeable Lithium-ion or Lithium-ion polymer 1350 mAh battery&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Expansion Slot: microSD&amp;trade; memory card (SD 2.0 compatible)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		AC Adapter Voltage range/frequency: 100 ~ 240V AC, 50/60 Hz DC output: 5V and 1A&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Special Features: FM Radio, G-Sensor&lt;/li&gt;\r\n&lt;/ul&gt;\r\n', '', '', '', '', ''),
(35, 2, 'Product 8', '&lt;p&gt;\r\n	Product 8&lt;/p&gt;\r\n', '', '', '', '', ''),
(48, 2, 'iPod Classic', '&lt;div class=&quot;cpt_product_description &quot;&gt;\r\n	&lt;div&gt;\r\n		&lt;p&gt;\r\n			&lt;strong&gt;More room to move.&lt;/strong&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			With 80GB or 160GB of storage and up to 40 hours of battery life, the new iPod classic lets you enjoy up to 40,000 songs or up to 200 hours of video or any combination wherever you go.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;strong&gt;Cover Flow.&lt;/strong&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Browse through your music collection by flipping through album art. Select an album to turn it over and see the track list.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;strong&gt;Enhanced interface.&lt;/strong&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Experience a whole new way to browse and view your music and video.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;strong&gt;Sleeker design.&lt;/strong&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Beautiful, durable, and sleeker than ever, iPod classic now features an anodized aluminum and polished stainless steel enclosure with rounded edges.&lt;/p&gt;\r\n	&lt;/div&gt;\r\n&lt;/div&gt;\r\n&lt;!-- cpt_container_end --&gt;', '', '', '', '', ''),
(40, 2, 'iPhone', '&lt;p class=&quot;intro&quot;&gt;\r\n	iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping a name or number in your address book, a favorites list, or a call log. It also automatically syncs all your contacts from a PC, Mac, or Internet service. And it lets you select and listen to voicemail messages in whatever order you want just like email.&lt;/p&gt;\r\n', '', '', '', '', ''),
(28, 2, 'HTC Touch HD', '&lt;p&gt;\r\n	HTC Touch - in High Definition. Watch music videos and streaming content in awe-inspiring high definition clarity for a mobile experience you never thought possible. Seductively sleek, the HTC Touch HD provides the next generation of mobile functionality, all at a simple touch. Fully integrated with Windows Mobile Professional 6.1, ultrafast 3.5G, GPS, 5MP camera, plus lots more - all delivered on a breathtakingly crisp 3.8&amp;quot; WVGA touchscreen - you can take control of your mobile world with the HTC Touch HD.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Features&lt;/strong&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Processor Qualcomm&amp;reg; MSM 7201A&amp;trade; 528 MHz&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Windows Mobile&amp;reg; 6.1 Professional Operating System&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Memory: 512 MB ROM, 288 MB RAM&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Dimensions: 115 mm x 62.8 mm x 12 mm / 146.4 grams&lt;/li&gt;\r\n	&lt;li&gt;\r\n		3.8-inch TFT-LCD flat touch-sensitive screen with 480 x 800 WVGA resolution&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HSDPA/WCDMA: Europe/Asia: 900/2100 MHz; Up to 2 Mbps up-link and 7.2 Mbps down-link speeds&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Quad-band GSM/GPRS/EDGE: Europe/Asia: 850/900/1800/1900 MHz (Band frequency, HSUPA availability, and data speed are operator dependent.)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Device Control via HTC TouchFLO&amp;trade; 3D &amp;amp; Touch-sensitive front panel buttons&lt;/li&gt;\r\n	&lt;li&gt;\r\n		GPS and A-GPS ready&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Bluetooth&amp;reg; 2.0 with Enhanced Data Rate and A2DP for wireless stereo headsets&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Wi-Fi&amp;reg;: IEEE 802.11 b/g&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HTC ExtUSB&amp;trade; (11-pin mini-USB 2.0)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		5 megapixel color camera with auto focus&lt;/li&gt;\r\n	&lt;li&gt;\r\n		VGA CMOS color camera&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Built-in 3.5 mm audio jack, microphone, speaker, and FM radio&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Ring tone formats: AAC, AAC+, eAAC+, AMR-NB, AMR-WB, QCP, MP3, WMA, WAV&lt;/li&gt;\r\n	&lt;li&gt;\r\n		40 polyphonic and standard MIDI format 0 and 1 (SMF)/SP MIDI&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Rechargeable Lithium-ion or Lithium-ion polymer 1350 mAh battery&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Expansion Slot: microSD&amp;trade; memory card (SD 2.0 compatible)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		AC Adapter Voltage range/frequency: 100 ~ 240V AC, 50/60 Hz DC output: 5V and 1A&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Special Features: FM Radio, G-Sensor&lt;/li&gt;\r\n&lt;/ul&gt;\r\n', '', '', '', '', ''),
(44, 2, 'MacBook Air', '&lt;div&gt;\r\n	MacBook Air is ultrathin, ultraportable, and ultra unlike anything else. But you don&amp;rsquo;t lose inches and pounds overnight. It&amp;rsquo;s the result of rethinking conventions. Of multiple wireless innovations. And of breakthrough design. With MacBook Air, mobile computing suddenly has a new standard.&lt;/div&gt;\r\n', '', '', '', '', ''),
(45, 2, 'MacBook Pro', '&lt;div class=&quot;cpt_product_description &quot;&gt;\r\n	&lt;div&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Latest Intel mobile architecture&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Powered by the most advanced mobile processors from Intel, the new Core 2 Duo MacBook Pro is over 50% faster than the original Core Duo MacBook Pro and now supports up to 4GB of RAM.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Leading-edge graphics&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			The NVIDIA GeForce 8600M GT delivers exceptional graphics processing power. For the ultimate creative canvas, you can even configure the 17-inch model with a 1920-by-1200 resolution display.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Designed for life on the road&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Innovations such as a magnetic power connection and an illuminated keyboard with ambient light sensor put the MacBook Pro in a class by itself.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Connect. Create. Communicate.&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Quickly set up a video conference with the built-in iSight camera. Control presentations and media from up to 30 feet away with the included Apple Remote. Connect to high-bandwidth peripherals with FireWire 800 and DVI.&lt;/p&gt;\r\n		&lt;p&gt;\r\n			&lt;b&gt;Next-generation wireless&lt;/b&gt;&lt;/p&gt;\r\n		&lt;p&gt;\r\n			Featuring 802.11n wireless technology, the MacBook Pro delivers up to five times the performance and up to twice the range of previous-generation technologies.&lt;/p&gt;\r\n	&lt;/div&gt;\r\n&lt;/div&gt;\r\n&lt;!-- cpt_container_end --&gt;', '', '', '', '', ''),
(29, 2, 'Palm Treo Pro', '&lt;p&gt;\r\n	Redefine your workday with the Palm Treo Pro smartphone. Perfectly balanced, you can respond to business and personal email, stay on top of appointments and contacts, and use Wi-Fi or GPS when you&amp;rsquo;re out and about. Then watch a video on YouTube, catch up with news and sports on the web, or listen to a few songs. Balance your work and play the way you like it, with the Palm Treo Pro.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Features&lt;/strong&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Windows Mobile&amp;reg; 6.1 Professional Edition&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Qualcomm&amp;reg; MSM7201 400MHz Processor&lt;/li&gt;\r\n	&lt;li&gt;\r\n		320x320 transflective colour TFT touchscreen&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HSDPA/UMTS/EDGE/GPRS/GSM radio&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Tri-band UMTS &amp;mdash; 850MHz, 1900MHz, 2100MHz&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Quad-band GSM &amp;mdash; 850/900/1800/1900&lt;/li&gt;\r\n	&lt;li&gt;\r\n		802.11b/g with WPA, WPA2, and 801.1x authentication&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Built-in GPS&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Bluetooth Version: 2.0 + Enhanced Data Rate&lt;/li&gt;\r\n	&lt;li&gt;\r\n		256MB storage (100MB user available), 128MB RAM&lt;/li&gt;\r\n	&lt;li&gt;\r\n		2.0 megapixel camera, up to 8x digital zoom and video capture&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Removable, rechargeable 1500mAh lithium-ion battery&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Up to 5.0 hours talk time and up to 250 hours standby&lt;/li&gt;\r\n	&lt;li&gt;\r\n		MicroSDHC card expansion (up to 32GB supported)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		MicroUSB 2.0 for synchronization and charging&lt;/li&gt;\r\n	&lt;li&gt;\r\n		3.5mm stereo headset jack&lt;/li&gt;\r\n	&lt;li&gt;\r\n		60mm (W) x 114mm (L) x 13.5mm (D) / 133g&lt;/li&gt;\r\n&lt;/ul&gt;\r\n', '', '', '', '', ''),
(36, 2, 'iPod Nano', '&lt;div&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Video in your pocket.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Its the small iPod with one very big idea: video. The worlds most popular music player now lets you enjoy movies, TV shows, and more on a two-inch display thats 65% brighter than before.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Cover Flow.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Browse through your music collection by flipping through album art. Select an album to turn it over and see the track list.&lt;strong&gt;&amp;nbsp;&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Enhanced interface.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Experience a whole new way to browse and view your music and video.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Sleek and colorful.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		With an anodized aluminum and polished stainless steel enclosure and a choice of five colors, iPod nano is dressed to impress.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;iTunes.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Available as a free download, iTunes makes it easy to browse and buy millions of songs, movies, TV shows, audiobooks, and games and download free podcasts all at the iTunes Store. And you can import your own music, manage your whole media library, and sync your iPod or iPhone with ease.&lt;/p&gt;\r\n&lt;/div&gt;\r\n', '', '', '', '', ''),
(46, 2, 'Sony VAIO', '&lt;div&gt;\r\n	Unprecedented power. The next generation of processing technology has arrived. Built into the newest VAIO notebooks lies Intel&amp;#39;s latest, most powerful innovation yet: Intel&amp;reg; Centrino&amp;reg; 2 processor technology. Boasting incredible speed, expanded wireless connectivity, enhanced multimedia support and greater energy efficiency, all the high-performance essentials are seamlessly combined into a single chip.&lt;/div&gt;\r\n', '', '', '', '', ''),
(47, 2, 'HP LP3065', '&lt;p&gt;\r\n	Stop your co-workers in their tracks with the stunning new 30-inch diagonal HP LP3065 Flat Panel Monitor. This flagship monitor features best-in-class performance and presentation features on a huge wide-aspect screen while letting you work as comfortably as possible - you might even forget you&amp;#39;re at the office&lt;/p&gt;\r\n', '', '', '', '', ''),
(32, 2, 'iPod Touch', '&lt;p&gt;\r\n	&lt;strong&gt;Revolutionary multi-touch interface.&lt;/strong&gt;&lt;br /&gt;\r\n	iPod touch features the same multi-touch screen technology as iPhone. Pinch to zoom in on a photo. Scroll through your songs and videos with a flick. Flip through your library by album artwork with Cover Flow.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Gorgeous 3.5-inch widescreen display.&lt;/strong&gt;&lt;br /&gt;\r\n	Watch your movies, TV shows, and photos come alive with bright, vivid color on the 320-by-480-pixel display.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Music downloads straight from iTunes.&lt;/strong&gt;&lt;br /&gt;\r\n	Shop the iTunes Wi-Fi Music Store from anywhere with Wi-Fi.1 Browse or search to find the music youre looking for, preview it, and buy it with just a tap.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Surf the web with Wi-Fi.&lt;/strong&gt;&lt;br /&gt;\r\n	Browse the web using Safari and watch YouTube videos on the first iPod with Wi-Fi built in&lt;br /&gt;\r\n	&amp;nbsp;&lt;/p&gt;\r\n', '', '', '', '', ''),
(41, 2, 'iMac', '&lt;div&gt;\r\n	Just when you thought iMac had everything, now there’s even more. More powerful Intel Core 2 Duo processors. And more memory standard. Combine this with Mac OS X Leopard and iLife ’08, and it’s more all-in-one than ever. iMac packs amazing performance into a stunningly slim space.&lt;/div&gt;\r\n', '', '', '', '', ''),
(33, 2, 'Samsung SyncMaster 941BW', '&lt;div&gt;\r\n	Imagine the advantages of going big without slowing down. The big 19&amp;quot; 941BW monitor combines wide aspect ratio with fast pixel response time, for bigger images, more room to work and crisp motion. In addition, the exclusive MagicBright 2, MagicColor and MagicTune technologies help deliver the ideal image in every situation, while sleek, narrow bezels and adjustable stands deliver style just the way you want it. With the Samsung 941BW widescreen analog/digital LCD monitor, it&amp;#39;s not hard to imagine.&lt;/div&gt;\r\n', '', '', '', '', ''),
(34, 2, 'iPod Shuffle', '&lt;div&gt;\r\n	&lt;strong&gt;Born to be worn.&lt;/strong&gt;\r\n	&lt;p&gt;\r\n		Clip on the worlds most wearable music player and take up to 240 songs with you anywhere. Choose from five colors including four new hues to make your musical fashion statement.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;strong&gt;Random meets rhythm.&lt;/strong&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		With iTunes autofill, iPod shuffle can deliver a new musical experience every time you sync. For more randomness, you can shuffle songs during playback with the slide of a switch.&lt;/p&gt;\r\n	&lt;strong&gt;Everything is easy.&lt;/strong&gt;\r\n	&lt;p&gt;\r\n		Charge and sync with the included USB dock. Operate the iPod shuffle controls with one hand. Enjoy up to 12 hours straight of skip-free music playback.&lt;/p&gt;\r\n&lt;/div&gt;\r\n', '', '', '', '', ''),
(43, 2, 'MacBook', '&lt;div&gt;\r\n	&lt;p&gt;\r\n		&lt;b&gt;Intel Core 2 Duo processor&lt;/b&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Powered by an Intel Core 2 Duo processor at speeds up to 2.16GHz, the new MacBook is the fastest ever.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;b&gt;1GB memory, larger hard drives&lt;/b&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		The new MacBook now comes with 1GB of memory standard and larger hard drives for the entire line perfect for running more of your favorite applications and storing growing media collections.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;b&gt;Sleek, 1.08-inch-thin design&lt;/b&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		MacBook makes it easy to hit the road thanks to its tough polycarbonate case, built-in wireless technologies, and innovative MagSafe Power Adapter that releases automatically if someone accidentally trips on the cord.&lt;/p&gt;\r\n	&lt;p&gt;\r\n		&lt;b&gt;Built-in iSight camera&lt;/b&gt;&lt;/p&gt;\r\n	&lt;p&gt;\r\n		Right out of the box, you can have a video chat with friends or family,2 record a video at your desk, or take fun pictures with Photo Booth&lt;/p&gt;\r\n&lt;/div&gt;\r\n', '', '', '', '', '');
INSERT INTO `product_description` (`product_id`, `language_id`, `name`, `description`, `meta_description`, `meta_keyword`, `seo_title`, `seo_h1`, `tag`) VALUES
(31, 2, 'Nikon D300', '&lt;div class=&quot;cpt_product_description &quot;&gt;\r\n	&lt;div&gt;\r\n		Engineered with pro-level features and performance, the 12.3-effective-megapixel D300 combines brand new technologies with advanced features inherited from Nikon&amp;#39;s newly announced D3 professional digital SLR camera to offer serious photographers remarkable performance combined with agility.&lt;br /&gt;\r\n		&lt;br /&gt;\r\n		Similar to the D3, the D300 features Nikon&amp;#39;s exclusive EXPEED Image Processing System that is central to driving the speed and processing power needed for many of the camera&amp;#39;s new features. The D300 features a new 51-point autofocus system with Nikon&amp;#39;s 3D Focus Tracking feature and two new LiveView shooting modes that allow users to frame a photograph using the camera&amp;#39;s high-resolution LCD monitor. The D300 shares a similar Scene Recognition System as is found in the D3; it promises to greatly enhance the accuracy of autofocus, autoexposure, and auto white balance by recognizing the subject or scene being photographed and applying this information to the calculations for the three functions.&lt;br /&gt;\r\n		&lt;br /&gt;\r\n		The D300 reacts with lightning speed, powering up in a mere 0.13 seconds and shooting with an imperceptible 45-millisecond shutter release lag time. The D300 is capable of shooting at a rapid six frames per second and can go as fast as eight frames per second when using the optional MB-D10 multi-power battery pack. In continuous bursts, the D300 can shoot up to 100 shots at full 12.3-megapixel resolution. (NORMAL-LARGE image setting, using a SanDisk Extreme IV 1GB CompactFlash card.)&lt;br /&gt;\r\n		&lt;br /&gt;\r\n		The D300 incorporates a range of innovative technologies and features that will significantly improve the accuracy, control, and performance photographers can get from their equipment. Its new Scene Recognition System advances the use of Nikon&amp;#39;s acclaimed 1,005-segment sensor to recognize colors and light patterns that help the camera determine the subject and the type of scene being photographed before a picture is taken. This information is used to improve the accuracy of autofocus, autoexposure, and auto white balance functions in the D300. For example, the camera can track moving subjects better and by identifying them, it can also automatically select focus points faster and with greater accuracy. It can also analyze highlights and more accurately determine exposure, as well as infer light sources to deliver more accurate white balance detection.&lt;/div&gt;\r\n&lt;/div&gt;\r\n&lt;!-- cpt_container_end --&gt;', '', '', '', '', ''),
(49, 2, 'Samsung Galaxy Tab 10.1', '&lt;p&gt;\r\n	Samsung Galaxy Tab 10.1, is the world&amp;rsquo;s thinnest tablet, measuring 8.6 mm thickness, running with Android 3.0 Honeycomb OS on a 1GHz dual-core Tegra 2 processor, similar to its younger brother Samsung Galaxy Tab 8.9.&lt;/p&gt;\r\n&lt;p&gt;\r\n	Samsung Galaxy Tab 10.1 gives pure Android 3.0 experience, adding its new TouchWiz UX or TouchWiz 4.0 &amp;ndash; includes a live panel, which lets you to customize with different content, such as your pictures, bookmarks, and social feeds, sporting a 10.1 inches WXGA capacitive touch screen with 1280 x 800 pixels of resolution, equipped with 3 megapixel rear camera with LED flash and a 2 megapixel front camera, HSPA+ connectivity up to 21Mbps, 720p HD video recording capability, 1080p HD playback, DLNA support, Bluetooth 2.1, USB 2.0, gyroscope, Wi-Fi 802.11 a/b/g/n, micro-SD slot, 3.5mm headphone jack, and SIM slot, including the Samsung Stick &amp;ndash; a Bluetooth microphone that can be carried in a pocket like a pen and sound dock with powered subwoofer.&lt;/p&gt;\r\n&lt;p&gt;\r\n	Samsung Galaxy Tab 10.1 will come in 16GB / 32GB / 64GB verities and pre-loaded with Social Hub, Reader&amp;rsquo;s Hub, Music Hub and Samsung Mini Apps Tray &amp;ndash; which gives you access to more commonly used apps to help ease multitasking and it is capable of Adobe Flash Player 10.2, powered by 6860mAh battery that gives you 10hours of video-playback time.&amp;nbsp;&amp;auml;&amp;ouml;&lt;/p&gt;\r\n', '', '', '', '', ''),
(42, 2, 'Apple Cinema 30&quot;', '&lt;p&gt;\r\n	&lt;font face=&quot;helvetica,geneva,arial&quot; size=&quot;2&quot;&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;The 30-inch Apple Cinema HD Display delivers an amazing 2560 x 1600 pixel resolution. Designed specifically for the creative professional, this display provides more space for easier access to all the tools and palettes needed to edit, format and composite your work. Combine this display with a Mac Pro, MacBook Pro, or PowerMac G5 and there&amp;#39;s no limit to what you can achieve. &lt;br /&gt;\r\n	&lt;br /&gt;\r\n	&lt;/font&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;The Cinema HD features an active-matrix liquid crystal display that produces flicker-free images that deliver twice the brightness, twice the sharpness and twice the contrast ratio of a typical CRT display. Unlike other flat panels, it&amp;#39;s designed with a pure digital interface to deliver distortion-free images that never need adjusting. With over 4 million digital pixels, the display is uniquely suited for scientific and technical applications such as visualizing molecular structures or analyzing geological data. &lt;br /&gt;\r\n	&lt;br /&gt;\r\n	&lt;/font&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;Offering accurate, brilliant color performance, the Cinema HD delivers up to 16.7 million colors across a wide gamut allowing you to see subtle nuances between colors from soft pastels to rich jewel tones. A wide viewing angle ensures uniform color from edge to edge. Apple&amp;#39;s ColorSync technology allows you to create custom profiles to maintain consistent color onscreen and in print. The result: You can confidently use this display in all your color-critical applications. &lt;br /&gt;\r\n	&lt;br /&gt;\r\n	&lt;/font&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;Housed in a new aluminum design, the display has a very thin bezel that enhances visual accuracy. Each display features two FireWire 400 ports and two USB 2.0 ports, making attachment of desktop peripherals, such as iSight, iPod, digital and still cameras, hard drives, printers and scanners, even more accessible and convenient. Taking advantage of the much thinner and lighter footprint of an LCD, the new displays support the VESA (Video Electronics Standards Association) mounting interface standard. Customers with the optional Cinema Display VESA Mount Adapter kit gain the flexibility to mount their display in locations most appropriate for their work environment. &lt;br /&gt;\r\n	&lt;br /&gt;\r\n	&lt;/font&gt;&lt;font face=&quot;Helvetica&quot; size=&quot;2&quot;&gt;The Cinema HD features a single cable design with elegant breakout for the USB 2.0, FireWire 400 and a pure digital connection using the industry standard Digital Video Interface (DVI) interface. The DVI connection allows for a direct pure-digital connection.&lt;br /&gt;\r\n	&lt;/font&gt;&lt;/font&gt;&lt;/p&gt;\r\n&lt;h3&gt;\r\n	Features:&lt;/h3&gt;\r\n&lt;p&gt;\r\n	Unrivaled display performance&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		30-inch (viewable) active-matrix liquid crystal display provides breathtaking image quality and vivid, richly saturated color.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Support for 2560-by-1600 pixel resolution for display of high definition still and video imagery.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Wide-format design for simultaneous display of two full pages of text and graphics.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Industry standard DVI connector for direct attachment to Mac- and Windows-based desktops and notebooks&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Incredibly wide (170 degree) horizontal and vertical viewing angle for maximum visibility and color performance.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Lightning-fast pixel response for full-motion digital video playback.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Support for 16.7 million saturated colors, for use in all graphics-intensive applications.&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	Simple setup and operation&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Single cable with elegant breakout for connection to DVI, USB and FireWire ports&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Built-in two-port USB 2.0 hub for easy connection of desktop peripheral devices.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Two FireWire 400 ports to support iSight and other desktop peripherals&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	Sleek, elegant design&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Huge virtual workspace, very small footprint.&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Narrow Bezel design to minimize visual impact of using dual displays&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Unique hinge design for effortless adjustment&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Support for VESA mounting solutions (Apple Cinema Display VESA Mount Adapter sold separately)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;h3&gt;\r\n	Technical specifications&lt;/h3&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Screen size (diagonal viewable image size)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Apple Cinema HD Display: 30 inches (29.7-inch viewable)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Screen type&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Thin film transistor (TFT) active-matrix liquid crystal display (AMLCD)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Resolutions&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		2560 x 1600 pixels (optimum resolution)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		2048 x 1280&lt;/li&gt;\r\n	&lt;li&gt;\r\n		1920 x 1200&lt;/li&gt;\r\n	&lt;li&gt;\r\n		1280 x 800&lt;/li&gt;\r\n	&lt;li&gt;\r\n		1024 x 640&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Display colors (maximum)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		16.7 million&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Viewing angle (typical)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		170&amp;deg; horizontal; 170&amp;deg; vertical&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Brightness (typical)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		30-inch Cinema HD Display: 400 cd/m2&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Contrast ratio (typical)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		700:1&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Response time (typical)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		16 ms&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Pixel pitch&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		30-inch Cinema HD Display: 0.250 mm&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Screen treatment&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Antiglare hardcoat&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;User controls (hardware and software)&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Display Power,&lt;/li&gt;\r\n	&lt;li&gt;\r\n		System sleep, wake&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Brightness&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Monitor tilt&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Connectors and cables&lt;/b&gt;&lt;br /&gt;\r\n	Cable&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		DVI (Digital Visual Interface)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		FireWire 400&lt;/li&gt;\r\n	&lt;li&gt;\r\n		USB 2.0&lt;/li&gt;\r\n	&lt;li&gt;\r\n		DC power (24 V)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	Connectors&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Two-port, self-powered USB 2.0 hub&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Two FireWire 400 ports&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Kensington security port&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;VESA mount adapter&lt;/b&gt;&lt;br /&gt;\r\n	Requires optional Cinema Display VESA Mount Adapter (M9649G/A)&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Compatible with VESA FDMI (MIS-D, 100, C) compliant mounting solutions&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Electrical requirements&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Input voltage: 100-240 VAC 50-60Hz&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Maximum power when operating: 150W&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Energy saver mode: 3W or less&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Environmental requirements&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Operating temperature: 50&amp;deg; to 95&amp;deg; F (10&amp;deg; to 35&amp;deg; C)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Storage temperature: -40&amp;deg; to 116&amp;deg; F (-40&amp;deg; to 47&amp;deg; C)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Operating humidity: 20% to 80% noncondensing&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Maximum operating altitude: 10,000 feet&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Agency approvals&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		FCC Part 15 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		EN55022 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		EN55024&lt;/li&gt;\r\n	&lt;li&gt;\r\n		VCCI Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		AS/NZS 3548 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		CNS 13438 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		ICES-003 Class B&lt;/li&gt;\r\n	&lt;li&gt;\r\n		ISO 13406 part 2&lt;/li&gt;\r\n	&lt;li&gt;\r\n		MPR II&lt;/li&gt;\r\n	&lt;li&gt;\r\n		IEC 60950&lt;/li&gt;\r\n	&lt;li&gt;\r\n		UL 60950&lt;/li&gt;\r\n	&lt;li&gt;\r\n		CSA 60950&lt;/li&gt;\r\n	&lt;li&gt;\r\n		EN60950&lt;/li&gt;\r\n	&lt;li&gt;\r\n		ENERGY STAR&lt;/li&gt;\r\n	&lt;li&gt;\r\n		TCO &amp;#39;03&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;Size and weight&lt;/b&gt;&lt;br /&gt;\r\n	30-inch Apple Cinema HD Display&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Height: 21.3 inches (54.3 cm)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Width: 27.2 inches (68.8 cm)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Depth: 8.46 inches (21.5 cm)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Weight: 27.5 pounds (12.5 kg)&lt;/li&gt;\r\n&lt;/ul&gt;\r\n&lt;p&gt;\r\n	&lt;b&gt;System Requirements&lt;/b&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Mac Pro, all graphic options&lt;/li&gt;\r\n	&lt;li&gt;\r\n		MacBook Pro&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Power Mac G5 (PCI-X) with ATI Radeon 9650 or better or NVIDIA GeForce 6800 GT DDL or better&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Power Mac G5 (PCI Express), all graphics options&lt;/li&gt;\r\n	&lt;li&gt;\r\n		PowerBook G4 with dual-link DVI support&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Windows PC and graphics card that supports DVI ports with dual-link digital bandwidth and VESA DDC standard for plug-and-play setup&lt;/li&gt;\r\n&lt;/ul&gt;\r\n', '', '', '', '', ''),
(30, 2, 'Canon EOS 5D', '&lt;p&gt;\r\n	Canon''s press material for the EOS 5D states that it ''defines (a) new D-SLR category'', while we''re not typically too concerned with marketing talk this particular statement is clearly pretty accurate. The EOS 5D is unlike any previous digital SLR in that it combines a full-frame (35 mm sized) high resolution sensor (12.8 megapixels) with a relatively compact body (slightly larger than the EOS 20D, although in your hand it feels noticeably ''chunkier''). The EOS 5D is aimed to slot in between the EOS 20D and the EOS-1D professional digital SLR''s, an important difference when compared to the latter is that the EOS 5D doesn''t have any environmental seals. While Canon don''t specifically refer to the EOS 5D as a ''professional'' digital SLR it will have obvious appeal to professionals who want a high quality digital SLR in a body lighter than the EOS-1D. It will also no doubt appeal to current EOS 20D owners (although lets hope they''ve not bought too many EF-S lenses...) ??&lt;/p&gt;\r\n', '', '', '', '', ''),
(64, 2, 'HTC Touch HD', '&lt;p&gt;\r\n	HTC Touch - in High Definition. Watch music videos and streaming content in awe-inspiring high definition clarity for a mobile experience you never thought possible. Seductively sleek, the HTC Touch HD provides the next generation of mobile functionality, all at a simple touch. Fully integrated with Windows Mobile Professional 6.1, ultrafast 3.5G, GPS, 5MP camera, plus lots more - all delivered on a breathtakingly crisp 3.8&amp;quot; WVGA touchscreen - you can take control of your mobile world with the HTC Touch HD.&lt;/p&gt;\r\n&lt;p&gt;\r\n	&lt;strong&gt;Features&lt;/strong&gt;&lt;/p&gt;\r\n&lt;ul&gt;\r\n	&lt;li&gt;\r\n		Processor Qualcomm&amp;reg; MSM 7201A&amp;trade; 528 MHz&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Windows Mobile&amp;reg; 6.1 Professional Operating System&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Memory: 512 MB ROM, 288 MB RAM&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Dimensions: 115 mm x 62.8 mm x 12 mm / 146.4 grams&lt;/li&gt;\r\n	&lt;li&gt;\r\n		3.8-inch TFT-LCD flat touch-sensitive screen with 480 x 800 WVGA resolution&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HSDPA/WCDMA: Europe/Asia: 900/2100 MHz; Up to 2 Mbps up-link and 7.2 Mbps down-link speeds&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Quad-band GSM/GPRS/EDGE: Europe/Asia: 850/900/1800/1900 MHz (Band frequency, HSUPA availability, and data speed are operator dependent.)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Device Control via HTC TouchFLO&amp;trade; 3D &amp;amp; Touch-sensitive front panel buttons&lt;/li&gt;\r\n	&lt;li&gt;\r\n		GPS and A-GPS ready&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Bluetooth&amp;reg; 2.0 with Enhanced Data Rate and A2DP for wireless stereo headsets&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Wi-Fi&amp;reg;: IEEE 802.11 b/g&lt;/li&gt;\r\n	&lt;li&gt;\r\n		HTC ExtUSB&amp;trade; (11-pin mini-USB 2.0)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		5 megapixel color camera with auto focus&lt;/li&gt;\r\n	&lt;li&gt;\r\n		VGA CMOS color camera&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Built-in 3.5 mm audio jack, microphone, speaker, and FM radio&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Ring tone formats: AAC, AAC+, eAAC+, AMR-NB, AMR-WB, QCP, MP3, WMA, WAV&lt;/li&gt;\r\n	&lt;li&gt;\r\n		40 polyphonic and standard MIDI format 0 and 1 (SMF)/SP MIDI&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Rechargeable Lithium-ion or Lithium-ion polymer 1350 mAh battery&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Expansion Slot: microSD&amp;trade; memory card (SD 2.0 compatible)&lt;/li&gt;\r\n	&lt;li&gt;\r\n		AC Adapter Voltage range/frequency: 100 ~ 240V AC, 50/60 Hz DC output: 5V and 1A&lt;/li&gt;\r\n	&lt;li&gt;\r\n		Special Features: FM Radio, G-Sensor&lt;/li&gt;\r\n&lt;/ul&gt;\r\n', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Структура таблицы `product_discount`
--

CREATE TABLE IF NOT EXISTS `product_discount` (
  `product_discount_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `customer_group_id` int(11) NOT NULL,
  `quantity` int(4) NOT NULL DEFAULT '0',
  `priority` int(5) NOT NULL DEFAULT '1',
  `price` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `date_start` date NOT NULL DEFAULT '0000-00-00',
  `date_end` date NOT NULL DEFAULT '0000-00-00'
) ENGINE=MyISAM AUTO_INCREMENT=441 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_discount`
--

INSERT INTO `product_discount` (`product_discount_id`, `product_id`, `customer_group_id`, `quantity`, `priority`, `price`, `date_start`, `date_end`) VALUES
(440, 42, 1, 30, 1, '66.0000', '0000-00-00', '0000-00-00'),
(439, 42, 1, 20, 1, '77.0000', '0000-00-00', '0000-00-00'),
(438, 42, 1, 10, 1, '88.0000', '0000-00-00', '0000-00-00');

-- --------------------------------------------------------

--
-- Структура таблицы `product_image`
--

CREATE TABLE IF NOT EXISTS `product_image` (
  `product_image_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `image` varchar(255) DEFAULT NULL,
  `sort_order` int(3) NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=2352 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_image`
--

INSERT INTO `product_image` (`product_image_id`, `product_id`, `image`, `sort_order`) VALUES
(2345, 30, 'data/demo/canon_eos_5d_2.jpg', 0),
(2321, 47, 'data/demo/hp_3.jpg', 0),
(2035, 28, 'data/demo/htc_touch_hd_2.jpg', 0),
(2351, 41, 'data/demo/imac_3.jpg', 0),
(1982, 40, 'data/demo/iphone_6.jpg', 0),
(2001, 36, 'data/demo/ipod_nano_5.jpg', 0),
(2000, 36, 'data/demo/ipod_nano_4.jpg', 0),
(2005, 34, 'data/demo/ipod_shuffle_5.jpg', 0),
(2004, 34, 'data/demo/ipod_shuffle_4.jpg', 0),
(2011, 32, 'data/demo/ipod_touch_7.jpg', 0),
(2010, 32, 'data/demo/ipod_touch_6.jpg', 0),
(2009, 32, 'data/demo/ipod_touch_5.jpg', 0),
(1971, 43, 'data/demo/macbook_5.jpg', 0),
(1970, 43, 'data/demo/macbook_4.jpg', 0),
(1974, 44, 'data/demo/macbook_air_4.jpg', 0),
(1973, 44, 'data/demo/macbook_air_2.jpg', 0),
(1977, 45, 'data/demo/macbook_pro_2.jpg', 0),
(1976, 45, 'data/demo/macbook_pro_3.jpg', 0),
(1986, 31, 'data/demo/nikon_d300_3.jpg', 0),
(1985, 31, 'data/demo/nikon_d300_2.jpg', 0),
(1988, 29, 'data/demo/palm_treo_pro_3.jpg', 0),
(1995, 46, 'data/demo/sony_vaio_5.jpg', 0),
(1994, 46, 'data/demo/sony_vaio_4.jpg', 0),
(1991, 48, 'data/demo/ipod_classic_4.jpg', 0),
(1990, 48, 'data/demo/ipod_classic_3.jpg', 0),
(1981, 40, 'data/demo/iphone_2.jpg', 0),
(1980, 40, 'data/demo/iphone_5.jpg', 0),
(2344, 30, 'data/demo/canon_eos_5d_3.jpg', 0),
(2320, 47, 'data/demo/hp_2.jpg', 0),
(2034, 28, 'data/demo/htc_touch_hd_3.jpg', 0),
(2350, 41, 'data/demo/imac_2.jpg', 0),
(1979, 40, 'data/demo/iphone_3.jpg', 0),
(1978, 40, 'data/demo/iphone_4.jpg', 0),
(1989, 48, 'data/demo/ipod_classic_2.jpg', 0),
(1999, 36, 'data/demo/ipod_nano_2.jpg', 0),
(1998, 36, 'data/demo/ipod_nano_3.jpg', 0),
(2003, 34, 'data/demo/ipod_shuffle_2.jpg', 0),
(2002, 34, 'data/demo/ipod_shuffle_3.jpg', 0),
(2008, 32, 'data/demo/ipod_touch_2.jpg', 0),
(2007, 32, 'data/demo/ipod_touch_3.jpg', 0),
(2006, 32, 'data/demo/ipod_touch_4.jpg', 0),
(1969, 43, 'data/demo/macbook_2.jpg', 0),
(1968, 43, 'data/demo/macbook_3.jpg', 0),
(1972, 44, 'data/demo/macbook_air_3.jpg', 0),
(1975, 45, 'data/demo/macbook_pro_4.jpg', 0),
(1984, 31, 'data/demo/nikon_d300_4.jpg', 0),
(1983, 31, 'data/demo/nikon_d300_5.jpg', 0),
(1987, 29, 'data/demo/palm_treo_pro_2.jpg', 0),
(1993, 46, 'data/demo/sony_vaio_2.jpg', 0),
(1992, 46, 'data/demo/sony_vaio_3.jpg', 0),
(2327, 49, 'data/demo/samsung_tab_7.jpg', 0),
(2326, 49, 'data/demo/samsung_tab_6.jpg', 0),
(2325, 49, 'data/demo/samsung_tab_5.jpg', 0),
(2324, 49, 'data/demo/samsung_tab_4.jpg', 0),
(2323, 49, 'data/demo/samsung_tab_3.jpg', 0),
(2322, 49, 'data/demo/samsung_tab_2.jpg', 0),
(2317, 42, 'data/demo/canon_logo.jpg', 0),
(2316, 42, 'data/demo/hp_1.jpg', 0),
(2315, 42, 'data/demo/compaq_presario.jpg', 0),
(2314, 42, 'data/demo/canon_eos_5d_1.jpg', 0),
(2313, 42, 'data/demo/canon_eos_5d_2.jpg', 0),
(2275, 64, 'data/demo/htc_touch_hd_2.jpg', 0),
(2276, 64, 'data/demo/htc_touch_hd_3.jpg', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `product_option`
--

CREATE TABLE IF NOT EXISTS `product_option` (
  `product_option_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `option_id` int(11) NOT NULL,
  `option_value` text NOT NULL,
  `required` tinyint(1) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=227 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_option`
--

INSERT INTO `product_option` (`product_option_id`, `product_id`, `option_id`, `option_value`, `required`) VALUES
(224, 35, 11, '', 1),
(225, 47, 12, '2011-04-22', 1),
(223, 42, 2, '', 1),
(217, 42, 5, '', 1),
(209, 42, 6, '', 1),
(218, 42, 1, '', 1),
(208, 42, 4, 'test', 1),
(219, 42, 8, '2011-02-20', 1),
(222, 42, 7, '', 1),
(221, 42, 9, '22:25', 1),
(220, 42, 10, '2011-02-20 22:25', 1),
(226, 30, 5, '', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `product_option_value`
--

CREATE TABLE IF NOT EXISTS `product_option_value` (
  `product_option_value_id` int(11) NOT NULL,
  `product_option_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `option_id` int(11) NOT NULL,
  `option_value_id` int(11) NOT NULL,
  `quantity` int(3) NOT NULL,
  `subtract` tinyint(1) NOT NULL,
  `price` decimal(15,4) NOT NULL,
  `price_prefix` varchar(1) NOT NULL,
  `points` int(8) NOT NULL,
  `points_prefix` varchar(1) NOT NULL,
  `weight` decimal(15,8) NOT NULL,
  `weight_prefix` varchar(1) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_option_value`
--

INSERT INTO `product_option_value` (`product_option_value_id`, `product_option_id`, `product_id`, `option_id`, `option_value_id`, `quantity`, `subtract`, `price`, `price_prefix`, `points`, `points_prefix`, `weight`, `weight_prefix`) VALUES
(1, 217, 42, 5, 41, 100, 0, '1.0000', '+', 0, '+', '1.00000000', '+'),
(6, 218, 42, 1, 31, 146, 1, '20.0000', '+', 2, '-', '20.00000000', '+'),
(7, 218, 42, 1, 43, 300, 1, '30.0000', '+', 3, '+', '30.00000000', '+'),
(5, 218, 42, 1, 32, 96, 1, '10.0000', '+', 1, '+', '10.00000000', '+'),
(4, 217, 42, 5, 39, 92, 1, '4.0000', '+', 0, '+', '4.00000000', '+'),
(2, 217, 42, 5, 42, 200, 1, '2.0000', '+', 0, '+', '2.00000000', '+'),
(3, 217, 42, 5, 40, 300, 0, '3.0000', '+', 0, '+', '3.00000000', '+'),
(8, 223, 42, 2, 23, 48, 1, '10.0000', '+', 0, '+', '10.00000000', '+'),
(10, 223, 42, 2, 44, 2696, 1, '30.0000', '+', 0, '+', '30.00000000', '+'),
(9, 223, 42, 2, 24, 194, 1, '20.0000', '+', 0, '+', '20.00000000', '+'),
(11, 223, 42, 2, 45, 3998, 1, '40.0000', '+', 0, '+', '40.00000000', '+'),
(12, 224, 35, 11, 46, 0, 1, '5.0000', '+', 0, '+', '0.00000000', '+'),
(13, 224, 35, 11, 47, 10, 1, '10.0000', '+', 0, '+', '0.00000000', '+'),
(14, 224, 35, 11, 48, 15, 1, '15.0000', '+', 0, '+', '0.00000000', '+'),
(16, 226, 30, 5, 40, 5, 1, '0.0000', '+', 0, '+', '0.00000000', '+'),
(15, 226, 30, 5, 39, 2, 1, '0.0000', '+', 0, '+', '0.00000000', '+');

-- --------------------------------------------------------

--
-- Структура таблицы `product_related`
--

CREATE TABLE IF NOT EXISTS `product_related` (
  `product_id` int(11) NOT NULL,
  `related_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_related`
--

INSERT INTO `product_related` (`product_id`, `related_id`) VALUES
(40, 42),
(41, 42),
(42, 40),
(42, 41);

-- --------------------------------------------------------

--
-- Структура таблицы `product_reward`
--

CREATE TABLE IF NOT EXISTS `product_reward` (
  `product_reward_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL DEFAULT '0',
  `customer_group_id` int(11) NOT NULL DEFAULT '0',
  `points` int(8) NOT NULL DEFAULT '0'
) ENGINE=MyISAM AUTO_INCREMENT=546 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_reward`
--

INSERT INTO `product_reward` (`product_reward_id`, `product_id`, `customer_group_id`, `points`) VALUES
(515, 42, 1, 100),
(519, 47, 1, 300),
(379, 28, 1, 400),
(329, 43, 1, 600),
(339, 29, 1, 0),
(343, 48, 1, 0),
(335, 40, 1, 0),
(539, 30, 1, 200),
(331, 44, 1, 700),
(333, 45, 1, 800),
(337, 31, 1, 0),
(425, 35, 1, 0),
(345, 33, 1, 0),
(347, 46, 1, 0),
(545, 41, 1, 0),
(351, 36, 1, 0),
(353, 34, 1, 0),
(355, 32, 1, 0),
(521, 49, 1, 1000);

-- --------------------------------------------------------

--
-- Структура таблицы `product_special`
--

CREATE TABLE IF NOT EXISTS `product_special` (
  `product_special_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `customer_group_id` int(11) NOT NULL,
  `priority` int(5) NOT NULL DEFAULT '1',
  `price` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `date_start` date NOT NULL DEFAULT '0000-00-00',
  `date_end` date NOT NULL DEFAULT '0000-00-00'
) ENGINE=MyISAM AUTO_INCREMENT=440 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_special`
--

INSERT INTO `product_special` (`product_special_id`, `product_id`, `customer_group_id`, `priority`, `price`, `date_start`, `date_end`) VALUES
(419, 42, 1, 1, '90.0000', '0000-00-00', '0000-00-00'),
(439, 30, 1, 2, '90.0000', '0000-00-00', '0000-00-00'),
(438, 30, 1, 1, '80.0000', '0000-00-00', '0000-00-00');

-- --------------------------------------------------------

--
-- Структура таблицы `product_to_category`
--

CREATE TABLE IF NOT EXISTS `product_to_category` (
  `product_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `main_category` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_to_category`
--

INSERT INTO `product_to_category` (`product_id`, `category_id`, `main_category`) VALUES
(28, 20, 0),
(28, 24, 0),
(29, 20, 0),
(29, 24, 0),
(30, 20, 0),
(30, 33, 0),
(31, 33, 0),
(32, 34, 0),
(33, 20, 0),
(33, 28, 0),
(34, 34, 0),
(35, 20, 0),
(36, 34, 0),
(40, 20, 0),
(40, 24, 0),
(41, 27, 0),
(42, 20, 0),
(42, 28, 0),
(43, 18, 0),
(43, 20, 0),
(44, 18, 0),
(44, 20, 0),
(45, 18, 0),
(46, 18, 0),
(46, 20, 0),
(47, 18, 0),
(47, 20, 0),
(48, 20, 0),
(48, 34, 0),
(49, 57, 0),
(64, 20, 0),
(64, 24, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `product_to_download`
--

CREATE TABLE IF NOT EXISTS `product_to_download` (
  `product_id` int(11) NOT NULL,
  `download_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `product_to_layout`
--

CREATE TABLE IF NOT EXISTS `product_to_layout` (
  `product_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL,
  `layout_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `product_to_store`
--

CREATE TABLE IF NOT EXISTS `product_to_store` (
  `product_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_to_store`
--

INSERT INTO `product_to_store` (`product_id`, `store_id`) VALUES
(28, 0),
(29, 0),
(30, 0),
(31, 0),
(32, 0),
(33, 0),
(34, 0),
(35, 0),
(36, 0),
(40, 0),
(41, 0),
(42, 0),
(43, 0),
(44, 0),
(45, 0),
(46, 0),
(47, 0),
(48, 0),
(49, 0),
(64, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `return`
--

CREATE TABLE IF NOT EXISTS `return` (
  `return_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `firstname` varchar(32) NOT NULL,
  `lastname` varchar(32) NOT NULL,
  `email` varchar(96) NOT NULL,
  `telephone` varchar(32) NOT NULL,
  `product` varchar(255) NOT NULL,
  `model` varchar(64) NOT NULL,
  `quantity` int(4) NOT NULL,
  `opened` tinyint(1) NOT NULL,
  `return_reason_id` int(11) NOT NULL,
  `return_action_id` int(11) NOT NULL,
  `return_status_id` int(11) NOT NULL,
  `comment` text,
  `date_ordered` date NOT NULL,
  `date_added` datetime NOT NULL,
  `date_modified` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `return_action`
--

CREATE TABLE IF NOT EXISTS `return_action` (
  `return_action_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(64) NOT NULL DEFAULT ''
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `return_action`
--

INSERT INTO `return_action` (`return_action_id`, `language_id`, `name`) VALUES
(1, 1, 'Refunded'),
(2, 1, 'Credit Issued'),
(3, 1, 'Replacement Sent'),
(1, 2, 'Refunded'),
(2, 2, 'Credit Issued'),
(3, 2, 'Replacement Sent');

-- --------------------------------------------------------

--
-- Структура таблицы `return_history`
--

CREATE TABLE IF NOT EXISTS `return_history` (
  `return_history_id` int(11) NOT NULL,
  `return_id` int(11) NOT NULL,
  `return_status_id` int(11) NOT NULL,
  `notify` tinyint(1) NOT NULL,
  `comment` text NOT NULL,
  `date_added` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `return_reason`
--

CREATE TABLE IF NOT EXISTS `return_reason` (
  `return_reason_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(128) NOT NULL DEFAULT ''
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `return_reason`
--

INSERT INTO `return_reason` (`return_reason_id`, `language_id`, `name`) VALUES
(1, 1, 'Dead On Arrival'),
(2, 1, 'Received Wrong Item'),
(3, 1, 'Order Error'),
(4, 1, 'Faulty, please supply details'),
(5, 1, 'Other, please supply details'),
(1, 2, 'Dead On Arrival'),
(2, 2, 'Received Wrong Item'),
(3, 2, 'Order Error'),
(4, 2, 'Faulty, please supply details'),
(5, 2, 'Other, please supply details');

-- --------------------------------------------------------

--
-- Структура таблицы `return_status`
--

CREATE TABLE IF NOT EXISTS `return_status` (
  `return_status_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(32) NOT NULL DEFAULT ''
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `return_status`
--

INSERT INTO `return_status` (`return_status_id`, `language_id`, `name`) VALUES
(1, 1, 'Pending'),
(3, 1, 'Complete'),
(2, 1, 'Awaiting Products'),
(1, 2, 'Pending'),
(3, 2, 'Complete'),
(2, 2, 'Awaiting Products');

-- --------------------------------------------------------

--
-- Структура таблицы `review`
--

CREATE TABLE IF NOT EXISTS `review` (
  `review_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `author` varchar(64) NOT NULL DEFAULT '',
  `text` text NOT NULL,
  `rating` int(1) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT '0',
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `date_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `setting`
--

CREATE TABLE IF NOT EXISTS `setting` (
  `setting_id` int(11) NOT NULL,
  `store_id` int(11) NOT NULL DEFAULT '0',
  `group` varchar(32) NOT NULL,
  `key` varchar(64) NOT NULL DEFAULT '',
  `value` text NOT NULL,
  `serialized` tinyint(1) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=542 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `setting`
--

INSERT INTO `setting` (`setting_id`, `store_id`, `group`, `key`, `value`, `serialized`) VALUES
(1, 0, 'shipping', 'shipping_sort_order', '3', 0),
(2, 0, 'sub_total', 'sub_total_sort_order', '1', 0),
(3, 0, 'sub_total', 'sub_total_status', '1', 0),
(4, 0, 'tax', 'tax_status', '1', 0),
(5, 0, 'total', 'total_sort_order', '9', 0),
(6, 0, 'total', 'total_status', '1', 0),
(7, 0, 'tax', 'tax_sort_order', '5', 0),
(8, 0, 'free_checkout', 'free_checkout_sort_order', '1', 0),
(9, 0, 'cod', 'cod_sort_order', '5', 0),
(10, 0, 'cod', 'cod_total', '0.01', 0),
(11, 0, 'cod', 'cod_order_status_id', '1', 0),
(12, 0, 'cod', 'cod_geo_zone_id', '0', 0),
(13, 0, 'cod', 'cod_status', '1', 0),
(14, 0, 'shipping', 'shipping_status', '1', 0),
(15, 0, 'shipping', 'shipping_estimator', '1', 0),
(538, 0, 'config', 'config_error_display', '1', 0),
(537, 0, 'config', 'config_compression', '0', 0),
(536, 0, 'config', 'config_encryption', '028aefe7f6e5054ba5d297d66ac365d9', 0),
(534, 0, 'config', 'config_seo_url_postfix', '/', 0),
(535, 0, 'config', 'config_maintenance', '0', 0),
(533, 0, 'config', 'config_seo_url_include_path', '0', 0),
(27, 0, 'coupon', 'coupon_sort_order', '4', 0),
(28, 0, 'coupon', 'coupon_status', '1', 0),
(532, 0, 'config', 'config_seo_url_type', 'seo_url', 0),
(531, 0, 'config', 'config_seo_url', '0', 0),
(530, 0, 'config', 'config_use_ssl', '0', 0),
(34, 0, 'flat', 'flat_sort_order', '1', 0),
(35, 0, 'flat', 'flat_status', '1', 0),
(36, 0, 'flat', 'flat_geo_zone_id', '0', 0),
(37, 0, 'flat', 'flat_tax_class_id', '9', 0),
(38, 0, 'carousel', 'carousel_module', 'a:1:{i:0;a:9:{s:9:"banner_id";s:1:"8";s:5:"limit";s:1:"5";s:6:"scroll";s:1:"3";s:5:"width";s:2:"80";s:6:"height";s:2:"80";s:9:"layout_id";s:1:"1";s:8:"position";s:14:"content_bottom";s:6:"status";s:1:"1";s:10:"sort_order";s:2:"-1";}}', 1),
(39, 0, 'featured', 'featured_product', '43,40,42,49,46,47,28', 0),
(40, 0, 'featured', 'featured_module', 'a:1:{i:0;a:7:{s:5:"limit";s:1:"6";s:11:"image_width";s:2:"80";s:12:"image_height";s:2:"80";s:9:"layout_id";s:1:"1";s:8:"position";s:11:"content_top";s:6:"status";s:1:"1";s:10:"sort_order";s:1:"2";}}', 1),
(41, 0, 'flat', 'flat_cost', '5.00', 0),
(42, 0, 'credit', 'credit_sort_order', '7', 0),
(43, 0, 'credit', 'credit_status', '1', 0),
(529, 0, 'config', 'config_sms_gate_password', '', 0),
(528, 0, 'config', 'config_sms_gate_username', '', 0),
(526, 0, 'config', 'config_sms_copy', '', 0),
(527, 0, 'config', 'config_sms_message', '', 0),
(525, 0, 'config', 'config_sms_to', '', 0),
(524, 0, 'config', 'config_sms_from', '', 0),
(523, 0, 'config', 'config_sms_gatename', 'testsms', 0),
(53, 0, 'reward', 'reward_sort_order', '2', 0),
(54, 0, 'reward', 'reward_status', '1', 0),
(522, 0, 'config', 'config_sms_alert', '0', 0),
(56, 0, 'affiliate', 'affiliate_module', 'a:1:{i:0;a:4:{s:9:"layout_id";s:2:"10";s:8:"position";s:12:"column_right";s:6:"status";s:1:"1";s:10:"sort_order";s:1:"1";}}', 1),
(57, 0, 'category', 'category_module', 'a:2:{i:0;a:5:{s:9:"layout_id";s:1:"3";s:8:"position";s:11:"column_left";s:5:"count";s:1:"0";s:6:"status";s:1:"1";s:10:"sort_order";s:1:"1";}i:1;a:5:{s:9:"layout_id";s:1:"2";s:8:"position";s:11:"column_left";s:5:"count";s:1:"0";s:6:"status";s:1:"1";s:10:"sort_order";s:1:"1";}}', 1),
(521, 0, 'config', 'config_fraud_status_id', '14', 0),
(520, 0, 'config', 'config_fraud_score', '', 0),
(60, 0, 'account', 'account_module', 'a:1:{i:0;a:4:{s:9:"layout_id";s:1:"6";s:8:"position";s:12:"column_right";s:6:"status";s:1:"1";s:10:"sort_order";s:1:"1";}}', 1),
(519, 0, 'config', 'config_fraud_key', '', 0),
(518, 0, 'config', 'config_fraud_detection', '0', 0),
(517, 0, 'config', 'config_alert_emails', '', 0),
(516, 0, 'config', 'config_account_mail', '0', 0),
(515, 0, 'config', 'config_alert_mail', '0', 0),
(514, 0, 'config', 'config_smtp_timeout', '5', 0),
(509, 0, 'config', 'config_mail_parameter', '', 0),
(510, 0, 'config', 'config_smtp_host', '', 0),
(511, 0, 'config', 'config_smtp_username', '', 0),
(512, 0, 'config', 'config_smtp_password', '', 0),
(513, 0, 'config', 'config_smtp_port', '25', 0),
(508, 0, 'config', 'config_mail_protocol', 'mail', 0),
(507, 0, 'config', 'config_image_cart_height', '47', 0),
(506, 0, 'config', 'config_image_cart_width', '47', 0),
(505, 0, 'config', 'config_image_wishlist_height', '47', 0),
(504, 0, 'config', 'config_image_wishlist_width', '47', 0),
(503, 0, 'config', 'config_image_compare_height', '90', 0),
(502, 0, 'config', 'config_image_compare_width', '90', 0),
(501, 0, 'config', 'config_image_related_height', '80', 0),
(500, 0, 'config', 'config_image_related_width', '80', 0),
(499, 0, 'config', 'config_image_additional_height', '74', 0),
(498, 0, 'config', 'config_image_additional_width', '74', 0),
(93, 0, 'voucher', 'voucher_sort_order', '8', 0),
(94, 0, 'voucher', 'voucher_status', '1', 0),
(497, 0, 'config', 'config_image_product_height', '80', 0),
(496, 0, 'config', 'config_image_product_width', '80', 0),
(495, 0, 'config', 'config_image_popup_height', '500', 0),
(102, 0, 'free_checkout', 'free_checkout_status', '1', 0),
(103, 0, 'free_checkout', 'free_checkout_order_status_id', '1', 0),
(494, 0, 'config', 'config_image_popup_width', '500', 0),
(493, 0, 'config', 'config_image_thumb_height', '228', 0),
(107, 0, 'slideshow', 'slideshow_module', 'a:1:{i:0;a:7:{s:9:"banner_id";s:1:"7";s:5:"width";s:3:"980";s:6:"height";s:3:"280";s:9:"layout_id";s:1:"1";s:8:"position";s:11:"content_top";s:6:"status";s:1:"1";s:10:"sort_order";s:1:"1";}}', 1),
(108, 0, 'banner', 'banner_module', 'a:1:{i:0;a:7:{s:9:"banner_id";s:1:"6";s:5:"width";s:3:"182";s:6:"height";s:3:"182";s:9:"layout_id";s:1:"3";s:8:"position";s:11:"column_left";s:6:"status";s:1:"1";s:10:"sort_order";s:1:"3";}}', 1),
(492, 0, 'config', 'config_image_thumb_width', '228', 0),
(491, 0, 'config', 'config_image_category_height', '80', 0),
(490, 0, 'config', 'config_image_category_width', '80', 0),
(489, 0, 'config', 'config_icon', 'data/cart.png', 0),
(488, 0, 'config', 'config_logo', 'data/logo.png', 0),
(484, 0, 'config', 'config_stock_status_id', '5', 0),
(485, 0, 'config', 'config_affiliate_id', '4', 0),
(486, 0, 'config', 'config_commission', '5', 0),
(487, 0, 'config', 'config_return_status_id', '2', 0),
(483, 0, 'config', 'config_stock_checkout', '0', 0),
(482, 0, 'config', 'config_stock_warning', '0', 0),
(481, 0, 'config', 'config_stock_display', '0', 0),
(479, 0, 'config', 'config_order_status_id', '1', 0),
(480, 0, 'config', 'config_complete_status_id', '5', 0),
(477, 0, 'config', 'config_order_edit', '100', 0),
(478, 0, 'config', 'config_invoice_prefix', 'INV-2012-00', 0),
(476, 0, 'config', 'config_checkout_id', '5', 0),
(475, 0, 'config', 'config_guest_checkout', '1', 0),
(474, 0, 'config', 'config_cart_weight', '1', 0),
(473, 0, 'config', 'config_account_id', '3', 0),
(472, 0, 'config', 'config_customer_price', '0', 0),
(471, 0, 'config', 'config_customer_group_display', 'a:1:{i:0;s:1:"1";}', 1),
(470, 0, 'config', 'config_customer_group_id', '1', 0),
(469, 0, 'config', 'config_customer_online', '0', 0),
(468, 0, 'config', 'config_tax_customer', 'shipping', 0),
(466, 0, 'config', 'config_vat', '0', 0),
(467, 0, 'config', 'config_tax_default', 'shipping', 0),
(465, 0, 'config', 'config_tax', '1', 0),
(464, 0, 'config', 'config_voucher_max', '1000', 0),
(462, 0, 'config', 'config_upload_allowed', 'jpg, JPG, jpeg, gif, png, txt', 0),
(463, 0, 'config', 'config_voucher_min', '1', 0),
(461, 0, 'config', 'config_download', '1', 0),
(460, 0, 'config', 'config_review_status', '1', 0),
(459, 0, 'config', 'config_product_count', '0', 0),
(458, 0, 'config', 'config_admin_limit', '20', 0),
(456, 0, 'config', 'config_weight_class_id', '1', 0),
(457, 0, 'config', 'config_catalog_limit', '15', 0),
(454, 0, 'config', 'config_currency_auto', '1', 0),
(455, 0, 'config', 'config_length_class_id', '1', 0),
(452, 0, 'config', 'config_admin_language', 'ru', 0),
(453, 0, 'config', 'config_currency', 'RUB', 0),
(451, 0, 'config', 'config_language', 'ru', 0),
(450, 0, 'config', 'config_zone_id', '2761', 0),
(448, 0, 'config', 'config_layout_id', '4', 0),
(449, 0, 'config', 'config_country_id', '176', 0),
(447, 0, 'config', 'config_template', 'palioxis', 0),
(446, 0, 'config', 'config_meta_description', 'Мой Магазин', 0),
(445, 0, 'config', 'config_title', 'Мой Магазин', 0),
(444, 0, 'config', 'config_fax', '', 0),
(443, 0, 'config', 'config_telephone', '123456789', 0),
(442, 0, 'config', 'config_email', 't.motanin@demis.ru', 0),
(441, 0, 'config', 'config_address', 'Адрес', 0),
(440, 0, 'config', 'config_owner', 'Demis', 0),
(439, 0, 'config', 'config_name', 'Demis test', 0),
(539, 0, 'config', 'config_error_log', '1', 0),
(540, 0, 'config', 'config_error_filename', 'error.txt', 0),
(541, 0, 'config', 'config_google_analytics', '', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `stock_status`
--

CREATE TABLE IF NOT EXISTS `stock_status` (
  `stock_status_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `stock_status`
--

INSERT INTO `stock_status` (`stock_status_id`, `language_id`, `name`) VALUES
(7, 1, 'В наличии'),
(8, 1, 'Предзаказ'),
(5, 1, 'Нет в наличии'),
(6, 1, 'Ожидание 2-3 дня'),
(7, 2, 'In Stock'),
(8, 2, 'Pre-Order'),
(5, 2, 'Out Of Stock'),
(6, 2, '2 - 3 Days');

-- --------------------------------------------------------

--
-- Структура таблицы `store`
--

CREATE TABLE IF NOT EXISTS `store` (
  `store_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL,
  `url` varchar(255) NOT NULL,
  `ssl` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `tax_class`
--

CREATE TABLE IF NOT EXISTS `tax_class` (
  `tax_class_id` int(11) NOT NULL,
  `title` varchar(32) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `date_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tax_class`
--

INSERT INTO `tax_class` (`tax_class_id`, `title`, `description`, `date_added`, `date_modified`) VALUES
(9, 'Налоги', 'Облагаемые налогом', '2009-01-06 23:21:53', '2011-03-09 21:17:10');

-- --------------------------------------------------------

--
-- Структура таблицы `tax_rate`
--

CREATE TABLE IF NOT EXISTS `tax_rate` (
  `tax_rate_id` int(11) NOT NULL,
  `geo_zone_id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(32) NOT NULL,
  `rate` decimal(15,4) NOT NULL DEFAULT '0.0000',
  `type` char(1) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `date_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM AUTO_INCREMENT=88 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tax_rate`
--

INSERT INTO `tax_rate` (`tax_rate_id`, `geo_zone_id`, `name`, `rate`, `type`, `date_added`, `date_modified`) VALUES
(86, 3, 'НДС 18%', '18.0000', 'P', '2011-03-09 21:17:10', '2011-09-22 22:24:29'),
(87, 3, 'Eco Tax (-2.00)', '2.0000', 'F', '2011-09-21 21:49:23', '2011-09-23 00:40:19');

-- --------------------------------------------------------

--
-- Структура таблицы `tax_rate_to_customer_group`
--

CREATE TABLE IF NOT EXISTS `tax_rate_to_customer_group` (
  `tax_rate_id` int(11) NOT NULL,
  `customer_group_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tax_rate_to_customer_group`
--

INSERT INTO `tax_rate_to_customer_group` (`tax_rate_id`, `customer_group_id`) VALUES
(86, 1),
(87, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `tax_rule`
--

CREATE TABLE IF NOT EXISTS `tax_rule` (
  `tax_rule_id` int(11) NOT NULL,
  `tax_class_id` int(11) NOT NULL,
  `tax_rate_id` int(11) NOT NULL,
  `based` varchar(10) NOT NULL,
  `priority` int(5) NOT NULL DEFAULT '1'
) ENGINE=MyISAM AUTO_INCREMENT=129 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tax_rule`
--

INSERT INTO `tax_rule` (`tax_rule_id`, `tax_class_id`, `tax_rate_id`, `based`, `priority`) VALUES
(121, 10, 86, 'payment', 1),
(120, 10, 87, 'store', 0),
(128, 9, 86, 'shipping', 1),
(127, 9, 87, 'shipping', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `url_alias`
--

CREATE TABLE IF NOT EXISTS `url_alias` (
  `url_alias_id` int(11) NOT NULL,
  `query` varchar(255) NOT NULL,
  `keyword` varchar(255) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=777 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `url_alias`
--

INSERT INTO `url_alias` (`url_alias_id`, `query`, `keyword`) VALUES
(704, 'product_id=48', 'ipod_classic'),
(773, 'category_id=20', 'desktops'),
(503, 'category_id=26', 'pc'),
(505, 'category_id=27', 'mac'),
(730, 'manufacturer_id=8', 'apple'),
(776, 'information_id=4', 'about_us'),
(768, 'product_id=42', 'test'),
(767, 'category_id=34', 'mp3-players'),
(536, 'category_id=36', 'Normal');

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(11) NOT NULL,
  `user_group_id` int(11) NOT NULL,
  `username` varchar(20) NOT NULL DEFAULT '',
  `password` varchar(40) NOT NULL DEFAULT '',
  `salt` varchar(9) NOT NULL DEFAULT '',
  `firstname` varchar(32) NOT NULL DEFAULT '',
  `lastname` varchar(32) NOT NULL DEFAULT '',
  `email` varchar(96) NOT NULL DEFAULT '',
  `code` varchar(32) NOT NULL,
  `ip` varchar(40) NOT NULL DEFAULT '',
  `status` tinyint(1) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`user_id`, `user_group_id`, `username`, `password`, `salt`, `firstname`, `lastname`, `email`, `code`, `ip`, `status`, `date_added`) VALUES
(1, 1, 'admin', '785ef32a1237ecbd75964f26b198f2621bc5a1f0', '6059a68c6', '', '', 't.motanin@demis.ru', '', '127.0.0.1', 1, '2013-06-03 11:06:35');

-- --------------------------------------------------------

--
-- Структура таблицы `user_group`
--

CREATE TABLE IF NOT EXISTS `user_group` (
  `user_group_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL,
  `permission` text NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `user_group`
--

INSERT INTO `user_group` (`user_group_id`, `name`, `permission`) VALUES
(1, 'Главный администратор', 'a:2:{s:6:"access";a:119:{i:0;s:17:"catalog/attribute";i:1;s:23:"catalog/attribute_group";i:2;s:16:"catalog/category";i:3;s:16:"catalog/download";i:4;s:19:"catalog/information";i:5;s:20:"catalog/manufacturer";i:6;s:14:"catalog/option";i:7;s:15:"catalog/product";i:8;s:14:"catalog/review";i:9;s:18:"common/filemanager";i:10;s:13:"design/banner";i:11;s:13:"design/layout";i:12;s:14:"extension/feed";i:13;s:16:"extension/module";i:14;s:17:"extension/payment";i:15;s:18:"extension/shipping";i:16;s:15:"extension/total";i:17;s:16:"feed/google_base";i:18;s:19:"feed/google_sitemap";i:19;s:20:"localisation/country";i:20;s:21:"localisation/currency";i:21;s:21:"localisation/geo_zone";i:22;s:21:"localisation/language";i:23;s:25:"localisation/length_class";i:24;s:25:"localisation/order_status";i:25;s:26:"localisation/return_action";i:26;s:26:"localisation/return_reason";i:27;s:26:"localisation/return_status";i:28;s:25:"localisation/stock_status";i:29;s:22:"localisation/tax_class";i:30;s:21:"localisation/tax_rate";i:31;s:25:"localisation/weight_class";i:32;s:17:"localisation/zone";i:33;s:14:"module/account";i:34;s:16:"module/affiliate";i:35;s:13:"module/banner";i:36;s:17:"module/bestseller";i:37;s:15:"module/carousel";i:38;s:15:"module/category";i:39;s:15:"module/featured";i:40;s:18:"module/google_talk";i:41;s:18:"module/information";i:42;s:13:"module/latest";i:43;s:16:"module/slideshow";i:44;s:14:"module/special";i:45;s:12:"module/store";i:46;s:14:"module/welcome";i:47;s:24:"payment/authorizenet_aim";i:48;s:21:"payment/bank_transfer";i:49;s:14:"payment/cheque";i:50;s:11:"payment/cod";i:51;s:21:"payment/free_checkout";i:52;s:14:"payment/liqpay";i:53;s:20:"payment/moneybookers";i:54;s:14:"payment/nochex";i:55;s:15:"payment/paymate";i:56;s:16:"payment/paypoint";i:57;s:13:"payment/payza";i:58;s:26:"payment/perpetual_payments";i:59;s:14:"payment/pp_pro";i:60;s:17:"payment/pp_pro_uk";i:61;s:19:"payment/pp_standard";i:62;s:15:"payment/sagepay";i:63;s:22:"payment/sagepay_direct";i:64;s:18:"payment/sagepay_us";i:65;s:19:"payment/twocheckout";i:66;s:28:"payment/web_payment_software";i:67;s:16:"payment/worldpay";i:68;s:27:"report/affiliate_commission";i:69;s:22:"report/customer_credit";i:70;s:22:"report/customer_online";i:71;s:21:"report/customer_order";i:72;s:22:"report/customer_reward";i:73;s:24:"report/product_purchased";i:74;s:21:"report/product_viewed";i:75;s:18:"report/sale_coupon";i:76;s:17:"report/sale_order";i:77;s:18:"report/sale_return";i:78;s:20:"report/sale_shipping";i:79;s:15:"report/sale_tax";i:80;s:14:"sale/affiliate";i:81;s:12:"sale/contact";i:82;s:11:"sale/coupon";i:83;s:13:"sale/customer";i:84;s:23:"sale/customer_blacklist";i:85;s:19:"sale/customer_group";i:86;s:10:"sale/order";i:87;s:11:"sale/return";i:88;s:12:"sale/voucher";i:89;s:18:"sale/voucher_theme";i:90;s:15:"setting/setting";i:91;s:13:"setting/store";i:92;s:16:"shipping/auspost";i:93;s:17:"shipping/citylink";i:94;s:14:"shipping/fedex";i:95;s:13:"shipping/flat";i:96;s:13:"shipping/free";i:97;s:13:"shipping/item";i:98;s:23:"shipping/parcelforce_48";i:99;s:15:"shipping/pickup";i:100;s:19:"shipping/royal_mail";i:101;s:12:"shipping/ups";i:102;s:13:"shipping/usps";i:103;s:15:"shipping/weight";i:104;s:11:"tool/backup";i:105;s:14:"tool/error_log";i:106;s:12:"total/coupon";i:107;s:12:"total/credit";i:108;s:14:"total/handling";i:109;s:16:"total/klarna_fee";i:110;s:19:"total/low_order_fee";i:111;s:12:"total/reward";i:112;s:14:"total/shipping";i:113;s:15:"total/sub_total";i:114;s:9:"total/tax";i:115;s:11:"total/total";i:116;s:13:"total/voucher";i:117;s:9:"user/user";i:118;s:20:"user/user_permission";}s:6:"modify";a:119:{i:0;s:17:"catalog/attribute";i:1;s:23:"catalog/attribute_group";i:2;s:16:"catalog/category";i:3;s:16:"catalog/download";i:4;s:19:"catalog/information";i:5;s:20:"catalog/manufacturer";i:6;s:14:"catalog/option";i:7;s:15:"catalog/product";i:8;s:14:"catalog/review";i:9;s:18:"common/filemanager";i:10;s:13:"design/banner";i:11;s:13:"design/layout";i:12;s:14:"extension/feed";i:13;s:16:"extension/module";i:14;s:17:"extension/payment";i:15;s:18:"extension/shipping";i:16;s:15:"extension/total";i:17;s:16:"feed/google_base";i:18;s:19:"feed/google_sitemap";i:19;s:20:"localisation/country";i:20;s:21:"localisation/currency";i:21;s:21:"localisation/geo_zone";i:22;s:21:"localisation/language";i:23;s:25:"localisation/length_class";i:24;s:25:"localisation/order_status";i:25;s:26:"localisation/return_action";i:26;s:26:"localisation/return_reason";i:27;s:26:"localisation/return_status";i:28;s:25:"localisation/stock_status";i:29;s:22:"localisation/tax_class";i:30;s:21:"localisation/tax_rate";i:31;s:25:"localisation/weight_class";i:32;s:17:"localisation/zone";i:33;s:14:"module/account";i:34;s:16:"module/affiliate";i:35;s:13:"module/banner";i:36;s:17:"module/bestseller";i:37;s:15:"module/carousel";i:38;s:15:"module/category";i:39;s:15:"module/featured";i:40;s:18:"module/google_talk";i:41;s:18:"module/information";i:42;s:13:"module/latest";i:43;s:16:"module/slideshow";i:44;s:14:"module/special";i:45;s:12:"module/store";i:46;s:14:"module/welcome";i:47;s:24:"payment/authorizenet_aim";i:48;s:21:"payment/bank_transfer";i:49;s:14:"payment/cheque";i:50;s:11:"payment/cod";i:51;s:21:"payment/free_checkout";i:52;s:14:"payment/liqpay";i:53;s:20:"payment/moneybookers";i:54;s:14:"payment/nochex";i:55;s:15:"payment/paymate";i:56;s:16:"payment/paypoint";i:57;s:13:"payment/payza";i:58;s:26:"payment/perpetual_payments";i:59;s:14:"payment/pp_pro";i:60;s:17:"payment/pp_pro_uk";i:61;s:19:"payment/pp_standard";i:62;s:15:"payment/sagepay";i:63;s:22:"payment/sagepay_direct";i:64;s:18:"payment/sagepay_us";i:65;s:19:"payment/twocheckout";i:66;s:28:"payment/web_payment_software";i:67;s:16:"payment/worldpay";i:68;s:27:"report/affiliate_commission";i:69;s:22:"report/customer_credit";i:70;s:22:"report/customer_online";i:71;s:21:"report/customer_order";i:72;s:22:"report/customer_reward";i:73;s:24:"report/product_purchased";i:74;s:21:"report/product_viewed";i:75;s:18:"report/sale_coupon";i:76;s:17:"report/sale_order";i:77;s:18:"report/sale_return";i:78;s:20:"report/sale_shipping";i:79;s:15:"report/sale_tax";i:80;s:14:"sale/affiliate";i:81;s:12:"sale/contact";i:82;s:11:"sale/coupon";i:83;s:13:"sale/customer";i:84;s:23:"sale/customer_blacklist";i:85;s:19:"sale/customer_group";i:86;s:10:"sale/order";i:87;s:11:"sale/return";i:88;s:12:"sale/voucher";i:89;s:18:"sale/voucher_theme";i:90;s:15:"setting/setting";i:91;s:13:"setting/store";i:92;s:16:"shipping/auspost";i:93;s:17:"shipping/citylink";i:94;s:14:"shipping/fedex";i:95;s:13:"shipping/flat";i:96;s:13:"shipping/free";i:97;s:13:"shipping/item";i:98;s:23:"shipping/parcelforce_48";i:99;s:15:"shipping/pickup";i:100;s:19:"shipping/royal_mail";i:101;s:12:"shipping/ups";i:102;s:13:"shipping/usps";i:103;s:15:"shipping/weight";i:104;s:11:"tool/backup";i:105;s:14:"tool/error_log";i:106;s:12:"total/coupon";i:107;s:12:"total/credit";i:108;s:14:"total/handling";i:109;s:16:"total/klarna_fee";i:110;s:19:"total/low_order_fee";i:111;s:12:"total/reward";i:112;s:14:"total/shipping";i:113;s:15:"total/sub_total";i:114;s:9:"total/tax";i:115;s:11:"total/total";i:116;s:13:"total/voucher";i:117;s:9:"user/user";i:118;s:20:"user/user_permission";}}'),
(10, 'Демонстрация', '');

-- --------------------------------------------------------

--
-- Структура таблицы `voucher`
--

CREATE TABLE IF NOT EXISTS `voucher` (
  `voucher_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `code` varchar(10) NOT NULL,
  `from_name` varchar(64) NOT NULL,
  `from_email` varchar(96) NOT NULL,
  `to_name` varchar(64) NOT NULL,
  `to_email` varchar(96) NOT NULL,
  `voucher_theme_id` int(11) NOT NULL,
  `message` text NOT NULL,
  `amount` decimal(15,4) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `voucher_history`
--

CREATE TABLE IF NOT EXISTS `voucher_history` (
  `voucher_history_id` int(11) NOT NULL,
  `voucher_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `amount` decimal(15,4) NOT NULL,
  `date_added` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `voucher_theme`
--

CREATE TABLE IF NOT EXISTS `voucher_theme` (
  `voucher_theme_id` int(11) NOT NULL,
  `image` varchar(255) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `voucher_theme`
--

INSERT INTO `voucher_theme` (`voucher_theme_id`, `image`) VALUES
(8, 'data/demo/canon_eos_5d_2.jpg'),
(7, 'data/demo/gift-voucher-birthday.jpg'),
(6, 'data/demo/apple_logo.jpg');

-- --------------------------------------------------------

--
-- Структура таблицы `voucher_theme_description`
--

CREATE TABLE IF NOT EXISTS `voucher_theme_description` (
  `voucher_theme_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `voucher_theme_description`
--

INSERT INTO `voucher_theme_description` (`voucher_theme_id`, `language_id`, `name`) VALUES
(6, 1, 'Рождество'),
(7, 1, 'День рождения'),
(8, 1, 'Основной'),
(6, 2, 'Christmas'),
(7, 2, 'Birthday'),
(8, 2, 'General');

-- --------------------------------------------------------

--
-- Структура таблицы `weight_class`
--

CREATE TABLE IF NOT EXISTS `weight_class` (
  `weight_class_id` int(11) NOT NULL,
  `value` decimal(15,8) NOT NULL DEFAULT '0.00000000'
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `weight_class`
--

INSERT INTO `weight_class` (`weight_class_id`, `value`) VALUES
(1, '1.00000000'),
(2, '1000.00000000');

-- --------------------------------------------------------

--
-- Структура таблицы `weight_class_description`
--

CREATE TABLE IF NOT EXISTS `weight_class_description` (
  `weight_class_id` int(11) NOT NULL,
  `language_id` int(11) NOT NULL,
  `title` varchar(32) NOT NULL,
  `unit` varchar(4) NOT NULL DEFAULT ''
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `weight_class_description`
--

INSERT INTO `weight_class_description` (`weight_class_id`, `language_id`, `title`, `unit`) VALUES
(1, 1, 'Килограммы', 'кг'),
(2, 1, 'Граммы', 'г'),
(1, 2, 'Kilogram', 'kg'),
(2, 2, 'Gram', 'g');

-- --------------------------------------------------------

--
-- Структура таблицы `zone`
--

CREATE TABLE IF NOT EXISTS `zone` (
  `zone_id` int(11) NOT NULL,
  `country_id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `code` varchar(32) NOT NULL DEFAULT '',
  `status` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=MyISAM AUTO_INCREMENT=3971 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `zone`
--

INSERT INTO `zone` (`zone_id`, `country_id`, `name`, `code`, `status`) VALUES
(1, 1, 'Бадахшан', 'BDS', 1),
(2, 1, 'Бадгис', 'BDG', 1),
(3, 1, 'Баглан', 'BGL', 1),
(4, 1, 'Балх', 'BAL', 1),
(5, 1, 'Бамиан', 'BAM', 1),
(6, 1, 'Фарах', 'FRA', 1),
(7, 1, 'Фарьяб', 'FYB', 1),
(8, 1, 'Газни', 'GHA', 1),
(9, 1, 'Гор', 'GHO', 1),
(10, 1, 'Гильменд', 'HEL', 1),
(11, 1, 'Герат', 'HER', 1),
(12, 1, 'Джаузджан', 'JOW', 1),
(13, 1, 'Кабул', 'KAB', 1),
(14, 1, 'Кандагар', 'KAN', 1),
(15, 1, 'Каписа', 'KAP', 1),
(16, 1, 'Хост', 'KHO', 1),
(17, 1, 'Кунар', 'KNR', 1),
(18, 1, 'Кундуз', 'KDZ', 1),
(19, 1, 'Лагман', 'LAG', 1),
(20, 1, 'Логар', 'LOW', 1),
(21, 1, 'Нангархар', 'NAN', 1),
(22, 1, 'Нимроз', 'NIM', 1),
(23, 1, 'Нуристан', 'NUR', 1),
(24, 1, 'Урузган', 'ORU', 1),
(25, 1, 'Пактия', 'PIA', 1),
(26, 1, 'Пактика', 'PKA', 1),
(27, 1, 'Парван', 'PAR', 1),
(28, 1, 'Саманган', 'SAM', 1),
(29, 1, 'Сари-Пуль', 'SAR', 1),
(30, 1, 'Тахар', 'TAK', 1),
(31, 1, 'Вардак', 'WAR', 1),
(32, 1, 'Забуль', 'ZAB', 1),
(33, 2, 'Берат', 'BR', 1),
(34, 2, 'Булькиза', 'BU', 1),
(35, 2, 'Дельвина', 'DL', 1),
(36, 2, 'Девол', 'DV', 1),
(37, 2, 'Дибра', 'DI', 1),
(38, 2, 'Дуррес', 'DR', 1),
(39, 2, 'Эльбасан', 'EL', 1),
(40, 2, 'Колёня', 'ER', 1),
(41, 2, 'Фиери', 'FR', 1),
(42, 2, 'Гирокастра', 'GJ', 1),
(43, 2, 'Грамши', 'GR', 1),
(44, 2, 'Хас', 'HA', 1),
(45, 2, 'Кавая', 'KA', 1),
(46, 2, 'Курбин', 'KB', 1),
(47, 2, 'Кучова', 'KC', 1),
(48, 2, 'Корча', 'KO', 1),
(49, 2, 'Круя', 'KR', 1),
(50, 2, 'Кукес', 'KU', 1),
(51, 2, 'Либражди', 'LB', 1),
(52, 2, 'Лежа', 'LE', 1),
(53, 2, 'Люшня', 'LU', 1),
(54, 2, 'Мальси-э-Мади', 'MM', 1),
(55, 2, 'Малакастра', 'MK', 1),
(56, 2, 'Мати', 'MT', 1),
(57, 2, 'Мирдита', 'MR', 1),
(58, 2, 'Пекини', 'PQ', 1),
(59, 2, 'Пермети', 'PR', 1),
(60, 2, 'Поградец', 'PG', 1),
(61, 2, 'Пука', 'PU', 1),
(62, 2, 'Шкодер', 'SH', 1),
(63, 2, 'Скрапари', 'SK', 1),
(64, 2, 'Саранда', 'SR', 1),
(65, 2, 'Тепелена', 'TE', 1),
(66, 2, 'Тропоя', 'TP', 1),
(67, 2, 'Тирана', 'TR', 1),
(68, 2, 'Влёра', 'VL', 1),
(69, 3, 'Адрар', 'ADR', 1),
(70, 3, 'Айн-Дефла', 'ADE', 1),
(71, 3, 'Айн-Темухент', 'ATE', 1),
(72, 3, 'Алжир', 'ALG', 1),
(73, 3, 'Аннаба', 'ANN', 1),
(74, 3, 'Батна', 'BAT', 1),
(75, 3, 'Бешар', 'BEC', 1),
(76, 3, 'Беджая', 'BEJ', 1),
(77, 3, 'Бискра', 'BIS', 1),
(78, 3, 'Блида', 'BLI', 1),
(79, 3, 'Бордж-Бу-Арреридж', 'BBA', 1),
(80, 3, 'Буйра', 'BOA', 1),
(81, 3, 'Бумердес', 'BMD', 1),
(82, 3, 'Шлеф', 'CHL', 1),
(83, 3, 'Константина', 'CON', 1),
(84, 3, 'Джельфа', 'DJE', 1),
(85, 3, 'Эль-Баяд', 'EBA', 1),
(86, 3, 'Эль-Уэд', 'EOU', 1),
(87, 3, 'Эль-Тарф', 'ETA', 1),
(88, 3, 'Гардая', 'GHA', 1),
(89, 3, 'Гуэльма', 'GUE', 1),
(90, 3, 'Иллизи', 'ILL', 1),
(91, 3, 'Джиджель', 'JIJ', 1),
(92, 3, 'Хеншела', 'KHE', 1),
(93, 3, 'Лагуат', 'LAG', 1),
(94, 3, 'Маскара', 'MUA', 1),
(95, 3, 'Медеа', 'MED', 1),
(96, 3, 'Мила', 'MIL', 1),
(97, 3, 'Мостаганем', 'MOS', 1),
(98, 3, 'Мсила', 'MSI', 1),
(99, 3, 'Наама', 'NAA', 1),
(100, 3, 'Оран', 'ORA', 1),
(101, 3, 'Уаргла', 'OUA', 1),
(102, 3, 'Ум Эль-Буахи', 'OEB', 1),
(103, 3, 'Релизан', 'REL', 1),
(104, 3, 'Саида', 'SAI', 1),
(105, 3, 'Сетиф', 'SET', 1),
(106, 3, 'Сиди-Бель-Аббес', 'SBA', 1),
(107, 3, 'Скикда', 'SKI', 1),
(108, 3, 'Сук-Ахрас', 'SAH', 1),
(109, 3, 'Таменрассет', 'TAM', 1),
(110, 3, 'Тебесса', 'TEB', 1),
(111, 3, 'Тиарет', 'TIA', 1),
(112, 3, 'Тиндуф', 'TIN', 1),
(113, 3, 'Типаза', 'TIP', 1),
(114, 3, 'Тиссемсилт', 'TIS', 1),
(115, 3, 'Тизи-Узу', 'TOU', 1),
(116, 3, 'Тлемсен', 'TLE', 1),
(117, 4, 'Восточный округ', 'E', 1),
(118, 4, 'Мануа', 'M', 1),
(119, 4, 'Остров Роз', 'R', 1),
(120, 4, 'Остров Суэйнс', 'S', 1),
(121, 4, 'Западный округ', 'W', 1),
(122, 5, 'Андорра-ла-Велья', 'ALV', 1),
(123, 5, 'Канильо', 'CAN', 1),
(124, 5, 'Энкамп', 'ENC', 1),
(125, 5, 'Эскальдес-Энгордань', 'ESE', 1),
(126, 5, 'Ла-Массана', 'LMA', 1),
(127, 5, 'Ордино', 'ORD', 1),
(128, 5, 'Сант-Жулия-де-Лория', 'SJL', 1),
(129, 6, 'Бенго', 'BGO', 1),
(130, 6, 'Бенгела', 'BGU', 1),
(131, 6, 'Бие', 'BIE', 1),
(132, 6, 'Кабинда', 'CAB', 1),
(133, 6, 'Квандо-Кубанго', 'CCU', 1),
(134, 6, 'Северная Кванза', 'CNO', 1),
(135, 6, 'Южная Кванза', 'CUS', 1),
(136, 6, 'Кунене', 'CNN', 1),
(137, 6, 'Уамбо', 'HUA', 1),
(138, 6, 'Уила', 'HUI', 1),
(139, 6, 'Луанда', 'LUA', 1),
(140, 6, 'Северная Лунда', 'LNO', 1),
(141, 6, 'Южная Лунда', 'LSU', 1),
(142, 6, 'Маланже', 'MAL', 1),
(143, 6, 'Мошико', 'MOX', 1),
(144, 6, 'Намибе', 'NAM', 1),
(145, 6, 'Уиже', 'UIG', 1),
(146, 6, 'Заире', 'ZAI', 1),
(147, 9, 'Сент-Джордж', 'ASG', 1),
(148, 9, 'Сент-Джон', 'ASJ', 1),
(149, 9, 'Сент-Мери', 'ASM', 1),
(150, 9, 'Сент-Пол', 'ASL', 1),
(151, 9, 'Сент-Петер', 'ASR', 1),
(152, 9, 'Сент-Филип', 'ASH', 1),
(153, 9, 'Барбуда', 'BAR', 1),
(154, 9, 'Редонда', 'RED', 1),
(155, 10, 'Антарктида и острова Южной Атлантики', 'AN', 1),
(156, 10, 'Буэнос-Айрес', 'BA', 1),
(157, 10, 'Катамарка', 'CA', 1),
(158, 10, 'Чако', 'CH', 1),
(159, 10, 'Чубут', 'CU', 1),
(160, 10, 'Кордова', 'CO', 1),
(161, 10, 'Корриентес', 'CR', 1),
(162, 10, 'Федеральный округ', 'DF', 1),
(163, 10, 'Энтре-Риос', 'ER', 1),
(164, 10, 'Формоса', 'FO', 1),
(165, 10, 'Жужуй', 'JU', 1),
(166, 10, 'Ла-Пампа', 'LP', 1),
(167, 10, 'Ла-Риоха', 'LR', 1),
(168, 10, 'Мендоса', 'ME', 1),
(169, 10, 'Мисьонес', 'MI', 1),
(170, 10, 'Неукен', 'NE', 1),
(171, 10, 'Рио-Негро', 'RN', 1),
(172, 10, 'Сальта', 'SA', 1),
(173, 10, 'Сан-Хуан', 'SJ', 1),
(174, 10, 'Сан-Луис', 'SL', 1),
(175, 10, 'Санта-Крус', 'SC', 1),
(176, 10, 'Санта-Фе', 'SF', 1),
(177, 10, 'Сантьяго-дель-Эстеро', 'SD', 1),
(178, 10, 'Тьерра-дель-Фуэго', 'TF', 1),
(179, 10, 'Тукуман', 'TU', 1),
(180, 11, 'Арагацотн', 'AGT', 1),
(181, 11, 'Арарат', 'ARR', 1),
(182, 11, 'Армавир', 'ARM', 1),
(183, 11, 'Гегаркуник', 'GEG', 1),
(184, 11, 'Котайк', 'KOT', 1),
(185, 11, 'Лори', 'LOR', 1),
(186, 11, 'Ширак', 'SHI', 1),
(187, 11, 'Сюник', 'SYU', 1),
(188, 11, 'Тавуш', 'TAV', 1),
(189, 11, 'Вайоц Дзор', 'VAY', 1),
(190, 11, 'Ереван', 'YER', 1),
(191, 13, 'Австралийская столичная территория', 'ACT', 1),
(192, 13, 'Новый Южный Уэльс', 'NSW', 1),
(193, 13, 'Северная территория', 'NT', 1),
(194, 13, 'Квинсленд', 'QLD', 1),
(195, 13, 'Южная Австралия', 'SA', 1),
(196, 13, 'Тасмания', 'TAS', 1),
(197, 13, 'Виктория', 'VIC', 1),
(198, 13, 'Западная Австралия', 'WA', 1),
(199, 14, 'Бургенланд', 'BUR', 1),
(200, 14, 'Каринтия', 'KAR', 1),
(201, 14, 'Нижняя Австрия', 'NOS', 1),
(202, 14, 'Верхняя Австрия', 'OOS', 1),
(203, 14, 'Зальцбург', 'SAL', 1),
(204, 14, 'Штирия', 'STE', 1),
(205, 14, 'Тироль', 'TIR', 1),
(206, 14, 'Форарльберг', 'VOR', 1),
(207, 14, 'Вена', 'WIE', 1),
(208, 15, 'Ali Bayramli', 'AB', 1),
(209, 15, 'Abseron', 'ABS', 1),
(210, 15, 'AgcabAdi', 'AGC', 1),
(211, 15, 'Agdam', 'AGM', 1),
(212, 15, 'Agdas', 'AGS', 1),
(213, 15, 'Agstafa', 'AGA', 1),
(214, 15, 'Agsu', 'AGU', 1),
(215, 15, 'Astara', 'AST', 1),
(216, 15, 'Baki', 'BA', 1),
(217, 15, 'BabAk', 'BAB', 1),
(218, 15, 'BalakAn', 'BAL', 1),
(219, 15, 'BArdA', 'BAR', 1),
(220, 15, 'Beylaqan', 'BEY', 1),
(221, 15, 'Bilasuvar', 'BIL', 1),
(222, 15, 'Cabrayil', 'CAB', 1),
(223, 15, 'Calilabab', 'CAL', 1),
(224, 15, 'Culfa', 'CUL', 1),
(225, 15, 'Daskasan', 'DAS', 1),
(226, 15, 'Davaci', 'DAV', 1),
(227, 15, 'Fuzuli', 'FUZ', 1),
(228, 15, 'Ganca', 'GA', 1),
(229, 15, 'Gadabay', 'GAD', 1),
(230, 15, 'Goranboy', 'GOR', 1),
(231, 15, 'Goycay', 'GOY', 1),
(232, 15, 'Haciqabul', 'HAC', 1),
(233, 15, 'Imisli', 'IMI', 1),
(234, 15, 'Ismayilli', 'ISM', 1),
(235, 15, 'Kalbacar', 'KAL', 1),
(236, 15, 'Kurdamir', 'KUR', 1),
(237, 15, 'Lankaran', 'LA', 1),
(238, 15, 'Lacin', 'LAC', 1),
(239, 15, 'Lankaran', 'LAN', 1),
(240, 15, 'Lerik', 'LER', 1),
(241, 15, 'Masalli', 'MAS', 1),
(242, 15, 'Mingacevir', 'MI', 1),
(243, 15, 'Naftalan', 'NA', 1),
(244, 15, 'Neftcala', 'NEF', 1),
(245, 15, 'Oguz', 'OGU', 1),
(246, 15, 'Ordubad', 'ORD', 1),
(247, 15, 'Qabala', 'QAB', 1),
(248, 15, 'Qax', 'QAX', 1),
(249, 15, 'Qazax', 'QAZ', 1),
(250, 15, 'Qobustan', 'QOB', 1),
(251, 15, 'Quba', 'QBA', 1),
(252, 15, 'Qubadli', 'QBI', 1),
(253, 15, 'Qusar', 'QUS', 1),
(254, 15, 'Saki', 'SA', 1),
(255, 15, 'Saatli', 'SAT', 1),
(256, 15, 'Sabirabad', 'SAB', 1),
(257, 15, 'Sadarak', 'SAD', 1),
(258, 15, 'Sahbuz', 'SAH', 1),
(259, 15, 'Saki', 'SAK', 1),
(260, 15, 'Salyan', 'SAL', 1),
(261, 15, 'Sumqayit', 'SM', 1),
(262, 15, 'Samaxi', 'SMI', 1),
(263, 15, 'Samkir', 'SKR', 1),
(264, 15, 'Samux', 'SMX', 1),
(265, 15, 'Sarur', 'SAR', 1),
(266, 15, 'Siyazan', 'SIY', 1),
(267, 15, 'Susa', 'SS', 1),
(268, 15, 'Susa', 'SUS', 1),
(269, 15, 'Tartar', 'TAR', 1),
(270, 15, 'Tovuz', 'TOV', 1),
(271, 15, 'Ucar', 'UCA', 1),
(272, 15, 'Xankandi', 'XA', 1),
(273, 15, 'Xacmaz', 'XAC', 1),
(274, 15, 'Xanlar', 'XAN', 1),
(275, 15, 'Xizi', 'XIZ', 1),
(276, 15, 'Xocali', 'XCI', 1),
(277, 15, 'Xocavand', 'XVD', 1),
(278, 15, 'Yardimli', 'YAR', 1),
(279, 15, 'Yevlax', 'YEV', 1),
(280, 15, 'Zangilan', 'ZAN', 1),
(281, 15, 'Zaqatala', 'ZAQ', 1),
(282, 15, 'Zardab', 'ZAR', 1),
(283, 15, 'Naxcivan', 'NX', 1),
(284, 16, 'Acklins', 'ACK', 1),
(285, 16, 'Berry Islands', 'BER', 1),
(286, 16, 'Bimini', 'BIM', 1),
(287, 16, 'Black Point', 'BLK', 1),
(288, 16, 'Cat Island', 'CAT', 1),
(289, 16, 'Central Abaco', 'CAB', 1),
(290, 16, 'Central Andros', 'CAN', 1),
(291, 16, 'Central Eleuthera', 'CEL', 1),
(292, 16, 'City of Freeport', 'FRE', 1),
(293, 16, 'Crooked Island', 'CRO', 1),
(294, 16, 'East Grand Bahama', 'EGB', 1),
(295, 16, 'Exuma', 'EXU', 1),
(296, 16, 'Grand Cay', 'GRD', 1),
(297, 16, 'Harbour Island', 'HAR', 1),
(298, 16, 'Hope Town', 'HOP', 1),
(299, 16, 'Inagua', 'INA', 1),
(300, 16, 'Long Island', 'LNG', 1),
(301, 16, 'Mangrove Cay', 'MAN', 1),
(302, 16, 'Mayaguana', 'MAY', 1),
(303, 16, 'Moore''s Island', 'MOO', 1),
(304, 16, 'North Abaco', 'NAB', 1),
(305, 16, 'North Andros', 'NAN', 1),
(306, 16, 'North Eleuthera', 'NEL', 1),
(307, 16, 'Ragged Island', 'RAG', 1),
(308, 16, 'Rum Cay', 'RUM', 1),
(309, 16, 'San Salvador', 'SAL', 1),
(310, 16, 'South Abaco', 'SAB', 1),
(311, 16, 'South Andros', 'SAN', 1),
(312, 16, 'South Eleuthera', 'SEL', 1),
(313, 16, 'Spanish Wells', 'SWE', 1),
(314, 16, 'West Grand Bahama', 'WGB', 1),
(315, 17, 'Capital', 'CAP', 1),
(316, 17, 'Central', 'CEN', 1),
(317, 17, 'Muharraq', 'MUH', 1),
(318, 17, 'Northern', 'NOR', 1),
(319, 17, 'Southern', 'SOU', 1),
(320, 18, 'Barisal', 'BAR', 1),
(321, 18, 'Chittagong', 'CHI', 1),
(322, 18, 'Dhaka', 'DHA', 1),
(323, 18, 'Khulna', 'KHU', 1),
(324, 18, 'Rajshahi', 'RAJ', 1),
(325, 18, 'Sylhet', 'SYL', 1),
(326, 19, 'Christ Church', 'CC', 1),
(327, 19, 'Saint Andrew', 'AND', 1),
(328, 19, 'Saint George', 'GEO', 1),
(329, 19, 'Saint James', 'JAM', 1),
(330, 19, 'Saint John', 'JOH', 1),
(331, 19, 'Saint Joseph', 'JOS', 1),
(332, 19, 'Saint Lucy', 'LUC', 1),
(333, 19, 'Saint Michael', 'MIC', 1),
(334, 19, 'Saint Peter', 'PET', 1),
(335, 19, 'Saint Philip', 'PHI', 1),
(336, 19, 'Saint Thomas', 'THO', 1),
(337, 20, 'Брест', 'BR', 1),
(338, 20, 'Гомель', 'HO', 1),
(339, 20, 'Минск', 'HM', 1),
(340, 20, 'Гродно', 'HR', 1),
(341, 20, 'Могилев', 'MA', 1),
(342, 20, 'Минская область', 'MI', 1),
(343, 20, 'Витебск', 'VI', 1),
(344, 21, 'Antwerpen', 'VAN', 1),
(345, 21, 'Brabant Wallon', 'WBR', 1),
(346, 21, 'Hainaut', 'WHT', 1),
(347, 21, 'Liege', 'WLG', 1),
(348, 21, 'Limburg', 'VLI', 1),
(349, 21, 'Luxembourg', 'WLX', 1),
(350, 21, 'Namur', 'WNA', 1),
(351, 21, 'Oost-Vlaanderen', 'VOV', 1),
(352, 21, 'Vlaams Brabant', 'VBR', 1),
(353, 21, 'West-Vlaanderen', 'VWV', 1),
(354, 22, 'Belize', 'BZ', 1),
(355, 22, 'Cayo', 'CY', 1),
(356, 22, 'Corozal', 'CR', 1),
(357, 22, 'Orange Walk', 'OW', 1),
(358, 22, 'Stann Creek', 'SC', 1),
(359, 22, 'Toledo', 'TO', 1),
(360, 23, 'Alibori', 'AL', 1),
(361, 23, 'Atakora', 'AK', 1),
(362, 23, 'Atlantique', 'AQ', 1),
(363, 23, 'Borgou', 'BO', 1),
(364, 23, 'Collines', 'CO', 1),
(365, 23, 'Donga', 'DO', 1),
(366, 23, 'Kouffo', 'KO', 1),
(367, 23, 'Littoral', 'LI', 1),
(368, 23, 'Mono', 'MO', 1),
(369, 23, 'Oueme', 'OU', 1),
(370, 23, 'Plateau', 'PL', 1),
(371, 23, 'Zou', 'ZO', 1),
(372, 24, 'Devonshire', 'DS', 1),
(373, 24, 'Hamilton City', 'HC', 1),
(374, 24, 'Hamilton', 'HA', 1),
(375, 24, 'Paget', 'PG', 1),
(376, 24, 'Pembroke', 'PB', 1),
(377, 24, 'Saint George City', 'GC', 1),
(378, 24, 'Saint George''s', 'SG', 1),
(379, 24, 'Sandys', 'SA', 1),
(380, 24, 'Smith''s', 'SM', 1),
(381, 24, 'Southampton', 'SH', 1),
(382, 24, 'Warwick', 'WA', 1),
(383, 25, 'Bumthang', 'BUM', 1),
(384, 25, 'Chukha', 'CHU', 1),
(385, 25, 'Dagana', 'DAG', 1),
(386, 25, 'Gasa', 'GAS', 1),
(387, 25, 'Haa', 'HAA', 1),
(388, 25, 'Lhuntse', 'LHU', 1),
(389, 25, 'Mongar', 'MON', 1),
(390, 25, 'Paro', 'PAR', 1),
(391, 25, 'Pemagatshel', 'PEM', 1),
(392, 25, 'Punakha', 'PUN', 1),
(393, 25, 'Samdrup Jongkhar', 'SJO', 1),
(394, 25, 'Samtse', 'SAT', 1),
(395, 25, 'Sarpang', 'SAR', 1),
(396, 25, 'Thimphu', 'THI', 1),
(397, 25, 'Trashigang', 'TRG', 1),
(398, 25, 'Trashiyangste', 'TRY', 1),
(399, 25, 'Trongsa', 'TRO', 1),
(400, 25, 'Tsirang', 'TSI', 1),
(401, 25, 'Wangdue Phodrang', 'WPH', 1),
(402, 25, 'Zhemgang', 'ZHE', 1),
(403, 26, 'Beni', 'BEN', 1),
(404, 26, 'Chuquisaca', 'CHU', 1),
(405, 26, 'Cochabamba', 'COC', 1),
(406, 26, 'La Paz', 'LPZ', 1),
(407, 26, 'Oruro', 'ORU', 1),
(408, 26, 'Pando', 'PAN', 1),
(409, 26, 'Potosi', 'POT', 1),
(410, 26, 'Santa Cruz', 'SCZ', 1),
(411, 26, 'Tarija', 'TAR', 1),
(412, 27, 'Brcko district', 'BRO', 1),
(413, 27, 'Unsko-Sanski Kanton', 'FUS', 1),
(414, 27, 'Posavski Kanton', 'FPO', 1),
(415, 27, 'Tuzlanski Kanton', 'FTU', 1),
(416, 27, 'Zenicko-Dobojski Kanton', 'FZE', 1),
(417, 27, 'Bosanskopodrinjski Kanton', 'FBP', 1),
(418, 27, 'Srednjebosanski Kanton', 'FSB', 1),
(419, 27, 'Hercegovacko-neretvanski Kanton', 'FHN', 1),
(420, 27, 'Zapadnohercegovacka Zupanija', 'FZH', 1),
(421, 27, 'Kanton Sarajevo', 'FSA', 1),
(422, 27, 'Zapadnobosanska', 'FZA', 1),
(423, 27, 'Banja Luka', 'SBL', 1),
(424, 27, 'Doboj', 'SDO', 1),
(425, 27, 'Bijeljina', 'SBI', 1),
(426, 27, 'Vlasenica', 'SVL', 1),
(427, 27, 'Sarajevo-Romanija or Sokolac', 'SSR', 1),
(428, 27, 'Foca', 'SFO', 1),
(429, 27, 'Trebinje', 'STR', 1),
(430, 28, 'Central', 'CE', 1),
(431, 28, 'Ghanzi', 'GH', 1),
(432, 28, 'Kgalagadi', 'KD', 1),
(433, 28, 'Kgatleng', 'KT', 1),
(434, 28, 'Kweneng', 'KW', 1),
(435, 28, 'Ngamiland', 'NG', 1),
(436, 28, 'North East', 'NE', 1),
(437, 28, 'North West', 'NW', 1),
(438, 28, 'South East', 'SE', 1),
(439, 28, 'Southern', 'SO', 1),
(440, 30, 'Acre', 'AC', 1),
(441, 30, 'Alagoas', 'AL', 1),
(442, 30, 'Amapa', 'AP', 1),
(443, 30, 'Amazonas', 'AM', 1),
(444, 30, 'Bahia', 'BA', 1),
(445, 30, 'Ceara', 'CE', 1),
(446, 30, 'Distrito Federal', 'DF', 1),
(447, 30, 'Espirito Santo', 'ES', 1),
(448, 30, 'Goias', 'GO', 1),
(449, 30, 'Maranhao', 'MA', 1),
(450, 30, 'Mato Grosso', 'MT', 1),
(451, 30, 'Mato Grosso do Sul', 'MS', 1),
(452, 30, 'Minas Gerais', 'MG', 1),
(453, 30, 'Para', 'PA', 1),
(454, 30, 'Paraiba', 'PB', 1),
(455, 30, 'Parana', 'PR', 1),
(456, 30, 'Pernambuco', 'PE', 1),
(457, 30, 'Piaui', 'PI', 1),
(458, 30, 'Rio de Janeiro', 'RJ', 1),
(459, 30, 'Rio Grande do Norte', 'RN', 1),
(460, 30, 'Rio Grande do Sul', 'RS', 1),
(461, 30, 'Rondonia', 'RO', 1),
(462, 30, 'Roraima', 'RR', 1),
(463, 30, 'Santa Catarina', 'SC', 1),
(464, 30, 'Sao Paulo', 'SP', 1),
(465, 30, 'Sergipe', 'SE', 1),
(466, 30, 'Tocantins', 'TO', 1),
(467, 31, 'Peros Banhos', 'PB', 1),
(468, 31, 'Salomon Islands', 'SI', 1),
(469, 31, 'Nelsons Island', 'NI', 1),
(470, 31, 'Three Brothers', 'TB', 1),
(471, 31, 'Eagle Islands', 'EA', 1),
(472, 31, 'Danger Island', 'DI', 1),
(473, 31, 'Egmont Islands', 'EG', 1),
(474, 31, 'Diego Garcia', 'DG', 1),
(475, 32, 'Belait', 'BEL', 1),
(476, 32, 'Brunei and Muara', 'BRM', 1),
(477, 32, 'Temburong', 'TEM', 1),
(478, 32, 'Tutong', 'TUT', 1),
(479, 33, 'Blagoevgrad', '', 1),
(480, 33, 'Burgas', '', 1),
(481, 33, 'Dobrich', '', 1),
(482, 33, 'Gabrovo', '', 1),
(483, 33, 'Haskovo', '', 1),
(484, 33, 'Kardjali', '', 1),
(485, 33, 'Kyustendil', '', 1),
(486, 33, 'Lovech', '', 1),
(487, 33, 'Montana', '', 1),
(488, 33, 'Pazardjik', '', 1),
(489, 33, 'Pernik', '', 1),
(490, 33, 'Pleven', '', 1),
(491, 33, 'Plovdiv', '', 1),
(492, 33, 'Razgrad', '', 1),
(493, 33, 'Shumen', '', 1),
(494, 33, 'Silistra', '', 1),
(495, 33, 'Sliven', '', 1),
(496, 33, 'Smolyan', '', 1),
(497, 33, 'Sofia', '', 1),
(498, 33, 'Sofia - town', '', 1),
(499, 33, 'Stara Zagora', '', 1),
(500, 33, 'Targovishte', '', 1),
(501, 33, 'Varna', '', 1),
(502, 33, 'Veliko Tarnovo', '', 1),
(503, 33, 'Vidin', '', 1),
(504, 33, 'Vratza', '', 1),
(505, 33, 'Yambol', '', 1),
(506, 34, 'Bale', 'BAL', 1),
(507, 34, 'Bam', 'BAM', 1),
(508, 34, 'Banwa', 'BAN', 1),
(509, 34, 'Bazega', 'BAZ', 1),
(510, 34, 'Bougouriba', 'BOR', 1),
(511, 34, 'Boulgou', 'BLG', 1),
(512, 34, 'Boulkiemde', 'BOK', 1),
(513, 34, 'Comoe', 'COM', 1),
(514, 34, 'Ganzourgou', 'GAN', 1),
(515, 34, 'Gnagna', 'GNA', 1),
(516, 34, 'Gourma', 'GOU', 1),
(517, 34, 'Houet', 'HOU', 1),
(518, 34, 'Ioba', 'IOA', 1),
(519, 34, 'Kadiogo', 'KAD', 1),
(520, 34, 'Kenedougou', 'KEN', 1),
(521, 34, 'Komondjari', 'KOD', 1),
(522, 34, 'Kompienga', 'KOP', 1),
(523, 34, 'Kossi', 'KOS', 1),
(524, 34, 'Koulpelogo', 'KOL', 1),
(525, 34, 'Kouritenga', 'KOT', 1),
(526, 34, 'Kourweogo', 'KOW', 1),
(527, 34, 'Leraba', 'LER', 1),
(528, 34, 'Loroum', 'LOR', 1),
(529, 34, 'Mouhoun', 'MOU', 1),
(530, 34, 'Nahouri', 'NAH', 1),
(531, 34, 'Namentenga', 'NAM', 1),
(532, 34, 'Nayala', 'NAY', 1),
(533, 34, 'Noumbiel', 'NOU', 1),
(534, 34, 'Oubritenga', 'OUB', 1),
(535, 34, 'Oudalan', 'OUD', 1),
(536, 34, 'Passore', 'PAS', 1),
(537, 34, 'Poni', 'PON', 1),
(538, 34, 'Sanguie', 'SAG', 1),
(539, 34, 'Sanmatenga', 'SAM', 1),
(540, 34, 'Seno', 'SEN', 1),
(541, 34, 'Sissili', 'SIS', 1),
(542, 34, 'Soum', 'SOM', 1),
(543, 34, 'Sourou', 'SOR', 1),
(544, 34, 'Tapoa', 'TAP', 1),
(545, 34, 'Tuy', 'TUY', 1),
(546, 34, 'Yagha', 'YAG', 1),
(547, 34, 'Yatenga', 'YAT', 1),
(548, 34, 'Ziro', 'ZIR', 1),
(549, 34, 'Zondoma', 'ZOD', 1),
(550, 34, 'Zoundweogo', 'ZOW', 1),
(551, 35, 'Bubanza', 'BB', 1),
(552, 35, 'Bujumbura', 'BJ', 1),
(553, 35, 'Bururi', 'BR', 1),
(554, 35, 'Cankuzo', 'CA', 1),
(555, 35, 'Cibitoke', 'CI', 1),
(556, 35, 'Gitega', 'GI', 1),
(557, 35, 'Karuzi', 'KR', 1),
(558, 35, 'Kayanza', 'KY', 1),
(559, 35, 'Kirundo', 'KI', 1),
(560, 35, 'Makamba', 'MA', 1),
(561, 35, 'Muramvya', 'MU', 1),
(562, 35, 'Muyinga', 'MY', 1),
(563, 35, 'Mwaro', 'MW', 1),
(564, 35, 'Ngozi', 'NG', 1),
(565, 35, 'Rutana', 'RT', 1),
(566, 35, 'Ruyigi', 'RY', 1),
(567, 36, 'Phnom Penh', 'PP', 1),
(568, 36, 'Preah Seihanu (Kompong Som or Sihanoukville)', 'PS', 1),
(569, 36, 'Pailin', 'PA', 1),
(570, 36, 'Keb', 'KB', 1),
(571, 36, 'Banteay Meanchey', 'BM', 1),
(572, 36, 'Battambang', 'BA', 1),
(573, 36, 'Kampong Cham', 'KM', 1),
(574, 36, 'Kampong Chhnang', 'KN', 1),
(575, 36, 'Kampong Speu', 'KU', 1),
(576, 36, 'Kampong Som', 'KO', 1),
(577, 36, 'Kampong Thom', 'KT', 1),
(578, 36, 'Kampot', 'KP', 1),
(579, 36, 'Kandal', 'KL', 1),
(580, 36, 'Kaoh Kong', 'KK', 1),
(581, 36, 'Kratie', 'KR', 1),
(582, 36, 'Mondul Kiri', 'MK', 1),
(583, 36, 'Oddar Meancheay', 'OM', 1),
(584, 36, 'Pursat', 'PU', 1),
(585, 36, 'Preah Vihear', 'PR', 1),
(586, 36, 'Prey Veng', 'PG', 1),
(587, 36, 'Ratanak Kiri', 'RK', 1),
(588, 36, 'Siemreap', 'SI', 1),
(589, 36, 'Stung Treng', 'ST', 1),
(590, 36, 'Svay Rieng', 'SR', 1),
(591, 36, 'Takeo', 'TK', 1),
(592, 37, 'Adamawa (Adamaoua)', 'ADA', 1),
(593, 37, 'Centre', 'CEN', 1),
(594, 37, 'East (Est)', 'EST', 1),
(595, 37, 'Extreme North (Extreme-Nord)', 'EXN', 1),
(596, 37, 'Littoral', 'LIT', 1),
(597, 37, 'North (Nord)', 'NOR', 1),
(598, 37, 'Northwest (Nord-Ouest)', 'NOT', 1),
(599, 37, 'West (Ouest)', 'OUE', 1),
(600, 37, 'South (Sud)', 'SUD', 1),
(601, 37, 'Southwest (Sud-Ouest).', 'SOU', 1),
(602, 38, 'Alberta', 'AB', 1),
(603, 38, 'British Columbia', 'BC', 1),
(604, 38, 'Manitoba', 'MB', 1),
(605, 38, 'New Brunswick', 'NB', 1),
(606, 38, 'Newfoundland and Labrador', 'NL', 1),
(607, 38, 'Northwest Territories', 'NT', 1),
(608, 38, 'Nova Scotia', 'NS', 1),
(609, 38, 'Nunavut', 'NU', 1),
(610, 38, 'Ontario', 'ON', 1),
(611, 38, 'Prince Edward Island', 'PE', 1),
(612, 38, 'Qu&eacute;bec', 'QC', 1),
(613, 38, 'Saskatchewan', 'SK', 1),
(614, 38, 'Yukon Territory', 'YT', 1),
(615, 39, 'Boa Vista', 'BV', 1),
(616, 39, 'Brava', 'BR', 1),
(617, 39, 'Calheta de Sao Miguel', 'CS', 1),
(618, 39, 'Maio', 'MA', 1),
(619, 39, 'Mosteiros', 'MO', 1),
(620, 39, 'Paul', 'PA', 1),
(621, 39, 'Porto Novo', 'PN', 1),
(622, 39, 'Praia', 'PR', 1),
(623, 39, 'Ribeira Grande', 'RG', 1),
(624, 39, 'Sal', 'SL', 1),
(625, 39, 'Santa Catarina', 'CA', 1),
(626, 39, 'Santa Cruz', 'CR', 1),
(627, 39, 'Sao Domingos', 'SD', 1),
(628, 39, 'Sao Filipe', 'SF', 1),
(629, 39, 'Sao Nicolau', 'SN', 1),
(630, 39, 'Sao Vicente', 'SV', 1),
(631, 39, 'Tarrafal', 'TA', 1),
(632, 40, 'Creek', 'CR', 1),
(633, 40, 'Eastern', 'EA', 1),
(634, 40, 'Midland', 'ML', 1),
(635, 40, 'South Town', 'ST', 1),
(636, 40, 'Spot Bay', 'SP', 1),
(637, 40, 'Stake Bay', 'SK', 1),
(638, 40, 'West End', 'WD', 1),
(639, 40, 'Western', 'WN', 1),
(640, 41, 'Bamingui-Bangoran', 'BBA', 1),
(641, 41, 'Basse-Kotto', 'BKO', 1),
(642, 41, 'Haute-Kotto', 'HKO', 1),
(643, 41, 'Haut-Mbomou', 'HMB', 1),
(644, 41, 'Kemo', 'KEM', 1),
(645, 41, 'Lobaye', 'LOB', 1),
(646, 41, 'Mambere-KadeÔ', 'MKD', 1),
(647, 41, 'Mbomou', 'MBO', 1),
(648, 41, 'Nana-Mambere', 'NMM', 1),
(649, 41, 'Ombella-M''Poko', 'OMP', 1),
(650, 41, 'Ouaka', 'OUK', 1),
(651, 41, 'Ouham', 'OUH', 1),
(652, 41, 'Ouham-Pende', 'OPE', 1),
(653, 41, 'Vakaga', 'VAK', 1),
(654, 41, 'Nana-Grebizi', 'NGR', 1),
(655, 41, 'Sangha-Mbaere', 'SMB', 1),
(656, 41, 'Bangui', 'BAN', 1),
(657, 42, 'Batha', 'BA', 1),
(658, 42, 'Biltine', 'BI', 1),
(659, 42, 'Borkou-Ennedi-Tibesti', 'BE', 1),
(660, 42, 'Chari-Baguirmi', 'CB', 1),
(661, 42, 'Guera', 'GU', 1),
(662, 42, 'Kanem', 'KA', 1),
(663, 42, 'Lac', 'LA', 1),
(664, 42, 'Logone Occidental', 'LC', 1),
(665, 42, 'Logone Oriental', 'LR', 1),
(666, 42, 'Mayo-Kebbi', 'MK', 1),
(667, 42, 'Moyen-Chari', 'MC', 1),
(668, 42, 'Ouaddai', 'OU', 1),
(669, 42, 'Salamat', 'SA', 1),
(670, 42, 'Tandjile', 'TA', 1),
(671, 43, 'Aisen del General Carlos Ibanez', 'AI', 1),
(672, 43, 'Antofagasta', 'AN', 1),
(673, 43, 'Araucania', 'AR', 1),
(674, 43, 'Atacama', 'AT', 1),
(675, 43, 'Bio-Bio', 'BI', 1),
(676, 43, 'Coquimbo', 'CO', 1),
(677, 43, 'Libertador General Bernardo O''Hi', 'LI', 1),
(678, 43, 'Los Lagos', 'LL', 1),
(679, 43, 'Magallanes y de la Antartica Chi', 'MA', 1),
(680, 43, 'Maule', 'ML', 1),
(681, 43, 'Region Metropolitana', 'RM', 1),
(682, 43, 'Tarapaca', 'TA', 1),
(683, 43, 'Valparaiso', 'VS', 1),
(684, 44, 'Anhui', 'AN', 1),
(685, 44, 'Beijing', 'BE', 1),
(686, 44, 'Chongqing', 'CH', 1),
(687, 44, 'Fujian', 'FU', 1),
(688, 44, 'Gansu', 'GA', 1),
(689, 44, 'Guangdong', 'GU', 1),
(690, 44, 'Guangxi', 'GX', 1),
(691, 44, 'Guizhou', 'GZ', 1),
(692, 44, 'Hainan', 'HA', 1),
(693, 44, 'Hebei', 'HB', 1),
(694, 44, 'Heilongjiang', 'HL', 1),
(695, 44, 'Henan', 'HE', 1),
(696, 44, 'Hong Kong', 'HK', 1),
(697, 44, 'Hubei', 'HU', 1),
(698, 44, 'Hunan', 'HN', 1),
(699, 44, 'Inner Mongolia', 'IM', 1),
(700, 44, 'Jiangsu', 'JI', 1),
(701, 44, 'Jiangxi', 'JX', 1),
(702, 44, 'Jilin', 'JL', 1),
(703, 44, 'Liaoning', 'LI', 1),
(704, 44, 'Macau', 'MA', 1),
(705, 44, 'Ningxia', 'NI', 1),
(706, 44, 'Shaanxi', 'SH', 1),
(707, 44, 'Shandong', 'SA', 1),
(708, 44, 'Shanghai', 'SG', 1),
(709, 44, 'Shanxi', 'SX', 1),
(710, 44, 'Sichuan', 'SI', 1),
(711, 44, 'Tianjin', 'TI', 1),
(712, 44, 'Xinjiang', 'XI', 1),
(713, 44, 'Yunnan', 'YU', 1),
(714, 44, 'Zhejiang', 'ZH', 1),
(715, 46, 'Direction Island', 'D', 1),
(716, 46, 'Home Island', 'H', 1),
(717, 46, 'Horsburgh Island', 'O', 1),
(718, 46, 'South Island', 'S', 1),
(719, 46, 'West Island', 'W', 1),
(720, 47, 'Amazonas', 'AMZ', 1),
(721, 47, 'Antioquia', 'ANT', 1),
(722, 47, 'Arauca', 'ARA', 1),
(723, 47, 'Atlantico', 'ATL', 1),
(724, 47, 'Bogota D.C.', 'BDC', 1),
(725, 47, 'Bolivar', 'BOL', 1),
(726, 47, 'Boyaca', 'BOY', 1),
(727, 47, 'Caldas', 'CAL', 1),
(728, 47, 'Caqueta', 'CAQ', 1),
(729, 47, 'Casanare', 'CAS', 1),
(730, 47, 'Cauca', 'CAU', 1),
(731, 47, 'Cesar', 'CES', 1),
(732, 47, 'Choco', 'CHO', 1),
(733, 47, 'Cordoba', 'COR', 1),
(734, 47, 'Cundinamarca', 'CAM', 1),
(735, 47, 'Guainia', 'GNA', 1),
(736, 47, 'Guajira', 'GJR', 1),
(737, 47, 'Guaviare', 'GVR', 1),
(738, 47, 'Huila', 'HUI', 1),
(739, 47, 'Magdalena', 'MAG', 1),
(740, 47, 'Meta', 'MET', 1),
(741, 47, 'Narino', 'NAR', 1),
(742, 47, 'Norte de Santander', 'NDS', 1),
(743, 47, 'Putumayo', 'PUT', 1),
(744, 47, 'Quindio', 'QUI', 1),
(745, 47, 'Risaralda', 'RIS', 1),
(746, 47, 'San Andres y Providencia', 'SAP', 1),
(747, 47, 'Santander', 'SAN', 1),
(748, 47, 'Sucre', 'SUC', 1),
(749, 47, 'Tolima', 'TOL', 1),
(750, 47, 'Valle del Cauca', 'VDC', 1),
(751, 47, 'Vaupes', 'VAU', 1),
(752, 47, 'Vichada', 'VIC', 1),
(753, 48, 'Grande Comore', 'G', 1),
(754, 48, 'Anjouan', 'A', 1),
(755, 48, 'Moheli', 'M', 1),
(756, 49, 'Bouenza', 'BO', 1),
(757, 49, 'Brazzaville', 'BR', 1),
(758, 49, 'Cuvette', 'CU', 1),
(759, 49, 'Cuvette-Ouest', 'CO', 1),
(760, 49, 'Kouilou', 'KO', 1),
(761, 49, 'Lekoumou', 'LE', 1),
(762, 49, 'Likouala', 'LI', 1),
(763, 49, 'Niari', 'NI', 1),
(764, 49, 'Plateaux', 'PL', 1),
(765, 49, 'Pool', 'PO', 1),
(766, 49, 'Sangha', 'SA', 1),
(767, 50, 'Pukapuka', 'PU', 1),
(768, 50, 'Rakahanga', 'RK', 1),
(769, 50, 'Manihiki', 'MK', 1),
(770, 50, 'Penrhyn', 'PE', 1),
(771, 50, 'Nassau Island', 'NI', 1),
(772, 50, 'Surwarrow', 'SU', 1),
(773, 50, 'Palmerston', 'PA', 1),
(774, 50, 'Aitutaki', 'AI', 1),
(775, 50, 'Manuae', 'MA', 1),
(776, 50, 'Takutea', 'TA', 1),
(777, 50, 'Mitiaro', 'MT', 1),
(778, 50, 'Atiu', 'AT', 1),
(779, 50, 'Mauke', 'MU', 1),
(780, 50, 'Rarotonga', 'RR', 1),
(781, 50, 'Mangaia', 'MG', 1),
(782, 51, 'Alajuela', 'AL', 1),
(783, 51, 'Cartago', 'CA', 1),
(784, 51, 'Guanacaste', 'GU', 1),
(785, 51, 'Heredia', 'HE', 1),
(786, 51, 'Limon', 'LI', 1),
(787, 51, 'Puntarenas', 'PU', 1),
(788, 51, 'San Jose', 'SJ', 1),
(789, 52, 'Abengourou', 'ABE', 1),
(790, 52, 'Abidjan', 'ABI', 1),
(791, 52, 'Aboisso', 'ABO', 1),
(792, 52, 'Adiake', 'ADI', 1),
(793, 52, 'Adzope', 'ADZ', 1),
(794, 52, 'Agboville', 'AGB', 1),
(795, 52, 'Agnibilekrou', 'AGN', 1),
(796, 52, 'Alepe', 'ALE', 1),
(797, 52, 'Bocanda', 'BOC', 1),
(798, 52, 'Bangolo', 'BAN', 1),
(799, 52, 'Beoumi', 'BEO', 1),
(800, 52, 'Biankouma', 'BIA', 1),
(801, 52, 'Bondoukou', 'BDK', 1),
(802, 52, 'Bongouanou', 'BGN', 1),
(803, 52, 'Bouafle', 'BFL', 1),
(804, 52, 'Bouake', 'BKE', 1),
(805, 52, 'Bouna', 'BNA', 1),
(806, 52, 'Boundiali', 'BDL', 1),
(807, 52, 'Dabakala', 'DKL', 1),
(808, 52, 'Dabou', 'DBU', 1),
(809, 52, 'Daloa', 'DAL', 1),
(810, 52, 'Danane', 'DAN', 1),
(811, 52, 'Daoukro', 'DAO', 1),
(812, 52, 'Dimbokro', 'DIM', 1),
(813, 52, 'Divo', 'DIV', 1),
(814, 52, 'Duekoue', 'DUE', 1),
(815, 52, 'Ferkessedougou', 'FER', 1),
(816, 52, 'Gagnoa', 'GAG', 1),
(817, 52, 'Grand-Bassam', 'GBA', 1),
(818, 52, 'Grand-Lahou', 'GLA', 1),
(819, 52, 'Guiglo', 'GUI', 1),
(820, 52, 'Issia', 'ISS', 1),
(821, 52, 'Jacqueville', 'JAC', 1),
(822, 52, 'Katiola', 'KAT', 1),
(823, 52, 'Korhogo', 'KOR', 1),
(824, 52, 'Lakota', 'LAK', 1),
(825, 52, 'Man', 'MAN', 1),
(826, 52, 'Mankono', 'MKN', 1),
(827, 52, 'Mbahiakro', 'MBA', 1),
(828, 52, 'Odienne', 'ODI', 1),
(829, 52, 'Oume', 'OUM', 1),
(830, 52, 'Sakassou', 'SAK', 1),
(831, 52, 'San-Pedro', 'SPE', 1),
(832, 52, 'Sassandra', 'SAS', 1),
(833, 52, 'Seguela', 'SEG', 1),
(834, 52, 'Sinfra', 'SIN', 1),
(835, 52, 'Soubre', 'SOU', 1),
(836, 52, 'Tabou', 'TAB', 1),
(837, 52, 'Tanda', 'TAN', 1),
(838, 52, 'Tiebissou', 'TIE', 1),
(839, 52, 'Tingrela', 'TIN', 1),
(840, 52, 'Tiassale', 'TIA', 1),
(841, 52, 'Touba', 'TBA', 1),
(842, 52, 'Toulepleu', 'TLP', 1),
(843, 52, 'Toumodi', 'TMD', 1),
(844, 52, 'Vavoua', 'VAV', 1),
(845, 52, 'Yamoussoukro', 'YAM', 1),
(846, 52, 'Zuenoula', 'ZUE', 1),
(847, 53, 'Bjelovar-Bilogora', 'BB', 1),
(848, 53, 'City of Zagreb', 'CZ', 1),
(849, 53, 'Dubrovnik-Neretva', 'DN', 1),
(850, 53, 'Istra', 'IS', 1),
(851, 53, 'Karlovac', 'KA', 1),
(852, 53, 'Koprivnica-Krizevci', 'KK', 1),
(853, 53, 'Krapina-Zagorje', 'KZ', 1),
(854, 53, 'Lika-Senj', 'LS', 1),
(855, 53, 'Medimurje', 'ME', 1),
(856, 53, 'Osijek-Baranja', 'OB', 1),
(857, 53, 'Pozega-Slavonia', 'PS', 1),
(858, 53, 'Primorje-Gorski Kotar', 'PG', 1),
(859, 53, 'Sibenik', 'SI', 1),
(860, 53, 'Sisak-Moslavina', 'SM', 1),
(861, 53, 'Slavonski Brod-Posavina', 'SB', 1),
(862, 53, 'Split-Dalmatia', 'SD', 1),
(863, 53, 'Varazdin', 'VA', 1),
(864, 53, 'Virovitica-Podravina', 'VP', 1),
(865, 53, 'Vukovar-Srijem', 'VS', 1),
(866, 53, 'Zadar-Knin', 'ZK', 1),
(867, 53, 'Zagreb', 'ZA', 1),
(868, 54, 'Camaguey', 'CA', 1),
(869, 54, 'Ciego de Avila', 'CD', 1),
(870, 54, 'Cienfuegos', 'CI', 1),
(871, 54, 'Ciudad de La Habana', 'CH', 1),
(872, 54, 'Granma', 'GR', 1),
(873, 54, 'Guantanamo', 'GU', 1),
(874, 54, 'Holguin', 'HO', 1),
(875, 54, 'Isla de la Juventud', 'IJ', 1),
(876, 54, 'La Habana', 'LH', 1),
(877, 54, 'Las Tunas', 'LT', 1),
(878, 54, 'Matanzas', 'MA', 1),
(879, 54, 'Pinar del Rio', 'PR', 1),
(880, 54, 'Sancti Spiritus', 'SS', 1),
(881, 54, 'Santiago de Cuba', 'SC', 1),
(882, 54, 'Villa Clara', 'VC', 1),
(883, 55, 'Famagusta', 'F', 1),
(884, 55, 'Kyrenia', 'K', 1),
(885, 55, 'Larnaca', 'A', 1),
(886, 55, 'Limassol', 'I', 1),
(887, 55, 'Nicosia', 'N', 1),
(888, 55, 'Paphos', 'P', 1),
(889, 56, 'Ústecký', 'U', 1),
(890, 56, 'Jihočeský', 'C', 1),
(891, 56, 'Jihomoravský', 'B', 1),
(892, 56, 'Karlovarský', 'K', 1),
(893, 56, 'Královehradecký', 'H', 1),
(894, 56, 'Liberecký', 'L', 1),
(895, 56, 'Moravskoslezský', 'T', 1),
(896, 56, 'Olomoucký', 'M', 1),
(897, 56, 'Pardubický', 'E', 1),
(898, 56, 'Plzeňský', 'P', 1),
(899, 56, 'Praha', 'A', 1),
(900, 56, 'Středočeský', 'S', 1),
(901, 56, 'Vysočina', 'J', 1),
(902, 56, 'Zlínský', 'Z', 1),
(903, 57, 'Arhus', 'AR', 1),
(904, 57, 'Bornholm', 'BH', 1),
(905, 57, 'Copenhagen', 'CO', 1),
(906, 57, 'Faroe Islands', 'FO', 1),
(907, 57, 'Frederiksborg', 'FR', 1),
(908, 57, 'Fyn', 'FY', 1),
(909, 57, 'Kobenhavn', 'KO', 1),
(910, 57, 'Nordjylland', 'NO', 1),
(911, 57, 'Ribe', 'RI', 1),
(912, 57, 'Ringkobing', 'RK', 1),
(913, 57, 'Roskilde', 'RO', 1),
(914, 57, 'Sonderjylland', 'SO', 1),
(915, 57, 'Storstrom', 'ST', 1),
(916, 57, 'Vejle', 'VK', 1),
(917, 57, 'Vestj&aelig;lland', 'VJ', 1),
(918, 57, 'Viborg', 'VB', 1),
(919, 58, '''Ali Sabih', 'S', 1),
(920, 58, 'Dikhil', 'K', 1),
(921, 58, 'Djibouti', 'J', 1),
(922, 58, 'Obock', 'O', 1),
(923, 58, 'Tadjoura', 'T', 1),
(924, 59, 'Saint Andrew Parish', 'AND', 1),
(925, 59, 'Saint David Parish', 'DAV', 1),
(926, 59, 'Saint George Parish', 'GEO', 1),
(927, 59, 'Saint John Parish', 'JOH', 1),
(928, 59, 'Saint Joseph Parish', 'JOS', 1),
(929, 59, 'Saint Luke Parish', 'LUK', 1),
(930, 59, 'Saint Mark Parish', 'MAR', 1),
(931, 59, 'Saint Patrick Parish', 'PAT', 1),
(932, 59, 'Saint Paul Parish', 'PAU', 1),
(933, 59, 'Saint Peter Parish', 'PET', 1),
(934, 60, 'Distrito Nacional', 'DN', 1),
(935, 60, 'Azua', 'AZ', 1),
(936, 60, 'Baoruco', 'BC', 1),
(937, 60, 'Barahona', 'BH', 1),
(938, 60, 'Dajabon', 'DJ', 1),
(939, 60, 'Duarte', 'DU', 1),
(940, 60, 'Elias Pina', 'EL', 1),
(941, 60, 'El Seybo', 'SY', 1),
(942, 60, 'Espaillat', 'ET', 1),
(943, 60, 'Hato Mayor', 'HM', 1),
(944, 60, 'Independencia', 'IN', 1),
(945, 60, 'La Altagracia', 'AL', 1),
(946, 60, 'La Romana', 'RO', 1),
(947, 60, 'La Vega', 'VE', 1),
(948, 60, 'Maria Trinidad Sanchez', 'MT', 1),
(949, 60, 'Monsenor Nouel', 'MN', 1),
(950, 60, 'Monte Cristi', 'MC', 1),
(951, 60, 'Monte Plata', 'MP', 1),
(952, 60, 'Pedernales', 'PD', 1),
(953, 60, 'Peravia (Bani)', 'PR', 1),
(954, 60, 'Puerto Plata', 'PP', 1),
(955, 60, 'Salcedo', 'SL', 1),
(956, 60, 'Samana', 'SM', 1),
(957, 60, 'Sanchez Ramirez', 'SH', 1),
(958, 60, 'San Cristobal', 'SC', 1),
(959, 60, 'San Jose de Ocoa', 'JO', 1),
(960, 60, 'San Juan', 'SJ', 1),
(961, 60, 'San Pedro de Macoris', 'PM', 1),
(962, 60, 'Santiago', 'SA', 1),
(963, 60, 'Santiago Rodriguez', 'ST', 1),
(964, 60, 'Santo Domingo', 'SD', 1),
(965, 60, 'Valverde', 'VA', 1),
(966, 61, 'Aileu', 'AL', 1),
(967, 61, 'Ainaro', 'AN', 1),
(968, 61, 'Baucau', 'BA', 1),
(969, 61, 'Bobonaro', 'BO', 1),
(970, 61, 'Cova Lima', 'CO', 1),
(971, 61, 'Dili', 'DI', 1),
(972, 61, 'Ermera', 'ER', 1),
(973, 61, 'Lautem', 'LA', 1),
(974, 61, 'Liquica', 'LI', 1),
(975, 61, 'Manatuto', 'MT', 1),
(976, 61, 'Manufahi', 'MF', 1),
(977, 61, 'Oecussi', 'OE', 1),
(978, 61, 'Viqueque', 'VI', 1),
(979, 62, 'Azuay', 'AZU', 1),
(980, 62, 'Bolivar', 'BOL', 1),
(981, 62, 'Ca&ntilde;ar', 'CAN', 1),
(982, 62, 'Carchi', 'CAR', 1),
(983, 62, 'Chimborazo', 'CHI', 1),
(984, 62, 'Cotopaxi', 'COT', 1),
(985, 62, 'El Oro', 'EOR', 1),
(986, 62, 'Esmeraldas', 'ESM', 1),
(987, 62, 'Gal&aacute;pagos', 'GPS', 1),
(988, 62, 'Guayas', 'GUA', 1),
(989, 62, 'Imbabura', 'IMB', 1),
(990, 62, 'Loja', 'LOJ', 1),
(991, 62, 'Los Rios', 'LRO', 1),
(992, 62, 'Manab&iacute;', 'MAN', 1),
(993, 62, 'Morona Santiago', 'MSA', 1),
(994, 62, 'Napo', 'NAP', 1),
(995, 62, 'Orellana', 'ORE', 1),
(996, 62, 'Pastaza', 'PAS', 1),
(997, 62, 'Pichincha', 'PIC', 1),
(998, 62, 'Sucumb&iacute;os', 'SUC', 1),
(999, 62, 'Tungurahua', 'TUN', 1),
(1000, 62, 'Zamora Chinchipe', 'ZCH', 1),
(1001, 63, 'Ad Daqahliyah', 'DHY', 1),
(1002, 63, 'Al Bahr al Ahmar', 'BAM', 1),
(1003, 63, 'Al Buhayrah', 'BHY', 1),
(1004, 63, 'Al Fayyum', 'FYM', 1),
(1005, 63, 'Al Gharbiyah', 'GBY', 1),
(1006, 63, 'Al Iskandariyah', 'IDR', 1),
(1007, 63, 'Al Isma''iliyah', 'IML', 1),
(1008, 63, 'Al Jizah', 'JZH', 1),
(1009, 63, 'Al Minufiyah', 'MFY', 1),
(1010, 63, 'Al Minya', 'MNY', 1),
(1011, 63, 'Al Qahirah', 'QHR', 1),
(1012, 63, 'Al Qalyubiyah', 'QLY', 1),
(1013, 63, 'Al Wadi al Jadid', 'WJD', 1),
(1014, 63, 'Ash Sharqiyah', 'SHQ', 1),
(1015, 63, 'As Suways', 'SWY', 1),
(1016, 63, 'Aswan', 'ASW', 1),
(1017, 63, 'Asyut', 'ASY', 1),
(1018, 63, 'Bani Suwayf', 'BSW', 1),
(1019, 63, 'Bur Sa''id', 'BSD', 1),
(1020, 63, 'Dumyat', 'DMY', 1),
(1021, 63, 'Janub Sina''', 'JNS', 1),
(1022, 63, 'Kafr ash Shaykh', 'KSH', 1),
(1023, 63, 'Matruh', 'MAT', 1),
(1024, 63, 'Qina', 'QIN', 1),
(1025, 63, 'Shamal Sina''', 'SHS', 1),
(1026, 63, 'Suhaj', 'SUH', 1),
(1027, 64, 'Ahuachapan', 'AH', 1),
(1028, 64, 'Cabanas', 'CA', 1),
(1029, 64, 'Chalatenango', 'CH', 1),
(1030, 64, 'Cuscatlan', 'CU', 1),
(1031, 64, 'La Libertad', 'LB', 1),
(1032, 64, 'La Paz', 'PZ', 1),
(1033, 64, 'La Union', 'UN', 1),
(1034, 64, 'Morazan', 'MO', 1),
(1035, 64, 'San Miguel', 'SM', 1),
(1036, 64, 'San Salvador', 'SS', 1),
(1037, 64, 'San Vicente', 'SV', 1),
(1038, 64, 'Santa Ana', 'SA', 1),
(1039, 64, 'Sonsonate', 'SO', 1),
(1040, 64, 'Usulutan', 'US', 1),
(1041, 65, 'Provincia Annobon', 'AN', 1),
(1042, 65, 'Provincia Bioko Norte', 'BN', 1),
(1043, 65, 'Provincia Bioko Sur', 'BS', 1),
(1044, 65, 'Provincia Centro Sur', 'CS', 1),
(1045, 65, 'Provincia Kie-Ntem', 'KN', 1),
(1046, 65, 'Provincia Litoral', 'LI', 1),
(1047, 65, 'Provincia Wele-Nzas', 'WN', 1),
(1048, 66, 'Central (Maekel)', 'MA', 1),
(1049, 66, 'Anseba (Keren)', 'KE', 1),
(1050, 66, 'Southern Red Sea (Debub-Keih-Bahri)', 'DK', 1),
(1051, 66, 'Northern Red Sea (Semien-Keih-Bahri)', 'SK', 1),
(1052, 66, 'Southern (Debub)', 'DE', 1),
(1053, 66, 'Gash-Barka (Barentu)', 'BR', 1),
(1054, 67, 'Harjumaa (Tallinn)', 'HA', 1),
(1055, 67, 'Hiiumaa (Kardla)', 'HI', 1),
(1056, 67, 'Ida-Virumaa (Johvi)', 'IV', 1),
(1057, 67, 'Jarvamaa (Paide)', 'JA', 1),
(1058, 67, 'Jogevamaa (Jogeva)', 'JO', 1),
(1059, 67, 'Laane-Virumaa (Rakvere)', 'LV', 1),
(1060, 67, 'Laanemaa (Haapsalu)', 'LA', 1),
(1061, 67, 'Parnumaa (Parnu)', 'PA', 1),
(1062, 67, 'Polvamaa (Polva)', 'PO', 1),
(1063, 67, 'Raplamaa (Rapla)', 'RA', 1),
(1064, 67, 'Saaremaa (Kuessaare)', 'SA', 1),
(1065, 67, 'Tartumaa (Tartu)', 'TA', 1),
(1066, 67, 'Valgamaa (Valga)', 'VA', 1),
(1067, 67, 'Viljandimaa (Viljandi)', 'VI', 1),
(1068, 67, 'Vorumaa (Voru)', 'VO', 1),
(1069, 68, 'Afar', 'AF', 1),
(1070, 68, 'Amhara', 'AH', 1),
(1071, 68, 'Benishangul-Gumaz', 'BG', 1),
(1072, 68, 'Gambela', 'GB', 1),
(1073, 68, 'Hariai', 'HR', 1),
(1074, 68, 'Oromia', 'OR', 1),
(1075, 68, 'Somali', 'SM', 1),
(1076, 68, 'Southern Nations - Nationalities and Peoples Region', 'SN', 1),
(1077, 68, 'Tigray', 'TG', 1),
(1078, 68, 'Addis Ababa', 'AA', 1),
(1079, 68, 'Dire Dawa', 'DD', 1),
(1080, 71, 'Central Division', 'C', 1),
(1081, 71, 'Northern Division', 'N', 1),
(1082, 71, 'Eastern Division', 'E', 1),
(1083, 71, 'Western Division', 'W', 1),
(1084, 71, 'Rotuma', 'R', 1),
(1085, 72, 'Ahvenanmaan Laani', 'AL', 1),
(1086, 72, 'Etela-Suomen Laani', 'ES', 1),
(1087, 72, 'Ita-Suomen Laani', 'IS', 1),
(1088, 72, 'Lansi-Suomen Laani', 'LS', 1),
(1089, 72, 'Lapin Lanani', 'LA', 1),
(1090, 72, 'Oulun Laani', 'OU', 1),
(1091, 73, 'Alsace', 'AL', 1),
(1092, 73, 'Aquitaine', 'AQ', 1),
(1093, 73, 'Auvergne', 'AU', 1),
(1094, 73, 'Brittany', 'BR', 1),
(1095, 73, 'Burgundy', 'BU', 1),
(1096, 73, 'Center Loire Valley', 'CE', 1),
(1097, 73, 'Champagne', 'CH', 1),
(1098, 73, 'Corse', 'CO', 1),
(1099, 73, 'France Comte', 'FR', 1),
(1100, 73, 'Languedoc Roussillon', 'LA', 1),
(1101, 73, 'Limousin', 'LI', 1),
(1102, 73, 'Lorraine', 'LO', 1),
(1103, 73, 'Midi Pyrenees', 'MI', 1),
(1104, 73, 'Nord Pas de Calais', 'NO', 1),
(1105, 73, 'Normandy', 'NR', 1),
(1106, 73, 'Paris / Ill de France', 'PA', 1),
(1107, 73, 'Picardie', 'PI', 1),
(1108, 73, 'Poitou Charente', 'PO', 1),
(1109, 73, 'Provence', 'PR', 1),
(1110, 73, 'Rhone Alps', 'RH', 1),
(1111, 73, 'Riviera', 'RI', 1),
(1112, 73, 'Western Loire Valley', 'WE', 1),
(1113, 74, 'Etranger', 'Et', 1),
(1114, 74, 'Ain', '01', 1),
(1115, 74, 'Aisne', '02', 1),
(1116, 74, 'Allier', '03', 1),
(1117, 74, 'Alpes de Haute Provence', '04', 1),
(1118, 74, 'Hautes-Alpes', '05', 1),
(1119, 74, 'Alpes Maritimes', '06', 1),
(1120, 74, 'Ard&egrave;che', '07', 1),
(1121, 74, 'Ardennes', '08', 1),
(1122, 74, 'Ari&egrave;ge', '09', 1),
(1123, 74, 'Aube', '10', 1),
(1124, 74, 'Aude', '11', 1),
(1125, 74, 'Aveyron', '12', 1),
(1126, 74, 'Bouches du Rh&ocirc;ne', '13', 1),
(1127, 74, 'Calvados', '14', 1),
(1128, 74, 'Cantal', '15', 1),
(1129, 74, 'Charente', '16', 1),
(1130, 74, 'Charente Maritime', '17', 1),
(1131, 74, 'Cher', '18', 1),
(1132, 74, 'Corr&egrave;ze', '19', 1),
(1133, 74, 'Corse du Sud', '2A', 1),
(1134, 74, 'Haute Corse', '2B', 1),
(1135, 74, 'C&ocirc;te d&#039;or', '21', 1),
(1136, 74, 'C&ocirc;tes d&#039;Armor', '22', 1),
(1137, 74, 'Creuse', '23', 1),
(1138, 74, 'Dordogne', '24', 1),
(1139, 74, 'Doubs', '25', 1),
(1140, 74, 'Dr&ocirc;me', '26', 1),
(1141, 74, 'Eure', '27', 1),
(1142, 74, 'Eure et Loir', '28', 1),
(1143, 74, 'Finist&egrave;re', '29', 1),
(1144, 74, 'Gard', '30', 1),
(1145, 74, 'Haute Garonne', '31', 1),
(1146, 74, 'Gers', '32', 1),
(1147, 74, 'Gironde', '33', 1),
(1148, 74, 'H&eacute;rault', '34', 1),
(1149, 74, 'Ille et Vilaine', '35', 1),
(1150, 74, 'Indre', '36', 1),
(1151, 74, 'Indre et Loire', '37', 1),
(1152, 74, 'Is&eacute;re', '38', 1),
(1153, 74, 'Jura', '39', 1),
(1154, 74, 'Landes', '40', 1),
(1155, 74, 'Loir et Cher', '41', 1),
(1156, 74, 'Loire', '42', 1),
(1157, 74, 'Haute Loire', '43', 1),
(1158, 74, 'Loire Atlantique', '44', 1),
(1159, 74, 'Loiret', '45', 1),
(1160, 74, 'Lot', '46', 1),
(1161, 74, 'Lot et Garonne', '47', 1),
(1162, 74, 'Loz&egrave;re', '48', 1),
(1163, 74, 'Maine et Loire', '49', 1),
(1164, 74, 'Manche', '50', 1),
(1165, 74, 'Marne', '51', 1),
(1166, 74, 'Haute Marne', '52', 1),
(1167, 74, 'Mayenne', '53', 1),
(1168, 74, 'Meurthe et Moselle', '54', 1),
(1169, 74, 'Meuse', '55', 1),
(1170, 74, 'Morbihan', '56', 1),
(1171, 74, 'Moselle', '57', 1),
(1172, 74, 'Ni&egrave;vre', '58', 1),
(1173, 74, 'Nord', '59', 1),
(1174, 74, 'Oise', '60', 1),
(1175, 74, 'Orne', '61', 1),
(1176, 74, 'Pas de Calais', '62', 1),
(1177, 74, 'Puy de D&ocirc;me', '63', 1),
(1178, 74, 'Pyr&eacute;n&eacute;es Atlantiques', '64', 1),
(1179, 74, 'Hautes Pyr&eacute;n&eacute;es', '65', 1),
(1180, 74, 'Pyr&eacute;n&eacute;es Orientales', '66', 1),
(1181, 74, 'Bas Rhin', '67', 1),
(1182, 74, 'Haut Rhin', '68', 1),
(1183, 74, 'Rh&ocirc;ne', '69', 1),
(1184, 74, 'Haute Sa&ocirc;ne', '70', 1),
(1185, 74, 'Sa&ocirc;ne et Loire', '71', 1),
(1186, 74, 'Sarthe', '72', 1),
(1187, 74, 'Savoie', '73', 1),
(1188, 74, 'Haute Savoie', '74', 1),
(1189, 74, 'Paris', '75', 1),
(1190, 74, 'Seine Maritime', '76', 1),
(1191, 74, 'Seine et Marne', '77', 1),
(1192, 74, 'Yvelines', '78', 1),
(1193, 74, 'Deux S&egrave;vres', '79', 1),
(1194, 74, 'Somme', '80', 1),
(1195, 74, 'Tarn', '81', 1),
(1196, 74, 'Tarn et Garonne', '82', 1),
(1197, 74, 'Var', '83', 1),
(1198, 74, 'Vaucluse', '84', 1),
(1199, 74, 'Vend&eacute;e', '85', 1),
(1200, 74, 'Vienne', '86', 1),
(1201, 74, 'Haute Vienne', '87', 1),
(1202, 74, 'Vosges', '88', 1),
(1203, 74, 'Yonne', '89', 1),
(1204, 74, 'Territoire de Belfort', '90', 1),
(1205, 74, 'Essonne', '91', 1),
(1206, 74, 'Hauts de Seine', '92', 1),
(1207, 74, 'Seine St-Denis', '93', 1),
(1208, 74, 'Val de Marne', '94', 1),
(1209, 74, 'Val d''Oise', '95', 1),
(1210, 76, 'Archipel des Marquises', 'M', 1),
(1211, 76, 'Archipel des Tuamotu', 'T', 1),
(1212, 76, 'Archipel des Tubuai', 'I', 1),
(1213, 76, 'Iles du Vent', 'V', 1),
(1214, 76, 'Iles Sous-le-Vent', 'S', 1),
(1215, 77, 'Iles Crozet', 'C', 1),
(1216, 77, 'Iles Kerguelen', 'K', 1),
(1217, 77, 'Ile Amsterdam', 'A', 1),
(1218, 77, 'Ile Saint-Paul', 'P', 1),
(1219, 77, 'Adelie Land', 'D', 1),
(1220, 78, 'Estuaire', 'ES', 1),
(1221, 78, 'Haut-Ogooue', 'HO', 1),
(1222, 78, 'Moyen-Ogooue', 'MO', 1),
(1223, 78, 'Ngounie', 'NG', 1),
(1224, 78, 'Nyanga', 'NY', 1),
(1225, 78, 'Ogooue-Ivindo', 'OI', 1),
(1226, 78, 'Ogooue-Lolo', 'OL', 1),
(1227, 78, 'Ogooue-Maritime', 'OM', 1),
(1228, 78, 'Woleu-Ntem', 'WN', 1),
(1229, 79, 'Banjul', 'BJ', 1),
(1230, 79, 'Basse', 'BS', 1),
(1231, 79, 'Brikama', 'BR', 1),
(1232, 79, 'Janjangbure', 'JA', 1),
(1233, 79, 'Kanifeng', 'KA', 1),
(1234, 79, 'Kerewan', 'KE', 1),
(1235, 79, 'Kuntaur', 'KU', 1),
(1236, 79, 'Mansakonko', 'MA', 1),
(1237, 79, 'Lower River', 'LR', 1),
(1238, 79, 'Central River', 'CR', 1),
(1239, 79, 'North Bank', 'NB', 1),
(1240, 79, 'Upper River', 'UR', 1),
(1241, 79, 'Western', 'WE', 1),
(1242, 80, 'Abkhazia', 'AB', 1),
(1243, 80, 'Ajaria', 'AJ', 1),
(1244, 80, 'Tbilisi', 'TB', 1),
(1245, 80, 'Guria', 'GU', 1),
(1246, 80, 'Imereti', 'IM', 1),
(1247, 80, 'Kakheti', 'KA', 1),
(1248, 80, 'Kvemo Kartli', 'KK', 1),
(1249, 80, 'Mtskheta-Mtianeti', 'MM', 1),
(1250, 80, 'Racha Lechkhumi and Kvemo Svanet', 'RL', 1),
(1251, 80, 'Samegrelo-Zemo Svaneti', 'SZ', 1),
(1252, 80, 'Samtskhe-Javakheti', 'SJ', 1),
(1253, 80, 'Shida Kartli', 'SK', 1),
(1254, 81, 'Baden-W&uuml;rttemberg', 'BAW', 1),
(1255, 81, 'Bayern', 'BAY', 1),
(1256, 81, 'Berlin', 'BER', 1),
(1257, 81, 'Brandenburg', 'BRG', 1),
(1258, 81, 'Bremen', 'BRE', 1),
(1259, 81, 'Hamburg', 'HAM', 1),
(1260, 81, 'Hessen', 'HES', 1),
(1261, 81, 'Mecklenburg-Vorpommern', 'MEC', 1),
(1262, 81, 'Niedersachsen', 'NDS', 1),
(1263, 81, 'Nordrhein-Westfalen', 'NRW', 1),
(1264, 81, 'Rheinland-Pfalz', 'RHE', 1),
(1265, 81, 'Saarland', 'SAR', 1),
(1266, 81, 'Sachsen', 'SAS', 1),
(1267, 81, 'Sachsen-Anhalt', 'SAC', 1),
(1268, 81, 'Schleswig-Holstein', 'SCN', 1),
(1269, 81, 'Th&uuml;ringen', 'THE', 1),
(1270, 82, 'Ashanti Region', 'AS', 1),
(1271, 82, 'Brong-Ahafo Region', 'BA', 1),
(1272, 82, 'Central Region', 'CE', 1),
(1273, 82, 'Eastern Region', 'EA', 1),
(1274, 82, 'Greater Accra Region', 'GA', 1),
(1275, 82, 'Northern Region', 'NO', 1),
(1276, 82, 'Upper East Region', 'UE', 1),
(1277, 82, 'Upper West Region', 'UW', 1),
(1278, 82, 'Volta Region', 'VO', 1),
(1279, 82, 'Western Region', 'WE', 1),
(1280, 84, 'Attica', 'AT', 1),
(1281, 84, 'Central Greece', 'CN', 1),
(1282, 84, 'Central Macedonia', 'CM', 1),
(1283, 84, 'Crete', 'CR', 1),
(1284, 84, 'East Macedonia and Thrace', 'EM', 1),
(1285, 84, 'Epirus', 'EP', 1),
(1286, 84, 'Ionian Islands', 'II', 1),
(1287, 84, 'North Aegean', 'NA', 1),
(1288, 84, 'Peloponnesos', 'PP', 1),
(1289, 84, 'South Aegean', 'SA', 1),
(1290, 84, 'Thessaly', 'TH', 1),
(1291, 84, 'West Greece', 'WG', 1),
(1292, 84, 'West Macedonia', 'WM', 1),
(1293, 85, 'Avannaa', 'A', 1),
(1294, 85, 'Tunu', 'T', 1),
(1295, 85, 'Kitaa', 'K', 1),
(1296, 86, 'Saint Andrew', 'A', 1),
(1297, 86, 'Saint David', 'D', 1),
(1298, 86, 'Saint George', 'G', 1),
(1299, 86, 'Saint John', 'J', 1),
(1300, 86, 'Saint Mark', 'M', 1),
(1301, 86, 'Saint Patrick', 'P', 1),
(1302, 86, 'Carriacou', 'C', 1),
(1303, 86, 'Petit Martinique', 'Q', 1),
(1304, 89, 'Alta Verapaz', 'AV', 1),
(1305, 89, 'Baja Verapaz', 'BV', 1),
(1306, 89, 'Chimaltenango', 'CM', 1),
(1307, 89, 'Chiquimula', 'CQ', 1),
(1308, 89, 'El Peten', 'PE', 1),
(1309, 89, 'El Progreso', 'PR', 1),
(1310, 89, 'El Quiche', 'QC', 1),
(1311, 89, 'Escuintla', 'ES', 1),
(1312, 89, 'Guatemala', 'GU', 1),
(1313, 89, 'Huehuetenango', 'HU', 1),
(1314, 89, 'Izabal', 'IZ', 1),
(1315, 89, 'Jalapa', 'JA', 1),
(1316, 89, 'Jutiapa', 'JU', 1),
(1317, 89, 'Quetzaltenango', 'QZ', 1),
(1318, 89, 'Retalhuleu', 'RE', 1),
(1319, 89, 'Sacatepequez', 'ST', 1),
(1320, 89, 'San Marcos', 'SM', 1),
(1321, 89, 'Santa Rosa', 'SR', 1),
(1322, 89, 'Solola', 'SO', 1),
(1323, 89, 'Suchitepequez', 'SU', 1),
(1324, 89, 'Totonicapan', 'TO', 1),
(1325, 89, 'Zacapa', 'ZA', 1),
(1326, 90, 'Conakry', 'CNK', 1),
(1327, 90, 'Beyla', 'BYL', 1),
(1328, 90, 'Boffa', 'BFA', 1),
(1329, 90, 'Boke', 'BOK', 1),
(1330, 90, 'Coyah', 'COY', 1),
(1331, 90, 'Dabola', 'DBL', 1),
(1332, 90, 'Dalaba', 'DLB', 1),
(1333, 90, 'Dinguiraye', 'DGR', 1),
(1334, 90, 'Dubreka', 'DBR', 1),
(1335, 90, 'Faranah', 'FRN', 1),
(1336, 90, 'Forecariah', 'FRC', 1),
(1337, 90, 'Fria', 'FRI', 1),
(1338, 90, 'Gaoual', 'GAO', 1),
(1339, 90, 'Gueckedou', 'GCD', 1),
(1340, 90, 'Kankan', 'KNK', 1),
(1341, 90, 'Kerouane', 'KRN', 1),
(1342, 90, 'Kindia', 'KND', 1),
(1343, 90, 'Kissidougou', 'KSD', 1),
(1344, 90, 'Koubia', 'KBA', 1),
(1345, 90, 'Koundara', 'KDA', 1),
(1346, 90, 'Kouroussa', 'KRA', 1),
(1347, 90, 'Labe', 'LAB', 1),
(1348, 90, 'Lelouma', 'LLM', 1),
(1349, 90, 'Lola', 'LOL', 1),
(1350, 90, 'Macenta', 'MCT', 1),
(1351, 90, 'Mali', 'MAL', 1),
(1352, 90, 'Mamou', 'MAM', 1),
(1353, 90, 'Mandiana', 'MAN', 1),
(1354, 90, 'Nzerekore', 'NZR', 1),
(1355, 90, 'Pita', 'PIT', 1),
(1356, 90, 'Siguiri', 'SIG', 1),
(1357, 90, 'Telimele', 'TLM', 1),
(1358, 90, 'Tougue', 'TOG', 1),
(1359, 90, 'Yomou', 'YOM', 1),
(1360, 91, 'Bafata Region', 'BF', 1),
(1361, 91, 'Biombo Region', 'BB', 1),
(1362, 91, 'Bissau Region', 'BS', 1),
(1363, 91, 'Bolama Region', 'BL', 1),
(1364, 91, 'Cacheu Region', 'CA', 1),
(1365, 91, 'Gabu Region', 'GA', 1),
(1366, 91, 'Oio Region', 'OI', 1),
(1367, 91, 'Quinara Region', 'QU', 1),
(1368, 91, 'Tombali Region', 'TO', 1),
(1369, 92, 'Barima-Waini', 'BW', 1),
(1370, 92, 'Cuyuni-Mazaruni', 'CM', 1),
(1371, 92, 'Demerara-Mahaica', 'DM', 1),
(1372, 92, 'East Berbice-Corentyne', 'EC', 1),
(1373, 92, 'Essequibo Islands-West Demerara', 'EW', 1),
(1374, 92, 'Mahaica-Berbice', 'MB', 1),
(1375, 92, 'Pomeroon-Supenaam', 'PM', 1),
(1376, 92, 'Potaro-Siparuni', 'PI', 1),
(1377, 92, 'Upper Demerara-Berbice', 'UD', 1),
(1378, 92, 'Upper Takutu-Upper Essequibo', 'UT', 1),
(1379, 93, 'Artibonite', 'AR', 1),
(1380, 93, 'Centre', 'CE', 1),
(1381, 93, 'Grand''Anse', 'GA', 1),
(1382, 93, 'Nord', 'ND', 1),
(1383, 93, 'Nord-Est', 'NE', 1),
(1384, 93, 'Nord-Ouest', 'NO', 1),
(1385, 93, 'Ouest', 'OU', 1),
(1386, 93, 'Sud', 'SD', 1),
(1387, 93, 'Sud-Est', 'SE', 1),
(1388, 94, 'Flat Island', 'F', 1),
(1389, 94, 'McDonald Island', 'M', 1),
(1390, 94, 'Shag Island', 'S', 1),
(1391, 94, 'Heard Island', 'H', 1),
(1392, 95, 'Atlantida', 'AT', 1),
(1393, 95, 'Choluteca', 'CH', 1),
(1394, 95, 'Colon', 'CL', 1),
(1395, 95, 'Comayagua', 'CM', 1),
(1396, 95, 'Copan', 'CP', 1),
(1397, 95, 'Cortes', 'CR', 1),
(1398, 95, 'El Paraiso', 'PA', 1),
(1399, 95, 'Francisco Morazan', 'FM', 1),
(1400, 95, 'Gracias a Dios', 'GD', 1),
(1401, 95, 'Intibuca', 'IN', 1),
(1402, 95, 'Islas de la Bahia (Bay Islands)', 'IB', 1),
(1403, 95, 'La Paz', 'PZ', 1),
(1404, 95, 'Lempira', 'LE', 1),
(1405, 95, 'Ocotepeque', 'OC', 1),
(1406, 95, 'Olancho', 'OL', 1),
(1407, 95, 'Santa Barbara', 'SB', 1),
(1408, 95, 'Valle', 'VA', 1),
(1409, 95, 'Yoro', 'YO', 1),
(1410, 96, 'Central and Western Hong Kong Island', 'HCW', 1),
(1411, 96, 'Eastern Hong Kong Island', 'HEA', 1),
(1412, 96, 'Southern Hong Kong Island', 'HSO', 1),
(1413, 96, 'Wan Chai Hong Kong Island', 'HWC', 1),
(1414, 96, 'Kowloon City Kowloon', 'KKC', 1),
(1415, 96, 'Kwun Tong Kowloon', 'KKT', 1),
(1416, 96, 'Sham Shui Po Kowloon', 'KSS', 1),
(1417, 96, 'Wong Tai Sin Kowloon', 'KWT', 1),
(1418, 96, 'Yau Tsim Mong Kowloon', 'KYT', 1),
(1419, 96, 'Islands New Territories', 'NIS', 1),
(1420, 96, 'Kwai Tsing New Territories', 'NKT', 1),
(1421, 96, 'North New Territories', 'NNO', 1),
(1422, 96, 'Sai Kung New Territories', 'NSK', 1),
(1423, 96, 'Sha Tin New Territories', 'NST', 1),
(1424, 96, 'Tai Po New Territories', 'NTP', 1),
(1425, 96, 'Tsuen Wan New Territories', 'NTW', 1),
(1426, 96, 'Tuen Mun New Territories', 'NTM', 1),
(1427, 96, 'Yuen Long New Territories', 'NYL', 1),
(1428, 97, 'Bacs-Kiskun', 'BK', 1),
(1429, 97, 'Baranya', 'BA', 1),
(1430, 97, 'Bekes', 'BE', 1),
(1431, 97, 'Bekescsaba', 'BS', 1),
(1432, 97, 'Borsod-Abauj-Zemplen', 'BZ', 1),
(1433, 97, 'Budapest', 'BU', 1),
(1434, 97, 'Csongrad', 'CS', 1),
(1435, 97, 'Debrecen', 'DE', 1),
(1436, 97, 'Dunaujvaros', 'DU', 1),
(1437, 97, 'Eger', 'EG', 1),
(1438, 97, 'Fejer', 'FE', 1),
(1439, 97, 'Gyor', 'GY', 1),
(1440, 97, 'Gyor-Moson-Sopron', 'GM', 1),
(1441, 97, 'Hajdu-Bihar', 'HB', 1),
(1442, 97, 'Heves', 'HE', 1),
(1443, 97, 'Hodmezovasarhely', 'HO', 1),
(1444, 97, 'Jasz-Nagykun-Szolnok', 'JN', 1),
(1445, 97, 'Kaposvar', 'KA', 1),
(1446, 97, 'Kecskemet', 'KE', 1),
(1447, 97, 'Komarom-Esztergom', 'KO', 1),
(1448, 97, 'Miskolc', 'MI', 1),
(1449, 97, 'Nagykanizsa', 'NA', 1),
(1450, 97, 'Nograd', 'NO', 1),
(1451, 97, 'Nyiregyhaza', 'NY', 1),
(1452, 97, 'Pecs', 'PE', 1),
(1453, 97, 'Pest', 'PS', 1),
(1454, 97, 'Somogy', 'SO', 1),
(1455, 97, 'Sopron', 'SP', 1),
(1456, 97, 'Szabolcs-Szatmar-Bereg', 'SS', 1),
(1457, 97, 'Szeged', 'SZ', 1),
(1458, 97, 'Szekesfehervar', 'SE', 1),
(1459, 97, 'Szolnok', 'SL', 1),
(1460, 97, 'Szombathely', 'SM', 1),
(1461, 97, 'Tatabanya', 'TA', 1),
(1462, 97, 'Tolna', 'TO', 1),
(1463, 97, 'Vas', 'VA', 1),
(1464, 97, 'Veszprem', 'VE', 1),
(1465, 97, 'Zala', 'ZA', 1),
(1466, 97, 'Zalaegerszeg', 'ZZ', 1),
(1467, 98, 'Austurland', 'AL', 1),
(1468, 98, 'Hofuoborgarsvaeoi', 'HF', 1),
(1469, 98, 'Norourland eystra', 'NE', 1),
(1470, 98, 'Norourland vestra', 'NV', 1),
(1471, 98, 'Suourland', 'SL', 1),
(1472, 98, 'Suournes', 'SN', 1),
(1473, 98, 'Vestfiroir', 'VF', 1),
(1474, 98, 'Vesturland', 'VL', 1),
(1475, 99, 'Andaman and Nicobar Islands', 'AN', 1),
(1476, 99, 'Andhra Pradesh', 'AP', 1),
(1477, 99, 'Arunachal Pradesh', 'AR', 1),
(1478, 99, 'Assam', 'AS', 1),
(1479, 99, 'Bihar', 'BI', 1),
(1480, 99, 'Chandigarh', 'CH', 1),
(1481, 99, 'Dadra and Nagar Haveli', 'DA', 1),
(1482, 99, 'Daman and Diu', 'DM', 1),
(1483, 99, 'Delhi', 'DE', 1),
(1484, 99, 'Goa', 'GO', 1),
(1485, 99, 'Gujarat', 'GU', 1),
(1486, 99, 'Haryana', 'HA', 1),
(1487, 99, 'Himachal Pradesh', 'HP', 1),
(1488, 99, 'Jammu and Kashmir', 'JA', 1),
(1489, 99, 'Karnataka', 'KA', 1),
(1490, 99, 'Kerala', 'KE', 1),
(1491, 99, 'Lakshadweep Islands', 'LI', 1),
(1492, 99, 'Madhya Pradesh', 'MP', 1),
(1493, 99, 'Maharashtra', 'MA', 1),
(1494, 99, 'Manipur', 'MN', 1),
(1495, 99, 'Meghalaya', 'ME', 1),
(1496, 99, 'Mizoram', 'MI', 1),
(1497, 99, 'Nagaland', 'NA', 1),
(1498, 99, 'Orissa', 'OR', 1),
(1499, 99, 'Pondicherry', 'PO', 1),
(1500, 99, 'Punjab', 'PU', 1),
(1501, 99, 'Rajasthan', 'RA', 1),
(1502, 99, 'Sikkim', 'SI', 1),
(1503, 99, 'Tamil Nadu', 'TN', 1),
(1504, 99, 'Tripura', 'TR', 1),
(1505, 99, 'Uttar Pradesh', 'UP', 1),
(1506, 99, 'West Bengal', 'WB', 1),
(1507, 100, 'Aceh', 'AC', 1),
(1508, 100, 'Bali', 'BA', 1),
(1509, 100, 'Banten', 'BT', 1),
(1510, 100, 'Bengkulu', 'BE', 1),
(1511, 100, 'BoDeTaBek', 'BD', 1),
(1512, 100, 'Gorontalo', 'GO', 1),
(1513, 100, 'Jakarta Raya', 'JK', 1),
(1514, 100, 'Jambi', 'JA', 1),
(1515, 100, 'Jawa Barat', 'JB', 1),
(1516, 100, 'Jawa Tengah', 'JT', 1),
(1517, 100, 'Jawa Timur', 'JI', 1),
(1518, 100, 'Kalimantan Barat', 'KB', 1),
(1519, 100, 'Kalimantan Selatan', 'KS', 1),
(1520, 100, 'Kalimantan Tengah', 'KT', 1),
(1521, 100, 'Kalimantan Timur', 'KI', 1),
(1522, 100, 'Kepulauan Bangka Belitung', 'BB', 1),
(1523, 100, 'Lampung', 'LA', 1),
(1524, 100, 'Maluku', 'MA', 1),
(1525, 100, 'Maluku Utara', 'MU', 1),
(1526, 100, 'Nusa Tenggara Barat', 'NB', 1),
(1527, 100, 'Nusa Tenggara Timur', 'NT', 1),
(1528, 100, 'Papua', 'PA', 1),
(1529, 100, 'Riau', 'RI', 1),
(1530, 100, 'Sulawesi Selatan', 'SN', 1),
(1531, 100, 'Sulawesi Tengah', 'ST', 1),
(1532, 100, 'Sulawesi Tenggara', 'SG', 1),
(1533, 100, 'Sulawesi Utara', 'SA', 1),
(1534, 100, 'Sumatera Barat', 'SB', 1),
(1535, 100, 'Sumatera Selatan', 'SS', 1),
(1536, 100, 'Sumatera Utara', 'SU', 1),
(1537, 100, 'Yogyakarta', 'YO', 1),
(1538, 101, 'Tehran', 'TEH', 1),
(1539, 101, 'Qom', 'QOM', 1),
(1540, 101, 'Markazi', 'MKZ', 1);
INSERT INTO `zone` (`zone_id`, `country_id`, `name`, `code`, `status`) VALUES
(1541, 101, 'Qazvin', 'QAZ', 1),
(1542, 101, 'Gilan', 'GIL', 1),
(1543, 101, 'Ardabil', 'ARD', 1),
(1544, 101, 'Zanjan', 'ZAN', 1),
(1545, 101, 'East Azarbaijan', 'EAZ', 1),
(1546, 101, 'West Azarbaijan', 'WEZ', 1),
(1547, 101, 'Kurdistan', 'KRD', 1),
(1548, 101, 'Hamadan', 'HMD', 1),
(1549, 101, 'Kermanshah', 'KRM', 1),
(1550, 101, 'Ilam', 'ILM', 1),
(1551, 101, 'Lorestan', 'LRS', 1),
(1552, 101, 'Khuzestan', 'KZT', 1),
(1553, 101, 'Chahar Mahaal and Bakhtiari', 'CMB', 1),
(1554, 101, 'Kohkiluyeh and Buyer Ahmad', 'KBA', 1),
(1555, 101, 'Bushehr', 'BSH', 1),
(1556, 101, 'Fars', 'FAR', 1),
(1557, 101, 'Hormozgan', 'HRM', 1),
(1558, 101, 'Sistan and Baluchistan', 'SBL', 1),
(1559, 101, 'Kerman', 'KRB', 1),
(1560, 101, 'Yazd', 'YZD', 1),
(1561, 101, 'Esfahan', 'EFH', 1),
(1562, 101, 'Semnan', 'SMN', 1),
(1563, 101, 'Mazandaran', 'MZD', 1),
(1564, 101, 'Golestan', 'GLS', 1),
(1565, 101, 'North Khorasan', 'NKH', 1),
(1566, 101, 'Razavi Khorasan', 'RKH', 1),
(1567, 101, 'South Khorasan', 'SKH', 1),
(1568, 102, 'Baghdad', 'BD', 1),
(1569, 102, 'Salah ad Din', 'SD', 1),
(1570, 102, 'Diyala', 'DY', 1),
(1571, 102, 'Wasit', 'WS', 1),
(1572, 102, 'Maysan', 'MY', 1),
(1573, 102, 'Al Basrah', 'BA', 1),
(1574, 102, 'Dhi Qar', 'DQ', 1),
(1575, 102, 'Al Muthanna', 'MU', 1),
(1576, 102, 'Al Qadisyah', 'QA', 1),
(1577, 102, 'Babil', 'BB', 1),
(1578, 102, 'Al Karbala', 'KB', 1),
(1579, 102, 'An Najaf', 'NJ', 1),
(1580, 102, 'Al Anbar', 'AB', 1),
(1581, 102, 'Ninawa', 'NN', 1),
(1582, 102, 'Dahuk', 'DH', 1),
(1583, 102, 'Arbil', 'AL', 1),
(1584, 102, 'At Ta''mim', 'TM', 1),
(1585, 102, 'As Sulaymaniyah', 'SL', 1),
(1586, 103, 'Carlow', 'CA', 1),
(1587, 103, 'Cavan', 'CV', 1),
(1588, 103, 'Clare', 'CL', 1),
(1589, 103, 'Cork', 'CO', 1),
(1590, 103, 'Donegal', 'DO', 1),
(1591, 103, 'Dublin', 'DU', 1),
(1592, 103, 'Galway', 'GA', 1),
(1593, 103, 'Kerry', 'KE', 1),
(1594, 103, 'Kildare', 'KI', 1),
(1595, 103, 'Kilkenny', 'KL', 1),
(1596, 103, 'Laois', 'LA', 1),
(1597, 103, 'Leitrim', 'LE', 1),
(1598, 103, 'Limerick', 'LI', 1),
(1599, 103, 'Longford', 'LO', 1),
(1600, 103, 'Louth', 'LU', 1),
(1601, 103, 'Mayo', 'MA', 1),
(1602, 103, 'Meath', 'ME', 1),
(1603, 103, 'Monaghan', 'MO', 1),
(1604, 103, 'Offaly', 'OF', 1),
(1605, 103, 'Roscommon', 'RO', 1),
(1606, 103, 'Sligo', 'SL', 1),
(1607, 103, 'Tipperary', 'TI', 1),
(1608, 103, 'Waterford', 'WA', 1),
(1609, 103, 'Westmeath', 'WE', 1),
(1610, 103, 'Wexford', 'WX', 1),
(1611, 103, 'Wicklow', 'WI', 1),
(1612, 104, 'Be''er Sheva', 'BS', 1),
(1613, 104, 'Bika''at Hayarden', 'BH', 1),
(1614, 104, 'Eilat and Arava', 'EA', 1),
(1615, 104, 'Galil', 'GA', 1),
(1616, 104, 'Haifa', 'HA', 1),
(1617, 104, 'Jehuda Mountains', 'JM', 1),
(1618, 104, 'Jerusalem', 'JE', 1),
(1619, 104, 'Negev', 'NE', 1),
(1620, 104, 'Semaria', 'SE', 1),
(1621, 104, 'Sharon', 'SH', 1),
(1622, 104, 'Tel Aviv (Gosh Dan)', 'TA', 1),
(3860, 105, 'Caltanissetta', 'CL', 1),
(3842, 105, 'Agrigento', 'AG', 1),
(3843, 105, 'Alessandria', 'AL', 1),
(3844, 105, 'Ancona', 'AN', 1),
(3845, 105, 'Aosta', 'AO', 1),
(3846, 105, 'Arezzo', 'AR', 1),
(3847, 105, 'Ascoli Piceno', 'AP', 1),
(3848, 105, 'Asti', 'AT', 1),
(3849, 105, 'Avellino', 'AV', 1),
(3850, 105, 'Bari', 'BA', 1),
(3851, 105, 'Belluno', 'BL', 1),
(3852, 105, 'Benevento', 'BN', 1),
(3853, 105, 'Bergamo', 'BG', 1),
(3854, 105, 'Biella', 'BI', 1),
(3855, 105, 'Bologna', 'BO', 1),
(3856, 105, 'Bolzano', 'BZ', 1),
(3857, 105, 'Brescia', 'BS', 1),
(3858, 105, 'Brindisi', 'BR', 1),
(3859, 105, 'Cagliari', 'CA', 1),
(1643, 106, 'Clarendon Parish', 'CLA', 1),
(1644, 106, 'Hanover Parish', 'HAN', 1),
(1645, 106, 'Kingston Parish', 'KIN', 1),
(1646, 106, 'Manchester Parish', 'MAN', 1),
(1647, 106, 'Portland Parish', 'POR', 1),
(1648, 106, 'Saint Andrew Parish', 'AND', 1),
(1649, 106, 'Saint Ann Parish', 'ANN', 1),
(1650, 106, 'Saint Catherine Parish', 'CAT', 1),
(1651, 106, 'Saint Elizabeth Parish', 'ELI', 1),
(1652, 106, 'Saint James Parish', 'JAM', 1),
(1653, 106, 'Saint Mary Parish', 'MAR', 1),
(1654, 106, 'Saint Thomas Parish', 'THO', 1),
(1655, 106, 'Trelawny Parish', 'TRL', 1),
(1656, 106, 'Westmoreland Parish', 'WML', 1),
(1657, 107, 'Aichi', 'AI', 1),
(1658, 107, 'Akita', 'AK', 1),
(1659, 107, 'Aomori', 'AO', 1),
(1660, 107, 'Chiba', 'CH', 1),
(1661, 107, 'Ehime', 'EH', 1),
(1662, 107, 'Fukui', 'FK', 1),
(1663, 107, 'Fukuoka', 'FU', 1),
(1664, 107, 'Fukushima', 'FS', 1),
(1665, 107, 'Gifu', 'GI', 1),
(1666, 107, 'Gumma', 'GU', 1),
(1667, 107, 'Hiroshima', 'HI', 1),
(1668, 107, 'Hokkaido', 'HO', 1),
(1669, 107, 'Hyogo', 'HY', 1),
(1670, 107, 'Ibaraki', 'IB', 1),
(1671, 107, 'Ishikawa', 'IS', 1),
(1672, 107, 'Iwate', 'IW', 1),
(1673, 107, 'Kagawa', 'KA', 1),
(1674, 107, 'Kagoshima', 'KG', 1),
(1675, 107, 'Kanagawa', 'KN', 1),
(1676, 107, 'Kochi', 'KO', 1),
(1677, 107, 'Kumamoto', 'KU', 1),
(1678, 107, 'Kyoto', 'KY', 1),
(1679, 107, 'Mie', 'MI', 1),
(1680, 107, 'Miyagi', 'MY', 1),
(1681, 107, 'Miyazaki', 'MZ', 1),
(1682, 107, 'Nagano', 'NA', 1),
(1683, 107, 'Nagasaki', 'NG', 1),
(1684, 107, 'Nara', 'NR', 1),
(1685, 107, 'Niigata', 'NI', 1),
(1686, 107, 'Oita', 'OI', 1),
(1687, 107, 'Okayama', 'OK', 1),
(1688, 107, 'Okinawa', 'ON', 1),
(1689, 107, 'Osaka', 'OS', 1),
(1690, 107, 'Saga', 'SA', 1),
(1691, 107, 'Saitama', 'SI', 1),
(1692, 107, 'Shiga', 'SH', 1),
(1693, 107, 'Shimane', 'SM', 1),
(1694, 107, 'Shizuoka', 'SZ', 1),
(1695, 107, 'Tochigi', 'TO', 1),
(1696, 107, 'Tokushima', 'TS', 1),
(1697, 107, 'Tokyo', 'TK', 1),
(1698, 107, 'Tottori', 'TT', 1),
(1699, 107, 'Toyama', 'TY', 1),
(1700, 107, 'Wakayama', 'WA', 1),
(1701, 107, 'Yamagata', 'YA', 1),
(1702, 107, 'Yamaguchi', 'YM', 1),
(1703, 107, 'Yamanashi', 'YN', 1),
(1704, 108, '''Amman', 'AM', 1),
(1705, 108, 'Ajlun', 'AJ', 1),
(1706, 108, 'Al ''Aqabah', 'AA', 1),
(1707, 108, 'Al Balqa''', 'AB', 1),
(1708, 108, 'Al Karak', 'AK', 1),
(1709, 108, 'Al Mafraq', 'AL', 1),
(1710, 108, 'At Tafilah', 'AT', 1),
(1711, 108, 'Az Zarqa''', 'AZ', 1),
(1712, 108, 'Irbid', 'IR', 1),
(1713, 108, 'Jarash', 'JA', 1),
(1714, 108, 'Ma''an', 'MA', 1),
(1715, 108, 'Madaba', 'MD', 1),
(1716, 109, 'Алматинская область', 'AL', 1),
(1717, 109, 'Алматы - город республ-го значения', 'AC', 1),
(1718, 109, 'Акмолинская область', 'AM', 1),
(1719, 109, 'Актюбинская область', 'AQ', 1),
(1720, 109, 'Астана - город республ-го значения', 'AS', 1),
(1721, 109, 'Атырауская область', 'AT', 1),
(1722, 109, 'Западно-Казахстанская область', 'BA', 1),
(1723, 109, 'Байконур - город республ-го значения', 'BY', 1),
(1724, 109, 'Мангистауская область', 'MA', 1),
(1725, 109, 'Южно-Казахстанская область', 'ON', 1),
(1726, 109, 'Павлодарская область', 'PA', 1),
(1727, 109, 'Карагандинская область', 'QA', 1),
(1728, 109, 'Костанайская область', 'QO', 1),
(1729, 109, 'Кызылординская область', 'QY', 1),
(1730, 109, 'Восточно-Казахстанская область', 'SH', 1),
(1731, 109, 'Северо-Казахстанская область', 'SO', 1),
(1732, 109, 'Жамбылская область', 'ZH', 1),
(1733, 110, 'Central', 'CE', 1),
(1734, 110, 'Coast', 'CO', 1),
(1735, 110, 'Eastern', 'EA', 1),
(1736, 110, 'Nairobi Area', 'NA', 1),
(1737, 110, 'North Eastern', 'NE', 1),
(1738, 110, 'Nyanza', 'NY', 1),
(1739, 110, 'Rift Valley', 'RV', 1),
(1740, 110, 'Western', 'WE', 1),
(1741, 111, 'Abaiang', 'AG', 1),
(1742, 111, 'Abemama', 'AM', 1),
(1743, 111, 'Aranuka', 'AK', 1),
(1744, 111, 'Arorae', 'AO', 1),
(1745, 111, 'Banaba', 'BA', 1),
(1746, 111, 'Beru', 'BE', 1),
(1747, 111, 'Butaritari', 'bT', 1),
(1748, 111, 'Kanton', 'KA', 1),
(1749, 111, 'Kiritimati', 'KR', 1),
(1750, 111, 'Kuria', 'KU', 1),
(1751, 111, 'Maiana', 'MI', 1),
(1752, 111, 'Makin', 'MN', 1),
(1753, 111, 'Marakei', 'ME', 1),
(1754, 111, 'Nikunau', 'NI', 1),
(1755, 111, 'Nonouti', 'NO', 1),
(1756, 111, 'Onotoa', 'ON', 1),
(1757, 111, 'Tabiteuea', 'TT', 1),
(1758, 111, 'Tabuaeran', 'TR', 1),
(1759, 111, 'Tamana', 'TM', 1),
(1760, 111, 'Tarawa', 'TW', 1),
(1761, 111, 'Teraina', 'TE', 1),
(1762, 112, 'Chagang-do', 'CHA', 1),
(1763, 112, 'Hamgyong-bukto', 'HAB', 1),
(1764, 112, 'Hamgyong-namdo', 'HAN', 1),
(1765, 112, 'Hwanghae-bukto', 'HWB', 1),
(1766, 112, 'Hwanghae-namdo', 'HWN', 1),
(1767, 112, 'Kangwon-do', 'KAN', 1),
(1768, 112, 'P''yongan-bukto', 'PYB', 1),
(1769, 112, 'P''yongan-namdo', 'PYN', 1),
(1770, 112, 'Ryanggang-do (Yanggang-do)', 'YAN', 1),
(1771, 112, 'Rason Directly Governed City', 'NAJ', 1),
(1772, 112, 'P''yongyang Special City', 'PYO', 1),
(1773, 113, 'Ch''ungch''ong-bukto', 'CO', 1),
(1774, 113, 'Ch''ungch''ong-namdo', 'CH', 1),
(1775, 113, 'Cheju-do', 'CD', 1),
(1776, 113, 'Cholla-bukto', 'CB', 1),
(1777, 113, 'Cholla-namdo', 'CN', 1),
(1778, 113, 'Inch''on-gwangyoksi', 'IG', 1),
(1779, 113, 'Kangwon-do', 'KA', 1),
(1780, 113, 'Kwangju-gwangyoksi', 'KG', 1),
(1781, 113, 'Kyonggi-do', 'KD', 1),
(1782, 113, 'Kyongsang-bukto', 'KB', 1),
(1783, 113, 'Kyongsang-namdo', 'KN', 1),
(1784, 113, 'Pusan-gwangyoksi', 'PG', 1),
(1785, 113, 'Soul-t''ukpyolsi', 'SO', 1),
(1786, 113, 'Taegu-gwangyoksi', 'TA', 1),
(1787, 113, 'Taejon-gwangyoksi', 'TG', 1),
(1788, 114, 'Al ''Asimah', 'AL', 1),
(1789, 114, 'Al Ahmadi', 'AA', 1),
(1790, 114, 'Al Farwaniyah', 'AF', 1),
(1791, 114, 'Al Jahra''', 'AJ', 1),
(1792, 114, 'Hawalli', 'HA', 1),
(1793, 115, 'Bishkek', 'GB', 1),
(1794, 115, 'Batken', 'B', 1),
(1795, 115, 'Chu', 'C', 1),
(1796, 115, 'Jalal-Abad', 'J', 1),
(1797, 115, 'Naryn', 'N', 1),
(1798, 115, 'Osh', 'O', 1),
(1799, 115, 'Talas', 'T', 1),
(1800, 115, 'Ysyk-Kol', 'Y', 1),
(1801, 116, 'Vientiane', 'VT', 1),
(1802, 116, 'Attapu', 'AT', 1),
(1803, 116, 'Bokeo', 'BK', 1),
(1804, 116, 'Bolikhamxai', 'BL', 1),
(1805, 116, 'Champasak', 'CH', 1),
(1806, 116, 'Houaphan', 'HO', 1),
(1807, 116, 'Khammouan', 'KH', 1),
(1808, 116, 'Louang Namtha', 'LM', 1),
(1809, 116, 'Louangphabang', 'LP', 1),
(1810, 116, 'Oudomxai', 'OU', 1),
(1811, 116, 'Phongsali', 'PH', 1),
(1812, 116, 'Salavan', 'SL', 1),
(1813, 116, 'Savannakhet', 'SV', 1),
(1814, 116, 'Vientiane', 'VI', 1),
(1815, 116, 'Xaignabouli', 'XA', 1),
(1816, 116, 'Xekong', 'XE', 1),
(1817, 116, 'Xiangkhoang', 'XI', 1),
(1818, 116, 'Xaisomboun', 'XN', 1),
(1819, 117, 'Aizkraukles Rajons', 'AIZ', 1),
(1820, 117, 'Aluksnes Rajons', 'ALU', 1),
(1821, 117, 'Balvu Rajons', 'BAL', 1),
(1822, 117, 'Bauskas Rajons', 'BAU', 1),
(1823, 117, 'Cesu Rajons', 'CES', 1),
(1824, 117, 'Daugavpils Rajons', 'DGR', 1),
(1825, 117, 'Dobeles Rajons', 'DOB', 1),
(1826, 117, 'Gulbenes Rajons', 'GUL', 1),
(1827, 117, 'Jekabpils Rajons', 'JEK', 1),
(1828, 117, 'Jelgavas Rajons', 'JGR', 1),
(1829, 117, 'Kraslavas Rajons', 'KRA', 1),
(1830, 117, 'Kuldigas Rajons', 'KUL', 1),
(1831, 117, 'Liepajas Rajons', 'LPR', 1),
(1832, 117, 'Limbazu Rajons', 'LIM', 1),
(1833, 117, 'Ludzas Rajons', 'LUD', 1),
(1834, 117, 'Madonas Rajons', 'MAD', 1),
(1835, 117, 'Ogres Rajons', 'OGR', 1),
(1836, 117, 'Preilu Rajons', 'PRE', 1),
(1837, 117, 'Rezeknes Rajons', 'RZR', 1),
(1838, 117, 'Rigas Rajons', 'RGR', 1),
(1839, 117, 'Saldus Rajons', 'SAL', 1),
(1840, 117, 'Talsu Rajons', 'TAL', 1),
(1841, 117, 'Tukuma Rajons', 'TUK', 1),
(1842, 117, 'Valkas Rajons', 'VLK', 1),
(1843, 117, 'Valmieras Rajons', 'VLM', 1),
(1844, 117, 'Ventspils Rajons', 'VSR', 1),
(1845, 117, 'Daugavpils', 'DGV', 1),
(1846, 117, 'Jelgava', 'JGV', 1),
(1847, 117, 'Jurmala', 'JUR', 1),
(1848, 117, 'Liepaja', 'LPK', 1),
(1849, 117, 'Rezekne', 'RZK', 1),
(1850, 117, 'Riga', 'RGA', 1),
(1851, 117, 'Ventspils', 'VSL', 1),
(1852, 119, 'Berea', 'BE', 1),
(1853, 119, 'Butha-Buthe', 'BB', 1),
(1854, 119, 'Leribe', 'LE', 1),
(1855, 119, 'Mafeteng', 'MF', 1),
(1856, 119, 'Maseru', 'MS', 1),
(1857, 119, 'Mohale''s Hoek', 'MH', 1),
(1858, 119, 'Mokhotlong', 'MK', 1),
(1859, 119, 'Qacha''s Nek', 'QN', 1),
(1860, 119, 'Quthing', 'QT', 1),
(1861, 119, 'Thaba-Tseka', 'TT', 1),
(1862, 120, 'Bomi', 'BI', 1),
(1863, 120, 'Bong', 'BG', 1),
(1864, 120, 'Grand Bassa', 'GB', 1),
(1865, 120, 'Grand Cape Mount', 'CM', 1),
(1866, 120, 'Grand Gedeh', 'GG', 1),
(1867, 120, 'Grand Kru', 'GK', 1),
(1868, 120, 'Lofa', 'LO', 1),
(1869, 120, 'Margibi', 'MG', 1),
(1870, 120, 'Maryland', 'ML', 1),
(1871, 120, 'Montserrado', 'MS', 1),
(1872, 120, 'Nimba', 'NB', 1),
(1873, 120, 'River Cess', 'RC', 1),
(1874, 120, 'Sinoe', 'SN', 1),
(1875, 121, 'Ajdabiya', 'AJ', 1),
(1876, 121, 'Al ''Aziziyah', 'AZ', 1),
(1877, 121, 'Al Fatih', 'FA', 1),
(1878, 121, 'Al Jabal al Akhdar', 'JA', 1),
(1879, 121, 'Al Jufrah', 'JU', 1),
(1880, 121, 'Al Khums', 'KH', 1),
(1881, 121, 'Al Kufrah', 'KU', 1),
(1882, 121, 'An Nuqat al Khams', 'NK', 1),
(1883, 121, 'Ash Shati''', 'AS', 1),
(1884, 121, 'Awbari', 'AW', 1),
(1885, 121, 'Az Zawiyah', 'ZA', 1),
(1886, 121, 'Banghazi', 'BA', 1),
(1887, 121, 'Darnah', 'DA', 1),
(1888, 121, 'Ghadamis', 'GD', 1),
(1889, 121, 'Gharyan', 'GY', 1),
(1890, 121, 'Misratah', 'MI', 1),
(1891, 121, 'Murzuq', 'MZ', 1),
(1892, 121, 'Sabha', 'SB', 1),
(1893, 121, 'Sawfajjin', 'SW', 1),
(1894, 121, 'Surt', 'SU', 1),
(1895, 121, 'Tarabulus (Tripoli)', 'TL', 1),
(1896, 121, 'Tarhunah', 'TH', 1),
(1897, 121, 'Tubruq', 'TU', 1),
(1898, 121, 'Yafran', 'YA', 1),
(1899, 121, 'Zlitan', 'ZL', 1),
(1900, 122, 'Vaduz', 'V', 1),
(1901, 122, 'Schaan', 'A', 1),
(1902, 122, 'Balzers', 'B', 1),
(1903, 122, 'Triesen', 'N', 1),
(1904, 122, 'Eschen', 'E', 1),
(1905, 122, 'Mauren', 'M', 1),
(1906, 122, 'Triesenberg', 'T', 1),
(1907, 122, 'Ruggell', 'R', 1),
(1908, 122, 'Gamprin', 'G', 1),
(1909, 122, 'Schellenberg', 'L', 1),
(1910, 122, 'Planken', 'P', 1),
(1911, 123, 'Alytus', 'AL', 1),
(1912, 123, 'Kaunas', 'KA', 1),
(1913, 123, 'Klaipeda', 'KL', 1),
(1914, 123, 'Marijampole', 'MA', 1),
(1915, 123, 'Panevezys', 'PA', 1),
(1916, 123, 'Siauliai', 'SI', 1),
(1917, 123, 'Taurage', 'TA', 1),
(1918, 123, 'Telsiai', 'TE', 1),
(1919, 123, 'Utena', 'UT', 1),
(1920, 123, 'Vilnius', 'VI', 1),
(1921, 124, 'Diekirch', 'DD', 1),
(1922, 124, 'Clervaux', 'DC', 1),
(1923, 124, 'Redange', 'DR', 1),
(1924, 124, 'Vianden', 'DV', 1),
(1925, 124, 'Wiltz', 'DW', 1),
(1926, 124, 'Grevenmacher', 'GG', 1),
(1927, 124, 'Echternach', 'GE', 1),
(1928, 124, 'Remich', 'GR', 1),
(1929, 124, 'Luxembourg', 'LL', 1),
(1930, 124, 'Capellen', 'LC', 1),
(1931, 124, 'Esch-sur-Alzette', 'LE', 1),
(1932, 124, 'Mersch', 'LM', 1),
(1933, 125, 'Our Lady Fatima Parish', 'OLF', 1),
(1934, 125, 'St. Anthony Parish', 'ANT', 1),
(1935, 125, 'St. Lazarus Parish', 'LAZ', 1),
(1936, 125, 'Cathedral Parish', 'CAT', 1),
(1937, 125, 'St. Lawrence Parish', 'LAW', 1),
(1938, 127, 'Antananarivo', 'AN', 1),
(1939, 127, 'Antsiranana', 'AS', 1),
(1940, 127, 'Fianarantsoa', 'FN', 1),
(1941, 127, 'Mahajanga', 'MJ', 1),
(1942, 127, 'Toamasina', 'TM', 1),
(1943, 127, 'Toliara', 'TL', 1),
(1944, 128, 'Balaka', 'BLK', 1),
(1945, 128, 'Blantyre', 'BLT', 1),
(1946, 128, 'Chikwawa', 'CKW', 1),
(1947, 128, 'Chiradzulu', 'CRD', 1),
(1948, 128, 'Chitipa', 'CTP', 1),
(1949, 128, 'Dedza', 'DDZ', 1),
(1950, 128, 'Dowa', 'DWA', 1),
(1951, 128, 'Karonga', 'KRG', 1),
(1952, 128, 'Kasungu', 'KSG', 1),
(1953, 128, 'Likoma', 'LKM', 1),
(1954, 128, 'Lilongwe', 'LLG', 1),
(1955, 128, 'Machinga', 'MCG', 1),
(1956, 128, 'Mangochi', 'MGC', 1),
(1957, 128, 'Mchinji', 'MCH', 1),
(1958, 128, 'Mulanje', 'MLJ', 1),
(1959, 128, 'Mwanza', 'MWZ', 1),
(1960, 128, 'Mzimba', 'MZM', 1),
(1961, 128, 'Ntcheu', 'NTU', 1),
(1962, 128, 'Nkhata Bay', 'NKB', 1),
(1963, 128, 'Nkhotakota', 'NKH', 1),
(1964, 128, 'Nsanje', 'NSJ', 1),
(1965, 128, 'Ntchisi', 'NTI', 1),
(1966, 128, 'Phalombe', 'PHL', 1),
(1967, 128, 'Rumphi', 'RMP', 1),
(1968, 128, 'Salima', 'SLM', 1),
(1969, 128, 'Thyolo', 'THY', 1),
(1970, 128, 'Zomba', 'ZBA', 1),
(1971, 129, 'Johor', 'JO', 1),
(1972, 129, 'Kedah', 'KE', 1),
(1973, 129, 'Kelantan', 'KL', 1),
(1974, 129, 'Labuan', 'LA', 1),
(1975, 129, 'Melaka', 'ME', 1),
(1976, 129, 'Negeri Sembilan', 'NS', 1),
(1977, 129, 'Pahang', 'PA', 1),
(1978, 129, 'Perak', 'PE', 1),
(1979, 129, 'Perlis', 'PR', 1),
(1980, 129, 'Pulau Pinang', 'PP', 1),
(1981, 129, 'Sabah', 'SA', 1),
(1982, 129, 'Sarawak', 'SR', 1),
(1983, 129, 'Selangor', 'SE', 1),
(1984, 129, 'Terengganu', 'TE', 1),
(1985, 129, 'Wilayah Persekutuan', 'WP', 1),
(1986, 130, 'Thiladhunmathi Uthuru', 'THU', 1),
(1987, 130, 'Thiladhunmathi Dhekunu', 'THD', 1),
(1988, 130, 'Miladhunmadulu Uthuru', 'MLU', 1),
(1989, 130, 'Miladhunmadulu Dhekunu', 'MLD', 1),
(1990, 130, 'Maalhosmadulu Uthuru', 'MAU', 1),
(1991, 130, 'Maalhosmadulu Dhekunu', 'MAD', 1),
(1992, 130, 'Faadhippolhu', 'FAA', 1),
(1993, 130, 'Male Atoll', 'MAA', 1),
(1994, 130, 'Ari Atoll Uthuru', 'AAU', 1),
(1995, 130, 'Ari Atoll Dheknu', 'AAD', 1),
(1996, 130, 'Felidhe Atoll', 'FEA', 1),
(1997, 130, 'Mulaku Atoll', 'MUA', 1),
(1998, 130, 'Nilandhe Atoll Uthuru', 'NAU', 1),
(1999, 130, 'Nilandhe Atoll Dhekunu', 'NAD', 1),
(2000, 130, 'Kolhumadulu', 'KLH', 1),
(2001, 130, 'Hadhdhunmathi', 'HDH', 1),
(2002, 130, 'Huvadhu Atoll Uthuru', 'HAU', 1),
(2003, 130, 'Huvadhu Atoll Dhekunu', 'HAD', 1),
(2004, 130, 'Fua Mulaku', 'FMU', 1),
(2005, 130, 'Addu', 'ADD', 1),
(2006, 131, 'Gao', 'GA', 1),
(2007, 131, 'Kayes', 'KY', 1),
(2008, 131, 'Kidal', 'KD', 1),
(2009, 131, 'Koulikoro', 'KL', 1),
(2010, 131, 'Mopti', 'MP', 1),
(2011, 131, 'Segou', 'SG', 1),
(2012, 131, 'Sikasso', 'SK', 1),
(2013, 131, 'Tombouctou', 'TB', 1),
(2014, 131, 'Bamako Capital District', 'CD', 1),
(2015, 132, 'Attard', 'ATT', 1),
(2016, 132, 'Balzan', 'BAL', 1),
(2017, 132, 'Birgu', 'BGU', 1),
(2018, 132, 'Birkirkara', 'BKK', 1),
(2019, 132, 'Birzebbuga', 'BRZ', 1),
(2020, 132, 'Bormla', 'BOR', 1),
(2021, 132, 'Dingli', 'DIN', 1),
(2022, 132, 'Fgura', 'FGU', 1),
(2023, 132, 'Floriana', 'FLO', 1),
(2024, 132, 'Gudja', 'GDJ', 1),
(2025, 132, 'Gzira', 'GZR', 1),
(2026, 132, 'Gargur', 'GRG', 1),
(2027, 132, 'Gaxaq', 'GXQ', 1),
(2028, 132, 'Hamrun', 'HMR', 1),
(2029, 132, 'Iklin', 'IKL', 1),
(2030, 132, 'Isla', 'ISL', 1),
(2031, 132, 'Kalkara', 'KLK', 1),
(2032, 132, 'Kirkop', 'KRK', 1),
(2033, 132, 'Lija', 'LIJ', 1),
(2034, 132, 'Luqa', 'LUQ', 1),
(2035, 132, 'Marsa', 'MRS', 1),
(2036, 132, 'Marsaskala', 'MKL', 1),
(2037, 132, 'Marsaxlokk', 'MXL', 1),
(2038, 132, 'Mdina', 'MDN', 1),
(2039, 132, 'Melliea', 'MEL', 1),
(2040, 132, 'Mgarr', 'MGR', 1),
(2041, 132, 'Mosta', 'MST', 1),
(2042, 132, 'Mqabba', 'MQA', 1),
(2043, 132, 'Msida', 'MSI', 1),
(2044, 132, 'Mtarfa', 'MTF', 1),
(2045, 132, 'Naxxar', 'NAX', 1),
(2046, 132, 'Paola', 'PAO', 1),
(2047, 132, 'Pembroke', 'PEM', 1),
(2048, 132, 'Pieta', 'PIE', 1),
(2049, 132, 'Qormi', 'QOR', 1),
(2050, 132, 'Qrendi', 'QRE', 1),
(2051, 132, 'Rabat', 'RAB', 1),
(2052, 132, 'Safi', 'SAF', 1),
(2053, 132, 'San Giljan', 'SGI', 1),
(2054, 132, 'Santa Lucija', 'SLU', 1),
(2055, 132, 'San Pawl il-Bahar', 'SPB', 1),
(2056, 132, 'San Gwann', 'SGW', 1),
(2057, 132, 'Santa Venera', 'SVE', 1),
(2058, 132, 'Siggiewi', 'SIG', 1),
(2059, 132, 'Sliema', 'SLM', 1),
(2060, 132, 'Swieqi', 'SWQ', 1),
(2061, 132, 'Ta Xbiex', 'TXB', 1),
(2062, 132, 'Tarxien', 'TRX', 1),
(2063, 132, 'Valletta', 'VLT', 1),
(2064, 132, 'Xgajra', 'XGJ', 1),
(2065, 132, 'Zabbar', 'ZBR', 1),
(2066, 132, 'Zebbug', 'ZBG', 1),
(2067, 132, 'Zejtun', 'ZJT', 1),
(2068, 132, 'Zurrieq', 'ZRQ', 1),
(2069, 132, 'Fontana', 'FNT', 1),
(2070, 132, 'Ghajnsielem', 'GHJ', 1),
(2071, 132, 'Gharb', 'GHR', 1),
(2072, 132, 'Ghasri', 'GHS', 1),
(2073, 132, 'Kercem', 'KRC', 1),
(2074, 132, 'Munxar', 'MUN', 1),
(2075, 132, 'Nadur', 'NAD', 1),
(2076, 132, 'Qala', 'QAL', 1),
(2077, 132, 'Victoria', 'VIC', 1),
(2078, 132, 'San Lawrenz', 'SLA', 1),
(2079, 132, 'Sannat', 'SNT', 1),
(2080, 132, 'Xagra', 'ZAG', 1),
(2081, 132, 'Xewkija', 'XEW', 1),
(2082, 132, 'Zebbug', 'ZEB', 1),
(2083, 133, 'Ailinginae', 'ALG', 1),
(2084, 133, 'Ailinglaplap', 'ALL', 1),
(2085, 133, 'Ailuk', 'ALK', 1),
(2086, 133, 'Arno', 'ARN', 1),
(2087, 133, 'Aur', 'AUR', 1),
(2088, 133, 'Bikar', 'BKR', 1),
(2089, 133, 'Bikini', 'BKN', 1),
(2090, 133, 'Bokak', 'BKK', 1),
(2091, 133, 'Ebon', 'EBN', 1),
(2092, 133, 'Enewetak', 'ENT', 1),
(2093, 133, 'Erikub', 'EKB', 1),
(2094, 133, 'Jabat', 'JBT', 1),
(2095, 133, 'Jaluit', 'JLT', 1),
(2096, 133, 'Jemo', 'JEM', 1),
(2097, 133, 'Kili', 'KIL', 1),
(2098, 133, 'Kwajalein', 'KWJ', 1),
(2099, 133, 'Lae', 'LAE', 1),
(2100, 133, 'Lib', 'LIB', 1),
(2101, 133, 'Likiep', 'LKP', 1),
(2102, 133, 'Majuro', 'MJR', 1),
(2103, 133, 'Maloelap', 'MLP', 1),
(2104, 133, 'Mejit', 'MJT', 1),
(2105, 133, 'Mili', 'MIL', 1),
(2106, 133, 'Namorik', 'NMK', 1),
(2107, 133, 'Namu', 'NAM', 1),
(2108, 133, 'Rongelap', 'RGL', 1),
(2109, 133, 'Rongrik', 'RGK', 1),
(2110, 133, 'Toke', 'TOK', 1),
(2111, 133, 'Ujae', 'UJA', 1),
(2112, 133, 'Ujelang', 'UJL', 1),
(2113, 133, 'Utirik', 'UTK', 1),
(2114, 133, 'Wotho', 'WTH', 1),
(2115, 133, 'Wotje', 'WTJ', 1),
(2116, 135, 'Adrar', 'AD', 1),
(2117, 135, 'Assaba', 'AS', 1),
(2118, 135, 'Brakna', 'BR', 1),
(2119, 135, 'Dakhlet Nouadhibou', 'DN', 1),
(2120, 135, 'Gorgol', 'GO', 1),
(2121, 135, 'Guidimaka', 'GM', 1),
(2122, 135, 'Hodh Ech Chargui', 'HC', 1),
(2123, 135, 'Hodh El Gharbi', 'HG', 1),
(2124, 135, 'Inchiri', 'IN', 1),
(2125, 135, 'Tagant', 'TA', 1),
(2126, 135, 'Tiris Zemmour', 'TZ', 1),
(2127, 135, 'Trarza', 'TR', 1),
(2128, 135, 'Nouakchott', 'NO', 1),
(2129, 136, 'Beau Bassin-Rose Hill', 'BR', 1),
(2130, 136, 'Curepipe', 'CU', 1),
(2131, 136, 'Port Louis', 'PU', 1),
(2132, 136, 'Quatre Bornes', 'QB', 1),
(2133, 136, 'Vacoas-Phoenix', 'VP', 1),
(2134, 136, 'Agalega Islands', 'AG', 1),
(2135, 136, 'Cargados Carajos Shoals (Saint Brandon Islands)', 'CC', 1),
(2136, 136, 'Rodrigues', 'RO', 1),
(2137, 136, 'Black River', 'BL', 1),
(2138, 136, 'Flacq', 'FL', 1),
(2139, 136, 'Grand Port', 'GP', 1),
(2140, 136, 'Moka', 'MO', 1),
(2141, 136, 'Pamplemousses', 'PA', 1),
(2142, 136, 'Plaines Wilhems', 'PW', 1),
(2143, 136, 'Port Louis', 'PL', 1),
(2144, 136, 'Riviere du Rempart', 'RR', 1),
(2145, 136, 'Savanne', 'SA', 1),
(2146, 138, 'Baja California Norte', 'BN', 1),
(2147, 138, 'Baja California Sur', 'BS', 1),
(2148, 138, 'Campeche', 'CA', 1),
(2149, 138, 'Chiapas', 'CI', 1),
(2150, 138, 'Chihuahua', 'CH', 1),
(2151, 138, 'Coahuila de Zaragoza', 'CZ', 1),
(2152, 138, 'Colima', 'CL', 1),
(2153, 138, 'Distrito Federal', 'DF', 1),
(2154, 138, 'Durango', 'DU', 1),
(2155, 138, 'Guanajuato', 'GA', 1),
(2156, 138, 'Guerrero', 'GE', 1),
(2157, 138, 'Hidalgo', 'HI', 1),
(2158, 138, 'Jalisco', 'JA', 1),
(2159, 138, 'Mexico', 'ME', 1),
(2160, 138, 'Michoacan de Ocampo', 'MI', 1),
(2161, 138, 'Morelos', 'MO', 1),
(2162, 138, 'Nayarit', 'NA', 1),
(2163, 138, 'Nuevo Leon', 'NL', 1),
(2164, 138, 'Oaxaca', 'OA', 1),
(2165, 138, 'Puebla', 'PU', 1),
(2166, 138, 'Queretaro de Arteaga', 'QA', 1),
(2167, 138, 'Quintana Roo', 'QR', 1),
(2168, 138, 'San Luis Potosi', 'SA', 1),
(2169, 138, 'Sinaloa', 'SI', 1),
(2170, 138, 'Sonora', 'SO', 1),
(2171, 138, 'Tabasco', 'TB', 1),
(2172, 138, 'Tamaulipas', 'TM', 1),
(2173, 138, 'Tlaxcala', 'TL', 1),
(2174, 138, 'Veracruz-Llave', 'VE', 1),
(2175, 138, 'Yucatan', 'YU', 1),
(2176, 138, 'Zacatecas', 'ZA', 1),
(2177, 139, 'Chuuk', 'C', 1),
(2178, 139, 'Kosrae', 'K', 1),
(2179, 139, 'Pohnpei', 'P', 1),
(2180, 139, 'Yap', 'Y', 1),
(2181, 140, 'Gagauzia', 'GA', 1),
(2182, 140, 'Chisinau', 'CU', 1),
(2183, 140, 'Balti', 'BA', 1),
(2184, 140, 'Cahul', 'CA', 1),
(2185, 140, 'Edinet', 'ED', 1),
(2186, 140, 'Lapusna', 'LA', 1),
(2187, 140, 'Orhei', 'OR', 1),
(2188, 140, 'Soroca', 'SO', 1),
(2189, 140, 'Tighina', 'TI', 1),
(2190, 140, 'Ungheni', 'UN', 1),
(2191, 140, 'St‚nga Nistrului', 'SN', 1),
(2192, 141, 'Fontvieille', 'FV', 1),
(2193, 141, 'La Condamine', 'LC', 1),
(2194, 141, 'Monaco-Ville', 'MV', 1),
(2195, 141, 'Monte-Carlo', 'MC', 1),
(2196, 142, 'Ulanbaatar', '1', 1),
(2197, 142, 'Orhon', '035', 1),
(2198, 142, 'Darhan uul', '037', 1),
(2199, 142, 'Hentiy', '039', 1),
(2200, 142, 'Hovsgol', '041', 1),
(2201, 142, 'Hovd', '043', 1),
(2202, 142, 'Uvs', '046', 1),
(2203, 142, 'Tov', '047', 1),
(2204, 142, 'Selenge', '049', 1),
(2205, 142, 'Suhbaatar', '051', 1),
(2206, 142, 'Omnogovi', '053', 1),
(2207, 142, 'Ovorhangay', '055', 1),
(2208, 142, 'Dzavhan', '057', 1),
(2209, 142, 'DundgovL', '059', 1),
(2210, 142, 'Dornod', '061', 1),
(2211, 142, 'Dornogov', '063', 1),
(2212, 142, 'Govi-Sumber', '064', 1),
(2213, 142, 'Govi-Altay', '065', 1),
(2214, 142, 'Bulgan', '067', 1),
(2215, 142, 'Bayanhongor', '069', 1),
(2216, 142, 'Bayan-Olgiy', '071', 1),
(2217, 142, 'Arhangay', '073', 1),
(2218, 143, 'Saint Anthony', 'A', 1),
(2219, 143, 'Saint Georges', 'G', 1),
(2220, 143, 'Saint Peter', 'P', 1),
(2221, 144, 'Agadir', 'AGD', 1),
(2222, 144, 'Al Hoceima', 'HOC', 1),
(2223, 144, 'Azilal', 'AZI', 1),
(2224, 144, 'Beni Mellal', 'BME', 1),
(2225, 144, 'Ben Slimane', 'BSL', 1),
(2226, 144, 'Boulemane', 'BLM', 1),
(2227, 144, 'Casablanca', 'CBL', 1),
(2228, 144, 'Chaouen', 'CHA', 1),
(2229, 144, 'El Jadida', 'EJA', 1),
(2230, 144, 'El Kelaa des Sraghna', 'EKS', 1),
(2231, 144, 'Er Rachidia', 'ERA', 1),
(2232, 144, 'Essaouira', 'ESS', 1),
(2233, 144, 'Fes', 'FES', 1),
(2234, 144, 'Figuig', 'FIG', 1),
(2235, 144, 'Guelmim', 'GLM', 1),
(2236, 144, 'Ifrane', 'IFR', 1),
(2237, 144, 'Kenitra', 'KEN', 1),
(2238, 144, 'Khemisset', 'KHM', 1),
(2239, 144, 'Khenifra', 'KHN', 1),
(2240, 144, 'Khouribga', 'KHO', 1),
(2241, 144, 'Laayoune', 'LYN', 1),
(2242, 144, 'Larache', 'LAR', 1),
(2243, 144, 'Marrakech', 'MRK', 1),
(2244, 144, 'Meknes', 'MKN', 1),
(2245, 144, 'Nador', 'NAD', 1),
(2246, 144, 'Ouarzazate', 'ORZ', 1),
(2247, 144, 'Oujda', 'OUJ', 1),
(2248, 144, 'Rabat-Sale', 'RSA', 1),
(2249, 144, 'Safi', 'SAF', 1),
(2250, 144, 'Settat', 'SET', 1),
(2251, 144, 'Sidi Kacem', 'SKA', 1),
(2252, 144, 'Tangier', 'TGR', 1),
(2253, 144, 'Tan-Tan', 'TAN', 1),
(2254, 144, 'Taounate', 'TAO', 1),
(2255, 144, 'Taroudannt', 'TRD', 1),
(2256, 144, 'Tata', 'TAT', 1),
(2257, 144, 'Taza', 'TAZ', 1),
(2258, 144, 'Tetouan', 'TET', 1),
(2259, 144, 'Tiznit', 'TIZ', 1),
(2260, 144, 'Ad Dakhla', 'ADK', 1),
(2261, 144, 'Boujdour', 'BJD', 1),
(2262, 144, 'Es Smara', 'ESM', 1),
(2263, 145, 'Cabo Delgado', 'CD', 1),
(2264, 145, 'Gaza', 'GZ', 1),
(2265, 145, 'Inhambane', 'IN', 1),
(2266, 145, 'Manica', 'MN', 1),
(2267, 145, 'Maputo (city)', 'MC', 1),
(2268, 145, 'Maputo', 'MP', 1),
(2269, 145, 'Nampula', 'NA', 1),
(2270, 145, 'Niassa', 'NI', 1),
(2271, 145, 'Sofala', 'SO', 1),
(2272, 145, 'Tete', 'TE', 1),
(2273, 145, 'Zambezia', 'ZA', 1),
(2274, 146, 'Ayeyarwady', 'AY', 1),
(2275, 146, 'Bago', 'BG', 1),
(2276, 146, 'Magway', 'MG', 1),
(2277, 146, 'Mandalay', 'MD', 1),
(2278, 146, 'Sagaing', 'SG', 1),
(2279, 146, 'Tanintharyi', 'TN', 1),
(2280, 146, 'Yangon', 'YG', 1),
(2281, 146, 'Chin State', 'CH', 1),
(2282, 146, 'Kachin State', 'KC', 1),
(2283, 146, 'Kayah State', 'KH', 1),
(2284, 146, 'Kayin State', 'KN', 1),
(2285, 146, 'Mon State', 'MN', 1),
(2286, 146, 'Rakhine State', 'RK', 1),
(2287, 146, 'Shan State', 'SH', 1),
(2288, 147, 'Caprivi', 'CA', 1),
(2289, 147, 'Erongo', 'ER', 1),
(2290, 147, 'Hardap', 'HA', 1),
(2291, 147, 'Karas', 'KR', 1),
(2292, 147, 'Kavango', 'KV', 1),
(2293, 147, 'Khomas', 'KH', 1),
(2294, 147, 'Kunene', 'KU', 1),
(2295, 147, 'Ohangwena', 'OW', 1),
(2296, 147, 'Omaheke', 'OK', 1),
(2297, 147, 'Omusati', 'OT', 1),
(2298, 147, 'Oshana', 'ON', 1),
(2299, 147, 'Oshikoto', 'OO', 1),
(2300, 147, 'Otjozondjupa', 'OJ', 1),
(2301, 148, 'Aiwo', 'AO', 1),
(2302, 148, 'Anabar', 'AA', 1),
(2303, 148, 'Anetan', 'AT', 1),
(2304, 148, 'Anibare', 'AI', 1),
(2305, 148, 'Baiti', 'BA', 1),
(2306, 148, 'Boe', 'BO', 1),
(2307, 148, 'Buada', 'BU', 1),
(2308, 148, 'Denigomodu', 'DE', 1),
(2309, 148, 'Ewa', 'EW', 1),
(2310, 148, 'Ijuw', 'IJ', 1),
(2311, 148, 'Meneng', 'ME', 1),
(2312, 148, 'Nibok', 'NI', 1),
(2313, 148, 'Uaboe', 'UA', 1),
(2314, 148, 'Yaren', 'YA', 1),
(2315, 149, 'Bagmati', 'BA', 1),
(2316, 149, 'Bheri', 'BH', 1),
(2317, 149, 'Dhawalagiri', 'DH', 1),
(2318, 149, 'Gandaki', 'GA', 1),
(2319, 149, 'Janakpur', 'JA', 1),
(2320, 149, 'Karnali', 'KA', 1),
(2321, 149, 'Kosi', 'KO', 1),
(2322, 149, 'Lumbini', 'LU', 1),
(2323, 149, 'Mahakali', 'MA', 1),
(2324, 149, 'Mechi', 'ME', 1),
(2325, 149, 'Narayani', 'NA', 1),
(2326, 149, 'Rapti', 'RA', 1),
(2327, 149, 'Sagarmatha', 'SA', 1),
(2328, 149, 'Seti', 'SE', 1),
(2329, 150, 'Drenthe', 'DR', 1),
(2330, 150, 'Flevoland', 'FL', 1),
(2331, 150, 'Friesland', 'FR', 1),
(2332, 150, 'Gelderland', 'GE', 1),
(2333, 150, 'Groningen', 'GR', 1),
(2334, 150, 'Limburg', 'LI', 1),
(2335, 150, 'Noord Brabant', 'NB', 1),
(2336, 150, 'Noord Holland', 'NH', 1),
(2337, 150, 'Overijssel', 'OV', 1),
(2338, 150, 'Utrecht', 'UT', 1),
(2339, 150, 'Zeeland', 'ZE', 1),
(2340, 150, 'Zuid Holland', 'ZH', 1),
(2341, 152, 'Iles Loyaute', 'L', 1),
(2342, 152, 'Nord', 'N', 1),
(2343, 152, 'Sud', 'S', 1),
(2344, 153, 'Auckland', 'AUK', 1),
(2345, 153, 'Bay of Plenty', 'BOP', 1),
(2346, 153, 'Canterbury', 'CAN', 1),
(2347, 153, 'Coromandel', 'COR', 1),
(2348, 153, 'Gisborne', 'GIS', 1),
(2349, 153, 'Fiordland', 'FIO', 1),
(2350, 153, 'Hawke''s Bay', 'HKB', 1),
(2351, 153, 'Marlborough', 'MBH', 1),
(2352, 153, 'Manawatu-Wanganui', 'MWT', 1),
(2353, 153, 'Mt Cook-Mackenzie', 'MCM', 1),
(2354, 153, 'Nelson', 'NSN', 1),
(2355, 153, 'Northland', 'NTL', 1),
(2356, 153, 'Otago', 'OTA', 1),
(2357, 153, 'Southland', 'STL', 1),
(2358, 153, 'Taranaki', 'TKI', 1),
(2359, 153, 'Wellington', 'WGN', 1),
(2360, 153, 'Waikato', 'WKO', 1),
(2361, 153, 'Wairprarapa', 'WAI', 1),
(2362, 153, 'West Coast', 'WTC', 1),
(2363, 154, 'Atlantico Norte', 'AN', 1),
(2364, 154, 'Atlantico Sur', 'AS', 1),
(2365, 154, 'Boaco', 'BO', 1),
(2366, 154, 'Carazo', 'CA', 1),
(2367, 154, 'Chinandega', 'CI', 1),
(2368, 154, 'Chontales', 'CO', 1),
(2369, 154, 'Esteli', 'ES', 1),
(2370, 154, 'Granada', 'GR', 1),
(2371, 154, 'Jinotega', 'JI', 1),
(2372, 154, 'Leon', 'LE', 1),
(2373, 154, 'Madriz', 'MD', 1),
(2374, 154, 'Managua', 'MN', 1),
(2375, 154, 'Masaya', 'MS', 1),
(2376, 154, 'Matagalpa', 'MT', 1),
(2377, 154, 'Nuevo Segovia', 'NS', 1),
(2378, 154, 'Rio San Juan', 'RS', 1),
(2379, 154, 'Rivas', 'RI', 1),
(2380, 155, 'Agadez', 'AG', 1),
(2381, 155, 'Diffa', 'DF', 1),
(2382, 155, 'Dosso', 'DS', 1),
(2383, 155, 'Maradi', 'MA', 1),
(2384, 155, 'Niamey', 'NM', 1),
(2385, 155, 'Tahoua', 'TH', 1),
(2386, 155, 'Tillaberi', 'TL', 1),
(2387, 155, 'Zinder', 'ZD', 1),
(2388, 156, 'Abia', 'AB', 1),
(2389, 156, 'Abuja Federal Capital Territory', 'CT', 1),
(2390, 156, 'Adamawa', 'AD', 1),
(2391, 156, 'Akwa Ibom', 'AK', 1),
(2392, 156, 'Anambra', 'AN', 1),
(2393, 156, 'Bauchi', 'BC', 1),
(2394, 156, 'Bayelsa', 'BY', 1),
(2395, 156, 'Benue', 'BN', 1),
(2396, 156, 'Borno', 'BO', 1),
(2397, 156, 'Cross River', 'CR', 1),
(2398, 156, 'Delta', 'DE', 1),
(2399, 156, 'Ebonyi', 'EB', 1),
(2400, 156, 'Edo', 'ED', 1),
(2401, 156, 'Ekiti', 'EK', 1),
(2402, 156, 'Enugu', 'EN', 1),
(2403, 156, 'Gombe', 'GO', 1),
(2404, 156, 'Imo', 'IM', 1),
(2405, 156, 'Jigawa', 'JI', 1),
(2406, 156, 'Kaduna', 'KD', 1),
(2407, 156, 'Kano', 'KN', 1),
(2408, 156, 'Katsina', 'KT', 1),
(2409, 156, 'Kebbi', 'KE', 1),
(2410, 156, 'Kogi', 'KO', 1),
(2411, 156, 'Kwara', 'KW', 1),
(2412, 156, 'Lagos', 'LA', 1),
(2413, 156, 'Nassarawa', 'NA', 1),
(2414, 156, 'Niger', 'NI', 1),
(2415, 156, 'Ogun', 'OG', 1),
(2416, 156, 'Ondo', 'ONG', 1),
(2417, 156, 'Osun', 'OS', 1),
(2418, 156, 'Oyo', 'OY', 1),
(2419, 156, 'Plateau', 'PL', 1),
(2420, 156, 'Rivers', 'RI', 1),
(2421, 156, 'Sokoto', 'SO', 1),
(2422, 156, 'Taraba', 'TA', 1),
(2423, 156, 'Yobe', 'YO', 1),
(2424, 156, 'Zamfara', 'ZA', 1),
(2425, 159, 'Northern Islands', 'N', 1),
(2426, 159, 'Rota', 'R', 1),
(2427, 159, 'Saipan', 'S', 1),
(2428, 159, 'Tinian', 'T', 1),
(2429, 160, 'Akershus', 'AK', 1),
(2430, 160, 'Aust-Agder', 'AA', 1),
(2431, 160, 'Buskerud', 'BU', 1),
(2432, 160, 'Finnmark', 'FM', 1),
(2433, 160, 'Hedmark', 'HM', 1),
(2434, 160, 'Hordaland', 'HL', 1),
(2435, 160, 'More og Romdal', 'MR', 1),
(2436, 160, 'Nord-Trondelag', 'NT', 1),
(2437, 160, 'Nordland', 'NL', 1),
(2438, 160, 'Ostfold', 'OF', 1),
(2439, 160, 'Oppland', 'OP', 1),
(2440, 160, 'Oslo', 'OL', 1),
(2441, 160, 'Rogaland', 'RL', 1),
(2442, 160, 'Sor-Trondelag', 'ST', 1),
(2443, 160, 'Sogn og Fjordane', 'SJ', 1),
(2444, 160, 'Svalbard', 'SV', 1),
(2445, 160, 'Telemark', 'TM', 1),
(2446, 160, 'Troms', 'TR', 1),
(2447, 160, 'Vest-Agder', 'VA', 1),
(2448, 160, 'Vestfold', 'VF', 1),
(2449, 161, 'Ad Dakhiliyah', 'DA', 1),
(2450, 161, 'Al Batinah', 'BA', 1),
(2451, 161, 'Al Wusta', 'WU', 1),
(2452, 161, 'Ash Sharqiyah', 'SH', 1),
(2453, 161, 'Az Zahirah', 'ZA', 1),
(2454, 161, 'Masqat', 'MA', 1),
(2455, 161, 'Musandam', 'MU', 1),
(2456, 161, 'Zufar', 'ZU', 1),
(2457, 162, 'Balochistan', 'B', 1),
(2458, 162, 'Federally Administered Tribal Areas', 'T', 1),
(2459, 162, 'Islamabad Capital Territory', 'I', 1),
(2460, 162, 'North-West Frontier', 'N', 1),
(2461, 162, 'Punjab', 'P', 1),
(2462, 162, 'Sindh', 'S', 1),
(2463, 163, 'Aimeliik', 'AM', 1),
(2464, 163, 'Airai', 'AR', 1),
(2465, 163, 'Angaur', 'AN', 1),
(2466, 163, 'Hatohobei', 'HA', 1),
(2467, 163, 'Kayangel', 'KA', 1),
(2468, 163, 'Koror', 'KO', 1),
(2469, 163, 'Melekeok', 'ME', 1),
(2470, 163, 'Ngaraard', 'NA', 1),
(2471, 163, 'Ngarchelong', 'NG', 1),
(2472, 163, 'Ngardmau', 'ND', 1),
(2473, 163, 'Ngatpang', 'NT', 1),
(2474, 163, 'Ngchesar', 'NC', 1),
(2475, 163, 'Ngeremlengui', 'NR', 1),
(2476, 163, 'Ngiwal', 'NW', 1),
(2477, 163, 'Peleliu', 'PE', 1),
(2478, 163, 'Sonsorol', 'SO', 1),
(2479, 164, 'Bocas del Toro', 'BT', 1),
(2480, 164, 'Chiriqui', 'CH', 1),
(2481, 164, 'Cocle', 'CC', 1),
(2482, 164, 'Colon', 'CL', 1),
(2483, 164, 'Darien', 'DA', 1),
(2484, 164, 'Herrera', 'HE', 1),
(2485, 164, 'Los Santos', 'LS', 1),
(2486, 164, 'Panama', 'PA', 1),
(2487, 164, 'San Blas', 'SB', 1),
(2488, 164, 'Veraguas', 'VG', 1),
(2489, 165, 'Bougainville', 'BV', 1),
(2490, 165, 'Central', 'CE', 1),
(2491, 165, 'Chimbu', 'CH', 1),
(2492, 165, 'Eastern Highlands', 'EH', 1),
(2493, 165, 'East New Britain', 'EB', 1),
(2494, 165, 'East Sepik', 'ES', 1),
(2495, 165, 'Enga', 'EN', 1),
(2496, 165, 'Gulf', 'GU', 1),
(2497, 165, 'Madang', 'MD', 1),
(2498, 165, 'Manus', 'MN', 1),
(2499, 165, 'Milne Bay', 'MB', 1),
(2500, 165, 'Morobe', 'MR', 1),
(2501, 165, 'National Capital', 'NC', 1),
(2502, 165, 'New Ireland', 'NI', 1),
(2503, 165, 'Northern', 'NO', 1),
(2504, 165, 'Sandaun', 'SA', 1),
(2505, 165, 'Southern Highlands', 'SH', 1),
(2506, 165, 'Western', 'WE', 1),
(2507, 165, 'Western Highlands', 'WH', 1),
(2508, 165, 'West New Britain', 'WB', 1),
(2509, 166, 'Alto Paraguay', 'AG', 1),
(2510, 166, 'Alto Parana', 'AN', 1),
(2511, 166, 'Amambay', 'AM', 1),
(2512, 166, 'Asuncion', 'AS', 1),
(2513, 166, 'Boqueron', 'BO', 1),
(2514, 166, 'Caaguazu', 'CG', 1),
(2515, 166, 'Caazapa', 'CZ', 1),
(2516, 166, 'Canindeyu', 'CN', 1),
(2517, 166, 'Central', 'CE', 1),
(2518, 166, 'Concepcion', 'CC', 1),
(2519, 166, 'Cordillera', 'CD', 1),
(2520, 166, 'Guaira', 'GU', 1),
(2521, 166, 'Itapua', 'IT', 1),
(2522, 166, 'Misiones', 'MI', 1),
(2523, 166, 'Neembucu', 'NE', 1),
(2524, 166, 'Paraguari', 'PA', 1),
(2525, 166, 'Presidente Hayes', 'PH', 1),
(2526, 166, 'San Pedro', 'SP', 1),
(2527, 167, 'Amazonas', 'AM', 1),
(2528, 167, 'Ancash', 'AN', 1),
(2529, 167, 'Apurimac', 'AP', 1),
(2530, 167, 'Arequipa', 'AR', 1),
(2531, 167, 'Ayacucho', 'AY', 1),
(2532, 167, 'Cajamarca', 'CJ', 1),
(2533, 167, 'Callao', 'CL', 1),
(2534, 167, 'Cusco', 'CU', 1),
(2535, 167, 'Huancavelica', 'HV', 1),
(2536, 167, 'Huanuco', 'HO', 1),
(2537, 167, 'Ica', 'IC', 1),
(2538, 167, 'Junin', 'JU', 1),
(2539, 167, 'La Libertad', 'LD', 1),
(2540, 167, 'Lambayeque', 'LY', 1),
(2541, 167, 'Lima', 'LI', 1),
(2542, 167, 'Loreto', 'LO', 1),
(2543, 167, 'Madre de Dios', 'MD', 1),
(2544, 167, 'Moquegua', 'MO', 1),
(2545, 167, 'Pasco', 'PA', 1),
(2546, 167, 'Piura', 'PI', 1),
(2547, 167, 'Puno', 'PU', 1),
(2548, 167, 'San Martin', 'SM', 1),
(2549, 167, 'Tacna', 'TA', 1),
(2550, 167, 'Tumbes', 'TU', 1),
(2551, 167, 'Ucayali', 'UC', 1),
(2552, 168, 'Abra', 'ABR', 1),
(2553, 168, 'Agusan del Norte', 'ANO', 1),
(2554, 168, 'Agusan del Sur', 'ASU', 1),
(2555, 168, 'Aklan', 'AKL', 1),
(2556, 168, 'Albay', 'ALB', 1),
(2557, 168, 'Antique', 'ANT', 1),
(2558, 168, 'Apayao', 'APY', 1),
(2559, 168, 'Aurora', 'AUR', 1),
(2560, 168, 'Basilan', 'BAS', 1),
(2561, 168, 'Bataan', 'BTA', 1),
(2562, 168, 'Batanes', 'BTE', 1),
(2563, 168, 'Batangas', 'BTG', 1),
(2564, 168, 'Biliran', 'BLR', 1),
(2565, 168, 'Benguet', 'BEN', 1),
(2566, 168, 'Bohol', 'BOL', 1),
(2567, 168, 'Bukidnon', 'BUK', 1),
(2568, 168, 'Bulacan', 'BUL', 1),
(2569, 168, 'Cagayan', 'CAG', 1),
(2570, 168, 'Camarines Norte', 'CNO', 1),
(2571, 168, 'Camarines Sur', 'CSU', 1),
(2572, 168, 'Camiguin', 'CAM', 1),
(2573, 168, 'Capiz', 'CAP', 1),
(2574, 168, 'Catanduanes', 'CAT', 1),
(2575, 168, 'Cavite', 'CAV', 1),
(2576, 168, 'Cebu', 'CEB', 1),
(2577, 168, 'Compostela', 'CMP', 1),
(2578, 168, 'Davao del Norte', 'DNO', 1),
(2579, 168, 'Davao del Sur', 'DSU', 1),
(2580, 168, 'Davao Oriental', 'DOR', 1),
(2581, 168, 'Eastern Samar', 'ESA', 1),
(2582, 168, 'Guimaras', 'GUI', 1),
(2583, 168, 'Ifugao', 'IFU', 1),
(2584, 168, 'Ilocos Norte', 'INO', 1),
(2585, 168, 'Ilocos Sur', 'ISU', 1),
(2586, 168, 'Iloilo', 'ILO', 1),
(2587, 168, 'Isabela', 'ISA', 1),
(2588, 168, 'Kalinga', 'KAL', 1),
(2589, 168, 'Laguna', 'LAG', 1),
(2590, 168, 'Lanao del Norte', 'LNO', 1),
(2591, 168, 'Lanao del Sur', 'LSU', 1),
(2592, 168, 'La Union', 'UNI', 1),
(2593, 168, 'Leyte', 'LEY', 1),
(2594, 168, 'Maguindanao', 'MAG', 1),
(2595, 168, 'Marinduque', 'MRN', 1),
(2596, 168, 'Masbate', 'MSB', 1),
(2597, 168, 'Mindoro Occidental', 'MIC', 1),
(2598, 168, 'Mindoro Oriental', 'MIR', 1),
(2599, 168, 'Misamis Occidental', 'MSC', 1),
(2600, 168, 'Misamis Oriental', 'MOR', 1),
(2601, 168, 'Mountain', 'MOP', 1),
(2602, 168, 'Negros Occidental', 'NOC', 1),
(2603, 168, 'Negros Oriental', 'NOR', 1),
(2604, 168, 'North Cotabato', 'NCT', 1),
(2605, 168, 'Northern Samar', 'NSM', 1),
(2606, 168, 'Nueva Ecija', 'NEC', 1),
(2607, 168, 'Nueva Vizcaya', 'NVZ', 1),
(2608, 168, 'Palawan', 'PLW', 1),
(2609, 168, 'Pampanga', 'PMP', 1),
(2610, 168, 'Pangasinan', 'PNG', 1),
(2611, 168, 'Quezon', 'QZN', 1),
(2612, 168, 'Quirino', 'QRN', 1),
(2613, 168, 'Rizal', 'RIZ', 1),
(2614, 168, 'Romblon', 'ROM', 1),
(2615, 168, 'Samar', 'SMR', 1),
(2616, 168, 'Sarangani', 'SRG', 1),
(2617, 168, 'Siquijor', 'SQJ', 1),
(2618, 168, 'Sorsogon', 'SRS', 1),
(2619, 168, 'South Cotabato', 'SCO', 1),
(2620, 168, 'Southern Leyte', 'SLE', 1),
(2621, 168, 'Sultan Kudarat', 'SKU', 1),
(2622, 168, 'Sulu', 'SLU', 1),
(2623, 168, 'Surigao del Norte', 'SNO', 1),
(2624, 168, 'Surigao del Sur', 'SSU', 1),
(2625, 168, 'Tarlac', 'TAR', 1),
(2626, 168, 'Tawi-Tawi', 'TAW', 1),
(2627, 168, 'Zambales', 'ZBL', 1),
(2628, 168, 'Zamboanga del Norte', 'ZNO', 1),
(2629, 168, 'Zamboanga del Sur', 'ZSU', 1),
(2630, 168, 'Zamboanga Sibugay', 'ZSI', 1),
(2631, 170, 'Dolnoslaskie', 'DO', 1),
(2632, 170, 'Kujawsko-Pomorskie', 'KP', 1),
(2633, 170, 'Lodzkie', 'LO', 1),
(2634, 170, 'Lubelskie', 'LL', 1),
(2635, 170, 'Lubuskie', 'LU', 1),
(2636, 170, 'Malopolskie', 'ML', 1),
(2637, 170, 'Mazowieckie', 'MZ', 1),
(2638, 170, 'Opolskie', 'OP', 1),
(2639, 170, 'Podkarpackie', 'PP', 1),
(2640, 170, 'Podlaskie', 'PL', 1),
(2641, 170, 'Pomorskie', 'PM', 1),
(2642, 170, 'Slaskie', 'SL', 1),
(2643, 170, 'Swietokrzyskie', 'SW', 1),
(2644, 170, 'Warminsko-Mazurskie', 'WM', 1),
(2645, 170, 'Wielkopolskie', 'WP', 1),
(2646, 170, 'Zachodniopomorskie', 'ZA', 1),
(2647, 198, 'Saint Pierre', 'P', 1),
(2648, 198, 'Miquelon', 'M', 1),
(2649, 171, 'A&ccedil;ores', 'AC', 1),
(2650, 171, 'Aveiro', 'AV', 1),
(2651, 171, 'Beja', 'BE', 1),
(2652, 171, 'Braga', 'BR', 1),
(2653, 171, 'Bragan&ccedil;a', 'BA', 1),
(2654, 171, 'Castelo Branco', 'CB', 1),
(2655, 171, 'Coimbra', 'CO', 1),
(2656, 171, '&Eacute;vora', 'EV', 1),
(2657, 171, 'Faro', 'FA', 1),
(2658, 171, 'Guarda', 'GU', 1),
(2659, 171, 'Leiria', 'LE', 1),
(2660, 171, 'Lisboa', 'LI', 1),
(2661, 171, 'Madeira', 'ME', 1),
(2662, 171, 'Portalegre', 'PO', 1),
(2663, 171, 'Porto', 'PR', 1),
(2664, 171, 'Santar&eacute;m', 'SA', 1),
(2665, 171, 'Set&uacute;bal', 'SE', 1),
(2666, 171, 'Viana do Castelo', 'VC', 1),
(2667, 171, 'Vila Real', 'VR', 1),
(2668, 171, 'Viseu', 'VI', 1),
(2669, 173, 'Ad Dawhah', 'DW', 1),
(2670, 173, 'Al Ghuwayriyah', 'GW', 1),
(2671, 173, 'Al Jumayliyah', 'JM', 1),
(2672, 173, 'Al Khawr', 'KR', 1),
(2673, 173, 'Al Wakrah', 'WK', 1),
(2674, 173, 'Ar Rayyan', 'RN', 1),
(2675, 173, 'Jarayan al Batinah', 'JB', 1),
(2676, 173, 'Madinat ash Shamal', 'MS', 1),
(2677, 173, 'Umm Sa''id', 'UD', 1),
(2678, 173, 'Umm Salal', 'UL', 1),
(2679, 175, 'Alba', 'AB', 1),
(2680, 175, 'Arad', 'AR', 1),
(2681, 175, 'Arges', 'AG', 1),
(2682, 175, 'Bacau', 'BC', 1),
(2683, 175, 'Bihor', 'BH', 1),
(2684, 175, 'Bistrita-Nasaud', 'BN', 1),
(2685, 175, 'Botosani', 'BT', 1),
(2686, 175, 'Brasov', 'BV', 1),
(2687, 175, 'Braila', 'BR', 1),
(2688, 175, 'Bucuresti', 'B', 1),
(2689, 175, 'Buzau', 'BZ', 1),
(2690, 175, 'Caras-Severin', 'CS', 1),
(2691, 175, 'Calarasi', 'CL', 1),
(2692, 175, 'Cluj', 'CJ', 1),
(2693, 175, 'Constanta', 'CT', 1),
(2694, 175, 'Covasna', 'CV', 1),
(2695, 175, 'Dimbovita', 'DB', 1),
(2696, 175, 'Dolj', 'DJ', 1),
(2697, 175, 'Galati', 'GL', 1),
(2698, 175, 'Giurgiu', 'GR', 1),
(2699, 175, 'Gorj', 'GJ', 1),
(2700, 175, 'Harghita', 'HR', 1),
(2701, 175, 'Hunedoara', 'HD', 1),
(2702, 175, 'Ialomita', 'IL', 1),
(2703, 175, 'Iasi', 'IS', 1),
(2704, 175, 'Ilfov', 'IF', 1),
(2705, 175, 'Maramures', 'MM', 1),
(2706, 175, 'Mehedinti', 'MH', 1),
(2707, 175, 'Mures', 'MS', 1),
(2708, 175, 'Neamt', 'NT', 1),
(2709, 175, 'Olt', 'OT', 1),
(2710, 175, 'Prahova', 'PH', 1),
(2711, 175, 'Satu-Mare', 'SM', 1),
(2712, 175, 'Salaj', 'SJ', 1),
(2713, 175, 'Sibiu', 'SB', 1),
(2714, 175, 'Suceava', 'SV', 1),
(2715, 175, 'Teleorman', 'TR', 1),
(2716, 175, 'Timis', 'TM', 1),
(2717, 175, 'Tulcea', 'TL', 1),
(2718, 175, 'Vaslui', 'VS', 1),
(2719, 175, 'Valcea', 'VL', 1),
(2720, 175, 'Vrancea', 'VN', 1),
(2721, 176, 'Республика Хакасия', 'KK', 1),
(2722, 176, 'Московская область', 'MOS', 1),
(2723, 176, 'Чукотский АО', 'CHU', 1),
(2724, 176, 'Архангельская область', 'ARK', 1),
(2725, 176, 'Астраханская область', 'AST', 1),
(2726, 176, 'Алтайский край', 'ALT', 1),
(2727, 176, 'Белгородская область', 'BEL', 1),
(2728, 176, 'Еврейская АО', 'YEV', 1),
(2729, 176, 'Амурская область', 'AMU', 1),
(2730, 176, 'Брянская область', 'BRY', 1),
(2731, 176, 'Чувашская Республика', 'CU', 1),
(2732, 176, 'Челябинская область', 'CHE', 1),
(2733, 176, 'Карачаево-Черкеcсия', 'KC', 1),
(2734, 176, 'Забайкальский край', 'ZAB', 1),
(2735, 176, 'Ленинградская область', 'LEN', 1),
(2736, 176, 'Республика Калмыкия', 'KL', 1),
(2737, 176, 'Сахалинская область', 'SAK', 1),
(2738, 176, 'Республика Алтай', 'AL', 1),
(2739, 176, 'Чеченская Республика', 'CE', 1),
(2740, 176, 'Иркутская область', 'IRK', 1),
(2741, 176, 'Ивановская область', 'IVA', 1),
(2742, 176, 'Удмуртская Республика', 'UD', 1),
(2743, 176, 'Калининградская область', 'KGD', 1),
(2744, 176, 'Калужская область', 'KLU', 1),
(2746, 176, 'Республика Татарстан', 'TA', 1),
(2747, 176, 'Кемеровская область', 'KEM', 1),
(2748, 176, 'Хабаровский край', 'KHA', 1),
(2749, 176, 'Ханты-Мансийский АО - Югра', 'KHM', 1),
(2750, 176, 'Костромская область', 'KOS', 1),
(2751, 176, 'Краснодарский край', 'KDA', 1),
(2752, 176, 'Красноярский край', 'KYA', 1),
(2754, 176, 'Курганская область', 'KGN', 1),
(2755, 176, 'Курская область', 'KRS', 1),
(2756, 176, 'Республика Тыва', 'TY', 1),
(2757, 176, 'Липецкая область', 'LIP', 1),
(2758, 176, 'Магаданская область', 'MAG', 1),
(2759, 176, 'Республика Дагестан', 'DA', 1),
(2760, 176, 'Республика Адыгея', 'AD', 1),
(2761, 176, 'Москва', 'MOW', 1),
(2762, 176, 'Мурманская область', 'MUR', 1),
(2763, 176, 'Республика Кабардино-Балкария', 'KB', 1),
(2764, 176, 'Ненецкий АО', 'NEN', 1),
(2765, 176, 'Республика Ингушетия', 'IN', 1),
(2766, 176, 'Нижегородская область', 'NIZ', 1),
(2767, 176, 'Новгородская область', 'NGR', 1),
(2768, 176, 'Новосибирская область', 'NVS', 1),
(2769, 176, 'Омская область', 'OMS', 1),
(2770, 176, 'Орловская область', 'ORL', 1),
(2771, 176, 'Оренбургская область', 'ORE', 1),
(2773, 176, 'Пензенская область', 'PNZ', 1),
(2774, 176, 'Пермский край', 'PER', 1),
(2775, 176, 'Камчатский край', 'KAM', 1),
(2776, 176, 'Республика Карелия', 'KR', 1),
(2777, 176, 'Псковская область', 'PSK', 1),
(2778, 176, 'Ростовская область', 'ROS', 1),
(2779, 176, 'Рязанская область', 'RYA', 1),
(2780, 176, 'Ямало-Ненецкий АО', 'YAN', 1),
(2781, 176, 'Самарская область', 'SAM', 1),
(2782, 176, 'Республика Мордовия', 'MO', 1),
(2783, 176, 'Саратовская область', 'SAR', 1),
(2784, 176, 'Смоленская область', 'SMO', 1),
(2785, 176, 'Санкт-Петербург', 'SPE', 1),
(2786, 176, 'Ставропольский край', 'STA', 1),
(2787, 176, 'Республика Коми', 'KO', 1),
(2788, 176, 'Тамбовская область', 'TAM', 1),
(2789, 176, 'Томская область', 'TOM', 1),
(2790, 176, 'Тульская область', 'TUL', 1),
(2792, 176, 'Тверская область', 'TVE', 1),
(2793, 176, 'Тюменская область', 'TYU', 1),
(2794, 176, 'Республика Башкортостан', 'BA', 1),
(2795, 176, 'Ульяновская область', 'ULY', 1),
(2796, 176, 'Республика Бурятия', 'BU', 1),
(2798, 176, 'Республика Северная Осетия', 'SE', 1),
(2799, 176, 'Владимирская область', 'VLA', 1),
(2800, 176, 'Приморский край', 'PRI', 1),
(2801, 176, 'Волгоградская область', 'VGG', 1),
(2802, 176, 'Вологодская область', 'VLG', 1),
(2803, 176, 'Воронежская область', 'VOR', 1),
(2804, 176, 'Кировская область', 'KIR', 1),
(2805, 176, 'Республика Саха', 'SA', 1),
(2806, 176, 'Ярославская область', 'YAR', 1),
(2807, 176, 'Свердловская область', 'SVE', 1),
(2808, 176, 'Республика Марий Эл', 'ME', 1),
(2809, 177, 'Butare', 'BU', 1),
(2810, 177, 'Byumba', 'BY', 1),
(2811, 177, 'Cyangugu', 'CY', 1),
(2812, 177, 'Gikongoro', 'GK', 1),
(2813, 177, 'Gisenyi', 'GS', 1),
(2814, 177, 'Gitarama', 'GT', 1),
(2815, 177, 'Kibungo', 'KG', 1),
(2816, 177, 'Kibuye', 'KY', 1),
(2817, 177, 'Kigali Rurale', 'KR', 1),
(2818, 177, 'Kigali-ville', 'KV', 1),
(2819, 177, 'Ruhengeri', 'RU', 1),
(2820, 177, 'Umutara', 'UM', 1),
(2821, 178, 'Christ Church Nichola Town', 'CCN', 1),
(2822, 178, 'Saint Anne Sandy Point', 'SAS', 1),
(2823, 178, 'Saint George Basseterre', 'SGB', 1),
(2824, 178, 'Saint George Gingerland', 'SGG', 1),
(2825, 178, 'Saint James Windward', 'SJW', 1),
(2826, 178, 'Saint John Capesterre', 'SJC', 1),
(2827, 178, 'Saint John Figtree', 'SJF', 1),
(2828, 178, 'Saint Mary Cayon', 'SMC', 1),
(2829, 178, 'Saint Paul Capesterre', 'CAP', 1),
(2830, 178, 'Saint Paul Charlestown', 'CHA', 1),
(2831, 178, 'Saint Peter Basseterre', 'SPB', 1),
(2832, 178, 'Saint Thomas Lowland', 'STL', 1),
(2833, 178, 'Saint Thomas Middle Island', 'STM', 1),
(2834, 178, 'Trinity Palmetto Point', 'TPP', 1),
(2835, 179, 'Anse-la-Raye', 'AR', 1),
(2836, 179, 'Castries', 'CA', 1),
(2837, 179, 'Choiseul', 'CH', 1),
(2838, 179, 'Dauphin', 'DA', 1),
(2839, 179, 'Dennery', 'DE', 1),
(2840, 179, 'Gros-Islet', 'GI', 1),
(2841, 179, 'Laborie', 'LA', 1),
(2842, 179, 'Micoud', 'MI', 1),
(2843, 179, 'Praslin', 'PR', 1),
(2844, 179, 'Soufriere', 'SO', 1),
(2845, 179, 'Vieux-Fort', 'VF', 1),
(2846, 180, 'Charlotte', 'C', 1),
(2847, 180, 'Grenadines', 'R', 1),
(2848, 180, 'Saint Andrew', 'A', 1),
(2849, 180, 'Saint David', 'D', 1),
(2850, 180, 'Saint George', 'G', 1),
(2851, 180, 'Saint Patrick', 'P', 1),
(2852, 181, 'A''ana', 'AN', 1),
(2853, 181, 'Aiga-i-le-Tai', 'AI', 1),
(2854, 181, 'Atua', 'AT', 1),
(2855, 181, 'Fa''asaleleaga', 'FA', 1),
(2856, 181, 'Gaga''emauga', 'GE', 1),
(2857, 181, 'Gagaifomauga', 'GF', 1),
(2858, 181, 'Palauli', 'PA', 1),
(2859, 181, 'Satupa''itea', 'SA', 1),
(2860, 181, 'Tuamasaga', 'TU', 1),
(2861, 181, 'Va''a-o-Fonoti', 'VF', 1),
(2862, 181, 'Vaisigano', 'VS', 1),
(2863, 182, 'Acquaviva', 'AC', 1),
(2864, 182, 'Borgo Maggiore', 'BM', 1),
(2865, 182, 'Chiesanuova', 'CH', 1),
(2866, 182, 'Domagnano', 'DO', 1),
(2867, 182, 'Faetano', 'FA', 1),
(2868, 182, 'Fiorentino', 'FI', 1),
(2869, 182, 'Montegiardino', 'MO', 1),
(2870, 182, 'Citta di San Marino', 'SM', 1),
(2871, 182, 'Serravalle', 'SE', 1),
(2872, 183, 'Sao Tome', 'S', 1),
(2873, 183, 'Principe', 'P', 1),
(2874, 184, 'Al Bahah', 'BH', 1),
(2875, 184, 'Al Hudud ash Shamaliyah', 'HS', 1),
(2876, 184, 'Al Jawf', 'JF', 1),
(2877, 184, 'Al Madinah', 'MD', 1),
(2878, 184, 'Al Qasim', 'QS', 1),
(2879, 184, 'Ar Riyad', 'RD', 1),
(2880, 184, 'Ash Sharqiyah (Eastern)', 'AQ', 1),
(2881, 184, '''Asir', 'AS', 1),
(2882, 184, 'Ha''il', 'HL', 1),
(2883, 184, 'Jizan', 'JZ', 1),
(2884, 184, 'Makkah', 'ML', 1),
(2885, 184, 'Najran', 'NR', 1),
(2886, 184, 'Tabuk', 'TB', 1),
(2887, 185, 'Dakar', 'DA', 1),
(2888, 185, 'Diourbel', 'DI', 1),
(2889, 185, 'Fatick', 'FA', 1),
(2890, 185, 'Kaolack', 'KA', 1),
(2891, 185, 'Kolda', 'KO', 1),
(2892, 185, 'Louga', 'LO', 1),
(2893, 185, 'Matam', 'MA', 1),
(2894, 185, 'Saint-Louis', 'SL', 1),
(2895, 185, 'Tambacounda', 'TA', 1),
(2896, 185, 'Thies', 'TH', 1),
(2897, 185, 'Ziguinchor', 'ZI', 1),
(2898, 186, 'Anse aux Pins', 'AP', 1),
(2899, 186, 'Anse Boileau', 'AB', 1),
(2900, 186, 'Anse Etoile', 'AE', 1),
(2901, 186, 'Anse Louis', 'AL', 1),
(2902, 186, 'Anse Royale', 'AR', 1),
(2903, 186, 'Baie Lazare', 'BL', 1),
(2904, 186, 'Baie Sainte Anne', 'BS', 1),
(2905, 186, 'Beau Vallon', 'BV', 1),
(2906, 186, 'Bel Air', 'BA', 1),
(2907, 186, 'Bel Ombre', 'BO', 1),
(2908, 186, 'Cascade', 'CA', 1),
(2909, 186, 'Glacis', 'GL', 1),
(2910, 186, 'Grand'' Anse (on Mahe)', 'GM', 1),
(2911, 186, 'Grand'' Anse (on Praslin)', 'GP', 1),
(2912, 186, 'La Digue', 'DG', 1),
(2913, 186, 'La Riviere Anglaise', 'RA', 1),
(2914, 186, 'Mont Buxton', 'MB', 1),
(2915, 186, 'Mont Fleuri', 'MF', 1),
(2916, 186, 'Plaisance', 'PL', 1),
(2917, 186, 'Pointe La Rue', 'PR', 1),
(2918, 186, 'Port Glaud', 'PG', 1),
(2919, 186, 'Saint Louis', 'SL', 1),
(2920, 186, 'Takamaka', 'TA', 1),
(2921, 187, 'Eastern', 'E', 1),
(2922, 187, 'Northern', 'N', 1),
(2923, 187, 'Southern', 'S', 1),
(2924, 187, 'Western', 'W', 1),
(2925, 189, 'Banskobystrický', 'BA', 1),
(2926, 189, 'Bratislavský', 'BR', 1),
(2927, 189, 'Košický', 'KO', 1),
(2928, 189, 'Nitriansky', 'NI', 1),
(2929, 189, 'Prešovský', 'PR', 1),
(2930, 189, 'Trenčiansky', 'TC', 1),
(2931, 189, 'Trnavský', 'TV', 1),
(2932, 189, 'Žilinský', 'ZI', 1),
(2933, 191, 'Central', 'CE', 1),
(2934, 191, 'Choiseul', 'CH', 1),
(2935, 191, 'Guadalcanal', 'GC', 1),
(2936, 191, 'Honiara', 'HO', 1),
(2937, 191, 'Isabel', 'IS', 1),
(2938, 191, 'Makira', 'MK', 1),
(2939, 191, 'Malaita', 'ML', 1),
(2940, 191, 'Rennell and Bellona', 'RB', 1),
(2941, 191, 'Temotu', 'TM', 1),
(2942, 191, 'Western', 'WE', 1),
(2943, 192, 'Awdal', 'AW', 1),
(2944, 192, 'Bakool', 'BK', 1),
(2945, 192, 'Banaadir', 'BN', 1),
(2946, 192, 'Bari', 'BR', 1),
(2947, 192, 'Bay', 'BY', 1),
(2948, 192, 'Galguduud', 'GA', 1),
(2949, 192, 'Gedo', 'GE', 1),
(2950, 192, 'Hiiraan', 'HI', 1),
(2951, 192, 'Jubbada Dhexe', 'JD', 1),
(2952, 192, 'Jubbada Hoose', 'JH', 1),
(2953, 192, 'Mudug', 'MU', 1),
(2954, 192, 'Nugaal', 'NU', 1),
(2955, 192, 'Sanaag', 'SA', 1),
(2956, 192, 'Shabeellaha Dhexe', 'SD', 1),
(2957, 192, 'Shabeellaha Hoose', 'SH', 1),
(2958, 192, 'Sool', 'SL', 1),
(2959, 192, 'Togdheer', 'TO', 1),
(2960, 192, 'Woqooyi Galbeed', 'WG', 1),
(2961, 193, 'Eastern Cape', 'EC', 1),
(2962, 193, 'Free State', 'FS', 1),
(2963, 193, 'Gauteng', 'GT', 1),
(2964, 193, 'KwaZulu-Natal', 'KN', 1),
(2965, 193, 'Limpopo', 'LP', 1),
(2966, 193, 'Mpumalanga', 'MP', 1),
(2967, 193, 'North West', 'NW', 1),
(2968, 193, 'Northern Cape', 'NC', 1),
(2969, 193, 'Western Cape', 'WC', 1),
(2970, 195, 'La Coru&ntilde;a', 'CA', 1),
(2971, 195, '&Aacute;lava', 'AL', 1),
(2972, 195, 'Albacete', 'AB', 1),
(2973, 195, 'Alicante', 'AC', 1),
(2974, 195, 'Almeria', 'AM', 1),
(2975, 195, 'Asturias', 'AS', 1),
(2976, 195, '&Aacute;vila', 'AV', 1),
(2977, 195, 'Badajoz', 'BJ', 1),
(2978, 195, 'Baleares', 'IB', 1),
(2979, 195, 'Barcelona', 'BA', 1),
(2980, 195, 'Burgos', 'BU', 1),
(2981, 195, 'C&aacute;ceres', 'CC', 1),
(2982, 195, 'C&aacute;diz', 'CZ', 1),
(2983, 195, 'Cantabria', 'CT', 1),
(2984, 195, 'Castell&oacute;n', 'CL', 1),
(2985, 195, 'Ceuta', 'CE', 1),
(2986, 195, 'Ciudad Real', 'CR', 1),
(2987, 195, 'C&oacute;rdoba', 'CD', 1),
(2988, 195, 'Cuenca', 'CU', 1),
(2989, 195, 'Girona', 'GI', 1),
(2990, 195, 'Granada', 'GD', 1),
(2991, 195, 'Guadalajara', 'GJ', 1),
(2992, 195, 'Guip&uacute;zcoa', 'GP', 1),
(2993, 195, 'Huelva', 'HL', 1),
(2994, 195, 'Huesca', 'HS', 1),
(2995, 195, 'Ja&eacute;n', 'JN', 1),
(2996, 195, 'La Rioja', 'RJ', 1),
(2997, 195, 'Las Palmas', 'PM', 1),
(2998, 195, 'Leon', 'LE', 1),
(2999, 195, 'Lleida', 'LL', 1),
(3000, 195, 'Lugo', 'LG', 1),
(3001, 195, 'Madrid', 'MD', 1),
(3002, 195, 'Malaga', 'MA', 1),
(3003, 195, 'Melilla', 'ML', 1),
(3004, 195, 'Murcia', 'MU', 1),
(3005, 195, 'Navarra', 'NV', 1),
(3006, 195, 'Ourense', 'OU', 1),
(3007, 195, 'Palencia', 'PL', 1),
(3008, 195, 'Pontevedra', 'PO', 1),
(3009, 195, 'Salamanca', 'SL', 1),
(3010, 195, 'Santa Cruz de Tenerife', 'SC', 1),
(3011, 195, 'Segovia', 'SG', 1),
(3012, 195, 'Sevilla', 'SV', 1),
(3013, 195, 'Soria', 'SO', 1),
(3014, 195, 'Tarragona', 'TA', 1);
INSERT INTO `zone` (`zone_id`, `country_id`, `name`, `code`, `status`) VALUES
(3015, 195, 'Teruel', 'TE', 1),
(3016, 195, 'Toledo', 'TO', 1),
(3017, 195, 'Valencia', 'VC', 1),
(3018, 195, 'Valladolid', 'VD', 1),
(3019, 195, 'Vizcaya', 'VZ', 1),
(3020, 195, 'Zamora', 'ZM', 1),
(3021, 195, 'Zaragoza', 'ZR', 1),
(3022, 196, 'Central', 'CE', 1),
(3023, 196, 'Eastern', 'EA', 1),
(3024, 196, 'North Central', 'NC', 1),
(3025, 196, 'Northern', 'NO', 1),
(3026, 196, 'North Western', 'NW', 1),
(3027, 196, 'Sabaragamuwa', 'SA', 1),
(3028, 196, 'Southern', 'SO', 1),
(3029, 196, 'Uva', 'UV', 1),
(3030, 196, 'Western', 'WE', 1),
(3031, 197, 'Ascension', 'A', 1),
(3032, 197, 'Saint Helena', 'S', 1),
(3033, 197, 'Tristan da Cunha', 'T', 1),
(3034, 199, 'A''ali an Nil', 'ANL', 1),
(3035, 199, 'Al Bahr al Ahmar', 'BAM', 1),
(3036, 199, 'Al Buhayrat', 'BRT', 1),
(3037, 199, 'Al Jazirah', 'JZR', 1),
(3038, 199, 'Al Khartum', 'KRT', 1),
(3039, 199, 'Al Qadarif', 'QDR', 1),
(3040, 199, 'Al Wahdah', 'WDH', 1),
(3041, 199, 'An Nil al Abyad', 'ANB', 1),
(3042, 199, 'An Nil al Azraq', 'ANZ', 1),
(3043, 199, 'Ash Shamaliyah', 'ASH', 1),
(3044, 199, 'Bahr al Jabal', 'BJA', 1),
(3045, 199, 'Gharb al Istiwa''iyah', 'GIS', 1),
(3046, 199, 'Gharb Bahr al Ghazal', 'GBG', 1),
(3047, 199, 'Gharb Darfur', 'GDA', 1),
(3048, 199, 'Gharb Kurdufan', 'GKU', 1),
(3049, 199, 'Janub Darfur', 'JDA', 1),
(3050, 199, 'Janub Kurdufan', 'JKU', 1),
(3051, 199, 'Junqali', 'JQL', 1),
(3052, 199, 'Kassala', 'KSL', 1),
(3053, 199, 'Nahr an Nil', 'NNL', 1),
(3054, 199, 'Shamal Bahr al Ghazal', 'SBG', 1),
(3055, 199, 'Shamal Darfur', 'SDA', 1),
(3056, 199, 'Shamal Kurdufan', 'SKU', 1),
(3057, 199, 'Sharq al Istiwa''iyah', 'SIS', 1),
(3058, 199, 'Sinnar', 'SNR', 1),
(3059, 199, 'Warab', 'WRB', 1),
(3060, 200, 'Brokopondo', 'BR', 1),
(3061, 200, 'Commewijne', 'CM', 1),
(3062, 200, 'Coronie', 'CR', 1),
(3063, 200, 'Marowijne', 'MA', 1),
(3064, 200, 'Nickerie', 'NI', 1),
(3065, 200, 'Para', 'PA', 1),
(3066, 200, 'Paramaribo', 'PM', 1),
(3067, 200, 'Saramacca', 'SA', 1),
(3068, 200, 'Sipaliwini', 'SI', 1),
(3069, 200, 'Wanica', 'WA', 1),
(3070, 202, 'Hhohho', 'H', 1),
(3071, 202, 'Lubombo', 'L', 1),
(3072, 202, 'Manzini', 'M', 1),
(3073, 202, 'Shishelweni', 'S', 1),
(3074, 203, 'Blekinge', 'K', 1),
(3075, 203, 'Dalarna', 'W', 1),
(3076, 203, 'G&auml;vleborg', 'X', 1),
(3077, 203, 'Gotland', 'I', 1),
(3078, 203, 'Halland', 'N', 1),
(3079, 203, 'J&auml;mtland', 'Z', 1),
(3080, 203, 'J&ouml;nk&ouml;ping', 'F', 1),
(3081, 203, 'Kalmar', 'H', 1),
(3082, 203, 'Kronoberg', 'G', 1),
(3083, 203, 'Norrbotten', 'BD', 1),
(3084, 203, '&Ouml;rebro', 'T', 1),
(3085, 203, '&Ouml;sterg&ouml;tland', 'E', 1),
(3086, 203, 'Sk&aring;ne', 'M', 1),
(3087, 203, 'S&ouml;dermanland', 'D', 1),
(3088, 203, 'Stockholm', 'AB', 1),
(3089, 203, 'Uppsala', 'C', 1),
(3090, 203, 'V&auml;rmland', 'S', 1),
(3091, 203, 'V&auml;sterbotten', 'AC', 1),
(3092, 203, 'V&auml;sternorrland', 'Y', 1),
(3093, 203, 'V&auml;stmanland', 'U', 1),
(3094, 203, 'V&auml;stra G&ouml;taland', 'O', 1),
(3095, 204, 'Aargau', 'AG', 1),
(3096, 204, 'Appenzell Ausserrhoden', 'AR', 1),
(3097, 204, 'Appenzell Innerrhoden', 'AI', 1),
(3098, 204, 'Basel-Stadt', 'BS', 1),
(3099, 204, 'Basel-Landschaft', 'BL', 1),
(3100, 204, 'Bern', 'BE', 1),
(3101, 204, 'Fribourg', 'FR', 1),
(3102, 204, 'Gen&egrave;ve', 'GE', 1),
(3103, 204, 'Glarus', 'GL', 1),
(3104, 204, 'Graub&uuml;nden', 'GR', 1),
(3105, 204, 'Jura', 'JU', 1),
(3106, 204, 'Luzern', 'LU', 1),
(3107, 204, 'Neuch&acirc;tel', 'NE', 1),
(3108, 204, 'Nidwald', 'NW', 1),
(3109, 204, 'Obwald', 'OW', 1),
(3110, 204, 'St. Gallen', 'SG', 1),
(3111, 204, 'Schaffhausen', 'SH', 1),
(3112, 204, 'Schwyz', 'SZ', 1),
(3113, 204, 'Solothurn', 'SO', 1),
(3114, 204, 'Thurgau', 'TG', 1),
(3115, 204, 'Ticino', 'TI', 1),
(3116, 204, 'Uri', 'UR', 1),
(3117, 204, 'Valais', 'VS', 1),
(3118, 204, 'Vaud', 'VD', 1),
(3119, 204, 'Zug', 'ZG', 1),
(3120, 204, 'Z&uuml;rich', 'ZH', 1),
(3121, 205, 'Al Hasakah', 'HA', 1),
(3122, 205, 'Al Ladhiqiyah', 'LA', 1),
(3123, 205, 'Al Qunaytirah', 'QU', 1),
(3124, 205, 'Ar Raqqah', 'RQ', 1),
(3125, 205, 'As Suwayda', 'SU', 1),
(3126, 205, 'Dara', 'DA', 1),
(3127, 205, 'Dayr az Zawr', 'DZ', 1),
(3128, 205, 'Dimashq', 'DI', 1),
(3129, 205, 'Halab', 'HL', 1),
(3130, 205, 'Hamah', 'HM', 1),
(3131, 205, 'Hims', 'HI', 1),
(3132, 205, 'Idlib', 'ID', 1),
(3133, 205, 'Rif Dimashq', 'RD', 1),
(3134, 205, 'Tartus', 'TA', 1),
(3135, 206, 'Chang-hua', 'CH', 1),
(3136, 206, 'Chia-i', 'CI', 1),
(3137, 206, 'Hsin-chu', 'HS', 1),
(3138, 206, 'Hua-lien', 'HL', 1),
(3139, 206, 'I-lan', 'IL', 1),
(3140, 206, 'Kao-hsiung county', 'KH', 1),
(3141, 206, 'Kin-men', 'KM', 1),
(3142, 206, 'Lien-chiang', 'LC', 1),
(3143, 206, 'Miao-li', 'ML', 1),
(3144, 206, 'Nan-t''ou', 'NT', 1),
(3145, 206, 'P''eng-hu', 'PH', 1),
(3146, 206, 'P''ing-tung', 'PT', 1),
(3147, 206, 'T''ai-chung', 'TG', 1),
(3148, 206, 'T''ai-nan', 'TA', 1),
(3149, 206, 'T''ai-pei county', 'TP', 1),
(3150, 206, 'T''ai-tung', 'TT', 1),
(3151, 206, 'T''ao-yuan', 'TY', 1),
(3152, 206, 'Yun-lin', 'YL', 1),
(3153, 206, 'Chia-i city', 'CC', 1),
(3154, 206, 'Chi-lung', 'CL', 1),
(3155, 206, 'Hsin-chu', 'HC', 1),
(3156, 206, 'T''ai-chung', 'TH', 1),
(3157, 206, 'T''ai-nan', 'TN', 1),
(3158, 206, 'Kao-hsiung city', 'KC', 1),
(3159, 206, 'T''ai-pei city', 'TC', 1),
(3160, 207, 'Gorno-Badakhstan', 'GB', 1),
(3161, 207, 'Khatlon', 'KT', 1),
(3162, 207, 'Sughd', 'SU', 1),
(3163, 208, 'Arusha', 'AR', 1),
(3164, 208, 'Dar es Salaam', 'DS', 1),
(3165, 208, 'Dodoma', 'DO', 1),
(3166, 208, 'Iringa', 'IR', 1),
(3167, 208, 'Kagera', 'KA', 1),
(3168, 208, 'Kigoma', 'KI', 1),
(3169, 208, 'Kilimanjaro', 'KJ', 1),
(3170, 208, 'Lindi', 'LN', 1),
(3171, 208, 'Manyara', 'MY', 1),
(3172, 208, 'Mara', 'MR', 1),
(3173, 208, 'Mbeya', 'MB', 1),
(3174, 208, 'Morogoro', 'MO', 1),
(3175, 208, 'Mtwara', 'MT', 1),
(3176, 208, 'Mwanza', 'MW', 1),
(3177, 208, 'Pemba North', 'PN', 1),
(3178, 208, 'Pemba South', 'PS', 1),
(3179, 208, 'Pwani', 'PW', 1),
(3180, 208, 'Rukwa', 'RK', 1),
(3181, 208, 'Ruvuma', 'RV', 1),
(3182, 208, 'Shinyanga', 'SH', 1),
(3183, 208, 'Singida', 'SI', 1),
(3184, 208, 'Tabora', 'TB', 1),
(3185, 208, 'Tanga', 'TN', 1),
(3186, 208, 'Zanzibar Central/South', 'ZC', 1),
(3187, 208, 'Zanzibar North', 'ZN', 1),
(3188, 208, 'Zanzibar Urban/West', 'ZU', 1),
(3189, 209, 'Amnat Charoen', 'Amnat Charoen', 1),
(3190, 209, 'Ang Thong', 'Ang Thong', 1),
(3191, 209, 'Ayutthaya', 'Ayutthaya', 1),
(3192, 209, 'Bangkok', 'Bangkok', 1),
(3193, 209, 'Buriram', 'Buriram', 1),
(3194, 209, 'Chachoengsao', 'Chachoengsao', 1),
(3195, 209, 'Chai Nat', 'Chai Nat', 1),
(3196, 209, 'Chaiyaphum', 'Chaiyaphum', 1),
(3197, 209, 'Chanthaburi', 'Chanthaburi', 1),
(3198, 209, 'Chiang Mai', 'Chiang Mai', 1),
(3199, 209, 'Chiang Rai', 'Chiang Rai', 1),
(3200, 209, 'Chon Buri', 'Chon Buri', 1),
(3201, 209, 'Chumphon', 'Chumphon', 1),
(3202, 209, 'Kalasin', 'Kalasin', 1),
(3203, 209, 'Kamphaeng Phet', 'Kamphaeng Phet', 1),
(3204, 209, 'Kanchanaburi', 'Kanchanaburi', 1),
(3205, 209, 'Khon Kaen', 'Khon Kaen', 1),
(3206, 209, 'Krabi', 'Krabi', 1),
(3207, 209, 'Lampang', 'Lampang', 1),
(3208, 209, 'Lamphun', 'Lamphun', 1),
(3209, 209, 'Loei', 'Loei', 1),
(3210, 209, 'Lop Buri', 'Lop Buri', 1),
(3211, 209, 'Mae Hong Son', 'Mae Hong Son', 1),
(3212, 209, 'Maha Sarakham', 'Maha Sarakham', 1),
(3213, 209, 'Mukdahan', 'Mukdahan', 1),
(3214, 209, 'Nakhon Nayok', 'Nakhon Nayok', 1),
(3215, 209, 'Nakhon Pathom', 'Nakhon Pathom', 1),
(3216, 209, 'Nakhon Phanom', 'Nakhon Phanom', 1),
(3217, 209, 'Nakhon Ratchasima', 'Nakhon Ratchasima', 1),
(3218, 209, 'Nakhon Sawan', 'Nakhon Sawan', 1),
(3219, 209, 'Nakhon Si Thammarat', 'Nakhon Si Thammarat', 1),
(3220, 209, 'Nan', 'Nan', 1),
(3221, 209, 'Narathiwat', 'Narathiwat', 1),
(3222, 209, 'Nong Bua Lamphu', 'Nong Bua Lamphu', 1),
(3223, 209, 'Nong Khai', 'Nong Khai', 1),
(3224, 209, 'Nonthaburi', 'Nonthaburi', 1),
(3225, 209, 'Pathum Thani', 'Pathum Thani', 1),
(3226, 209, 'Pattani', 'Pattani', 1),
(3227, 209, 'Phangnga', 'Phangnga', 1),
(3228, 209, 'Phatthalung', 'Phatthalung', 1),
(3229, 209, 'Phayao', 'Phayao', 1),
(3230, 209, 'Phetchabun', 'Phetchabun', 1),
(3231, 209, 'Phetchaburi', 'Phetchaburi', 1),
(3232, 209, 'Phichit', 'Phichit', 1),
(3233, 209, 'Phitsanulok', 'Phitsanulok', 1),
(3234, 209, 'Phrae', 'Phrae', 1),
(3235, 209, 'Phuket', 'Phuket', 1),
(3236, 209, 'Prachin Buri', 'Prachin Buri', 1),
(3237, 209, 'Prachuap Khiri Khan', 'Prachuap Khiri Khan', 1),
(3238, 209, 'Ranong', 'Ranong', 1),
(3239, 209, 'Ratchaburi', 'Ratchaburi', 1),
(3240, 209, 'Rayong', 'Rayong', 1),
(3241, 209, 'Roi Et', 'Roi Et', 1),
(3242, 209, 'Sa Kaeo', 'Sa Kaeo', 1),
(3243, 209, 'Sakon Nakhon', 'Sakon Nakhon', 1),
(3244, 209, 'Samut Prakan', 'Samut Prakan', 1),
(3245, 209, 'Samut Sakhon', 'Samut Sakhon', 1),
(3246, 209, 'Samut Songkhram', 'Samut Songkhram', 1),
(3247, 209, 'Sara Buri', 'Sara Buri', 1),
(3248, 209, 'Satun', 'Satun', 1),
(3249, 209, 'Sing Buri', 'Sing Buri', 1),
(3250, 209, 'Sisaket', 'Sisaket', 1),
(3251, 209, 'Songkhla', 'Songkhla', 1),
(3252, 209, 'Sukhothai', 'Sukhothai', 1),
(3253, 209, 'Suphan Buri', 'Suphan Buri', 1),
(3254, 209, 'Surat Thani', 'Surat Thani', 1),
(3255, 209, 'Surin', 'Surin', 1),
(3256, 209, 'Tak', 'Tak', 1),
(3257, 209, 'Trang', 'Trang', 1),
(3258, 209, 'Trat', 'Trat', 1),
(3259, 209, 'Ubon Ratchathani', 'Ubon Ratchathani', 1),
(3260, 209, 'Udon Thani', 'Udon Thani', 1),
(3261, 209, 'Uthai Thani', 'Uthai Thani', 1),
(3262, 209, 'Uttaradit', 'Uttaradit', 1),
(3263, 209, 'Yala', 'Yala', 1),
(3264, 209, 'Yasothon', 'Yasothon', 1),
(3265, 210, 'Kara', 'K', 1),
(3266, 210, 'Plateaux', 'P', 1),
(3267, 210, 'Savanes', 'S', 1),
(3268, 210, 'Centrale', 'C', 1),
(3269, 210, 'Maritime', 'M', 1),
(3270, 211, 'Atafu', 'A', 1),
(3271, 211, 'Fakaofo', 'F', 1),
(3272, 211, 'Nukunonu', 'N', 1),
(3273, 212, 'Ha''apai', 'H', 1),
(3274, 212, 'Tongatapu', 'T', 1),
(3275, 212, 'Vava''u', 'V', 1),
(3276, 213, 'Couva/Tabaquite/Talparo', 'CT', 1),
(3277, 213, 'Diego Martin', 'DM', 1),
(3278, 213, 'Mayaro/Rio Claro', 'MR', 1),
(3279, 213, 'Penal/Debe', 'PD', 1),
(3280, 213, 'Princes Town', 'PT', 1),
(3281, 213, 'Sangre Grande', 'SG', 1),
(3282, 213, 'San Juan/Laventille', 'SL', 1),
(3283, 213, 'Siparia', 'SI', 1),
(3284, 213, 'Tunapuna/Piarco', 'TP', 1),
(3285, 213, 'Port of Spain', 'PS', 1),
(3286, 213, 'San Fernando', 'SF', 1),
(3287, 213, 'Arima', 'AR', 1),
(3288, 213, 'Point Fortin', 'PF', 1),
(3289, 213, 'Chaguanas', 'CH', 1),
(3290, 213, 'Tobago', 'TO', 1),
(3291, 214, 'Ariana', 'AR', 1),
(3292, 214, 'Beja', 'BJ', 1),
(3293, 214, 'Ben Arous', 'BA', 1),
(3294, 214, 'Bizerte', 'BI', 1),
(3295, 214, 'Gabes', 'GB', 1),
(3296, 214, 'Gafsa', 'GF', 1),
(3297, 214, 'Jendouba', 'JE', 1),
(3298, 214, 'Kairouan', 'KR', 1),
(3299, 214, 'Kasserine', 'KS', 1),
(3300, 214, 'Kebili', 'KB', 1),
(3301, 214, 'Kef', 'KF', 1),
(3302, 214, 'Mahdia', 'MH', 1),
(3303, 214, 'Manouba', 'MN', 1),
(3304, 214, 'Medenine', 'ME', 1),
(3305, 214, 'Monastir', 'MO', 1),
(3306, 214, 'Nabeul', 'NA', 1),
(3307, 214, 'Sfax', 'SF', 1),
(3308, 214, 'Sidi', 'SD', 1),
(3309, 214, 'Siliana', 'SL', 1),
(3310, 214, 'Sousse', 'SO', 1),
(3311, 214, 'Tataouine', 'TA', 1),
(3312, 214, 'Tozeur', 'TO', 1),
(3313, 214, 'Tunis', 'TU', 1),
(3314, 214, 'Zaghouan', 'ZA', 1),
(3315, 215, 'Adana', 'ADA', 1),
(3316, 215, 'Adıyaman', 'ADI', 1),
(3317, 215, 'Afyonkarahisar', 'AFY', 1),
(3318, 215, 'Ağrı', 'AGR', 1),
(3319, 215, 'Aksaray', 'AKS', 1),
(3320, 215, 'Amasya', 'AMA', 1),
(3321, 215, 'Ankara', 'ANK', 1),
(3322, 215, 'Antalya', 'ANT', 1),
(3323, 215, 'Ardahan', 'ARD', 1),
(3324, 215, 'Artvin', 'ART', 1),
(3325, 215, 'Aydın', 'AYI', 1),
(3326, 215, 'Balıkesir', 'BAL', 1),
(3327, 215, 'Bartın', 'BAR', 1),
(3328, 215, 'Batman', 'BAT', 1),
(3329, 215, 'Bayburt', 'BAY', 1),
(3330, 215, 'Bilecik', 'BIL', 1),
(3331, 215, 'Bingöl', 'BIN', 1),
(3332, 215, 'Bitlis', 'BIT', 1),
(3333, 215, 'Bolu', 'BOL', 1),
(3334, 215, 'Burdur', 'BRD', 1),
(3335, 215, 'Bursa', 'BRS', 1),
(3336, 215, 'Çanakkale', 'CKL', 1),
(3337, 215, 'Çankırı', 'CKR', 1),
(3338, 215, 'Çorum', 'COR', 1),
(3339, 215, 'Denizli', 'DEN', 1),
(3340, 215, 'Diyarbakir', 'DIY', 1),
(3341, 215, 'Düzce', 'DUZ', 1),
(3342, 215, 'Edirne', 'EDI', 1),
(3343, 215, 'Elazig', 'ELA', 1),
(3344, 215, 'Erzincan', 'EZC', 1),
(3345, 215, 'Erzurum', 'EZR', 1),
(3346, 215, 'Eskişehir', 'ESK', 1),
(3347, 215, 'Gaziantep', 'GAZ', 1),
(3348, 215, 'Giresun', 'GIR', 1),
(3349, 215, 'Gümüşhane', 'GMS', 1),
(3350, 215, 'Hakkari', 'HKR', 1),
(3351, 215, 'Hatay', 'HTY', 1),
(3352, 215, 'Iğdır', 'IGD', 1),
(3353, 215, 'Isparta', 'ISP', 1),
(3354, 215, 'İstanbul', 'IST', 1),
(3355, 215, 'İzmir', 'IZM', 1),
(3356, 215, 'Kahramanmaraş', 'KAH', 1),
(3357, 215, 'Karabük', 'KRB', 1),
(3358, 215, 'Karaman', 'KRM', 1),
(3359, 215, 'Kars', 'KRS', 1),
(3360, 215, 'Kastamonu', 'KAS', 1),
(3361, 215, 'Kayseri', 'KAY', 1),
(3362, 215, 'Kilis', 'KLS', 1),
(3363, 215, 'Kirikkale', 'KRK', 1),
(3364, 215, 'Kirklareli', 'KLR', 1),
(3365, 215, 'Kirsehir', 'KRH', 1),
(3366, 215, 'Kocaeli', 'KOC', 1),
(3367, 215, 'Konya', 'KON', 1),
(3368, 215, 'Kütahya', 'KUT', 1),
(3369, 215, 'Malatya', 'MAL', 1),
(3370, 215, 'Manisa', 'MAN', 1),
(3371, 215, 'Mardin', 'MAR', 1),
(3372, 215, 'Mersin', 'MER', 1),
(3373, 215, 'Muğla', 'MUG', 1),
(3374, 215, 'Muş', 'MUS', 1),
(3375, 215, 'Nevşehir', 'NEV', 1),
(3376, 215, 'Niğde', 'NIG', 1),
(3377, 215, 'Ordu', 'ORD', 1),
(3378, 215, 'Osmaniye', 'OSM', 1),
(3379, 215, 'Rize', 'RIZ', 1),
(3380, 215, 'Sakarya', 'SAK', 1),
(3381, 215, 'Samsun', 'SAM', 1),
(3382, 215, 'Şanlıurfa', 'SAN', 1),
(3383, 215, 'Siirt', 'SII', 1),
(3384, 215, 'Sinop', 'SIN', 1),
(3385, 215, 'Şırnak', 'SIR', 1),
(3386, 215, 'Sivas', 'SIV', 1),
(3387, 215, 'Tekirdağ', 'TEL', 1),
(3388, 215, 'Tokat', 'TOK', 1),
(3389, 215, 'Trabzon', 'TRA', 1),
(3390, 215, 'Tunceli', 'TUN', 1),
(3391, 215, 'Uşak', 'USK', 1),
(3392, 215, 'Van', 'VAN', 1),
(3393, 215, 'Yalova', 'YAL', 1),
(3394, 215, 'Yozgat', 'YOZ', 1),
(3395, 215, 'Zonguldak', 'ZON', 1),
(3396, 216, 'Ahal Welayaty', 'A', 1),
(3397, 216, 'Balkan Welayaty', 'B', 1),
(3398, 216, 'Dashhowuz Welayaty', 'D', 1),
(3399, 216, 'Lebap Welayaty', 'L', 1),
(3400, 216, 'Mary Welayaty', 'M', 1),
(3401, 217, 'Ambergris Cays', 'AC', 1),
(3402, 217, 'Dellis Cay', 'DC', 1),
(3403, 217, 'French Cay', 'FC', 1),
(3404, 217, 'Little Water Cay', 'LW', 1),
(3405, 217, 'Parrot Cay', 'RC', 1),
(3406, 217, 'Pine Cay', 'PN', 1),
(3407, 217, 'Salt Cay', 'SL', 1),
(3408, 217, 'Grand Turk', 'GT', 1),
(3409, 217, 'South Caicos', 'SC', 1),
(3410, 217, 'East Caicos', 'EC', 1),
(3411, 217, 'Middle Caicos', 'MC', 1),
(3412, 217, 'North Caicos', 'NC', 1),
(3413, 217, 'Providenciales', 'PR', 1),
(3414, 217, 'West Caicos', 'WC', 1),
(3415, 218, 'Nanumanga', 'NMG', 1),
(3416, 218, 'Niulakita', 'NLK', 1),
(3417, 218, 'Niutao', 'NTO', 1),
(3418, 218, 'Funafuti', 'FUN', 1),
(3419, 218, 'Nanumea', 'NME', 1),
(3420, 218, 'Nui', 'NUI', 1),
(3421, 218, 'Nukufetau', 'NFT', 1),
(3422, 218, 'Nukulaelae', 'NLL', 1),
(3423, 218, 'Vaitupu', 'VAI', 1),
(3424, 219, 'Kalangala', 'KAL', 1),
(3425, 219, 'Kampala', 'KMP', 1),
(3426, 219, 'Kayunga', 'KAY', 1),
(3427, 219, 'Kiboga', 'KIB', 1),
(3428, 219, 'Luwero', 'LUW', 1),
(3429, 219, 'Masaka', 'MAS', 1),
(3430, 219, 'Mpigi', 'MPI', 1),
(3431, 219, 'Mubende', 'MUB', 1),
(3432, 219, 'Mukono', 'MUK', 1),
(3433, 219, 'Nakasongola', 'NKS', 1),
(3434, 219, 'Rakai', 'RAK', 1),
(3435, 219, 'Sembabule', 'SEM', 1),
(3436, 219, 'Wakiso', 'WAK', 1),
(3437, 219, 'Bugiri', 'BUG', 1),
(3438, 219, 'Busia', 'BUS', 1),
(3439, 219, 'Iganga', 'IGA', 1),
(3440, 219, 'Jinja', 'JIN', 1),
(3441, 219, 'Kaberamaido', 'KAB', 1),
(3442, 219, 'Kamuli', 'KML', 1),
(3443, 219, 'Kapchorwa', 'KPC', 1),
(3444, 219, 'Katakwi', 'KTK', 1),
(3445, 219, 'Kumi', 'KUM', 1),
(3446, 219, 'Mayuge', 'MAY', 1),
(3447, 219, 'Mbale', 'MBA', 1),
(3448, 219, 'Pallisa', 'PAL', 1),
(3449, 219, 'Sironko', 'SIR', 1),
(3450, 219, 'Soroti', 'SOR', 1),
(3451, 219, 'Tororo', 'TOR', 1),
(3452, 219, 'Adjumani', 'ADJ', 1),
(3453, 219, 'Apac', 'APC', 1),
(3454, 219, 'Arua', 'ARU', 1),
(3455, 219, 'Gulu', 'GUL', 1),
(3456, 219, 'Kitgum', 'KIT', 1),
(3457, 219, 'Kotido', 'KOT', 1),
(3458, 219, 'Lira', 'LIR', 1),
(3459, 219, 'Moroto', 'MRT', 1),
(3460, 219, 'Moyo', 'MOY', 1),
(3461, 219, 'Nakapiripirit', 'NAK', 1),
(3462, 219, 'Nebbi', 'NEB', 1),
(3463, 219, 'Pader', 'PAD', 1),
(3464, 219, 'Yumbe', 'YUM', 1),
(3465, 219, 'Bundibugyo', 'BUN', 1),
(3466, 219, 'Bushenyi', 'BSH', 1),
(3467, 219, 'Hoima', 'HOI', 1),
(3468, 219, 'Kabale', 'KBL', 1),
(3469, 219, 'Kabarole', 'KAR', 1),
(3470, 219, 'Kamwenge', 'KAM', 1),
(3471, 219, 'Kanungu', 'KAN', 1),
(3472, 219, 'Kasese', 'KAS', 1),
(3473, 219, 'Kibaale', 'KBA', 1),
(3474, 219, 'Kisoro', 'KIS', 1),
(3475, 219, 'Kyenjojo', 'KYE', 1),
(3476, 219, 'Masindi', 'MSN', 1),
(3477, 219, 'Mbarara', 'MBR', 1),
(3478, 219, 'Ntungamo', 'NTU', 1),
(3479, 219, 'Rukungiri', 'RUK', 1),
(3480, 220, 'Черкассы', 'CK', 1),
(3481, 220, 'Чернигов', 'CH', 1),
(3482, 220, 'Черновцы', 'CV', 1),
(3483, 220, 'Крым', 'CR', 1),
(3484, 220, 'Днепропетровск', 'DN', 1),
(3485, 220, 'Донецк', 'DO', 1),
(3486, 220, 'Ивано-Франковск', 'IV', 1),
(3487, 220, 'Харьков', 'KH', 1),
(3488, 220, 'Хмельницкий', 'KM', 1),
(3489, 220, 'Кировоград', 'KR', 1),
(3490, 220, 'Киевская область', 'KV', 1),
(3491, 220, 'Киев', 'KY', 1),
(3492, 220, 'Луганск', 'LU', 1),
(3493, 220, 'Львов', 'LV', 1),
(3494, 220, 'Николаев', 'MY', 1),
(3495, 220, 'Одесса', 'OD', 1),
(3496, 220, 'Полтава', 'PO', 1),
(3497, 220, 'Ровно', 'RI', 1),
(3498, 220, 'Севастополь', 'SE', 1),
(3499, 220, 'Сумы', 'SU', 1),
(3500, 220, 'Тернополь', 'TE', 1),
(3501, 220, 'Винница', 'VI', 1),
(3502, 220, 'Луцк', 'VO', 1),
(3503, 220, 'Ужгород', 'ZK', 1),
(3504, 220, 'Запорожье', 'ZA', 1),
(3505, 220, 'Житомир', 'ZH', 1),
(3506, 221, 'Abu Zaby', 'AZ', 1),
(3507, 221, '''Ajman', 'AJ', 1),
(3508, 221, 'Al Fujayrah', 'FU', 1),
(3509, 221, 'Ash Shariqah', 'SH', 1),
(3510, 221, 'Dubayy', 'DU', 1),
(3511, 221, 'R''as al Khaymah', 'RK', 1),
(3512, 221, 'Umm al Qaywayn', 'UQ', 1),
(3513, 222, 'Aberdeen', 'ABN', 1),
(3514, 222, 'Aberdeenshire', 'ABNS', 1),
(3515, 222, 'Anglesey', 'ANG', 1),
(3516, 222, 'Angus', 'AGS', 1),
(3517, 222, 'Argyll and Bute', 'ARY', 1),
(3518, 222, 'Bedfordshire', 'BEDS', 1),
(3519, 222, 'Berkshire', 'BERKS', 1),
(3520, 222, 'Blaenau Gwent', 'BLA', 1),
(3521, 222, 'Bridgend', 'BRI', 1),
(3522, 222, 'Bristol', 'BSTL', 1),
(3523, 222, 'Buckinghamshire', 'BUCKS', 1),
(3524, 222, 'Caerphilly', 'CAE', 1),
(3525, 222, 'Cambridgeshire', 'CAMBS', 1),
(3526, 222, 'Cardiff', 'CDF', 1),
(3527, 222, 'Carmarthenshire', 'CARM', 1),
(3528, 222, 'Ceredigion', 'CDGN', 1),
(3529, 222, 'Cheshire', 'CHES', 1),
(3530, 222, 'Clackmannanshire', 'CLACK', 1),
(3531, 222, 'Conwy', 'CON', 1),
(3532, 222, 'Cornwall', 'CORN', 1),
(3533, 222, 'Denbighshire', 'DNBG', 1),
(3534, 222, 'Derbyshire', 'DERBY', 1),
(3535, 222, 'Devon', 'DVN', 1),
(3536, 222, 'Dorset', 'DOR', 1),
(3537, 222, 'Dumfries and Galloway', 'DGL', 1),
(3538, 222, 'Dundee', 'DUND', 1),
(3539, 222, 'Durham', 'DHM', 1),
(3540, 222, 'East Ayrshire', 'ARYE', 1),
(3541, 222, 'East Dunbartonshire', 'DUNBE', 1),
(3542, 222, 'East Lothian', 'LOTE', 1),
(3543, 222, 'East Renfrewshire', 'RENE', 1),
(3544, 222, 'East Riding of Yorkshire', 'ERYS', 1),
(3545, 222, 'East Sussex', 'SXE', 1),
(3546, 222, 'Edinburgh', 'EDIN', 1),
(3547, 222, 'Essex', 'ESX', 1),
(3548, 222, 'Falkirk', 'FALK', 1),
(3549, 222, 'Fife', 'FFE', 1),
(3550, 222, 'Flintshire', 'FLINT', 1),
(3551, 222, 'Glasgow', 'GLAS', 1),
(3552, 222, 'Gloucestershire', 'GLOS', 1),
(3553, 222, 'Greater London', 'LDN', 1),
(3554, 222, 'Greater Manchester', 'MCH', 1),
(3555, 222, 'Gwynedd', 'GDD', 1),
(3556, 222, 'Hampshire', 'HANTS', 1),
(3557, 222, 'Herefordshire', 'HWR', 1),
(3558, 222, 'Hertfordshire', 'HERTS', 1),
(3559, 222, 'Highlands', 'HLD', 1),
(3560, 222, 'Inverclyde', 'IVER', 1),
(3561, 222, 'Isle of Wight', 'IOW', 1),
(3562, 222, 'Kent', 'KNT', 1),
(3563, 222, 'Lancashire', 'LANCS', 1),
(3564, 222, 'Leicestershire', 'LEICS', 1),
(3565, 222, 'Lincolnshire', 'LINCS', 1),
(3566, 222, 'Merseyside', 'MSY', 1),
(3567, 222, 'Merthyr Tydfil', 'MERT', 1),
(3568, 222, 'Midlothian', 'MLOT', 1),
(3569, 222, 'Monmouthshire', 'MMOUTH', 1),
(3570, 222, 'Moray', 'MORAY', 1),
(3571, 222, 'Neath Port Talbot', 'NPRTAL', 1),
(3572, 222, 'Newport', 'NEWPT', 1),
(3573, 222, 'Norfolk', 'NOR', 1),
(3574, 222, 'North Ayrshire', 'ARYN', 1),
(3575, 222, 'North Lanarkshire', 'LANN', 1),
(3576, 222, 'North Yorkshire', 'YSN', 1),
(3577, 222, 'Northamptonshire', 'NHM', 1),
(3578, 222, 'Northumberland', 'NLD', 1),
(3579, 222, 'Nottinghamshire', 'NOT', 1),
(3580, 222, 'Orkney Islands', 'ORK', 1),
(3581, 222, 'Oxfordshire', 'OFE', 1),
(3582, 222, 'Pembrokeshire', 'PEM', 1),
(3583, 222, 'Perth and Kinross', 'PERTH', 1),
(3584, 222, 'Powys', 'PWS', 1),
(3585, 222, 'Renfrewshire', 'REN', 1),
(3586, 222, 'Rhondda Cynon Taff', 'RHON', 1),
(3587, 222, 'Rutland', 'RUT', 1),
(3588, 222, 'Scottish Borders', 'BOR', 1),
(3589, 222, 'Shetland Islands', 'SHET', 1),
(3590, 222, 'Shropshire', 'SPE', 1),
(3591, 222, 'Somerset', 'SOM', 1),
(3592, 222, 'South Ayrshire', 'ARYS', 1),
(3593, 222, 'South Lanarkshire', 'LANS', 1),
(3594, 222, 'South Yorkshire', 'YSS', 1),
(3595, 222, 'Staffordshire', 'SFD', 1),
(3596, 222, 'Stirling', 'STIR', 1),
(3597, 222, 'Suffolk', 'SFK', 1),
(3598, 222, 'Surrey', 'SRY', 1),
(3599, 222, 'Swansea', 'SWAN', 1),
(3600, 222, 'Torfaen', 'TORF', 1),
(3601, 222, 'Tyne and Wear', 'TWR', 1),
(3602, 222, 'Vale of Glamorgan', 'VGLAM', 1),
(3603, 222, 'Warwickshire', 'WARKS', 1),
(3604, 222, 'West Dunbartonshire', 'WDUN', 1),
(3605, 222, 'West Lothian', 'WLOT', 1),
(3606, 222, 'West Midlands', 'WMD', 1),
(3607, 222, 'West Sussex', 'SXW', 1),
(3608, 222, 'West Yorkshire', 'YSW', 1),
(3609, 222, 'Western Isles', 'WIL', 1),
(3610, 222, 'Wiltshire', 'WLT', 1),
(3611, 222, 'Worcestershire', 'WORCS', 1),
(3612, 222, 'Wrexham', 'WRX', 1),
(3613, 223, 'Alabama', 'AL', 1),
(3614, 223, 'Alaska', 'AK', 1),
(3615, 223, 'American Samoa', 'AS', 1),
(3616, 223, 'Arizona', 'AZ', 1),
(3617, 223, 'Arkansas', 'AR', 1),
(3618, 223, 'Armed Forces Africa', 'AF', 1),
(3619, 223, 'Armed Forces Americas', 'AA', 1),
(3620, 223, 'Armed Forces Canada', 'AC', 1),
(3621, 223, 'Armed Forces Europe', 'AE', 1),
(3622, 223, 'Armed Forces Middle East', 'AM', 1),
(3623, 223, 'Armed Forces Pacific', 'AP', 1),
(3624, 223, 'California', 'CA', 1),
(3625, 223, 'Colorado', 'CO', 1),
(3626, 223, 'Connecticut', 'CT', 1),
(3627, 223, 'Delaware', 'DE', 1),
(3628, 223, 'District of Columbia', 'DC', 1),
(3629, 223, 'Federated States Of Micronesia', 'FM', 1),
(3630, 223, 'Florida', 'FL', 1),
(3631, 223, 'Georgia', 'GA', 1),
(3632, 223, 'Guam', 'GU', 1),
(3633, 223, 'Hawaii', 'HI', 1),
(3634, 223, 'Idaho', 'ID', 1),
(3635, 223, 'Illinois', 'IL', 1),
(3636, 223, 'Indiana', 'IN', 1),
(3637, 223, 'Iowa', 'IA', 1),
(3638, 223, 'Kansas', 'KS', 1),
(3639, 223, 'Kentucky', 'KY', 1),
(3640, 223, 'Louisiana', 'LA', 1),
(3641, 223, 'Maine', 'ME', 1),
(3642, 223, 'Marshall Islands', 'MH', 1),
(3643, 223, 'Maryland', 'MD', 1),
(3644, 223, 'Massachusetts', 'MA', 1),
(3645, 223, 'Michigan', 'MI', 1),
(3646, 223, 'Minnesota', 'MN', 1),
(3647, 223, 'Mississippi', 'MS', 1),
(3648, 223, 'Missouri', 'MO', 1),
(3649, 223, 'Montana', 'MT', 1),
(3650, 223, 'Nebraska', 'NE', 1),
(3651, 223, 'Nevada', 'NV', 1),
(3652, 223, 'New Hampshire', 'NH', 1),
(3653, 223, 'New Jersey', 'NJ', 1),
(3654, 223, 'New Mexico', 'NM', 1),
(3655, 223, 'New York', 'NY', 1),
(3656, 223, 'North Carolina', 'NC', 1),
(3657, 223, 'North Dakota', 'ND', 1),
(3658, 223, 'Northern Mariana Islands', 'MP', 1),
(3659, 223, 'Ohio', 'OH', 1),
(3660, 223, 'Oklahoma', 'OK', 1),
(3661, 223, 'Oregon', 'OR', 1),
(3662, 223, 'Palau', 'PW', 1),
(3663, 223, 'Pennsylvania', 'PA', 1),
(3664, 223, 'Puerto Rico', 'PR', 1),
(3665, 223, 'Rhode Island', 'RI', 1),
(3666, 223, 'South Carolina', 'SC', 1),
(3667, 223, 'South Dakota', 'SD', 1),
(3668, 223, 'Tennessee', 'TN', 1),
(3669, 223, 'Texas', 'TX', 1),
(3670, 223, 'Utah', 'UT', 1),
(3671, 223, 'Vermont', 'VT', 1),
(3672, 223, 'Virgin Islands', 'VI', 1),
(3673, 223, 'Virginia', 'VA', 1),
(3674, 223, 'Washington', 'WA', 1),
(3675, 223, 'West Virginia', 'WV', 1),
(3676, 223, 'Wisconsin', 'WI', 1),
(3677, 223, 'Wyoming', 'WY', 1),
(3678, 224, 'Baker Island', 'BI', 1),
(3679, 224, 'Howland Island', 'HI', 1),
(3680, 224, 'Jarvis Island', 'JI', 1),
(3681, 224, 'Johnston Atoll', 'JA', 1),
(3682, 224, 'Kingman Reef', 'KR', 1),
(3683, 224, 'Midway Atoll', 'MA', 1),
(3684, 224, 'Navassa Island', 'NI', 1),
(3685, 224, 'Palmyra Atoll', 'PA', 1),
(3686, 224, 'Wake Island', 'WI', 1),
(3687, 225, 'Artigas', 'AR', 1),
(3688, 225, 'Canelones', 'CA', 1),
(3689, 225, 'Cerro Largo', 'CL', 1),
(3690, 225, 'Colonia', 'CO', 1),
(3691, 225, 'Durazno', 'DU', 1),
(3692, 225, 'Flores', 'FS', 1),
(3693, 225, 'Florida', 'FA', 1),
(3694, 225, 'Lavalleja', 'LA', 1),
(3695, 225, 'Maldonado', 'MA', 1),
(3696, 225, 'Montevideo', 'MO', 1),
(3697, 225, 'Paysandu', 'PA', 1),
(3698, 225, 'Rio Negro', 'RN', 1),
(3699, 225, 'Rivera', 'RV', 1),
(3700, 225, 'Rocha', 'RO', 1),
(3701, 225, 'Salto', 'SL', 1),
(3702, 225, 'San Jose', 'SJ', 1),
(3703, 225, 'Soriano', 'SO', 1),
(3704, 225, 'Tacuarembo', 'TA', 1),
(3705, 225, 'Treinta y Tres', 'TT', 1),
(3706, 226, 'Andijon', 'AN', 1),
(3707, 226, 'Buxoro', 'BU', 1),
(3708, 226, 'Farg''ona', 'FA', 1),
(3709, 226, 'Jizzax', 'JI', 1),
(3710, 226, 'Namangan', 'NG', 1),
(3711, 226, 'Navoiy', 'NW', 1),
(3712, 226, 'Qashqadaryo', 'QA', 1),
(3713, 226, 'Qoraqalpog''iston Republikasi', 'QR', 1),
(3714, 226, 'Samarqand', 'SA', 1),
(3715, 226, 'Sirdaryo', 'SI', 1),
(3716, 226, 'Surxondaryo', 'SU', 1),
(3717, 226, 'Toshkent City', 'TK', 1),
(3718, 226, 'Toshkent Region', 'TO', 1),
(3719, 226, 'Xorazm', 'XO', 1),
(3720, 227, 'Malampa', 'MA', 1),
(3721, 227, 'Penama', 'PE', 1),
(3722, 227, 'Sanma', 'SA', 1),
(3723, 227, 'Shefa', 'SH', 1),
(3724, 227, 'Tafea', 'TA', 1),
(3725, 227, 'Torba', 'TO', 1),
(3726, 229, 'Amazonas', 'AM', 1),
(3727, 229, 'Anzoategui', 'AN', 1),
(3728, 229, 'Apure', 'AP', 1),
(3729, 229, 'Aragua', 'AR', 1),
(3730, 229, 'Barinas', 'BA', 1),
(3731, 229, 'Bolivar', 'BO', 1),
(3732, 229, 'Carabobo', 'CA', 1),
(3733, 229, 'Cojedes', 'CO', 1),
(3734, 229, 'Delta Amacuro', 'DA', 1),
(3735, 229, 'Dependencias Federales', 'DF', 1),
(3736, 229, 'Distrito Federal', 'DI', 1),
(3737, 229, 'Falcon', 'FA', 1),
(3738, 229, 'Guarico', 'GU', 1),
(3739, 229, 'Lara', 'LA', 1),
(3740, 229, 'Merida', 'ME', 1),
(3741, 229, 'Miranda', 'MI', 1),
(3742, 229, 'Monagas', 'MO', 1),
(3743, 229, 'Nueva Esparta', 'NE', 1),
(3744, 229, 'Portuguesa', 'PO', 1),
(3745, 229, 'Sucre', 'SU', 1),
(3746, 229, 'Tachira', 'TA', 1),
(3747, 229, 'Trujillo', 'TR', 1),
(3748, 229, 'Vargas', 'VA', 1),
(3749, 229, 'Yaracuy', 'YA', 1),
(3750, 229, 'Zulia', 'ZU', 1),
(3751, 230, 'An Giang', 'AG', 1),
(3752, 230, 'Bac Giang', 'BG', 1),
(3753, 230, 'Bac Kan', 'BK', 1),
(3754, 230, 'Bac Lieu', 'BL', 1),
(3755, 230, 'Bac Ninh', 'BC', 1),
(3756, 230, 'Ba Ria-Vung Tau', 'BR', 1),
(3757, 230, 'Ben Tre', 'BN', 1),
(3758, 230, 'Binh Dinh', 'BH', 1),
(3759, 230, 'Binh Duong', 'BU', 1),
(3760, 230, 'Binh Phuoc', 'BP', 1),
(3761, 230, 'Binh Thuan', 'BT', 1),
(3762, 230, 'Ca Mau', 'CM', 1),
(3763, 230, 'Can Tho', 'CT', 1),
(3764, 230, 'Cao Bang', 'CB', 1),
(3765, 230, 'Dak Lak', 'DL', 1),
(3766, 230, 'Dak Nong', 'DG', 1),
(3767, 230, 'Da Nang', 'DN', 1),
(3768, 230, 'Dien Bien', 'DB', 1),
(3769, 230, 'Dong Nai', 'DI', 1),
(3770, 230, 'Dong Thap', 'DT', 1),
(3771, 230, 'Gia Lai', 'GL', 1),
(3772, 230, 'Ha Giang', 'HG', 1),
(3773, 230, 'Hai Duong', 'HD', 1),
(3774, 230, 'Hai Phong', 'HP', 1),
(3775, 230, 'Ha Nam', 'HM', 1),
(3776, 230, 'Ha Noi', 'HI', 1),
(3777, 230, 'Ha Tay', 'HT', 1),
(3778, 230, 'Ha Tinh', 'HH', 1),
(3779, 230, 'Hoa Binh', 'HB', 1),
(3780, 230, 'Ho Chi Minh City', 'HC', 1),
(3781, 230, 'Hau Giang', 'HU', 1),
(3782, 230, 'Hung Yen', 'HY', 1),
(3783, 232, 'Saint Croix', 'C', 1),
(3784, 232, 'Saint John', 'J', 1),
(3785, 232, 'Saint Thomas', 'T', 1),
(3786, 233, 'Alo', 'A', 1),
(3787, 233, 'Sigave', 'S', 1),
(3788, 233, 'Wallis', 'W', 1),
(3789, 235, 'Abyan', 'AB', 1),
(3790, 235, 'Adan', 'AD', 1),
(3791, 235, 'Amran', 'AM', 1),
(3792, 235, 'Al Bayda', 'BA', 1),
(3793, 235, 'Ad Dali', 'DA', 1),
(3794, 235, 'Dhamar', 'DH', 1),
(3795, 235, 'Hadramawt', 'HD', 1),
(3796, 235, 'Hajjah', 'HJ', 1),
(3797, 235, 'Al Hudaydah', 'HU', 1),
(3798, 235, 'Ibb', 'IB', 1),
(3799, 235, 'Al Jawf', 'JA', 1),
(3800, 235, 'Lahij', 'LA', 1),
(3801, 235, 'Ma''rib', 'MA', 1),
(3802, 235, 'Al Mahrah', 'MR', 1),
(3803, 235, 'Al Mahwit', 'MW', 1),
(3804, 235, 'Sa''dah', 'SD', 1),
(3805, 235, 'San''a', 'SN', 1),
(3806, 235, 'Shabwah', 'SH', 1),
(3807, 235, 'Ta''izz', 'TA', 1),
(3808, 236, 'Kosovo', 'KOS', 1),
(3809, 236, 'Montenegro', 'MON', 1),
(3810, 236, 'Serbia', 'SER', 1),
(3811, 236, 'Vojvodina', 'VOJ', 1),
(3812, 237, 'Bas-Congo', 'BC', 1),
(3813, 237, 'Bandundu', 'BN', 1),
(3814, 237, 'Equateur', 'EQ', 1),
(3815, 237, 'Katanga', 'KA', 1),
(3816, 237, 'Kasai-Oriental', 'KE', 1),
(3817, 237, 'Kinshasa', 'KN', 1),
(3818, 237, 'Kasai-Occidental', 'KW', 1),
(3819, 237, 'Maniema', 'MA', 1),
(3820, 237, 'Nord-Kivu', 'NK', 1),
(3821, 237, 'Orientale', 'OR', 1),
(3822, 237, 'Sud-Kivu', 'SK', 1),
(3823, 238, 'Central', 'CE', 1),
(3824, 238, 'Copperbelt', 'CB', 1),
(3825, 238, 'Eastern', 'EA', 1),
(3826, 238, 'Luapula', 'LP', 1),
(3827, 238, 'Lusaka', 'LK', 1),
(3828, 238, 'Northern', 'NO', 1),
(3829, 238, 'North-Western', 'NW', 1),
(3830, 238, 'Southern', 'SO', 1),
(3831, 238, 'Western', 'WE', 1),
(3832, 239, 'Bulawayo', 'BU', 1),
(3833, 239, 'Harare', 'HA', 1),
(3834, 239, 'Manicaland', 'ML', 1),
(3835, 239, 'Mashonaland Central', 'MC', 1),
(3836, 239, 'Mashonaland East', 'ME', 1),
(3837, 239, 'Mashonaland West', 'MW', 1),
(3838, 239, 'Masvingo', 'MV', 1),
(3839, 239, 'Matabeleland North', 'MN', 1),
(3840, 239, 'Matabeleland South', 'MS', 1),
(3841, 239, 'Midlands', 'MD', 1),
(3861, 105, 'Campobasso', 'CB', 1),
(3862, 105, 'Carbonia-Iglesias', 'CI', 1),
(3863, 105, 'Caserta', 'CE', 1),
(3864, 105, 'Catania', 'CT', 1),
(3865, 105, 'Catanzaro', 'CZ', 1),
(3866, 105, 'Chieti', 'CH', 1),
(3867, 105, 'Como', 'CO', 1),
(3868, 105, 'Cosenza', 'CS', 1),
(3869, 105, 'Cremona', 'CR', 1),
(3870, 105, 'Crotone', 'KR', 1),
(3871, 105, 'Cuneo', 'CN', 1),
(3872, 105, 'Enna', 'EN', 1),
(3873, 105, 'Ferrara', 'FE', 1),
(3874, 105, 'Firenze', 'FI', 1),
(3875, 105, 'Foggia', 'FG', 1),
(3876, 105, 'Forli-Cesena', 'FC', 1),
(3877, 105, 'Frosinone', 'FR', 1),
(3878, 105, 'Genova', 'GE', 1),
(3879, 105, 'Gorizia', 'GO', 1),
(3880, 105, 'Grosseto', 'GR', 1),
(3881, 105, 'Imperia', 'IM', 1),
(3882, 105, 'Isernia', 'IS', 1),
(3883, 105, 'L&#39;Aquila', 'AQ', 1),
(3884, 105, 'La Spezia', 'SP', 1),
(3885, 105, 'Latina', 'LT', 1),
(3886, 105, 'Lecce', 'LE', 1),
(3887, 105, 'Lecco', 'LC', 1),
(3888, 105, 'Livorno', 'LI', 1),
(3889, 105, 'Lodi', 'LO', 1),
(3890, 105, 'Lucca', 'LU', 1),
(3891, 105, 'Macerata', 'MC', 1),
(3892, 105, 'Mantova', 'MN', 1),
(3893, 105, 'Massa-Carrara', 'MS', 1),
(3894, 105, 'Matera', 'MT', 1),
(3895, 105, 'Medio Campidano', 'VS', 1),
(3896, 105, 'Messina', 'ME', 1),
(3897, 105, 'Milano', 'MI', 1),
(3898, 105, 'Modena', 'MO', 1),
(3899, 105, 'Napoli', 'NA', 1),
(3900, 105, 'Novara', 'NO', 1),
(3901, 105, 'Nuoro', 'NU', 1),
(3902, 105, 'Ogliastra', 'OG', 1),
(3903, 105, 'Olbia-Tempio', 'OT', 1),
(3904, 105, 'Oristano', 'OR', 1),
(3905, 105, 'Padova', 'PD', 1),
(3906, 105, 'Palermo', 'PA', 1),
(3907, 105, 'Parma', 'PR', 1),
(3908, 105, 'Pavia', 'PV', 1),
(3909, 105, 'Perugia', 'PG', 1),
(3910, 105, 'Pesaro e Urbino', 'PU', 1),
(3911, 105, 'Pescara', 'PE', 1),
(3912, 105, 'Piacenza', 'PC', 1),
(3913, 105, 'Pisa', 'PI', 1),
(3914, 105, 'Pistoia', 'PT', 1),
(3915, 105, 'Pordenone', 'PN', 1),
(3916, 105, 'Potenza', 'PZ', 1),
(3917, 105, 'Prato', 'PO', 1),
(3918, 105, 'Ragusa', 'RG', 1),
(3919, 105, 'Ravenna', 'RA', 1),
(3920, 105, 'Reggio Calabria', 'RC', 1),
(3921, 105, 'Reggio Emilia', 'RE', 1),
(3922, 105, 'Rieti', 'RI', 1),
(3923, 105, 'Rimini', 'RN', 1),
(3924, 105, 'Roma', 'RM', 1),
(3925, 105, 'Rovigo', 'RO', 1),
(3926, 105, 'Salerno', 'SA', 1),
(3927, 105, 'Sassari', 'SS', 1),
(3928, 105, 'Savona', 'SV', 1),
(3929, 105, 'Siena', 'SI', 1),
(3930, 105, 'Siracusa', 'SR', 1),
(3931, 105, 'Sondrio', 'SO', 1),
(3932, 105, 'Taranto', 'TA', 1),
(3933, 105, 'Teramo', 'TE', 1),
(3934, 105, 'Terni', 'TR', 1),
(3935, 105, 'Torino', 'TO', 1),
(3936, 105, 'Trapani', 'TP', 1),
(3937, 105, 'Trento', 'TN', 1),
(3938, 105, 'Treviso', 'TV', 1),
(3939, 105, 'Trieste', 'TS', 1),
(3940, 105, 'Udine', 'UD', 1),
(3941, 105, 'Varese', 'VA', 1),
(3942, 105, 'Venezia', 'VE', 1),
(3943, 105, 'Verbano-Cusio-Ossola', 'VB', 1),
(3944, 105, 'Vercelli', 'VC', 1),
(3945, 105, 'Verona', 'VR', 1),
(3946, 105, 'Vibo Valentia', 'VV', 1),
(3947, 105, 'Vicenza', 'VI', 1),
(3948, 105, 'Viterbo', 'VT', 1),
(3949, 222, 'County Antrim', 'ANT', 1),
(3950, 222, 'County Armagh', 'ARM', 1),
(3951, 222, 'County Down', 'DOW', 1),
(3952, 222, 'County Fermanagh', 'FER', 1),
(3953, 222, 'County Londonderry', 'LDY', 1),
(3954, 222, 'County Tyrone', 'TYR', 1),
(3955, 222, 'Cumbria', 'CMA', 1),
(3956, 190, 'Pomurska', '1', 1),
(3957, 190, 'Podravska', '2', 1),
(3958, 190, 'Koroška', '3', 1),
(3959, 190, 'Savinjska', '4', 1),
(3960, 190, 'Zasavska', '5', 1),
(3961, 190, 'Spodnjeposavska', '6', 1),
(3962, 190, 'Jugovzhodna Slovenija', '7', 1),
(3963, 190, 'Osrednjeslovenska', '8', 1),
(3964, 190, 'Gorenjska', '9', 1),
(3965, 190, 'Notranjsko-kraška', '10', 1),
(3966, 190, 'Goriška', '11', 1),
(3967, 190, 'Obalno-kraška', '12', 1),
(3968, 33, 'Ruse', '', 1),
(3969, 101, 'Alborz', 'ALB', 1),
(3970, 220, 'Херсон', 'KE', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `zone_to_geo_zone`
--

CREATE TABLE IF NOT EXISTS `zone_to_geo_zone` (
  `zone_to_geo_zone_id` int(11) NOT NULL,
  `country_id` int(11) NOT NULL,
  `zone_id` int(11) NOT NULL DEFAULT '0',
  `geo_zone_id` int(11) NOT NULL,
  `date_added` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `date_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM AUTO_INCREMENT=58 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `zone_to_geo_zone`
--

INSERT INTO `zone_to_geo_zone` (`zone_to_geo_zone_id`, `country_id`, `zone_id`, `geo_zone_id`, `date_added`, `date_modified`) VALUES
(57, 176, 0, 3, '2010-02-26 22:33:24', '0000-00-00 00:00:00');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`address_id`), ADD KEY `customer_id` (`customer_id`);

--
-- Индексы таблицы `affiliate`
--
ALTER TABLE `affiliate`
  ADD PRIMARY KEY (`affiliate_id`);

--
-- Индексы таблицы `affiliate_transaction`
--
ALTER TABLE `affiliate_transaction`
  ADD PRIMARY KEY (`affiliate_transaction_id`);

--
-- Индексы таблицы `attribute`
--
ALTER TABLE `attribute`
  ADD PRIMARY KEY (`attribute_id`);

--
-- Индексы таблицы `attribute_description`
--
ALTER TABLE `attribute_description`
  ADD PRIMARY KEY (`attribute_id`,`language_id`);

--
-- Индексы таблицы `attribute_group`
--
ALTER TABLE `attribute_group`
  ADD PRIMARY KEY (`attribute_group_id`);

--
-- Индексы таблицы `attribute_group_description`
--
ALTER TABLE `attribute_group_description`
  ADD PRIMARY KEY (`attribute_group_id`,`language_id`);

--
-- Индексы таблицы `banner`
--
ALTER TABLE `banner`
  ADD PRIMARY KEY (`banner_id`);

--
-- Индексы таблицы `banner_image`
--
ALTER TABLE `banner_image`
  ADD PRIMARY KEY (`banner_image_id`);

--
-- Индексы таблицы `banner_image_description`
--
ALTER TABLE `banner_image_description`
  ADD PRIMARY KEY (`banner_image_id`,`language_id`);

--
-- Индексы таблицы `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`category_id`);

--
-- Индексы таблицы `category_description`
--
ALTER TABLE `category_description`
  ADD PRIMARY KEY (`category_id`,`language_id`), ADD KEY `name` (`name`);

--
-- Индексы таблицы `category_to_layout`
--
ALTER TABLE `category_to_layout`
  ADD PRIMARY KEY (`category_id`,`store_id`);

--
-- Индексы таблицы `category_to_store`
--
ALTER TABLE `category_to_store`
  ADD PRIMARY KEY (`category_id`,`store_id`);

--
-- Индексы таблицы `country`
--
ALTER TABLE `country`
  ADD PRIMARY KEY (`country_id`);

--
-- Индексы таблицы `coupon`
--
ALTER TABLE `coupon`
  ADD PRIMARY KEY (`coupon_id`);

--
-- Индексы таблицы `coupon_history`
--
ALTER TABLE `coupon_history`
  ADD PRIMARY KEY (`coupon_history_id`);

--
-- Индексы таблицы `coupon_product`
--
ALTER TABLE `coupon_product`
  ADD PRIMARY KEY (`coupon_product_id`);

--
-- Индексы таблицы `currency`
--
ALTER TABLE `currency`
  ADD PRIMARY KEY (`currency_id`);

--
-- Индексы таблицы `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`customer_id`);

--
-- Индексы таблицы `customer_group`
--
ALTER TABLE `customer_group`
  ADD PRIMARY KEY (`customer_group_id`);

--
-- Индексы таблицы `customer_group_description`
--
ALTER TABLE `customer_group_description`
  ADD PRIMARY KEY (`customer_group_id`,`language_id`);

--
-- Индексы таблицы `customer_ip`
--
ALTER TABLE `customer_ip`
  ADD PRIMARY KEY (`customer_ip_id`), ADD KEY `ip` (`ip`);

--
-- Индексы таблицы `customer_ip_blacklist`
--
ALTER TABLE `customer_ip_blacklist`
  ADD PRIMARY KEY (`customer_ip_blacklist_id`), ADD KEY `ip` (`ip`);

--
-- Индексы таблицы `customer_online`
--
ALTER TABLE `customer_online`
  ADD PRIMARY KEY (`ip`);

--
-- Индексы таблицы `customer_reward`
--
ALTER TABLE `customer_reward`
  ADD PRIMARY KEY (`customer_reward_id`);

--
-- Индексы таблицы `customer_transaction`
--
ALTER TABLE `customer_transaction`
  ADD PRIMARY KEY (`customer_transaction_id`);

--
-- Индексы таблицы `download`
--
ALTER TABLE `download`
  ADD PRIMARY KEY (`download_id`);

--
-- Индексы таблицы `download_description`
--
ALTER TABLE `download_description`
  ADD PRIMARY KEY (`download_id`,`language_id`);

--
-- Индексы таблицы `extension`
--
ALTER TABLE `extension`
  ADD PRIMARY KEY (`extension_id`);

--
-- Индексы таблицы `geo_zone`
--
ALTER TABLE `geo_zone`
  ADD PRIMARY KEY (`geo_zone_id`);

--
-- Индексы таблицы `information`
--
ALTER TABLE `information`
  ADD PRIMARY KEY (`information_id`);

--
-- Индексы таблицы `information_description`
--
ALTER TABLE `information_description`
  ADD PRIMARY KEY (`information_id`,`language_id`);

--
-- Индексы таблицы `information_to_layout`
--
ALTER TABLE `information_to_layout`
  ADD PRIMARY KEY (`information_id`,`store_id`);

--
-- Индексы таблицы `information_to_store`
--
ALTER TABLE `information_to_store`
  ADD PRIMARY KEY (`information_id`,`store_id`);

--
-- Индексы таблицы `language`
--
ALTER TABLE `language`
  ADD PRIMARY KEY (`language_id`), ADD KEY `name` (`name`);

--
-- Индексы таблицы `layout`
--
ALTER TABLE `layout`
  ADD PRIMARY KEY (`layout_id`);

--
-- Индексы таблицы `layout_route`
--
ALTER TABLE `layout_route`
  ADD PRIMARY KEY (`layout_route_id`);

--
-- Индексы таблицы `length_class`
--
ALTER TABLE `length_class`
  ADD PRIMARY KEY (`length_class_id`);

--
-- Индексы таблицы `length_class_description`
--
ALTER TABLE `length_class_description`
  ADD PRIMARY KEY (`length_class_id`,`language_id`);

--
-- Индексы таблицы `manufacturer`
--
ALTER TABLE `manufacturer`
  ADD PRIMARY KEY (`manufacturer_id`);

--
-- Индексы таблицы `manufacturer_description`
--
ALTER TABLE `manufacturer_description`
  ADD PRIMARY KEY (`manufacturer_id`,`language_id`);

--
-- Индексы таблицы `manufacturer_to_store`
--
ALTER TABLE `manufacturer_to_store`
  ADD PRIMARY KEY (`manufacturer_id`,`store_id`);

--
-- Индексы таблицы `option`
--
ALTER TABLE `option`
  ADD PRIMARY KEY (`option_id`);

--
-- Индексы таблицы `option_description`
--
ALTER TABLE `option_description`
  ADD PRIMARY KEY (`option_id`,`language_id`);

--
-- Индексы таблицы `option_value`
--
ALTER TABLE `option_value`
  ADD PRIMARY KEY (`option_value_id`);

--
-- Индексы таблицы `option_value_description`
--
ALTER TABLE `option_value_description`
  ADD PRIMARY KEY (`option_value_id`,`language_id`);

--
-- Индексы таблицы `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`order_id`);

--
-- Индексы таблицы `order_download`
--
ALTER TABLE `order_download`
  ADD PRIMARY KEY (`order_download_id`);

--
-- Индексы таблицы `order_fraud`
--
ALTER TABLE `order_fraud`
  ADD PRIMARY KEY (`order_id`);

--
-- Индексы таблицы `order_history`
--
ALTER TABLE `order_history`
  ADD PRIMARY KEY (`order_history_id`);

--
-- Индексы таблицы `order_option`
--
ALTER TABLE `order_option`
  ADD PRIMARY KEY (`order_option_id`);

--
-- Индексы таблицы `order_product`
--
ALTER TABLE `order_product`
  ADD PRIMARY KEY (`order_product_id`);

--
-- Индексы таблицы `order_status`
--
ALTER TABLE `order_status`
  ADD PRIMARY KEY (`order_status_id`,`language_id`);

--
-- Индексы таблицы `order_total`
--
ALTER TABLE `order_total`
  ADD PRIMARY KEY (`order_total_id`), ADD KEY `idx_orders_total_orders_id` (`order_id`);

--
-- Индексы таблицы `order_voucher`
--
ALTER TABLE `order_voucher`
  ADD PRIMARY KEY (`order_voucher_id`);

--
-- Индексы таблицы `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_id`);

--
-- Индексы таблицы `product_attribute`
--
ALTER TABLE `product_attribute`
  ADD PRIMARY KEY (`product_id`,`attribute_id`,`language_id`);

--
-- Индексы таблицы `product_description`
--
ALTER TABLE `product_description`
  ADD PRIMARY KEY (`product_id`,`language_id`), ADD KEY `name` (`name`), ADD FULLTEXT KEY `description` (`description`), ADD FULLTEXT KEY `tag` (`tag`);

--
-- Индексы таблицы `product_discount`
--
ALTER TABLE `product_discount`
  ADD PRIMARY KEY (`product_discount_id`), ADD KEY `product_id` (`product_id`);

--
-- Индексы таблицы `product_image`
--
ALTER TABLE `product_image`
  ADD PRIMARY KEY (`product_image_id`);

--
-- Индексы таблицы `product_option`
--
ALTER TABLE `product_option`
  ADD PRIMARY KEY (`product_option_id`);

--
-- Индексы таблицы `product_option_value`
--
ALTER TABLE `product_option_value`
  ADD PRIMARY KEY (`product_option_value_id`);

--
-- Индексы таблицы `product_related`
--
ALTER TABLE `product_related`
  ADD PRIMARY KEY (`product_id`,`related_id`);

--
-- Индексы таблицы `product_reward`
--
ALTER TABLE `product_reward`
  ADD PRIMARY KEY (`product_reward_id`);

--
-- Индексы таблицы `product_special`
--
ALTER TABLE `product_special`
  ADD PRIMARY KEY (`product_special_id`), ADD KEY `product_id` (`product_id`);

--
-- Индексы таблицы `product_to_category`
--
ALTER TABLE `product_to_category`
  ADD PRIMARY KEY (`product_id`,`category_id`);

--
-- Индексы таблицы `product_to_download`
--
ALTER TABLE `product_to_download`
  ADD PRIMARY KEY (`product_id`,`download_id`);

--
-- Индексы таблицы `product_to_layout`
--
ALTER TABLE `product_to_layout`
  ADD PRIMARY KEY (`product_id`,`store_id`);

--
-- Индексы таблицы `product_to_store`
--
ALTER TABLE `product_to_store`
  ADD PRIMARY KEY (`product_id`,`store_id`);

--
-- Индексы таблицы `return`
--
ALTER TABLE `return`
  ADD PRIMARY KEY (`return_id`);

--
-- Индексы таблицы `return_action`
--
ALTER TABLE `return_action`
  ADD PRIMARY KEY (`return_action_id`,`language_id`);

--
-- Индексы таблицы `return_history`
--
ALTER TABLE `return_history`
  ADD PRIMARY KEY (`return_history_id`);

--
-- Индексы таблицы `return_reason`
--
ALTER TABLE `return_reason`
  ADD PRIMARY KEY (`return_reason_id`,`language_id`);

--
-- Индексы таблицы `return_status`
--
ALTER TABLE `return_status`
  ADD PRIMARY KEY (`return_status_id`,`language_id`);

--
-- Индексы таблицы `review`
--
ALTER TABLE `review`
  ADD PRIMARY KEY (`review_id`), ADD KEY `product_id` (`product_id`);

--
-- Индексы таблицы `setting`
--
ALTER TABLE `setting`
  ADD PRIMARY KEY (`setting_id`);

--
-- Индексы таблицы `stock_status`
--
ALTER TABLE `stock_status`
  ADD PRIMARY KEY (`stock_status_id`,`language_id`);

--
-- Индексы таблицы `store`
--
ALTER TABLE `store`
  ADD PRIMARY KEY (`store_id`);

--
-- Индексы таблицы `tax_class`
--
ALTER TABLE `tax_class`
  ADD PRIMARY KEY (`tax_class_id`);

--
-- Индексы таблицы `tax_rate`
--
ALTER TABLE `tax_rate`
  ADD PRIMARY KEY (`tax_rate_id`);

--
-- Индексы таблицы `tax_rate_to_customer_group`
--
ALTER TABLE `tax_rate_to_customer_group`
  ADD PRIMARY KEY (`tax_rate_id`,`customer_group_id`);

--
-- Индексы таблицы `tax_rule`
--
ALTER TABLE `tax_rule`
  ADD PRIMARY KEY (`tax_rule_id`);

--
-- Индексы таблицы `url_alias`
--
ALTER TABLE `url_alias`
  ADD PRIMARY KEY (`url_alias_id`);

--
-- Индексы таблицы `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- Индексы таблицы `user_group`
--
ALTER TABLE `user_group`
  ADD PRIMARY KEY (`user_group_id`);

--
-- Индексы таблицы `voucher`
--
ALTER TABLE `voucher`
  ADD PRIMARY KEY (`voucher_id`);

--
-- Индексы таблицы `voucher_history`
--
ALTER TABLE `voucher_history`
  ADD PRIMARY KEY (`voucher_history_id`);

--
-- Индексы таблицы `voucher_theme`
--
ALTER TABLE `voucher_theme`
  ADD PRIMARY KEY (`voucher_theme_id`);

--
-- Индексы таблицы `voucher_theme_description`
--
ALTER TABLE `voucher_theme_description`
  ADD PRIMARY KEY (`voucher_theme_id`,`language_id`);

--
-- Индексы таблицы `weight_class`
--
ALTER TABLE `weight_class`
  ADD PRIMARY KEY (`weight_class_id`);

--
-- Индексы таблицы `weight_class_description`
--
ALTER TABLE `weight_class_description`
  ADD PRIMARY KEY (`weight_class_id`,`language_id`);

--
-- Индексы таблицы `zone`
--
ALTER TABLE `zone`
  ADD PRIMARY KEY (`zone_id`);

--
-- Индексы таблицы `zone_to_geo_zone`
--
ALTER TABLE `zone_to_geo_zone`
  ADD PRIMARY KEY (`zone_to_geo_zone_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `address`
--
ALTER TABLE `address`
  MODIFY `address_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `affiliate`
--
ALTER TABLE `affiliate`
  MODIFY `affiliate_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `affiliate_transaction`
--
ALTER TABLE `affiliate_transaction`
  MODIFY `affiliate_transaction_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `attribute`
--
ALTER TABLE `attribute`
  MODIFY `attribute_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT для таблицы `attribute_group`
--
ALTER TABLE `attribute_group`
  MODIFY `attribute_group_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT для таблицы `banner`
--
ALTER TABLE `banner`
  MODIFY `banner_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT для таблицы `banner_image`
--
ALTER TABLE `banner_image`
  MODIFY `banner_image_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=83;
--
-- AUTO_INCREMENT для таблицы `category`
--
ALTER TABLE `category`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=59;
--
-- AUTO_INCREMENT для таблицы `country`
--
ALTER TABLE `country`
  MODIFY `country_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=240;
--
-- AUTO_INCREMENT для таблицы `coupon`
--
ALTER TABLE `coupon`
  MODIFY `coupon_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT для таблицы `coupon_history`
--
ALTER TABLE `coupon_history`
  MODIFY `coupon_history_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `coupon_product`
--
ALTER TABLE `coupon_product`
  MODIFY `coupon_product_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `currency`
--
ALTER TABLE `currency`
  MODIFY `currency_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `customer`
--
ALTER TABLE `customer`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `customer_group`
--
ALTER TABLE `customer_group`
  MODIFY `customer_group_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `customer_ip`
--
ALTER TABLE `customer_ip`
  MODIFY `customer_ip_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `customer_ip_blacklist`
--
ALTER TABLE `customer_ip_blacklist`
  MODIFY `customer_ip_blacklist_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `customer_reward`
--
ALTER TABLE `customer_reward`
  MODIFY `customer_reward_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `customer_transaction`
--
ALTER TABLE `customer_transaction`
  MODIFY `customer_transaction_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `download`
--
ALTER TABLE `download`
  MODIFY `download_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `extension`
--
ALTER TABLE `extension`
  MODIFY `extension_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=428;
--
-- AUTO_INCREMENT для таблицы `geo_zone`
--
ALTER TABLE `geo_zone`
  MODIFY `geo_zone_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `information`
--
ALTER TABLE `information`
  MODIFY `information_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT для таблицы `language`
--
ALTER TABLE `language`
  MODIFY `language_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT для таблицы `layout`
--
ALTER TABLE `layout`
  MODIFY `layout_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT для таблицы `layout_route`
--
ALTER TABLE `layout_route`
  MODIFY `layout_route_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=32;
--
-- AUTO_INCREMENT для таблицы `length_class`
--
ALTER TABLE `length_class`
  MODIFY `length_class_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT для таблицы `length_class_description`
--
ALTER TABLE `length_class_description`
  MODIFY `length_class_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT для таблицы `manufacturer`
--
ALTER TABLE `manufacturer`
  MODIFY `manufacturer_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT для таблицы `option`
--
ALTER TABLE `option`
  MODIFY `option_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=13;
--
-- AUTO_INCREMENT для таблицы `option_value`
--
ALTER TABLE `option_value`
  MODIFY `option_value_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=49;
--
-- AUTO_INCREMENT для таблицы `order`
--
ALTER TABLE `order`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `order_download`
--
ALTER TABLE `order_download`
  MODIFY `order_download_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `order_history`
--
ALTER TABLE `order_history`
  MODIFY `order_history_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `order_option`
--
ALTER TABLE `order_option`
  MODIFY `order_option_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `order_product`
--
ALTER TABLE `order_product`
  MODIFY `order_product_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `order_status`
--
ALTER TABLE `order_status`
  MODIFY `order_status_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=17;
--
-- AUTO_INCREMENT для таблицы `order_total`
--
ALTER TABLE `order_total`
  MODIFY `order_total_id` int(10) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `order_voucher`
--
ALTER TABLE `order_voucher`
  MODIFY `order_voucher_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `product`
--
ALTER TABLE `product`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=65;
--
-- AUTO_INCREMENT для таблицы `product_description`
--
ALTER TABLE `product_description`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=65;
--
-- AUTO_INCREMENT для таблицы `product_discount`
--
ALTER TABLE `product_discount`
  MODIFY `product_discount_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=441;
--
-- AUTO_INCREMENT для таблицы `product_image`
--
ALTER TABLE `product_image`
  MODIFY `product_image_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2352;
--
-- AUTO_INCREMENT для таблицы `product_option`
--
ALTER TABLE `product_option`
  MODIFY `product_option_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=227;
--
-- AUTO_INCREMENT для таблицы `product_option_value`
--
ALTER TABLE `product_option_value`
  MODIFY `product_option_value_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=17;
--
-- AUTO_INCREMENT для таблицы `product_reward`
--
ALTER TABLE `product_reward`
  MODIFY `product_reward_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=546;
--
-- AUTO_INCREMENT для таблицы `product_special`
--
ALTER TABLE `product_special`
  MODIFY `product_special_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=440;
--
-- AUTO_INCREMENT для таблицы `return`
--
ALTER TABLE `return`
  MODIFY `return_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `return_action`
--
ALTER TABLE `return_action`
  MODIFY `return_action_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `return_history`
--
ALTER TABLE `return_history`
  MODIFY `return_history_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `return_reason`
--
ALTER TABLE `return_reason`
  MODIFY `return_reason_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT для таблицы `return_status`
--
ALTER TABLE `return_status`
  MODIFY `return_status_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `review`
--
ALTER TABLE `review`
  MODIFY `review_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `setting`
--
ALTER TABLE `setting`
  MODIFY `setting_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=542;
--
-- AUTO_INCREMENT для таблицы `stock_status`
--
ALTER TABLE `stock_status`
  MODIFY `stock_status_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT для таблицы `store`
--
ALTER TABLE `store`
  MODIFY `store_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `tax_class`
--
ALTER TABLE `tax_class`
  MODIFY `tax_class_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT для таблицы `tax_rate`
--
ALTER TABLE `tax_rate`
  MODIFY `tax_rate_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=88;
--
-- AUTO_INCREMENT для таблицы `tax_rule`
--
ALTER TABLE `tax_rule`
  MODIFY `tax_rule_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=129;
--
-- AUTO_INCREMENT для таблицы `url_alias`
--
ALTER TABLE `url_alias`
  MODIFY `url_alias_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=777;
--
-- AUTO_INCREMENT для таблицы `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `user_group`
--
ALTER TABLE `user_group`
  MODIFY `user_group_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT для таблицы `voucher`
--
ALTER TABLE `voucher`
  MODIFY `voucher_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `voucher_history`
--
ALTER TABLE `voucher_history`
  MODIFY `voucher_history_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `voucher_theme`
--
ALTER TABLE `voucher_theme`
  MODIFY `voucher_theme_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT для таблицы `weight_class`
--
ALTER TABLE `weight_class`
  MODIFY `weight_class_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT для таблицы `weight_class_description`
--
ALTER TABLE `weight_class_description`
  MODIFY `weight_class_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT для таблицы `zone`
--
ALTER TABLE `zone`
  MODIFY `zone_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3971;
--
-- AUTO_INCREMENT для таблицы `zone_to_geo_zone`
--
ALTER TABLE `zone_to_geo_zone`
  MODIFY `zone_to_geo_zone_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=58;--
-- База данных: `phpmyadmin`
--

-- --------------------------------------------------------

--
-- Структура таблицы `pma_bookmark`
--

CREATE TABLE IF NOT EXISTS `pma_bookmark` (
  `id` int(11) NOT NULL,
  `dbase` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `user` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `label` varchar(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `query` text COLLATE utf8_bin NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Bookmarks';

--
-- Дамп данных таблицы `pma_bookmark`
--

INSERT INTO `pma_bookmark` (`id`, `dbase`, `user`, `label`, `query`) VALUES
(1, 'test', '', 'Rename_Table', 'RENAME TABLE `table 2` TO transistor;');

-- --------------------------------------------------------

--
-- Структура таблицы `pma_column_info`
--

CREATE TABLE IF NOT EXISTS `pma_column_info` (
  `id` int(5) unsigned NOT NULL,
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `column_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `comment` varchar(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `mimetype` varchar(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `transformation` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `transformation_options` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Column information for phpMyAdmin';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_designer_coords`
--

CREATE TABLE IF NOT EXISTS `pma_designer_coords` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `x` int(11) DEFAULT NULL,
  `y` int(11) DEFAULT NULL,
  `v` tinyint(4) DEFAULT NULL,
  `h` tinyint(4) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Table coordinates for Designer';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_history`
--

CREATE TABLE IF NOT EXISTS `pma_history` (
  `id` bigint(20) unsigned NOT NULL,
  `username` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `db` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `timevalue` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `sqlquery` text COLLATE utf8_bin NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='SQL history for phpMyAdmin';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_navigationhiding`
--

CREATE TABLE IF NOT EXISTS `pma_navigationhiding` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `item_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `item_type` varchar(64) COLLATE utf8_bin NOT NULL,
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Hidden items of navigation tree';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_pdf_pages`
--

CREATE TABLE IF NOT EXISTS `pma_pdf_pages` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `page_nr` int(10) unsigned NOT NULL,
  `page_descr` varchar(50) CHARACTER SET utf8 NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='PDF relation pages for phpMyAdmin';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_recent`
--

CREATE TABLE IF NOT EXISTS `pma_recent` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `tables` text COLLATE utf8_bin NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Recently accessed tables';

--
-- Дамп данных таблицы `pma_recent`
--

INSERT INTO `pma_recent` (`username`, `tables`) VALUES
('root', '[{"db":"diplom","table":"ekstruder"},{"db":"diplom","table":"peskosuwilka"},{"db":"diplom","table":"magnit"},{"db":"diplom","table":"konveer"},{"db":"diplom","table":"konteiner"},{"db":"diplom","table":"drobilka"},{"db":"diplom","table":"aglomerator"},{"db":"Diplom","table":"Konteiner"},{"db":"test","table":"microsxema"},{"db":"test","table":"transistor"}]');

-- --------------------------------------------------------

--
-- Структура таблицы `pma_relation`
--

CREATE TABLE IF NOT EXISTS `pma_relation` (
  `master_db` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `master_table` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `master_field` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `foreign_db` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `foreign_table` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `foreign_field` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Relation table';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_savedsearches`
--

CREATE TABLE IF NOT EXISTS `pma_savedsearches` (
  `id` int(5) unsigned NOT NULL,
  `username` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `search_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `search_data` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Saved searches';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_table_coords`
--

CREATE TABLE IF NOT EXISTS `pma_table_coords` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `pdf_page_number` int(11) NOT NULL DEFAULT '0',
  `x` float unsigned NOT NULL DEFAULT '0',
  `y` float unsigned NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Table coordinates for phpMyAdmin PDF output';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_table_info`
--

CREATE TABLE IF NOT EXISTS `pma_table_info` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `display_field` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Table information for phpMyAdmin';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_table_uiprefs`
--

CREATE TABLE IF NOT EXISTS `pma_table_uiprefs` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `prefs` text COLLATE utf8_bin NOT NULL,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Tables'' UI preferences';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_tracking`
--

CREATE TABLE IF NOT EXISTS `pma_tracking` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `version` int(10) unsigned NOT NULL,
  `date_created` datetime NOT NULL,
  `date_updated` datetime NOT NULL,
  `schema_snapshot` text COLLATE utf8_bin NOT NULL,
  `schema_sql` text COLLATE utf8_bin,
  `data_sql` longtext COLLATE utf8_bin,
  `tracking` set('UPDATE','REPLACE','INSERT','DELETE','TRUNCATE','CREATE DATABASE','ALTER DATABASE','DROP DATABASE','CREATE TABLE','ALTER TABLE','RENAME TABLE','DROP TABLE','CREATE INDEX','DROP INDEX','CREATE VIEW','ALTER VIEW','DROP VIEW') COLLATE utf8_bin DEFAULT NULL,
  `tracking_active` int(1) unsigned NOT NULL DEFAULT '1'
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin ROW_FORMAT=COMPACT COMMENT='Database changes tracking for phpMyAdmin';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_userconfig`
--

CREATE TABLE IF NOT EXISTS `pma_userconfig` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `timevalue` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `config_data` text COLLATE utf8_bin NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='User preferences storage for phpMyAdmin';

--
-- Дамп данных таблицы `pma_userconfig`
--

INSERT INTO `pma_userconfig` (`username`, `timevalue`, `config_data`) VALUES
('root', '2015-07-21 21:59:08', '{"collation_connection":"utf8mb4_general_ci","lang":"ru"}');

-- --------------------------------------------------------

--
-- Структура таблицы `pma_usergroups`
--

CREATE TABLE IF NOT EXISTS `pma_usergroups` (
  `usergroup` varchar(64) COLLATE utf8_bin NOT NULL,
  `tab` varchar(64) COLLATE utf8_bin NOT NULL,
  `allowed` enum('Y','N') COLLATE utf8_bin NOT NULL DEFAULT 'N'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='User groups with configured menu items';

-- --------------------------------------------------------

--
-- Структура таблицы `pma_users`
--

CREATE TABLE IF NOT EXISTS `pma_users` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `usergroup` varchar(64) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Users and their assignments to user groups';

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `pma_bookmark`
--
ALTER TABLE `pma_bookmark`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `pma_column_info`
--
ALTER TABLE `pma_column_info`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `db_name` (`db_name`,`table_name`,`column_name`);

--
-- Индексы таблицы `pma_designer_coords`
--
ALTER TABLE `pma_designer_coords`
  ADD PRIMARY KEY (`db_name`,`table_name`);

--
-- Индексы таблицы `pma_history`
--
ALTER TABLE `pma_history`
  ADD PRIMARY KEY (`id`), ADD KEY `username` (`username`,`db`,`table`,`timevalue`);

--
-- Индексы таблицы `pma_navigationhiding`
--
ALTER TABLE `pma_navigationhiding`
  ADD PRIMARY KEY (`username`,`item_name`,`item_type`,`db_name`,`table_name`);

--
-- Индексы таблицы `pma_pdf_pages`
--
ALTER TABLE `pma_pdf_pages`
  ADD PRIMARY KEY (`page_nr`), ADD KEY `db_name` (`db_name`);

--
-- Индексы таблицы `pma_recent`
--
ALTER TABLE `pma_recent`
  ADD PRIMARY KEY (`username`);

--
-- Индексы таблицы `pma_relation`
--
ALTER TABLE `pma_relation`
  ADD PRIMARY KEY (`master_db`,`master_table`,`master_field`), ADD KEY `foreign_field` (`foreign_db`,`foreign_table`);

--
-- Индексы таблицы `pma_savedsearches`
--
ALTER TABLE `pma_savedsearches`
  ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `u_savedsearches_username_dbname` (`username`,`db_name`,`search_name`);

--
-- Индексы таблицы `pma_table_coords`
--
ALTER TABLE `pma_table_coords`
  ADD PRIMARY KEY (`db_name`,`table_name`,`pdf_page_number`);

--
-- Индексы таблицы `pma_table_info`
--
ALTER TABLE `pma_table_info`
  ADD PRIMARY KEY (`db_name`,`table_name`);

--
-- Индексы таблицы `pma_table_uiprefs`
--
ALTER TABLE `pma_table_uiprefs`
  ADD PRIMARY KEY (`username`,`db_name`,`table_name`);

--
-- Индексы таблицы `pma_tracking`
--
ALTER TABLE `pma_tracking`
  ADD PRIMARY KEY (`db_name`,`table_name`,`version`);

--
-- Индексы таблицы `pma_userconfig`
--
ALTER TABLE `pma_userconfig`
  ADD PRIMARY KEY (`username`);

--
-- Индексы таблицы `pma_usergroups`
--
ALTER TABLE `pma_usergroups`
  ADD PRIMARY KEY (`usergroup`,`tab`,`allowed`);

--
-- Индексы таблицы `pma_users`
--
ALTER TABLE `pma_users`
  ADD PRIMARY KEY (`username`,`usergroup`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `pma_bookmark`
--
ALTER TABLE `pma_bookmark`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `pma_column_info`
--
ALTER TABLE `pma_column_info`
  MODIFY `id` int(5) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `pma_history`
--
ALTER TABLE `pma_history`
  MODIFY `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `pma_pdf_pages`
--
ALTER TABLE `pma_pdf_pages`
  MODIFY `page_nr` int(10) unsigned NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT для таблицы `pma_savedsearches`
--
ALTER TABLE `pma_savedsearches`
  MODIFY `id` int(5) unsigned NOT NULL AUTO_INCREMENT;--
-- База данных: `test`
--

-- --------------------------------------------------------

--
-- Структура таблицы `inform`
--

CREATE TABLE IF NOT EXISTS `inform` (
  `№` int(11) NOT NULL,
  `tema` longtext NOT NULL,
  `content` longtext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=cp1251;

--
-- Дамп данных таблицы `inform`
--

INSERT INTO `inform` (`№`, `tema`, `content`) VALUES
(0, 'Автор', '\r\n<div id="faceSmurf">\r\n			<div class="hat1"></div>\r\n			<div class="hat2"></div>\r\n			<div class="hat3"></div>\r\n			\r\n			<div class="nFace"></div>\r\n			<div class="ear">\r\n				<div class="earl1"></div>\r\n			</div>\r\n			<div class="mouth">\r\n				<div class="mouth1"></div>\r\n			</div>\r\n			<div class="nose">\r\n				<div class="noseb"></div>\r\n				<div class="noseb1"></div>\r\n			</div>\r\n			<div class="eye1">\r\n				<div class="eye11"></div>\r\n			</div>\r\n			<div class="eye2">\r\n				<div class="eye21"></div>\r\n			</div>\r\n			<div class="eyebrow1"></div>\r\n			<div class="eyebrow2"></div>\r\n		</div>\r\n\r\n\r\n<div class="block1"><img src="images/0.jpg" height=350 width=350 hspace=5 vspace=5 align="top" alt="Гдето касяк">\r\n<div style="background-color: Oldlace; margin-left: 0px;" class="block1">\r\nСайт создан:<br>\r\n<b>Предмет</b> - Сети и телекоммуникации<br>\r\n<b>Автор</b> - Сафронов Д. Ю.<br>\r\nQwinCor@2015 17:48\r\n</div>\r\n</div>\r\n\r\n\r\n'),
(1, 'Почта', '\r\n<div>\r\n<h1 style="text-align: center;">Как завести электронную почту</h1>\r\n\r\n<p style="text-align: center;"><img class="aligncenter size-full wp-image-836" alt="22222Как завести электронную почту" src="images/wp-content/uploads/2013/01/22222.jpg" width="523" height="338" title="Как завести электронную почту" />\r\n<br>В современном мире такие термины, как почта, или письмо уже морально устарели, на смену им пришли новые  понятия <em>электронная почта</em> и электронном письмо. Конечно «почта России» никуда не денется, и бумажные письма тоже (интернет есть далеко не везде), но необходимость бумажных писем сократилось в разы, когда <em>электронная почта</em> пришла в массы, а интернет в городах стал как само собой естественное.</p>\r\n\r\n<p><em> Электронная почта</em> позволяет общаться с родственниками в других городах и странах, а электронное письмо адресат получит через пару минут после его отправки. Электронной почтой активно пользуются на работе: отправляют отчеты, договариваются о встречах, обсуждают договора и во многих других случаях. Часто для получения доступа к некой информации в интернете, требуют пройти регистрацию, где обязательным условием ставиться указать свою электронную почту. Как видим без неё просто не обойтись в сегодняшнем мире. Думаю, что Вы уже знаете для чего вам нужна почта, а раз так то смотрим <em><strong>как завести электронную почту</strong></em>. <span id="more-825"></span></p>\r\n\r\n<p>Бесплатно завести электронную почту можно на сайтах поисковых систем: Яндекс, Майл, Рамблер, Гугл.  Рассмотрим на примере, <em>как завести электронную почту на Яндексе</em>, помните вы можете сделать почту на любом другом сайте.</p>\r\n\r\n<p>Открываем Яндекс. В правой части экрана видим вот такое окно, выбираем «Завести ящик».</p>\r\n\r\n<p style="text-align: center;"><img class="alignnone size-full wp-image-988" alt="1111Как завести электронную почту" src="images/wp-content/uploads/2013/01/1111.jpg" width="232" height="220" title="Как завести электронную почту" /></p>\r\n\r\n<p style="text-align: center;"><img class="aligncenter size-full wp-image-827" alt="24Как завести электронную почту" src="images/wp-content/uploads/2013/01/24.jpg" width="523" height="344" title="Как завести электронную почту" /></p>\r\n\r\n<p>Пишем имя и фамилию, после нам предлагают выбрать имя нашей почты. Придумайте уникальное имя(лучше псевдоним) и впишите в графу Логин. Следует учесть, что имя будущей почты обязательно идёт на английском языке. Когда напишите логин, система укажет можно использовать данное имя, или такое имя уже есть в системе (две одинаковые электронные почты не могут существовать).</p>\r\n\r\n<p style="text-align: center;"><img class="aligncenter size-full wp-image-828" alt="34Как завести электронную почту" src="images/wp-content/uploads/2013/01/34.jpg" width="419" height="343" title="Как завести электронную почту" /></p>\r\n\r\n<p style="text-align: center;"><img class="aligncenter size-full wp-image-829" alt="43Как завести электронную почту" src="images/wp-content/uploads/2013/01/43.jpg" width="523" height="64" title="Как завести электронную почту" /></p>\r\n\r\n<p style="text-align: center;"><img class="aligncenter size-full wp-image-830" alt="54Как завести электронную почту" src="images/wp-content/uploads/2013/01/54.jpg" width="523" height="64" title="Как завести электронную почту" /></p>\r\n\r\n<p>Идём дальше, теперь придумайте пароль такой, чтобы его не забыли (набираем в обоих графах), минимальная длина должна быть 6 символов (буквы и цифры). Многие ставят на пароль свой номер телефона. Секретный вопрос, это в случае если забыли пароль, чтобы смогли войти в электронную почту и поменять пароль. Мобильный телефон можно не указывать, но он может пригодится для восстановления пароля (Помните, что указывать ваш номер телефона в интернете можно только на ОЧЕНЬ проверенных сайтах, мошенники не дремлют). Вводим показанный код, если не понятно то сделайте показать другую картинку. И наконец жмем зарегистрироваться.</p>\r\n\r\n<p style="text-align: center;"><img class="aligncenter size-full wp-image-831" alt="61Как завести электронную почту" src="images/wp-content/uploads/2013/01/61.jpg" width="523" height="500" title="Как завести электронную почту" /></p>\r\n\r\n<p>Если всё удачно появится такое окно. Можно вписать код подтверждения, если указывали номер телефона. Осталось нажать на кнопку начать пользоваться, после закройте лишние окна и вот она <em>электронная почта</em>.</p>\r\n\r\n<p style="text-align: center;"><img class="aligncenter size-full wp-image-832" alt="71Как завести электронную почту" src="images/wp-content/uploads/2013/01/71.jpg" width="523" height="489" title="Как завести электронную почту" /></p>\r\n\r\n<p style="text-align: center;"><img class="aligncenter size-full wp-image-840" alt="101Как завести электронную почту" src="images/wp-content/uploads/2013/01/101.jpg" width="494" height="343" title="Как завести электронную почту" /></p>\r\n\r\n<p>Если теперь перейдете на сайт Яндекса, то увидите справа похожее окно.</p>\r\n\r\n<p style="text-align: center;"><img class="size-full wp-image-991 aligncenter" alt="screenshot 41Как завести электронную почту" src="images/wp-content/uploads/2013/01/screenshot-41.jpg" width="232" height="220" title="Как завести электронную почту" /></p>\r\n\r\n<p>Теперь, когда захотите войти в почту, открываете сайт Яндекса (<noindex><a rel="nofollow" href="http://www.yandex.ru/">www.yandex.ru</a></noindex>) и в правой стороне вводите свой логин и пароль для электронной почты. Поставьте галочку, чтобы запомнить меня, это значит что теперь с данного компьютера, вы сможете заходить в свою почту, не заполняя графы логин и пароль постоянно.</p>\r\n\r\n<p style="text-align: center;"><img  alt="screenshot 31Как завести электронную почту" src="images/wp-content/uploads/2013/01/screenshot-31.jpg" width="232" height="220" title="Как завести электронную почту" /></p>\r\n\r\n<p>Вы можете завести почту на любом другом сайте, но я рекомендую выбрать одну из этих: Яндекс, Гугл (www.gmail.com), или Майл (<noindex><a rel="nofollow" href="http://www.mail.ru/">www.mail.ru</a></noindex>). Не ограничивайтесь одним почтовым ящиком (у меня есть 4-5 действующих почтовых ящиков, самому первому ящику наверно 8-9 лет), заведите один для работы, другой например, для регистрации на различных сайтах или форумах.</p>\r\n\r\n</div>\r\n'),
(2, 'Telnet', '\r\n<div>\r\n<h2 >\r\n			<a >\r\n		Проверка работы почтовых сервисов с помощью telnet</a>\r\n</h2>\r\n\r\n<p><strong><em>Доступ к почтовому серверу через Telnet</em></strong><br />telnet mail.mydomain.ru 25 <br /><em>mail.mydomain.ru - адрес smtp сервера</em> <br /><em>25 - smtp-порт сервера, с которым должен соедениться telnet <br /></em>220 mail.mydomain.ru ESMTP Sendmail 8.13.1/8.13.1; Sat, 6 Oct 2007 09:50:16 +0400 <br />ehlo lo <br /><em>ehlo lo - поздоровались с удалённым smtp-сервером</em> <br />250-ENHANCEDSTATUSCODES <br />250-PIPELINING <br />250-8BITMIME <br />250-SIZE <br />250-DSN <br />250-ETRN <br />250-AUTH GSSAPI DIGEST-MD5 CRAM-MD5 <br />250-DELIVERBY <br />250 HELP</p>\r\n \r\n<p>mail from: test/@mydomain.ru <em>тут мы говорим, что адрес почтовый отправителя письма </em><em> test/@mydomain.ru </em></p>\r\n\r\n<p>250 2.1.0 test/@mydomain.ru ... Sender ok <br /><em>поверка отправителя прошла успешно</em></p>\r\n\r\n<p>rcpt to: test/@remote.ru <em>здесь мы ввели почтовый адрес получателя нашего письма </em><em> test/@remote.ru </em></p>\r\n\r\n<p>250 2.1.5 test/@remote.ru ... Recipient ok <br /><em>проверка получателя прошла успешно</em></p>\r\n<img src="images/bsdtelnet.png" />\r\n<p>data&nbsp; <br /><em>команда data говорит о том, что дальше пойдёт тело письма</em> <br />354 Enter mail, end with "." on a line by itself <br /><em>ответ сервера говорит нам о том, что чтобы закончить письмо мы должны набрать <br />точку "." на новой строке после набранного нами сообщения (тела письма) <br /></em>this is test message<br /><em>это наш текст</em> <br />. <br /><em>точка - даём понять серверу что письмо набрано и его пора отправлять адресату</em> <br />250 2.0.0 l965oGGR025162 Message accepted for delivery <br /><em>ответ сервера - письмо ушло на отправку</em></p>\r\n\r\n<p><strong><em>Доступ к POP3 через telnet (приём почты). <br /></em></strong>telnet pop3.myserver.ru 110 <br /><em>pop3.myserver.ru - наш pop3 сервер</em> <br /><em>110 - pop3-порт на который соединиться телнет</em> <br />+OK <br /><em>сервер сказал, что соеденение прошло нормально <br /></em>user test <br /><em>ввели имя пользователя test.</em> <br />pass parol <br /><em>ввели пароль "parol" <br />теперь мы можем узнать колличество и размер почтовых сообщений: <br /></em>stat <br /><em>для вывода полного листинга почтовых сообщений надо использоваьт команду: <br /></em>list <br /><em>для того чтобы прочитать нужное сообщение вводим: <br /></em>retr номер письма <br /><em>просмотреть только заголовок сообщения: <br />top номер письма 0 (в конце строки поставить ноль) <br />удалить письмо из ящика: <br />dele номер сообщения <br />выход: <br /></em>quit <br />\r\n<img src="images/inboxmail.png" /><br /><strong><em>Дополнение: <br /></em></strong>1) Если SMTP сервер требует SMTP-аутентификацию, то после того, как мы с <br />ним поздоровались (ehlo lo), вводим команду AUTH LOGIN, и после неё поочереди: <br />USERNAME имя-пользователя <br />PASSWORD наш-пароль <br />2) На почтовых серверах, где заведено несколько виртуальных почтовых доменах в <br />POP3-сессии в поле user следует вводить полностью электронный ящик: test/@myserver.ru</p>\r\n\r\n</div>\r\n');
INSERT INTO `inform` (`№`, `tema`, `content`) VALUES
(3, 'Команды сети', '\r\n<div>\r\n<h2>Команды работы с сетью в CMD</h2>\r\n\r\n<center><font size="2"><b><font color="#0000ff">\r\n<h3 id="id07"><font size="2">\r\n<a href="#id07">NETSTAT</a><br>\r\n<a href="#id08">NET</a><br>\r\n<a href="#id009">NSLOOKUP</a><br>\r\n<a href="#id10">PATHPING</a><br>\r\n<a href="#id11">PING</a><br>\r\n<a href="#id12">ROUTE</a><br>\r\n<a href="#id13">TELNET</a><br>\r\n<a href="#id14">TRACERT</a>\r\n</font></h3>\r\n<h3 id="id07" name="id07">Утилита NETSTAT.EXE</h3></font></b></font></center>\r\n<img class="center" src="images/netstat.png" />\r\n<table width="100%"><tbody><tr><td width="90%"><br>\r\n<li><font size="2">Получить список слушаемых портов и связанных с ними программ:<br><br><b>netstat -a -b </b><br><br>\r\n<b>netstat -ab </b>- параметры \r\nкомандной строки можно объединять. Параметр <b>-ab</b> эквивалентен <b>-a -b \r\n</b><br><br><b>netstat -a -n -b </b>- отобразить список всех соединений с \r\nчисловыми номерами портов <br><br><b>netstat -anb </b>- аналогично предыдущей \r\nкоманде. <br><br><b>netstat -anbv </b>- при использовании параметра <b>-v</b> \r\nотображается последовательность компонентов, участвующих в создании соединения \r\nили слушаемого порта.<br><br></font>\r\n</li>\r\n<li><font size="2">получить статистические данные:<br><br><b>netstat -e </b>- получить \r\nстатистические данные для Ethernet. Отображается суммарные значения принятых и \r\nполученных байт для всех сетевых адаптеров.<br><br><b>netstat -e -v </b>- кроме \r\nстатистических данных, отображается информация о каждом сетевом адаптере. \r\n<br><br><b>netstat -e -s </b>- дополнительно к статистике Ethernet, отображается \r\nстатистика для протоколов IP , ICMP , TCP , UDP <br><br><b>netstat -s -p tcp udp \r\n</b>- получить статистику только по протоколам TCP и UDP<br></font>\r\n\r\n<font size="2"><br><b name="id08">\r\n</b><br><br>&nbsp; &nbsp; Утилита NET.EXE \r\nсуществует во всех версиях Windows и является одной из самых используемых в \r\nпрактической работе с сетевыми ресурсами. Позволяет подключать и отключать \r\nсетевые диски, запускать и останавливать системные службы, добавлять и удалять \r\nпользователей, управлять совместно используемыми ресурсами, устанавливать \r\nсистемное время, отображать статистические и справочные данные об использовании \r\nресурсов и многое другое. <br>\r\n<img class="center" src="images/net.png" /><br>Выполнение команды <b>net </b>без параметров \r\nвызывает краткую справку со списком возможных уровней использования, запуск с \r\nпараметром <b>help </b>позволяет получить более подробную информацию об \r\nиспользовании net.exe:<br><br><b><font color="green">Синтаксис данной \r\nкоманды:<br><br>NET HELP <br>имя_команды<br>-или-<br>NET имя_команды \r\n/HELP<br>Можно использовать следующие имена команд:<br><br>NET ACCOUNTS NET HELP \r\nNET SHARE <br>NET COMPUTER NET HELPMSG NET START <br>NET CONFIG NET LOCALGROUP \r\nNET STATISTICS <br>NET CONFIG SERVER NET NAME NET STOP <br>NET CONFIG \r\nWORKSTATION NET PAUSE NET TIME <br>NET CONTINUE NET PRINT NET USE <br>NET FILE \r\nNET SEND NET USER <br>NET GROUP NET SESSION NET VIEW <br><br>NET HELP SERVICES - \r\nэта команда выводит список служб, которые можно запустить. <br>NET HELP SYNTAX - \r\nэта команда выводит объяснения синтаксических правил, используемых при описании \r\nкоманд в Справке. <br>NET HELP имя_команды | MORE - просмотр справки по одному \r\nэкрану за раз. <br><br></font></b>При описании команды <b>NET </b>используются \r\nследующие синтаксические соглашения:<br><br>- Заглавными буквами набраны слова, \r\nкоторые должны быть введены без изменений, строчными буквами набраны имена и \r\nпараметры, которые могут изменяться, например, имена файлов.<br><br>- \r\nНеобязательные параметры заключены в квадратные скобки - [ ].<br><br>- Списки \r\nдопустимых параметров заключены в фигурные скобки - { }. Необходимо использовать \r\nодин из элементов такого списка. <br><br>- Символ | (вертикальная черта) \r\nиспользуется в качестве разделителя элементов списка. Возможно использование \r\nтолько одного из элементов списка. Например, в соответствии с изложенными \r\nсоглашениями, необходимо ввести NET COMMAND и один из переключателей - SWITCH1 \r\nили SWITCH2. Указанное в квадратных скобках имя [name] является необязательным \r\nпараметром:<br>NET COMMAND [name] {SWITCH1 | SWITCH2}<br><br>- Запись [...] \r\nозначает, что указанный элемент может повторяться. Повторяющиеся элементы должны \r\nбыть разделены пробелом. <br><br>- Запись [,...] означает, что указанный элемент \r\nможет повторяться, но повторяющиеся элементы должны быть разделены запятой или \r\nточкой с запятой, но не пробелом. <br><br>- При вводе в командной строке можно \r\nиспользовать русские названия служб, при этом они должны быть заключены в \r\nкавычки и не допускается изменение прописных букв на строчные и наоборот. \r\nНапример, команда <br>NET START "Обозреватель сети"<br>запускает службу \r\nобозревателя сети. <br><br>Справочная система NET.EXE, пожалуй, является одной \r\nиз лучших в семействе операционных систем Windows. Подробную справку по \r\nиспользованию нужной команды, например <b>use </b>, можно получить несколькими \r\nспособами:<br><br><b>net use ? </b>- справка о синтаксисе команды <br><b>net use \r\n/help </b>- подробная справка по использованию команды с описанием используемых \r\nключей. <br><b>net help use </b>- аналогично предыдущей форме вызова справки. \r\n<br><b>net help use | more </b>- отобразить справку в постраничном режиме выдачи \r\nна экран. Удобно пользоваться в тех случаях, когда тест не помещается на экране. \r\nНажатие <b>Enter</b> перемещает текст на одну строку, нажатие пробела - на один \r\nэкран.<br><b>net help use &gt; C:&#92;helpuse.txt </b>- создать текстовый файл \r\nсправки C:&#92;helpuse.txt <br><br><br></font><center><font size="2"><b><font color="#0000ff">\r\n<h3 id="id08">Утилита NET.EXE</h3></font></b></font></center>\r\n<center>\r\n<li><font color="blue" size="2">Работа с системными службами </font></li></center><font size="2"><br><br>&nbsp; &nbsp; \r\nДанный режим использования <b>NET.EXE </b>, в некоторой степени, является не \r\nхарактерным для основного предназначения утилиты, и начиная с Windows XP, для \r\nуправления системными службами используется специальная утилита командной строки \r\n<b>SC.EXE</b>. Тем не менее, NET.EXE в среде любой версии операционных систем \r\nWindows может быть использована для запуска и остановки системных служб \r\n(сервисов). Согласно справочной информации, список служб, которыми можно \r\nуправлять с помощью <b>net.exe </b>можно получить используя следующую \r\nкоманду:<br><br><b>net help services </b><br><br>Но это не совсем верно, и на \r\nсамом деле, с помощью <b>net.exe</b> можно запустить или остановить практически \r\nлюбую системную службу, и в том числе, не представленную в списке , отображаемом \r\nпри выполнении данной команды . Для остановки используется параметр <b>stop</b>, \r\nа для запуска - параметр <b>start</b>:<br><br><b>net stop dnscache </b>- \r\nостановить службу <b>dnscache </b><br><b>net start dnscache </b>- запустить \r\nслужбу <b>dnscache </b><br><br>Возможно использование как короткого, так и \r\nполного имени ("Dnscache" - короткое, "DNS-клиент" - полное имя службы). Имя \r\nслужбы, содержащее символы русского алфавита и пробелы заключается в двойные \r\nкавычки. <br><br><b>net stop "DNS-клиент" </b>- остановить службу <b>DNS-клиент \r\n</b>. <br><br>Полное имя службы можно скопировать из "Панель управления" - \r\n"Администрирование" - "Службы" - Имя службы - "Свойства" - "Выводимое имя". \r\n<br><br>Для приостановки некоторых системных служб или продолжения работы ранее \r\nприостановленной службы используются команды <b>NET PAUSE </b>и <b>NET CONTINUE \r\n</b>: <br><br><b>net pause "Планировщик заданий" </b>- приостановить службу \r\n"Планировщик заданий"<br><b>net continue schedule </b>- продолжить работу службы \r\n"Планировщик заданий" . Имя службы задано в коротком формате. <br><br><br></font>\r\n<center>\r\n<li><font color="blue" size="2">Работа с сетевыми дисками </font></li></center><font size="2"><br><br><b>net \r\nuse </b>- отобразить список сетевых дисков, подключенных на данном компьютере. \r\n<br><br><b><font color="green">Состояние &nbsp; &nbsp; Локальный &nbsp; &nbsp; Удаленный &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; \r\nСеть<br>-------------------------------------------------------------------------------<br>Отсоединен \r\n&nbsp; X: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &#92;&#92;SERVER&#92;movies &nbsp; &nbsp; &nbsp; &nbsp; Microsoft Windows Network<br>OK \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Y: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &#92;&#92;SERVER&#92;shares &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Microsoft \r\nWindows Network<br><br></font></b>В колонке "Локальный" отображается буква \r\nсетевого диска, а в колонке "Удаленный" - имя удаленного сетевого ресурса в \r\nформате <b>UNC</b> <br>UNC - это Общее соглашение об именах (Uniform Naming \r\nConvention) или универсальное соглашение об именовании (universal naming \r\nconvention), соглашение об именовании файлов и других ресурсов, дающее \r\nопределение местоположения ресурса .<br>Имя, соответствующее UNC - полное имя \r\nресурса в сети, включающее имя сервера и имя совместно используемого \r\n(разделяемого, сетевого ) ресурса (принтера, каталога или файла). Синтаксис \r\nUNC-пути к каталогу или файлу следующий: \r\n<br><b>&#92;&#92;Сервер&#92;СетевойКаталог[&#92;ОтносительныйПуть]<br></b><b>Сервер</b> - \r\nсетевое имя компьютера, <b>СетевойКаталог </b>- это сетевое имя общего каталога \r\nна этом компьютере, а необязательный <b>ОтносительныйПуть</b> - путь к каталогу \r\nили файлу из общего каталога.<br>СетевойКаталог не обязательно называется так \r\nже, как ассоциированный с ним каталог на сервере, имя даётся в ходе открытия \r\nобщего доступа к каталогу в файловой системе компьютера<br><br>В операционных \r\nсистемах семейства Windows, если в конце имени разделяемого ресурса используется \r\nзнак <b>$ </b>то такой ресурс является скрытым и не отображается в проводнике \r\nпри просмотре сетевого окружения. Это правило относится не только к \r\nавтоматически создаваемым ресурсам для системного администрирования ( C$ , D$ , \r\nADMIN$ и т.п. ), но и для любого пользовательского разделяемого ресурса. Если, \r\nнапример, для сетевого доступа выделена папка под именем "movies", то она будет \r\nвидна в сетевом окружении, а если - под именем "movies$" - то нет.<br>Для того, \r\nчтобы скрыть в сетевом окружении отдельный компьютер используется \r\nкоманда:<br><b>NET config server /hidden:yes</b><br>Чтобы вернуть отображение \r\nкомпьютера в сетевом окружении<br><b>NET config server \r\n/hidden:no</b><br><br>UNC-пути можно использовать и для локальной машины, только \r\nв этом случае вместо имени "Сервер" нужно подставлять знак "?" или ".", а путь к \r\nфайлу указывать вместе с буквой диска. Например так: \r\n"&#92;&#92;?&#92;C:&#92;Windows&#92;System32&#92;file.exe" . <br><br>Для отключения сетевого диска или \r\nустройства используется команда <b>net use</b> с ключом <b>/DELETE \r\n</b><br><br><b>net use X: /delete </b>- отключить сетевой диск X: \r\n<br><br>Регистр букв в данном ключе не имеет значения и можно использовать \r\nсокращения:<br><br><b>net use Y: /del</b><br><br>Примеры выполнения команды \r\n<b>NET USE </b>для подключения сетевых дисков:<br><br><b>net use X: \r\n&#92;&#92;server&#92;shares </b>- подключить сетевой диск X: которому соответствует \r\nразделяемый сетевой каталог с именем <b>shares</b> на компьютере с именем \r\n<b>server </b><br><br><b>net use Y:&#92;C$ /USER:Администратор admpass </b>- \r\nподключить сетевой диск Y: которому соответствует скрытый ресурс C$ (корневой \r\nкаталог диска C:) . При подключении к удаленному компьютеру используется имя \r\nпользователя <b>Администратор</b> и пароль <b>admpass</b><br><br>То же самое, но \r\nс использованием учетной записи в домене <b>mydomain</b> <b>net use Y:&#92;C$ \r\n/USER:mydomain&#92;Администратор admpass </b><br><br><b>net use Y:&#92;C$ \r\n/USER:Администратор@mydomain admpass </b><br><br>Если в командной строке пароль \r\nне задан, то он будет запрошен при подключении к сетевому ресурсу. Если ключ \r\n<b>/USER </b>не задан, то для авторизации на удаленном компьютере используется \r\nтекущая учетная запись.<br><br><b>net use Y:&#92;C$ /SAVECRED </b>- выполнить \r\nподключение с запоминанием полномочий (credentials) пользователя. При первом \r\nподключении, будет выдан запрос на ввод имени пользователя и пароля , которые \r\nбудут запомнены и не будут запрашиваться при последующих подключениях. Параметр \r\n<b>/savecred</b> не работает в версиях Домашняя и Начальная Windows 7 / Windpws \r\nXP <br><br>Для изменения режима запоминания подключенных сетевых дисков \r\nиспользуется ключ <b>/PERSISTENT </b><br><br><b>net use /PERSISTENT:NO </b>- не \r\nзапоминать сетевые подключения. <br><b>net use /PERSISTENT:YES </b>- запоминать \r\nсетевые подключения. <br><br>Необходимо учитывать, что режим, определяемый \r\nзначением ключа /PERSISTENT, относится к вновь создаваемым подключениям. Если, \r\nнапример, сетевой диск X: был создан при установленном режиме запоминания \r\n(PERSISTENT:YES), а затем вы выполнили смену режима командой <b>net use \r\n/PERSISTENT:NO </b>и подключили сетевой диск Y: , то после перезагрузки системы, \r\nне будет восстановлено подключение диска Y: , но будет восстановлено подключение \r\nдиска X: <br><br><br></font>\r\n<center>\r\n<li><font color="blue" size="2">Работа с файлами и каталогами \r\n</font></li></center><font size="2"><br><br><b>NET SHARE</b> - эта команда позволяет выделить \r\nресурсы системы для сетевого доступа . При запуске без других параметров, \r\nвыводит информацию обо всех ресурсах данного компьютера, которые могут быть \r\nсовместно использованы . Для каждого ресурса выводится имя устройства или путь и \r\nсоответствующий комментарий.<br><br><b>net share </b>- получить список \r\nразделяемых в локальной сети ресурсов данного компьютера. Пример \r\nсписка:<br><br><font color="green">Общее имя &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Ресурс &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\nЗаметки<br><br>------------------------------------------------------------------------------<br>G$ \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; G:&#92; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Стандартный общий ресурс <br>E$ \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; E:&#92; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Стандартный общий ресурс \r\n<br>IPC$ &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Удаленный IPC <br>ADMIN$ \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; C:&#92;WINDOWS &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Удаленный Admin <br>INSTALL &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\nC:&#92;INSTALL &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Дистрибутивы и обновления<br><br><br></font><b>net \r\nshare INSTALL </b>- получить информацию о разделяемом ресурсе с именем INSTALL . \r\n<br><br><font color="green">Имя общего ресурса &nbsp; &nbsp; INSTALL<br>Путь &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; C:&#92;INSTALL<br>Заметки &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Дистрибутивы и \r\nобновления <br>Макс. число пользователей &nbsp; &nbsp; Не ограничен<br>Пользователи &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Administrator <br>Кэширование &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Вручную \r\n<br><br></font>Для добавления нового разделяемого по сети ресурса используется \r\nпараметр <b>/ADD </b><br><br><b>net share TEMP="C:&#92;Documents And \r\nSettings&#92;LocalSettings&#92;games" </b>- добавить новый разделяемый каталог под \r\nименем <b>TEMP</b> <br><br><b>net share TEMP="C:&#92;Documents And \r\nSettings&#92;LocalSettings&#92;games" /users:5 </b>- добавить новый разделяемый каталог \r\nпод именем <b>TEMP</b> с максимальным числом обновременоо подключающихся \r\nпользователей равным 5 .<br><br>Кроме этого, при создании разделяемого ресурса \r\nможно указать краткое его описание (заметку) с помощью параметра /REMARK и режим \r\nкэширования файлов с помощью параметра /CACHE . <br><br><b>NET SHARE \r\nимя_ресурса=диск:путь [/USERS:чиcло | /UNLIMITED] [/REMARK:"текст"] \r\n[/CACHE:Manual | Automatic | No ] [/CACHE:Manual | Documents| Programs | None \r\n]<br><br></b>Для удаления существующего разделяемого ресурса используется \r\nпараметр /DELETE: <br><br><b>net share TEMP /DELETE </b>- удалить разделяемый \r\nресурс под именем TEMP<br><br>Удаление выполняется только для имени разделяемого \r\nресурса и не затрагивает каталог локального диска, связанный с данным именем. \r\n<br><br>Для работы с файлами, открытыми по сети на данном компьютере, \r\nиспользуется команда <b>NET FILE</b> . По каждому открытому ресурсу выводится \r\nидентификационный номер, путь файла, имя пользователя, которым используется \r\nфайл, и количество блокировок при совместном использовании. Кроме того, команда \r\n<b>NET FILE </b>позволяет закрыть совместно используемый файл и снять блокировки \r\n. <br><br><b>net file</b> - получить список открытых по сети файлов \r\n.<br><br><b>net file 4050 /close </b>- принудительно закрыть файл, идентификатор \r\nкоторого равен 4050<br><br>Для получения списка компьютеров рабочей группы или \r\nдомена с разделяемыми ресурсами используется команда <br><br><b>net view</b> - \r\nотобразить список компьютеров в сетевом окружении.<br><br><b>net view | more</b> \r\n- отобразить список компьютеров в постраничном режиме вывода на \r\nэкран.<br><br><b>net view &gt; C:&#92;computers.txt</b> - отобразить список \r\nкомпьютеров c записью результатов в текстовый файл.<br><br>Синтаксис данной \r\nкоманды:<br><br><b>NET VIEW [&#92;&#92;имя_компьютера [/CACHE] | \r\n/DOMAIN[:имя_домена]]<br>NET VIEW /NETWORK:NW \r\n[&#92;&#92;имя_компьютера]</b><br><br><b>net view &#92;&#92;server </b>- отобразить список \r\nсетевых ресурсов компьютера server <br><br><b>net view /DOMAIN:mydomain </b>- \r\nотобразить список компьютеров с разделяемыми ресурсами в домене <b>mydomain</b> \r\nЕсли имя домена не указано, то выводится список всех доступных компьютеров \r\nлокальной сети. <br><br><b>net view /NETWORK:NW </b>- отобразить список серверов \r\nNovell Netware, доступных в данной локальной сети.<br><br><b>net view \r\n/NETWORK:NW &#92;&#92;NWServer</b> - отобразить списков сетевых ресурсов сервера Netware \r\nс именем NWServer .<br><br><br></font>\r\n<center>\r\n<li><font color="blue" size="2">Работа с пользователями и компьютерами . \r\n</font></li></center><font size="2"><br><br>&nbsp; &nbsp; Утилита NET.EXE позволяет отобразить данные об \r\nучетных записях пользователей и групп, добавлять новые записи, удалять \r\nсуществующие, отображать параметры безопасности, связанные с авторизацией \r\nпользователей и некоторые другие операции по администрированию на локальном \r\nкомпьютере или контроллере домена. <br><br><b>NET ACCOUNTS </b>- эта команда \r\nиспользуется для обновления базы данных регистрационных записей и изменения \r\nпараметров входа в сеть (LOGON) . При использовании этой команды без указания \r\nпараметров, выводятся текущие значения параметров, определяющих требования к \r\nпаролям и входу в сеть, - время принудительного завершения сессии, минимальную \r\nдлину пароля, максимальное и минимальное время действия пароля и его \r\nуникальность.<br><br>Синтаксис данной команды:<br><br><b>NET ACCOUNTS \r\n[/FORCELOGOFF:{минуты | NO}] [/MINPWLEN:длина] [/MAXPWAGE:{дни | UNLIMITED}] \r\n[/MINPWAGE:дни] [/UNIQUEPW:число] [/DOMAIN]</b><br><br>Пример отображаемой \r\nинформации по команде NET ACCOUNTS : <br><br><font color="green">Принудительный \r\nвыход по истечении времени через: Никогда<br>Минимальный срок действия пароля \r\n(дней): &nbsp; &nbsp; &nbsp; &nbsp; 0<br>Максимальный срок действия пароля (дней): &nbsp; &nbsp; &nbsp; &nbsp; \r\n42<br>Минимальная длина пароля: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 0<br>Хранение неповторяющихся \r\nпаролей: &nbsp; &nbsp; &nbsp; &nbsp; Нет<br>Блокировка после ошибок ввода пароля: &nbsp; &nbsp; &nbsp; \r\nНикогда<br>Длительность блокировки (минут): &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 30<br>Сброс счетчика \r\nблокировок через (минут): &nbsp; &nbsp; &nbsp; &nbsp; 30<br>Роль компьютера: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; РАБОЧАЯ \r\nСТАНЦИЯ<br><br></font>&nbsp; &nbsp; При использовании в локальной сети, каждый компьютер \r\nможет выполнять как роль сервера (server), предоставляющего свои ресурсы для \r\nсовместного использования, так и рабочей станции (workstation), использующей \r\nразделяемые сетевые ресурсы. Основные настройки сетевых служб сервера и рабочих \r\nстанций можно отобразить с помощью команд:<br><br><b>net config server </b>- \r\nнастройки сетевых служб для роли сервера.<br><b>net config workstation </b>- \r\nнастройки сетевых служб для роли рабочей станции.<br><br>Настройки служб сервера \r\nможно изменить с использованием параметров:<br><br><b>/AUTODISCONNECT:минуты \r\n</b>- максимальное время, в течение которого сеанс пользователя может быть не \r\nактивен, прежде чем соединение будет отключено. Можно использовать значение -1, \r\nкоторое означает, что отключение вообще не производится. Допустимый диапазон \r\nзначений: от -1 до 65535; по умолчанию используется 15.<br>/SRVCOMMENT:"текст" \r\n<br>Добавляет текст комментария для сервера, который отображается на экране \r\nWindows и при выполнении команды NET VIEW. Максимальная длина этого текста \r\nсоставляет 48 знаков. Текст должен быть заключен в кавычки.<br>/HIDDEN:{YES | \r\nNO} Указывает, должно ли выводиться имя данного сервера в списке серверов. \r\nУчтите, что "скрытие" сервера не изменяет параметров доступа к этому серверу. По \r\nумолчанию используется значение NO.<br><b>net config server /SRVCOMMENT:"Игровой \r\nсервер" /AUTODISCONNECT:5</b> - автоотключение при неактивности пользователя - 5 \r\nминут..<br><b>net config server /HIDDEN:YES&gt;/AUTODISCONNECT:-1</b> - \r\nавтоотключение при неактивности пользователя не выполняется, сервер не \r\nотображается в сетевом окружении.<br><br>При выполнении на контроллере домена, \r\nутилита net.exe позволяет добавлять новые компьютеры в базу данных Active \r\nDirectory (AD) или удалять существующие компьютеры из нее. <br><br><b>net \r\ncomputer &#92;&#92;notebook /add </b>- добавить в домен компьютер notebook .<br><b>net \r\ncomputer &#92;&#92;notebook /del </b>- удалить из домена компьютер notebook .<br><br>Для \r\nпросмотра списка групп пользователей и изменения их состава, а также добавления \r\nновых или удаления существующих групп используются команды <b>NET GROUP</b> и \r\n<b>NET LOCALGROUP</b>. Первая из них используется только на контроллерах домена \r\nи предназначена для работы с группами пользователей в домене. <br><br><b>net \r\ngroup </b>- отобразить список групп пользователей в текущем \r\nдомене.<br><br><b>net localgroup </b>- отобразить список групп пользователей \r\nданного компьютера. <br>Синтаксис и назначение параметров этих команд \r\nпрактически не отличаются.<br><br><b>NET LOCALGROUP [имя_группы \r\n[/COMMENT:"текст"]] [/DOMAIN] имя_группы {/ADD /COMMENT:"текст"] | /DELETE} \r\n[/DOMAIN] имя_группы имя [...] {/ADD | /DELETE} [/DOMAIN]</b> \r\n<br><br><b>имя_группы </b>- имя локальной группы, которую необходимо добавить, \r\nизменить или удалить. Если указать только имя группы, то будет выведен список \r\nпользователей или глобальных групп, являющихся членами этой локальной \r\nгруппы.<br><b>/COMMENT:"текст"</b> - комментарий для новой или существующей \r\nгруппы. Текст должен быть заключен в кавычки.<br><b>/DOMAIN </b>- Команда \r\nвыполняется на основном контроллере домена в текущем домене. В противном случае \r\nоперация выполняется на локальном компьютере. <br><b>имя [ ...]</b> - Список из \r\nодного или нескольких имен пользователей, которые необходимо добавить или \r\nудалить из локальной группы. Имена разделяются пробелом. Эти имена могут быть \r\nименами пользователей или глобальных групп, но не именами других локальных \r\nгрупп. Если пользователь зарегистрирован в другом домене, его имени должно \r\nпредшествовать имя домена (например, SALES&#92;RALPHR).<br><b>/ADD </b>- Добавляет \r\nимя группы или имя пользователя в локальную группу. Регистрационная запись для \r\nдобавляемых пользователей или глобальных групп должна быть создана \r\nзаранее.<br><b>/DELETE </b>- Удаляет имя группы или пользователя из локальной \r\nгруппы.<br><br><b>net localgroup Администраторы </b>- отобразить список \r\nпользователей локальной группы <b>Администраторы</b> данного компьютера. \r\n<br><b>net localgroup Администраторы testuser /add </b>- добавление в группу \r\n<b>Администраторы </b>нового пользователя с именем <b>testuser </b><br><b>net \r\nlocalgroup Администраторы testuser /delete </b>- удалить пользователя \r\n<b>testuser</b> из группы <b>Администраторы</b> .<br><br>Для работы с учетными \r\nзаписями пользователей используется команда <b>net user </b><br><br><b>NET USER \r\n[имя_пользователя [пароль | *] [параметры]] [/DOMAIN] имя_пользователя {пароль | \r\n*} /ADD [параметры] [/DOMAIN] имя_пользователя [/DELETE] \r\n[/DOMAIN]</b><br><br><b>имя_пользователя </b>- имя пользователя, которое \r\nнеобходимо добавить, удалить, изменить или вывести на экран. Длина имени \r\nпользователя не должна превосходить 20 знаков.<br><b>пароль</b> - пароль для \r\nучетной записи пользователя. Пароль должен отвечать установленным требованиям на \r\nдлину - быть не короче, чем значение, установленное параметром /MINPWLEN в \r\nкоманде NET ACCOUNTS, и в то же время не длиннее 14 знаков.<br><b>*</b> - \r\nВызывает открытие специальной строки ввода пароля. Пароль не выводится на экран \r\nво время его ввода в этой строке.<br><b>/DOMAIN </b>команда будет выполняться на \r\nконтроллере домена в текущем домене.<br><b>/ADD </b>- добавление нового \r\nпользователя. <br><b>/DELETE </b>- удаление пользователя. <br><b>Параметры </b>- \r\nДопустимые параметры :<br><b>/ACTIVE:{YES | NO} </b>- Активизирует учетную \r\nзапись или делает ее не активной. Если учетная запись не активна, пользователь \r\nне может получить доступ к серверу. По умолчанию используется значение YES (т.е. \r\nучетная запись активна).<br><b>/COMMENT:"текст" </b>- Добавляет описательный \r\nкомментарий об учетной записи (длиной не более 48 знаков). Текст должен быть \r\nзаключен в кавычки. <br><b>/COUNTRYCODE:nnn </b>- Использует кодовую страницу \r\nнужного языка для вывода справки и сообщений об ошибках. Значение 0 означает \r\nвыбор кодовой страницы по умолчанию.<br><b>/EXPIRES:{дата | NEVER} </b>- \r\nУстанавливает дату истечения срока действия ученой записи. Если используется \r\nзначение NEVER, то время действия учетной записи не ограничено. Дата истечения \r\nсрока действия задается в формате дд/мм/гг или мм/дд/гг, в зависимости от того, \r\nкакая кодовая страница используется. Месяц может быть указан цифрами, названием \r\nмесяца или трехбуквенным его сокращением. В качестве разделителя полей должен \r\nиспользоваться знак косой черты (/).<br><b>/FULLNAME:"имя" </b>- Указывает \r\nнастоящее имя пользователя (а не кодовое имя, заданное параметром \r\nимя_пользователя). Настоящее имя следует заключить в \r\nкавычки.<br><b>/HOMEDIR:путь</b> Указывает путь к домашнему каталогу \r\nпользователя. Этот каталог должен существовать.<br><b>/PASSWORDCHG:{YES | NO} \r\n</b>Определяет, может ли пользователь изменять свой пароль. По умолчанию \r\nиспользуется значение YES (т.е. изменение пароля \r\nразрешено).<br><b>/PASSWORDREQ:{YES | NO} </b>Определяет, является ли указание \r\nпароля обязательным. По умолчанию используется значение YES (т.е. пароль \r\nобязателен).<br><b>/PROFILEPATH[:путь] </b>Устанавливает путь к профилю \r\nпользователя.<br><b>/SCRIPTPATH:путь </b>Устанавливает расположение \r\nпользовательского сценария для входа в систему.<br><b>/TIMES:{промежуток | ALL} \r\n</b>- Устанавливает промежуток времени, во время которого пользователю разрешен \r\nвход в систему. Этот параметр задается в следующем \r\nформате:<br>день[-день][,день[-день]],время[-время][,время[-время]]<br>Время \r\nуказывается с точностью до одного часа. Дни являются днями недели и могут \r\nуказываться как в полном, так и в сокращенном виде. Время можно указывать в 12- \r\nи 24-часовом формате. Если используется 12-часовой формат, то можно использовать \r\nam, pm, a.m. или p.m. Значение ALL указывает, что пользователь может войти в \r\nсистему в любое время, а пустое значение указывает, что пользователь не может \r\nвойти в систему никогда. Разделителем полей указания дней недели и времени \r\nявляется запятая, разделителем при использовании нескольких частей является \r\nточка с запятой.<br><b>/USERCOMMENT:"текст" </b>- Позволяет администратору \r\nдобавлять или изменять текст комментария к учетной записи. \r\n<b>/WORKSTATIONS:{имя_компьютера[,...] | *}</b> - Перечисляет до восьми \r\nразличных компьютеров, с которых пользователь может войти в сеть. Если данный \r\nпараметр имеет пустой список или указано значение *, пользователь может войти в \r\nсеть с любого компьютера.<br><br>Примеры использования:<br><br><b>net user </b>- \r\nотобразить список пользователей <br><b>net user /DOMAIN</b> - отобразить список \r\nпользователей текущего домена<br><b>net user VASYA /USERCOMMENT:"Тестовый \r\nпользователь " /add </b>- добавить пользователя с именем <b>VASYA</b><br><b>net \r\nuser VASYA /delete </b>- удалить созданного пользователя.<br><b>net user VASYA \r\npassword /USERCOMMENT:"Тестовый пользователь " /add </b>- создать учетную запись \r\nнового пользователя VASYA с паролем password .<br><b>net user VASYA * \r\n/USERCOMMENT:"Тестовый пользователь " /add </b>- то же, что и в предыдущей \r\nкоманде, но пароь будет запрошен при создании новой учетной записи. <br><b>net \r\nuser VASYA * </b>- изменить пароль существующего пользователя VASYA. Новый \r\nпароль будет запрошен при выполнении команды.<br><b>net user VASYA Boss </b>- \r\nизменить пароль пользователя VASYA на новое значение Boss<br><br>Пример \r\nпоследовательности команд для создания нового пользователя с правами локального \r\nадминистратора:BR&gt;<br><b>net user VASYA Boss /ADD</b> <br>- создание учетной \r\nзаписи.<br><b>net localgroup Администраторы VASYA /ADD </b>- добавление \r\nпользователя в группу "Администраторы" <br><br><br></font>\r\n<center>\r\n<li><font color="blue" size="2">Отправка сообщений по локальной сети \r\n</font></li></center><font size="2"><br><br>&nbsp; &nbsp; Для отправки сообщений в локальной сети используется \r\nкоманда <b>NET SEND </b><br><br><b>NET SEND {имя | * | /DOMAIN[:имя] | /USERS} \r\nсообщение</b> <b>имя </b>- имя пользователя, компьютера или имя для получения \r\nсообщений, на которое отправляется данное сообщение. Если это имя содержит \r\nпробелы, то оно должно быть заключено в кавычки (" "). <br><b>*</b> - отправка \r\nсообщения по всем именам, которые доступны в данный момент.<br><b>/DOMAIN[:имя \r\nдомена]</b> - сообщение будет отправлено по всем именам домена данной рабочей \r\nстанции. Если указано имя домена, то сообщение отправляется по всем именам \r\nуказанного домена или рабочей группы.<br><b>/USERS</b> - сообщение будет \r\nотправлено всем пользователям, подключенным в настоящий момент к \r\nсерверу.<br><b>сообщение</b> - текст отправляемого сообщения.<br><br>Для того, \r\nчтобы получить сообщение, должна быть запущена "Служба сообщений" (MESSENGER). \r\nИмена пользователей, компьютеров и текст сообщений на русском языке должны быть \r\nв DOS-кодировке. <br>Перечень доступных активных имен на данном компьютере и \r\nсостояние службы сообщений можно получить с использованием команды <b>net name \r\n</b>без параметров. По всему списку имен, отображаемому в результате выполнения \r\nданной команды возможна отправка сообщений. Примеры использования:<br><br><b>net \r\nsend VASYA привет! </b>- отправка сообщения на имя VASYA . <br><b>net send * \r\nпривет! </b>- отправка сообщения всем пользователям локальной сети, имена \r\nкоторых можно определить.<br><b>net send /DOMAIN:mydomain Привет </b>- отправка \r\nсообщения всем пользователям в домене mydomain <br><b>net send /USERS Привет! \r\n</b>- отправка сообщений всем пользователям, зарегистрированным службой сервера \r\nданного компьютера. <br></font><font size="2"><br>Утилита NET.EXE позволяет получить статистические данные \r\nпо использованию служб сервера и рабочей станции. Статистика содержит информацию \r\nо сеансах, доступе к сетевым устройствам, объемах принятых и переданных данных, \r\nотказах в доступе и ошибках, обнаруженных в процессе сетевого обмена. \r\n<br><br><b>net statistics server </b>- отобразить статистические данные для \r\nслужбы сервера <br><br><b>net statistics workstation </b>- отобразить \r\nстатистические данные для службы рабочей станции <br><br>Для изменения \r\nсистемного времени компьютера используется команда <b>NET TIME \r\n</b>:<br><br><b>NET TIME [&#92;&#92;компьютер | /DOMAIN[:домен]| /RTSDOMAIN[:домен]] \r\n[/SET] [&#92;&#92;компьютер] /QUERYSNTP [&#92;&#92;компьютер] /SETSNTP[:список серверов \r\nNTP]</b><br><br><b>NET TIME</b> синхронизирует показания часов компьютера с \r\nдругим компьютером или доменом. Если используется без параметров в домене \r\nWindows Server, выводит текущую дату и время дня, установленные на компьютере, \r\nкоторый назначен сервером времени для данного домена. Эта команда позволяет \r\nзадать сервер времени NTP для компьютера. <b>&#92;&#92;компьютер </b>- имя компьютера, \r\nкоторый нужно проверить или с которым нужно синхронизировать показания \r\nчасов.<br><b>/DOMAIN[:домен]</b> Задает домен, с которым нужно синхронизировать \r\nпоказания часов.<br><b>/RTSDOMAIN[:домен] </b>- выполняет синхронизацию времени \r\nс сервером времени (Reliable Time Server) из указанного домена.<br><b>/SET</b> - \r\nСинхронизирует показания часов компьютера со временем указанного компьютера или \r\nдомена.<br><b>/QUERYSNTP</b> - Отображает назначенный этому компьютеру сервер \r\nNTP <b>/SETSNTP[:ntp server list] </b>- задать список серверов времени NTP \r\nдля этого компьютера. Это может быть список IP-адресов или DNS-имен, разделенных \r\nпробелами. Если задано несколько серверов, список должен быть заключен в \r\nкавычки.<br><br><b>net time &#92;&#92;COMPUTER </b>- отобразить время на компьютере \r\nCOMPUTER. Вместо имени компьютера можно использовать его IP-адрес.<br><b>net \r\ntime &#92;&#92;COMPUTER /SET </b>- установить часы текущего компьютера по значению часов \r\nкомпьютера COMPUTER<br><br><b>net time &#92;&#92;COMPUTER /SET /YES </b>- установить \r\nчасы текущего компьютера по значению часов компьютера COMPUTER без запроса \r\nподтверждения. Обычно ключ /YES используется в командных файлах, выполняющихся \r\nбез участия пользователя. <br><br><b>net time /QUERYSNTP </b>- отобразить сервер \r\nвремени, определенный для данного компьютера.<br><b>net time &#92;&#92;COMPUTER \r\n/QUERYSNTP </b>- отобразить сервер времени, определенный для указанного \r\nкомпьютера. <br><b>net time /SETSNTP:"1.ru.pool.ntp.org time.windows.com" </b>- \r\nзадать в качестве NTP-серверов узлы <b>1.ru.pool.ntp.org</b> и \r\n<b>time.windows.com</b><br></font><font size="2"><br>&nbsp; &nbsp; Утилита \r\n<b id="id009">NSLOOKUP</b> присутствует во всех версиях операционных систем Windows и \r\nявляется классическим средством диагностики сетевых проблем, связанных с \r\nразрешением доменных имен в IP-адреса. NSLOOKUP предоставляет пользователю \r\nвозможность просмотра базы данных DNS-сервера и построения определенные \r\nзапросов, для поиска нужных ресурсов DNS. Практически, утилита выполняет функции \r\nслужбы DNS-клиент в командной строке Windows. <br>\r\n<img src="images/nslookup.png" class="center"><br>После запуска, утилита \r\nпереходит в режим ожидания ввода. Ввод символа <b>?</b> или команды <b>help</b> \r\nпозволяет получить подсказку по использованию утилиты.<br><br>Примеры \r\nиспользования:<br><br><b>nslookup</b> - запуск утилиты<br><b>yandex.ru. </b>- \r\nотобразить IP-адрес (а) узла с именем yandex.ru . Точка в конце имени желательна \r\nдля минимизации числа запросов на разрешение имени к серверу DNS. Если \r\nзавершающей точки нет, то NSLOOKUP сначала попытается разрешить указанное имя \r\nкак часть доменного имя компьютера, на котором она запущена. <br><b>server \r\n8.8.4.4 </b>- установить в качестве сервера имен DNS-сервер Google с IP-адресом \r\n8.8.4.4 <br><b>yandex.ru. </b>- повторить запрос с использованием разрешения \r\nимени DNS-сервером Google.<br><b>set type=MX </b>- установить тип записи \r\nMX<br><b>yandex.ru. </b>- отобразить MX-запись для домена yandex.ru - В примере \r\nузел обмена почтой для домена - mx.yandex.ru<br><b>mx.yandex.ru. </b>- \r\nотобразить информацию по mx.yandex.ru<br><b>set type=A </b>- установить тип \r\nзаписи в <b>A </b><br><b>mx.yandex.ru</b> - получить IP-адреса для mx.yandex.ru \r\n.<br><b>exit </b>- завершить работу с nslookup<br><br>Возможно использование \r\nутилиты NSLOOKUP не в интерактивном режиме:<br><br><b>nslookup odnoklassniki.ru \r\n</b>- определить IP-адрес узла odnokassniki.ru с использованием сервера DNS, \r\nзаданного настройками сетевого подключения.<br><b>nslookup odnoklassniki.ru \r\n8.8.8.8</b> - определить IP-адрес узла odnokassniki.ru с использованием \r\nDNS-сервера 8.8.8.8 (публичный DNS-сервер Google) </font><br><center><font size="2"><b><font color="#0000ff">\r\n<h3 id="id10">Утилита PATHPING.EXE</h3></font></b></font></center>\r\n<font size="2">&nbsp; &nbsp; Команда \r\n<b>PATHPING</b> выполняет трассировку маршрута к конечному узлу аналогично \r\nкоманде <b>TRACERT </b>, но дополнительно, выполняет отправку ICMP-эхо запросов \r\nна промежуточные узлы маршрута для сбора информации о задержках и потерях \r\nпакетов на каждом из них. <br>\r\n<img src="images/pathping.png" class="center">\r\n<br>При запуске <b>PATHPING</b> без параметров, \r\nотображается краткая справка:<br><br><b>pathping [-g Список] [-h Число_прыжков] \r\n[-i Адрес] [-n] [-p Пауза] [-q Число_запросов] [-w Таймаут] [-P] [-R] [-T] [-4] \r\n[-6] узел </b><br><br>Параметры:<br><b>-g Список </b>При прохождении по \r\nэлементам списка узлов игнорировать предыдущий маршрут. Максимальное число \r\nадресов в списке равно 9 . Элементы списка помещаются в специальное поле \r\nзаголовка отправляемых ICMP-пакетов.<br><b>-h Число_прыжков </b>- Максимальное \r\nчисло прыжков при поиске узла. Значение по умолчанию - 30<br><b>-i Адрес </b>- \r\nИспользовать указанный адрес источника в отправляемых ICMP-пакетах. <br><b>-n \r\n</b>- Не разрешать адреса в имена узлов.<br><b>-p Пауза </b>- Пауза между \r\nотправками (мсек) пакетов. Значение по умолчанию - 250.<br><b>-q Число_запросов \r\n</b>Число запросов для каждого узла. По умолчанию - 100 <br><b>-w Таймаут </b>- \r\nВремя ожидания каждого ответа (мсек). Значение по умолчанию - 3000 <br><b>-R \r\n</b>- Тестировать возможность использования RSVP ( Reservation Protocol, \r\nпротокола настройки резервирования ресурсов), который позволяет динамически \r\nвыделять ресурсы для различных видов трафика.<br><b>-T </b>- Тестировать на \r\nвозможность использования QoS (Quality of Service - качество обслуживания) - \r\nсистемы обслуживания пакетов разного содержания с учетом их приоритетов доставки \r\nполучателю. <br><b>-4 </b>- Принудительно использовать IPv4.<br><b>-6 </b>- \r\nПринудительно использовать IPv6. <br><br>Практически, <b>PATHPING</b>, \r\nзапущенная на выполнение с параметрами по умолчанию, выполняет те же действия, \r\nчто и команда <b>TRACERT</b> плюс команды <b>PING</b> для каждого промежуточного \r\nузла с указанием числа эхо-запросов, равным 100 (ping -n 100 . . . \r\n)<br><br>Пример результатов выполнения команды <b>pathping yandex.ru \r\n</b>:<br><br><font color="green">Трассировка маршрута к yandex.ru [77.88.21.11] с \r\nмаксимальным числом прыжков 30:<br>1 192.168.1.1 <br>2 180.84.250.11<br>3 \r\n180.84.250.53 <br>4 80.184.112.25 <br>5 msk-ix-m9.yandex.net [193.232.244.93] \r\n<br>6 l3-s900-dante.yandex.net [213.180.213.70] <br>7 s600-s900.yandex.net \r\n[213.180.213.54] <br>8 yandex.ru [77.88.21.11] <br><br>Подсчет статистики за: \r\n200 сек. . . .<br>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Исходный узел &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; \r\nМаршрутный узел<br>Прыжок &nbsp; &nbsp; &nbsp; RTT &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; Утер./Отпр. % &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; Утер./Отпр. \r\n% &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; Адрес<br><br>1 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 1мс &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; \r\n&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; 192.168.1.1<br>&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | <br>2 &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 5мс &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; \r\n180.84.250.11 <br>&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | <br>3 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 11мс &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ \r\n100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 3/ 100 = 3% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; 180.84.250.53 <br></font><font color="red">&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; \r\n&nbsp; &nbsp; 8/ 100 = 8% &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | <br></font><font color="green">4 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 4мс \r\n&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; 80.184.112.25 <br>&nbsp; &nbsp; \r\n&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 0/ 100 = \r\n0% &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | <br>5 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 8мс &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; \r\n0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; msk-ix-m9.yandex.net [193.232.244.93] <br>&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n| <br>6 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 12мс &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; \r\n&nbsp; &nbsp;&nbsp; &nbsp; l3-s900-dante.yandex.net [213.180.213.70] <br>&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | <br>7 &nbsp; \r\n&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 5мс &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; \r\ns600-s900.yandex.net [213.180.213.54] <br>&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | <br>8 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; \r\n&nbsp; &nbsp; &nbsp; 2мс &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 0/ 100 = 0% &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; yandex.ru \r\n[77.88.21.11] </font><br><br>В приведенном примере красным цветом выделен \r\nпроблемный участок маршрута к конечному узлу с потерей 8% пакетов. <br>При \r\nинтерпретации результатов выполнения <b>pathping</b> нужно учитывать тот факт, \r\nчто некоторые маршрутизаторы могут быть настроены на блокировку icmp-трафика, \r\nчто не позволяет правильно отработать трассировку, и получить по ним \r\nстатистические данные. <br><br><br><br><b>\r\n</b><br><br>&nbsp; &nbsp; <b id="id11">PING.EXE</b> \r\n- это, наверно, наиболее часто используемая сетевая утилита командной строки. \r\nСуществует во всех версиях всех операционных систем с поддержкой сети и является \r\nпростым и удобным средством опроса узла по имени или его IP-адресу.<br>\r\n<img src="images/ping.png" class="center"><br>Для \r\nобмена служебной и диагностической информацией в сети используется специальный \r\nпротокол управляющих сообщений <b>ICMP</b> (Internet Control Message Protocol). \r\nКоманда <b>ping </b>позволяет выполнить отправку управляющего сообщения типа \r\n<b>Echo Request</b> (тип равен 8 и указывается в заголовке сообщения) \r\nадресуемому узлу и интерпретировать полученный от него ответ в удобном для \r\nанализа виде. В поле данных отправляемого icmp-пакета обычно содержатся символы \r\nанглийского алфавита. В ответ на такой запрос, опрашиваемый узел дожжен \r\nотправить icmp-пакет с теми же данными, которые были приняты, и типом сообщения \r\n<b>Echo Reply</b> (код типа в заголовке равен 0) . Если при обмене \r\nicmp-сообщениями возникает какая-либо проблема, то утилита ping выведет \r\nинформацию для ее диагностики.<br><br>Формат командной строки:<br><br><b>ping \r\n[-t] [-a] [-n число] [-l размер] [-f] [-i TTL] [-v TOS] [-r число] [-s число] \r\n[[-j списокУзлов] | [-k списокУзлов]] [-w таймаут] \r\nконечноеИмя</b><br><br>Параметры:<br><br><b>-t </b>- Непрерывная отправка \r\nпакетов. Для завершения и вывода статистики используются комбинации клавиш \r\n+ (вывод статистики), и + (вывод статистики и \r\nзавершение).<br><b>-a </b>- Определение адресов по именам узлов. <b>-n число \r\n</b>- Число отправляемых эхо-запросов.<br><b>-l размер </b>- Размер поля данных \r\nв байтах отправляемого запроса.<br><b>-f </b>- Установка флага, запрещающего \r\nфрагментацию пакета.<br><b>-i TTL </b>- Задание срока жизни пакета (поле "Time \r\nTo Live").<br><b>-v TOS </b>- Задание типа службы (поле "Type Of \r\nService").<br><b>-r число </b>- Запись маршрута для указанного числа \r\nпереходов.<br><b>-s число </b>- Штамп времени для указанного числа \r\nпереходов.<br><b>-j списокУзлов </b>- Свободный выбор маршрута по списку \r\nузлов.<br><b>-k списокУзлов </b>- Жесткий выбор маршрута по списку \r\nузлов.<br><b>-w таймаут </b>- Максимальное время ожидания каждого ответа в \r\nмиллисекундах.<br><br>Примеры использования:<br><br><b>ping 8.8.8.8 </b>- \r\nвыполнить опрос узла с IP-адресом 8.8.8.8 с параметрами по умолчанию.<br><b>ping \r\n-t yandex.ru</b> - выполнять ping до нажатия комбинации CTRL-C, При нажатии \r\nCTRL-Break - выдается статистика и опрос узла продолжается<br>ping -n 1000 -l \r\n500 192.168.1.1 - выполнить ping 1000 раз с использованием сообщений, длиной 500 \r\nбайт.<br>ping -a -n 1 -r 9 -w 1000 yandex.ru - выполнить ping 1 раз (ключ -n 1), \r\nопределять адрес по имени (ключ -a), выдавать маршрут для первых 9 переходов (-r \r\n9), ожидать ответ 1 секунду (1000мсек) <br><br>Использование ключа <b>-r</b> \r\nпозволяет получить трассировку маршрута, аналогичную получаемой с помощью \r\nкоманды tracert, но число промежуточных узлов не может превышать 9 . \r\n<br><b></b></font><center><font size="2"><b><font color="#0000ff">\r\n<h3 id="id12">Утилита ROUTE.EXE</h3></font></b></font></center><font size="2"><br><br>&nbsp; &nbsp; Утилита \r\n<b>ROUTE.EXE</b> используется для просмотра и модификации таблицы маршрутов на \r\nлокальном компьютере. При запуске без параметров, на экран выводится подсказка \r\nпо использованию <b>route</b>:<br>\r\n<img src="images/route.png" class="center"><br><b>route [-f] [-p] [команда \r\n[конечная_точка] [mask маска_сети] [шлюз] [metric метрика]] [if интерфейс]]</b> \r\n<br><br><b>-f </b>- используется для сброса таблицы маршрутизации. При \r\nвыполнении команды <b>route -f </b>из таблицы удаляются все маршруты, которые не \r\nотносятся к петлевому интерфейсу (IP 127.0.0.1 маска -255.0.0.0), не являются \r\nмаршрутами для многоадресной (multicast) рассылки (IP 224.0.0.1 маска 255.0.0.0) \r\nи не являются узловыми маршрутами (маска равна 255.255.255.255) . <br><br><b>-p \r\n</b>- используется для добавления в таблуцу постоянного маршрута. Если маршрут \r\nдобавлен без использования параметра <b>-p</b> то он сохраняется только до \r\nперезагрузки системы (до перезапуска сетевого системного программного \r\nобеспечения). Если же, при добавлении маршрута искользовался данный параметр, то \r\nинформация о маршруте записывается в реестр Windows (раздел \r\nHKLM&#92;SYSTEM&#92;CurrentControlSet&#92;Services&#92;Tcpip&#92;Parameters&#92;PersistentRoutes ) и \r\nбудет использоваться постоянно при активации сетевых \r\nинтерфейсов.<br><br><b>команда </b>- козможно использование команд <b>add </b>- \r\nдобавление маршрута, <b>change </b>- изменение существующего маршрута, \r\n<b>delete</b> - удаление маршрута или маршрутов, <b>print</b> - отображение \r\nтекущей таблицы маршрутов<br><br><b>конечная_точка </b>- IP-адрес, адрес сети \r\nили адрес 0.0.0.0 для шлюза по умолчанию. <br><br><b>mask маска_сети </b>- маска \r\nсети. <br><br><b>шлюз </b>- IP-адрес шлюза, через который будет выполняться \r\nотправка пакета для достижения конечной точки. <br><br><b>metric число </b>- \r\nзначение метрики (1-9999). Метрика представляет собой числовое значение, \r\nпозволяющее оптимизировать доставку пакета получателю, если конечная точка \r\nмаршрута может быть достижима по нескольким разным маршрутам. Чем меньше \r\nзначение метрики, тем выше приоритет маршрута. <br><br><b>if интерфейс </b>- \r\nидентификатор сетевого интерфейса. Может задаваться в виде десятичного или \r\nшестнадцатеричного числа. Посмотреть идентификаторы можно с помщью команды \r\n<b>route print</b> <br><br>Примеры : <br><br><b>route print</b> - отобразить \r\nтекущую таблицу маршрутов<br><br><b>route print 192.*</b> - отобразить таблицу \r\nмаршрутов только для адресов, начинающихся с 192. <br><br><b>route add 0.0.0.0 \r\nmask 0.0.0.0 192.168.1.1 </b>- установить в качестве шлюза по умолчанию \r\n(основного шлюза) адрес 192.168.1.1<br><br><b>route -p add 10.0.0.0 mask \r\n255.0.0.0 10.0.0.1 </b>- добавить маршрут для подсети 10.0.0.0/255.0.0.0 и \r\nзапомнить его в реестре . Постоянный статический маршрут.<br><br><b>route delete \r\n10.0.0.0 mask 255.0.0.0 </b>- удалить маршрут для подсети 10.0.0.0/255.0.0.0 \r\n.<br><br><b>route add 10.10.10.10 192.168.1.158 </b>- добавить маршрут для узла \r\nс IP-адресом 10.10.10.10 . Если маска в команде не задана, то подразумевается ее \r\nзначение равное 255.255.255.255 , т.е конечная точка назначения является \r\nодиночным IP-адресом узла.<br><br><b>route delete 10.10.10.10 </b>- удалить \r\nмаршрут созданный предыдущей командой <br><br><b>route change 10.0.0.0 mask \r\n255.0.0.0 10.10.10.1</b> - изменить адрес перехода для существующего маршрута к \r\nсети 10.0.0.0/255.0.0.0 на значение 10.10.10.1<br><br><b>route -f </b>- очистить \r\nтаблицу маршрутов. После перезагрузки системы, или при перезапуске сетевых \r\nподключений таблица маршрутов будет восстановлена исходя из текущей сетевой \r\nконфигурации компьютера.</font></li>\r\n<li><font size="2" id="id13"><br>&nbsp; &nbsp; На заре \r\nразвития сети Интернет, сервис TELNET был основным средством удаленной работы \r\nпользователей, реализующим взаимодействие терминала с процессом на удаленном \r\nкомпьютере. На сегодняшний день, TELNET, в основном, используется как средство \r\nудаленного администрирования специализированных сетевых устройств. Сервис TELNET \r\nвходит в состав практически всех сетевых операциооных систем и реализован в виде \r\nпрограммного обеспечения сервера Telnet и клиентской оболочки с текстовым или \r\nграфическим интерфейсом. Подключившись к серверу, удаленный пользователь \r\nполучает доступ к командной строке, поддерживаемой сервером, таким же образом, \r\nкак если-бы он работал с локальным терминалом. Утилита TELNET работает поверх \r\nпротокола TCP и позволяет пользователю подключиться к удаленному узлу не только \r\nна стандартный порт 23, но и на любой другой TCP-порт, тем самым, позволяя \r\nвзаимодействовать с любым приложением, управляемым командной строкой. Так, \r\nнапример, с использованием утилиты <b>telnet</b> можно подключиться к серверам, \r\nподдерживающим текстовый (telnet-like) ввод команд и данных - SMTP, POP3, IMAP и \r\nт.п. Кроме этого, утилиту можно использовать в качестве средства грубой проверки \r\nвозможности подключения на любой TCP-порт (проверки слушается ли определенный \r\nпорт TCP). <br><img src="images/bsdtelnet.png" class="center"><br>При запуске TELNET.EXE без параметров, программа переходит в \r\nинтерактивный режим, ожидая ввода команд пользователем. Для получения списка \r\nдоступных команд используется ввод знака вопроса или <b>/h</b> . Набор доступных \r\nкоманд может отличаться для разных версий <b>telnet</b>, но всегда будут \r\nприсутствовать команды подключения к удаленному узлу (<b>open </b>), закрытия \r\nсуществующего подключения (<b>close </b>), установки (<b>set </b>) и сброса \r\n(<b>unset</b> параметров. <br><br><b>set ? </b>- отобразить текущие параметры \r\nсессии. Отображаются параметры, связанные с эмуляцией терминала, режима \r\nотображения вводимых символов (локального эха), интерпретацией управляющих \r\nпоследовательностей символов, способа аутентификации. <br><br><b>open \r\n192.168.1.1 </b>- подключиться к серверу TELNET узла 192.168.1.1<br><br><b>open \r\n192.168.1.1 25</b> - подключиться к серверу, слушающему порт 25/TCP узла \r\n192.168.1.1<br><br>После подключения к удаленному серверу, вводимые с клавиатуры \r\nсимволы, будут передаваться на обработку удаленной системе и, для возврата в \r\nкомандную строку <b>telnet </b>, требуется ввод специальной комбинации клавиш \r\nпереключения режима (Escape character) - по умолчанию это <b>CTRL-]</b> . Для \r\nвыхода из telnet используется команда <b>quit</b>. <br><br>На практике, как \r\nправило, используется запуск telnet с параметрами по умолчанию и с указанием \r\nимени или IP-адреса и номера порта TCP удаленной системы.<br><br><b>telnet \r\n192.168.1.1 </b>- подключиться к серверу telnet узла 192.168.1.1 \r\n<br><br><b>telnet yandex.ru 80 </b>- подключиться к серверу HTTP (TCP порт 80) \r\nузла yandex.ru <br><br>Если подключение невозможно, то утилита <b>telnet \r\n</b>завершится сообщением:<br><br><font color="green">Не удалось открыть \r\nподключение к этому узлу на порт . . . Сбой подключения. <br><br></font>Если имя \r\nили IP-адрес в командной строке достижимы, то такое сообщение говорит о том, что \r\nзаданный порт не слушается удаленной системой ( или закрыт брандмауэром) . Если \r\nже удаленная система не поддерживает текстовое (telnet-like) управление, то, как \r\nправило, соединение устанавливается, экран терминала остается пустым, и после \r\nнажатия любой клавиши, сессия может завершиться, но сообщения о сбое соединения \r\nне будет. В некоторых случаях, удаленный сервер, не поддерживающий \r\nтелнетоподобный протокол может выдать баннер, отображая информацию о себе, как \r\nнапример, это делают серверы VNC, отбражая версию протокола RFB. Примеры \r\nиспользования telnet для отправки простого e-mail сообщения имеются <a href="http://ab57.ru/mail.html" target="_blsnk">в этой статье </a><br><br>В \r\nоперационных системах Windows 7, Windows Server 2008,Windows Server 2008 R2, для \r\nуправлением службой TELNET на локальном или удаленном компьютере можно \r\nвоспользоваться специальной утилитой tlntadmn, позволяющей запустить, \r\nприостановить, остановить или продолжить работу сервера TELNET, а также \r\nнастроить некоторые параметры его конфигурации. <br><br></font><center><font size="2"><b><font color="#0000ff">\r\n\r\n<h3 id="id14">Утилита TRACERT.EXE</h3></font></b></font></center><font size="2"><br>&nbsp; &nbsp; Не смотря на \r\nпоявление утилиты <b>PATHPIG</b>, классическая утилита трассировки маршрута до \r\nзаданного узла <b>TRACERT </b>, по-прежнему остается наиболее часто используемым \r\nинструментом сетевой диагностики. Утилита позволяет получить цепочку узлов, \r\nчерез которые проходит IP-пакет, адресованный конечному узлу. В основе \r\nтрассировки заложен метод анализа ответов при последоательной отправке \r\nICMP-пакетов на указанный адрес с увеличивающимся на 1 полем TTL. ("Время жизни" \r\n- Time To Live). На самом деле это поле не имеет отношения к времени, а является \r\nсчетчиком числа возможных переходов при передаче маршрутизируемого пакета. \r\nКаждый маршрутизатор, получив пакет, вычитает из этого поля 1 и проверяет \r\nзначение счетчика TTL. Если значение стало равным нулю, такой пакет \r\nотбрасывается и отправителю посылается ICMP-сообщение о превышении времени жизни \r\n("Time Exceeded" - значение 11 в заголовке ICMP). Если бы не было предусмотрено \r\nвключение поля TTL в IP пакеты, то при ошибках в маршрутах, могда бы возникнуть \r\nситуация, когда пакет будет вечно циркулировать в сети, пересылаемый \r\nмаршрутизаторами по кругу. &nbsp; &nbsp; При выполнении команды tracert.exe сначала \r\nвыполняется отправка ICMP пакета с полем TTL равным <b>1</b> и первый в цепочке \r\nмаршрутизатор (обычно это основной шлюз из настроек сетевого подключения) вычтя \r\nединицу из TTL получает его нулевое значение и сообщает о превышении времени \r\nжизни. Эта последовательность повторяется трижды, поэтому в строке результата, \r\nформируемой tracert.exe, после номера перехода отображаются три значения времени \r\nотклика:<br><font color="blue">1 &nbsp; &nbsp; 1 ms &nbsp; &nbsp; &lt;1 &nbsp; &nbsp; &lt;1 &nbsp; &nbsp; 192.168.1.1 \r\n<br></font>1 - номер перехода (1 - первый маршрутизатор)<br>1 ms &lt;1 &lt;1 - \r\nвремя его ответа для 3-х попыток (1ms и 2 ответа менее чем 1 ms)<br>192.168.1.1 \r\n- его адрес (или имя)<br><br>&nbsp; &nbsp; Затем процедура повторяется, но TTL \r\nустанавливается равным <b>2</b> - первый маршрутизатор его уменьшит до 1 и \r\nотправит следующему в цепочке, который после вычитания 1 обнулит TTL и сообщит о \r\nпревышении времени жизни. И так далее, пока не будет достигнут заданный узел, \r\nимя или адрес которого заданы в качестве параметра командной строки, например , \r\n<b>tracert yandex.ru </b>, или до обнаружения неисправности, не позволяющей \r\nдоставить пакет узлу yandex.ru.<br><br>Пример результатов выполнения <b>tracert \r\nvk.com \r\n</b>\r\n<br>\r\n<img src="images/tracert.png" class="center"><br>\r\n<b>tracert google.com</b> - трассировка маршрута к узлу \r\ngoogle.com<br><br>Результат:<br><br><font color="green"><br>Трассировка маршрута к \r\ngoogle.com [74.125.45.100] с максимальным числом прыжков 30:<br>1 1 ms &lt;1 \r\n&lt;1 192.168.1.1 <br>2 498 ms 444 ms 302 ms ppp83-237-220-1.pppoe.mtu-net.ru \r\n[83.237.220.1] <br>3 * * * .<br>4 282 ms * * \r\na197-crs-1-be1-53.msk.stream-internet.net [212.188.1.113] <br>5 518 ms 344 ms \r\n382 ms ss-crs-1-be5.msk.stream-internet.net [195.34.59.105] <br>6 462 ms 440 ms \r\n335 ms m9-cr01-po3.msk.stream-internet.net [195.34.53.85] <br>7 323 ms 389 ms \r\n339 ms bor-cr01-po4.spb.stream-internet.net [195.34.53.126] <br>8 475 ms 302 ms \r\n420 ms anc-cr01-po3.ff.stream-internet.net [195.34.53.102] <br>9 334 ms 408 ms \r\n348 ms 74.125.50.57 <br>10 451 ms 368 ms 524 ms 209.85.255.178 <br>11 329 ms 542 \r\nms 451 ms 209.85.250.140 <br>12 616 ms 480 ms 645 ms 209.85.248.81 <br>13 656 ms \r\n549 ms 422 ms 216.239.43.192 <br>14 378 ms 560 ms 534 ms 216.239.43.113 <br>15 \r\n511 ms 566 ms 546 ms 209.85.251.9 <br>16 543 ms 682 ms 523 ms 72.14.232.213 \r\n<br>17 468 ms 557 ms 486 ms 209.85.253.141 <br>18 593 ms 589 ms 575 ms \r\nyx-in-f100.google.com [74.125.45.100] <br><br>Трассировка \r\nзавершена.<br></font><br>&nbsp; &nbsp; В результатах трассировки могут присутствовать \r\nстроки, где вместо адреса узла отображается звездочка (узел номер 3 в примере). \r\nЭто не обязательно является признаком неисправности маршрутизатора, и чаще \r\nвсего, говорит о том, что настройки данного узла запрещают ICMP-протокол из \r\nсоображений безопасности или уменьшения нагрузки на канал . Подобные же \r\nнастройки используются в сетях корпорации Microsoft . <br></font> </li></td></tr></tbody></table> <br />\r\n\r\n</div>\r\n');
INSERT INTO `inform` (`№`, `tema`, `content`) VALUES
(4, 'Socket', '\r\n<div>\r\n\r\n<H3>Лабораторная работа 2: Socket.</H3>\r\n<hr>\r\n<p class=MsoNormal>Программы-сервлеты, прослушивающие свои порты, работают под\r\nуправлением операционной системы. У машин-серверов могут быть самые разные\r\nоперационные системы, особености которых передаются програмам-серверам. </p>\r\n\r\n<p class=MsoNormal>Чтобы сгладить различия в реализации разных серверов, между\r\nсервером и портом введен промежуточный програмный слой, названный <b\r\nstyle="mso-bidi-font-weight:normal">сокетом </b>(<span lang=EN-US\r\nstyle="mso-ansi-language:EN-US">socket</span>). Английское слово <span\r\nlang=EN-US style="mso-ansi-language:EN-US">socket</span> переводится как\r\nэлектрический разьем, розетка. Так же как к электророзетке при помощи вилки\r\nможно подключить любой электроприбор, к сокету можно присоединить любой клиент,\r\nлишь бы он работал по тому же протоколу, что и сервер. Каждый <b\r\nstyle="mso-bidi-font-weight:normal">сокет связан с одним портом</b>, говорят,\r\nчто сокет <b style="mso-bidi-font-weight:normal">прослушивает</b> порт. </p>\r\n\r\n<p class=MsoNormal>Соединение с помощью сокетов устанавливается так:</p>\r\n\r\n<p class=MsoListParagraphCxSpFirst style="text-indent:-18.0pt;mso-list:l0 level1 lfo1"><![if !supportLists]><span\r\nstyle="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:\r\nSymbol"><span style="mso-list:Ignore">·<span style="font:7.0pt Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]>Сервер создает сокет, прослушивающий порт\r\nсервера.</p>\r\n\r\n<p class=MsoListParagraphCxSpMiddle style="text-indent:-18.0pt;mso-list:l0 level1 lfo1"><![if !supportLists]><span\r\nstyle="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:\r\nSymbol"><span style="mso-list:Ignore">·<span style="font:7.0pt Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]>Клиент тоже создает сокет, через который\r\nсвязывается с сервером, сервер начинает устанавливать связь с клиентом.</p>\r\n\r\n<p class=MsoListParagraphCxSpMiddle style="text-indent:-18.0pt;mso-list:l0 level1 lfo1"><![if !supportLists]><span\r\nstyle="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:\r\nSymbol"><span style="mso-list:Ignore">·<span style="font:7.0pt Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]>Устанавливая связь, сервер создает новый сокет,\r\nпрослушивающий порт с другим, новым номером, и сообщает этот номер клиенту.</p>\r\n\r\n<p class=MsoListParagraphCxSpLast style="text-indent:-18.0pt;mso-list:l0 level1 lfo1"><![if !supportLists]><span\r\nstyle="font-family:Symbol;mso-fareast-font-family:Symbol;mso-bidi-font-family:\r\nSymbol"><span style="mso-list:Ignore">·<span style="font:7.0pt Times New Roman">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]>Клиент посылает запрос на сервер через порт с\r\nновым номером.</p>\r\n\r\n<p class=MsoNormal>После этого соединение становится совершенно симметричным –\r\nдва сокета обмениваются информацией, а сервер через старый сокет продолжает\r\nпрослушивать прежний порт, ожидая следующего клиента.</p>\r\n\r\n\r\n\r\n\r\n\r\n\r\n<div style="float: left; white-space: pre; line-height: 1; background: #FFFFFF; "><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">io</span><span class="sc10">.</span><span class="sc11">BufferedReader</span><span class="sc10">;</span><span class="sc0">\r\n</span><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">io</span><span class="sc10">.</span><span class="sc11">InputStreamReader</span><span class="sc10">;</span><span class="sc0">\r\n</span><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">io</span><span class="sc10">.</span><span class="sc11">OutputStreamWriter</span><span class="sc10">;</span><span class="sc0">\r\n</span><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">io</span><span class="sc10">.</span><span class="sc11">PrintWriter</span><span class="sc10">;</span><span class="sc0">\r\n</span><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">net</span><span class="sc10">.</span><span class="sc11">Socket</span><span class="sc10">;</span><span class="sc0">\r\n</span><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">util</span><span class="sc10">.</span><span class="sc11">StringTokenizer</span><span class="sc10">;</span><span class="sc0">\r\n\r\n</span><span class="sc16">public</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0"> </span><span class="sc11">Client</span><span class="sc0"> </span><span class="sc10">{</span><span class="sc0">\r\n\r\n    </span><span class="sc16">public</span><span class="sc0"> </span><span class="sc16">static</span><span class="sc0"> </span><span class="sc16">void</span><span class="sc0"> </span><span class="sc11">main</span><span class="sc10">(</span><span class="sc11">String</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">args</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc10">{</span><span class="sc0">\r\n        </span><span class="sc5">if</span><span class="sc10">(</span><span class="sc11">args</span><span class="sc10">.</span><span class="sc11">length</span><span class="sc10">!=</span><span class="sc4">3</span><span class="sc10">)</span><span class="sc0">\r\n        </span><span class="sc10">{</span><span class="sc0">\r\n            </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">err</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"Касяк в веденом адресе."</span><span class="sc10">);</span><span class="sc0">\r\n            </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">exit</span><span class="sc10">(</span><span class="sc4">0</span><span class="sc10">);</span><span class="sc0">\r\n        </span><span class="sc10">}</span><span class="sc0">\r\n        </span><span class="sc11">String</span><span class="sc0"> </span><span class="sc11">host</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">args</span><span class="sc10">[</span><span class="sc4">0</span><span class="sc10">];</span><span class="sc0">\r\n        </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"host:"</span><span class="sc10">+</span><span class="sc11">host</span><span class="sc10">);</span><span class="sc0">\r\n\r\n        </span><span class="sc16">int</span><span class="sc0"> </span><span class="sc11">port</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">Integer</span><span class="sc10">.</span><span class="sc11">parseInt</span><span class="sc10">(</span><span class="sc11">args</span><span class="sc10">[</span><span class="sc4">1</span><span class="sc10">]);</span><span class="sc0">\r\n        </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"port:"</span><span class="sc10">+</span><span class="sc11">port</span><span class="sc10">);</span><span class="sc0">\r\n\r\n        </span><span class="sc11">String</span><span class="sc0"> </span><span class="sc11">file</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">args</span><span class="sc10">[</span><span class="sc4">2</span><span class="sc10">];</span><span class="sc0">\r\n        </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"file:"</span><span class="sc10">+</span><span class="sc11">file</span><span class="sc10">);</span><span class="sc0">\r\n\r\n        </span><span class="sc5">try</span><span class="sc10">{</span><span class="sc0">\r\n            </span><span class="sc11">Socket</span><span class="sc0"> </span><span class="sc11">sock</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">Socket</span><span class="sc10">(</span><span class="sc11">host</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc11">port</span><span class="sc10">);</span><span class="sc0">\r\n            </span><span class="sc11">PrintWriter</span><span class="sc0"> </span><span class="sc11">pw</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">PrintWriter</span><span class="sc10">(</span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">OutputStreamWriter</span><span class="sc10">(</span><span class="sc11">sock</span><span class="sc10">.</span><span class="sc11">getOutputStream</span><span class="sc10">()),</span><span class="sc0"> </span><span class="sc5">true</span><span class="sc10">);</span><span class="sc0">\r\n            </span><span class="sc11">pw</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"POST "</span><span class="sc0"> </span><span class="sc10">+</span><span class="sc0"> </span><span class="sc11">file</span><span class="sc0"> </span><span class="sc10">+</span><span class="sc0"> </span><span class="sc6">" HTTP/1.1\n"</span><span class="sc10">);</span><span class="sc0">\r\n            </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"POST "</span><span class="sc0"> </span><span class="sc10">+</span><span class="sc0"> </span><span class="sc11">file</span><span class="sc0"> </span><span class="sc10">+</span><span class="sc0"> </span><span class="sc6">" HTTP/1.1\n"</span><span class="sc10">);</span><span class="sc0">\r\n\r\n            </span><span class="sc11">BufferedReader</span><span class="sc0"> </span><span class="sc11">br</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">BufferedReader</span><span class="sc10">(</span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">InputStreamReader</span><span class="sc10">(</span><span class="sc11">sock</span><span class="sc10">.</span><span class="sc11">getInputStream</span><span class="sc10">()));</span><span class="sc0">\r\n\r\n            </span><span class="sc11">String</span><span class="sc0"> </span><span class="sc11">line</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">null</span><span class="sc10">;</span><span class="sc0">\r\n            </span><span class="sc11">line</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">br</span><span class="sc10">.</span><span class="sc11">readLine</span><span class="sc10">();</span><span class="sc0">\r\n            </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"line:"</span><span class="sc10">+</span><span class="sc11">line</span><span class="sc10">);</span><span class="sc0">\r\n\r\n            </span><span class="sc11">StringTokenizer</span><span class="sc0"> </span><span class="sc11">st</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">StringTokenizer</span><span class="sc10">(</span><span class="sc11">line</span><span class="sc10">);</span><span class="sc0">\r\n            </span><span class="sc11">String</span><span class="sc0"> </span><span class="sc11">code</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">null</span><span class="sc10">;</span><span class="sc0">\r\n\r\n            </span><span class="sc5">if</span><span class="sc0"> </span><span class="sc10">((</span><span class="sc11">st</span><span class="sc10">.</span><span class="sc11">countTokens</span><span class="sc10">()&gt;=</span><span class="sc4">2</span><span class="sc10">)&amp;&amp;</span><span class="sc11">st</span><span class="sc10">.</span><span class="sc11">nextToken</span><span class="sc10">().</span><span class="sc11">equals</span><span class="sc10">(</span><span class="sc6">"POST"</span><span class="sc10">))</span><span class="sc0">\r\n            </span><span class="sc10">{</span><span class="sc0">\r\n                </span><span class="sc5">if</span><span class="sc0"> </span><span class="sc10">((</span><span class="sc11">code</span><span class="sc10">=</span><span class="sc11">st</span><span class="sc10">.</span><span class="sc11">nextToken</span><span class="sc10">())!=</span><span class="sc6">"200"</span><span class="sc10">)</span><span class="sc0">\r\n                </span><span class="sc10">{</span><span class="sc0">\r\n                    </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">err</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"Файл не найден, код ошибки "</span><span class="sc10">+</span><span class="sc11">code</span><span class="sc10">);</span><span class="sc0">\r\n                    </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">exit</span><span class="sc10">(</span><span class="sc4">0</span><span class="sc10">);</span><span class="sc0">\r\n                </span><span class="sc10">}</span><span class="sc0">\r\n            </span><span class="sc10">}</span><span class="sc0">\r\n\r\n            </span><span class="sc5">while</span><span class="sc0"> </span><span class="sc10">((</span><span class="sc11">line</span><span class="sc10">=</span><span class="sc11">br</span><span class="sc10">.</span><span class="sc11">readLine</span><span class="sc10">())!=</span><span class="sc5">null</span><span class="sc10">)</span><span class="sc0">\r\n                </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc11">line</span><span class="sc10">);</span><span class="sc0">\r\n\r\n            </span><span class="sc11">sock</span><span class="sc10">.</span><span class="sc11">close</span><span class="sc10">();</span><span class="sc0">\r\n\r\n        </span><span class="sc10">}</span><span class="sc5">catch</span><span class="sc0"> </span><span class="sc10">(</span><span class="sc11">Exception</span><span class="sc0"> </span><span class="sc11">e</span><span class="sc10">){</span><span class="sc0">\r\n            </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">err</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"Вылет в блоке проверки: "</span><span class="sc0"> </span><span class="sc10">+</span><span class="sc0"> </span><span class="sc11">e</span><span class="sc10">);</span><span class="sc0">\r\n        </span><span class="sc10">}</span><span class="sc0">\r\n\r\n\r\n    </span><span class="sc10">}</span><span class="sc0">\r\n\r\n\r\n\r\n</span><span class="sc10">}</span><span class="sc0">\r\n</span>\r\n<div style="mso-element:para-border-div;border:none;border-bottom:solid windowtext 1.5pt;\r\npadding:0cm 0cm 1.0pt 0cm"></div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<div style="float: left; white-space: pre; line-height: 1; background: #FFFFFF; "><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">io</span><span class="sc10">.*;</span><span class="sc0">\r\n</span><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">net</span><span class="sc10">.</span><span class="sc11">Socket</span><span class="sc10">;</span><span class="sc0">\r\n</span><span class="sc5">import</span><span class="sc0"> </span><span class="sc11">java</span><span class="sc10">.</span><span class="sc11">util</span><span class="sc10">.</span><span class="sc11">StringTokenizer</span><span class="sc10">;</span><span class="sc0">\r\n\r\n</span><span class="sc16">public</span><span class="sc0"> </span><span class="sc16">class</span><span class="sc0"> </span><span class="sc11">HttpConnect</span><span class="sc0"> </span><span class="sc5">extends</span><span class="sc0"> </span><span class="sc11">Thread</span><span class="sc0">\r\n</span><span class="sc10">{</span><span class="sc0">\r\n\r\n    </span><span class="sc16">private</span><span class="sc0"> </span><span class="sc11">Socket</span><span class="sc0"> </span><span class="sc11">sock</span><span class="sc10">;</span><span class="sc0">\r\n\r\n    </span><span class="sc11">HttpConnect</span><span class="sc10">(</span><span class="sc11">Socket</span><span class="sc0"> </span><span class="sc11">s</span><span class="sc10">){</span><span class="sc0">\r\n        </span><span class="sc11">sock</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">s</span><span class="sc10">;</span><span class="sc0">\r\n        </span><span class="sc11">setPriority</span><span class="sc10">(</span><span class="sc11">NORM_PRIORITY</span><span class="sc0"> </span><span class="sc10">-</span><span class="sc0"> </span><span class="sc4">1</span><span class="sc10">);</span><span class="sc0">\r\n        </span><span class="sc11">start</span><span class="sc10">();</span><span class="sc0">\r\n    </span><span class="sc10">}</span><span class="sc0">\r\n\r\n    </span><span class="sc16">public</span><span class="sc0"> </span><span class="sc16">void</span><span class="sc0"> </span><span class="sc11">run</span><span class="sc10">(){</span><span class="sc0">\r\n        </span><span class="sc5">try</span><span class="sc10">{</span><span class="sc0">\r\n            </span><span class="sc11">PrintWriter</span><span class="sc0"> </span><span class="sc11">pw</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">PrintWriter</span><span class="sc10">(</span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">OutputStreamWriter</span><span class="sc10">(</span><span class="sc11">sock</span><span class="sc10">.</span><span class="sc11">getOutputStream</span><span class="sc10">()),</span><span class="sc0"> </span><span class="sc5">true</span><span class="sc10">);</span><span class="sc0">\r\n            </span><span class="sc11">BufferedReader</span><span class="sc0"> </span><span class="sc11">br</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">BufferedReader</span><span class="sc10">(</span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">InputStreamReader</span><span class="sc10">(</span><span class="sc11">sock</span><span class="sc10">.</span><span class="sc11">getInputStream</span><span class="sc10">()));</span><span class="sc0">\r\n\r\n            </span><span class="sc11">String</span><span class="sc0"> </span><span class="sc11">req</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">null</span><span class="sc10">;</span><span class="sc0">\r\n            </span><span class="sc11">req</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">br</span><span class="sc10">.</span><span class="sc11">readLine</span><span class="sc10">();</span><span class="sc0">\r\n            </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"Request: "</span><span class="sc10">+</span><span class="sc11">req</span><span class="sc10">);</span><span class="sc0">\r\n\r\n            </span><span class="sc11">StringTokenizer</span><span class="sc0"> </span><span class="sc11">st</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">StringTokenizer</span><span class="sc10">(</span><span class="sc11">req</span><span class="sc10">);</span><span class="sc0">\r\n\r\n            </span><span class="sc5">if</span><span class="sc10">((</span><span class="sc11">st</span><span class="sc10">.</span><span class="sc11">countTokens</span><span class="sc10">()&gt;=</span><span class="sc4">2</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc10">&amp;&amp;</span><span class="sc0"> </span><span class="sc11">st</span><span class="sc10">.</span><span class="sc11">nextToken</span><span class="sc10">().</span><span class="sc11">equals</span><span class="sc10">(</span><span class="sc6">"POST"</span><span class="sc10">))</span><span class="sc0">\r\n            </span><span class="sc10">{</span><span class="sc0">\r\n                </span><span class="sc5">if</span><span class="sc10">((</span><span class="sc11">req</span><span class="sc10">=</span><span class="sc11">st</span><span class="sc10">.</span><span class="sc11">nextToken</span><span class="sc10">()).</span><span class="sc11">endsWith</span><span class="sc10">(</span><span class="sc6">"/"</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc10">||</span><span class="sc0"> </span><span class="sc11">req</span><span class="sc10">.</span><span class="sc11">equals</span><span class="sc10">(</span><span class="sc6">""</span><span class="sc10">))</span><span class="sc0">\r\n                    </span><span class="sc11">req</span><span class="sc10">+=</span><span class="sc6">"index.html"</span><span class="sc10">;</span><span class="sc0">\r\n                </span><span class="sc5">try</span><span class="sc10">{</span><span class="sc0">\r\n                    </span><span class="sc11">File</span><span class="sc0"> </span><span class="sc11">f</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">File</span><span class="sc10">(</span><span class="sc11">req</span><span class="sc10">);</span><span class="sc0">\r\n                    </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"Запрос Файла:"</span><span class="sc10">+</span><span class="sc11">req</span><span class="sc10">);</span><span class="sc0">\r\n\r\n                    </span><span class="sc11">BufferedReader</span><span class="sc0"> </span><span class="sc11">bfr</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">BufferedReader</span><span class="sc10">(</span><span class="sc5">new</span><span class="sc0"> </span><span class="sc11">FileReader</span><span class="sc10">(</span><span class="sc11">f</span><span class="sc10">));</span><span class="sc0">\r\n                    </span><span class="sc16">char</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">data</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc16">char</span><span class="sc10">[(</span><span class="sc16">int</span><span class="sc10">)</span><span class="sc11">f</span><span class="sc10">.</span><span class="sc11">length</span><span class="sc10">()];</span><span class="sc0">\r\n                    </span><span class="sc11">bfr</span><span class="sc10">.</span><span class="sc11">read</span><span class="sc10">(</span><span class="sc11">data</span><span class="sc10">);</span><span class="sc0">\r\n\r\n                    </span><span class="sc11">pw</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"HTTP/1.1 200 OK\n"</span><span class="sc10">);</span><span class="sc0">\r\n                    </span><span class="sc11">pw</span><span class="sc10">.</span><span class="sc11">write</span><span class="sc10">(</span><span class="sc11">data</span><span class="sc10">);</span><span class="sc0">\r\n                    </span><span class="sc11">pw</span><span class="sc10">.</span><span class="sc11">flush</span><span class="sc10">();</span><span class="sc0">\r\n\r\n                </span><span class="sc10">}</span><span class="sc5">catch</span><span class="sc0"> </span><span class="sc10">(</span><span class="sc11">FileNotFoundException</span><span class="sc0"> </span><span class="sc11">fe</span><span class="sc10">)</span><span class="sc0">\r\n                </span><span class="sc10">{</span><span class="sc0">\r\n                    </span><span class="sc11">pw</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"HTTP/1.1 404 Not Found\n"</span><span class="sc10">);</span><span class="sc0">\r\n                </span><span class="sc10">}</span><span class="sc5">catch</span><span class="sc0"> </span><span class="sc10">(</span><span class="sc11">IOException</span><span class="sc0"> </span><span class="sc11">ioe</span><span class="sc10">){</span><span class="sc0">\r\n                    </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc11">ioe</span><span class="sc10">);</span><span class="sc0">\r\n                </span><span class="sc10">}</span><span class="sc0">\r\n\r\n            </span><span class="sc10">}</span><span class="sc5">else</span><span class="sc0"> </span><span class="sc11">pw</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc6">"HTTP/1.1 400 Bad Request\n"</span><span class="sc10">);</span><span class="sc0">\r\n\r\n            </span><span class="sc11">sock</span><span class="sc10">.</span><span class="sc11">close</span><span class="sc10">();</span><span class="sc0">\r\n\r\n        </span><span class="sc10">}</span><span class="sc5">catch</span><span class="sc0"> </span><span class="sc10">(</span><span class="sc11">IOException</span><span class="sc0"> </span><span class="sc11">e</span><span class="sc10">){</span><span class="sc0">\r\n            </span><span class="sc11">System</span><span class="sc10">.</span><span class="sc11">out</span><span class="sc10">.</span><span class="sc11">println</span><span class="sc10">(</span><span class="sc11">e</span><span class="sc10">);</span><span class="sc0">\r\n        </span><span class="sc10">}</span><span class="sc0">\r\n\r\n    </span><span class="sc10">}</span><span class="sc0">\r\n\r\n</span><span class="sc10">}</span><span class="sc0">\r\n<div style="mso-element:para-border-div;border:none;border-bottom:solid windowtext 1.5pt;\r\npadding:0cm 0cm 1.0pt 0cm"></div>\r\n<p>После запуска проверки портов увидим на 8080 сервер.<br>\r\n<img src="images/proverkaPortov8080.jpg" class="center"/></p>\r\n<p>Запустим клиента и протестируем программу:<br><br><img src="images/clientServer8080.jpg" class="center" width=635 height=345 /><br>Прога работает.</p>\r\n<p><a href="download/java.zip" title="Cкачать">*Исходный код приложения доступен для скачивания.</a></p>\r\n\r\n</span>\r\n</div>\r\n</div>\r\n'),
(5, 'Sniffer', '\r\n<div>\r\n<H3>Лабораторная работа 3: Sniffer.</H3>\r\n<hr>\r\n<p align="center"><b>Анализ пакетов</b></p>\r\n<p>IP датаграммы инкапсулируются TCP и UDP пакетами. Они также содержатся в  данных, передаваемыx по протоколам прикладного уровня, таких как DNS, HTTP, FTP, SMTP, SIP и т.д. Таким образом, пакет TCP содержит в себе дейтаграммы IP, например:</p>\r\n<p>\r\n<div style="float: left; white-space: pre; line-height: 1; background: #FFFFFF; "><span class="sc0">+--------------+---------------+----------------------+\r\n| IP заголовок | TCP заголовок |        Данные        |\r\n+--------------+---------------+----------------------+\r\n</span></div><br><br>\r\n<p>Итак, первое, что мы должны сделать, это проанализировать IP-заголовок. Для этого создан урезанный класс classIPHeader. Комментарии описывают что и как происходит.</p>\r\n<div style="float: left; white-space: pre; line-height: 1; background: #FFFFFF; "><span class="sc5">public</span><span class="sc0"> </span><span class="sc11">classIPHeader</span><span class="sc0"> \r\n</span><span class="sc10">{</span><span class="sc0"> \r\n  </span><span class="sc2">//Поля IP заголовка\r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">byte</span><span class="sc0"> </span><span class="sc11">byVersionAndHeaderLength</span><span class="sc10">;</span><span class="sc0"> </span><span class="sc2">// Восемь бит для версии \r\n</span><span class="sc0">                                         </span><span class="sc2">// и длины \r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">byte</span><span class="sc0"> </span><span class="sc11">byDifferentiatedServices</span><span class="sc10">;</span><span class="sc0"> </span><span class="sc2">// Восемь бит для дифференцированного \r\n</span><span class="sc0">                                         </span><span class="sc2">// сервиса\r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">ushort</span><span class="sc0"> </span><span class="sc11">usTotalLength</span><span class="sc10">;</span><span class="sc0">          </span><span class="sc2">// 16 бит для общей длины \r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">ushort</span><span class="sc0"> </span><span class="sc11">usIdentification</span><span class="sc10">;</span><span class="sc0">       </span><span class="sc2">// 16 бит для идентификатора\r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">ushort</span><span class="sc0"> </span><span class="sc11">usFlagsAndOffset</span><span class="sc10">;</span><span class="sc0">       </span><span class="sc2">// 16 бит для флагов, фрагментов \r\n</span><span class="sc0">                                         </span><span class="sc2">// смещения \r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">byte</span><span class="sc0"> </span><span class="sc11">byTTL</span><span class="sc10">;</span><span class="sc0">                    </span><span class="sc2">// 8 бит для TTL (Time To Live) \r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">byte</span><span class="sc0"> </span><span class="sc11">byProtocol</span><span class="sc10">;</span><span class="sc0">               </span><span class="sc2">// 8 бит для базового протокола\r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">short</span><span class="sc0"> </span><span class="sc11">sChecksum</span><span class="sc10">;</span><span class="sc0">               </span><span class="sc2">// 16 бит для контрольной суммы \r\n</span><span class="sc0">                                         </span><span class="sc2">//  заголовка \r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">uint</span><span class="sc0"> </span><span class="sc11">uiSourceIPAddress</span><span class="sc10">;</span><span class="sc0">        </span><span class="sc2">// 32 бита для адреса источника IP \r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">uint</span><span class="sc0"> </span><span class="sc11">uiDestinationIPAddress</span><span class="sc10">;</span><span class="sc0">   </span><span class="sc2">// 32 бита для IP назначения \r\n</span><span class="sc0">\r\n  </span><span class="sc2">//Конец полей IP заголовка   \r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">byte</span><span class="sc0"> </span><span class="sc11">byHeaderLength</span><span class="sc10">;</span><span class="sc0">             </span><span class="sc2">//Длина заголовка\r\n</span><span class="sc0">  </span><span class="sc5">private</span><span class="sc0"> </span><span class="sc16">byte</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">byIPData</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc5">new</span><span class="sc0"> </span><span class="sc16">byte</span><span class="sc10">[</span><span class="sc4">4096</span><span class="sc10">];</span><span class="sc0"> </span><span class="sc2">//Данные в дейтаграмме\r\n</span><span class="sc0">  </span><span class="sc5">public</span><span class="sc0"> </span><span class="sc11">IPHeader</span><span class="sc10">(</span><span class="sc16">byte</span><span class="sc10">[]</span><span class="sc0"> </span><span class="sc11">byBuffer</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc16">int</span><span class="sc0"> </span><span class="sc11">nReceived</span><span class="sc10">)</span><span class="sc0">\r\n  </span><span class="sc10">{</span><span class="sc0">\r\n    </span><span class="sc5">try</span><span class="sc0">\r\n    </span><span class="sc10">{</span><span class="sc0">\r\n    </span><span class="sc2">//Создаём MemoryStream для принимаемых данных\r\n</span><span class="sc0">    </span><span class="sc11">MemoryStream</span><span class="sc0"> </span><span class="sc11">memoryStream</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">newMemoryStream</span><span class="sc10">(</span><span class="sc11">byBuffer</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc4">0</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc11">nReceived</span><span class="sc10">);</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//Далее создаем BinaryReader для чтения MemoryStream\r\n</span><span class="sc0">    </span><span class="sc11">BinaryReader</span><span class="sc0"> </span><span class="sc11">binaryReader</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">newBinaryReader</span><span class="sc10">(</span><span class="sc11">memoryStream</span><span class="sc10">);</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//Первые 8 бит содержат верисю и длину заголовка\r\n</span><span class="sc0">    </span><span class="sc2">//считываем 8 бит = 1 байт\r\n</span><span class="sc0">    </span><span class="sc11">byVersionAndHeaderLength</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadByte</span><span class="sc10">();</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//Следующие 8 бит содержат дифф. сервис\r\n</span><span class="sc0">    </span><span class="sc11">byDifferentiatedServices</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadByte</span><span class="sc10">();</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//Следующие 8 бит содержат общую длину дейтаграммы\r\n</span><span class="sc0">    </span><span class="sc11">usTotalLength</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> \r\n             </span><span class="sc10">(</span><span class="sc16">ushort</span><span class="sc10">)</span><span class="sc0"> </span><span class="sc11">IPAddress</span><span class="sc10">.</span><span class="sc11">NetworkToHostOrder</span><span class="sc10">(</span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadInt16</span><span class="sc10">());</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//16 байт для идентификатора\r\n</span><span class="sc0">    </span><span class="sc11">usIdentification</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> \r\n              </span><span class="sc10">(</span><span class="sc16">ushort</span><span class="sc10">)</span><span class="sc11">IPAddress</span><span class="sc10">.</span><span class="sc11">NetworkToHostOrder</span><span class="sc10">(</span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadInt16</span><span class="sc10">());</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//8 бит для флагов, фрагментов, смещений\r\n</span><span class="sc0">    </span><span class="sc11">usFlagsAndOffset</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> \r\n              </span><span class="sc10">(</span><span class="sc16">ushort</span><span class="sc10">)</span><span class="sc11">IPAddress</span><span class="sc10">.</span><span class="sc11">NetworkToHostOrder</span><span class="sc10">(</span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadInt16</span><span class="sc10">());</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//8 бит для TTL\r\n</span><span class="sc0">    </span><span class="sc11">byTTL</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadByte</span><span class="sc10">();</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//8 бит для базового протокола\r\n</span><span class="sc0">    </span><span class="sc11">byProtocol</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadByte</span><span class="sc10">();</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//16 бит для контрольной суммы\r\n</span><span class="sc0">    </span><span class="sc11">sChecksum</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">IPAddress</span><span class="sc10">.</span><span class="sc11">NetworkToHostOrder</span><span class="sc10">(</span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadInt16</span><span class="sc10">());</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//32 бита для IP источника\r\n</span><span class="sc0">    </span><span class="sc11">uiSourceIPAddress</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc10">(</span><span class="sc16">uint</span><span class="sc10">)(</span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadInt32</span><span class="sc10">());</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//32 бита IP назначения\r\n</span><span class="sc0">    </span><span class="sc11">uiDestinationIPAddress</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc10">(</span><span class="sc16">uint</span><span class="sc10">)(</span><span class="sc11">binaryReader</span><span class="sc10">.</span><span class="sc11">ReadInt32</span><span class="sc10">());</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//Высчитываем длину заголовка\r\n</span><span class="sc0">    </span><span class="sc11">byHeaderLength</span><span class="sc0"> </span><span class="sc10">=</span><span class="sc0"> </span><span class="sc11">byVersionAndHeaderLength</span><span class="sc10">;</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//Последние 4 бита в версии и длине заголовка содержат длину заголовка\r\n</span><span class="sc0">    </span><span class="sc2">//выполняем простые арифметические операции для их извлечения\r\n</span><span class="sc0">    </span><span class="sc11">byHeaderLength</span><span class="sc0"> </span><span class="sc10">&lt;&lt;=</span><span class="sc0"> </span><span class="sc4">4</span><span class="sc10">;</span><span class="sc0">\r\n    </span><span class="sc11">byHeaderLength</span><span class="sc0"> </span><span class="sc10">&gt;&gt;=</span><span class="sc0"> </span><span class="sc4">4</span><span class="sc10">;</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//Умножаем на 4 чтобы получить точную длину заголовка\r\n</span><span class="sc0">    </span><span class="sc11">byHeaderLength</span><span class="sc0"> </span><span class="sc10">*=</span><span class="sc0"> </span><span class="sc4">4</span><span class="sc10">;</span><span class="sc0">\r\n\r\n    </span><span class="sc2">//Копируем данные (которые содержат информацию в соответствии с типом \r\n</span><span class="sc0">    </span><span class="sc2">//основного протокола) в другой массив\r\n</span><span class="sc0">    </span><span class="sc11">Array</span><span class="sc10">.</span><span class="sc11">Copy</span><span class="sc10">(</span><span class="sc11">byBuffer</span><span class="sc10">,</span><span class="sc0"> \r\n               </span><span class="sc11">byHeaderLength</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc2">//копируем с конца заголовка\r\n</span><span class="sc0">               </span><span class="sc11">byIPData</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc4">0</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc11">usTotalLength</span><span class="sc0"> </span><span class="sc10">-</span><span class="sc0"> </span><span class="sc11">byHeaderLength</span><span class="sc10">);</span><span class="sc0">\r\n    </span><span class="sc10">}</span><span class="sc0">\r\n    </span><span class="sc5">catch</span><span class="sc0"> </span><span class="sc10">(</span><span class="sc11">Exception</span><span class="sc0"> </span><span class="sc11">ex</span><span class="sc10">)</span><span class="sc0">\r\n    </span><span class="sc10">{</span><span class="sc0">\r\n        </span><span class="sc11">MessageBox</span><span class="sc10">.</span><span class="sc11">Show</span><span class="sc10">(</span><span class="sc11">ex</span><span class="sc10">.</span><span class="sc11">Message</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc6">"Sn5"</span><span class="sc10">,</span><span class="sc0"> </span><span class="sc11">MessageBoxButtons</span><span class="sc10">.</span><span class="sc11">OK</span><span class="sc10">,</span><span class="sc0"> \r\n                        </span><span class="sc11">MessageBoxIcon</span><span class="sc10">.</span><span class="sc11">Error</span><span class="sc10">);</span><span class="sc0">\r\n    </span><span class="sc10">}</span><span class="sc0">\r\n </span><span class="sc10">}</span><span class="sc0">\r\n\r\n</span><span class="sc10">}</span></div>\r\n<div style="clear: left;"><p>Класс содержит элементы данных, соответствующих полям заголовка IP (RFC 791). Конструктор класса берет полученные байты и создает MemoryStream для полученной информации. Затем создает BinaryReader, чтобы считать данные байт за  байтом из MemoryStream. Важно, что данные, полученные от сети, находятся в форме с обратным порядком байтов, в связи с этим мы используем IPAddress. NetworkToHostOrder, чтобы исправить порядок байтов. Это должно быть сделано для всех элементов данных.</p>\r\n</div><hr>\r\n<H3 align="center">Тестирование примера:</H3>\r\n<p>Запускаем программу, переводим в режим ожидания. Через некоторое время активного использования интернет ресурсов можно увидеть следующее:<br>\r\n\r\n<img src="images/sn5.bmp" title="Запуск примера и проверка работы" height="300">\r\n<br>\r\n*<a href="download/Sniffer5.7z" title="Cкачать">Исходный код приложения доступен для скачивания.</a>\r\n</div>\r\n');
INSERT INTO `inform` (`№`, `tema`, `content`) VALUES
(6, 'LVS', '\r\n<div class=Section2>\r\n<h3>Лабораторная работа 4: ЛВС.</h3>\r\n<hr>\r\n<style type="text/css">\r\nspan {\r\nfont-size:14.0pt;\r\nline-height:115%;\r\nfont-family:Times New Roman, serif;\r\n}\r\n</style>\r\n<p class=MsoNormal align=center style="text-align:center"><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-bidi-font-family:Times New Roman;mso-bidi-theme-font:minor-bidi">СОДЕРЖАНИЕ<o:p></o:p></span></p>\r\n\r\n<table class=MsoTableGrid border=0 cellspacing=0 cellpadding=0\r\n style="border-collapse:collapse;border:none;mso-yfti-tbllook:1184;mso-padding-alt:\r\n 0cm 5.4pt 0cm 5.4pt;mso-border-insideh:none;mso-border-insidev:none">\r\n <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes">\r\n  <td width=36 valign=top style="width:26.7pt;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><span style="font-size:14.0pt;font-family:Times New Roman, serif">1.<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=602 valign=top style="width:451.85pt;border:none;border-right:solid white 1.0pt;\r\n  mso-border-right-themecolor:background1;mso-border-right-alt:solid white .5pt;\r\n  mso-border-right-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><a href="#001"><span style="font-size:14.0pt;font-family:Times New Roman, serif">Описание\r\n  принципов работы сети<u> <o:p></o:p></u></a></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:1">\r\n  <td width=36 valign=top style="width:26.7pt;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><span style="font-size:14.0pt;font-family:Times New Roman, serif">2.<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=602 valign=top style="width:451.85pt;border:none;border-right:solid white 1.0pt;\r\n  mso-border-right-themecolor:background1;mso-border-right-alt:solid white .5pt;\r\n  mso-border-right-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><a href="#002"><span style="font-size:14.0pt;font-family:Times New Roman, serif">Описание\r\n  коммутатора и его настройка<u> </u><o:p></o:p></a></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:2">\r\n  <td width=36 valign=top style="width:26.7pt;border:none;border-bottom:solid white 1.0pt;\r\n  mso-border-bottom-themecolor:background1;mso-border-bottom-alt:solid white .5pt;\r\n  mso-border-bottom-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><span style="font-size:14.0pt;font-family:Times New Roman, serif">3.<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=602 valign=top style="width:451.85pt;border:none;border-right:solid white 1.0pt;\r\n  mso-border-right-themecolor:background1;mso-border-right-alt:solid white .5pt;\r\n  mso-border-right-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><a href="#003"><span style="font-size:14.0pt;font-family:Times New Roman, serif">Описание\r\n  роутера и его настройка<u></u><o:p></o:p></span></a></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:3">\r\n  <td width=36 valign=top style="width:26.7pt;border:none;mso-border-top-alt:\r\n  solid white .5pt;mso-border-top-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><span style="font-size:14.0pt;font-family:Times New Roman, serif">4</span><span\r\n  lang=EN-US style="font-size:14.0pt;font-family:Times New Roman, serif;\r\n  mso-ansi-language:EN-US">.<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=602 valign=top style="width:451.85pt;border:none;border-right:solid white 1.0pt;\r\n  mso-border-right-themecolor:background1;mso-border-right-alt:solid white .5pt;\r\n  mso-border-right-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><a href="#004"><span style="font-size:14.0pt;font-family:Times New Roman, serif">Описание\r\n  ноутбуков и их настройка<u></u><o:p></o:p></span></a></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:4">\r\n  <td width=36 valign=top style="width:26.7pt;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><span style="font-size:14.0pt;font-family:Times New Roman, serif">5</span><span\r\n  lang=EN-US style="font-size:14.0pt;font-family:Times New Roman, serif;\r\n  mso-ansi-language:EN-US">.<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=602 valign=top style="width:451.85pt;border:none;border-right:solid white 1.0pt;\r\n  mso-border-right-themecolor:background1;mso-border-right-alt:solid white .5pt;\r\n  mso-border-right-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><a href="#005"><span style="font-size:14.0pt;font-family:Times New Roman, serif">Описание\r\n  пк и их настройка<u></u><o:p></o:p></span></a></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:5">\r\n  <td width=36 valign=top style="width:26.7pt;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><span style="font-size:14.0pt;font-family:Times New Roman, serif">6</span><span\r\n  lang=EN-US style="font-size:14.0pt;font-family:Times New Roman, serif;\r\n  mso-ansi-language:EN-US">.<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=602 valign=top style="width:451.85pt;border:none;border-right:solid white 1.0pt;\r\n  mso-border-right-themecolor:background1;mso-border-right-alt:solid white .5pt;\r\n  mso-border-right-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><a href="#006"><span style="font-size:14.0pt;font-family:Times New Roman, serif">Медиаконвертор<u></u><o:p></o:p></span></a></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:6;mso-yfti-lastrow:yes">\r\n  <td width=36 valign=top style="width:26.7pt;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal"><span style="font-size:14.0pt;font-family:Times New Roman, serif">7</span><span\r\n  lang=EN-US style="font-size:14.0pt;font-family:Times New Roman, serif;\r\n  mso-ansi-language:EN-US">.<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=602 valign=top style="width:451.85pt;border:none;border-right:solid white 1.0pt;\r\n  mso-border-right-themecolor:background1;mso-border-right-alt:solid white .5pt;\r\n  mso-border-right-themecolor:background1;padding:0cm 5.4pt 0cm 5.4pt">\r\n  <p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\n  normal "><a href="#007"><span style="font-size:14.0pt;font-family:Times New Roman, serif;background:yellow;mso-highlight:yellow">Критерий корректности сети</span><u><span\r\n  style="font-size:14.0pt;font-family:Times New Roman, serif"></span></u></a><span\r\n  style="font-size:14.0pt;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n</table>\r\n\r\n<p class=MsoNormal><o:p>&nbsp;</o:p></p>\r\n\r\n<span style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-fareast-theme-font:minor-fareast;\r\nmso-ansi-language:RU;mso-fareast-language:RU;mso-bidi-language:AR-SA"><br\r\nclear=all style="mso-special-character:line-break;page-break-before:always">\r\n</span>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoNormal><a name="_Toc388895625"><b><span style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif" id="001">1 Описание принципов\r\nработы сети</span></b></a><span style="mso-bookmark:_Toc388895625"></span><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Локальная вычислительная сеть – это совокупность\r\nкомпьютеров и различных устройств, обеспечивающих информационный обмен между\r\nкомпьютерами в сети без использования каких-либо промежуточных носителей\r\nинформации (флешки, компакт диски).<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Все многообразие компьютерных сетей можно классифицировать\r\nпо группе признаков.<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">По территориальной распространенности сети могут\r\nбыть локальными, глобальными, и региональными. Локальные – это сети,\r\nперекрывающие небольшую территорию, региональные – расположенные на территории\r\nгорода или области, глобальные на территории государства или группы государств,\r\nнапример, всемирная сеть </span><span lang=EN-US style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif;mso-ansi-language:EN-US">Internet</span><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif">.<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">По принадлежности различают ведомственные и\r\nгосударственные сети. Ведомственные принадлежат одной организации и\r\nрасполагаются на ее территории. Государственные сети – сети, используемые в\r\nгосударственных структурах. <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">По скорости передачи информации компьютерные сети\r\nделятся на низко-, средне- и высокоскоростные.<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">По типу среды передачи разделяются на сети\r\nкоаксиальные, на витой паре, оптоволоконные, с передачей информации по\r\nрадиоканалам, в инфракрасном диапазоне.<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">В классификации сетей существует два основных\r\nтермина: </span><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\nfont-family:Times New Roman, serif;mso-ansi-language:EN-US">LAN</span><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif">\r\nи </span><span lang=EN-US style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-ansi-language:EN-US">WAN</span><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif">.<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt"><span\r\nlang=EN-US style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-ansi-language:EN-US">LAN</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif"> (</span><span lang=EN-US\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-ansi-language:EN-US">Local</span><span lang=EN-US style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif"> </span><span\r\nlang=EN-US style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-ansi-language:EN-US">Area</span><span lang=EN-US style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif"> </span><span\r\nlang=EN-US style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-ansi-language:EN-US">Network</span><span style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif">) – локальные сети,\r\nимеющие замкнутую инфраструктуру до выхода на поставщиков услуг. Термин «</span><span\r\nlang=EN-US style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-ansi-language:EN-US">LAN</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">» может описывать и маленькую\r\nофисную сеть, и сеть уровня большого завода, занимающего несколько сотен\r\nгектаров. Зарубежные источники дают даже<o:p></o:p>\r\nблизкую оценку – около шести миль (10 км) в радиусе; использование высокоскоростных\r\nканалов.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">WAN\r\n\r\n \r\n\r\n ( Wide Area Network )\r\n– глобальная сеть, покрывающая большие географические регионы, включающие в\r\nсебя как локальные сети, так и прочие телекоммуникационные сети и устройства.\r\nПример  WAN  – сети с коммутацией пакетов ( Frame Relay ),\r\nчерез которую могут «разговаривать» между собой различные компьютерные сети.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">Термин «корпоративная сеть» также используется в\r\nлитературе для обозначения объединения нескольких сетей, каждая из которых\r\nможет быть построена на различных технических, программных и информационных\r\nпринципах.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><b style="mso-bidi-font-weight:\r\nnormal"><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">Типы ЛВС<o:p></o:p></span></b></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">Ethernet</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif"> – изначально коллизионная\r\nтехнология, основанная на общей шине, к которой компьютеры подключаются и\r\n«борются» между собой за право передачи пакета. Основной протокол – </span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">CSMA</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">/</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">CD</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">\r\n(множественный доступ с чувствительностью несущей и обнаружению коллизий). Дело\r\nв том, что если две станции одновременно начнут передачу, то возникает ситуация\r\nколлизии, и сеть некоторое время «ждет», пока «улягутся» переходные процессы и\r\nопять наступит «тишина». Существует еще один метод доступа – </span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">CSMA</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">/</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">CA</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif"> (</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">Collision</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif"> </span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">Avoidance</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">) – то же, но с исключением\r\nколлизий. Перед отправкой любого пакета в сети пробегает анонс о том, что\r\nсейчас будет происходить передача, и станции уже не пытаются ее инициировать.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> бывает полудуплексный по\r\nвсем средам передачи: источник и приемник «говорит по очереди» (классическая\r\nколлизионная технология) и полнодуплексный, когда две пары приемника и\r\nпередатчика на устройствах говорят одновременно. Этот механизм работает только\r\nна витой паре и на оптоволокне (одна пара на передачу, одна пара на прием).<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> различается по скоростям и\r\nметодам кодирования для различной физической среды, а также по типу пакетов (</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Ethernet</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%"> </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">II</span><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">, 802.3, </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">RAW</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">, 802.2 (</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">LLC</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">), </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">SNAP</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">).<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> различается по скоростям:\r\n10 Мбит/с, 100 Мбит/с, 1000 Мбит/с (Гигабит). Поскольку недавно ратифицирован\r\nстандарт </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%;mso-ansi-language:EN-US">Gigabit</span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%"> </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> для витой пары категории 5,\r\nможно сказать, что для любой сети </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> могут быть использованы\r\nвитая пара, одномодовое (</span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">SMF</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">) или многомодовое (</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">MMF</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">)\r\nоптоволокно. В зависимости от этого существуют различные спецификации: <o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="margin-left:0cm;text-indent:35.45pt;mso-list:l0 level1 lfo1;\r\ntab-stops:list 53.45pt"><![if !supportLists]><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;font-family:Symbol;mso-fareast-font-family:Symbol;\r\nmso-bidi-font-family:Symbol"><span style="mso-list:Ignore">·<span\r\nstyle="font:7.0pt Times New Roman>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">10 Мбит/с </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">: 10</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">BaseT</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">, 10</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">BaseFL</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">, (10</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Base</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">2 и\r\n10</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US">Base</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">5 существуют для коаксиального кабеля и уже не применяются); <o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="margin-left:0cm;text-indent:35.45pt;mso-list:l0 level1 lfo1;\r\ntab-stops:list 53.45pt"><![if !supportLists]><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;font-family:Symbol;mso-fareast-font-family:Symbol;\r\nmso-bidi-font-family:Symbol;mso-ansi-language:EN-US"><span style="mso-list:\r\nIgnore">·<span style="font:7.0pt Times New Roman>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">100 </span><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Мбит</span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">/</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">с</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">\r\nEthernet: 100BaseTX, 100BaseFX, 100BaseT4, 100BaseT2; <o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="margin-left:0cm;text-indent:35.45pt;mso-list:l0 level1 lfo1;\r\ntab-stops:list 53.45pt"><![if !supportLists]><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;font-family:Symbol;mso-fareast-font-family:Symbol;\r\nmso-bidi-font-family:Symbol;mso-ansi-language:EN-US"><span style="mso-list:\r\nIgnore">·<span style="font:7.0pt Times New Roman>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">Gigabit Ethernet: 1000BaseLX,\r\n1000BaseSX (</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">по</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US"> </span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">оптике</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">) </span><span style="mso-bidi-font-size:14.0pt;line-height:150%">и</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US"> 1000BaseTX (</span><span style="mso-bidi-font-size:14.0pt;line-height:\r\n150%">для</span><span style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US"> </span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">витой</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"> </span><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">пары</span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">)<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Существуют два варианта реализации </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Ethernet</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\nна коаксиальном кабеле, называемые «тонкий» и «толстый» </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Ethernet</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\n(</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US">Ethernet</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%"> на тонком кабеле 0,2 дюйма и </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> на толстом кабеле 0,4\r\nдюйма). <o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><b style="mso-bidi-font-weight:\r\nnormal"><span style="mso-bidi-font-size:14.0pt;line-height:150%">Тонкий </span></b><b\r\nstyle="mso-bidi-font-weight:normal"><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span></b><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> использует кабель типа </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">RG</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">-58</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">A</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">/</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">V</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\n(диаметром 0,2 дюйма). Для маленькой сети используется коаксиальный кабель с\r\nсопротивлением 50 Ом. Длина сегмента 185 м, количество компьютеров,\r\nподключенных к шине – до 30.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">После присоединения всех отрезков кабеля с </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">BNC</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">-коннекторами\r\nк Т-коннекторам получится единый кабельный сегмент. На его обоих концах\r\nустанавливаются терминаторы («заглушки»). Терминатор конструктивно представляет\r\nсобой </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%;mso-ansi-language:EN-US">BNC</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">-коннектор (он также надевается на Т-коннектор) с впаянным\r\nсопротивлением (для </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> 50 Ом).<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><b style="mso-bidi-font-weight:\r\nnormal"><span style="mso-bidi-font-size:14.0pt;line-height:150%">Толстый </span></b><b\r\nstyle="mso-bidi-font-weight:normal"><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span></b><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> – сеть на толстом\r\nкоаксиальном кабеле, имеющем диаметр 0,4 дюйма и волновое сопротивление 50 Ом.\r\nМаксимальная длина кабельного сегмента – 500 м. Прокладка самого кабеля почти\r\nодинакова для всех типов коаксиального кабеля.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Для подключения компьютера к толстому кабелю\r\nиспользуется дополнительное устройство, называемое трансивером. Трансивер\r\nподсоединен непосредственно к сетевому кабелю. От него к компьютеру идет\r\nспециальный трансиверный кабель, максимальная длина которого 50 м. На обоих его\r\nконцах находятся 15-контактные </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">DIX</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">-разъемы (</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Digital</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">,\r\n</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US">Intel</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%"> и </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">Xerox</span><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">). С помощью одного разъема осуществляется подключение\r\nк трансиверу, с помощью другого – к сетевой плате компьютера. Трансиверы освобождают\r\nот необходимости подводить кабель к каждому компьютеру.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.4pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Создание сети при помощи трансивера очень удобно. Он\r\nможет в любом месте в буквальном смысле «пропускать» кабель. Эта простая\r\nпроцедура занимает мало времени, а получаемое соединение оказывается очень\r\nнадежным.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><b style="mso-bidi-font-weight:\r\nnormal"><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US">Ethernet</span></b><b style="mso-bidi-font-weight:\r\nnormal"><span style="mso-bidi-font-size:14.0pt;line-height:150%"> на витой\r\nпаре.<o:p></o:p></span></b></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Витая пара – это два изолированных провода, скрученных\r\nмежду собой. Для </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> используется 8-жильный\r\nкабель, состоящий из четырех витых пар. Для защиты от воздействия окружающей\r\nсреды кабель имеет внешнее изолирующее покрытие.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Основной узел на витой паре – </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">hub</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">. Каждый компьютер должен\r\nбыть подключен к нему с помощью своего сегмента кабеля. Длина каждого сегмента\r\nне должна превышать 100 м. На концах кабельных сегментов устанавливаются\r\nразъемы </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%;mso-ansi-language:EN-US">RJ</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">-45. Одним разъемом кабель подключается к хабу, другим – к\r\nсетевой плате. Разъемы </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">RJ</span><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">-45 очень компактны, имеют пластмассовый корпус и\r\nвосемь миниатюрных площадок.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Хаб – центральное устройство в сети на витой паре, от\r\nнего зависит ее работоспособность. Располагать его надо в легкодоступном месте,\r\nчтобы можно было легко подключать кабель и следить за индикацией портов. Хабы\r\nвыпускаются на разное количество портов – 8, 12, 16 или 24. Соответственно к\r\nнему можно подключить такое же количество компьютеров.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 align=left style="text-align:left;text-indent:35.45pt"><b\r\nstyle="mso-bidi-font-weight:normal"><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">Технология</span></b><b style="mso-bidi-font-weight:normal"><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US"> <span\r\nlang=EN-US>Fast Ethernet IEEE 802.3U.<o:p></o:p></span></span></b></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Технология </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Fast</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> была стандартизирована\r\nкомитетом </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%;mso-ansi-language:EN-US">IEEE</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%"> 802.3. Новый стандарт получил название </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">IEEE</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\n802.3</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US">U</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">. Скорость передачи информации 100 Мбит/с. </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Fast</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%"> </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%;mso-ansi-language:EN-US">Ethernet</span><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%"> организуется на витой паре или оптоволокне.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">В сети </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Fast</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> организуются несколько\r\nдоменов конфликтов, но с обязательным учетом класса повторителя, используемого\r\nв доменах.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Репитеры </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Fast</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> (</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">IEEE</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> 802.3</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">U</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">)\r\nбывают двух классов и различаются по задержке в мкс. Соответственно в сегменте\r\n(логическом) может быть до двух репитеров класса 2 и один репитер класса 1. Для\r\n</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US">Ethernet</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%"> (</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">IEEE</span><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%"> 802.3) сеть подчиняется правилу 5-4-3-2-1. Правило\r\n5-4-3-2-1 гласит: между любыми двумя рабочими станциями не должно быть более 5\r\nфизических сегментов, 4 репитеров (концентраторов), 3 «населенных» физических\r\nсегментов, 2 «населенных» межрепитерных связей (</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">IRL</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">), и все это должно\r\nпредставлять собой один коллизионный домен (25,6 мкс).<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Физически из концентратора «растет» много проводов, но\r\nлогически это все один сегмент </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> и один коллизионный домен,\r\nв связи с ним любой сбой одной станции отражается на работе других. Поскольку\r\nвсе станции вынуждены «слушать» чужие пакеты, коллизия происходит в пределах\r\nвсего концентратора (на самом деле на другие порты посылается сигнал </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Jam</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">, но\r\nэто не меняет сути дела). Поэтому, хотя концентратор – это самое дешевое\r\nустройство и, кажется, что оно решает все проблемы заказчика, специалисты советуют\r\nпостепенно отказаться от этой методики, особенно в условиях постоянного роста\r\nтребований к ресурсам сетей, и переходить на коммутируемые сети. Сеть их 20\r\nкомпьютеров, собранная на репитерах 100 Мбит/с, может работать медленнее, чем\r\nсеть из 20 компьютеров, включенных в коммутатор 10 Мбит/с.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 align=left style="text-align:left;text-indent:35.45pt"><b\r\nstyle="mso-bidi-font-weight:normal<><span style=tmso-bidi-font-size:14.0pt;\r\nline-height:150%">Технология </span></b><b style="mso-bidi-font-weight:normal"><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Gigabit</span></b><b style="mso-bidi-font-weight:normal"><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%"> </span></b><b\r\nstyle="mso-bidi-font-weight:normal"><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span></b><b\r\nstyle="mso-bidi-font-weight:normal"><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">.<o:p></o:p></span></b></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">Следующий шаг в развитии технологии </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Ethernet</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\n– разработка проекта стандарта </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">IEEE</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">-802.32. Данный стандарт\r\nпредусматривает скорость обмена информацией между станциями локальной сети 1\r\nГбит/с. Предполагается, что устройства </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Gigabit</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Ethernet</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\nбудут объединять сегменты сетей с </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Fast</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> со скоростями 100 Мбит/с.\r\nРазрабатываются сетевые карты со скоростью 1 Гбит/с, а также серия сетевых\r\nустройств, таких как коммутаторы и маршрутизаторы.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%">В сети с </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Gigabit</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Ethernet</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\nбудет использоваться управление трафиком, контроль перегрузок и обеспечение\r\nкачества обслуживания (</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">Quality</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">Of</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Service</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\n- </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US">QOS</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">). Стандарт </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Gigabit</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">Ethernet</span><span style="mso-bidi-font-size:14.0pt;line-height:150%">\r\n– один из серьезных соперников технологии АТМ. <o:p></o:p></span></p>\r\n\r\n<h1 style="text-indent:35.45pt"><span style="font-family:"Arial","sans-serif" id="002">2\r\nОписание коммутатора и его настройка<o:p></o:p></span></h1>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><!--[if gte vml 1]><o:wrapblock><v:shapetype\r\n  id="_x0000_t75" coordsize="21600,21600" o:spt="75" o:preferrelative="t"\r\n  path="m@4@5l@4@11@9@11@9@5xe" filled="f" stroked="f">\r\n  <v:stroke joinstyle="miter"/>\r\n  <v:formulas>\r\n   <v:f eqn="if lineDrawn pixelLineWidth 0"/>\r\n   <v:f eqn="sum @0 1 0"/>\r\n   <v:f eqn="sum 0 0 @1"/>\r\n   <v:f eqn="prod @2 1 2"/>\r\n   <v:f eqn="prod @3 21600 pixelWidth"/>\r\n   <v:f eqn="prod @3 21600 pixelHeight"/>\r\n   <v:f eqn="sum @0 0 1"/>\r\n   <v:f eqn="prod @6 1 2"/>\r\n   <v:f eqn="prod @7 21600 pixelWidth"/>\r\n   <v:f eqn="sum @8 21600 0"/>\r\n   <v:f eqn="prod @7 21600 pixelHeight"/>\r\n   <v:f eqn="sum @10 21600 0"/>\r\n  </v:formulas>\r\n  <v:path o:extrusionok="f" gradientshapeok="t" o:connecttype="rect"/>\r\n  <o:lock v:ext="edit" aspectratio="t"/>\r\n </v:shapetype><v:shape id="Рисунок_x0020_182" o:spid="_x0000_s1031" type="#_x0000_t75"\r\n  alt="408-626_" style="position:absolute;left:0;text-align:left;margin-left:30.45pt;\r\n  margin-top:8.1pt;width:397.05pt;height:108pt;z-index:1;visibility:visible;\r\n  mso-wrap-style:square;mso-wrap-distance-left:9pt;mso-wrap-distance-top:0;\r\n  mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:0;\r\n  mso-position-horizontal:absolute;mso-position-horizontal-relative:text;\r\n  mso-position-vertical:absolute;mso-position-vertical-relative:text">\r\n  <v:imagedata src="images/image001.jpg" o:title="408-626_"/>\r\n  <w:wrap type="topAndBottom"/>\r\n </v:shape><![endif]--><![if !vml]><span style="mso-ignore:vglayout">\r\n <table cellpadding=0 cellspacing=0 align=left>\r\n  <tr>\r\n   <td width=41 height=0></td>\r\n  </tr>\r\n  <tr>\r\n   <td></td>\r\n   <td><img width=529 height=144 src="images/image002.jpg" alt="408-626_"\r\n   v:shapes="Рисунок_x0020_182"></td>\r\n  </tr>\r\n </table>\r\n </span><![endif]><!--[if gte vml 1]></o:wrapblock><![endif]--><br\r\nstyle="mso-ignore:vglayout" clear=ALL>\r\n</p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><b><span\r\nstyle="font-size:14.0pt;line-height:150%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-bidi-font-family:Times New Roman;\r\nmso-bidi-theme-font:minor-bidi;color:black">Описание:<o:p></o:p></span></b></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><b><span\r\nstyle="font-size:14.0pt;line-height:150%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-bidi-font-family:Times New Roman;\r\nmso-bidi-theme-font:minor-bidi;color:black">SW-21600/B PoE коммутатор Fast\r\nEthernet на 16 портов.</span></b><span style="font-size:14.0pt;line-height:\r\n150%;font-family:Times New Roman, serif;mso-fareast-font-family:Times New Roman;\r\nmso-bidi-font-family:Times New Roman;mso-bidi-theme-font:minor-bidi;\r\ncolor:black"><o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><span style="font-size:\r\n14.0pt;line-height:150%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman;mso-bidi-font-family:Times New Roman;mso-bidi-theme-font:\r\nminor-bidi;color:black">PoE коммутатор Fast Ethernet на 16 портов. Порты: 16 x\r\nFE (10/100 Base-T) с поддержкой PoE (IEEE 802.3af/at). Мощность PoE на порт -\r\nдо 30W. Суммарная мощность PoE до 240W. Питание: AC100-240V (250W). Встроенный\r\nБП. Размеры: 480 x200 x 44 мм. Рабочая температура: 0...+50 гр. С.&nbsp;<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><b><span\r\nstyle="font-size:14.0pt;line-height:150%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-bidi-font-family:Times New Roman;\r\nmso-bidi-theme-font:minor-bidi;color:black">Особенность модели</span></b><span\r\nstyle="font-size:14.0pt;line-height:150%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-bidi-font-family:Times New Roman;\r\nmso-bidi-theme-font:minor-bidi;color:black"><o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><span style="font-size:\r\n14.0pt;line-height:150%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman;mso-bidi-font-family:Times New Roman;mso-bidi-theme-font:\r\nminor-bidi;color:black">16-портовый коммутатор SW-21600/B обеспечивает\r\nавтоматическое сохранение электроэнергии благодаря автоматическому отключению\r\nпитания портов, когда отсутствуют соединения происходит экономия значительного\r\nколичества энергии на неактивных портах или портах, подключенных к выключенным\r\nкомпьютерам. Коммутатор способен подсчитывать длину любого подключенного кабеля\r\nи применять необходимый режим потребления электропитания, обеспечивая тем самым\r\nэкономию электроэнергии без ущерба для производительности.&nbsp;<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><span style="font-size:\r\n14.0pt;line-height:150%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman;mso-bidi-font-family:Times New Roman;mso-bidi-theme-font:\r\nminor-bidi;color:black">&nbsp;<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><b><span\r\nstyle="font-size:14.0pt;line-height:150%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-bidi-font-family:Times New Roman;\r\nmso-bidi-theme-font:minor-bidi;color:black">Защита окружающей среды</span></b><span\r\nstyle="font-size:14.0pt;line-height:150%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-bidi-font-family:Times New Roman;\r\nmso-bidi-theme-font:minor-bidi;color:black"><o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><span style="font-size:\r\n14.0pt;line-height:150%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman;mso-bidi-font-family:Times New Roman;mso-bidi-theme-font:\r\nminor-bidi;color:black">SW-21600/B разработан в соответствии со стандартом\r\nEnergyStar Level V и постановлениями CEC и MEPS, требующими использования\r\nадаптеров</span><span style="mso-bidi-font-size:14.0pt;line-height:150%;\r\ncolor:black"> <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal style="margin-bottom:0cm;margin-bottom:.0001pt;text-align:\r\njustify;text-justify:inter-ideograph;line-height:150%"><span style="font-size:\r\n14.0pt;line-height:150%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman;mso-bidi-font-family:Times New Roman;mso-bidi-theme-font:\r\nminor-bidi;color:black">питания, сокращающих энергопотребление в целях защиты\r\nокружающей среды. Коммутатор также соответствует стандартам RoHS по ограничению\r\nиспользования вредных веществ и повторному использованию упаковки, что\r\nзначительно сокращает количество отходов согласно директиве WEEE. &nbsp;<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><o:p>&nbsp;</o:p></p>\r\n\r\n<table class=MsoNormalTable border=1 cellspacing=0 cellpadding=0\r\n style="margin-left:42.15pt;border-collapse:collapse;border:none;mso-border-alt:\r\n solid windowtext .5pt;mso-padding-alt:0cm 5.4pt 0cm 5.4pt;mso-border-insideh:\r\n .5pt solid windowtext;mso-border-insidev:.5pt solid windowtext">\r\n <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><b>Настройка<o:p></o:p></b></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border:solid windowtext 1.0pt;\r\n  border-left:none;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:\r\n  solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><b style="mso-bidi-font-weight:\r\n  normal">Значение<o:p></o:p></b></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:1;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2>Тип соединения<span lang=EN-US style="mso-ansi-language:\r\n  EN-US"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">PoE</p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:2;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><span lang=EN-US\r\n  style="mso-ansi-language:EN-US">MTU<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2><span lang=EN-US style="mso-ansi-language:EN-US">1492<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:3;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">LCP интервал<span\r\n  style="mso-bidi-font-weight:bold"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><span lang=EN-US\r\n  style="mso-ansi-language:EN-US">30<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:4;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2>LCP провалы<span lang=EN-US style="mso-ansi-language:\r\n  EN-US"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><span lang=EN-US\r\n  style="mso-ansi-language:EN-US">3<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:5;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2>Версия IGMP<span lang=EN-US style="mso-ansi-language:\r\n  EN-US"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><span lang=EN-US\r\n  style="mso-ansi-language:EN-US">2<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:6;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Адрес шлюза<span lang=EN-US\r\n  style="mso-ansi-language:EN-US;mso-bidi-font-weight:bold"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><span lang=EN-US\r\n  style="mso-ansi-language:EN-US">192.168.</span>2<span lang=EN-US\r\n  style="mso-ansi-language:EN-US">.1</span>4</p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:7;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2>Маска сети<span lang=EN-US style="mso-ansi-language:\r\n  EN-US;mso-bidi-font-weight:bold"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">255.255.255.0<span lang=EN-US\r\n  style="mso-ansi-language:EN-US"><o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:8;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Включить NAT<span lang=EN-US\r\n  style="mso-ansi-language:EN-US;mso-bidi-font-weight:bold"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Да</p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:9;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Включить сетевой экран<span\r\n  lang=EN-US style="mso-ansi-language:EN-US;mso-bidi-font-weight:bold"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Да</p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:10;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Использовать <span lang=EN-US\r\n  style="mso-ansi-language:EN-US">DNS</span>-сервер</p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Да</p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:11;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><span lang=EN-US\r\n  style="mso-ansi-language:EN-US">DNS</span>-сервер 1</p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">213<span lang=EN-US\r\n  style="mso-ansi-language:EN-US">.135.128.2</span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:12;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><span lang=EN-US\r\n  style="mso-ansi-language:EN-US">DNS</span>-сервер <span lang=EN-US\r\n  style="mso-ansi-language:EN-US">2<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt"><span lang=EN-US\r\n  style="color:white;mso-themecolor:background1;mso-ansi-language:EN-US">78.132.128.2</span><span\r\n  style="color:white;mso-themecolor:background1"><o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:13;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Начальный адрес пула <span\r\n  lang=EN-US style="mso-ansi-language:EN-US">IP</span>-адресов</p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">192.168.2.3</p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:14;mso-yfti-lastrow:yes;height:26.25pt">\r\n  <td width=386 valign=top style="width:289.5pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;\r\n  padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">Конечный адрес пула <span\r\n  lang=EN-US style="mso-ansi-language:EN-US">IP</span>-адресов</p>\r\n  </td>\r\n  <td width=201 valign=top style="width:150.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;\r\n  mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:26.25pt">\r\n  <p class=MsoBodyText2 style="text-indent:.4pt">192.168.2.8</p>\r\n  </td>\r\n </tr>\r\n</table>\r\n\r\n<p class=MsoBodyText2 style="text-indent:35.45pt"><o:p>&nbsp;</o:p></p>\r\n\r\n<h1 style="text-indent:35.45pt"><span style="font-family:"Arial","sans-serif" id="003">3\r\nОписание роутера и его настройка<o:p></o:p></span></h1>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<span style="font-size:11.0pt;mso-bidi-font-size:14.0pt;line-height:115%;\r\nfont-family:"Calibri","sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:\r\nTimes New Roman;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:\r\nminor-latin;mso-bidi-font-family:Times New Roman;mso-bidi-theme-font:minor-bidi;\r\nmso-ansi-language:RU;mso-fareast-language:RU;mso-bidi-language:AR-SA"><br\r\nclear=all style="mso-special-character:line-break;page-break-before:always">\r\n</span>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoNormal><!--[if gte vml 1]><v:shape id="Рисунок_x0020_1" o:spid="_x0000_s1030"\r\n type="#_x0000_t75" style="position:absolute;margin-left:8.7pt;margin-top:34.8pt;\r\n width:155.25pt;height:212.25pt;z-index:-5;visibility:visible;mso-wrap-style:square;\r\n mso-wrap-distance-left:9pt;mso-wrap-distance-top:0;mso-wrap-distance-right:9pt;\r\n mso-wrap-distance-bottom:0;mso-position-horizontal:absolute;\r\n mso-position-horizontal-relative:text;mso-position-vertical:absolute;\r\n mso-position-vertical-relative:text">\r\n <v:imagedata src="images/image003.png" o:title="Безымянный"/>\r\n <w:wrap type="square"/>\r\n</v:shape><![endif]--><![if !vml]><img width=207 height=283\r\nsrc="images/image004.jpg" align=left hspace=12 v:shapes="Рисунок_x0020_1"><![endif]><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman>WiFi-роутер ASUS RT-N65U<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Стандарт\r\nWi-Fi - 802.11n <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Количество\r\nпортов коммутатора - 4 шт. <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Маршрутизатор\r\n- Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Статическая\r\nмаршрутизация - Нет <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Межсетевой\r\nэкран (Firewall) - Запущен<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Встроенный\r\nVoIP-адаптер - Нет <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Макс.\r\nскорость беспроводного соединения - 750 Мбит/с <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>DHCP-сервер\r\n- Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>NAT - Запущен\r\n<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Web-сервер\r\n- Нет <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>SPI - Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>WAN-порт -\r\nНет <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>FTP-сервер\r\n- Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Поддержка</span><span\r\nlang=EN-US style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-ansi-language:EN-US"> VPN (VPN\r\npass through) - </span><span style="font-size:14.0pt;line-height:115%;\r\nfont-family:Times New Roman, serif;mso-fareast-font-family:Times New Roman>Да</span><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-ansi-language:EN-US"> <span\r\nlang=EN-US><o:p></o:p></span></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Поддержка\r\nVPN-туннелей (VPN Endpoint) - Да<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Web-интерфейс\r\n- Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Возможность\r\nподключения 3G-модема - Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Интерфейс\r\nвстроенного принт-сервера - USB <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Количество\r\nвнешних антенн - 3 <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Поддержка\r\nIGMP v1 - Нет <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Поддержка\r\nIGMP v2 - Нет <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Поддержка\r\nRIP v1 - Нет <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Поддержка\r\nRIP v2 - Нет <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Метод\r\nшифрования данных WEP - Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Метод\r\nшифрования данных WPA - Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman>Поддержка\r\nTelnet - Да <o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoBodyText2><u><span style="mso-bidi-font-size:14.0pt;line-height:\r\n150%">Радиус действия</span></u><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%"> устройств стандарта 802.11n достигает 250м на открытой\r\nместности и 70 м в помещении.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Маска:\r\n255.255.255.0<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Начальный\r\nадрес пула </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%;mso-ansi-language:EN-US">IP</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">: 192.168.2.14<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Конечный\r\nадрес пула </span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%;mso-ansi-language:EN-US">IP</span><span style="mso-bidi-font-size:14.0pt;\r\nline-height:150%">: 192.168.2.19<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">IP</span><span style="mso-bidi-font-size:\r\n14.0pt;line-height:150%"> адрес устройства: 192.168.2.3<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<h1 style="text-indent:35.45pt"><!--[if gte vml 1]><o:wrapblock><v:shape id="Рисунок_x0020_2"\r\n  o:spid="_x0000_s1029" type="#_x0000_t75" style="position:absolute;left:0;\r\n  text-align:left;margin-left:1.2pt;margin-top:36.9pt;width:345pt;height:180pt;\r\n  z-index:3;visibility:visible;mso-wrap-style:square;mso-wrap-distance-left:9pt;\r\n  mso-wrap-distance-top:0;mso-wrap-distance-right:9pt;\r\n  mso-wrap-distance-bottom:0;mso-position-horizontal:absolute;\r\n  mso-position-horizontal-relative:text;mso-position-vertical:absolute;\r\n  mso-position-vertical-relative:text">\r\n  <v:imagedata src="images/image005.jpg" o:title="951abc8acfcb3a9d826224435385d013"/>\r\n  <w:wrap type="topAndBottom"/>\r\n </v:shape><![endif]--><![if !vml]><span style="mso-ignore:vglayout">\r\n <table cellpadding=0 cellspacing=0>\r\n  <tr>\r\n   <td width=2 height=0></td>\r\n  </tr>\r\n  <tr>\r\n   <td></td>\r\n   <td></td>\r\n  </tr>\r\n </table>\r\n </span><![endif]><!--[if gte vml 1]></o:wrapblock><![endif]--><br\r\nstyle="mso-ignore:vglayout" clear=ALL>\r\n<span style="font-family:"Arial","sans-serif" id="004">4 Описание ноутбуков и их\r\nнастройка<o:p></o:p></span></h1>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Ноутбук\r\nHP DV910r Intel<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Установленная\r\nОС <span style="mso-tab-count:1">      </span>Win 8.1<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Тип\r\n<span style="mso-tab-count:1">  </span>ноутбук<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Процессор\r\n<span style="mso-tab-count:1">         </span>Intel® Celeron<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Частота\r\nпроцессора <span style="mso-tab-count:1">    </span>2160 МГц<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Количество\r\nядер процессора <span style="mso-tab-count:1">        </span>2<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Размер\r\nэкрана <span style="mso-tab-count:1">   </span>15.6 дюйм<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Объем\r\nпамяти <span style="mso-tab-count:1">    </span>2048 Мб<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Тип\r\nпамяти <span style="mso-tab-count:1">        </span>DDR3L<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Частота\r\nпамяти <span style="mso-tab-count:1">  </span>1600 МГц<o:p></o:p></span></p>\r\n\r\n<span style="font-size:11.0pt;mso-bidi-font-size:14.0pt;line-height:115%;\r\nfont-family:"Calibri","sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:\r\nTimes New Roman;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:\r\nminor-latin;mso-bidi-font-family:Times New Roman;mso-bidi-theme-font:minor-bidi;\r\nmso-ansi-language:RU;mso-fareast-language:RU;mso-bidi-language:AR-SA"><br\r\nclear=all style="mso-special-character:line-break;page-break-before:always">\r\n</span>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif;mso-fareast-font-family:Times New Roman><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Размер\r\nдиска <span style="mso-tab-count:1">     </span>500 Гб<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Оптический\r\nпривод <span style="mso-tab-count:1">    </span>DVD-RW<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Чипсет\r\nграфического контроллера <span style="mso-tab-count:1">        </span>Intel® HD\r\nGraphics<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Тип\r\nвидеопамяти <span style="mso-tab-count:1">        </span>SMA<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Порты<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Количество\r\nUSB 2.0 <span style="mso-tab-count:1">   </span>2<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Количество\r\nUSB 3.0 <span style="mso-tab-count:1">   </span>1<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">VGA\r\n(D-Sub) <span style="mso-tab-count:1">     </span>Да<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">HDMI\r\n<span style="mso-tab-count:1">        </span>Да<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Вход\r\nмикрофонный <span style="mso-tab-count:1">    </span>Да<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Выход\r\nаудио/наушники <span style="mso-tab-count:1">      </span>Да<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Проводная\r\n/ Беспроводная связь<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Wi-Fi\r\n<span style="mso-tab-count:1">         </span>Да<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Стандарт\r\nWi-Fi <span style="mso-tab-count:1">  </span>802.11n / 802.11g / 802.11b<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Bluetooth\r\n<span style="mso-tab-count:1">  </span>Да<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Версия\r\nBluetooth <span style="mso-tab-count:1">        </span>4.0<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Сетевая\r\nкарта <span style="mso-tab-count:1">    </span>Встроенная<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Cкорость\r\nсетевой карты <span style="mso-tab-count:1">      </span>1000<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">IP</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%"> </span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">a</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">дреса машин: 192.168.2.15/19<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<h1 style="text-indent:35.45pt"><!--[if gte vml 1]><o:wrapblock><v:shape id="Рисунок_x0020_3"\r\n  o:spid="_x0000_s1028" type="#_x0000_t75" style="position:absolute;left:0;\r\n  text-align:left;margin-left:45.45pt;margin-top:38pt;width:266.25pt;height:199.5pt;\r\n  z-index:4;visibility:visible;mso-wrap-style:square;mso-wrap-distance-left:9pt;\r\n  mso-wrap-distance-top:0;mso-wrap-distance-right:9pt;\r\n  mso-wrap-distance-bottom:0;mso-position-horizontal:absolute;\r\n  mso-position-horizontal-relative:text;mso-position-vertical:absolute;\r\n  mso-position-vertical-relative:text">\r\n  <v:imagedata src="images/image006.jpg" o:title="43535.1424092558"/>\r\n  <w:wrap type="topAndBottom"/>\r\n </v:shape><![endif]--><![if !vml]><span style="mso-ignore:vglayout">\r\n <table cellpadding=0 cellspacing=0>\r\n  <tr>\r\n   <td width=61 height=0></td>\r\n  </tr>\r\n  <tr>\r\n   <td></td>\r\n   <td><img width=355 height=266 src="images/image007.jpg" v:shapes="Рисунок_x0020_3"></td>\r\n  </tr>\r\n </table>\r\n </span><![endif]><!--[if gte vml 1]></o:wrapblock><![endif]--><br\r\nstyle="mso-ignore:vglayout" clear=ALL>\r\n<span style="font-family:"Arial","sans-serif" id="005">5 Описание пк и их настройка<o:p></o:p></span></h1>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">ПК\r\nDNS Office 0803185<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US">Intel Celeron J1800, 2x2410 </span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">МГц</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">, 2 </span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">Гб</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">,\r\n500 </span><span style="mso-bidi-font-size:14.0pt;line-height:150%">Гб</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US"><o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Tип\r\nоперативной памяти<span style="mso-tab-count:1">      </span>DIMM DDR3<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Размер\r\nоперативной памяти<span style="mso-tab-count:1"> </span>2 Гб<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Суммарный\r\nобъем жестких дисков (HDD)<span style="mso-tab-count:1">      </span>500 Гб<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Вид\r\nдоступа в Интернет<span style="mso-tab-count:1">       </span>Ethernet<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Интерфейсы\r\nпериферии<span style="mso-tab-count:1">        </span>USB 2.0 x2<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Адреса\r\nмашин: 192.168.2.4/8<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<h1 style="text-indent:35.45pt"><!--[if gte vml 1]><o:wrapblock><v:shape id="Рисунок_x0020_4"\r\n  o:spid="_x0000_s1027" type="#_x0000_t75" style="position:absolute;left:0;\r\n  text-align:left;margin-left:28.95pt;margin-top:46.05pt;width:243.75pt;\r\n  height:243.75pt;z-index:5;visibility:visible;mso-wrap-style:square;\r\n  mso-wrap-distance-left:9pt;mso-wrap-distance-top:0;mso-wrap-distance-right:9pt;\r\n  mso-wrap-distance-bottom:0;mso-position-horizontal:absolute;\r\n  mso-position-horizontal-relative:text;mso-position-vertical:absolute;\r\n  mso-position-vertical-relative:text">\r\n  <v:imagedata src="images/image008.jpg" o:title="136634"/>\r\n  <w:wrap type="topAndBottom"/>\r\n </v:shape><![endif]--><![if !vml]><span style="mso-ignore:vglayout">\r\n <table cellpadding=0 cellspacing=0>\r\n  <tr>\r\n   <td width=39 height=0></td>\r\n  </tr>\r\n  <tr>\r\n   <td></td>\r\n   <td><img width=325 height=325 src="images/image005.jpg" v:shapes="Рисунок_x0020_4"></td>\r\n  </tr>\r\n </table>\r\n </span><![endif]><!--[if gte vml 1]></o:wrapblock><![endif]--><br\r\nstyle="mso-ignore:vglayout" clear=ALL>\r\n<span style="font-family:"Arial","sans-serif;mso-fareast-language:RU;\r\nmso-no-proof:yes" id="006">6 Медиаконвертор<o:p></o:p></span></h1>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Конвертер/мост\r\nNSGate qBRIDGE-100<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Описание:<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Конвертер/\r\nмост: 1 Ethernet, 1 порт E1 (unframed), DIP switch, 220VAC. нвертер/ мост,\r\nпредназначенный для соединения удаленных сегментов LAN через стандартные каналы\r\nE1, работающие в режиме передачи неструктурированного потока данных с\r\nфиксированной скоростью 2.048 Mbps (E1 Unframed), с интерфейсом G.703.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Кроме\r\nэтого, устройство можно использовать для работы на физической линии (две медные\r\nвитые пары), длина которой может достигать 1,8 км при диаметре жилы 0,5 мм.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Благодаря\r\nвысокопроизводительному аппаратному ядру, конвертеры никогда не зависают и не\r\nтеряют пакетов (особенно это важно при работе с короткими пакетами).<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Конвертер,\r\nработающий в режиме &quot;Bridge connection&quot;, прозрачен для &quot;tagged\r\nVLAN&quot; пакетов, имеет один порт Ethernet 10/100Base-TX с автоопределением\r\nскорости и типа UTP кабеля, один порт E1 и ряд DIP переключателей для конфигурации,\r\nс помощью которых осуществляется выбор следующих функций и характеристик:\r\nразмер буфера кадров между встречными пакетами, установка режима фильтрации\r\nконтроллера LAN, режима управления потоком IEEE 802.3x, режима работы\r\nинтерфейса E1, внутреннего или внешнего источника синхронизации<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n<img width=260 height=240 src="images/image009.jpg" />\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">qBRIDGE-100\r\nдополняют модельный ряд популярной серии экономичных устройств доступа\r\nqBRIDGE®, которые предназначены для соединения удаленных сегментов LAN с\r\nиспользованием различных технологий. Отличительными особенностями серии\r\nявляются простота конфигурирования, высокая производительность и надежность,\r\nдоступная цена.<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">Технические\r\nхарактеристики NSGate qBRIDGE-100:<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%">1\r\nпорт Ethernet 10/100Base-TX<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Поддержка</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">\r\nIEEE 802.3/802.3u<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"><span style="mso-spacerun:yes">   \r\n</span></span><span style="mso-bidi-font-size:14.0pt;line-height:150%">Поддержка</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US"> IEEE 802.3x flow control<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"><span style="mso-spacerun:yes">   \r\n</span>Autonegotiation &amp; Auto-MDIX<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"><span style="mso-spacerun:yes">   \r\n</span></span><span style="mso-bidi-font-size:14.0pt;line-height:150%">Инкапсуляция</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US"> Ethernet </span><span style="mso-bidi-font-size:14.0pt;line-height:\r\n150%">в</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:\r\n150%;mso-ansi-language:EN-US"> HDLC<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"><span style="mso-spacerun:yes">   \r\n</span></span><span style="mso-bidi-font-size:14.0pt;line-height:150%">Прозрачный</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US"> </span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">режим</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US"> </span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">для</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">\r\nVLAN </span><span style="mso-bidi-font-size:14.0pt;line-height:150%">пакетов</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US"><o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"><span style="mso-spacerun:yes">   \r\n</span>IEEE 802.1D transparent learning bridge<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"><span style="mso-spacerun:yes">   \r\n</span></span><span style="mso-bidi-font-size:14.0pt;line-height:150%">Емкость</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US"> </span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">таблицы</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US"> </span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">МАС</span><span lang=EN-US\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:EN-US">-</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">адресов</span><span\r\nlang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;mso-ansi-language:\r\nEN-US">: 256<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"><span style="mso-spacerun:yes">   \r\n</span>Filtering and Forwarding: 90,000 pps<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span lang=EN-US style="mso-bidi-font-size:14.0pt;\r\nline-height:150%;mso-ansi-language:EN-US"><span style="mso-spacerun:yes">   \r\n</span></span><span style="mso-bidi-font-size:14.0pt;line-height:150%">Буфер кадров\r\n(</span><span lang=EN-US style="mso-bidi-font-size:14.0pt;line-height:150%;\r\nmso-ansi-language:EN-US">Frame</span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%"> </span><span lang=EN-US style="mso-bidi-font-size:\r\n14.0pt;line-height:150%;mso-ansi-language:EN-US">Buffer</span><span\r\nstyle="mso-bidi-font-size:14.0pt;line-height:150%">): 340<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Электрический интерфейс: G.703<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Скорость передачи: 2048 KbpsРежим работы:\r\nдуплексный<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Линейный код: HDB3<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Импеданс: 120 Ohm Balanced<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Допустимое дрожание частоты: ITU-T G.823<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Допустимое затухание сигнала 43 дБ (1024\r\nкГц)<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Cинхронизация: внутренняя/внешняя<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>DIP переключатели для настройки<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Светодиодные индикаторы состояния<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Энергопитание: адаптер 9V/1А<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Потребляемая мощность: менее 2 Вт<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Размеры: 80x135x27 мм (пластик)<o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><span\r\nstyle="mso-spacerun:yes">    </span>Вес: 0,3 Kg <o:p></o:p></span></p>\r\n\r\n<p class=MsoBodyText2><span style="mso-bidi-font-size:14.0pt;line-height:150%"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<h1 style="text-indent:35.45pt"><span style="font-family:"Arial","sans-serif;\r\nmso-fareast-language:RU;mso-no-proof:yes" id="007">7 Критерии корректности сети<o:p></o:p></span></h1>\r\n\r\n<p class=MsoNormal style="text-align:justify;text-justify:inter-ideograph"><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif">Чтобы\r\nсеть </span><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\nfont-family:Times New Roman, serif;mso-ansi-language:EN-US">Ethernet</span><span\r\nstyle="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif">,\r\nсостоящая из сегментов различной физической природы, работала корректно,\r\nнеобходимо выполнение четырех основных условий:</span><span style="font-family:\r\nTimes New Roman, serif"><o:p></o:p></span></p>\r\n\r\n<p class=MsoListParagraphCxSpFirst style="margin-left:53.45pt;mso-add-space:\r\nauto;text-align:justify;text-justify:inter-ideograph;text-indent:-18.0pt;\r\nmso-list:l1 level1 lfo2"><![if !supportLists]><span style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman><span style="mso-list:Ignore">1.<span style="font:7.0pt Times New Roman>&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]><span style="font-size:14.0pt;line-height:115%;\r\nfont-family:Times New Roman, serif">количество ПК-станций в сети - не более\r\n1024 штук;<o:p></o:p></span></p>\r\n\r\n<p class=MsoListParagraphCxSpMiddle style="margin-left:53.45pt;mso-add-space:\r\nauto;text-align:justify;text-justify:inter-ideograph;text-indent:-18.0pt;\r\nmso-list:l1 level1 lfo2"><![if !supportLists]><span style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman><span style="mso-list:Ignore">2.<span style="font:7.0pt Times New Roman>&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]><span style="font-size:14.0pt;line-height:115%;\r\nfont-family:Times New Roman, serif">максимальная длина каждого физического\r\nсегмента - не более величины, определенной в соответствующем стандарте\r\nфизического уровня (100 метров для витой пары);<o:p></o:p></span></p>\r\n\r\n<p class=MsoListParagraphCxSpMiddle style="margin-left:53.45pt;mso-add-space:\r\nauto;text-align:justify;text-justify:inter-ideograph;text-indent:-18.0pt;\r\nmso-list:l1 level1 lfo2"><![if !supportLists]><span style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman><span style="mso-list:Ignore">3.<span style="font:7.0pt Times New Roman>&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]><span style="font-size:14.0pt;line-height:115%;\r\nfont-family:Times New Roman, serif">время двойного оборота сигнала (Path Delay\r\nValue, PDV) между двумя самыми удаленными друг от друга ПК-станциями сети - не\r\nболее 575 битовых интервала (расчитывается);<o:p></o:p></span></p>\r\n\r\n<p class=MsoListParagraphCxSpLast style="margin-left:53.45pt;mso-add-space:\r\nauto;text-align:justify;text-justify:inter-ideograph;text-indent:-18.0pt;\r\nmso-list:l1 level1 lfo2"><![if !supportLists]><span style="font-size:14.0pt;\r\nline-height:115%;font-family:Times New Roman, serif;mso-fareast-font-family:\r\nTimes New Roman><span style="mso-list:Ignore">4.<span style="font:7.0pt Times New Roman>&nbsp;&nbsp;&nbsp;&nbsp;\r\n</span></span></span><![endif]><span style="font-size:14.0pt;line-height:115%;\r\nfont-family:Times New Roman, serif">сокращение межкадрового интервала (Path Variability\r\nValue, PVV) при прохождении последовательности кадров через все повторители -\r\nне больше, чем 49 битовых интервала (так как при отправке кадров конечные узлы\r\nобеспечивают начальное межкадровое расстояние в 96 битовых интервала, то после\r\nпрохождения повторителя оно должно быть не меньше, чем 96 - 49 = 47 битовых\r\nинтервала).<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Правила 1, 2, 4 выполняются, количество станций – 10\r\nштук, длина сегментов: витая пара – 15 метров (самый дальний маршрут от коммутатора),\r\nдлинной оптоволокона можно принебречь (затухание слишком мало), от роутера до\r\nдальнего ноутбука 27 метров, что является вполне рабочим диапазоном для\r\nстандарта 802.11n. 4 пункт можно опустить, так как локальная схема не включает\r\nповторители сигнала (размеры помещения позволяют обойтись без него).<o:p></o:p></span></p>\r\n\r\n<p><i style="mso-bidi-font-style:normal"><span style="font-size:14.0pt;\r\nmso-fareast-font-family:Times New Roman;mso-fareast-theme-font:minor-fareast">Сегмент\r\nсети</span></i><span style="font-size:14.0pt;mso-fareast-font-family:Times New Roman;\r\nmso-fareast-theme-font:minor-fareast"> (network segment) - участок локальной\r\nсети, отделенный от других повторителем, концентратором, мостом или\r\nмаршрутизатором. Т. е., совокупность машин, для передачи данных между которыми\r\nдостаточно протокола канального уровня. <o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Рассчитаем значение PDV. <o:p></o:p></span></p>\r\n\r\n<span style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-fareast-theme-font:minor-fareast;\r\nmso-ansi-language:RU;mso-fareast-language:RU;mso-bidi-language:AR-SA"><br\r\nclear=all style="mso-special-character:line-break;page-break-before:always">\r\n</span>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoNormal><!--[if gte vml 1]><o:wrapblock><v:shape id="_x0000_s1026"\r\n  type="#_x0000_t75" style="position:absolute;margin-left:43.05pt;margin-top:.4pt;\r\n  width:353.45pt;height:510.2pt;z-index:6;visibility:visible;mso-wrap-style:square;\r\n  mso-wrap-distance-left:9pt;mso-wrap-distance-top:0;mso-wrap-distance-right:9pt;\r\n  mso-wrap-distance-bottom:0;mso-position-horizontal:absolute;\r\n  mso-position-horizontal-relative:text;mso-position-vertical:absolute;\r\n  mso-position-vertical-relative:text">\r\n  <v:imagedata src="images/image010.png" o:title="/>\r\n  <w:wrap type="topAndBottom"/>\r\n </v:shape><![endif]--><![if !vml]><span style="mso-ignore:vglayout">\r\n <table cellpadding=0 cellspacing=0>\r\n  <tr>\r\n   <td width=58 height=0></td>\r\n  </tr>\r\n  <tr>\r\n   <td></td>\r\n   <td><img width=471 height=680 src="images/image011.jpg" v:shapes="_x0000_s1026"></td>\r\n  </tr>\r\n </table>\r\n </span><![endif]><!--[if gte vml 1]></o:wrapblock><![endif]--><br\r\nstyle="mso-ignore:vglayout" clear=ALL>\r\n<span style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif">Руководствуясь\r\nопределением сегмента, приведенным выше, условимся рассматривать 3 сегмента для\r\nлокальной сети, при этом один – связь по оптоволокну можно опустить (нет\r\nпродолжения схемы от медиаконвертора). <o:p></o:p></span></p>\r\n\r\n<span style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-fareast-font-family:Times New Roman;mso-fareast-theme-font:minor-fareast;\r\nmso-ansi-language:RU;mso-fareast-language:RU;mso-bidi-language:AR-SA"><br\r\nclear=all style="mso-special-character:line-break;page-break-before:always">\r\n</span>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif"><o:p>&nbsp;</o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Таблица 1 - Данные для расчета значения </span><span\r\nlang=EN-US style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-ansi-language:EN-US">PDV</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n\r\n<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0\r\n style="margin-left:2.0pt;border-collapse:collapse;mso-padding-alt:0cm 2.0pt 0cm 2.0pt">\r\n <tr style="mso-yfti-irow:0;mso-yfti-firstrow:yes;height:42.7pt">\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  42.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">Тип сегмента<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-left:none;mso-border-left-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:42.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">База левого сегмента, </span><span lang=EN-US\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\n  mso-ansi-language:EN-US">bt</span><span style="font-size:14.0pt;line-height:\r\n  115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border:solid windowtext 1.0pt;\r\n  border-left:none;mso-border-left-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:42.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">База промежуточного сегмента, </span><span\r\n  lang=EN-US style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\n  mso-ansi-language:EN-US">bt</span><span style="font-size:14.0pt;line-height:\r\n  115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-left:none;mso-border-left-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:42.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">База правого сегмента, </span><span lang=EN-US\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\n  mso-ansi-language:EN-US">bt</span><span style="font-size:14.0pt;line-height:\r\n  115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border:solid windowtext 1.0pt;\r\n  border-left:none;mso-border-left-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:42.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">Задержка среды на <st1:metricconverter\r\n  ProductID="1 м" w:st="on">1 м</st1:metricconverter>, </span><span lang=EN-US\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\n  mso-ansi-language:EN-US">bt</span><span style="font-size:14.0pt;line-height:\r\n  115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=106 valign=top style="width:79.2pt;border:solid windowtext 1.0pt;\r\n  border-left:none;mso-border-left-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:42.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">Максимальная длина сегмента, м<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:1;height:17.75pt">\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:17.75pt">\r\n  <p class=MsoNormal><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif;mso-ansi-language:EN-US">10Base-5</span><span\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">11,8<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">46,5<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">169,5<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">0,0866<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=106 valign=top style="width:79.2pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">500<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:2;height:17.75pt">\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:17.75pt">\r\n  <p class=MsoNormal><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif;mso-ansi-language:EN-US">10Base-2</span><span\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">11,8<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">46,5<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">169,5<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">0,1026<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=106 valign=top style="width:79.2pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">185<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:3;height:17.75pt">\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:17.75pt">\r\n  <p class=MsoNormal><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif;mso-ansi-language:EN-US">10Base-T</span><span\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">15,3<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">42,0<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">165,0<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">0,113<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=106 valign=top style="width:79.2pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">100<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:4;height:17.75pt">\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:17.75pt">\r\n  <p class=MsoNormal><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif;mso-ansi-language:EN-US">10Base-FB</span><span\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">-<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">24,0<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">-<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><b><span style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif">од</span></b><span style="font-size:\r\n  14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=106 valign=top style="width:79.2pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">2000<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:5;height:17.75pt">\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:17.75pt">\r\n  <p class=MsoNormal><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif;mso-ansi-language:EN-US">10Base-FL</span><span\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">12,3<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">33,5<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">156,5<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><b><span style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif">од</span></b><span style="font-size:\r\n  14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=106 valign=top style="width:79.2pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">2000<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:6;height:17.75pt">\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:17.75pt">\r\n  <p class=MsoNormal><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif;mso-ansi-language:EN-US">FOIRL</span><span\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">7,8<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">29,0<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">152,0<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><b><span style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif">од</span></b><span style="font-size:\r\n  14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=106 valign=top style="width:79.2pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  17.75pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">1000<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n <tr style="mso-yfti-irow:7;mso-yfti-lastrow:yes;height:18.7pt">\r\n  <td width=104 valign=top style="width:78.25pt;border:solid windowtext 1.0pt;\r\n  border-top:none;mso-border-top-alt:solid windowtext .75pt;mso-border-alt:\r\n  solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:18.7pt">\r\n  <p class=MsoNormal><span lang=EN-US style="font-size:14.0pt;line-height:115%;\r\n  font-family:Times New Roman, serif;mso-ansi-language:EN-US">AUI (&gt;<st1:metricconverter\r\n  ProductID="2 M" w:st="on">2 m</st1:metricconverter>)</span><span\r\n  style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif"><o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  18.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">0<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  18.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">0<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:78.25pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  18.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">0<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=104 valign=top style="width:77.75pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  18.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">0,1026<o:p></o:p></span></p>\r\n  </td>\r\n  <td width=106 valign=top style="width:79.2pt;border-top:none;border-left:\r\n  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;\r\n  mso-border-top-alt:solid windowtext .75pt;mso-border-left-alt:solid windowtext .75pt;\r\n  mso-border-alt:solid windowtext .75pt;padding:0cm 2.0pt 0cm 2.0pt;height:\r\n  18.7pt">\r\n  <p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\n  Times New Roman, serif">2+48<o:p></o:p></span></p>\r\n  </td>\r\n </tr>\r\n</table>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Задержка распространения сигнала вдоль кабеля\r\nсегмента зависит от длины сегмента и вычисляется путем умножения времени\r\nраспространения сигнала по одному метру кабеля (в битовых интервалах) на длину\r\nкабеля в метрах.<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Сегмент кабеля 100Вase-T: 15(м) * 1,1(</span><span\r\nlang=EN-US style="font-size:14.0pt;line-height:115%;font-family:Times New Roman, serif;\r\nmso-ansi-language:EN-US">bt</span><span style="font-size:14.0pt;line-height:\r\n115%;font-family:Times New Roman, serif">) = 16,5 (bt).<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Коммутатор не вносит задержек.<o:p></o:p></span></p>\r\n\r\n<p class=MsoNormal><span style="font-size:14.0pt;line-height:115%;font-family:\r\nTimes New Roman, serif">Сумма задержки равна 16,5 bt &lt; 512 bt, это\r\nговорит о том, что сеть корректна.<o:p></o:p></span></p>\r\n\r\n<a href="download/LVS.7z" title="Cкачать">*Исходный код проекта доступен для скачивания.</a>\r\n</div>\r\n');

-- --------------------------------------------------------

--
-- Структура таблицы `microsxema`
--

CREATE TABLE IF NOT EXISTS `microsxema` (
  `name` varchar(100) NOT NULL,
  `ik0` double NOT NULL,
  `ik1` double NOT NULL,
  `uk0` double NOT NULL,
  `uk1` double NOT NULL,
  `uk2` double NOT NULL,
  `pk` double NOT NULL,
  `tc0` double NOT NULL,
  `tc1` double NOT NULL,
  `tc2` double NOT NULL,
  `h21` varchar(100) NOT NULL,
  `ukb` double NOT NULL,
  `ikb` double NOT NULL,
  `uke` double NOT NULL,
  `ikbo` double NOT NULL,
  `fgr` double NOT NULL,
  `kh` double NOT NULL,
  `ck` double NOT NULL,
  `ca` double NOT NULL,
  `tpac` double NOT NULL,
  `rtnc` double NOT NULL,
  `title` longtext NOT NULL,
  `picture` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `microsxema`
--

INSERT INTO `microsxema` (`name`, `ik0`, `ik1`, `uk0`, `uk1`, `uk2`, `pk`, `tc0`, `tc1`, `tc2`, `h21`, `ukb`, `ikb`, `uke`, `ikbo`, `fgr`, `kh`, `ck`, `ca`, `tpac`, `rtnc`, `title`, `picture`) VALUES
('k140ud1', 6.3, 2.8, 6, 7, 4.5, 7, 2.5, 500, 60, '301.12-1', 60, 1, 1.5, 50, 300, 0.1, 0, 0, 0, 0, 'Операционные усилители средней точности, без частотной коррекции, с усилением 500...12000.', 'k140ud1'),
('k147la3', 0, 0, 123, 0, 0, 33, 0, 0, 0, '301.11', 33, 5, 0, 64, 22, 0, 2, 4, 54, 44, 'Дешифратор', 'h140ud20'),
('kp140ma1', 12, 2.8, 2.8, 14, 30, 10, 2, 50, 15, '201.14-1', 5.3, 7.3, 1, 0, 0, 0, 0, 0, 0, 0, 'Балансный модулятор', 'kp140ma1');

-- --------------------------------------------------------

--
-- Структура таблицы `tarakan`
--

CREATE TABLE IF NOT EXISTS `tarakan` (
  `name` varchar(6) NOT NULL DEFAULT '',
  `COL 2` varchar(3) DEFAULT NULL,
  `COL 3` varchar(3) DEFAULT NULL,
  `COL 4` varchar(4) DEFAULT NULL,
  `COL 5` varchar(3) DEFAULT NULL,
  `COL 6` varchar(3) DEFAULT NULL,
  `COL 7` varchar(3) DEFAULT NULL,
  `COL 8` varchar(3) DEFAULT NULL,
  `COL 9` varchar(3) DEFAULT NULL,
  `COL 10` varchar(3) DEFAULT NULL,
  `COL 11` varchar(9) DEFAULT NULL,
  `COL 12` varchar(3) DEFAULT NULL,
  `COL 13` varchar(3) DEFAULT NULL,
  `COL 14` varchar(3) DEFAULT NULL,
  `COL 15` varchar(4) DEFAULT NULL,
  `COL 16` varchar(3) DEFAULT NULL,
  `COL 17` varchar(2) DEFAULT NULL,
  `COL 18` varchar(2) DEFAULT NULL,
  `COL 19` varchar(2) DEFAULT NULL,
  `COL 20` varchar(4) DEFAULT NULL,
  `COL 21` varchar(4) DEFAULT NULL,
  `COL 22` varchar(68) DEFAULT NULL,
  `COL 23` varchar(7) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tarakan`
--

INSERT INTO `tarakan` (`name`, `COL 2`, `COL 3`, `COL 4`, `COL 5`, `COL 6`, `COL 7`, `COL 8`, `COL 9`, `COL 10`, `COL 11`, `COL 12`, `COL 13`, `COL 14`, `COL 15`, `COL 16`, `COL 17`, `COL 18`, `COL 19`, `COL 20`, `COL 21`, `COL 22`, `COL 23`) VALUES
('1Т308А', '50', '120', '15', '20', '3', '150', '45', '85', '70', '25...75', '1', '10', '1,5', '5', '100', '', '8', '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('1Т308Б', '50', '120', '15', '20', '3', '150', '45', '85', '70', '22...57', '1', '10', '1,2', '5', '120', '', '8', '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('1Т308В', '51', '120', '16', '21', '4', '150', '46', '85', '70', '12...14', '2', '11', '1,2', '6', '120', '8', '8', '22', '2', '', 'для работы в автогенераторах, усилителях тока, импульсных схемах', 'p12'),
('1Т308Г', '50', '120', '15', '20', '3', '150', '45', '85', '70', '100...300', '1', '10', '', '5', '120', '6', '8', '22', '', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('1Т309А', '10', '0', '10', '0', '0', '50', '20', '70', '55', '20...70', '5', '5', '0', '5', '120', '0', '10', '0', '0', '100', 'для применения в схемах усиления высокой частоты', 'p16'),
('me', 'ik0', 'ik1', 'uk0', 'uk1', 'uk2', 'pk', 'tc0', 'tc1', 'tc2', 'h21', 'ukb', 'ikb', 'uke', 'ikbo', 'fgr', 'kh', 'ck', 'ca', 'tpac', 'rtnc', 'title', 'picture'),
('ГТ308А', '22', '120', '17,2', '20', '2', '150', '11', '85', '70', '2...34', '1', '10', '1,5', '5', '100', '', '8', '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('ГТ308Б', '22', '120', '15', '20', '3', '150', '45', '85', '70', '50...120', '1', '10', '1,2', '5', '120', '', '8', '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('ГТ308В', '50', '120', '15', '20', '3', '150', '45', '85', '70', '80...150', '1', '10', '1,2', '5', '120', '8', '8', '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('ГТ308Г', '50', '120', '15', '20', '3', '150', '45', '85', '70', '90...200', '1', '10', '1,2', '5', '120', '', '8', '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('ГТ309А', '10', '0', '10', '0', '0', '50', '20', '70', '55', '60...180', '5', '5', '0', '5', '120', '0', '10', '0', '0', '100', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ309Б', '', '', '', '', '', '', '', '38', '', '33...67', '', '', '', '0', '', '', '0', '', '', '100', 'для применения в схемах усиления высокой частоты', 'p23a'),
('ГТ309В', '12', '3', '54', '2', '34', '12', '44', '32', '', '12...43', '', '', '', '0', '', '22', '0', '', '', '2', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ309Г', '', '', '61', '', '29', '', '', '38', '', '60...80', '', '10', '6', '2', '', '', '7', '6', '4', '93', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ309Д', '', '', '', '', '', '', '', '', '', '60...80', '45', '23', '44', '0', '', '', '23', '34', '', '123', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ309Е', '1', '1', '1', '1', '1', '1', '1', '1', '1', '60...80', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', 'для применения в схемах усиления высокой частоты', 'p16');

-- --------------------------------------------------------

--
-- Структура таблицы `transistor`
--

CREATE TABLE IF NOT EXISTS `transistor` (
  `name` varchar(6) NOT NULL DEFAULT '',
  `ik0` varchar(2) DEFAULT NULL,
  `ik1` varchar(3) DEFAULT NULL,
  `uk0` varchar(4) DEFAULT NULL,
  `uk1` varchar(2) DEFAULT NULL,
  `uk2` varchar(2) DEFAULT NULL,
  `pk` varchar(3) DEFAULT NULL,
  `tc0` varchar(2) DEFAULT NULL,
  `tc1` varchar(2) DEFAULT NULL,
  `tc2` varchar(2) DEFAULT NULL,
  `h21` varchar(9) DEFAULT NULL,
  `ukb` varchar(2) DEFAULT NULL,
  `ikb` varchar(2) DEFAULT NULL,
  `uke` varchar(3) DEFAULT NULL,
  `ikbo` int(1) DEFAULT NULL,
  `fgr` varchar(3) DEFAULT NULL,
  `kh` varchar(2) DEFAULT NULL,
  `ck` int(2) DEFAULT NULL,
  `ca` varchar(2) DEFAULT NULL,
  `tpac` varchar(1) DEFAULT NULL,
  `rtnc` varchar(3) DEFAULT NULL,
  `title` varchar(68) DEFAULT NULL,
  `picture` varchar(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `transistor`
--

INSERT INTO `transistor` (`name`, `ik0`, `ik1`, `uk0`, `uk1`, `uk2`, `pk`, `tc0`, `tc1`, `tc2`, `h21`, `ukb`, `ikb`, `uke`, `ikbo`, `fgr`, `kh`, `ck`, `ca`, `tpac`, `rtnc`, `title`, `picture`) VALUES
('1Т308А', '50', '120', '15', '20', '3', '150', '45', '85', '70', '25...75', '1', '10', '1,5', 5, '100', '', 8, '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('1Т308Б', '50', '120', '15', '20', '3', '150', '45', '85', '70', '22...57', '1', '10', '1,2', 5, '120', '', 8, '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('1Т308В', '51', '120', '16', '21', '4', '150', '46', '85', '70', '12...14', '2', '11', '1,2', 6, '120', '8', 8, '22', '2', '', 'для работы в автогенераторах, усилителях тока, импульсных схемах', 'p12'),
('1Т308Г', '50', '120', '15', '20', '3', '150', '45', '85', '70', '100...300', '1', '10', '', 5, '120', '6', 8, '22', '', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('1Т309А', '10', '0', '10', '0', '0', '50', '20', '70', '55', '20...70', '5', '5', '0', 5, '120', '0', 10, '0', '0', '100', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ308А', '22', '120', '17,2', '20', '2', '150', '11', '85', '70', '2...34', '1', '10', '1,5', 5, '100', '', 8, '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('ГТ308Б', '22', '120', '15', '20', '3', '150', '45', '85', '70', '50...120', '1', '10', '1,2', 5, '120', '', 8, '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('ГТ308В', '50', '120', '15', '20', '3', '150', '45', '85', '70', '80...150', '1', '10', '1,2', 5, '120', '8', 8, '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('ГТ308Г', '50', '120', '15', '20', '3', '150', '45', '85', '70', '90...200', '1', '10', '1,2', 5, '120', '', 8, '22', '1', '', 'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32'),
('ГТ309А', '10', '0', '10', '0', '0', '50', '20', '70', '55', '60...180', '5', '5', '0', 5, '120', '0', 10, '0', '0', '100', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ309Б', '', '', '', '', '', '', '', '38', '', '33...67', '', '', '', 0, '', '', 0, '', '', '100', 'для применения в схемах усиления высокой частоты', 'p23a'),
('ГТ309В', '12', '3', '54', '2', '34', '12', '44', '32', '', '12...43', '', '', '', 0, '', '22', 0, '', '', '2', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ309Г', '47', '9.0', '61.0', '-6', '29', '3.0', '5.', '38', '16', '60...80', '-3', '10', '6', 2, '17.', '11', 7, '6', '4', '93', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ309Д', '13', '23.', '', '', '', '14.', '12', '', '-2', '60...80', '45', '23', '44', 11, '-33', '', 23, '34', '8', '123', 'для применения в схемах усиления высокой частоты', 'p16'),
('ГТ309Е', '1', '1', '1', '1', '1', '1', '21', '12', '1', '60...80', '1', '1', '1', 1, '1', '1', 1, '1', '5', '1', 'для применения в схемах усиления высокой частоты', 'p16');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `microsxema`
--
ALTER TABLE `microsxema`
  ADD PRIMARY KEY (`name`);

--
-- Индексы таблицы `tarakan`
--
ALTER TABLE `tarakan`
  ADD PRIMARY KEY (`name`);

--
-- Индексы таблицы `transistor`
--
ALTER TABLE `transistor`
  ADD PRIMARY KEY (`name`);
--
-- База данных: `webauth`
--

-- --------------------------------------------------------

--
-- Структура таблицы `user_pwd`
--

CREATE TABLE IF NOT EXISTS `user_pwd` (
  `name` char(30) COLLATE latin1_general_ci NOT NULL DEFAULT '',
  `pass` char(32) COLLATE latin1_general_ci NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Дамп данных таблицы `user_pwd`
--

INSERT INTO `user_pwd` (`name`, `pass`) VALUES
('xampp', 'wampp');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `user_pwd`
--
ALTER TABLE `user_pwd`
  ADD PRIMARY KEY (`name`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
