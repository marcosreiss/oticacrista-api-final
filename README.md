# ÓticaCristã API

ÓticaCristã API é uma API desenvolvida em ASP.NET Web API (.NET 8) para gerenciar o sistema de uma ótica, 
permitindo a realização de operações CRUD (Criar, Ler, Atualizar, Excluir) para diferentes módulos, 
incluindo clientes, fornecedores, produtos, serviços, fluxo de caixa, receita, protocolos (ordens de serviço), 
armações e outros.

## Recursos Principais

- **Clientes**: Gerenciamento completo de cadastro de clientes.
- **Fornecedores**: Controle de fornecedores e seus dados.
- **Produtos**: Cadastro e controle de inventário de produtos.
- **Serviços**: Gerenciamento dos serviços oferecidos pela ótica.
- **Fluxo de Caixa**: Controle financeiro da entrada e saída de recursos.
- **Receita**: Registro e acompanhamento das receitas geradas.
- **Protocolo (OS)**: Gestão de ordens de serviço para atender aos pedidos dos clientes.
- **Armação**: Controle de estoque e venda de armações.

## Tecnologias Utilizadas

- **Plataforma**: ASP.NET Web API (.NET 8)
- **Banco de Dados**: MySql
- **Autenticação**: Implementação de autenticação e autorização.
- **ORM**: Entity Framework Core
- **Documentação**: Swagger/OpenAPI
- **Controle de Versão**: Git

## Requisitos

- **SDK do .NET 8**
- **Visual Studio 2022** (ou superior) ou outra IDE compatível
- **MySql**

## Configuração do Projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/marcosreiss/oticacrista-api-final
   ```

2. Acesse o diretório do projeto:

   ```bash
   cd oticacrista-api-final
   ```

3. Restaure as dependências:

   ```bash
   dotnet restore
   ```

4. Configure a string de conexão no arquivo `appsettings.json`.

5. Aplique as migrações do banco de dados:

   ```bash
   dotnet ef database update
   ```

6. Inicie o servidor:

   ```bash
   dotnet run
   ```

7. Acesse o Swagger para documentação e testes da API:

   ```
   http://localhost:5000/swagger
   ```

## Estrutura do Projeto

- **Controllers/**: Contém os controladores para os endpoints da API.
- **Models/**: Define os modelos de dados utilizados pela aplicação.
- **Services/**: Contém a lógica de negócios.
- **Data/**: Contém o contexto do Entity Framework e configurações do banco de dados.

## Contribuição

1. Fork o repositório.
2. Crie uma branch para sua feature ou correção:

   ```bash
   git checkout -b minha-feature
   ```

3. Commit suas alterações:

   ```bash
   git commit -m "Minha nova feature"
   ```

4. Envie as alterações para o repositório remoto:

   ```bash
   git push origin minha-feature
   ```

5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

**Observação**: Para dúvidas ou suporte, entre em contato pelo e-mail: suporte@oticacrista.com.br.

