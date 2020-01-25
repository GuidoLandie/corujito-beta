INSERT INTO CRJAplicacoes (IdAplicacao,Nome,Descricao,Caminho,AplicacaoPai) VALUES 
	(1,'Acad�mico','Acad�mico','<a href="#" >Acad�mico</a>',0)
	,(2,'Administra��o','Administra��o','<a href="#">Administra��o</a>',0)		
	,(3,'Minha �rea','Minha �rea','<a href="#">Minha �rea</a>',0)
	,(4,'Cantina','Cantina','<a href="#">Cantina</a>',0)
	,(5,'Alunos','Alunos','<a href="/Paginas/Administracao/AlunosPesquisa.aspx">Alunos</a>',1)
	,(6,'Controle de Sala','Controle de Sala','<a href="/Paginas/Administracao/AcaoProfessor.aspx">Controle de Sala</a>',1)
	,(7,'Dados Escolar','Dados Escolar','<a href="/Paginas/Administracao/CadastroEscola.aspx">Dados Escolar</a>',2)	
	,(8,'Cadastro de Pessoas','Cadastro de Pessoas','<a href="/Paginas/Administracao/CadastroPessoaPesquisa.aspx">Cadastro de Pessoas</a>',2) 
	,(9,'Controle Permiss�o','Controle de Permiss�o','<a href="#" >Controle de Acessos</a>',2)						
	,(10,'Cart�o','Cart�o','<a href="#" >Cart�o</a>',3)
	,(11,'Alimenta��o','Alimenta��o','<a href="#" >Alimenta��o</a>',3)
	,(12,'Atividades','Atividades','<a href="#" >Atividades</a>',3)
	,(13,'Notas','Notas','<a href="#" >Notas</a>',3)
	,(14,'Fequ�ncia','Fequ�ncia','<a href="#" >Fequ�ncia</a>',3)
	,(15,'Ocorr�ncias','Ocorr�ncias','<a href="/Paginas/Administracao/CadastroOcorrenciaPesquisa.aspx" >Ocorr�ncias</a>',3)
	,(16,'Cadastrar Prdutos','Cadastrar Prdutos','<a href="/Paginas/Administracao/CadastroProdutoPesquisa.aspx">Cadastrar Produtos</a>',4)
	,(17,'Vender Produtos','Vender Produtos','<a href="/Paginas/Administracao/VenderProdutoPesquisa.aspx">Vender Produtos</a>',4)
	,(18,'Grupos','Grupos','<a href="/Paginas/Administracao/CadastroGrupoPesquisa.aspx">Grupos</a>',9)
    ,(19,'Permissao Usuarios','Permissao Usuarios','<a href="/Paginas/Administracao/CadastroPermissaoUsuarioPesquisa.aspx">Usuarios</a>',9)

    
    
INSERT INTO CRJFuncionalidadeAplicacao ( IdFuncionalidade ,IdAplicacao ,Descricao) 
VALUES 
 (1,5,'Enviar e-mail' )
,(2,5,'Lan�ar Ocorr�ncia' )
,(3,6,'Lan�ar Atividade' )
,(4,6,'Lan�ar Notas')
,(5,6,'Lan�ar Frequ�ncia' )
,(6,7,'Cadastrar dados da escola' )
,(7,8,'Cadastrar Dados Pessoais' )
,(8,8,'Atribuir Respons�vel' )
,(9,8,'Cadastrar Tipo de Usu�rio' )
,(10,8,'Ger�nciar Cart�o do Usu�rio' )
,(11,16,'Cadastrar Produtos' )
,(12,17,'Vender Produtos' )
,(13,18,'Cadastrar Grupo de Permissao' )
,(14,19,'Permiss�o de um usu�rio' )
,(15,10,'Consultar' )
,(16,11,'Consultar' )
,(17,12,'Consultar' )
,(18,13,'Consultar' )
,(19,14,'Consultar' )
,(20,15,'Consultar' )


INSERT INTO CRJStatus (Descricao) values ('Ativo')
INSERT INTO CRJStatus (Descricao) values ('Inativo')



INSERT INTO `crjescola` (`idEscola`, `IdStatus`, `Nome`, `RazaoSocial`, `Missao`, `Logradouro`, `CNPJ`, `Rua`, `CEP`, `Bairro`, `Cidade`, `Pais`, `Estado`, `DataAbertura`, `InscEstadual`, `TelefonePrincipal`, `TelefoneSecundario`, `Email`, `Observacao`) VALUES ('1', '1', 'Arte & Saber ', 'Arte & Saber LTDA.', 'Zelo pelo que voc� tem de melhor', 'Rua Sete de Setembro, 737', '98.046.715/0001-80', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);


INSERT CRJTipoPessoa (Descricao) VALUES 
  ('Secret�ria')
,( 'Cantineiro')
,('Professor')
,('Diretor')
,('Respons�vel')
,('Aluno')




INSERT CRJGrupoPermissao ( IdEscola, Nome, Descricao, IdTipoPessoa) 
	VALUES 
 ( 1, 'Secret�rias', 'Grupo de permiss�o para os usuarios do tipo Secret�ria do sistema', 1) 
,( 1, 'Cantineiro', 'Grupo de usuarios que tem acesso ao sistema da cantina', 2)
,( 1, 'Professores', 'Grupo de usu�rios professores da escola.', 3)
,( 1, 'Diretores', 'Grupo de usuarios que s�o respons�veis por algum aluno da escola.', 5)
,( 1, 'Respons�veis', 'Grupo de usuarios para respons�veis dos alunos.', 6)
,( 1, 'Alunos', 'Grupo de permiss�o dos alunos da escola.', 6)



Insert into CRJPessoaXTipo(IdPessoa,IdTipoPessoa)values(1,1)


insert into CRJTipoAtividade(Descricao)values('Prova')
insert into CRJTipoAtividade(Descricao)values('Trabalho')
insert into CRJTipoAtividade(Descricao)values('Prova Substutiva')
insert into CRJTipoAtividade(Descricao)values('Exec�cio')



