drop database if exists lojas;

create database lojas;

use lojas;

create table usuario
(
  id_usu int not null auto_increment,
  nome_usu varchar(50) not null,
  login_usu varchar(15) not null,
  senha_usu varchar(15) not null,
  tipo_usu varchar(4) not null,

  primary key(id_usu)
);

insert into usuario values (null,'ANA','ana','123', 'ADM');
insert into usuario values (null,'JOSÉ', 'jose', '123', 'FUNC');
insert into usuario values (null,'PEDRO', 'pedro','123', 'CLI');

create table forma_pagto
(
  id_pagto int not null auto_increment,
  tipo_pagto varchar(20) not null,
  
  primary key(id_pagto)
);

insert into forma_pagto values(null,'A VISTA');
insert into forma_pagto values(null,'A PRAZO');
insert into forma_pagto values(null,'DINHEIRO');

create table tipo_prod
(
  id_tipo int not null auto_increment,
  tipo_prod varchar(100) not null,
  porc_aumento int not null,

  primary key (id_tipo)
);

insert into tipo_prod values (null, "Calça", 4);
insert into tipo_prod values (null, "Blusa", 9);
insert into tipo_prod values (null, "Shorts", 3);

create table produto
(
  id_prod int not null auto_increment, 
  nome_prod varchar(70) not null,
  desc_prod varchar(255) not null,
  image1 varchar(255) not null,
  qtd int not null,
  id_tipo int not null,
  valor_prod decimal(8,2) not null,

  primary key (id_prod),
  foreign key (id_tipo) references tipo_prod(id_tipo)
);

create table vendas
(
  id_venda int not null auto_increment,
  id_usu int not null,
  id_pagto int ,
  valor_vnd decimal(8,2),

  primary key (id_venda),
  foreign key (id_usu) references usuario(id_usu),
  foreign key (id_pagto) references forma_pagto(id_pagto)  
);


create table item_vendas
(
  id_item_venda int not null auto_increment,
  id_venda int not null,
  id_prod int not null, 
  qtd_item int not null, 
  total_item decimal(8,2) not null,

  primary key (id_item_venda),
  
  foreign key(id_venda) references vendas(id_venda),
  foreign key(id_prod) references produto(id_prod)
);



