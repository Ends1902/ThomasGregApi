# ThomasGregApi
Api do desafio thomas greg

O desafio consiste em criar um sistema de identificação de clientes e logradouros

Requisitos
 Deve ser possível criar, atualizar, visualizar e remover Clientes
o O cadastro dos clientes deve conter apenas os seguintes campos:
   Nome;
   Endereço de e-mail
   Logotipo;
   Logradouro;
   Um cliente pode conter vários logradouros;
   Um cliente não pode se registrar duas vezes com o mesmo endereço
  de e-mail;

 Deve ser possível criar, atualizar, visualizar e remover os logradouros;
 O acesso à API deve ser aberto ao mundo, porém deve possuir autenticação e
autorização.

# Descrição das soluções utilizadas

A solução foi criada utilizando .net core na versão 3.1
Empacotei em conteineres docker através de DockerFiles, tanto a api quanto o banco de dados Sql Server rodam em um comando através do compose
Optei por manter a organização utilizando princípios de arquitetura limpa
A solução foi versionada desde o início no git
Utilizei ferramentas como FluentValidation para fazer as validações de estado nas controllers
Criei um script inicial de banco para preencher as tabelas com um usuário padrão

# Como utilizar a aplicação

Para rodar a aplicação, você deve ter o Docker desktop e o Docker compose instalados em sua máquina

Dito isso, basta acessar o diretório da aplicação clonada do github através do git clone, e rodar o comando docker-compose up
