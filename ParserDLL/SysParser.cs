/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 21.08.2017
 * Время: 15:34
 */
 
using System;
//using System.Collections.Generic; 
//using System.Windows.Forms;       
//using System.Data;
//using System.Diagnostics; 
//using System.Linq;
//using System.Text;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
 //8-906-097-37-91 Участок 11000
 //Добавить команды работы с файлами.. может быть.
 //Язык работы со значениями таблицы - все текстовые команды C# и sys...
 
namespace FBA
{    
    ///Парсер запросов MSQL к модели данных.
    ///Разбит на два файла для удобства:
    ///SysParserData - это статический класс с некоторымим методами, которые можно сделать статическими.
    ///SysParser - это класс в котором собраны все методы преобразования MSQL в SQL.      
    //Часть кода вынесена в модуль SysParserData, чтобы лечше прокручивать было.
    //Основная логика всего парсера в этом модуле.
    public partial class Parser
    {                         
        ///Составление списка таблиц.
        private void GetListTable()
        {
            //return;
            //CHR());
            //string c = ((char)67).ToString();
            //char c = Convert.ToChar(65); 
            //sys.SM(c);
            //Left Outer Join enEntity EOT_2 On EOT_2.ID = EOT_1.EntityID 
            
            TableCount = 0;                     
            GreateTableForAttr1();   //Все атрибуты записываем в отдельную таблицу AttrTable.                      
            GreateTableForAttr2();   //Получение данных по атрибутам.
            GreateTableForAttr2_1(); //Проставляем алиасы таблицам, которые будем джойнить.    
            GreateTableForAttr3();   //Проставляем дату состояния для каждой таблицы в AttrTable.                    
            GreateTableForAttr6();   //Составляем JOIN-ы.
            GreateTableForAttr6_1(); //Составляем JOIN-ы.
            GreateTableForAttr7();   //Проставляем код SQL для атрибута.       
            SetSQLCode();            
        }
                   
        ///Все атрибуты записываем в отдельную таблицу AttrTable. 
        ///Завполнение: vEntityID, vEntityTableMain, vEntityTableFieldID
        private void GreateTableForAttr1()
        {                                                                   
            for (int i = 0; i < WordsCount; i++)
            {    
                if (Words[i, wLexType] != "ATTR")  continue;   //&& (Words[i, wStateDate] != "1"))
                                             
                string AttrFull    = Words[i, wAttrFull];
                                                                                                       
                //Делаем пометку, если атрибут начинается с ПсевдонимСущности. 
                string IsPrevdonimEntity = "";                                                         
                if (AttrFull.ToUpper().IndexOf("ПСЕВДОНИМСУЩНОСТИ", StringComparison.OrdinalIgnoreCase) > -1) IsPrevdonimEntity = "1";
                                                   
                if (IsPrevdonimEntity == "1")
                {
                    AttrFull = AttrFull.ParserReplaceIgnoreCase("ПСЕВДОНИМСУЩНОСТИ.", "").ParserReplaceIgnoreCase("ПСЕВДОНИМСУЩНОСТИ", "");                                                               
                }
                
                if (AttrFull == "") continue;
                
                string[] ArrAttr = AttrFull.Split('.');
                string AttrPartFull = "";  
                for (int j = 0; j < ArrAttr.Length; j++) 
                {                                                                                         
                    if (AttrPartFull != "") AttrPartFull = AttrPartFull + ".";                    
                    AttrPartFull = AttrPartFull + ArrAttr[j];
                    string NumPart = (j + 1).ToString();
                    //!!if ((ArrAttr[j] == "ИсторияАтрибута") || (ArrAttr[j] == "ДатаСостАтрибута"))
                    //!!{
                    //!!    NumPart = AttrTable[AttrTableCount - 1, vNumPart];
                    //!!}
                   
                    AttrTable[AttrTableCount, vPos]                = AttrTableCount.ToString("D3");
                    AttrTable[AttrTableCount, vNum]                = Words[i, wPos];
                    AttrTable[AttrTableCount, vAlias]              = Words[i, wAlias];
                    AttrTable[AttrTableCount, vSelect]             = Words[i, wSelect];                                
                    AttrTable[AttrTableCount, vNumPart]            = NumPart; 
                    AttrTable[AttrTableCount, vLastPart]           = ""; 
                    AttrTable[AttrTableCount, vPsevdonim]          = IsPrevdonimEntity;                     
                    AttrTable[AttrTableCount, vEntity]             = Words[i, wEntity];
                    AttrTable[AttrTableCount, vEntityAlias]        = Words[i, wEntityAlias];
                    AttrTable[AttrTableCount, vEntityID]           = "";
                    AttrTable[AttrTableCount, vEntityTableMain]    = "";
                    AttrTable[AttrTableCount, vEntityTableFieldID] = "";
                    AttrTable[AttrTableCount, vRef_EntityBrief]    = "";
                    AttrTable[AttrTableCount, vAttrFull]           = AttrFull;  
                    AttrTable[AttrTableCount, vAttrPartFull]       = AttrPartFull;  
                    AttrTable[AttrTableCount, vAttrPartNoLast]     = "";
                    AttrTable[AttrTableCount, vAttrPart]           = ArrAttr[j];
                    AttrTable[AttrTableCount, vAttrType]           = ""; 
                    AttrTable[AttrTableCount, vAttrKind]           = "";
                    AttrTable[AttrTableCount, vAttrCode]           = "";
                    AttrTable[AttrTableCount, vTableName]          = "";
                    AttrTable[AttrTableCount, vTableType]          = "";
                    AttrTable[AttrTableCount, vTableField]         = "";
                    AttrTable[AttrTableCount, vTableField2]        = "";                                                  
                    AttrTable[AttrTableCount, vTableFieldID]       = "";
                    AttrTable[AttrTableCount, vTableAlias]         = "";                                                
                    AttrTable[AttrTableCount, vTableAliasReplace]  = "";
                    AttrTable[AttrTableCount, vStateDate]          = "AttTableStateDate" + AttrTableCount.ToString("D3"); //LocalDate; //LocalDate это текущая дата в формате '20180124 23:59:59'. По умолчанию текущую дату для историчных таблиц, позже она будет переписана.
                    AttrTable[AttrTableCount, vJoinTableName]      = "";    
                    AttrTable[AttrTableCount, vJoinTableAlias]     = "";
                    AttrTable[AttrTableCount, vJoinTableFieldID]   = "";                                                                      
                    AttrTable[AttrTableCount, vJoinSQL]            = "";
                    AttrTable[AttrTableCount, vAttrSQL]            = "";
                    AttrTable[AttrTableCount, vSubJoinSQL]         = "";
                    AttrTable[AttrTableCount, vSubSQL]             = "";
                    AttrTable[AttrTableCount, vNumSub]             = PsevdonimCountRecursion.ToString();
                    AttrTable[AttrTableCount, vPosSub]             = "";
                    AttrTable[AttrTableCount, vBlockWhere]         = Words[i, wBlockWhere];
                    
                    /*AttrTable[AttrTableCount, vJOIN_Table]         = "";
                    AttrTable[AttrTableCount, vJOIN_Alias1]        = "";
                    AttrTable[AttrTableCount, vJOIN_Field1]        = "";
                    AttrTable[AttrTableCount, vJOIN_Alias2]        = "";
                    AttrTable[AttrTableCount, vJOIN_Field2]        = "";
                    AttrTable[AttrTableCount, vJOIN_Hist]          = "";
                    
                    AttrTable[AttrTableCount, vJOINSub_Table]      = "";
                    AttrTable[AttrTableCount, vJOINSub_Alias1]     = "";
                    AttrTable[AttrTableCount, vJOINSub_Field1]     = "";
                    AttrTable[AttrTableCount, vJOINSub_Alias2]     = "";
                    AttrTable[AttrTableCount, vJOINSub_Field2]     = "";
                    AttrTable[AttrTableCount, vJOINSub_Hist]       = "";*/
                    //Проставляем признак последнего атрибута в составном атрибуте.
                    if (j == (ArrAttr.Length - 1)) AttrTable[AttrTableCount, vLastPart] = "1";
                    
                    if (AttrTable[AttrTableCount,  vNumPart] != "1")
                        AttrTable[AttrTableCount,  vAttrPartNoLast] = AttrTable[AttrTableCount - 1, vAttrPartFull];
                    else AttrTable[AttrTableCount, vAttrPartNoLast] = AttrPartFull;
                                                                                                  
                          
                    //AttrTable[AttrTableCount, vAttrPsevdonim] = "";
                    //Если мы стоим на атрибуте, который содержит слово ПСЕВДОНИМСУЩНОСТИ, то значит атрибут начинается с той сущности,
                    //сокращение которой было передано при создании объекта Parser.
                    //поэтому в качестве главной сущности выставляем её.
                    if (IsPrevdonimEntity == "1")
                    {
                        AttrTable[AttrTableCount, vEntity]        = PsevdonimEntityBrief;
                        AttrTable[AttrTableCount, vEntityAlias]   = PsevdonimAlias;                                                                   
                    } 
                    
                    //Проставление главной таблицы сущности и её поля ID.
                    string EntityBrief = AttrTable[AttrTableCount, vEntity];
                    string TableType;
                    ParserData.GetEntityData(EntityBrief,                                                                         
                                              out AttrTable[AttrTableCount, vEntityID],
                                              out AttrTable[AttrTableCount, vEntityTableMain],
                                              out TableType,
                                              out AttrTable[AttrTableCount, vEntityTableFieldID]);                                                         
                    AttrTableCount++;
                } 
            }                      
        }       
     
