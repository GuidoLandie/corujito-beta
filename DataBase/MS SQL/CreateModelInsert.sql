--> CREATE DO CONTROLE DE PERMISSÃO

--Menu de Nivel 0 -------------------------------------------------------------------------------------------------------------------------
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (1,'Acadêmico','Acadêmico','<a href="#" >Acadêmico</a>',0)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (2,'Administração','Administração','<a href="#">Administração</a>',0)		
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (3,'Minha Área','Minha Área','<a href="#">Minha Área</a>',0)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (4,'Cantina','Cantina','<a href="#">Cantina</a>',0)
--> Menu de Nivel 1
--> Acadêmico - 1    -------------------------------------------------------------------------------------------------		
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (5,'Alunos','Alunos','<a href="/Paginas/Administracao/AlunosPesquisa.aspx">Alunos</a>',1)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (6,'Controle de Sala','Controle de Sala','<a href="/Paginas/Administracao/AcaoProfessor.aspx">Controle de Sala</a>',1)
--> Administração - 2 -------------------------------------------------------------------------------------------------
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (7,'Dados Escolar','Dados Escolar','<a href="/Paginas/Administracao/CadastroEscola.aspx">Dados Escolar</a>',2)	
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (8,'Cadastro de Pessoas','Cadastro de Pessoas','<a href="/Paginas/Administracao/CadastroPessoaPesquisa.aspx">Cadastro de Pessoas</a>',2) 
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (9,'Controle Permissão','Controle de Permissão','<a href="#" >Controle de Acessos</a>',2)						
-->Minha Área - 3  -------------------------------------------------------------------------------------------------		
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (10,'Cartão','Cartão','<a href="#" >Cartão</a>',3)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (11,'Alimentação','Alimentação','<a href="#" >Alimentação</a>',3)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (12,'Atividades','Atividades','<a href="#" >Atividades</a>',3)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (13,'Notas','Notas','<a href="#" >Notas</a>',3)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (14,'Fequência','Fequência','<a href="#" >Fequência</a>',3)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (15,'Ocorrências','Ocorrências','<a href="/Paginas/Administracao/CadastroOcorrenciaPesquisa.aspx" >Ocorrências</a>',3)

-->Cantina -4  -------------------------------------------------------------------------------------------------
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (16,'Cadastrar Prdutos','Cadastrar Prdutos','<a href="/Paginas/Administracao/CadastroProdutoPesquisa.aspx">Cadastrar Produtos</a>',4)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (17,'Vender Produtos','Vender Produtos','<a href="/Paginas/Administracao/VenderProdutoPesquisa.aspx">Vender Produtos</a>',4)
------------------------------------------------------------------------------------------------------------------------------------------------------
--> Nivel 2 -->9,'Controle Permissão'
-----------------------------------------------------------------------------------------------------------------------------
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (18,'Grupos','Grupos','<a href="/Paginas/Administracao/CadastroGrupoPesquisa.aspx">Grupos</a>',9)
INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES (19,'Permissao Usuarios','Permissao Usuarios','<a href="/Paginas/Administracao/CadastroPermissaoUsuarioPesquisa.aspx">Usuarios</a>',9)
-------------------------------------------------------------------------------------------------------------------------------------------------
-->CADASTRO DAS FUNCIONALIDADES
-------------------------------------------------------------------------------------------------------------------------------------------------
--> 5 - Alunos
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (1,5,'Enviar e-mail' )
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (2,5,'Lançar Ocorrência' )
--> 6 - Coontrole de Sala
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (3,6,'Lançar Atividade' )
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (4,6,'Lançar Notas')
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (5,6,'Lançar Frequência' )
--> 7 Dados Escolar
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (6,7,'Cadastrar dados da escola' )
-->(8,'Cadastro de pessoa' 
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (7,8,'Cadastrar Dados Pessoais' )
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (8,8,'Atribuir Responsável' )
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (9,8,'Cadastrar Tipo de Usuário' )
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (10,8,'Gerênciar Cartão do Usuário' )
-->Cadastrar Produto
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (11,16,'Cadastrar Produtos' )
-->Vender Produtos
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (12,17,'Vender Produtos' )
-->grupo de permissão
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (13,18,'Cadastrar Grupo de Permissao' )
--> permissão usuario
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (14,19,'Permissão de um usuário' )
--10,'Cartão'
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (15,10,'Consultar' )
--11,'Alimentação'
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (16,11,'Consultar' )
--12,'Atividades
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (17,12,'Consultar' )
--13,'Notas'
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (18,13,'Consultar' )
--14,'Fequência',
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (19,14,'Consultar' )
--15,'Ocorrências
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) VALUES (20,15,'Consultar' )
--------------------------------------------------------------------------------------------------------------------------------

