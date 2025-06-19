# 📄 Plennus

**Plennus** é uma aplicação desktop feita em **C# (Windows Forms)** desenvolvida para atender uma demanda real de um escritório contábil. O sistema tem como objetivo **importar arquivos XML de Notas Fiscais Eletrônicas (NF-e)** e exibir informações detalhadas do **emitente**, **produtos**, **impostos** e **identificação da nota**.

> O projeto foi interrompido antes de ser finalizado devido à desistência do cliente, mas permanece funcional como base de leitura e visualização de dados XML da NF-e.

---

## 🧠 Funcionalidades

- 📂 Importação de arquivos XML da NF-e (modelo 55);
- 🏢 Leitura automática dos dados do **emitente**: CNPJ, razão social, endereço, inscrição estadual, etc;
- 📦 Exibição dos **produtos**: código, descrição, quantidade, preço unitário e total;
- 🧾 Informações da **nota fiscal**: número, data de emissão, série, modelo, chave de acesso, etc;
- 🧮 Visualização dos **impostos ICMS**: origem, CST e mais;
- 📋 Interface com abas separadas para **importação** e **notas cadastradas**.

---

## 🛠️ Tecnologias utilizadas

- **C# / Windows Forms**
- **XML (XmlDocument, XPath)**
- **MySQL** *(em estrutura inicial para futura persistência de dados)*
- **Guna UI2** *(componentes visuais modernos)*

---

## 🏗️ Arquitetura do Projeto

- **Form1.cs**: Tela inicial com botões para navegar entre importação de XML e consulta de notas.
- **importacao.cs**: Tela responsável por importar e exibir os dados do arquivo XML da NF-e, separados em abas com emitente, produtos, impostos e identificação da nota.
- **notascadastradas.cs**: Tela para visualizar notas cadastradas (ainda em fase inicial), com lógica para controlar fechamento da aplicação.
- Utiliza o pacote MySQL.Data para futura persistência dos dados em banco MySQL.

---

## ▶️ Como rodar o projeto

1. Abra no Visual Studio (2019+ recomendado);
2. Instale o pacote MySql.Data pelo NuGet;
3. Compile e execute o projeto;
4. Acesse a aba Importar Nota, selecione um XML válido da NF-e e visualize os dados.

---

🧩 Estado atual
O projeto foi interrompido antes de ter todas as funcionalidades finalizadas (como salvamento no banco), 
mas pode servir como base para novos sistemas que precisem importar e tratar arquivos XML de nota fiscal eletrônica.