        ///Получение данных по атрибутам.
        private void GreateTableForAttr2()
        {              
            for (int i = 0; i < AttrTableCount; i++)
            {                                                                            
                string Entity = "";
                if (AttrTable[i, vNumPart] == "1") Entity = AttrTable[i, vEntity];
                else        
                {
                    if (AttrTable[i - 1, vNum] == AttrTable[i, vNum]) 
                        Entity = AttrTable[i - 1, vRef_EntityBrief];                          
                } 
                
                //Если атрибут - КоличОбъектовМассива.
                if (AttrTable[i, vAttrPart].ToUpper() == "КОЛИЧОБЪЕКТОВМАССИВА") 
                {                   
                    AttrTable[i, vEntityID]        = AttrTable[i - 1, vEntityID];
                    AttrTable[i, vRef_EntityBrief] = AttrTable[i - 1, vRef_EntityBrief];
                    AttrTable[i, vAttrType]        = AttrTable[i - 1, vAttrType];
                    AttrTable[i, vAttrKind]        = AttrTable[i - 1, vAttrKind];
                    AttrTable[i, vAttrCode]        = AttrTable[i - 1, vAttrCode];
                    AttrTable[i, vTableName]       = AttrTable[i - 1, vTableName];
                    AttrTable[i, vTableType]       = AttrTable[i - 1, vTableType];
                    AttrTable[i, vTableField]      = AttrTable[i - 1, vTableField]; 
                    AttrTable[i, vTableField2]     = "";    
                    AttrTable[i, vTableFieldID]    = "N";  //Наименование поля по умолчанию.                                                    
                    continue;                                      
                }      
                
                if ((Entity == "") && (i > 0) && (AttrTable[i, vNumPart] != "1"))
                {     
                    //Если атрибут - ДатаСостАтрибута.
                    if (AttrTable[i, vAttrPart] == "AttrStateDate") 
                    {                   
                        AttrTable[i, vEntityID]        = AttrTable[i - 1, vEntityID];
                        AttrTable[i, vRef_EntityBrief] = AttrTable[i - 1, vRef_EntityBrief];
                        AttrTable[i, vAttrType]        = AttrTable[i - 1, vAttrType];
                        AttrTable[i, vAttrKind]        = AttrTable[i - 1, vAttrKind];
                        AttrTable[i, vAttrCode]        = AttrTable[i - 1, vAttrCode];
                        AttrTable[i, vTableName]       = AttrTable[i - 1, vTableName];
                        AttrTable[i, vTableType]       = AttrTable[i - 1, vTableType];
                        AttrTable[i, vTableField]      = "StateDate";
                        AttrTable[i, vTableField2]     = "";    
                        AttrTable[i, vTableFieldID]    = AttrTable[i - 1, vTableFieldID];                                                     
                        continue;                                      
                    }
                                                                       
                    //Если атрибут - ИсторияАтрибута.
                    if (AttrTable[i, vAttrPart].ToUpper() == "ИСТОРИЯАТРИБУТА") 
                    {                   
                        AttrTable[i, vEntityID]        = AttrTable[i - 1, vEntityID];
                        AttrTable[i, vRef_EntityBrief] = AttrTable[i - 1, vRef_EntityBrief];
                        AttrTable[i, vAttrType]        = AttrTable[i - 1, vAttrType];
                        AttrTable[i, vAttrKind]        = AttrTable[i - 1, vAttrKind];
                        AttrTable[i, vAttrCode]        = AttrTable[i - 1, vAttrCode];
                        AttrTable[i, vTableName]       = AttrTable[i - 1, vTableName];
                        AttrTable[i, vTableType]       = AttrTable[i - 1, vTableType];
                        AttrTable[i, vTableAlias]      = AttrTable[i - 1, vTableAlias];
                        AttrTable[i, vTableField]      = AttrTable[i - 1, vTableField];
                        AttrTable[i, vTableField2]     = "";    
                        AttrTable[i, vTableFieldID]    = AttrTable[i - 1, vTableFieldID];                                                     
                        continue;                                      
                    }
                                                          
                    //Если универсальная ссылка.
                    if (AttrTable[i - 1, vAttrType] == "UniLink")
                    {
                        AttrTable[i, vAttrType]         = AttrTable[i - 1, vAttrType];
                        AttrTable[i, vAttrKind]         = AttrTable[i - 1, vAttrKind];                         
                        
                        if ((AttrTable[i, vAttrPart].ToUpper() == "СОКРСУЩНОСТИ") ||
                            (AttrTable[i, vAttrPart].ToUpper() == "НАИМСУЩНОСТИ"))
                        {    
                            AttrTable[i, vTableName]   = "enEntity";
                            AttrTable[i, vTableType]   = "Main";
                            AttrTable[i, vTableField]  = "ID";
                            AttrTable[i, vTableField2] = "";
                        } else
                        {
                            AttrTable[i, vTableName]        = AttrTable[i - 1, vTableName];
                            AttrTable[i, vTableType]        = AttrTable[i - 1, vTableType];
                            AttrTable[i, vTableField]       = AttrTable[i - 1, vTableField];
                            AttrTable[i, vTableField2]      = AttrTable[i - 1, vTableField2];
                            AttrTable[i, vTableFieldID]     = AttrTable[i - 1, vTableFieldID];
                            AttrTable[i, vTableAlias]       = AttrTable[i - 1, vTableAlias];
                            AttrTable[i, vStateDate]        = AttrTable[i - 1, vStateDate];
                            AttrTable[i, vJoinTableName]    = AttrTable[i - 1, vJoinTableName];
                            AttrTable[i, vJoinTableAlias]   = AttrTable[i - 1, vJoinTableAlias];
                            AttrTable[i, vJoinTableFieldID] = AttrTable[i - 1, vJoinTableFieldID]; 
                        }
                        continue;
                    }
                }
                                
                //Проверка на ошибку.
                if (Entity == "") 
                {
                    //sys.SM("Ошибка парсера. Сущность атрибута " + AttrTable[i, vAttrPart] + " не определена.");
                    ParserSys.ParserSM("Parser error. The entity of the attribute '" + AttrTable[i, vAttrPart] + "' is not defined. Num: " + i.ToString());
                    continue;
                }
                                 
                string AttrPart = AttrTable[i, vAttrPart];
                if (AttrPart.ToUpper() == "ПСЕВДОНИМСУЩНОСТИ") continue;
           
                
                ParserData.GetAttrData(Entity, AttrPart, 
                     out AttrTable[i, vEntityID],
                     out AttrTable[i, vRef_EntityBrief],                      
                     out AttrTable[i, vAttrType],
                     out AttrTable[i, vAttrKind],
                     out AttrTable[i, vAttrCode],                      
                     out AttrTable[i, vTableName],
                     out AttrTable[i, vTableType],                                     
                     out AttrTable[i, vTableField],
                     out AttrTable[i, vTableField2],
                     out AttrTable[i, vTableFieldID]);
                
                //Простой или системный.
                if (AttrTable[i, vAttrKind].ParserInStr("Simple, System") &&               
                   (AttrTable[i, vNumPart] == "1") &&
                   (AttrTable[i, vTableName] == AttrTable[i, vEntityTableMain]))
                {
                    AttrTable[i, vTableAlias] = AttrTable[i, vEntityAlias];
                }                                  
                
                //Вычисляемый атрибут.                    
                if ((AttrTable[i, vAttrKind] == "Calc")  && 
                    (AttrTable[i, vAttrType] == "Field") &&
                    (AttrTable[i, vAttrCode].ToUpper().IndexOf("ПСЕВДОНИМСУЩНОСТИ", StringComparison.OrdinalIgnoreCase) > -1))
                {
                    //Таблицу джойним если в вычисляемом атрибуте есть указание на ПсевдонимСущности. В противном случае она нам не нужна,
                    //нам просто нечего с неё брать, поэтому и джойнить её не нужно. 
                    //Если, например, вычисляемыфй атрибут принадлежит родителю сущности и нет указания на ПсевдонимСущности, 
                    //то таблицу родителя не джойним.    
                    string EntityID;
                    ParserData.GetEntityData(Entity,
                                             out EntityID, //Пока не используется.
                                             out AttrTable[i, vTableName],  
                                             out AttrTable[i, vTableType],  
                                             out AttrTable[i, vTableFieldID]);
                } 
                //Вычисляемая ссылка.
                if ((AttrTable[i, vAttrKind] == "Calc") && 
                    (AttrTable[i, vAttrType] == "Link"))
                {
                    string EntityID;
                    Entity = AttrTable[i, vRef_EntityBrief];
                    ParserData.GetEntityData(Entity,
                                             out EntityID, //Пока не используется.
                                             out AttrTable[i, vTableName],  
                                             out AttrTable[i, vTableType],  
                                             out AttrTable[i, vTableFieldID]); 
                    AttrTable[i, vTableField] = AttrTable[i, vTableFieldID];
                }                 
            }        
        }
                
