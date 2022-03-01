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

DECLARE @id int;
INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Andre', 'Stanlley', 'usuario@lyncas.net', '1998-09-19');
SELECT @id = SCOPE_IDENTITY();

INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncas123', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Bruno', 'Trindade', 'usuario@lyncas.net', '1998-09-19');
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncasnet', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Gabriel', 'Moya', 'gabriel.mm@lyncas.net', '1996-07-15');
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncas@net', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Genara', 'de Souza', 'usuario@lyncas.net', '1998-09-19');
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncas@net123', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Henrique', 'Carvalho', 'usuario@lyncas.net', '1998-09-19')
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncas@netAbc', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Mauricio', 'Costa', 'usuario@lyncas.net', '1998-09-19')
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncas123', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Renato', 'Ganske', 'usuario@lyncas.net', '1998-09-19')
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncasnetAbc123', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Telmi', 'Adame', 'usuario@lyncas.net', '1998-09-19')
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncas@net', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Thalisson', 'Monteiro', 'usuario@lyncas.net', '1998-09-19')
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncas@net', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Vanessa', 'Eich', 'usuario@lyncas.net', '1998-09-19')
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncas@net', 1);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Garbiel', 'Moy', 'gabriel.mm@lyncas.net', '1996-07-15')
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncasnetAbc123', 0);

INSERT INTO pessoas (nome, sobrenome, email, data_nascimento)
	VALUES ('Gabriel', 'Moya', 'gabriel.mm@lyncas.net', '1996-07-15')
	SELECT @id = SCOPE_IDENTITY();
INSERT INTO autenticacao (id_pessoa, senha, ativo)
	VALUES (@id, 'lyncasnet123', 0);
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