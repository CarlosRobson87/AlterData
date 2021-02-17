Create Table Recurso (
	recurso_id serial PRIMARY KEY,
	nome VARCHAR(50) UNIQUE NOT NULL
);

INSERT INTO recurso(nome)
VALUES ('Suporte Telefone');

INSERT INTO recurso(nome)
VALUES ('Suporte Online');

INSERT INTO recurso(nome)
VALUES ('Dúvidas Email');