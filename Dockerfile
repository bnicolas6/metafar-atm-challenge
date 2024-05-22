# Utilizamos la imagen oficial de SQL Server 2022 desde Microsoft
FROM mcr.microsoft.com/mssql/server:2022-latest

# Variables de entorno para configurar la instancia de SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=password_123

# Exponemos el puerto 1433 para conexiones TCP/IP
EXPOSE 1433
