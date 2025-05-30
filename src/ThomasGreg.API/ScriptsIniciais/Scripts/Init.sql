IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ThomasGregDb')
BEGIN
    CREATE DATABASE ThomasGregDb;
END
GO

USE ThomasGregDb;
GO

-- ============================================
-- CRIAÇÃO DAS TABELAS
-- ============================================
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Senha NVARCHAR(255) NOT NULL
);
GO

INSERT INTO Usuario (Email, Senha)
VALUES ('admin@thomasgreg.com', '123456');
GO

CREATE TABLE Cliente
(
    Nome VARCHAR(50) NOT NULL,
    Email VARCHAR(50) PRIMARY KEY NOT NULL,
    Logotipo VARCHAR(50)
);
GO

CREATE TABLE Logradouro
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50),
    Numero VARCHAR(50),
    Cep VARCHAR(10),
    Email VARCHAR(50) NOT NULL,
    CONSTRAINT fk_CliLogradouro FOREIGN KEY (Email) REFERENCES Cliente (Email)
);
GO

SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';
GO

SELECT * FROM Usuario;
GO

-- ============================================
-- STORED PROCEDURES
-- ============================================

-- SP: Inserir Cliente
IF OBJECT_ID('sp_InserirCliente', 'P') IS NOT NULL DROP PROCEDURE sp_InserirCliente;
GO

CREATE PROCEDURE sp_InserirCliente
    @Nome VARCHAR(50),
    @Email VARCHAR(50),
    @Logotipo VARCHAR(50)
AS
BEGIN
    INSERT INTO Cliente (Nome, Email, Logotipo)
    VALUES (@Nome, @Email, @Logotipo);
END;
GO

-- SP: Inserir Logradouro
IF OBJECT_ID('sp_InserirLogradouro', 'P') IS NOT NULL DROP PROCEDURE sp_InserirLogradouro;
GO

CREATE PROCEDURE sp_InserirLogradouro
    @Nome VARCHAR(50),
    @Numero VARCHAR(50),
    @Cep VARCHAR(10),
    @Email VARCHAR(50)
AS
BEGIN
    INSERT INTO Logradouro (Nome, Numero, Cep, Email)
    VALUES (@Nome, @Numero, @Cep, @Email);
END;
GO

-- SP: Atualizar Cliente
IF OBJECT_ID('sp_AtualizarCliente', 'P') IS NOT NULL DROP PROCEDURE sp_AtualizarCliente;
GO

CREATE PROCEDURE sp_AtualizarCliente
    @Nome VARCHAR(50),
    @Logotipo VARCHAR(50),
    @Email VARCHAR(50)
AS
BEGIN
    UPDATE Cliente
    SET Nome = @Nome,
        Logotipo = @Logotipo
    WHERE Email = @Email;
END;
GO

-- SP: Atualizar Logradouro
IF OBJECT_ID('sp_AtualizarLogradouro', 'P') IS NOT NULL DROP PROCEDURE sp_AtualizarLogradouro;
GO

CREATE PROCEDURE sp_AtualizarLogradouro
    @Id INT,
    @Nome VARCHAR(50),
    @Numero VARCHAR(50),
    @Cep VARCHAR(10)
AS
BEGIN
    UPDATE Logradouro
    SET Nome = @Nome,
        Numero = @Numero,
        Cep = @Cep
    WHERE Id = @Id;
END;
GO

-- SP: Remover Logradouro
IF OBJECT_ID('sp_RemoverLogradouro', 'P') IS NOT NULL DROP PROCEDURE sp_RemoverLogradouro;
GO

CREATE PROCEDURE sp_RemoverLogradouro
    @Id INT
AS
BEGIN
    DELETE FROM Logradouro
    WHERE Id = @Id;
END;
GO

-- SP: Remover Cliente (com cascade nos logradouros)
IF OBJECT_ID('sp_RemoverCliente', 'P') IS NOT NULL DROP PROCEDURE sp_RemoverCliente;
GO

CREATE PROCEDURE sp_RemoverCliente
    @Email VARCHAR(50)
AS
BEGIN
    DELETE FROM Logradouro
    WHERE Email = @Email;

    DELETE FROM Cliente
    WHERE Email = @Email;
END;
GO

-- SP: Obter Cliente com Logradouros
IF OBJECT_ID('sp_ObterClienteComLogradouros', 'P') IS NOT NULL DROP PROCEDURE sp_ObterClienteComLogradouros;
GO

CREATE PROCEDURE sp_ObterClienteComLogradouros
    @Email VARCHAR(50)
AS
BEGIN
    SELECT Nome, Email, Logotipo FROM Cliente WHERE Email = @Email;

    SELECT Id, Nome, Numero, Cep 
    FROM Logradouro 
    WHERE Email = @Email;
END;
GO

CREATE PROCEDURE sp_ListarLogradouros
AS
BEGIN
    SELECT 
        Id,
        Nome,
        Numero,
        Cep,
        Email
    FROM Logradouro;
END;
GO
