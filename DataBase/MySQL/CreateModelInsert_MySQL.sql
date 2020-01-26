INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES 
	(1,'Acadêmico','Acadêmico','<a href="#" >Acadêmico</a>',0)
	,(2,'Administração','Administração','<a href="#">Administração</a>',0)		
	,(3,'Minha Área','Minha Área','<a href="#">Minha Área</a>',0)
	,(4,'Cantina','Cantina','<a href="#">Cantina</a>',0)
	,(5,'Alunos','Alunos','<a href="/Paginas/Administracao/AlunosPesquisa.aspx">Alunos</a>',1)
	,(6,'Controle de Sala','Controle de Sala','<a href="/Paginas/Administracao/AcaoProfessor.aspx">Controle de Sala</a>',1)
	,(7,'Dados Escolar','Dados Escolar','<a href="/Paginas/Administracao/CadastroEscola.aspx">Dados Escolar</a>',2)	
	,(8,'Cadastro de Pessoas','Cadastro de Pessoas','<a href="/Paginas/Administracao/CadastroPessoaPesquisa.aspx">Cadastro de Pessoas</a>',2) 
	,(9,'Controle Permissão','Controle de Permissão','<a href="#" >Controle de Acessos</a>',2)						
	,(10,'Cartão','Cartão','<a href="#" >Cartão</a>',3)
	,(11,'Alimentação','Alimentação','<a href="#" >Alimentação</a>',3)
	,(12,'Atividades','Atividades','<a href="#" >Atividades</a>',3)
	,(13,'Notas','Notas','<a href="#" >Notas</a>',3)
	,(14,'Fequência','Fequência','<a href="#" >Fequência</a>',3)
	,(15,'Ocorrências','Ocorrências','<a href="/Paginas/Administracao/CadastroOcorrenciaPesquisa.aspx" >Ocorrências</a>',3)
	,(16,'Cadastrar Prdutos','Cadastrar Prdutos','<a href="/Paginas/Administracao/CadastroProdutoPesquisa.aspx">Cadastrar Produtos</a>',4)
	,(17,'Vender Produtos','Vender Produtos','<a href="/Paginas/Administracao/VenderProdutoPesquisa.aspx">Vender Produtos</a>',4)
	,(18,'Grupos','Grupos','<a href="/Paginas/Administracao/CadastroGrupoPesquisa.aspx">Grupos</a>',9)
    ,(19,'Permissao Usuarios','Permissao Usuarios','<a href="/Paginas/Administracao/CadastroPermissaoUsuarioPesquisa.aspx">Usuarios</a>',9)

    
    
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) 
VALUES 
 (1,5,'Enviar e-mail' )
,(2,5,'Lançar Ocorrência' )
,(3,6,'Lançar Atividade' )
,(4,6,'Lançar Notas')
,(5,6,'Lançar Frequência' )
,(6,7,'Cadastrar dados da escola' )
,(7,8,'Cadastrar Dados Pessoais' )
,(8,8,'Atribuir Responsável' )
,(9,8,'Cadastrar Tipo de Usuário' )
,(10,8,'Gerênciar Cartão do Usuário' )
,(11,16,'Cadastrar Produtos' )
,(12,17,'Vender Produtos' )
,(13,18,'Cadastrar Grupo de Permissao' )
,(14,19,'Permissão de um usuário' )
,(15,10,'Consultar' )
,(16,11,'Consultar' )
,(17,12,'Consultar' )
,(18,13,'Consultar' )
,(19,14,'Consultar' )
,(20,15,'Consultar' )


INSERT INTO CRJStatus (Descricao) values ('Ativo')
INSERT INTO CRJStatus (Descricao) values ('Inativo')



INSERT INTO `crjescola` (`idEscola`, `IdStatus`, `Nome`, `RazaoSocial`, `Missao`, `Logradouro`, `CNPJ`, `Rua`, `CEP`, `Bairro`, `Cidade`, `Pais`, `Estado`, `DataAbertura`, `InscEstadual`, `TelefonePrincipal`, `TelefoneSecundario`, `Email`, `Observacao`) VALUES ('1', '1', 'Arte & Saber ', 'Arte & Saber LTDA.', 'Zelo pelo que você tem de melhor', 'Rua Sete de Setembro, 737', '98.046.715/0001-80', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);


