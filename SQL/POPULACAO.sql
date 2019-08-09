INSERT INTO PERFIL(NOME)
VALUES 
('Administrador'),
('Usuario'),
('Analista de Compras'),
('Gerente')

INSERT INTO CATEGORIA (NOME)
VALUES
('Hardware'),
('Software'),
('Administrativo')

INSERT INTO USUARIO (NOME, EMAIL, COD_PERFIL)
VALUES
('Fabricio', 'fabricio.durand@viaflow.com.br', '1'),
('Luiz', 'luiz.mazoni@viaflow.com.br', '1'),
('Ana','ana@ana.com.br','2'),
('Eduardo','eduardo@eduardo.com','3'),
('Joao','joao.schmidt@viaflow.com.br','4')

INSERT INTO _STATUS (NOME)
VALUES
('Aguardando aprovação'),
('Aprovada'), --APROVADA = 1
('Reprovada'), -- APROVADA = 0
('Finalizada') -- FINALIZADO = 1


/*
select * from categoria
*/