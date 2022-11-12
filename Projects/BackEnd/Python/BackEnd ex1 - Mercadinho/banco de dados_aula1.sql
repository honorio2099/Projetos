create database myCompany;

use myCompany;

create table produtos
(
  idProd int not null auto_increment,
  nomeProd varchar(100) not null,
  descProd varchar(255) not null,
  qtdEstoque int not null,
  precoProd float not null,
  
  primary key(idProd)
);

