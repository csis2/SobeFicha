%comment%
MakeRelease versao 1.0 - CSIS Software - setembro 2022.
Gera arquivo de release do utilitario SobeFicha.
O diretorio SobeFicha tem que estar na raiz do disco C.
O diretorio de montagem fica no c:/temp. Esse diretorio nao e criado pelo script. Tem que ser criado pelo
usuario, caso nao exista.
Ao final do processo, o arquivo sobeficha.zip é criado em:
c:\SobeFicha\SobeFicha\bin.
:endcomment

cd\
cd temp
md sobeficha
cd sobeficha
md sobeficha
copy c:\sobeficha\sobeficha\bin\release\netcoreapp3.1\publish\IniFile.dll c:\temp\sobeficha\sobeficha
copy c:\sobeficha\sobeficha\bin\release\netcoreapp3.1\publish\INIFileParser.dll c:\temp\sobeficha\sobeficha
copy c:\sobeficha\sobeficha\bin\release\netcoreapp3.1\publish\SobeFicha.deps.json c:\temp\sobeficha\sobeficha
copy c:\sobeficha\sobeficha\bin\release\netcoreapp3.1\publish\SobeFicha.dll c:\temp\sobeficha\sobeficha
copy c:\sobeficha\sobeficha\bin\release\netcoreapp3.1\publish\SobeFicha.exe c:\temp\sobeficha\sobeficha
copy c:\sobeficha\sobeficha\bin\release\netcoreapp3.1\publish\SobeFicha.pdb c:\temp\sobeficha\sobeficha
copy c:\sobeficha\sobeficha\bin\release\netcoreapp3.1\publish\SobeFicha.runtimeconfig.json c:\temp\sobeficha\sobeficha

cd sobeficha
md bin
md doc
md set
md tmp
dir
copy c:\sobeficha\sobeficha\bin\run_psqlx.exe c:\temp\sobeficha\sobeficha\bin
copy c:\sobeficha\sobeficha\doc\sobeficha.docx c:\temp\sobeficha\sobeficha\doc
copy c:\sobeficha\sobeficha\doc\SobeFicha_directory_structure.jpg c:\temp\sobeficha\sobeficha\doc
copy c:\sobeficha\sobeficha\set\SobeFicha.ini c:\temp\sobeficha\sobeficha\set

cd\
cd sobeficha\sobeficha\bin
7za.exe a -r sobeficha.zip c:\temp\sobeficha\