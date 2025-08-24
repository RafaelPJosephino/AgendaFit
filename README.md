# Agenda Fit - Como Rodar o Projeto

Este guia explica como configurar e rodar o projeto Agenda Fit localmente.

---

## Pré-requisitos
- [Git](https://git-scm.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- (Opcional) IDE: Visual Studio, VS Code, Rider, etc.

---

## 1. Clonar o repositório

Abra o terminal e execute o seguinte comando para clonar o repositório:

```bash
git clone https://github.com/RafaelPJosephino/AgendaFit.git
```

## 2. Configurar a string de conexão

Navegue até a pasta do projeto MVC:

```bash
cd AgendaFit/Mvc
```

Se não existir, crie o arquivo `appsettings.json`.

Adicione a seguinte configuração:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=agenda_fit;Username=postgres;Password=senha"
  }
}
```

> Substitua `senha` pela senha do seu usuário PostgreSQL.  
> Certifique-se de que o banco de dados `agenda_fit` exista.(Final do arquivo tem todos os SQLs)

---

## 3. Rodar a aplicação

Dentro da pasta `Mvc`, execute:

```bash
dotnet run
```

A aplicação será iniciada usando a string de conexão configurada.

---

## 4. Acessar a API e Swagger

Após rodar a aplicação, abra seu navegador e acesse:

```
http://localhost:5000/swagger
```

> O Swagger exibirá todos os endpoints disponíveis da API para teste e documentação.

---

## Banco De dados postgres
### 📌 Script SQL - AgendaFit

```sql
-- Criacao do banco
CREATE DATABASE "agenda_fit"
WITH
OWNER = postgres
ENCODING = 'UTF8'
LC_COLLATE = 'pt-BR'
LC_CTYPE = 'pt-BR'
LOCALE_PROVIDER = 'libc'
TABLESPACE = pg_default
CONNECTION LIMIT = -1
IS_TEMPLATE = False;

-- Criar schema
CREATE SCHEMA agenda AUTHORIZATION postgres;

-- Criar tabela aluno
CREATE TABLE agenda.agendafit_aluno (
    id_aluno SERIAL PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    tipo_plano int NOT NULL
);

-- Criar tabela aula
CREATE TABLE agenda.agendafit_aula (
    id_aula SERIAL PRIMARY KEY,
    tipo_aula int NOT NULL,
    quantidade_participante INT NOT NULL,
    data_hora TIMESTAMP NOT NULL
);

-- Criar tabela agendamento
CREATE TABLE agenda.agendafit_agendamento (
    id_agendamento SERIAL PRIMARY KEY,
    id_aula INT NOT NULL,
    id_aluno INT NOT NULL,
    CONSTRAINT fk_agendamento_aula FOREIGN KEY (id_aula) REFERENCES agenda.agendafit_aula(id_aula) ON DELETE NO ACTION,
    CONSTRAINT fk_agendamento_aluno FOREIGN KEY (id_aluno) REFERENCES agenda.agendafit_aluno(id_aluno) ON DELETE NO ACTION
);
```