INSERT CRJTipoPessoa (Descricao) VALUES 
  ('Secretária')
,( 'Cantineiro')
,('Professor')
,('Diretor')
,('Responsável')
,('Aluno')




INSERT CRJGrupoPermissao ( IdEscola, Nome, Descricao, IdTipoPessoa) 
	VALUES 
 ( 1, 'Secretárias', 'Grupo de permissão para os usuarios do tipo Secretária do sistema', 1) 
,( 1, 'Cantineiro', 'Grupo de usuarios que tem acesso ao sistema da cantina', 2)
,( 1, 'Professores', 'Grupo de usuários professores da escola.', 3)
,( 1, 'Diretores', 'Grupo de usuarios que são responsáveis por algum aluno da escola.', 5)
,( 1, 'Responsáveis', 'Grupo de usuarios para responsáveis dos alunos.', 6)
,( 1, 'Alunos', 'Grupo de permissão dos alunos da escola.', 6)



Insert into CRJPessoaXTipo(IdPessoa,IdTipoPessoa)values(1,1)


insert into CRJTipoAtividade(Descricao)values('Prova')
insert into CRJTipoAtividade(Descricao)values('Trabalho')
insert into CRJTipoAtividade(Descricao)values('Prova Substutiva')
insert into CRJTipoAtividade(Descricao)values('Execício')




INSERT CRJGrupoPermissao (IdGrupo, IdEscola, Nome, Descricao, IdTipoPessoa) VALUES (1, 'Secretárias', '', 1);
INSERT CRJGrupoPermissao (IdGrupo, IdEscola, Nome,Descricao, IdTipoPessoa) VALUES (2, 1, N'Cantineiro', N'Grupo de usuarios que tem acesso ao sistema da cantina', 2);
INSERT CRJGrupoPermissao (IdGrupo, IdEscola, Nome,Descricao, IdTipoPessoa) VALUES (3, 1, N'Professores', N'Grupo de usuários professores da escola.', 3);
INSERT CRJGrupoPermissao (IdGrupo, IdEscola, Nome,Descricao, IdTipoPessoa) VALUES (5, 1, N'Diretores', N'Grupo de usuarios que são responsáveis por algum aluno da escola.', 5);
INSERT CRJGrupoPermissao (IdGrupo, IdEscola, Nome,Descricao, IdTipoPessoa) VALUES (6, 1, N'Responsáveis', N'Grupo de usuarios para responsáveis dos alunos.', 6);
INSERT CRJGrupoPermissao (IdGrupo, IdEscola, Nome,Descricao, IdTipoPessoa) VALUES (7, 1, N'Alunos', N'Grupo de permissão dos alunos da escola.', 7);





INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (10, 6, 15) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (11, 6, 16) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (12, 6, 17) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (13, 6, 18) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (14, 6, 19) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (15, 6, 20) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (11, 7, 16) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (5, 1, 1)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (5, 1, 2)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (8, 1, 7)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (8, 1, 8)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (8, 1, 9)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (8, 1, 10)  ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (16, 2, 11) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (17, 2, 12) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (11, 2, 16) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (7, 5, 6)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (8, 5, 7)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (8, 5, 8)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (8, 5, 9)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (8, 5, 10)  ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (18, 5, 13) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (19, 5, 14) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (5, 3, 1)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (5, 3, 2)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (6, 3, 3)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (6, 3, 4)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (6, 3, 5)   ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (12, 7, 17) ;
INSERT CRJAplicacaoGrupo (IdAplicacao, IdGrupo, IdFuncionalidade) VALUES (13, 7, 18) ;




insert into crjgrupopermissaousuarios (usuario, idgrupo) values ('guidolandie',1);
insert into crjgrupopermissaousuarios (usuario, idgrupo) values ('guidolandie',2);
insert into crjgrupopermissaousuarios (usuario, idgrupo) values ('guidolandie',3);
insert into crjgrupopermissaousuarios (usuario, idgrupo) values ('guidolandie',4);
insert into crjgrupopermissaousuarios (usuario, idgrupo) values ('guidolandie',5);
insert into crjgrupopermissaousuarios (usuario, idgrupo) values ('guidolandie',6);