        ///Проставляем псевдоним всем таблицам. Так как все таблицы всех атрибутов определены.
        private void GreateTableForAttr2_1()
        {
            int TableNum = 1;
            for (int i = 0; i < AttrTableCount; i++)
            {   
                if (AttrTable[i, vTableName] == "") continue;                                   
                
                if ((AttrTable[i, vNumPart]  == "1") &&
                    (AttrTable[i, vTableName] == AttrTable[i, vEntityTableMain]) &&
                    (AttrTable[i, vTableAlias] == ""))                    
                AttrTable[i, vTableAlias] = AttrTable[i, vEntityAlias];
                else
                {
                    if (AttrTable[i, vTableAlias] == "")
                    {                                             
                        //string LetterAlias = "A";
                        //S = SubQuery т.е. таблица была приджойнена вычисляемым атрибутом.
                        //если у нас не вложенный рекурсивный цикл, то PsevdonimAlias = ""
                        //if  (PsevdonimAlias == AttrTable[i, vEntityAlias]) LetterAlias = "S"; 
                        //AttrTable[i, vTableAlias] = LetterAlias + ParserData.PsevdonimSubQuery.ToString();                                              
                        //ParserData.PsevdonimSubQuery++;
                        SetAliasForTable(i);
                    }                                          
                    TableNum++;
                }                                                               
            }
        }
               
