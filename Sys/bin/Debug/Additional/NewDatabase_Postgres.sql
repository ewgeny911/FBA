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
   
CREATE TABLE arhForm (ID serial NOT NULL, EntityID INTEGER DEFAULT (107), Name TEXT, Type TEXT, DEL INTEGER, Block INTEGER, DateCreate timestamp without time zone, DateCreateTest timestamp without time zone, DateChange timestamp without time zone, DateChangeTest timestamp without time zone, AuthorCreate INTEGER, AuthorCreateTest INTEGER, AuthorChange INTEGER, AuthorChangeTest INTEGER, FormXML TEXT, FormXMLTest TEXT, FormCode TEXT, FormCodeTest TEXT, TextCode TEXT, TextCodeTest TEXT, FormDLL TEXT, FormDLLTest TEXT, CountRows INTEGER, CountRowsTest INTEGER, Description TEXT, Hash TEXT, HashTest TEXT, TextAssembly TEXT, TextAssemblyTest TEXT, TextUsing TEXT, TextUsingTest TEXT, "Query" TEXT, QueryTest TEXT, CONSTRAINT "pk_arhForm_ID" PRIMARY KEY (ID));
CREATE TABLE arhRole (ID serial NOT NULL, EntityID INTEGER DEFAULT (101), Name TEXT, Brief TEXT, DateCreate timestamp without time zone, DateChange timestamp without time zone, CONSTRAINT "pk_arhRole_ID" PRIMARY KEY (ID));
CREATE TABLE arhUser (ID serial NOT NULL, EntityID INTEGER DEFAULT (102), Login TEXT, Name TEXT, RoleID INTEGER REFERENCES arhRole (ID), Block INTEGER, Pass TEXT, DateCreate timestamp without time zone, DateChange timestamp without time zone, CONSTRAINT "pk_arhUser_ID" PRIMARY KEY (ID));
CREATE TABLE arhConnectionList (ID serial NOT NULL, EntityID INTEGER DEFAULT (105), ConnectionName TEXT, ServerName TEXT, ServerType TEXT, DatabaseName TEXT, DatabaseLogin TEXT, DatabasePass TEXT, UserForm TEXT, UserLogin TEXT, UserPass TEXT, CONSTRAINT "pk_arhConnectionList_ID" PRIMARY KEY (ID));
CREATE TABLE arhEnterLast (ID serial NOT NULL, EntityID INTEGER DEFAULT (106), ConnectionName TEXT, EnterDate timestamp without time zone, EnterMode TEXT, CONSTRAINT "pk_arhEnterLast_ID" PRIMARY KEY (ID));
CREATE TABLE arhEntity (ID serial NOT NULL, EntityID INTEGER DEFAULT (101), Name TEXT, Brief TEXT, CONSTRAINT "pk_arhEntity_ID" PRIMARY KEY (ID));
CREATE TABLE arhFormHist (ID serial NOT NULL, EntityID INTEGER DEFAULT (109), Name TEXT, Type TEXT, DEL INTEGER, Block INTEGER, FormXML TEXT, FormCode TEXT, TextCode TEXT, FormDLL TEXT, CountRows INTEGER, FormID INTEGER REFERENCES arhForm (ID), AuthorCopy INTEGER, DateCopy timestamp without time zone, Hash TEXT, GUID TEXT, "Query" TEXT, CONSTRAINT "pk_arhFormHist_ID" PRIMARY KEY (ID));
CREATE TABLE arhEnterHist (ID serial NOT NULL, EntityID INTEGER DEFAULT (103), ConnectionName TEXT, MachineName TEXT, MachineUserName TEXT, UserForm TEXT, UserID INTEGER REFERENCES arhUser (ID), SystemName TEXT, EnterDate timestamp without time zone, CONSTRAINT "pk_arhEnterHist_ID" PRIMARY KEY (ID));
CREATE TABLE arhRelRoleUser (ID INTEGER, EntityID INTEGER DEFAULT (104), UserID INTEGER REFERENCES arhUser (ID), RoleID INTEGER REFERENCES arhRole (ID), CONSTRAINT "pk_arhRelRoleUser_ID" PRIMARY KEY (ID));
CREATE TABLE arhRelRoleForm (ID serial NOT NULL, EntityID INTEGER DEFAULT (108), FormID INTEGER REFERENCES arhForm (ID), RoleID INTEGER REFERENCES arhRole (ID), UserID INTEGER REFERENCES arhUser (ID), DateCreate timestamp without time zone, CONSTRAINT "pk_arhRelRoleForm_ID" PRIMARY KEY (ID));
CREATE TABLE arhClientAll (ID serial NOT NULL, EntityID INTEGER DEFAULT (110), Number INTEGER, Port INTEGER, UserCheck INTEGER, EnterDate timestamp without time zone, LocalIP TEXT, LocalHost TEXT, MachineName TEXT, MachineUserName TEXT, ConnectionGUID TEXT, CONSTRAINT "pk_arhClientAll_ID" PRIMARY KEY (ID));
CREATE TABLE arhClientCurrent (ID serial NOT NULL, EntityID INTEGER DEFAULT (111), Number INTEGER, Port INTEGER, UserCheck INTEGER, EnterDate timestamp without time zone, LocalIP TEXT, LocalHost TEXT, MachineName TEXT, MachineUserName TEXT, ConnectionGUID TEXT, CONSTRAINT "pk_arhClientCurrent_ID" PRIMARY KEY (ID));
CREATE TABLE arhQueries (ID serial NOT NULL, EntityID INTEGER DEFAULT (112), SQL TEXT, CONSTRAINT "pk_arhQueries_ID" PRIMARY KEY (ID));  
CREATE TABLE arhProgUpdate(ID serial NOT NULL, EntityID INTEGER DEFAULT (112), NumberFile INTEGER, NumberUpdate INTEGER, DateRecord timestamp without time zone, UserUpdate INTEGER, ContentType INTEGER, Operation INTEGER, Version TEXT, CurrentVersion TEXT, FullName TEXT, Path TEXT, Name TEXT, Extension TEXT, CreationTime timestamp without time zone, LastWriteTime timestamp without time zone, LastAccessTime timestamp without time zone, Size INTEGER, MD5 TEXT, FileData TEXT, CONSTRAINT "pk_arhProgUpdate_ID" PRIMARY KEY (ID));
CREATE TABLE arhLicense (ID INTEGER  PRIMARY KEY AUTOINCREMENT, EntityID INTEGER  DEFAULT (109), LicenseKey   TEXT, LicenseCount INTEGER, DateCreate   timestamp without time zone, DateStart    timestamp without time zone, DateEnd      timestamp without time zone, CONSTRAINT "pk_arhLicense_ID" PRIMARY KEY (ID));
CREATE TABLE arhSysParam (ID INTEGER  PRIMARY KEY AUTOINCREMENT, EntityID INTEGER, DateCreate timestamp without time zone, DateChange timestamp without time zone, Name TEXT, Type TEXT, Value TEXT, Comment TEXT, CONSTRAINT "pk_arhSysParam_ID" PRIMARY KEY (ID));
CREATE TABLE arhReport (ID  INTEGER   PRIMARY KEY, EntityID INTEGER, DateCreate   timestamp without time zone, UserCreateID INTEGER, DateChange   timestamp without time zone,UserChangeID INTEGER, ReportType   TEXT, Brief        TEXT, Name         TEXT, FileName     TEXT, FileNameFull TEXT,FileData     TEXT, Comment      TEXT, CONSTRAINT "pk_arhReport_ID" PRIMARY KEY (ID));
CREATE TABLE arhError (ID   INTEGER PRIMARY KEY, EntityID INTEGER, UserID INTEGER, ErrorTime timestamp without time zone, ErrorText TEXT, Screenshot TEXT, CompressRatio INTEGER, AdditionalInfo TEXT, CONSTRAINT "pk_arhError_ID" PRIMARY KEY (ID));          


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