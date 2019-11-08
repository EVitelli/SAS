-- DROP DATABASE SAS

CREATE DATABASE SAS
GO

USE SAS
GO

CREATE TABLE Ambientes (
	AmbienteId				INT PRIMARY KEY IDENTITY NOT NULL,
	Nome					VARCHAR(255) NOT NULL,
	DescricaoSoftwares		TEXT NOT NULL,
	DescricaoEquipamentos	VARCHAR(255),
	QtdEquipamentos			INT NOT NULL DEFAULT(0),
	QtdMaxPessoas			INT NOT NULL DEFAULT(0),
	Observacao				TEXT NULL DEFAULT('N/C'),
)
GO

SELECT AmbienteId, Nome, DescricaoSoftwares, DescricaoEquipamentos, QtdEquipamentos, QtdMaxPessoas, Observacao FROM Ambientes

CREATE TABLE Categorias (
	CategoriaId			INT PRIMARY KEY IDENTITY NOT NULL,
	Nome				VARCHAR(100) UNIQUE
)
GO

INSERT INTO Categorias VALUES ('Palestra'), ('Curso'), ('Evento')
GO

CREATE TABLE Permissoes (
	PermissaoId		INT PRIMARY KEY IDENTITY NOT NULL,
	-- gestao, recepcao, administrador
	Nome			VARCHAR(100) UNIQUE
)
GO

INSERT INTO Permissoes VALUES ('Gest�o'), ('Coordena��o'), ('Recep��o'), ('Administra��o')
GO

CREATE TABLE Usuarios (
	UsuarioId		INT PRIMARY KEY NOT NULL IDENTITY,
	Nome			VARCHAR(255) NOT NULL,
	NIF				VARCHAR(50) NOT NULL UNIQUE,
	Email			VARCHAR(255) UNIQUE NOT NULL,
	Senha			VARCHAR(255),
	PermissaoId		INT FOREIGN KEY REFERENCES Permissoes(PermissaoId)
)
GO

SELECT U.*, P.*
FROM Usuarios U
INNER JOIN Permissoes P
ON U.PermissaoId = P.PermissaoId
GO

CREATE TABLE Participantes (
	ParticipanteId		INT PRIMARY KEY IDENTITY NOT NULL,
	Nome				VARCHAR(255) NOT NULL,
	RG					CHAR(10) UNIQUE NULL,
	CPF					CHAR(11) UNIQUE NOT NULL
)
GO

CREATE TABLE Agendamentos (
	AgendamentoId		INT PRIMARY KEY IDENTITY NOT NULL,
	InicioReserva		DATETIME NOT NULL,
	TerminoReserva		DATETIME NOT NULL,
	Descricao			VARCHAR(255) NOT NULL,
	Observacao			VARCHAR(255) DEFAULT('N/C'),
	-- confirmado, cancelado, realizado, em preparacao
	StatusAgenda		VARCHAR(20) NOT NULL DEFAULT('Agendado'),
	CategoriaId			INT FOREIGN KEY REFERENCES Categorias(CategoriaId),
	Criador				INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
	AmbienteId			INT FOREIGN KEY REFERENCES Ambientes(AmbienteId)
)
GO

CREATE TABLE AgendamentosParticipantes (
	AgendaParticipanteId	INT PRIMARY KEY IDENTITY NOT NULL,
	AgendamentoId			INT FOREIGN KEY REFERENCES Agendamentos(AgendamentoId),
	ParticipanteId			INT FOREIGN KEY REFERENCES Participantes(ParticipanteId),
	-- presente, ausente, confirmado, cancelado
	StatusParticipante		VARCHAR(20)
)
GO