        ///Проставляем имя алиаса. Если результат true, то это новый алиас, 
        ///если false, то значит такая таблица уже есть.
        private bool SetAliasForTable(int Pos)
        {                       
            string AttrPartNoLast = AttrTable[Pos, vAttrPartNoLast];
            string Select         = AttrTable[Pos, vSelect];
            string EntityAlias    = AttrTable[Pos, vEntityAlias];          
            string TableName      = AttrTable[Pos, vTableName];
            string AttrFull       = AttrTable[Pos, vAttrFull];
            string AttrPartFull   = AttrTable[Pos, vAttrPartFull]; 
            
            //Сначала одинаковые атрибуты в пределах одного запроса.
            for (int i = 0; i < Pos; i++)
            {                                                     
                if (AttrTable[i, vTableName]   == "")            continue; 
                if (AttrTable[i, vSelect]       != Select)       continue;
                if (AttrTable[i, vEntityAlias]  != EntityAlias)  continue;
                if (AttrTable[i, vTableName]    != TableName)    continue;           
                if (AttrTable[i, vAttrFull]     != AttrFull)     continue;
                if (AttrTable[i, vAttrPartFull] != AttrPartFull) continue;                 
                AttrTable[Pos, vTableAliasReplace] = "REPLACE1:" + i + ";";
                AttrTable[Pos, vTableAlias] = AttrTable[i, vTableAlias];
                //AttrTable[Pos, vAttrSQL]    = AttrTable[i, vAttrSQL]; 
                //AttrTable[Pos, vJoinSQL]    = "";                
                return false;               
            }
            
            if (AttrTable[Pos, vAttrPart].ToUpper() == "КОЛИЧОБЪЕКТОВМАССИВА")
            {
                AttrTable[Pos, vTableAlias] = "A" + ParserData.PsevdonimSubQuery.ToString(); 
                ParserData.PsevdonimSubQuery++;
                return true;             
            }
      
            //Далее одинаковые таблицы в пределах одного зароса.
            for (int i = 0; i < Pos; i++)
            {                                                     
                //vAttrPartNoLast - Это тот же AttrPartFull , но без последнего атрибута (после точки).
                //Нужен чтобы исключить некоторые (повторяющиеся) таблицы из JOIN. AttrTable[i, vAttrFull]   AttrTable[i, vAttrPartFull]                                
                if (AttrTable[i, vTableName]   == "")          continue; 
                if (AttrTable[i, vSelect]      != Select)      continue;
                if (AttrTable[i, vEntityAlias] != EntityAlias) continue;
                if (AttrTable[i, vTableName]   != TableName)   continue;           

                //Эту строку не удалять!! Есть случаи когда это условие нужно. С этим нужно разобраться.
                //Если это таблица полученная в подзапросе, то оставляем её.                
                //if ((AttrTable[i, vAttrCode]   != "") && (AttrTable[Pos, vAttrType] != "Link")) continue;                                          
                //if (AttrTable[i, vAttrKind]   == "Calc") continue;                 
                if (AttrTable[Pos, vAttrKind] == "Calc") continue;
                
                //if ((AttrTable[i, vAttrPartNoLast] != AttrPartNoLast) && 
                //    (AttrTable[i, vAttrPartNoLast] != AttrTable[Pos, vAttrPartFull]) &&
                //    (AttrTable[i, vAttrPart] != "ДатаСостАтрибута") &&
                //    (AttrTable[i, vAttrPart] != "ИсторияАтрибута")) continue;
                                                                                                         
                AttrTable[Pos, vTableAliasReplace] = "REPLACE2:" + i + ";";
                AttrTable[Pos, vTableAlias] = AttrTable[i, vTableAlias];       
                return false;               
            }
            
            //Далее одинаковые таблицы в пределах разных запросов.
            //Если дошли до этого места, то значит у нас новая таблица, 
            //но нужно ещё проверить по таблице AttrTable верхнего уровня, 
            //если в данный момент мы находимся внутри рекурсивного цикла при парсинге вычисляемого атрибута.      
            if (AttrTablePrev != null) //Этого достаточно, если не null, то мы в вычисямом атрибуте.
            {
                for (int i = 0; i < AttrTablePrevCount; i++)   
                {                                                     
                    //vAttrPartNoLast - Это тот же AttrPartFull , но без последнего атрибута (после точки).
                    //Нужен чтобы исключить некоторые (повторяющиеся) таблицы из JOIN. AttrTable[i, vAttrFull]   AttrTable[i, vAttrPartFull]                                
                    if (AttrTablePrev[i, vTableName]   == "")          continue; 
                    //if (AttrTablePrev[i, vSelect]      != Select)      continue; //select всегда будет разный. 
                    if (AttrTablePrev[i, vEntityAlias] != EntityAlias) continue;  //Проверка на то что вычисляемый атрибут относится к тому же алиасу той же сущности.
                    if (AttrTablePrev[i, vTableName]   != TableName)   continue;  //Проверка на то что Если таблицы одинаковые         
                    if (AttrTable[Pos, vAttrKind] == "Calc") continue;
                    
                    //Если это таблица полученная в подзапросе, то оставляем её.                
                    if ((AttrTablePrev[i, vAttrCode]   != "") && (AttrTablePrev[Pos, vAttrType] != "Link")) continue; 
                                                                                                             
                    AttrTable[Pos, vTableAliasReplace] = "REPLACE3:" + i + ";";
                    AttrTable[Pos, vTableAlias] = AttrTablePrev[i, vTableAlias];       
                    return false;               
                }                                                              
            }
                       
            string LetterAlias = "A";
            //S = SubQuery т.е. таблица была приджойнена вычисляемым атрибутом.
            //если у нас не вложенный рекурсивный цикл, то PsevdonimAlias = ""
            if  (PsevdonimAlias == AttrTable[Pos, vEntityAlias]) LetterAlias = "S";            
            AttrTable[Pos, vTableAlias] = LetterAlias + ParserData.PsevdonimSubQuery.ToString();                      
            ParserData.PsevdonimSubQuery++;
            return true;
        }
        
        
        ///Проставляем значение полей JoinTableName, JionTableAlias, JoinTableField.
        private void GreateTableForAttr3()
        {           
            //JoinTableName - одначает что нужно таблицу в текущей строке
            //джойнить с JoinTableName.
            for (int i = 0; i < AttrTableCount; i++)
            {                                                        //AttrTable[i - 1, vTableFieldID]
                if (AttrTable[i, vTableName] == "") continue;        //AttrTable[i, vAttrPart]
                                                                 
                if (AttrTable[i, vNumPart] == "1")
                {                       
                    if ((AttrTable[i, vAttrKind] == "Calc") &&
                        (AttrTable[i, vAttrType] == "Link"))
                    {
                        //Если самая первая часть составного атрибута. То атрибут может относиться только к сущности из FROM.
                        AttrTable[i, vJoinTableName]    = AttrTable[i, vEntityTableMain];
                        AttrTable[i, vJoinTableAlias]   = AttrTable[i, vEntityAlias];
                        AttrTable[i, vJoinTableFieldID] = AttrTable[i, vEntityTableFieldID];
                    }
                    
                    if (AttrTable[i, vAttrKind].ParserInStr("Simple, System"))                        
                    {
                        //Если самая первая часть составного атрибута. То атрибут может относиться только к сущности из FROM.
                        AttrTable[i, vJoinTableName]    = AttrTable[i, vEntityTableMain];
                        AttrTable[i, vJoinTableAlias]   = AttrTable[i, vEntityAlias];
                        AttrTable[i, vJoinTableFieldID] = AttrTable[i, vEntityTableFieldID];
                    }
                    
                } else
                {                             
                    if (AttrTable[i, vAttrType] == "UniLink")                        
                    {
                        if ((AttrTable[i, vAttrPart].ToUpper() == "СОКРСУЩНОСТИ") ||
                            (AttrTable[i, vAttrPart].ToUpper() == "НАИМСУЩНОСТИ"))
                        {
                            AttrTable[i, vJoinTableName]    = AttrTable[i - 1, vJoinTableName];
                            AttrTable[i, vJoinTableAlias]   = AttrTable[i - 1, vJoinTableAlias];
                            AttrTable[i, vJoinTableFieldID] = AttrTable[i - 1, vTableField2];
                        }
                    } else
                    {
                        //Во всех остальных случаях, берем таблицу из предыдущей части составного атрибута.
                        AttrTable[i, vJoinTableName]    = AttrTable[i - 1, vTableName];
                        AttrTable[i, vJoinTableAlias]   = AttrTable[i - 1, vTableAlias];
                        AttrTable[i, vJoinTableFieldID] = AttrTable[i - 1, vTableField];                                             
                    }                  
                }
            
         
                //Это исключение. Если нужно НаимСущностиОбъекта или СокрСущностиОбъекта.                
                if ((AttrTable[i, vAttrPart].ToUpper() == "НАИМСУЩНОСТИОБЪЕКТА") || 
                    (AttrTable[i, vAttrPart].ToUpper() == "СОКРСУЩНОСТИОБЪЕКТА"))
                {
                    AttrTable[i, vJoinTableFieldID] = "EntityID";  
                }               
            }             
        }                                                 
                                        
