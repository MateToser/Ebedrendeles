
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/19/2017 23:38:58
-- Generated from EDMX file: C:\Users\tgabo\OneDrive\Documents\Visual Studio 2015\Projects\Ebedrendeles\Ebedrendeles_adatbazis\database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\Users\tgabo\OneDrive\Documents\Visual Studio 2015\Projects\Ebedrendeles\Ebedrendeles_adatbazis\server.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_enRendelesenHetimenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[enMenuSet] DROP CONSTRAINT [FK_enRendelesenHetimenu];
GO
IF OBJECT_ID(N'[dbo].[FK_enRendelesenAlacarte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[enAlacarteSet] DROP CONSTRAINT [FK_enRendelesenAlacarte];
GO
IF OBJECT_ID(N'[dbo].[FK_enRendelesenFelhasznalo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[enKosarSet] DROP CONSTRAINT [FK_enRendelesenFelhasznalo];
GO
IF OBJECT_ID(N'[dbo].[FK_enAlacarteenEtelek]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[enAlacarteSet] DROP CONSTRAINT [FK_enAlacarteenEtelek];
GO
IF OBJECT_ID(N'[dbo].[FK_enNetelekenHrendeles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[enMenuSet] DROP CONSTRAINT [FK_enNetelekenHrendeles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[enKosarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[enKosarSet];
GO
IF OBJECT_ID(N'[dbo].[enAlacarteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[enAlacarteSet];
GO
IF OBJECT_ID(N'[dbo].[enEtelekSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[enEtelekSet];
GO
IF OBJECT_ID(N'[dbo].[enMenuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[enMenuSet];
GO
IF OBJECT_ID(N'[dbo].[enNetelekSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[enNetelekSet];
GO
IF OBJECT_ID(N'[dbo].[enFelhasznaloSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[enFelhasznaloSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'enKosarSet'
CREATE TABLE [dbo].[enKosarSet] (
    [rendelesID] int IDENTITY(1,1) NOT NULL,
    [szamla] int  NOT NULL,
    [rendelesido] datetime  NOT NULL,
    [enFelhasznalo_felhasznaloID] int  NULL
);
GO

-- Creating table 'enAlacarteSet'
CREATE TABLE [dbo].[enAlacarteSet] (
    [alacarteID] int IDENTITY(1,1) NOT NULL,
    [datum] datetime  NOT NULL,
    [enRendeles_rendelesID] int  NULL,
    [enEtelek_etelekID] int  NULL
);
GO

-- Creating table 'enEtelekSet'
CREATE TABLE [dbo].[enEtelekSet] (
    [etelekID] int IDENTITY(1,1) NOT NULL,
    [kategoria] nvarchar(max)  NOT NULL,
    [nev] nvarchar(max)  NOT NULL,
    [ar] int  NOT NULL,
    [kep] varbinary(max)  NOT NULL
);
GO

-- Creating table 'enMenuSet'
CREATE TABLE [dbo].[enMenuSet] (
    [hetimenuID] int IDENTITY(1,1) NOT NULL,
    [foetel] nvarchar(max)  NOT NULL,
    [enRendeles_rendelesID] int  NULL,
    [enNetelek_napietelekID] int  NULL
);
GO

-- Creating table 'enNetelekSet'
CREATE TABLE [dbo].[enNetelekSet] (
    [napietelekID] int IDENTITY(1,1) NOT NULL,
    [leves] nvarchar(max)  NOT NULL,
    [foetel1] nvarchar(max)  NOT NULL,
    [foetel2] nvarchar(max)  NOT NULL,
    [foetelvega] nvarchar(max)  NOT NULL,
    [desszert] nvarchar(max)  NOT NULL,
    [datum] datetime  NOT NULL
);
GO

-- Creating table 'enFelhasznaloSet'
CREATE TABLE [dbo].[enFelhasznaloSet] (
    [felhasznaloID] int IDENTITY(1,1) NOT NULL,
    [felhasznalonev] nvarchar(max)  NOT NULL,
    [jelszo] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [vezeteknev] nvarchar(max)  NOT NULL,
    [keresztnev] nvarchar(max)  NOT NULL,
    [iranyitoszam] int  NOT NULL,
    [varos] nvarchar(max)  NOT NULL,
    [cim] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [rendelesID] in table 'enKosarSet'
ALTER TABLE [dbo].[enKosarSet]
ADD CONSTRAINT [PK_enKosarSet]
    PRIMARY KEY CLUSTERED ([rendelesID] ASC);
GO

-- Creating primary key on [alacarteID] in table 'enAlacarteSet'
ALTER TABLE [dbo].[enAlacarteSet]
ADD CONSTRAINT [PK_enAlacarteSet]
    PRIMARY KEY CLUSTERED ([alacarteID] ASC);
GO

-- Creating primary key on [etelekID] in table 'enEtelekSet'
ALTER TABLE [dbo].[enEtelekSet]
ADD CONSTRAINT [PK_enEtelekSet]
    PRIMARY KEY CLUSTERED ([etelekID] ASC);
GO

-- Creating primary key on [hetimenuID] in table 'enMenuSet'
ALTER TABLE [dbo].[enMenuSet]
ADD CONSTRAINT [PK_enMenuSet]
    PRIMARY KEY CLUSTERED ([hetimenuID] ASC);
GO

-- Creating primary key on [napietelekID] in table 'enNetelekSet'
ALTER TABLE [dbo].[enNetelekSet]
ADD CONSTRAINT [PK_enNetelekSet]
    PRIMARY KEY CLUSTERED ([napietelekID] ASC);
GO

-- Creating primary key on [felhasznaloID] in table 'enFelhasznaloSet'
ALTER TABLE [dbo].[enFelhasznaloSet]
ADD CONSTRAINT [PK_enFelhasznaloSet]
    PRIMARY KEY CLUSTERED ([felhasznaloID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [enRendeles_rendelesID] in table 'enMenuSet'
ALTER TABLE [dbo].[enMenuSet]
ADD CONSTRAINT [FK_enRendelesenHetimenu]
    FOREIGN KEY ([enRendeles_rendelesID])
    REFERENCES [dbo].[enKosarSet]
        ([rendelesID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_enRendelesenHetimenu'
CREATE INDEX [IX_FK_enRendelesenHetimenu]
ON [dbo].[enMenuSet]
    ([enRendeles_rendelesID]);
GO

-- Creating foreign key on [enRendeles_rendelesID] in table 'enAlacarteSet'
ALTER TABLE [dbo].[enAlacarteSet]
ADD CONSTRAINT [FK_enRendelesenAlacarte]
    FOREIGN KEY ([enRendeles_rendelesID])
    REFERENCES [dbo].[enKosarSet]
        ([rendelesID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_enRendelesenAlacarte'
CREATE INDEX [IX_FK_enRendelesenAlacarte]
ON [dbo].[enAlacarteSet]
    ([enRendeles_rendelesID]);
GO

-- Creating foreign key on [enFelhasznalo_felhasznaloID] in table 'enKosarSet'
ALTER TABLE [dbo].[enKosarSet]
ADD CONSTRAINT [FK_enRendelesenFelhasznalo]
    FOREIGN KEY ([enFelhasznalo_felhasznaloID])
    REFERENCES [dbo].[enFelhasznaloSet]
        ([felhasznaloID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_enRendelesenFelhasznalo'
CREATE INDEX [IX_FK_enRendelesenFelhasznalo]
ON [dbo].[enKosarSet]
    ([enFelhasznalo_felhasznaloID]);
GO

-- Creating foreign key on [enEtelek_etelekID] in table 'enAlacarteSet'
ALTER TABLE [dbo].[enAlacarteSet]
ADD CONSTRAINT [FK_enAlacarteenEtelek]
    FOREIGN KEY ([enEtelek_etelekID])
    REFERENCES [dbo].[enEtelekSet]
        ([etelekID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_enAlacarteenEtelek'
CREATE INDEX [IX_FK_enAlacarteenEtelek]
ON [dbo].[enAlacarteSet]
    ([enEtelek_etelekID]);
GO

-- Creating foreign key on [enNetelek_napietelekID] in table 'enMenuSet'
ALTER TABLE [dbo].[enMenuSet]
ADD CONSTRAINT [FK_enNetelekenHrendeles]
    FOREIGN KEY ([enNetelek_napietelekID])
    REFERENCES [dbo].[enNetelekSet]
        ([napietelekID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_enNetelekenHrendeles'
CREATE INDEX [IX_FK_enNetelekenHrendeles]
ON [dbo].[enMenuSet]
    ([enNetelek_napietelekID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------