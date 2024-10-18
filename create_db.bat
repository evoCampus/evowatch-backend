@echo off

echo Creating MSSQL volume

echo Starting MSSQL in docker...
docker run --name evowatchdb-mssql2022 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=1Secure*Password1" -v evowatchdb-mssql2022:/var/opt/mssql -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

echo Waiting 5 seconds for MSSQL to start...
timeout 5 > nul

echo Applying migrations...

dotnet ef database update

@echo on