        ///Для атрибута проставляем то что должно быть вместо него.
        private void GreateTableForAttr6()
        {                                     
            for (int i = 0; i < AttrTableCount; i++)
            {                                                                     
                //Если поле вычисляемое (неважно, обычная ссылка или вычисляемая ссылка), то:   
                bool DoCalc = false;
                if (AttrTable[i, vAttrKind] == "Calc") DoCalc = true;
                if ((AttrTable[i, vTableAliasReplace] != "") && (AttrTable[i, vAttrType] == "Link")) DoCalc = false;
                if (AttrTable[i, vAttrKind] == "Calc")        
                if (DoCalc) 
                {                                       
                    string Code          = AttrTable[i, vAttrCode];
                    string ResultSQL     = "";
                    string ResultJoinSQL = "";                                           
                    string PsevdonimAliasOUT       = "";
                    string PsevdonimEntityBriefOUT = "";
                    if (AttrTable[i, vNumPart] == "1")
                    {
                        PsevdonimAliasOUT       = AttrTable[i, vEntityAlias];
                        PsevdonimEntityBriefOUT = AttrTable[i, vEntity];
                    }  else
                    {
                        PsevdonimAliasOUT       = AttrTable[i, vTableAlias];
                        PsevdonimEntityBriefOUT = AttrTable[i - 1, vRef_EntityBrief]; 
                    }                                                        
                               
                    if ((PsevdonimAliasOUT == "") || (PsevdonimEntityBriefOUT == "")) continue;
                                                                                                                                                                         
                    //AttrTableCount - это кол-во строк в текущей таблице AttrTable, до добавления в неё таблицы, которая вернулась из вычисляемого атрибута.
                    //Это как бы сказать атрибуты текущего уровня, а AttrTableCountAll - это включая строки таблицы которая вернулась из вычисляемого атрибута.
                    //а AttrTableCountAll - это кобщее кол-во строк после добавления таблицы которая вернулась из вычисляемого атрибута.
                    if (AttrTableCountAll == 0) AttrTableCountAll = AttrTableCount;
                    var parserLocal = new Parser();
                    parserLocal.ParseLocal(Code,
                                           enterMode, 
                                           "", 
                                           PsevdonimAliasOUT, 
                                           PsevdonimEntityBriefOUT, 
                                           PsevdonimStateDate, 
                                           PsevdonimCountRecursion,
                                           AttrTable,          //Посылаем всю таблицу с атрибутами для того, чтобы внутри вычисляемого атрибута найти уже используемые таблицы и правильно выставить алиасы.
                                           AttrTableCountAll,  //И также посылаем общее количество строк этой таблицы.
                                           out ResultSQL,
                                           out ResultJoinSQL);
                                                                                                          
                    AttrTable[i, vSubSQL] = "(" + ResultSQL + ")";
                    AttrTable[i, vSubJoinSQL] = ResultJoinSQL;   
                                                                    
                    //Для того чтобы понять к какой строке относится таблица.
                    string PosSub = AttrTable[i, vNumSub] + ":" + AttrTable[i, vPos];                    
                    
                    for (int j = 0; j < parserLocal.AttrTableCount; j++)         
                        parserLocal.AttrTable[j, vPosSub] = PosSub;
                                       
                    ParserSys.ParserArrayAdd(parserLocal.AttrTable, AttrTable, 0);                   
                    AttrTableCountAll = AttrTableCountAll + parserLocal.AttrTableCount;                
                }                                                            
            }                
        }
        
