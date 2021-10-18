# SkillTestSegfy

Teste de skills técnicos para a empresa Segfy.

## Tecnologias utilizadas
- **Back-end:** ASP.NET Core 5.0, EF Core 5.0, MySQL, Google Youtube API v3.
- **Front-end:** Razor, Bootstrap, jQuery, Font Awesome.
- **Tests:** MSTest, SQLite.
- **Deploy:** AWS Elastic Beanstalk ([link](http://skilltestsegfy-env.eba-gr2rya2d.sa-east-1.elasticbeanstalk.com/)).

**Importante:** caso receba a mensagem *"A chave de API do YouTube excedeu a cota de uso diário"*, me avise para que eu possa substitui-la. A cota gratuita é pequena para acessar os detalhes dos vídeos e acaba rapidamente durante testes repetitivos.

## Executar o projeto em ambiente próprio

São necessárias as definições de algumas váriaveis de ambiente para o funcionamento do banco de dados e da API do Youtube.

```
RDS_HOSTNAME=your_mysql_host
RDS_PORT=your_mysql_port
RDS_DB_NAME=your_mysql_schema
RDS_USERNAME=your_mysql_user
RDS_PASSWORD=your_mysql_pwd
        
YOUTUBE_API_KEY=your_key
YOUTUBE_API_PROJECT=your_project_name
```

Também é póssível inserir os valores `hardcoded` manualmente na classe `ConfigManager` (Libraries/SkillTestSegfy/ConfigManager.cs).

```
public class ConfigManager
{
    //public static string DatabaseHost => Environment.GetEnvironmentVariable("RDS_HOSTNAME");
    public static string DatabaseHost => "localhost";
    
    //public static string DatabasePort => Environment.GetEnvironmentVariable("RDS_PORT");
    public static string DatabasePort => "3306";
    
    [...]
}
```


## [Descrição Original] Desafio técnico para desenvolvedores

Construa uma nova solução restful, utilizando no backend e no front os frameworks de sua preferência, a qual deverá conectar na API do YouTube e disponibilizar as seguintes funcionalidades:

- Botão para pesquisar canal/video;
- Listar os canais/videos encontrados e salvos no banco;
- Visualizar os detalhes de cada canal/video.

Alguns requisitos:

- Deve ser uma aplicação totalmente nova;
- A solução deve estar em um repositório público do GitHub;
- A aplicação deve armazenar as informações encontradas;
- Utilizar MongoDB,  MySQL ou Postgres;
- O deploy deve ser realizado, preferencialmente na AWS;
- A aplicação precisa ter testes automatizados.
