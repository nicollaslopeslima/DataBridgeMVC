# DataBridgeMVC

## Descrição do Projeto

O DataBridgeMVC é uma aplicação web acadêmica desenvolvida com ASP.NET Core MVC, com o objetivo de demonstrar, de forma prática, o processo de integração, transferência e conversão de dados entre dois sistemas distintos: um banco de dados SQL Server e um banco de dados MySQL.

O projeto simula um cenário corporativo comum, no qual sistemas legados coexistem com tecnologias mais modernas, exigindo mecanismos de integração capazes de sincronizar informações de maneira segura, organizada e rastreável.

Além das operações CRUD completas, o sistema implementa transferência controlada de registros entre os bancos de dados, preenchimento automático de endereço via API ViaCEP e separação em camadas utilizando boas práticas de desenvolvimento em .NET.

---

# Tecnologias Utilizadas

* C#
* ASP.NET Core MVC (.NET 8)
* Entity Framework Core
* SQL Server
* MySQL
* Pomelo.EntityFrameworkCore.MySql
* JavaScript
* Bootstrap
* ViaCEP API

---

# Arquitetura do Projeto

O sistema foi estruturado utilizando o padrão MVC (Model-View-Controller), promovendo separação de responsabilidades entre as camadas da aplicação.

A solução também utiliza camadas adicionais para organização da lógica de negócio e acesso a dados:

* Models
* Controllers
* Services
* Data
* Views

A aplicação faz uso de:

* Injeção de Dependência
* Métodos Assíncronos
* Entity Framework Core como ORM
* Integração entre múltiplos DbContexts
* Consumo de APIs externas via HttpClient

---

# Funcionalidades

## Sistema de Origem (SQL Server)

* Cadastro de clientes
* Edição de registros
* Exclusão de registros
* Busca de clientes
* Preenchimento automático de endereço por CEP

## Processo de Integração

* Transferência de registros do SQL Server para o MySQL
* Conversão de estruturas entre bancos distintos
* Rastreamento de data de cadastro e data de transferência
* Integração intermediada por camada de serviço

## Sistema de Destino (MySQL)

* Visualização de registros integrados
* Edição de registros transferidos
* Persistência independente do banco de origem

---

# Estrutura dos Bancos de Dados

O projeto utiliza dois bancos independentes:

## SQL Server

Banco responsável pelo sistema legado:

* Banco: `DataBridgeAntigo`
* Tabela: `Clientes`

## MySQL

Banco responsável pelo sistema moderno:

* Banco: `DataBridgeNovo`
* Tabela: `clientes`

Os bancos possuem diferenças de nomenclatura e tipos de dados, simulando cenários reais de integração entre sistemas heterogêneos.

---

# Integração com ViaCEP

O sistema realiza integração com a API pública ViaCEP para preenchimento automático de endereço a partir do CEP informado pelo usuário.

Endpoint utilizado:

```txt
https://viacep.com.br/ws/{cep}/json/
```

Os campos de endereço são preenchidos dinamicamente via JavaScript e requisições assíncronas.

---

# Como Executar o Projeto

## 1. Clonar o Repositório

```bash
git clone https://github.com/nicollaslopeslima/DataBridgeMVC
```

---

## 2. Abrir o Projeto

Abra a solução utilizando o Visual Studio 2022 ou superior.

---

## 3. Configurar os Bancos de Dados

### SQL Server

Executar o script de criação do banco:

* Banco: `DataBridgeAntigo`
* Tabela: `Clientes`

### MySQL

Executar o script de criação do banco:

* Banco: `DataBridgeNovo`
* Tabela: `clientes`

---

## 4. Configurar as Connection Strings

As credenciais do MySQL devem ser armazenadas utilizando o recurso User Secrets do .NET.

Exemplo:

```bash
dotnet user-secrets set "ConnectionStrings:MySqlConnection" "SUA_CONNECTION_STRING"
```

---

## 5. Executar a Aplicação

Compile e execute o projeto pelo Visual Studio:

```bash
Ctrl + F5
```

---

# Objetivos Acadêmicos

O projeto foi desenvolvido com os seguintes objetivos:

* Demonstrar conceitos de integração entre sistemas
* Aplicar arquitetura MVC em ASP.NET Core
* Trabalhar com múltiplos bancos de dados simultaneamente
* Utilizar Entity Framework Core na manipulação de dados
* Implementar transferência controlada entre bancos distintos
* Aplicar boas práticas de organização em camadas
* Integrar APIs externas em aplicações web

---

# Uso de Inteligência Artificial no Projeto

Ferramentas de Inteligência Artificial foram utilizadas como apoio técnico e acadêmico durante o desenvolvimento do projeto, auxiliando no esclarecimento de conceitos, identificação de erros, revisão textual e organização estrutural da documentação e implementação.

A IA foi utilizada exclusivamente como ferramenta de apoio ao aprendizado e desenvolvimento. Todas as decisões técnicas, implementações, adaptações e validações foram realizadas manualmente pelo autor do projeto.

---

# Melhorias Futuras

Algumas melhorias planejadas para versões futuras incluem:

* Implementação de autenticação de usuários
* Logs persistidos em banco de dados
* Sistema de paginação
* Verificação de duplicidade antes da transferência
* Dashboard de monitoramento
* API REST própria para integração externa
* Testes automatizados
* Containerização com Docker

---

# Status do Projeto

Projeto acadêmico concluído para fins de estudo e demonstração prática de integração entre sistemas utilizando ASP.NET Core MVC.

---

# Autor

Desenvolvido por Nicollas Lopes de Lima.