        ///Для атрибута проставляем то что должно быть вместо него.
        ///Полностью оставляем для вычисляемых так как нужен vAttrSQL. 
        private void GreateTableForAttr6_1()
        {                                     
            for (int i = 0; i < AttrTableCount; i++)
            {                           
                //Если атрибут является последним в составном атрибуте.
                //Если это не последний атрибут в списке атрибутов, в котором есть ДатаСостАтрибута, то пропускаем.
                if (AttrTable[i, vLastPart] == "1") 
                {
                    //Для вычисляемых ссылок, обычных ссылок и простых атрибутов.
                    if ((AttrTable[i, vTableAlias] != "") && 
                        (AttrTable[i, vTableField] != ""))                       
                    AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + "." + AttrTable[i, vTableField];                                      
                    
                    //Если атрибут является универсальной ссылкой.
                    if (AttrTable[i, vAttrType] == "UniLink")
                    {
                        if (AttrTable[i, vAttrPart].ToUpper() == ParserData.KeyBrief.ObjectID) 
                            AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + "." + AttrTable[i, vTableField];
                        else if (AttrTable[i, vAttrPart].ToUpper() == ParserData.KeyBrief.EntityID)                                
                            AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + "." + AttrTable[i, vTableField2];  
                        else if (AttrTable[i, vAttrPart].ToUpper() == ParserData.KeyBrief.EntityBrief)                             
                            AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + ".Brief";                           
                        else if (AttrTable[i, vAttrPart].ToUpper() == ParserData.KeyBrief.EntityName)                              
                            AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + ".Name";                           
                        //else if (AttrTable[i, vAttrPart].ToUpper() == "ДАТАСОСТАТРИБУТА")
                        //    AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + ".StateDate";
                        else AttrTable[i, vAttrSQL] = "";
                    }                   
                                                          
                    //Если атрибут является массивом.
                    if (AttrTable[i, vAttrType] == "Array")
                    {
                        AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + "." + AttrTable[i, vTableFieldID];
                    }                   
                    
                    //Если атрибут вычисляемый, то вставляем код, который распарсили.
                    if ((AttrTable[i, vAttrKind] == "Calc") && (AttrTable[i, vAttrType] == "Field"))
                    {
                        AttrTable[i, vAttrSQL] = AttrTable[i, vSubSQL];
                    }
                    
                    //Если не распарсили, то вставляем что есть.
                    if (AttrTable[i, vAttrSQL] == "") AttrTable[i, vAttrSQL] = AttrTable[i, vAttrFull];
                    
                    //Если атрибут равен ДатаСостОбъекта
                    if (AttrTable[i, vAttrSQL] == "ObjectStateDate") AttrTable[i, vAttrSQL] = AttrTable[i, vStateDate];                                          
                    
                    //Если атрибут равен НаимОбъекта, то вставляем это: dbo.eo_ObjectName(EOT_11.EntityID, EOT_11.FaceID) "FIO".    
                    if (AttrTable[i, vAttrPart] == "ObjectName") AttrTable[i, vAttrSQL] = "dbo.eo_ObjectName(" + AttrTable[i, vTableAlias] + ".EntityID, " + AttrTable[i, vTableAlias] + "." + AttrTable[i, vTableFieldID] + ")";
                    
                    //Если атрибут равен ИсторияАтрибута
                    //if (AttrTable[i, vAttrSQL].ToUpper() == "ИСТОРИЯАТРИБУТА") AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + "." + AttrTable[i, vTableField];
                
                    //Если атрибут не найден, то у него не заполнен vAttrType и vAttrKind и vAttrTable и др.
                    //В этом случае пишет то что есть. 
                    if (AttrTable[i, vAttrType] == "") 
                    {
                        if (AttrTable[i, vTableAlias] != "") AttrTable[i, vAttrSQL] = AttrTable[i, vTableAlias] + "." + AttrTable[i, vAttrFull];                         
                    }
                }
            }
        }        
      
