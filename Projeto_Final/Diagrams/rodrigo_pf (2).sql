-- phpMyAdmin SQL Dump
-- version 4.5.4.1deb2ubuntu2.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Tempo de geração: 19/11/2022 às 11:51
-- Versão do servidor: 5.7.33-0ubuntu0.16.04.1
-- Versão do PHP: 7.0.33-0ubuntu0.16.04.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `rodrigo_pf`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `matricula`
--

CREATE TABLE `matricula` (
  `id_matricula` int(11) NOT NULL,
  `id_aluno` varchar(14) NOT NULL,
  `id_turma` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Fazendo dump de dados para tabela `matricula`
--

INSERT INTO `matricula` (`id_matricula`, `id_aluno`, `id_turma`) VALUES
(2, '69696969696', 2),
(3, '69696969696', 1),
(4, '15942073951', 4),
(5, '78964564563', 5),
(6, '15942073951', 3),
(7, '78964564563', 4),
(8, '15942073951', 3),
(9, '78964564563', 3),
(10, '78964564563', 3);

-- --------------------------------------------------------

--
-- Estrutura para tabela `pessoa`
--

CREATE TABLE `pessoa` (
  `cpf` varchar(14) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telefone` varchar(14) NOT NULL,
  `senha` varchar(16) NOT NULL,
  `nivel_acesso` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Fazendo dump de dados para tabela `pessoa`
--

INSERT INTO `pessoa` (`cpf`, `nome`, `email`, `telefone`, `senha`, `nivel_acesso`) VALUES
('05815942073', 'Rodrigo Gomes', 'rodrigo.gmssouza@gmail.com', '5551980587018', '05815942073', 'administrador'),
('11111111111', 'Agostinho Carrara', 'agostinho@carrara.com', '5511984299580', 'aaaaaa', 'professor'),
('12332165445', 'Teresa Cristina Maria Josefa Gaspar Baltasar Melchior Januária Rosalía Lúcia Francisca de Assis', 'aa@bb.com', '11122223333444', '123456', 'administrador'),
('12345678910', 'Mauricio Cerqueira', 'a@b.com', '51123456789', 'senai123', 'professor'),
('15942073951', 'Marcel', 'arthur_lessa@hotmail.com', '51222222222222', '222222222', 'usuario'),
('20032004200', 'Julio Arronax', 'b@c.com', '51951515151', 'senai123', 'professor'),
('69696969696', 'Jacinto Pinto', 'adriano.silva6@estudante.senai', '+5551980587018', '123456', 'usuario'),
('78964564563', 'Adolfo', 'alexandre.barbosa@fiergs.org.b', '51222222222222', '123456', 'usuario');

-- --------------------------------------------------------

--
-- Estrutura para tabela `provas`
--

CREATE TABLE `provas` (
  `id_prova` int(11) NOT NULL,
  `nota` varchar(3) NOT NULL,
  `id_matricula` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Fazendo dump de dados para tabela `provas`
--

INSERT INTO `provas` (`id_prova`, `nota`, `id_matricula`) VALUES
(3, '95', 2),
(4, '97', 3);

-- --------------------------------------------------------

--
-- Estrutura para tabela `sala`
--

CREATE TABLE `sala` (
  `id_sala` int(11) NOT NULL,
  `numero_sala` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Fazendo dump de dados para tabela `sala`
--

INSERT INTO `sala` (`id_sala`, `numero_sala`) VALUES
(1, 101),
(2, 102),
(3, 103);

-- --------------------------------------------------------

--
-- Estrutura para tabela `setor`
--

CREATE TABLE `setor` (
  `id_setor` int(11) NOT NULL,
  `nome_setor` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Fazendo dump de dados para tabela `setor`
--

INSERT INTO `setor` (`id_setor`, `nome_setor`) VALUES
(2, 'Recursos Humanos'),
(3, 'Secretaria Escolar'),
(4, 'TI'),
(5, 'Limpeza'),
(6, 'Biblioteca');

-- --------------------------------------------------------

--
-- Estrutura para tabela `turma`
--

CREATE TABLE `turma` (
  `id_turma` int(11) NOT NULL,
  `nome_curso` varchar(30) NOT NULL,
  `turno` varchar(16) NOT NULL,
  `id_sala` int(11) NOT NULL,
  `id_profe` varchar(14) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Fazendo dump de dados para tabela `turma`
--

INSERT INTO `turma` (`id_turma`, `nome_curso`, `turno`, `id_sala`, `id_profe`) VALUES
(1, 'Desenvolvimento de Sistemas', 'vespertino', 3, '12345678910'),
(2, 'Internet das Coisas', 'noturno', 2, '11111111111'),
(3, 'Banco de Dados com ORACLE', 'matutino', 2, '11111111111'),
(4, 'Web Design', 'vespertino', 1, '20032004200'),
(5, 'Programacao Orientada a Objeto', 'noturno', 1, '20032004200');

--
-- Índices de tabelas apagadas
--

--
-- Índices de tabela `matricula`
--
ALTER TABLE `matricula`
  ADD PRIMARY KEY (`id_matricula`),
  ADD KEY `id_aluno` (`id_aluno`),
  ADD KEY `id_turma` (`id_turma`);

--
-- Índices de tabela `pessoa`
--
ALTER TABLE `pessoa`
  ADD PRIMARY KEY (`cpf`);

--
-- Índices de tabela `provas`
--
ALTER TABLE `provas`
  ADD PRIMARY KEY (`id_prova`),
  ADD KEY `id_matricula` (`id_matricula`);

--
-- Índices de tabela `sala`
--
ALTER TABLE `sala`
  ADD PRIMARY KEY (`id_sala`);

--
-- Índices de tabela `setor`
--
ALTER TABLE `setor`
  ADD PRIMARY KEY (`id_setor`);

--
-- Índices de tabela `turma`
--
ALTER TABLE `turma`
  ADD PRIMARY KEY (`id_turma`),
  ADD KEY `id_sala` (`id_sala`,`id_profe`),
  ADD KEY `id_profe` (`id_profe`);

--
-- AUTO_INCREMENT de tabelas apagadas
--

--
-- AUTO_INCREMENT de tabela `matricula`
--
ALTER TABLE `matricula`
  MODIFY `id_matricula` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT de tabela `provas`
--
ALTER TABLE `provas`
  MODIFY `id_prova` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de tabela `sala`
--
ALTER TABLE `sala`
  MODIFY `id_sala` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de tabela `setor`
--
ALTER TABLE `setor`
  MODIFY `id_setor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de tabela `turma`
--
ALTER TABLE `turma`
  MODIFY `id_turma` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
