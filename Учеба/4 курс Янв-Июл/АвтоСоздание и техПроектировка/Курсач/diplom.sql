-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Мар 19 2016 г., 22:13
-- Версия сервера: 5.6.24
-- Версия PHP: 5.6.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
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

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
