drop database if exists viagemlegal;

create database viagemlegal;

use viagemlegal;

create table destino
(
  idDestino int auto_increment,
  nomeDestino varchar(30) not null, 
  adicionalDestino float not null,  

  primary key(idDestino)
);

insert into destino values(0,'EGITO','50');
insert into destino values(0,'MACEIO','12');
insert into destino values(0,'NATAL','8');

create table hotel
(
  idHotel int auto_increment,
  nomeHotel varchar(100) not null, 
  diariaHotel float not null,
  qtdVagas int not null,

  primary key(idHotel)
);

insert into hotel values(0,'REDE MERCURE','250.65','20');
insert into hotel values(0,'REDE IBIS','190.45','50');
insert into hotel values(0,'REDE PLAZA','378.25','15');

create table empresa_aerea
(
  idEmp int auto_increment,
  empresaAerea varchar(80) not null,
  qtdVagas int not null,

  primary key(idEmp)
);

insert into empresa_aerea values(0,'LATAM',0);
insert into empresa_aerea values(0,'GOL',0);
insert into empresa_aerea values(0,'AVIANCA',0);

create table pacote
(
  idPacote int auto_increment,
  nomeCliente varchar(30) not null,
  idDestino int not null,
  idHotel int not null,
  idEmp int not null,
  dataEmbarque datetime not null, 
  qtdDiarias int not null,
  valorFinal float not null, 

  primary key(idPacote),
  foreign key(idDestino) references destino(idDestino),
  foreign key(idHotel) references hotel(idHotel),
  foreign key(idEmp) references empresa_aerea(idEmp)
);


