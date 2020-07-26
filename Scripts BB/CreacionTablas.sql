CREATE TABLE ruleta.ruleta(
  id INT primary key auto_increment NOT NULL,
  estado varchar(45) not null  
  );

CREATE TABLE ruleta.apuesta (
  id INT primary key auto_increment NOT NULL,
  id_ruleta INT not null,
  usuario VARCHAR(45) NOT NULL,
  montoApuesta DOUBLE NOT NULL,
  numeroApuesta INT NULL,
  color VARCHAR(45) NULL,
  FOREIGN KEY (id_ruleta) REFERENCES ruleta(id)
  );