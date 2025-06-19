-- Tabela emit (Informações do Emitente)
CREATE TABLE emit (
    CNPJ VARCHAR(14) PRIMARY KEY,  -- CNPJ do emitente (chave primária)
    xNome VARCHAR(50),  -- Razão social do emitente
    xLgr VARCHAR(100),  -- Logradouro do endereço do emitente
    nro VARCHAR(10),  -- Número do endereço do emitente
    xBairro VARCHAR(50),  -- Bairro do endereço do emitente
    cMun INT,  -- Código do município do emitente
    xMun VARCHAR(50),  -- Nome do município do emitente
    UF CHAR(2),  -- Unidade da federação (estado) do emitente
    CEP VARCHAR(8),  -- Código postal (CEP) do emitente
    cPais INT,  -- Código do país do emitente
    xPais VARCHAR(50),  -- Nome do país do emitente
    fone VARCHAR(15),  -- Número de telefone do emitente
    IE VARCHAR(15),  -- Inscrição estadual do emitente
    CRT INT  -- Regime de tributação do emitente
);

-- Tabela ide (Informações de Identificação da NFE)
CREATE TABLE ide (
    chave_acesso VARCHAR(44) PRIMARY KEY,  -- Chave de acesso única da NFE
    CNPJ VARCHAR(14),  -- CNPJ do emitente, chave estrangeira referenciando a tabela emit
    cUF CHAR(2),  -- Código da UF (estado) da NFE
    cNF INT,  -- Código numérico da NFE
    natOp VARCHAR(50),  -- Natureza da operação da NFE
    modelo INT,  -- Modelo da NFE (ex: 55 para NF-e)
    serie INT,  -- Série da NFE
    nNF INT,  -- Número da NFE
    dhEmi DATETIME,  -- Data e hora de emissão da NFE
    dhSaiEnt DATETIME,  -- Data e hora de saída/entrada da NFE
    tpNF INT,  -- Tipo da NFE (entrada ou saída)
    idDest INT,  -- Identificador de destino (destinatário)
    cMunFG INT,  -- Código do município de origem
    tpImp INT,  -- Tipo de impressão da NFE
    tpEmis INT,  -- Tipo de emissão da NFE
    cDV INT,  -- Dígito verificador da NFE
    tpAmb INT,  -- Ambiente de emissão da NFE (1 = Produção, 2 = Homologação)
    finNFe INT,  -- Finalidade da NFE (normal, complementar, etc.)
    indFinal INT,  -- Indicador de operação final (se é final ou não)
    indPres INT,  -- Indicador de presença do comprador (em operação presencial ou não)
    indIntermed INT,  -- Indicador de intermediário
    procEmi INT,  -- Processo de emissão da NFE
    verProc VARCHAR(50),  -- Versão do processo de emissão da NFE
    FOREIGN KEY (CNPJ) REFERENCES emit(CNPJ)  -- Chave estrangeira que referencia a tabela emit
);

-- Tabela prod (Informações dos Produtos)
CREATE TABLE prod (
    cProd VARCHAR(20) PRIMARY KEY,  -- Código do produto (chave primária)
    chave_acesso VARCHAR(44),  -- Chave de acesso da NFE, chave estrangeira referenciando a tabela ide
    cEAN VARCHAR(13),  -- Código EAN (código de barras) do produto
    xProd VARCHAR(100),  -- Descrição do produto
    NCM VARCHAR(8),  -- Código NCM (Nomenclatura Comum do Mercosul) do produto
    CEST VARCHAR(7),  -- Código CEST (Código Especificador da Substituição Tributária)
    CFOP VARCHAR(4),  -- Código Fiscal de Operações e Prestações
    uCom VARCHAR(3),  -- Unidade comercial do produto
    qCom DECIMAL(10, 2),  -- Quantidade comercial do produto
    vUnCom DECIMAL(10, 2),  -- Valor unitário do produto
    vProd DECIMAL(10, 2),  -- Valor total do produto
    cEANTrib VARCHAR(13),  -- Código de barras de tributação do produto
    uTrib VARCHAR(3),  -- Unidade de tributação do produto
    qTrib DECIMAL(10, 2),  -- Quantidade tributada do produto
    vUnTrib DECIMAL(10, 2),  -- Valor unitário tributado do produto
    indTot INT,  -- Indicador de totalização (se o valor do produto entra no total da NFE)
    FOREIGN KEY (chave_acesso) REFERENCES ide(chave_acesso)  -- Chave estrangeira que referencia a tabela ide
);

-- Tabela imposto (Impostos sobre o produto)
CREATE TABLE imposto (
    id_imposto INT AUTO_INCREMENT PRIMARY KEY,  -- Chave primária única do imposto
    cProd VARCHAR(20),  -- Código do produto, chave estrangeira referenciando a tabela prod
    orig INT,  -- Origem do ICMS (se é nacional, importado, etc.)
    CST INT,  -- Código da Situação Tributária do ICMS
    vBCSTRet DECIMAL(10, 2),  -- Valor da base de cálculo do ICMS Substituto
    pST DECIMAL(5, 2),  -- Percentual de ICMS Substituto
    vICMSSubstituto DECIMAL(10, 2),  -- Valor do ICMS Substituto
    vICMSSTRet DECIMAL(10, 2),  -- Valor do ICMS Substituto Retido
    cEnq INT,  -- Código de enquadramento do IPI
    CST_IPI INT,  -- Código da Situação Tributária do IPI
    CST_PIS INT,  -- Código da Situação Tributária do PIS
    CST_COFINS INT,  -- Código da Situação Tributária do COFINS
    FOREIGN KEY (cProd) REFERENCES prod(cProd)  -- Chave estrangeira que referencia a tabela prod
);

/* 
1) Tabela emit: A chave primária é o CNPJ. Os outros campos são os dados relacionados ao emitente.
2) Tabela ide: A chave primária é chave_acesso. A tabela faz referência à tabela emit com a chave estrangeira CNPJ.
3) Tabela prod: A chave primária é cProd. A tabela faz referência à tabela ide com a chave estrangeira chave_acesso.
4) Tabela imposto: Cada produto pode ter impostos associados. A chave primária é id_imposto, e há uma chave estrangeira cProd que referencia a tabela prod.
*/
