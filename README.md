# financeiro


Delivery front end 

1. delivery e um projeto em angular 
que tem as seguinstes configuracoes

1.1 
Angular CLI: 7.3.10
Node: 10.16.1
OS: win32 x64
Angular: 7.2.16
... animations, common, compiler, compiler-cli, core, forms
... language-service, platform-browser, platform-browser-dynamic
... router

Package                           Version
-----------------------------------------------------------
@angular-devkit/architect         0.13.10
@angular-devkit/build-angular     0.13.10
@angular-devkit/build-optimizer   0.13.10
@angular-devkit/build-webpack     0.13.10
@angular-devkit/core              7.3.10
@angular-devkit/schematics        7.3.10
@angular/cli                      7.3.10
@ngtools/webpack                  7.3.10
@schematics/angular               7.3.10
@schematics/update                0.13.10
rxjs                              6.3.3

1.2 node.js versão v10.16.1
1.3 o caminho da api esta localizado em no arquivo type script environment.ts
1.4 digitar o comando na raiz do projeto  npm i  para instalar os pacotes do package.json

--------------------------Deliver.api------------------------------------------------------------------
1. Update-Package -ProjectName Delivery.Api
2. Update-Package -ProjectName FinanceiroNucleo
3.  ConnectionString localizada no arquivo appsettings.Development.json
4. Criar a base de dados chamada delivery no banco local SQL Server Express
5. No console gerenciador de pacotes digitar o comando update-database para criar a estrutura do banco compativel com a classe de cominio 
6. Caso não funcione a primeira 5 passo cria a tabela  
CREATE TABLE [dbo].[ContasAPagar] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Nome]           NVARCHAR (MAX)  NOT NULL,
    [ValorOriginal]  DECIMAL (18, 2) NOT NULL,
    [DataVencimento] DATETIME2 (7)   NOT NULL,
    [DataPagamento]  DATETIME2 (7)   NOT NULL,
    [ValorMulta]     DECIMAL (18, 2) NOT NULL,
    [ValorCobrado]   DECIMAL (18, 2) NOT NULL,
    [DiasEmAtraso]   INT             DEFAULT ((0)) NOT NULL,
    [ValorJuros]     DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    CONSTRAINT [PK_ContasAPagar] PRIMARY KEY CLUSTERED ([Id] ASC)
);

 

