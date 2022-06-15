-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 06/05/2021 às 23:44
-- Versão do servidor: 10.4.18-MariaDB
-- Versão do PHP: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `destinocerto`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `pacotesturisticos`
--

CREATE TABLE `pacotesturisticos` (
  `Id` int(4) NOT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `Origem` varchar(80) DEFAULT NULL,
  `Destino` varchar(80) DEFAULT NULL,
  `Atrativos` varchar(200) DEFAULT NULL,
  `Saida` datetime DEFAULT NULL,
  `Retorno` datetime DEFAULT NULL,
  `Usuario` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(4) NOT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `Login` varchar(80) DEFAULT NULL,
  `Senha` varchar(90) DEFAULT NULL,
  `DataNascimento` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `Login`, `Senha`, `DataNascimento`) VALUES
(7, '123', '123', '123', '2021-05-13 00:00:00'),
(8, '123', '123', '123', '2021-05-06 00:00:00');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Usuario` (`Usuario`);

--
-- Índices de tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD CONSTRAINT `pacotesturisticos_ibfk_1` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
