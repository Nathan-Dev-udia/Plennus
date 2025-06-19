using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace musica.Properties
{
    public partial class importacao : Form // Tela de importação de XML
    {
        private string xmlFilePath; // Caminho do XML

        public importacao()
        {
            InitializeComponent();
        }

        // Botão que procura o xml
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "Arquivos XML|*.xml",
                Title = "Selecione um arquivo XML"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                xmlFilePath = openFile.FileName;

                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);

                    XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                    nsManager.AddNamespace("ns", "http://www.portalfiscal.inf.br/nfe");

                    // Exibe os dados nas DataGrids
                    MostrarEmitente(xmlDoc, nsManager);
                    MostrarIdentificacao(xmlDoc, nsManager);
                    MostrarProdutos(xmlDoc, nsManager);
                    MostrarImpostos(xmlDoc, nsManager);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao importar o arquivo XML: " + ex.Message);
                }
            }
        }

        // Exibir dados do emitente
        private void MostrarEmitente(XmlDocument xmlDoc, XmlNamespaceManager nsManager)
        {
            XmlNode emitente = xmlDoc.SelectSingleNode("//ns:emit", nsManager);
            if (emitente != null)
            {
                // Criando os DataTables para cada DataGridView
                DataTable dtImport = new DataTable();
                dtImport.Columns.Add("CNPJ");
                dtImport.Rows.Add(emitente.SelectSingleNode("ns:CNPJ", nsManager)?.InnerText ?? "N/A");
                dataGridImport.DataSource = dtImport;

                DataTable dtRazao = new DataTable();
                dtRazao.Columns.Add("Razão Social");
                dtRazao.Rows.Add(emitente.SelectSingleNode("ns:xNome", nsManager)?.InnerText ?? "N/A");
                dataGridrazao.DataSource = dtRazao;

                XmlNode endereco = emitente.SelectSingleNode("ns:enderEmit", nsManager);
                if (endereco != null)
                {
                    DataTable dtLogra = new DataTable();
                    dtLogra.Columns.Add("Logradouro");
                    dtLogra.Rows.Add(endereco.SelectSingleNode("ns:xLgr", nsManager)?.InnerText ?? "N/A");
                    dataGridlogra.DataSource = dtLogra;

                    DataTable dtNumero = new DataTable();
                    dtNumero.Columns.Add("Número");
                    dtNumero.Rows.Add(endereco.SelectSingleNode("ns:nro", nsManager)?.InnerText ?? "N/A");
                    dataGridnumero.DataSource = dtNumero;

                    DataTable dtBairro = new DataTable();
                    dtBairro.Columns.Add("Bairro");
                    dtBairro.Rows.Add(endereco.SelectSingleNode("ns:xBairro", nsManager)?.InnerText ?? "N/A");
                    dataGridbairro.DataSource = dtBairro;

                    DataTable dtCidade = new DataTable();
                    dtCidade.Columns.Add("Município");
                    dtCidade.Rows.Add(endereco.SelectSingleNode("ns:xMun", nsManager)?.InnerText ?? "N/A");
                    dataGridcidade.DataSource = dtCidade;

                    DataTable dtUF = new DataTable();
                    dtUF.Columns.Add("UF");
                    dtUF.Rows.Add(endereco.SelectSingleNode("ns:UF", nsManager)?.InnerText ?? "N/A");
                    dataGriduf.DataSource = dtUF;

                    DataTable dtCEP = new DataTable();
                    dtCEP.Columns.Add("CEP");
                    dtCEP.Rows.Add(endereco.SelectSingleNode("ns:CEP", nsManager)?.InnerText ?? "N/A");
                    dataGridcep.DataSource = dtCEP;

                    DataTable dtPais = new DataTable();
                    dtPais.Columns.Add("País");
                    dtPais.Rows.Add(endereco.SelectSingleNode("ns:xPais", nsManager)?.InnerText ?? "N/A");
                    dataGridpais.DataSource = dtPais;

                    DataTable dtTelefone = new DataTable();
                    dtTelefone.Columns.Add("Telefone");
                    dtTelefone.Rows.Add(endereco.SelectSingleNode("ns:fone", nsManager)?.InnerText ?? "N/A");
                    dataGridtelefone.DataSource = dtTelefone;
                }

                DataTable dtIE = new DataTable();
                dtIE.Columns.Add("Inscrição Estadual");
                dtIE.Rows.Add(emitente.SelectSingleNode("ns:IE", nsManager)?.InnerText ?? "N/A");
                dataGridie.DataSource = dtIE;

                DataTable dtCRT = new DataTable();
                dtCRT.Columns.Add("Regime de Tributação");
                dtCRT.Rows.Add(emitente.SelectSingleNode("ns:CRT", nsManager)?.InnerText ?? "N/A");
                dataGridcrt.DataSource = dtCRT;
            }
        }

        // Exibir dados da NFe
        private void MostrarIdentificacao(XmlDocument xmlDoc, XmlNamespaceManager nsManager)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Chave de Acesso");
            dt.Columns.Add("CNPJ Emitente");
            dt.Columns.Add("Código UF");
            dt.Columns.Add("Código NF");
            dt.Columns.Add("Natureza da Operação");
            dt.Columns.Add("Modelo");
            dt.Columns.Add("Série");
            dt.Columns.Add("Número NF");
            dt.Columns.Add("Data de Emissão");
            dt.Columns.Add("Data de Saída/Entrada");
            dt.Columns.Add("Tipo de NF");
            dt.Columns.Add("Código do Município");
            dt.Columns.Add("Tipo de Impressão");
            dt.Columns.Add("Tipo de Emissão");
            dt.Columns.Add("Dígito Verificador");
            dt.Columns.Add("Ambiente de Emissão");
            dt.Columns.Add("Finalidade da NF");
            dt.Columns.Add("Indicador de Operação Final");
            dt.Columns.Add("Indicador de Presença");
            dt.Columns.Add("Indicador de Intermediário");
            dt.Columns.Add("Processo de Emissão");
            dt.Columns.Add("Versão do Processo");

            XmlNode ide = xmlDoc.SelectSingleNode("//ns:ide", nsManager);
            if (ide != null)
            {
                XmlNode infNFeNode = xmlDoc.SelectSingleNode("//ns:infNFe", nsManager);
                string chave = infNFeNode?.Attributes["Id"]?.InnerText ?? "N/A";
                string cnpjEmitente = ide.SelectSingleNode("ns:CNPJ", nsManager)?.InnerText ?? "N/A";
                string cUF = ide.SelectSingleNode("ns:cUF", nsManager)?.InnerText ?? "N/A";
                string cNF = ide.SelectSingleNode("ns:cNF", nsManager)?.InnerText ?? "N/A";
                string natOp = ide.SelectSingleNode("ns:natOp", nsManager)?.InnerText ?? "N/A";
                string modelo = ide.SelectSingleNode("ns:modelo", nsManager)?.InnerText ?? "N/A";
                string serie = ide.SelectSingleNode("ns:serie", nsManager)?.InnerText ?? "N/A";
                string nNF = ide.SelectSingleNode("ns:nNF", nsManager)?.InnerText ?? "N/A";
                string dhEmi = ide.SelectSingleNode("ns:dhEmi", nsManager)?.InnerText ?? "N/A";
                string dhSaiEnt = ide.SelectSingleNode("ns:dhSaiEnt", nsManager)?.InnerText ?? "N/A";
                string tpNF = ide.SelectSingleNode("ns:tpNF", nsManager)?.InnerText ?? "N/A";
                string cMunFG = ide.SelectSingleNode("ns:cMunFG", nsManager)?.InnerText ?? "N/A";
                string tpImp = ide.SelectSingleNode("ns:tpImp", nsManager)?.InnerText ?? "N/A";
                string tpEmis = ide.SelectSingleNode("ns:tpEmis", nsManager)?.InnerText ?? "N/A";
                string cDV = ide.SelectSingleNode("ns:cDV", nsManager)?.InnerText ?? "N/A";
                string tpAmb = ide.SelectSingleNode("ns:tpAmb", nsManager)?.InnerText ?? "N/A";
                string finNFe = ide.SelectSingleNode("ns:finNFe", nsManager)?.InnerText ?? "N/A";
                string indFinal = ide.SelectSingleNode("ns:indFinal", nsManager)?.InnerText ?? "N/A";
                string indPres = ide.SelectSingleNode("ns:indPres", nsManager)?.InnerText ?? "N/A";
                string indIntermed = ide.SelectSingleNode("ns:indIntermed", nsManager)?.InnerText ?? "N/A";
                string procEmi = ide.SelectSingleNode("ns:procEmi", nsManager)?.InnerText ?? "N/A";
                string verProc = ide.SelectSingleNode("ns:verProc", nsManager)?.InnerText ?? "N/A";

                dt.Rows.Add(chave, cnpjEmitente, cUF, cNF, natOp, modelo, serie, nNF, dhEmi, dhSaiEnt, tpNF, cMunFG, tpImp, tpEmis, cDV, tpAmb, finNFe, indFinal, indPres, indIntermed, procEmi, verProc);
            }

            dataGridide.DataSource = dt;
        }

        // Exibir produtos
        private void MostrarProdutos(XmlDocument xmlDoc, XmlNamespaceManager nsManager)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Código");
            dt.Columns.Add("Descrição");
            dt.Columns.Add("Quantidade");
            dt.Columns.Add("Preço Unitário");
            dt.Columns.Add("Preço Total");

            XmlNodeList produtos = xmlDoc.SelectNodes("//ns:det", nsManager);
            foreach (XmlNode produto in produtos)
            {
                string codigo = produto.SelectSingleNode("ns:prod/ns:cProd", nsManager)?.InnerText ?? "N/A";
                string descricao = produto.SelectSingleNode("ns:prod/ns:xProd", nsManager)?.InnerText ?? "N/A";
                string quantidade = produto.SelectSingleNode("ns:prod/ns:qCom", nsManager)?.InnerText ?? "0";
                string precoUnitario = produto.SelectSingleNode("ns:prod/ns:vUnCom", nsManager)?.InnerText ?? "0.00";
                string precoTotal = produto.SelectSingleNode("ns:prod/ns:vProd", nsManager)?.InnerText ?? "0.00";

                dt.Rows.Add(codigo, descricao, quantidade, precoUnitario, precoTotal);
            }

            dataGridprod.DataSource = dt;
        }

        // Exibir impostos
        private void MostrarImpostos(XmlDocument xmlDoc, XmlNamespaceManager nsManager)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Código Produto");
            dt.Columns.Add("Origem");
            dt.Columns.Add("CST");

            XmlNodeList impostos = xmlDoc.SelectNodes("//ns:det", nsManager);
            foreach (XmlNode imposto in impostos)
            {
                string codigo = imposto.SelectSingleNode("ns:prod/ns:cProd", nsManager)?.InnerText ?? "N/A";
                string origem = imposto.SelectSingleNode("ns:imposto/ns:ICMS/ns:orig", nsManager)?.InnerText ?? "N/A";
                string cst = imposto.SelectSingleNode("ns:imposto/ns:ICMS/ns:CST", nsManager)?.InnerText ?? "N/A";

                dt.Rows.Add(codigo, origem, cst);
            }

            dataGridimposto.DataSource = dt;
        }

        // Botão de importação
        private void importdeff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(xmlFilePath))
            {
                MessageBox.Show("Por favor, selecione um arquivo XML primeiro.");
                return;
            }

            MessageBox.Show("XML importado com sucesso!");
        }

        private void btnHome2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