--> CRJStatus
------------------------------------------------------------------------------------------------------------------------------
INSERT INTO CRJStatus (Descricao) values ('Ativo')
INSERT INTO CRJStatus (Descricao) values ('Inativo')

SET IDENTITY_INSERT [CRJEscola] ON
INSERT [CRJEscola] ([idEscola], [IdStatus], [Nome], [RazaoSocial], [Missao], [Logradouro], [CNPJ], [Rua], [CEP], [Bairro], [Cidade], [Pais], [Estado], [DataAbertura], [InscEstadual], [TelefonePrincipal], [TelefoneSecundario], [Email], [Observacao]) VALUES (1, 1, N'Arte & Saber ', N'Arte & Saber LTDA.', N'Zelo pelo que você tem de melhor', N'Rua Sete de Setembro, 737', N'98.046.715/0001-80', NULL, N'13035-420', N'Vila Industrial', N'Campinas', NULL, N'São Paulo', CAST(0x00008ED200000000 AS DateTime), NULL, N'(19)3273-6736', N'(19)3273-6736', N'contato@arteesaber.com.br', N'Zelo pelo que você tem de melhor')
SET IDENTITY_INSERT [CRJEscola] OFF
------------------------------------------------------------------------------------------------------------------------------

-->INSERT TIPOS DE PESSOAS
SET IDENTITY_INSERT [CRJTipoPessoa] ON
INSERT [CRJTipoPessoa] ([IdTipoPessoa], [Descricao]) VALUES (1, N'Secretária')
INSERT [CRJTipoPessoa] ([IdTipoPessoa], [Descricao]) VALUES (2, N'Cantineiro')
INSERT [CRJTipoPessoa] ([IdTipoPessoa], [Descricao]) VALUES (3, N'Professor')
INSERT [CRJTipoPessoa] ([IdTipoPessoa], [Descricao]) VALUES (5, N'Diretor')
INSERT [CRJTipoPessoa] ([IdTipoPessoa], [Descricao]) VALUES (6, N'Responsável')
INSERT [CRJTipoPessoa] ([IdTipoPessoa], [Descricao]) VALUES (7, N'Aluno')
SET IDENTITY_INSERT [CRJTipoPessoa] OFF

------------------------------------------------------------------------------------------------------------------------------
--> Tipo de grupo de permissão
SET IDENTITY_INSERT [CRJGrupoPermissao] ON
INSERT [CRJGrupoPermissao] ([IdGrupo], [IdEscola], [Nome], [Descricao], [IdTipoPessoa]) VALUES (1, 1, N'Secretárias', N'Grupo de permissão para os usuarios do tipo Secretária do sistema', 1)
INSERT [CRJGrupoPermissao] ([IdGrupo], [IdEscola], [Nome], [Descricao], [IdTipoPessoa]) VALUES (2, 1, N'Cantineiro', N'Grupo de usuarios que tem acesso ao sistema da cantina', 2)
INSERT [CRJGrupoPermissao] ([IdGrupo], [IdEscola], [Nome], [Descricao], [IdTipoPessoa]) VALUES (3, 1, N'Professores', N'Grupo de usuários professores da escola.', 3)
INSERT [CRJGrupoPermissao] ([IdGrupo], [IdEscola], [Nome], [Descricao], [IdTipoPessoa]) VALUES (5, 1, N'Diretores', N'Grupo de usuarios que são responsáveis por algum aluno da escola.', 5)
INSERT [CRJGrupoPermissao] ([IdGrupo], [IdEscola], [Nome], [Descricao], [IdTipoPessoa]) VALUES (6, 1, N'Responsáveis', N'Grupo de usuarios para responsáveis dos alunos.', 6)
INSERT [CRJGrupoPermissao] ([IdGrupo], [IdEscola], [Nome], [Descricao], [IdTipoPessoa]) VALUES (7, 1, N'Alunos', N'Grupo de permissão dos alunos da escola.', 7)
SET IDENTITY_INSERT [CRJGrupoPermissao] OFF

