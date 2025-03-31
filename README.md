# CaseBackend - Sistema de Gerenciamento de Processos por Área

## Objetivo do Sistema

O **CaseBackend** é um sistema projetado para gerenciar processos por área de qualquer tipo de organização. Ele permite a criação, atualização, listagem e exclusão de processos, onde cada processo está vinculado a uma área específica e pode ser estruturado de forma hierárquica, com subprocessos relacionados a um processo pai.

A principal finalidade deste sistema é fornecer uma forma eficiente de organizar, rastrear e gerenciar os fluxos de trabalho dentro de uma organização, permitindo que os usuários visualizem facilmente todos os processos, seus detalhes, ferramentas envolvidas, responsáveis e documentação associada.

## Funcionalidades

- **Gestão de Processos**: Cadastro, visualização, atualização e exclusão de processos.
- **Hierarquia de Processos**: Os processos podem ser organizados de forma hierárquica, permitindo que um processo tenha subprocessos, criando uma estrutura clara e fácil de entender.
- **Área de Processos**: Cada processo pertence a uma área específica, o que facilita a categorização e organização das atividades.
- **API REST**: Acesso completo à gestão de processos via API RESTful, utilizando os métodos HTTP padrão (GET, POST, PUT, DELETE).

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework utilizado para desenvolver a API RESTful.
- **Entity Framework Core**: Para interação com o banco de dados e persistência dos dados dos processos.
- **PostgreSQL**: Banco de dados utilizado para armazenar as informações dos processos e áreas.
- **Swagger**: Para documentação e testes interativos da API.

## Como Usar

### Instalação e Execução

1. Clone o repositório para a sua máquina local:

    ```bash
    git clone https://github.com/seu-usuario/case-backend.git
    cd case-backend
    ```

2. Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

3. Crie a base de dados e aplique as migrações:

    ```bash
    dotnet ef database update
    ```

4. Execute o projeto:

    ```bash
    dotnet run
    ```

5. O servidor estará disponível em `http://localhost:5120` (ou a porta configurada).

### Swagger

Após iniciar o sistema, a documentação da API estará disponível através do **Swagger** em:

[http://localhost:5120/swagger](http://localhost:5120/swagger)

Com o Swagger, você pode testar todos os endpoints da API diretamente no navegador.

## Licença

Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
