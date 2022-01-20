create table utilizadores(
	id int identity primary key,
	email varchar(100) not null unique check (email like '%@%.%'),
	nome varchar(100) not null,
	morada varchar(100) not null,
	nif varchar(9) not null,
	password varchar(64) not null,
	sal int,
	fail_count int,
	fail_data date,
	estado int not null,
	perfil int not null check (perfil in ('0','1')),
	lnkRecuperar varchar(36),
	data_lnk date,
)

CREATE TABLE Livros
(
	[nlivro] INT NOT NULL PRIMARY KEY identity,
	nome varchar(100) not null,
	ano int not null,
	data_aquisicao date not null,
	preco decimal(4,2) not null,
	autor varchar(100) not null,
	tipo varchar(50) not null,
	estado int not null
)
create table emprestimos(
	nemprestimo int identity primary key,
	nlivro int references livros(nlivro),
	idutilizador int references utilizadores(id),
	data_emprestimo date default(getdate()),
	data_devolve date,
	estado int --2=>Reservado 1=>Emprestado 0=>Terminado
)

create index ilivro_nome on livros(nome)
create index ilivro_autor on livros(autor)


INSERT INTO utilizadores(email,nome,morada,nif,password,sal,estado,perfil)
VALUES ('admin@gmail.com','admin','viseu','123123123',HASHBYTES('SHA2_512','123450'),0,1,0)
