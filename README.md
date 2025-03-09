# Projeto Integrador: Análise de soluções integradas para organizações

# Membros do grupo

- Lucas Almeida Campos
- Marinna Farias de Oliveira Lins Lima
- Tabata de Sando Angelo

# Objetivo
O desenvolvimento de um aplicativo de manutenção e gerenciamento de vacinas tem como finalidade fornecer uma solução inovadora e acessível para ajudar adultos e idosos a manter suas vacinas atualizadas. Sua missão é simplificar e agilizar a consulta do histórico de vacinação e a comunicação de novidades e atualizações do calendário de vacinação para a sociedade. Facilitar o acesso a essas informações ajuda a proteger a saúde e o bem-estar dos usuários e contribui com a prevenção de doenças.

A proposta do aplicativo é oferecer uma solução única e personalizada para problemas enfrentados por usuários que têm dificuldade em acompanhar e gerenciar suas vacinas. Destacando-se pela interface intuitiva e a capacidade de incluir dependentes, entregando conveniência e confiabilidade. Além de contribuir com a saúde pública, prevenindo a propagação de doenças e promovendo o bem-estar coletivo.

# Como executar o projeto

Tenha instalado o [.NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet) (ou versão mais recente) e o [Nodejs](https://nodejs.org/pt) (versão 22.13.0 ou mais recente).

Abra dois terminais a partir da pasta raíz do projeto e execute os comandos a seguir:
No primeiro terminal:
```console
$ dotnet run --launch-profile https --project src/VacineMais.API
```
No segundo terminal:
```console
$ cd src/VacineMais.Web ;npm run dev
```

Swagger (API): https://localhost:7168/swagger/index.html

Aplicativo: https://localhost:5173/


# Trilha

- [X] Cadastrar usuário
- [X] Fazer Login
- [X] Registrar membros em família
- [X] Editar membro de família
- [X] Deletar membro de família
- [X] Cadastrar vacina
- [X] Atualizar registro de vacina
- [X] Deletar registro de vacina
- [X] Construir landing page

# Recursos

A fonte de vacinas e doses utilizadas no aplicativo foi a documentação [LEDI APS](https://integracao.esusab.ufsc.br/ledi/documentacao/index.html). A lista de doses e vacinas está disponível na pasta "assets" deste repositório.
  
# Protótipo

[Clique aqui](https://www.figma.com/proto/1VPxk0XyPZ0k8WPUfMlfHg/Carteira-de-Vacina%C3%A7%C3%A3o-Digital?node-id=0-1&t=pGyq08SuHhkjWkko-1) para ver o protótipo interativo feito no figma

![image](./assets/prototipo.png)

# Esquema banco de dados
![image](./assets/db_schema.png)

# Tecnologias e bibliotecas
- .NET 8
- Entity Framework 8
- React
- React Bootstrap
- React-Router
- SQLite

# Ferramentas utilizadas
- Figma
- Google Drive
- Whatsapp
- dbdiagram.io
- Excalidraw
