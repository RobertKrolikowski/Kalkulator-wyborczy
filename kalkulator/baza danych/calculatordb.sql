-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 20 Maj 2018, 09:35
-- Wersja serwera: 10.1.32-MariaDB
-- Wersja PHP: 7.2.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `calculatordb`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `candidates`
--

CREATE TABLE `candidates` (
  `idcandidate` int(11) NOT NULL,
  `name` varchar(80) COLLATE utf8mb4_polish_ci NOT NULL,
  `party` varchar(30) COLLATE utf8mb4_polish_ci NOT NULL,
  `numbersofvotes` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `candidates`
--

INSERT INTO `candidates` (`idcandidate`, `name`, `party`, `numbersofvotes`) VALUES
(14, 'votes invalid', 'votes invalid', 3),
(15, 'Mieszko I', 'Piastowie', 0),
(16, 'Bolesław Chrobry', 'Piastowie', 0),
(17, 'Władysław Łokietek', 'Piastowie', 0),
(18, 'Kazimierz Wielki', 'Piastowie', 0),
(19, 'Władysław Jagiełło', 'Dynastia Jagiellonów', 0),
(20, 'Władysław Warneńczyk', 'Dynastia Jagiellonów', 0),
(21, 'Zygmunt Stary', 'Dynastia Jagiellonów', 0),
(22, 'Henryk Walezy', 'Elekcyjni dla Polski', 0),
(23, 'Anna Jagiellonka', 'Elekcyjni dla Polski', 1),
(24, 'Stefan Batory', 'Elekcyjni dla Polski', 0),
(25, 'Zygmunt Waza', 'Wazowie', 0),
(26, 'Władysław Waza', 'Wazowie', 0),
(27, 'Jan Kazimierz', 'Wazowie', 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `user`
--

CREATE TABLE `user` (
  `iduser` int(11) NOT NULL,
  `firstname` varchar(30) COLLATE utf8mb4_polish_ci NOT NULL,
  `lastname` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `pesel` varchar(11) COLLATE utf8mb4_polish_ci NOT NULL,
  `logged` tinyint(4) NOT NULL DEFAULT '0',
  `voted` tinyint(4) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Zrzut danych tabeli `user`
--

INSERT INTO `user` (`iduser`, `firstname`, `lastname`, `pesel`, `logged`, `voted`) VALUES
(1, 'Adam', '\0Nowak', '23011704934', 0, 0),
(2, 'Jan', 'Struś', '54070702117', 0, 1),
(3, '', '', '73101015127', 0, 1),
(4, '', '', '85112002162', 0, 1),
(5, '', '', '77071107194', 0, 1),
(13, '', '', '50051302705', 0, 1),
(14, '', '', '70022516717', 0, 1),
(15, '', '', '58052918138', 0, 1),
(35, 'H', 'H', '00000000000', 0, 0);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `candidates`
--
ALTER TABLE `candidates`
  ADD PRIMARY KEY (`idcandidate`);

--
-- Indeksy dla tabeli `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`iduser`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `candidates`
--
ALTER TABLE `candidates`
  MODIFY `idcandidate` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT dla tabeli `user`
--
ALTER TABLE `user`
  MODIFY `iduser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
