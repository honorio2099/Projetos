drop database if exists login;

create database login;

use login;

create table usuarios
(
  idUsu int not null auto_increment,
  nomeUsu varchar(50) not null,
  loginUsu varchar(15) not null,
  senhaUsu varchar(15) not null,
  tipoUsu varchar(4) not null,

  primary key(idUsu)
);

insert into usuarios values (null,'ANA','ana','123', 'ADM');
insert into usuarios values (null,'JOSÉ', 'jose', '123', 'FUNC');
insert into usuarios values (null,'PEDRO', 'pedro','123', 'CLI');