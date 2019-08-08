INSERT INTO PERFIL(NOME)
VALUES 
('Administrador'),
('Usuario'),
('Analista de Compras')

INSERT INTO CATEGORIA (NOME)
VALUES
('Hardware'),
('Software'),
('Qualquer coisa')

INSERT INTO USUARIO (NOME, EMAIL, COD_PERFIL)
VALUES
('Fabricio', 'fabricio.durand@viaflow.com.br', '1'),
('Luiz', 'luiz.mazoni@viaflow.com.br', '1')

INSERT INTO _STATUS (NOME)
VALUES
('Aguardando aprovação'),
('Aprovada'), --APROVADA = 1
('Reprovada'), -- APROVADA = 0
('Finalizada') -- FINALIZADO = 1


/*
select * from categoria
*/