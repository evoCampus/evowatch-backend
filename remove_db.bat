@echo off

echo Removing old MSSQl container
docker rm -f evowatchdb-mssql2022

echo Removing old MSSQL volume
docker volume rm evowatchdb-mssql2022

@echo on