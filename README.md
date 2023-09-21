<h1 align="center" style="color: green; font-weight: bold; font-size: 40px">
APIDesafioBackEndIndustriall
</h1>

<br/>

# 💻 Pré-requisitos

> API REST usando .net, asp.net identity, jwt, EF core e SQLserver. O projeto é um CRUD de usuários e eventos, usando esses usuários para a autenticação, é necessário estar autenticado para editar, remover e criar eventos.
>
> Projeto desenvolvido para o desafio de estágio de da [Industriall](https://industriall.ai)

<br/>
# 👨‍💻 Executar a aplicação

Primeiro precisamos ir até o diretório que deseja a aplicação e abrir o terminal

```bash
# Clonar pasta do projeto
> git clone https://github.com/RogerioMSantos/APIDesafioBackEndIndustriall
```

Com o projeto clonado, precisamos acessar o diretorio ./Industrial.API

```bash
# Entrar no diretorio ./Industrial.API
> cd ./Industrial.API
```

E por fim rodar o projeto

```bash
> Rodar o projeto com dotnet run
```
<br/>


# 🚀 Rotas

A aplicação possui as determinadas rotas:

### IdentityUser

São as rotas relacionadas a autenticação de um usuário, desde o cadastro.
```
/IdentityUser/cadastro
post
/IdentityUser/login
post
/IdentityUser
Get
/IdentityUser/current
Get
/IdentityUser/delete
Delete
```


### User

São as rotas relacionados as iformações de um usuário ja logado.
```
/User
Get e Post
User/{id}
Get, put e delete
Para criar um usuário é necessario estar logado usando ao login ao qual ele está relacionado
```

### Event

São as rotas relacionados aos eventos, para registrar um responsável do evento é necessario antes criar as informações adicionais do usuário(rota /user) e pegar o id
```
/Event
Get e post
/Event/{id}
Get, put e delete

```


<br/>


# 🤝 Desenvolvedor

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://avatars.githubusercontent.com/RogerioMSantos" width="100px;" alt="Foto do Rogério Medeiros"/><br>
        <sub>
          <b style="color: orange">Rogério Medeiros</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
<br/>

# 📝 Licença

Esse projeto está sob licença MIT. Veja o arquivo [LICENÇA](LICENSE) para mais detalhes.

<br/>


