create database N8_MiniProjeto
use N8_MiniProjeto

create table Usuario
(
	id_usuario int not null identity primary key,
	nome_usuario varchar(50) not null ,
	login_usuario varchar(30) not null unique,
	senha_usuario varchar(30) not null ,
	cpf_usuario char(14) not null unique,
	status_usuario varchar(30) not null ,
	obs_usuario varchar(255) null
)
select * from Usuario

insert into Usuario
	(nome_usuario, login_usuario, senha_usuario, cpf_usuario, status_usuario, obs_usuario)
values
	('Johann', 'johann@empresa.com', '123456', '111.111.111-11', 'Ativo', '')

create table Categoria
(
	id_categoria int not null identity primary key,
	nome_categoria varchar(50) not null unique,
	descricao_categoria varchar(255) not null ,
	status_categoria varchar(30) not null ,
	obs_categoria varchar(255) null
)

insert into Categoria
	(nome_categoria, descricao_categoria, status_categoria, obs_categoria)
values
	('Ferramentas', 'Objetos, utensílios para serviços', 'Ativo', '')

create table Produto
(
	id_produto int not null identity primary key,
	id_categoria_produto int not null ,
	nome_produto varchar(50) not null unique,
	qtde_produto int not null ,
	peso_produto decimal(10,3) not null ,
	unidade_produto varchar(30) not null ,
	cadastro_produto smalldatetime not null default getdate(),
	valorCusto_produto decimal(10,2) not null ,
	valorVenda_produto decimal(10,2) not null ,
	status_produto varchar(30) not null ,
	obs_produto varchar(255) null

	constraint FK_Id_Categoria_Produto foreign key(id_categoria_produto) references Categoria(id_categoria)
)

insert into Produto
	(id_categoria_produto, nome_produto, qtde_produto, peso_produto, unidade_produto, valorCusto_produto, valorVenda_produto, status_produto, obs_produto)
values
	(1, 'Martelo', 100, 1.200, '', 1255.00, 1500.00, 'Ativo', '')

create table MovProduto
(
	id_movProduto int not null identity primary key,
	id_produto_movProduto int not null ,
	id_usuario_movProduto int not null ,
	qtde_movProduto int not null ,
	cadastro_movProduto smalldatetime not null default getdate(),
	tipo_movProduto varchar(30) not null ,
	descricao_movProduto varchar(255) not null ,
	status_movProduto varchar(30) not null ,
	obs_movProduto varchar(255) null

	constraint FK_Id_Produto_MovProduto foreign key(id_produto_movProduto) references Produto(id_produto),
	constraint FK_Id_Usuario_MovProduto foreign key(id_usuario_movProduto) references Usuario(id_usuario)
)

insert into MovProduto
	(id_produto_movProduto, id_usuario_movProduto, qtde_movProduto, tipo_movProduto, descricao_movProduto, status_movProduto, obs_movProduto)
values
	(1, 1, 25, 'Entrada', 'Venda do Produto', 'Ativo', '')

create table Fornecedor
(
	id_fornecedor int not null identity primary key,
	cnpj_fornecedor char(18) not null unique,
	nome_fornecedor varchar(50) not null ,
	cep_fornecedor char(9) not null ,
	numero_fornecedor int not null ,
	telefone1_fornecedor char(14) not null ,
	telefone2_fornecedor char(14) not null ,
	status_fornecedor varchar(30) not null ,
	obs_fornecedor varchar(255) null
)

insert into Fornecedor
	(cnpj_fornecedor, nome_fornecedor, cep_fornecedor, numero_fornecedor, telefone1_fornecedor, telefone2_fornecedor, status_fornecedor, obs_fornecedor)
values
	('11.111.111/0001-00', 'Tools INC', '11111-111', 123, '(11)12345-6789', '', 'Ativo', '')

create table ProdFornecedor
(
	id_prodFornecedor int not null identity primary key,
	id_fornecedor_prodFornecedor int not null ,
	id_produto_prodFornecedor int not null ,
	dataEntrada_prodFornecedor smalldatetime not null default getdate(),
	descricao_prodFornecedor varchar(255) not null ,
	status_prodFornecedor varchar(30) not null ,
	obs_prodFornecedor varchar(255) null

	constraint FK_Id_Fornecedor_ProdFornecedor foreign key(id_fornecedor_prodFornecedor) references Fornecedor(id_fornecedor),
	constraint FK_Id_Produto_ProdFornecedor foreign key(id_produto_prodFornecedor) references Produto(id_produto)
)

insert into ProdFornecedor
	(id_fornecedor_prodFornecedor, id_produto_prodFornecedor, descricao_prodFornecedor, status_prodFornecedor, obs_prodFornecedor)
values
	(1, 1, '', 'Ativo', '')