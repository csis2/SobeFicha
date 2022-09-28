::[Bat To Exe Converter]
::
::YAwzoRdxOk+EWAnk
::fBw5plQjdG8=
::YAwzuBVtJxjWCl3EqQJgSA==
::ZR4luwNxJguZRRnk
::Yhs/ulQjdF+5
::cxAkpRVqdFKZSDk=
::cBs/ulQjdF+5
::ZR41oxFsdFKZSDk=
::eBoioBt6dFKZSDk=
::cRo6pxp7LAbNWATEpCI=
::egkzugNsPRvcWATEpCI=
::dAsiuh18IRvcCxnZtBJQ
::cRYluBh/LU+EWAnk
::YxY4rhs+aU+JeA==
::cxY6rQJ7JhzQF1fEqQJQ
::ZQ05rAF9IBncCkqN+0xwdVs0
::ZQ05rAF9IAHYFVzEqQJQ
::eg0/rx1wNQPfEVWB+kM9LVsJDGQ=
::fBEirQZwNQPfEVWB+kM9LVsJDGQ=
::cRolqwZ3JBvQF1fEqQJQ
::dhA7uBVwLU+EWDk=
::YQ03rBFzNR3SWATElA==
::dhAmsQZ3MwfNWATElA==
::ZQ0/vhVqMQ3MEVWAtB9wSA==
::Zg8zqx1/OA3MEVWAtB9wSA==
::dhA7pRFwIByZRRnk
::Zh4grVQjdCyDJGqL9kcWIRhcTTixM2m/ILwf4OnH/PiEnl8IWt0va57X4vqLOOVz
::YB416Ek+ZG8=
::
::
::978f952a14a936cc963da21a135fa983
cls
@echo on
@echo *********************************************************************************************************************
@echo run_psqlX - release candidate - jul/2022
@echo Executa acoes no banco de dados do SINAN NET versao 5.0 patch 5.3.
@echo *********************************************************************************************************************
@echo sintaxe - run_psqlX ["caminho da subpasta bin do PostgreSQL"] [Host] [Porta] [Usuario] [Database] ["comando"]
@echo Exemplo run_psqlX "c:\program files (x86)\postgresql\9.0\bin" localhost 5445
@echo postgres sinanpop62 "select no_padrao_consulta from dbsinan.tb_padrao_consulta;"
@echo *********************************************************************************************************************
@echo off
cd\
cd "%1%"
set pgpassword=
set Host=%2%
set Porta=%3%
set Usuario=%4%
set Database=%5%
psql -h %Host% -p %Porta% -U %Usuario% -d %Database% -c %6% -o \sobeficha\sobeficha\tmp\output.txt
cd\
cd c:\sobeficha\sobeficha\src