# Items a implementar

- Deploy
    - Configuração do Beanstalk foi toda executada, porém houve alguns problemas na configuração das variáveis de ambiente
# Front

Abrir o CLI na pasta **front** e executar os comandos a seguir:

```
npm install
npm run start
```

# API

É possível executar a API localmente com Banco de Dados **InMemory**. Para isso, altere a tag **Database:Memory = true** no arquivo **appsettings.(*).json**

Caso false, é necessário configurar a string de conexão com o banco de dados, no caso, **Postgres**.

# Tests

Na pasta **server**, onde se encontra o projeto **sln**, executar o comando:

```
dotnet test
```

# Docker

Docker está sendo usado apenas para subir o banco de dados do Postgres, sem precisar instalar localmente.

Para subir os serviços do Banco
```
docker-compose up -d
```

### Serviços

- Postgres Database -> http://postgres:5432
- Postgres Admin -> http://localhost
	- Usuário: dev@gmail.com
	- Senha: 123456

Para se conectar ao Banco a partir do Postgres Admin

- Host -> postgres
- Database -> youtubetree
- User -> admin
- Password -> admin

# Migrations

### Criar Migrations  


> OBS: O CLI deve estar apontando para pasta raiz do projeto, onde se encontra o ***.sln**

```
dotnet ef migrations add Initial -p YoutubeTree.Data -s YoutubeTree.API
```

Na pasta raiz da API

```
dotnet ef database update -p YoutubeTree.Data -s YoutubeTree.API
```

Os scripts das Tabelas estão na pasta **/Script**
