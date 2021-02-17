Create Table Funcionario (
	funcionario_id serial PRIMARY KEY,
	nome VARCHAR(50) NOT NULL,
	email VARCHAR(255) UNIQUE NOT NULL,
	password VARCHAR(50) NOT NULL
);