        //Составляем JOIN-ы.
        private void GreateTableForAttr7()
        {                                                 
            //Это делаем только для запроса первого уровня.
            //if (PsevdonimCountRecursion != "1") continue;           
            //if (ParserData.TestON == 1) sys.ArrayView("AttrTable", "Value", AttrTable);
            
            //AttrTableCountAll - здесь количество строк AttrTable со всеми вычисляемыми атрибутами.
            for (int i = 0; i < AttrTableCount; i++)
            {                                                                         
                if (AttrTable[i, vTableName] == "") continue;              
                
                //Если в этой строке был подменён алиас, то пропускаем.
                if (AttrTable[i, vTableAliasReplace] != "") continue;  
                                
                string Join1 = AttrTable[i, vTableAlias]     + "." + AttrTable[i, vTableFieldID];
                string Join2 = AttrTable[i, vJoinTableAlias] + "." + AttrTable[i, vJoinTableFieldID];
                string Join3 = AttrTable[i, vTableAlias]     + "." + AttrTable[i, vTableField];
                
                //Если Атрибут - универсальная ссылка.
                if (AttrTable[i, vAttrType] == "UniLink")
                {
                    if ((AttrTable[i, vAttrPart].ToUpper() == "СОКРСУЩНОСТИ") ||
                        (AttrTable[i, vAttrPart].ToUpper() == "НАИМСУЩНОСТИ"))
                        AttrTable[i, vJoinSQL] = "LEFT OUTER JOIN /*test1*/ " + AttrTable[i, vTableName] + " " + AttrTable[i, vTableAlias] +
                            " ON " + AttrTable[i, vTableAlias] + "." + AttrTable[i, vTableField] + " = " + AttrTable[i, vJoinTableAlias] + "." + AttrTable[i, vJoinTableFieldID] + " "; // + ParserSys.CR;                                                                          
                    continue;
                }
                                               
                //Если Атрибут - вычисляемая ссылка.
                if ((AttrTable[i, vAttrKind] == "Calc") &&
                    (AttrTable[i, vAttrType] == "Link"))
                {                                   
                    AttrTable[i, vJoinSQL] = "LEFT OUTER JOIN /*test2*/ " + AttrTable[i, vTableName] + " " + AttrTable[i, vTableAlias] + 
                        " ON " + Join1 + " = " + AttrTable[i, vSubSQL] + " ";                                   
                    continue;
                }
                    
                //Если Атрибут - историчная таблица.
                if (AttrTable[i, vTableType] == "Hist")
                {    
                    if (((i + 1) < AttrTableCount) && (AttrTable[i + 1, vAttrPart] == "ИсторияАтрибута"))
                    {
                        AttrTable[i, vJoinSQL] = "LEFT OUTER JOIN /*test4*/ " + AttrTable[i, vTableName] + " " + AttrTable[i, vTableAlias] + 
                            " ON (" + Join1 + " = " + Join2 + ") ";                        
                    }
                    else
                    {
                        AttrTable[i, vJoinSQL] = "LEFT OUTER JOIN /*test3*/ " + AttrTable[i, vTableName] + " " + AttrTable[i, vTableAlias] + 
                            " ON (" + Join1 + " = " + Join2 + ") AND (" + AttrTable[i, vTableAlias] + ".StateDate = (SELECT MAX(StateDate) FROM " + AttrTable[i, vTableName] + " WHERE (StateDate <= " + AttrTable[i, vStateDate] + ") AND (" + AttrTable[i, vJoinTableAlias] + "." + AttrTable[i, vJoinTableFieldID] + " = " + AttrTable[i, vTableFieldID] + "))) ";// + ParserSys.CR;                                         
                    }
                    continue;
                }
                
                //Если Атрибут - КОЛИЧОБЪЕКТОВМАССИВА.
                if ((AttrTable[i, vAttrType] == "Array") && (AttrTable[i, vAttrPart].ToUpper() == "КОЛИЧОБЪЕКТОВМАССИВА"))
                {
                    //Left Outer Join (Select EOT_11.ContractID F, Count(*) N 
                    //From RelContFace EOT_11 Group By EOT_11.ContractID) EOT_10 On EOT_10.F = EOT_1.CID
                    AttrTable[i, vJoinSQL] = "LEFT OUTER JOIN /*test7*/ (SELECT A." + AttrTable[i, vTableField] + " F, COUNT(*) N FROM " + AttrTable[i, vTableName] + " A GROUP BY A." + AttrTable[i, vTableField] + ") " + AttrTable[i, vTableAlias] +
                        " ON " + AttrTable[i, vTableAlias] + ".F = " + Join2 + " ";                                       
                    continue;                    
                }
                
                //Если Атрибут - массив.
                if ((AttrTable[i, vAttrType] == "Array") && (AttrTable[i + 1, vAttrPart].ToUpper() != "КОЛИЧОБЪЕКТОВМАССИВА"))
                {
                    AttrTable[i, vJoinSQL] = "LEFT OUTER JOIN /*test5*/ " + AttrTable[i, vTableName] + " " + AttrTable[i, vTableAlias] + 
                        " ON " + Join3 + " = " + Join2 + " ";// + ParserSys.CR;                                        
                    continue;                    
                }
                   
                //Во всех остальных случаях.
                if (AttrTable[i, vJoinTableAlias] != "")    
                if (AttrTable[i, vTableAlias] != AttrTable[i, vJoinTableAlias])    
                {
                    //Если таблицы разные, то джойним:
                    AttrTable[i, vJoinSQL] = "LEFT OUTER JOIN /*test6*/ " + AttrTable[i, vTableName] + " " + AttrTable[i, vTableAlias] + 
                        " ON " + Join1 + " = " + Join2 + " " + AttrTable[i, vJoinSQL] + " ";                               
                }
                
                if (AttrTable[i, vSubJoinSQL] != "")
                {
                    ParserSys.ParserAddRightCR(ref AttrTable[i, vJoinSQL]);
                    AttrTable[i, vJoinSQL] = AttrTable[i, vJoinSQL] + AttrTable[i, vSubJoinSQL];
                }                   
            }           
        }
            
        private string GetValueStateDate(string SelectStr, string EntityAliasStr, string EntityBriefStr)
        {
             for (int i = 0; i < StateDateCount; i++) 
             {
                 if (ListStateDate[i, dSelect]      != SelectStr)      continue;
                 if (ListStateDate[i, dEntityBrief] != EntityBriefStr) continue;
                 if (ListStateDate[i, dEntityAlias] != EntityAliasStr) continue;
                 return ListStateDate[i, dStateDateCode];
             }
             return "";
        }
        
