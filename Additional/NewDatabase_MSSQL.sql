/* 
  DROP TABLE IF EXISTS arhConnectionList; 
  DROP TABLE IF EXISTS arhEnterLast; 
  DROP TABLE IF EXISTS arhEntity;  
  DROP TABLE IF EXISTS arhFormHist;
  DROP TABLE IF EXISTS arhEnterHist;
  DROP TABLE IF EXISTS arhQueries; 
  DROP TABLE IF EXISTS arhRelRoleForm; 
  DROP TABLE IF EXISTS arhRelRoleUser;
  DROP TABLE IF EXISTS arhForm;  
  DROP TABLE IF EXISTS arhUser; 
  DROP TABLE IF EXISTS arhRole;
  DROP TABLE IF EXISTS arhClientAll; 
  DROP TABLE IF EXISTS arhClientCurrent;    
  DROP TABLE IF EXISTS arhProgUpdate;  
*/
   
CREATE TABLE arhForm (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (107), Name VARCHAR(MAX), Type VARCHAR(MAX), DEL INTEGER, Block INTEGER, DateCreate DATETIME, DateCreateTest DATETIME, DateChange DATETIME, DateChangeTest DATETIME, AuthorCreate INTEGER, AuthorCreateTest INTEGER, AuthorChange INTEGER, AuthorChangeTest INTEGER, FormXML VARCHAR(MAX), FormXMLTest VARCHAR(MAX), FormCode VARCHAR(MAX), FormCodeTest VARCHAR(MAX), TextCode VARCHAR(MAX), TextCodeTest VARCHAR(MAX), FormDLL VARCHAR(MAX), FormDLLTest VARCHAR(MAX), CountRows INTEGER, CountRowsTest INTEGER, Description VARCHAR(MAX), Hash VARCHAR(MAX), HashTest VARCHAR(MAX), TextAssembly VARCHAR(MAX), TextAssemblyTest VARCHAR(MAX), TextUsing VARCHAR(MAX), TextUsingTest VARCHAR(MAX), "Query" VARCHAR(MAX), QueryTest TEXT CONSTRAINT [PK_arhForm] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhRole (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (101), Name VARCHAR(MAX), Brief VARCHAR(MAX), DateCreate DATETIME, DateChange DATETIME CONSTRAINT [PK_arhRole] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhUser (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (102), Login VARCHAR(MAX), Name VARCHAR(MAX), RoleID INTEGER REFERENCES arhRole (ID), Block INTEGER, Pass VARCHAR(MAX), DateCreate DATETIME, DateChange DATETIME CONSTRAINT [PK_arhUser] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhConnectionList (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (105), ConnectionName VARCHAR(MAX), ServerName VARCHAR(MAX), ServerType VARCHAR(MAX), DatabaseName VARCHAR(MAX), DatabaseLogin VARCHAR(MAX), DatabasePass VARCHAR(MAX), UserForm VARCHAR(MAX), UserLogin VARCHAR(MAX), UserPass TEXT CONSTRAINT [PK_arhConnectionList] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhEnterLast (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (106), ConnectionName VARCHAR(MAX), EnterDate DATETIME, EnterMode TEXT CONSTRAINT [PK_arhEnterLast] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhEntity (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (101), Name VARCHAR(MAX), Brief TEXT CONSTRAINT [PK_arhEntity] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhFormHist (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (109), Name VARCHAR(MAX), Type VARCHAR(MAX), DEL INTEGER, Block INTEGER, FormXML VARCHAR(MAX), FormCode VARCHAR(MAX), TextCode VARCHAR(MAX), FormDLL VARCHAR(MAX), CountRows INTEGER, FormID INTEGER REFERENCES arhForm (ID), AuthorCopy INTEGER, DateCopy DATETIME, Hash VARCHAR(MAX), GUID VARCHAR(MAX), "Query" TEXT CONSTRAINT [PK_arhFormHist] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhEnterHist (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (103), ConnectionName VARCHAR(MAX), MachineName VARCHAR(MAX), MachineUserName VARCHAR(MAX), UserForm VARCHAR(MAX), UserID INTEGER REFERENCES arhUser (ID), SystemName VARCHAR(MAX), EnterDate DATETIME CONSTRAINT [PK_arhEnterHist] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhRelRoleUser (ID INTEGER, EntityID INTEGER DEFAULT (104), UserID INTEGER REFERENCES arhUser (ID), RoleID INTEGER REFERENCES arhRole (ID) CONSTRAINT [PK_arhRelRoleUser] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhRelRoleForm (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (108), FormID INTEGER REFERENCES arhForm (ID), RoleID INTEGER REFERENCES arhRole (ID), UserID INTEGER REFERENCES arhUser (ID), DateCreate DATETIME CONSTRAINT [PK_arhRelRoleForm] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhClientAll (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (110), Number INTEGER, Port INTEGER, UserCheck INTEGER, EnterDate DATETIME, LocalIP VARCHAR(MAX), LocalHost VARCHAR(MAX), MachineName VARCHAR(MAX), MachineUserName VARCHAR(MAX), ConnectionGUID TEXT CONSTRAINT [PK_arhClientAll] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhClientCurrent (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (111), Number INTEGER, Port INTEGER, UserCheck INTEGER, EnterDate DATETIME, LocalIP VARCHAR(MAX), LocalHost VARCHAR(MAX), MachineName VARCHAR(MAX), MachineUserName VARCHAR(MAX), ConnectionGUID TEXT CONSTRAINT [PK_arhClientCurrent] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhQueries (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (112), SQL TEXT CONSTRAINT [PK_arhQueries] PRIMARY KEY CLUSTERED ([ID] ASC));  
CREATE TABLE arhProgUpdate(ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER DEFAULT (112), NumberFile INTEGER, NumberUpdate INTEGER, DateRecord DATETIME , UserUpdate INTEGER, ContentType INTEGER, Operation INTEGER, Version VARCHAR(MAX), CurrentVersion VARCHAR(MAX), FullName VARCHAR(MAX), Path VARCHAR(MAX), Name VARCHAR(MAX), Extension VARCHAR(MAX), CreationTime DATETIME , LastWriteTime DATETIME , LastAccessTime DATETIME , Size INTEGER, MD5 VARCHAR(MAX), FileData TEXT CONSTRAINT [PK_arhProgUpdate] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhLicense (ID INTEGER  IDENTITY(1,1) NOT NULL, EntityID INTEGER  DEFAULT (109), LicenseKey   VARCHAR(MAX), LicenseCount INTEGER, DateCreate   DATETIME, DateStart    DATETIME, DateEnd      DATETIME CONSTRAINT [PK_arhLicense] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhSysParam (ID INTEGER IDENTITY(1,1) NOT NULL, EntityID INTEGER, DateCreate DATETIME, DateChange DATETIME, Name VARCHAR(MAX), Type VARCHAR(MAX), Value VARCHAR(MAX), Comment TEXT CONSTRAINT [PK_arhSysParam] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhReport (ID  INTEGER  IDENTITY(1,1) NOT NULL, EntityID INTEGER, DateCreate   DATETIME, UserCreateID INTEGER, DateChange   DATETIME,UserChangeID INTEGER, ReportType   VARCHAR(MAX), Format     VARCHAR(10), Brief        , Name         VARCHAR(MAX), FileName     VARCHAR(MAX), FileNameFull VARCHAR(MAX),FileData     VARCHAR(MAX), Comment      TEXT CONSTRAINT [PK_arhReport] PRIMARY KEY CLUSTERED ([ID] ASC));
CREATE TABLE arhError (ID  INTEGER IDENTITY(1,1), EntityID INTEGER, UserID TEXT, ErrorTime DATETIME, ErrorText TEXT, ScreenshotFormat TEXT, ScreenshotWidth INTEGER, ScreenshotHeight INTEGER, ScreenshotSize INTEGER,CompressRatio  INTEGER, AdditionalInfo TEXT, ScreenshotData TEXT)


/*
insert into arhEntity (EntityID, Name, Brief) values (100, 'Сущность', 'Сущность'); --Entity
insert into arhEntity (EntityID, Name, Brief) values (101, 'Роль', 'Роль'); --Role
insert into arhEntity (EntityID, Name, Brief) values (102, 'Пользователь', 'Пользователь'); --Usr
insert into arhEntity (EntityID, Name, Brief) values (103, 'ИсторияВход', 'ИсторияВход'); --EnterHist
insert into arhEntity (EntityID, Name, Brief) values (104, 'ОтношениеРольПользователь', 'ОтношениеРольПользователь'); --RelRoleUsr
insert into arhEntity (EntityID, Name, Brief) values (105, 'Подключение',  'Подключение'); --ConnectionList
insert into arhEntity (EntityID, Name, Brief) values (106, 'ВходПоследний', 'ВходПоследний'); --EnterLast
insert into arhEntity (EntityID, Name, Brief) values (107, 'Форма',  'Форма'); --Form
insert into arhEntity (EntityID, Name, Brief) values (108, 'ОтношениеРольФорма', 'ОтношениеРольФорма'); --RelRoleForm
insert into arhEntity (EntityID, Name, Brief) values (109, 'ИсторияФорма',  'ИсторияФорма'); --FormHist
insert into arhEntity (EntityID, Name, Brief) values (110, 'КлиентыВсе',  'КлиентыВсе'); --ClientAll
insert into arhEntity (EntityID, Name, Brief) values (111, 'КлиентТекущие',  'КлиентТекущие'); --ClientCurrent
insert into arhEntity (EntityID, Name, Brief) values (112, 'Запрос', 'Запрос');
insert into arhEntity (EntityID, Name, Brief) values (113, 'Обновление программы', 'Обновление');

--Наполнение данными:
--Роль администратора
INSERT INTO arhRole (name, brief, datecreate, datechange) VALUES ('admin', 'admin', current_timestamp, current_timestamp);

--Учетная запись администратора, логин admin пароль пустой
INSERT INTO arhUser (login, name, roleid, block, datecreate, datechange, pass)
  SELECT 'admin', 'admin', id, 0, current_timestamp, current_timestamp, '' FROM arhRole WHERE brief = 'admin' LIMIT 1;
*/