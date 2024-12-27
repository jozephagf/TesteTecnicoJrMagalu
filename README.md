## Lendo o Projeto

### Pré-requisitos
* **.NET 6 ou superior:** Instale a versão compatível com o projeto.
* **PostgreSQL:** Tenha uma instância do PostgreSQL rodando e configure as credenciais de acesso.

### Configuração
1. **String de Conexão:**
   * Abra o arquivo `Program.cs`.
   * Localize a string de conexão com o banco de dados PostgreSQL.
   * Substitua os placeholders pelos seus dados de conexão:

2. **Criar as Tabelas:**
   * Execute o seguinte comando para criação das tabelas via Migration:
     ```bash
     update-datebase
     ```