        ///Проставляем дату состояния для каждой таблицы в AttrTable.        
        private string ReadySQLReplaceStateDate(string ReadySQL)
        {        
            for (int i = 0; i < StateDateCount; i++)
            {
                int StateDateBeg = ListStateDate[i, dStateDateBeg].ParserToInt();
                int StateDateEnd = ListStateDate[i, dStateDateEnd].ParserToInt();
                string StateDateCode = "";
                                               
                for (int j = StateDateBeg; j < (StateDateEnd + 1); j++)
                {               
                    if (Words[j, wReadySQL] == "") continue;
                    //if ((Words[j, wStateDate] == "1") || (Words[j, wStateDate] == "2")) continue;
                    StateDateCode = StateDateCode + Words[j, wReadySQL] + GetDOCR(Words[j, wDOCR]);       
                }                               
                ListStateDate[i, dStateDateCode] = StateDateCode;
            }
            
            for (int i = 0; i < AttrTableCount; i++)   //AttTableStateDate
            {
                string StrForReplace = "AttTableStateDate" + i.ToString("D3");                
                int ExI = ReadySQL.ParserIndexOfEx(StrForReplace);
                if (ExI == -1) continue;
                string StrRepl = GetValueStateDate(AttrTable[i, vSelect], AttrTable[i, vEntityAlias], AttrTable[i, vEntity]);
                if (StrRepl == "") StrRepl = LocalDate;
                ReadySQL = ReadySQL.Replace(StrForReplace, StrRepl);
            }         
            return ReadySQL;                  
        }
        
        ///Получить весь SQL код JOIN-ов, для запроса с номером Select.
        private string GetSQLForEntityFromTableAttr(string Select, string Entity, string EntityAlias)
        {
            string ResultSQL = "";
            for (int i = 0; i < AttrTableCount; i++)        
            {
                if (AttrTable[i, vJoinSQL]     == "")          continue;
                if (AttrTable[i, vSelect]      != Select)      continue;    //!!!!!!!
                if (AttrTable[i, vEntity]      != Entity)      continue;
                if (AttrTable[i, vEntityAlias] != EntityAlias) continue;                                                         
                ParserSys.ParserAddRightCR(ref ResultSQL);
                ResultSQL = ResultSQL + AttrTable[i, vJoinSQL];
                
                //Если добавили текст джойна к сущности, то дальше в запрос верхнего уровне (если мы находимся в вычисляемом) джойн не передаем.
                if (AttrTable[i, vSelect] != Select) AttrTable[i, vJoinSQL] = ""; 
            }           
            return ResultSQL;
        }
        
        ///Получить SQL код для атрибута.
        private string GetSQLForAttrFromTableAttr(string Num) //, string BlockWhere, string BlockFunc)
        {           
            for (int i = 0; i < AttrTableCount; i++) 
            {
                if (AttrTable[i, vNum]    != Num) continue;
                
                //Продолжаем если это не конец атрибута.
                if ((i < (AttrTableCount-1)) && (AttrTable[i, vAttrSQL] == "") && (AttrTable[i + 1, vNum] == Num)) continue;                                                                             
                return AttrTable[i, vAttrSQL];
            }
            return "";
        }
        
        ///Корректировака формата даты.
        private void CorrectFormatDate()
        {          
            for (int i = 2; i < WordsCount; i++)
            {
                bool FindDate = false;         
                bool ResultConvert;
                if ((Words[i - 2, wReadySQL].ParserIndexOfBool("Date")) || (Words[i - 2, wLex].ParserIndexOfBool("Дата"))) FindDate = true;                               
                if (!FindDate) continue;
                SetwProc(i, "DATECOR");
                Words[i, wReadySQL] = Words[i, wReadySQL].ParserConvertDate4Server10(true, false, out ResultConvert);
            }
        }
        
        ///Проставить весь код SQL для атрибутов и блока FROM в таблице Words в колонке wReadySQL.
        private void SetSQLCode()
        {                                                     
            //Устанавливаем переносы строк.
            SetDOCR();
            
            for (int i = 0; i < WordsCount; i++)
            {
                if (Words[i, wReadySQL] != "") continue;                   
                if (Words[i, wLexType] == "NOTUSE")  continue;
                                  
                //Перенос лексем в готовый SQL запрос.
                Words[i, wReadySQL] = Words[i, wLex];
                                 
                //Если лексема = атрибут.                                Words[i, wLex]
                if (Words[i, wLexType] == "ATTR")
                {
                    string Attr = GetSQLForAttrFromTableAttr(Words[i, wPos]);//, Words[i, wBlockWhere], Words[i, wBlockFunc]);
                    if (Attr != "") Words[i, wReadySQL] = Attr;                 
                }
                
                //Если лексема = сущность.
                if (Words[i, wLexType] == "ENTITY")
                {
                    string JoinSQLtext = GetSQLForEntityFromTableAttr(Words[i, wSelect], Words[i, wEntity], Words[i, wEntityAlias]);
                    if (Words[i, wEntityAlias] != "")  Words[i, wEntityAlias] = " AS " + Words[i, wEntityAlias];
                    Words[i, wReadySQL] = Words[i, wTableName] + Words[i, wEntityAlias] + ParserSys.CR + JoinSQLtext + GetDOCR(Words[i, wDOCR]);                 
                }
               
                if ((Words[i, wAlias] != "") && (Words[i, wLexType] != "ENTITY"))
                    Words[i, wReadySQL] = Words[i, wReadySQL] + " AS " + Words[i, wAlias];             
            }
                                 
            //Корректировака формата даты.
            CorrectFormatDate();           
                       
            //Что вместо атрибута.
            string ResultSQL = "";                      
            for (int i = 0; i < WordsCount; i++)
            {               
                if (Words[i, wReadySQL] == "") continue;
                if ((Words[i, wStateDate] == "1") || (Words[i, wStateDate] == "2")) continue;
                ResultSQL = ResultSQL + Words[i, wReadySQL] + GetDOCR(Words[i, wDOCR]);//ParserSys.CR;               
            } 

            ResultSQL = ReadySQLReplaceStateDate(ResultSQL);
            
            this.SQL = ResultSQL; //sys.SM("SQL=" + ResultSQL);
            
            //Что джойним.
            string ResultJoinSQL = "";
            for (int i = 0; i < AttrTableCount; i++) 
            {                 
                if (PsevdonimAlias == AttrTable[i, vEntityAlias])       
                    ResultJoinSQL = ResultJoinSQL + AttrTable[i, vJoinSQL];               
            }           
            this.JoinSQL = ResultJoinSQL; //sys.SM("JoinSQL=" + ResultJoinSQL);
            
            ParserData.TestDeep++;           
            if (ParserData.TestDeep > 1) ShowSubQuery(MSQL);                                         
        }            
    }
     
}

