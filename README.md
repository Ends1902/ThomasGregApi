# ThomasGregApi
Api do desafio thomas greg

O desafio consiste em criar uma api para um sistema de identificação de clientes e logradouros

## Requisitos
 - Deve ser possível criar, atualizar, visualizar e remover Clientes
     - O cadastro dos clientes deve conter apenas os seguintes campos:
        -  Nome;
        - Endereço de e-mail
        - Logotipo;
        - Logradouro;
        - Um cliente pode conter vários logradouros;
        - Um cliente não pode se registrar duas vezes com o mesmo endereço
  de e-mail;

- Deve ser possível criar, atualizar, visualizar e remover os logradouros;
- O acesso à API deve ser aberto ao mundo, porém deve possuir autenticação e
autorização.

## Descrição das soluções técnicas utilizadas

- A solução foi criada utilizando **.net core na versão 3.1**

- Empacotei em conteineres docker através de DockerFiles, tanto a api quanto o banco de dados Sql Server rodam em um único comando através do compose

- Optei por manter a organização utilizando princípios de arquitetura limpa

![image](https://github.com/user-attachments/assets/a94a13da-8ae8-449f-91b6-295fd5b3c5ac)

- A solução foi versionada desde o início no git

- Utilizei ferramentas como FluentValidation para fazer as validações de estado nas controllers

- Criei um script inicial de banco para preencher as tabelas com um usuário padrão

- Utilizei o **Dapper** tanto para as tabelas de Autenticação quanto para as tabelas de persistência

- Utilizei Middleware global de tratamento de exceção

## Como utilizar a aplicação

- Para rodar a aplicação, você deve ter o **Docker desktop e o Docker compose** instalados em sua máquina 

- Link de download do Docker: https://www.docker.com/products/docker-desktop/

- Após a instalação do Docker com Docker compose, e com a aplicação clonada em seu computador, basta acessar o diretório da aplicação através do CMD ou do PowerShell, e rodar o comando **docker-compose up**

![image](https://github.com/user-attachments/assets/b912f00a-1b7f-4202-ab5e-358eb834b583)

A api deverá estar de pé na porta 5000

![image](https://github.com/user-attachments/assets/410fdedc-4e37-46bf-9d2d-1f67f595c635)


