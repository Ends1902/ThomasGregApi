#!/bin/bash

# Inicia o SQL Server em segundo plano
/opt/mssql/bin/sqlservr &

echo "Aguardando SQL Server iniciar..."
sleep 15

# Executa o script
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P SenhaForte12345 -i /Init.sql


# Espera o processo do SQL Server
wait