drop database if exists barbearia;
create database if not exists barbearia;
use barbearia;

###############################################
create table if not exists Cortes
(
	id_Cortes int not null auto_increment,
	descGen varchar(50) not null,  # (0,'Degradê', 4,50)
    price float not null,
	primary key(id_Cortes)
);     
insert into Cortes values (0,'Degradê', 54.99);
insert into Cortes values (0,'Militar - (a Zero)', 29.99);
insert into Cortes values (0,'Undercut', 59.99);
insert into Cortes values (0,'Moicano', 69.99);
insert into Cortes values (0,'Top Knot', 49.99);
###############################################
create table if not exists clientes
(
	id_cliente int not null auto_increment,
	clienteNome varchar(100),
    telefone varchar(100),
	primary key (id_cliente) 
);
###############################################
create table if not exists barbeiros
(
	id_barbeiros int not null auto_increment,
	barbeiroNome varchar(100),
    disponivelOU varchar(100),
	primary key (id_barbeiros)
);     # - não é cadastrado no programa
insert into barbeiros values (0,'Josué FRIO-e-CALCULISTA','Indisponível');
insert into barbeiros values (0,'Colápso Cardíaco Ferreira Nervoso da Silva','Disponível');
###############################################
create table if not exists agenda
(
	id_agenda int not null auto_increment,
	corteDesejadofk int not null,
    Barbeirofk int not null,
    Clientefk int not null,
    LucroTotalDiario float not null,
    dataHoraCorte datetime not null,
	primary key (id_agenda),
    foreign key (corteDesejadofk) references Cortes(id_Cortes) ON DELETE CASCADE,
    foreign key (Barbeirofk) references barbeiros(id_barbeiros) ON DELETE CASCADE,
	foreign key (Clientefk) references clientes(id_cliente) ON DELETE CASCADE
); # - fica na janela "principal", linkando os três 
###############################################
create table if not exists senha
(
	id_senha int not null auto_increment,
    NomeUsuario varchar(100),
    loginUsuario varchar(100),
    SenhaUsuario varchar(100),
	primary key (id_senha)
);
insert into senha values (0,'Josué FRIO-e-CALCULISTA','Thommy Shelby','peakyBLINDER');
insert into senha values (0,'Colápso Cardíaco Ferreira Nervoso da Silva','coração-de-aço99','CarótidaEmPERIGO');


