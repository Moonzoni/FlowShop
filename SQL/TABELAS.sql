CREATE TABLE CATEGORIA
(
    COD_CATEGORIA INT IDENTITY (1,1),
    NOME  VARCHAR (100) NOT NULL,

    PRIMARY KEY (COD_CATEGORIA),
    UNIQUE(NOME)
    
)


CREATE TABLE PERFIL
(
COD_PERFIL INT IDENTITY (1,1),
NOME  VARCHAR(100) NOT NULL,

PRIMARY KEY (COD_PERFIL),
UNIQUE(NOME)
)


CREATE TABLE _STATUS
(
    COD_STATUS INT IDENTITY (1,1),
    NOME  VARCHAR (100) NOT NULL,

    PRIMARY KEY (COD_STATUS),
    UNIQUE(NOME)
)

CREATE TABLE USUARIO
(
    COD_USUARIO INT IDENTITY(1,1),
    NOME  VARCHAR (100) NOT NULL,
    EMAIL  VARCHAR (100) NOT NULL,
    COD_PERFIL INT NOT NULL
    PRIMARY KEY (COD_USUARIO),
    UNIQUE(EMAIL),

    FOREIGN KEY (COD_PERFIL)
        REFERENCES PERFIL(COD_PERFIL)
)




CREATE TABLE COMPRA
(
    COD_COMPRA INT IDENTITY (1,1),
    TITULO  VARCHAR (100) NOT NULL,
    DESCRICAO  VARCHAR (500) NOT NULL,
    COD_STATUS INT NOT NULL,    
    DATA_SOLICITACAO DATETIME NOT NULL DEFAULT GETDATE(),
    COD_USUARIO INT NOT NULL,
	COD_CATEGORIA INT NOT NULL,
    APROVADO BIT DEFAULT 0,
    FINALIZADO BIT DEFAULT 0,

    PRIMARY KEY (COD_COMPRA),
    FOREIGN KEY (COD_STATUS)
        REFERENCES _STATUS(COD_STATUS),
	FOREIGN KEY (COD_CATEGORIA)
        REFERENCES CATEGORIA (COD_CATEGORIA),
    FOREIGN KEY (COD_USUARIO)
        REFERENCES USUARIO (COD_USUARIO)    
)

CREATE TABLE ORCAMENTO
(
    COD_ORCAMENTO INT IDENTITY (1,1),
    NOME  VARCHAR (100) NOT NULL,
    LINK  VARCHAR (500) NOT NULL,
    OBS VARCHAR (500),
    COD_COMPRA INT NOT NULL,

    PRIMARY KEY (COD_ORCAMENTO),
    FOREIGN KEY (COD_COMPRA)
        REFERENCES COMPRA (COD_COMPRA)
)






/*
DROP TABLE ORCAMENTO
DROP TABLE COMPRA
DROP TABLE USUARIO
DROP TABLE _STATUS
DROP TABLE PERFIL
DROP TABLE CATEGORIA
*/

/*
SELECT * FROM ORCAMENTO
SELECT * FROM COMPRA
SELECT * FROM USUARIO
SELECT * FROM _STATUS
SELECT * FROM PERFIL
SELECT * FROM CATEGORIA
*/