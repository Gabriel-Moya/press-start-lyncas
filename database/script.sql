CREATE DATABASE PRESS_START;
GO

USE [PRESS_START];
GO

CREATE TABLE pessoas (
	id_pessoa int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nome varchar(255) NOT NULL,
	sobrenome varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	data_nascimento date  NOT NULL
);

CREATE TABLE autenticacao (
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	id_pessoa int NOT NULL,
	senha nvarchar(255) NOT NULL,
	ativo bit
);
GO

ALTER TABLE autenticacao
	ADD FOREIGN KEY (id_pessoa) REFERENCES pessoas(id_pessoa);
GO


--INSERTS
INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Andre', 'Stanlley', 'usuario@lyncas.net', '1998-09-19'),
		   ('Bruno', 'Trindade', 'usuario@lyncas.net', '1998-09-19'),
		   ('Gabriel', 'Moya', 'gabriel.mm@lyncas.net', '1996-07-15'),
		   ('Genara', 'de Souza', 'usuario@lyncas.net', '1998-09-19'),
		   ('Henrique', 'Carvalho', 'usuario@lyncas.net', '1998-09-19'),
		   ('Mauricio', 'Costa', 'usuario@lyncas.net', '1998-09-19'),
		   ('Renato', 'Ganske', 'usuario@lyncas.net', '1998-09-19'),
		   ('Telmi', 'Adame', 'usuario@lyncas.net', '1998-09-19'),
		   ('Thalisson', 'Monteiro', 'usuario@lyncas.net', '1998-09-19'),
		   ('Vanessa', 'Eich', 'usuario@lyncas.net', '1998-09-19'),
		   ('Garbiel', 'Moy', 'gabriel.mm@lyncas.net', '1996-07-15'),
		   ('Gabriel', 'Moya', 'gabriel.mm@lyncas.net', '1996-07-15');

INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (1, 'lyncas123', 1),
		   (2, 'lyncasnet', 1),
		   (3, 'lyncas@net', 1),
		   (4, 'lyncas@net123', 1),
		   (5, 'lyncas@netAbc', 1),
		   (6, 'lyncas123', 1),
		   (7, 'lyncasnetAbc123', 1),
		   (8, 'lyncas@net', 1),
		   (9, 'lyncas@net', 1),
		   (10, 'lyncas@net', 1),
		   (11, 'lyncasnetAbc123', 0),
		   (12, 'lyncasnet123', 0);
GO


--UPDATE
UPDATE pessoas
	SET nome = 'Gabriel', sobrenome = 'Moya'
	WHERE id_pessoa = 11;


--DELETE
DELETE FROM autenticacao
	WHERE id_pessoa = 12;
DELETE FROM pessoas
	WHERE id_pessoa = 12;


--SELECT
SELECT nome
	  ,sobrenome
	  ,email
	  ,data_nascimento
	FROM pessoas
		INNER JOIN autenticacao
		ON pessoas.id_pessoa = autenticacao.id_pessoa
		WHERE autenticacao.ativo = 1;
