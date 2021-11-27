-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Время создания: Янв 04 2016 г., 02:17
-- Версия сервера: 5.6.24
-- Версия PHP: 5.6.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `test`
--

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

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `microsxema`
--
ALTER TABLE `microsxema`
  ADD PRIMARY KEY (`name`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
