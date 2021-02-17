Create Table Voto (
	funcionario_id int  NOT NULL,
	recurso_id int  NOT NULL,
	comentario VARCHAR(255) NOT NULL,
	data_votacao timestamp NOT NULL,
	
  PRIMARY KEY(funcionario_id, recurso_id)
);