-->Funcionalidades dos grupos
--------------------------------------------------------------------------------------------------------------
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (10, 6, 15)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (11, 6, 16)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (12, 6, 17)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (13, 6, 18)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (14, 6, 19)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (15, 6, 20)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (11, 7, 16)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (5, 1, 1)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (5, 1, 2)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (8, 1, 7)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (8, 1, 8)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (8, 1, 9)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (8, 1, 10)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (16, 2, 11)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (17, 2, 12)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (11, 2, 16)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (7, 5, 6)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (8, 5, 7)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (8, 5, 8)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (8, 5, 9)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (8, 5, 10)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (18, 5, 13)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (19, 5, 14)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (5, 3, 1)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (5, 3, 2)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (6, 3, 3)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (6, 3, 4)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (6, 3, 5)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (12, 7, 17)
INSERT [CRJAplicacaoGrupo] ([IdAplicacao], [IdGrupo], [IdFuncionalidade]) VALUES (13, 7, 18)

--------------------------------------------------------------------------------------------------------------


-->INSERT da tabela CRJTipoProduto
INSERT INTO CRJTipoProduto (IdTipoProduto,Nome) VALUES(1,'Bebida')
INSERT INTO CRJTipoProduto (IdTipoProduto,Nome) VALUES(2,'Salgado')
INSERT INTO CRJTipoProduto (IdTipoProduto,Nome) VALUES(3,'Doce')
INSERT INTO CRJTipoProduto (IdTipoProduto,Nome) VALUES(4,'Lanche')
INSERT INTO CRJTipoProduto (IdTipoProduto,Nome) VALUES(5,'Almoço')
------------------------------------------------------------------------------------------------------------------------------

--INSERT DAS MATERIAS
INSERT INTO CRJMateria (Descricao,TipoMateria)VALUES('Matematica','M')
INSERT INTO CRJMateria (Descricao,TipoMateria) VALUES('Portugues','M')
INSERT INTO CRJMateria (Descricao,TipoMateria) VALUES('Ingles','M')
INSERT INTO CRJMateria (Descricao,TipoMateria) VALUES('Alemão','M')
INSERT INTO CRJMateria (Descricao,TipoMateria) VALUES('Italiano','M')
INSERT INTO CRJMateria (Descricao,TipoMateria) VALUES('Ed.Fisica','M')
INSERT INTO CRJMateria (Descricao,TipoMateria) VALUES('Geografia','M')
INSERT INTO CRJMateria (Descricao,TipoMateria) VALUES('Historia','M')
------------------------------------------------------------------------------------------------------------------------------
--Turno
insert into CRJTurno (Descricao) values ('Manha')
insert into CRJTurno (Descricao) values ('Tarde')
insert into CRJTurno (Descricao) values ('Noite')
------------------------------------------------------------------------------------------------------------------------------

-->Serie
insert into CRJSerie (Descricao) values ('1')
insert into CRJSerie (Descricao) values ('2')
insert into CRJSerie (Descricao) values ('3')
insert into CRJSerie (Descricao) values ('4')
insert into CRJSerie (Descricao) values ('5')
insert into CRJSerie (Descricao) values ('6')
insert into CRJSerie (Descricao) values ('7')
insert into CRJSerie (Descricao) values ('8')
insert into CRJSerie (Descricao) values ('9')
------------------------------------------------------------------------------------------------------------------------------

-->ENSINO
INSERT into CRJEnsino (idEscola,Descricao) values (1,'Ensino Fundamental 1')
INSERT into CRJEnsino (idEscola,Descricao) values (1,'Ensino Fundamental 2')
INSERT into CRJEnsino (idEscola,Descricao) values (1,'Ensino Médio')
------------------------------------------------------------------------------------------------------------------------------

--CRJ Classes
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,1,1,'A')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,1,1,'B')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,1,1,'C')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,1,1,'D')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,1,1,'E')

insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,2,1,'A')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,2,1,'B')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,2,1,'C')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,2,1,'D')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,2,1,'E')

insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,3,1,'A')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,3,1,'B')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,3,1,'C')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,3,1,'D')
insert into CRJClasse (IdEnsino,IdSerie,IdTurno,NomeTurma) values (1,3,1,'E')
------------------------------------------------------------------------------------------------------------------------------

--> CRJPessoa
GO
SET IDENTITY_INSERT [CRJPessoa] ON
INSERT [CRJPessoa] ([IdPessoa], [IdStatus], [Nome], [CPF], [RG], [Sexo], [Email], [DataNascimento], [Telefone], [Celular], [CEP], [Logradouro], [Numero], [Bairro], [Cidade], [Estado], [Pais], [Complemento], [URL]) VALUES (1, 1, N'Guido Landie Lopes Murta', N'376.352.578-54', NULL, N'M', N'guidolandie@yahoo.com.br', CAST(0x0000A0F400000000 AS DateTime), N'(19)8881-1851', N'(19)8881-1851', N'13902-030', N'Nove de Julho', N'174', N'Jardim Jantana', N'Amparo', N'São Paulo', N'Brasil', N'casa', N'')
INSERT [CRJPessoa] ([IdPessoa], [IdStatus], [Nome], [CPF], [RG], [Sexo], [Email], [DataNascimento], [Telefone], [Celular], [CEP], [Logradouro], [Numero], [Bairro], [Cidade], [Estado], [Pais], [Complemento], [URL]) VALUES (2, 1, N'João Paulo Concimo', N'402.242.898-88', NULL, N'M', N'joao@hotmail.com', CAST(0x0000A0DD00000000 AS DateTime), N'(11)1111-1111', N'(11)1111-1111', N'11111-111', N'1123', N'31231', N'3213123', N'Sumaré', N'São Paulo', N'Brasil', N'', N'')
INSERT [CRJPessoa] ([IdPessoa], [IdStatus], [Nome], [CPF], [RG], [Sexo], [Email], [DataNascimento], [Telefone], [Celular], [CEP], [Logradouro], [Numero], [Bairro], [Cidade], [Estado], [Pais], [Complemento], [URL]) VALUES (4, 1, N'Bruno Cavani', N'402.714.438-47', NULL, N'M', N'bruno.cavani@gmail.com', CAST(0x000080D200000000 AS DateTime), N'(11)4412-1550', N'(11)8177-8809', N'12941-235', N'Rua Flamboyant', N'241', N'Nirvana', N'Atibaia', N'São Paulo', N'Brasil', N'', N'')
SET IDENTITY_INSERT [CRJPessoa] OFF
go
------------------------------------------------------------------------------------------------------------------------------
--> CRJUsuarios
INSERT [CRJUsuarios] ([Usuario], [IdPessoa], [Senha], [Ativo]) VALUES (N'bruno.cavani@gmail.com', 4, N'12345', 1)
INSERT [CRJUsuarios] ([Usuario], [IdPessoa], [Senha], [Ativo]) VALUES (N'guidolandie@yahoo.com.br', 1, N'senha', 1)
INSERT [CRJUsuarios] ([Usuario], [IdPessoa], [Senha], [Ativo]) VALUES (N'joao@hotmail.com', 2, N'123', 1)
------------------------------------------------------------------------------------------------------------------------------

Insert into CRJPessoaXTipo(IdPessoa,IdTipoPessoa)values(1,1)
Insert into CRJPessoaXTipo(IdPessoa,IdTipoPessoa)values(1,2)
Insert into CRJPessoaXTipo(IdPessoa,IdTipoPessoa)values(1,3)
Insert into CRJPessoaXTipo(IdPessoa,IdTipoPessoa)values(1,5)


Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (1,1,1)

Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (1,2,1)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (1,3,1)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (1,4,1)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (1,5,1)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (1,6,1)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (1,7,1)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (1,8,1)

Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (2,2,2)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (3,3,3)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (3,3,3)
Insert into CRJProfXMatXClasse (IdClasse,IdMateria,IdPessoa) values (3,3,3)

--Tipo de atividades
insert into CRJTipoAtividade(Descricao)values('Prova')
insert into CRJTipoAtividade(Descricao)values('Trabalho')
insert into CRJTipoAtividade(Descricao)values('Prova Substutiva')
insert into CRJTipoAtividade(Descricao)values('Execício')