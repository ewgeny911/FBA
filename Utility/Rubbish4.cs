
﻿/*
=========================================================================
//Возвращает число, сответсвующее 1 секунде
//МО 23.07.2002
function Second : double;
begin
  Result := 1.0/86400.0;
end;
//==============================================================================
//Возвращает по дате Dt дату-время - последнюю секунду дня.
//Пример Вход {01/01/2002} Выход {01/01/2002 23:59:59}
//МО 23.07.2002
function EndOfDayDate(Dt: TDateTime) : TDateTime;
var
  tmpDt : TDateTime;
begin
  Result := Trunc(Dt) + 1 - Second;
end;  
  
// ============================================================================= Слово "месяц" с правильным окончанием
function MonthCorrectEnding(Value : Float) : String;
var
  S : String;
begin
  Result := 'месяц';
  S := DaysCorrectEnding(Value);
  if S = 'дней' then
    Result := 'месяцев'
  else if S = 'день' then
    Result := 'месяц'
  else if S = 'дня' then
    Result := 'месяца';
end;
// ============================================================================= Слово "человек" с правильным окончанием
function MansCorrectEnding(Value : Float) : String;
var
  S : String;
begin
  Result := 'человек';
  S := DaysCorrectEnding(Value);
  if S = 'дней' then
    Result := 'человек'
  else if S = 'день' then
    Result := 'человек'
  else if S = 'дня' then
    Result := 'человека';
end;
// ============================================================================= Слово "человек" с правильным окончанием (вариант 2)
function MansCorrectEnding2(Value : Float) : String;
var
  S : String;
begin
  Result := 'человек';
  S := DaysCorrectEnding(Value);
  if S = 'дней' then
    Result := 'человек'
  else if S = 'день' then
    Result := 'человека'
  else if S = 'дня' then
    Result := 'человек';
end;
// ============================================================================= Слово "рубль" с правильным окончанием
function RublesCorrectEnding(Value : Float) : String;
var
  S : String;
begin
  Result := 'рублей';
  S := DaysCorrectEnding(Value);
  if S = 'дней' then
    Result := 'рублей'
  else if S = 'день' then
    Result := 'рубль'
  else if S = 'дня' then
    Result := 'рубля';
end;
// ============================================================================= Слово "копейка" с правильным окончанием
function CopeeksCorrectEnding(Value : Float) : String;
var
  S : String;
begin
  Result := 'копеек';
  S := DaysCorrectEnding(Value);
  if S = 'дней' then
    Result := 'копеек'
  else if S = 'день' then
    Result := 'копейка'
  else if S = 'дня' then
    Result := 'копейки';
end;
{  Колесниченко И.В.   02.02.2012}
// ============================================================================= Слово "рубль" с правильным окончанием в родительном падеже
function RublesCorrectEndingGenitiv(Value : Float) : String;
var
  S : String;
  LastNum, PrelastNum : Integer;
  Num : Integer;
begin
  S := IntToStr(Trunc(Value));
  LastNum := StrToInt(Copy(S, Length(S), 1));
  PreLastNum := 0;
  if Length(S) >= 2 then
    PreLastNum := StrToInt( Copy(S, Length(S)-1, 1) );
  if (LastNum = 1) and (PreLastNum <> 1) then // пример: 1 день, 21 день, 1961 день
    Result := 'рубля'
  else Result := 'рублей';
end;
// ============================================================================= Слово "копейка" с правильным окончанием в родительном падеже
function CopeeksCorrectEndingGenitiv(Value : Float) : String;
var
  S : String;
  LastNum, PrelastNum : Integer;
  Num : Integer;
begin
  S := IntToStr(Trunc(Value));
  LastNum := StrToInt(Copy(S, Length(S), 1));
  PreLastNum := 0;
  if Length(S) >= 2 then
    PreLastNum := StrToInt( Copy(S, Length(S)-1, 1) );
  if (LastNum = 1) and (PreLastNum <> 1) then // пример: 1 день, 21 день, 1961 день
    Result := 'копейки'
  else Result := 'копеек';
end;
//***********************************************************
// ============================================================================= Слово "раз" с правильным окончанием
function TimesCorrectEnding(Value : Float) : String;
var
  S : String;
begin
  Result := 'раз';
  S := DaysCorrectEnding(Value);
  if S = 'дней' then
    Result := 'раз'
  else if S = 'день' then
    Result := 'раз'
  else if S = 'дня' then
    Result := 'раза';
end;
// ============================================================================= Слово "сообщение" с правильным окончанием
function MessageCorrectEnding(Value : Float) : String;
var
  S : String;
begin
  Result := 'сообщений';
  S := DaysCorrectEnding(Value);
  if S = 'дней' then
    Result := 'сообщений'
  else if S = 'день' then
    Result := 'сообщение'
  else if S = 'дня' then
    Result := 'сообщения';
end;
  
//==============================================================================
// Функция добавляет к строке ValueStr слева или справа символ Symbol
// Травин Е.В. 09.07.2014
// Пример использования:
//==============================================================================
function SetNewLength(ValueStr: string; Symbol: Char; NewLength: integer; Left: boolean = True): string;
var
  i, L: integer;
begin
  L := Length(ValueStr);
  if Left     then for i := 1 to (NewLength - L) do  ValueStr := Symbol + ValueStr;
  if not Left then for i := 1 to (NewLength - L) do  ValueStr := ValueStr + Symbol;
  Result := ValueStr;
end;
//==============================================================================
// Функция вовращает кусок строки ограниченый подстроками
// Травин Е.В. 31.07.2013
//==============================================================================
function StringBetweenString(TextSource, TextBegin, TextEnd: string; IgnoreCase: boolean): string;
var
  L, p1, p2:integer;
begin
  Result := '';
  if IgnoreCase then
  begin
    TextSource := AnsiLowerCase(TextSource);
    TextBegin  := AnsiLowerCase(TextBegin);
    TextEnd    := AnsiLowerCase(TextEnd);
  end;
  p1 := Pos(TextBegin, TextSource);
  if p1 = 0 then exit;
  p2 := Pos(TextEnd, TextSource);
  if p2 = 0 then exit;
  L := Length(TextBegin);
  if p1 < p2 then Result := Copy(TextSource, p1 + L, p2 - p1 - L) else Result := '';
end;
//==============================================================================
// Функция вовращает кусок строки ограниченый подстроками
// Травин Е.В. 31.07.2013
//Отличие от первой процедуры в том что если TextBegin не указан, то считает первый символ,
// если не указанао TextEnd - то считается до конца строки.
//==============================================================================
function StringBetweenString2(TextSource, TextBegin, TextEnd: string; IgnoreCase: boolean): string;
var
  L, p1, p2:integer;
begin
  Result := '';
  if IgnoreCase then
  begin
    TextSource := AnsiLowerCase(TextSource);
    TextBegin  := AnsiLowerCase(TextBegin);
    TextEnd    := AnsiLowerCase(TextEnd);
  end;
  p1 := Pos(TextBegin, TextSource);
  if p1 = 0 then p1 := 1;
  p2 := Pos(TextEnd, TextSource);
  if p2 = 0 then p2 := 10000; //Length(TextSource) + 1;
  L := Length(TextBegin);
  if p1 < p2 then Result := Copy(TextSource, p1 + L, p2 - p1 - L) else Result := '';
end;
//==============================================================================
// Функция вовращает кусок строки ограниченый подстроками
// Последнее вхождение текста TextBegin и первое TextEnd.
// Пример StringBetweenString3('270211-МП-011-06-2395860 от 05.12.2016', '-', 'от') = "2395860 "
//==============================================================================
function StringBetweenString3(TextSource, TextBegin, TextEnd: string): string;
var
  p1:integer;
  s1: string;
begin
  p1 := Pos(TextEnd, TextSource);
  s1 := Copy(TextSource, 1, p1-1);
  s1 := ReverseString(s1);
  p1 := Pos(TextBegin, s1);
  s1 := LeftStr(s1, p1-1);
  Result := ReverseString(s1);
end;  
//==============================================================================
// Травин Е.В. 31.05.2013
// Разделение строки на отдельные блоки: 01.04.343.55
// Пример использвания:
// StringList1 := MKBCodeLine('01.04.343.55', '.');
// Результат:
// 01
// 01.04
// 01.04.343
// 01.04.343.55
//==============================================================================
function MKBCodeLine(SourceString, Comma: string): TStringList;
var
  List: TStringList;
  s: string;
  p: integer;
begin
  List := TStringList.Create;
  p := Pos(Comma, SourceString);
  s := '';
  while p > 0 do
  begin
    s := s + Copy(SourceString, 1, p - 1);
    SourceString := Copy(SourceString, p + 1, 10000000);
    List.Add(s);
    s := s + Comma;
    p := Pos(Comma, SourceString);
  end;
  List.Add(s + SourceString);
  Result := List;
end;
//------------------------------------------------------------------------------
// 31.01.2003, Автор: Пантелеев Н.
// Функция заменяет все вхождения подстроки
// 26.02.2015, Автор: Букрин А. С.
// Теперь удаляемая строка может содержаться в той которой заменяем
// (не вызывает зацикливания)
//------------------------------------------------------------------------------
Function StrReplaceStr(pStr: String; RemoveStr, ReplaceStr: String): String;
Var
  rPos, LastPos, Delta : Integer;
  fl : boolean;
Begin
  fl := true;
  Delta := Length(ReplaceStr)-Length(RemoveStr);
  rPos := Pos(RemoveStr, pStr);
  LastPos := 0;
  While (rPos > 0) and ((LastPos < rPos-Delta) or fl = true) Do
  Begin
    Delete(pStr, rPos, Length(RemoveStr));
    Insert(ReplaceStr, pStr, rPos);
    LastPos := rPos;
    rPos := Pos(RemoveStr, RightStr(pStr, Length(pStr)-LastPos-Delta))+ LastPos+Delta;
    fl := false;
  End;
  Result := pStr;
End;
     
//=============================================================
// 11.04.2002, Автор: Кривцов С.
// Функция формирует строку ФИО в родительном падеже
// из параметров aSurname, aName, aPatronymic, которые
// представляют собой Фамилию, Имя и Отчество (соответственно),
// заданные в именительном падеже
// КОГО:
//=============================================================
function GenitiveCase(aSurname, aName, aPatronymic: string): string;
var
  bMaleSex: Boolean;
  sSurname, sName, sPatronymic: string;
  s: string;
begin
  Result := '';
  s := aSurname + ' ' + aName + ' ' + aPatronymic;
  if s = 'Директор по развитию' then Result := 'Директора по развитию';
  if s = 'Заместитель генерального директора' then Result := 'Заместителя генерального директора';
  if s = 'Начальник операционного управления Департамента по работе с персоналом' then Result := 'Начальника операционного управления Департамента по работе с персоналом';
  if Result <> '' then exit;
  try
    sSurname := AnsiUpperCase(Trim(aSurname));
    sName := AnsiUpperCase(Trim(aName));
    sPatronymic := AnsiUpperCase(Trim(aPatronymic));
    if sPatronymic <> '' then
      bMaleSex := sPatronymic[Length(sPatronymic)] = 'Ч'
    else
      bMaleSex := true;
  //   Фамилия
    if Length(sSurname) > 0 then
    begin
      if bMaleSex then
        Case sSurname[Length(sSurname)] of
          'О', 'И', 'Я', 'А': Result := sSurname;
          'Й': Result := LeftStr(sSurname, Length(sSurname) - 2) + 'ОГО';
          else Result := sSurname + 'А';
        end
      else
        case sSurname[Length(sSurname)] of
          'О', 'И', 'Б', 'В', 'Г', 'Д', 'Ж', 'З',
          'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т',
          'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь': Result := sSurname;
          'Я': Result := LeftStr(sSurname, Length(sSurname) - 2) + 'ОЙ';
          else Result := LeftStr(sSurname, Length(sSurname) - 1) + 'ОЙ';
        end;
      Result := Result + ' ';
    end;
  //   Имя
    if Length(sName) > 0 then
    begin
      if bMaleSex then
        case sName[Length(sName)] of
          'Й', 'Ь': Result := Result + LeftStr(sName, Length(sName) - 1) + 'Я';
          else Result := Result + sName + 'А';
        end
      else
        case sName[Length(sName)] of
          'А': case sName[Length(sName) - 1] of
                 'И', 'Г': Result := Result + LeftStr(sName, Length(sName) - 1) + 'И';
                 else Result := Result + LeftStr(sName, Length(sName) - 1) + 'Ы';
               end;
          'Я': if sName[Length(sName) - 1] = 'И' then
                 Result := Result + LeftStr(sName, Length(sName) - 1) + 'И'
               else
                 Result := Result + LeftStr(sName, Length(sName) - 1) + 'И';
          'Ь': Result := Result + LeftStr(sName, Length(sName) - 1) + 'И';
          else Result := Result + sName;
        end; //of case
      Result := Result + ' ';
    end;
  //   Отчество
    if Length(sPatronymic) > 0 then
      if bMaleSex then Result := Result + sPatronymic + 'А'
      else             Result := Result + LeftStr(sPatronymic, Length(sPatronymic) - 1) + 'Ы';
  except
  end;
  Result := NameCase(Result);
end;
//=============================================================
// 11.04.2002, Автор: Кривцов С.
// Функция формирует строку ФИО в дательном падеже
// из параметров aSurname, aName, aPatronymic, которые
// представляют собой Фамилию, Имя и Отчество (соответственно),
// заданные в именительном падеже
// КОМУ:
//=============================================================
function DativeCase(aSurname,aName, aPatronymic: string): string;
var
  bMaleSex: boolean;
  a: char;
  sSurname, sName, sPatronymic: string;
  s: string;
begin
  Result := '';
  s := aSurname + ' ' + aName + ' ' + aPatronymic;
  if s = 'Директор по развитию' then Result := 'Директору по развитию';
  if s = 'Заместитель генерального директора' then Result := 'Заместителю генерального директора';
  if s = 'Начальник операционного управления Департамента по работе с персоналом' then Result := 'Начальнику операционного управления Департамента по работе с персоналом';
  if Result <> '' then exit;
  try
    sSurname := AnsiUpperCase(Trim(aSurname));
    sName := AnsiUpperCase(Trim(aName));
    sPatronymic := AnsiUpperCase(Trim(aPatronymic));
    if sPatronymic <> '' then
      bMaleSex := sPatronymic[Length(sPatronymic)] = 'Ч'
    else
      bMaleSex := true;
  //   Фамилия
    if Length(sSurname) > 0 then
    begin
      if bMaleSex then
        case sSurname[Length(sSurname)] of
          'О', 'И', 'Я', 'А': Result := sSurname;
          'Й': Result := LeftStr(sSurname, Length(sSurname) - 2) + 'ОМУ';
          else Result := sSurname + 'У';
        end
      else
        Case sSurname[Length(sSurname)] of
          'О', 'И', 'Б', 'В', 'Г', 'Д', 'Ж','З',
          'К', 'Л', 'М', 'Н', 'П', 'Р', 'С',
          'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь': Result := sSurname;
          'Я': Result := LeftStr(sSurname, Length(sSurname) - 2) + 'ОЙ';
          else Result := LeftStr(sSurname, Length(sSurname) - 1) + 'ОЙ';
        end;
      Result := Result + ' ';
    end;
  //   Имя
    if Length(sName) > 0 then
    begin
      if bMaleSex then
        case sName[Length(sName)] of
          'Й', 'Ь': Result := Result + LeftStr(sName, Length(sName) - 1) + 'Ю';
          else Result := Result + sName + 'У';
        end
      else
        case sName[Length(sName)] of
          'А', 'Я': if Copy(sName, Length(sName) - 1, 1) = 'И' then
                      Result := Result + LeftStr(sName, Length(sName) - 1) + 'И'
                    else Result := Result + LeftStr(sName, Length(sName) - 1) + 'Е';
          'Ь': Result := Result + LeftStr(sName, Length(sName) - 1) + 'И';
          else Result := Result + sName;
        end;
      Result := Result + ' ';
    end;
  //   Отчество
    if Length(sPatronymic) > 0 then
      if bMaleSex then Result := Result + sPatronymic + 'У'
      else             Result := Result + LeftStr(sPatronymic, Length(sPatronymic) - 1) + 'Е';
  except
  end;
  Result := NameCase(Result);
end;
//=============================================================
// 20.03.2002, Автор: Сергеев Д.
// Функция выводит строку с лидирующей заглавной буквой
//=============================================================
function AnsiUpperCaseFirst(vSource: string): string;
var
  s: string;
begin
  s := AnsiLowerCase(vSource);
  if ( length(s) > 1 ) then Result := AnsiUpperCase(copy(s, 1, 1)) + copy(s, 2, length(s) - 1)
  else                      Result := AnsiUpperCase(s);
end;
function ExtractFIOPart(const AFIOStr: string; APart: Integer);
var
  StrList: TStrings;
begin
  if APart > 0 then
  begin
    StrList := TStringList.Create;
    try
      StrList.CommaText := AFIOStr;
      if APart <= StrList.Count then
        Result := StrList[APart - 1]
      else
        Result := '';
    finally
      StrList.Free;
    end;
  end
  else
    Result := AFIOStr;
end;
 
 
//==============================================================================
// Функция возвращает список строк заключенных в скобки.
// Букрин А.С. 06.04.2016
// StrUtilsSu.StringsBetweenBkt('select (select ( aaaa ) bbbbbbb ) where 1 = 2');
// Будет возвращено:
// aaaa
// select bbbbbbb
// select where 1 = 2
// Если второй параметр false, то результат будет таким:
// aaaa
// select ( aaaa ) bbbbbbb
// select (select ( aaaa ) bbbbbbb ) where 1 = 2
//==============================================================================
function StringsBetweenBkt(s: string, WithoutContains : boolean = true): TStringList;
var
  s2 : string;
  p1, p2, p3, p4, bkcount, i : integer;
  List, List2 : TStringList;
begin
  List := TStringList.Create;
  p1 := 0;
  if Pos('(', s) = 0 then
  begin
    List.Add(s);
    Result := List;
    exit;
  end;
  while PosEx('(', s, p1) > 0 do
  begin
    p1 := PosEx('(', s, p1);
    p2 := PosEx(')', s, p1);
    p3 := p1;
    bkcount := 0;
    while (PosEx('(', s, p3) > 0) and (PosEx('(', s, p3) < p2) do // Подсчитываем количество открывающих скобок от текущей до первой закрывающей
    begin
      Inc(bkcount);
      p3 := PosEx('(', s, p3);
    end;
    p3 := p2;
    while (bkcount > 0) and (bkcount < 1000) do // Ищем закрывающую скобку соответствующую текущей открывающей
    begin
      p4 := p3;
      p3 := PosEx(')', s, p3);
      while (PosEx('(', s, p4) > 0) and (PosEx(')', s, p4) < p3) do
      begin
        p4 := PosEx('(', s, p4);
        Inc(bkcount);
      end;
      bkcount := bkcount - 1;
    end;
    s2 := Copy(s, p1+1, p3-p1-1);
    List2 := StringsBetweenBkt(s2, WithoutContains);
    for i := 0 to List2.Count - 1 do
    begin
      List.Add(List2.Strings[i]);
    end;
    if WithoutContains = true then
      delete(s, p1, p3-p1+1);
    Inc(p1);
  end;
  List.Add(s);
  Result := List;
end;
  
 
//==============================================================================
// Процедура Select1 отсылает одну таблицу на сервере, выполняет запрос и возвращает результат.
// DataSetIN  - Таблица которую необходимо загрузить на сервер
// TableName  - Имя таблицы на сервере куда будут сохраняться данные из DataSetIN.
// TableName должно начинаться с #, т.е. таблица должна быть временной, иначе при
// многопользовательской работе возможно неправильная работа функции.
// Query      - Произвольный SQL запрос
// DataSetOUT - Таблица в которой возвращается результат
// DataSetIN и DataSetOUT могут совпадать.
// Пример вызова: Select1(mtDescIN1, '#A1_Table18','select Code1 from #A1_Table18', mtDescOUT);
// При вызове Query всегда должен содержать в конце какой либо Select, например Select 1. либо можно вместо MemTableOUT указать nil.
// Автор: Травин Е.В.
// Дата: 05.05.2012
//==============================================================================
procedure Select1(DataSetIN1: TDataSet; TableName1, Query: string; MemTableOUT: TmcMemTable; AddSelect: boolean = True);
var
  eSP: TencStoredProc;
  sCreate1, sInsert1: string;
  sList: TStringList;
  sError: string;
  //Time1, Time2, Time3, Time4: TDateTime;
begin
  //Time1 := Now;
  if (TableName1 = '') or (Query = '') then
  begin
    ErrorMesDlg('Ошибка вызова функции!');
    exit;
  end;
  if Pos('#', TableName1)<> 1 then
  begin
    ErrorMesDlg('Имя таблицы на сервере должно начинаться с #!');
    exit;
  end;
  sList := TStringList.Create;
  sList.Add(GetTextCreate(DataSetIN1, TableName1));
  sList.Add(GetTextInsert(DataSetIN1, TableName1));
  if AddSelect then Query := Query + #13#10 + 'select * from ' + TableName1;
  sList.Add(Query);
  //Time2 := Now;
  //exit;
  eSP := TencStoredProc.Create(nil);
  eSP.SPName := 'spen_TEMPTABLE';
  //ViewText(sList.Text);
  eSP.Parameters[0].Value := sList.Text;
  try
    eSP.Open;
  except
    sError := 'Ошибка выполнения запроса: ' + ScriptException.Message + CR + CR + sList.Text;
    RaiseScriptException('', sError);
  end;
  if (MemTableOUT <> nil) then
  begin
    MemTableOUT.DeleteTable;
    MemTableOUT.FieldDefs.Assign(eSP.FieldDefs);
    MemTableOUT.LoadFromDataSet(eSP,mkSet());
    ReadOnlyFields(MemTableOUT, False);
  end;
  eSP.Free;
  sList.Free;
end;
//==============================================================================
// Процедура Select1_SameTable такая же как и Select1 только поля не удадяются.
// Это как временное решение, для устранения ошибки при импорте застрахованных когда после удаления полей
// не срабатывает процедура LoadMemTableFromStringList из-за того что поля в файле csv не совпадают с тем что в MemTable.
// При вызове Query всегда должен содержать в конце какой либо Select, например Select 1.
// Автор: Травин Е.В.
// Дата: 07.08.2012
//==============================================================================
procedure Select1_SameTable(DataSetIN1: TDataSet; TableName1, Query: string; MemTableOUT: TmcMemTable);
var
  eSP: TencStoredProc;
  sCreate1, sInsert1: string;
  sList: TStringList;
begin
  if (TableName1 = '') or (Query = '') then
  begin
    ErrorMesDlg('Ошибка вызова функции!');
    exit;
  end;
  if Pos('#', TableName1) <> 1 then
  begin
    ErrorMesDlg('Имя таблицы на сервере должно начинаться с #!');
    exit;
  end;
  sList := TStringList.Create;
  sList.Add(GetTextCreate(DataSetIN1, TableName1));
  sList.Add(GetTextInsert(DataSetIN1, TableName1));
  if LowerCase(Copy(Query, 1, 6)) <> 'select' then Query := Query + #13#10 + 'select * from ' + TableName1;
  sList.Add(Query);
  eSP := TencStoredProc.Create(nil);
  eSP.SPName := 'spen_TEMPTABLE';
  eSP.Parameters[0].Value := sList.Text;
  eSP.Open;
  //DataSetOUT.DeleteTable;
  //DataSetOUT.FieldDefs.Assign(eSP.FieldDefs);
  MemTableOUT.LoadFromDataSet(eSP,mkSet());
  ReadOnlyFields(MemTableOUT, False);
  eSP.Free;
  sList.Free;
end;
//==============================================================================
// Процедура Select2 отсылает три таблицы на сервере, выполняет запрос и возвращает результат.
// DataSetIN1, DataSetIN2 - Таблицы которую необходимо загрузить на сервер
// TableName1, TableName2 - Имена под которыми таблицы будут на сервере
// Query      - Произвольный SQL запрос
// DataSetOUT - Таблица в которой возвращается результат
// DataSetOUT и (DataSetIN1 или DataSetIN2) могут совпадать.
// Пример вызова: Select2(mtDescIN1, mtDescIN2,'#A2_Table18', '#A2_Table19', 'select * from #A2_Table18, #A2_Table19', mtDescOUT);
// При вызове Query всегда должен содержать в конце какой либо Select, например Select 1.
// Автор: Травин Е.В.
// Дата: 05.05.2012
//==============================================================================
procedure Select2(DataSetIN1, DataSetIN2: TDataSet; TableName1, TableName2, Query: string; MemTableOUT: TmcMemTable);
var
  eSP: TencStoredProc;
  sCreate1, sInsert1: string;
  sCreate2, sInsert2: string;
begin
  if (TableName1 = '') or (TableName2 = '') or (Query = '') then
  begin
    ErrorMesDlg('Ошибка вызова функции!');
    exit;
  end;
  if (Pos('#', TableName1) <> 1) or (Pos('#', TableName2) <> 1) then
  begin
    ErrorMesDlg('Имя таблиц на сервере должно начинаться с #!');
    exit;
  end;
  sCreate1 := GetTextCreate(DataSetIN1, TableName1);
  sInsert1 := GetTextInsert(DataSetIN1, TableName1);
  sCreate2 := GetTextCreate(DataSetIN2, TableName2);
  sInsert2 := GetTextInsert(DataSetIN2, TableName2);
  eSP := TencStoredProc.Create(nil);
  eSP.SPName := 'spen_TEMPTABLE';
  eSP.Parameters[0].Value := sCreate1 + sInsert1 +
                             sCreate2 + sInsert2 + #13#10 + Query;
  eSP.Open;
  MemTableOUT.DeleteTable;
  MemTableOUT.FieldDefs.Assign(eSP.FieldDefs);
  MemTableOUT.LoadFromDataSet(eSP,mkSet());
  ReadOnlyFields(MemTableOUT, False);
  eSP.Free;
end;
//==============================================================================
// Процедура Select3 отсылает три таблицы на сервере, выполняет запрос и возвращает результат.
// DataSetIN1, DataSetIN2, DataSetIN3 - Таблицы которую необходимо загрузить на сервер
// TableName1, TableName2, TableName3 - Имена под которыми таблицы будут на сервере
// Query      - Произвольный SQL запрос
// DataSetOUT - Таблица в которой возвращается результат
// DataSetOUT и (DataSetIN1 или DataSetIN2 или DataSetIN3) могут совпадать.
// Пример вызова: Select3(mtDescIN1, mtDescIN2, mtDescIN3, '#A2_Table18', '#A2_Table19',
//            '#A2_Table20', 'select * from #A2_Table18, #A2_Table19, #A2_Table20', mtDescOUT);
// При вызове Query всегда должен содержать в конце какой либо Select, например Select 1.
// Автор: Травин Е.В.
// Дата: 05.05.2012
//==============================================================================
procedure Select3(DataSetIN1, DataSetIN2, DataSetIN3: TDataSet; TableName1, TableName2, TableName3, Query: string; MemTableOUT: TmcMemTable);
var
  eSP: TencStoredProc;
  sCreate1, sInsert1: string;
  sCreate2, sInsert2: string;
  sCreate3, sInsert3: string;
begin
  if (TableName1 = '') or (TableName2 = '') or (TableName3 = '') or (Query = '') then
  begin
    ErrorMesDlg('Ошибка вызова функции!');
    exit;
  end;
  if (Pos('#', TableName1) <> 1) or (Pos('#', TableName2) <> 1) or (Pos('#', TableName3) <> 1) then
  begin
    ErrorMesDlg('Имя таблиц на сервере должно начинаться с #!');
    exit;
  end;
  sCreate1 := GetTextCreate(DataSetIN1, TableName1);
  sInsert1 := GetTextInsert(DataSetIN1, TableName1);
  sCreate2 := GetTextCreate(DataSetIN2, TableName2);
  sInsert2 := GetTextInsert(DataSetIN2, TableName2);
  sCreate3 := GetTextCreate(DataSetIN3, TableName3);
  sInsert3 := GetTextInsert(DataSetIN3, TableName3);
  eSP := TencStoredProc.Create(nil);
  eSP.SPName := 'spen_TEMPTABLE';
  eSP.Parameters[0].Value := sCreate1 + sInsert1 +
                             sCreate2 + sInsert2 +
                             sCreate3 + sInsert3 + #13#10 + Query;
  eSP.Open;
  MemTableOUT.DeleteTable;
  MemTableOUT.FieldDefs.Assign(eSP.FieldDefs);
  MemTableOUT.LoadFromDataSet(eSP,mkSet());
  ReadOnlyFields(MemTableOUT, False);
  eSP.Free;
end;
  */
 
    //======================================================================
/*
        
    //enum ObjParams
      //{
      //iPos, 
      //iTypeAction
    //}
*/
//======================================================================
/*
      /*public class Demo
    {
        public static int ZipDeflate(System.IO.Stream dest, string FileName, System.IO.Stream src, System.IO.Stream tail,int offset)
        {
            // zip-архив двупроходный, содержит тело и "хвост"
            //   нужно записать "все" файлы через ZipStore, хвост запишется в tail            
            System.IO.MemoryStream deflate = new MemoryStream();
            UInt32[] CrcTable = new UInt32[256];
            DateTime dt = DateTime.Now;
            byte[] buf = new byte[4096];
            int i = 0, j = 0;
            uint Crc32 = 0 ^ 0xffffffff;
            int size = (FileName == null) ? 0 : (14 + 12 + 4 + FileName.Length);
            uint dt2 = (uint)((dt.Second / 2) | (dt.Minute << 5) | (dt.Hour << 11) | (dt.Day << 16) | (dt.Month << 21) | ((dt.Year - 1980) << 25));  //DOS time
            uint POLYNOMIAL = 0xEDB88320, remainder = 0;
            for (i = 1; i < 256; i++)
            {
                remainder = (uint)i;
                for (uint bit = 8; bit > 0; --bit) remainder = ((remainder & 1) != 0) ? ((remainder >> 1) ^ POLYNOMIAL) : (remainder >> 1);
                CrcTable[i] = remainder;
            }
            src.Position = 0;
            using (System.IO.Compression.DeflateStream ds = new System.IO.Compression.DeflateStream(deflate, System.IO.Compression.CompressionMode.Compress,true))
            do
            {
                    i = src.Read(buf, 0, 4096);
                    for (j = 0; j < i; j++) Crc32 = CrcTable[(Crc32 ^ buf[j]) & 0xff] ^ (Crc32 >> 8);                  
                    ds.Write(buf,0,i);                    
            } while (i == 4096); 
            
            deflate.Position=0;
            src.Position = 0;
            Crc32 ^= 0xffffffff;
            dest.Write(new byte[] { 0x50, 0x4B, 0x03, 4, 0x14 , 0, 0, 0 , 8, 0 }, 0, 10);
            Buffer.BlockCopy(new uint[] { dt2, Crc32, (uint)deflate.Length ,(uint) src.Length, (uint)FileName.Length }, 0, buf, 0, 20);
            dest.Write(buf,0, 20);
            dest.Write(System.Text.Encoding.UTF8.GetBytes(FileName), 0, FileName.Length);            
            do
            {
                i = deflate.Read(buf, 0, 4096); //Запись "тела" (deflate stream)
                if (i != 0) dest.Write(buf, 0, i);
                Console.Write("len=" + i);
                size += i;
            } while (i == 4096);
    
            long len = (long)tail.Length;             //Обработка хвоста
            int offs = 0;
            int count = 1;
            if (len != 0)
            {
                tail.Position = len - 12;
                tail.Read(buf, 0, 12);
                count = ((int)BitConverter.ToInt16(buf, 0)) + 1;
                offs = BitConverter.ToInt32(buf, 6);
                tail.Position = len - 22; //Следующий central-dir 
            };
            count = count * 65536 + count; //Запись central-dir           
            Buffer.BlockCopy(new uint[] { 0x2014B50,0x200B23,0x80000, dt2, Crc32, (uint)deflate.Length,(uint) src.Length, (uint)FileName.Length,0, 0x81, 0,0 }, 0, buf, 0, 42);
            tail.Write(buf,0,42);
            tail.Write(BitConverter.GetBytes(offset),0, 4);  
            tail.Write(System.Text.Encoding.UTF8.GetBytes(FileName), 0, FileName.Length);
            len = (int)tail.Length;   //Запись endof-centraldir
            Buffer.BlockCopy(new int[] { 0x6054B50,0,count,(int)len,(int)(offs+size),0 }, 0, buf, 0, 22);
            tail.Write(buf, 0, 22);
            tail.Position = 0;
            return size;
        }
            
            
        public static void Main11(string[] args)
        {
            Stream dest = System.IO.File.Create("1.zip");
            MemoryStream mm = new MemoryStream();
            MemoryStream tail = new MemoryStream();
            //MemoryStream tail = new System.IO.MemoryStream();
            mm.Write(new byte[] { 65,65,65,65,65,65,65,65,65,65 },0, 10);
            mm.Position = 0;
            int offs = ZipDeflate(dest,"1.txt",mm,tail,0); //Запись файла
            // mm.Position = 0; offs += ZipDeflate(dest,"2.txt",mm,tail,offs);/Второй файл
            dest.Write(tail.ToArray(),0,(int)tail.Length);// Запись "хвоста"
            dest.Close();
        }
        
*/
 //======================================================================
/*
        //string value = listBox.Items[index].ToString();                                     
                //ListBox listBox1 = new ListBox();
                //StreamReader sr = new StreamReader(FileName);          
               // string line;
                //while ((line = sr.ReadLine()) != null){listBox1.Items.Add(line);}           
                //LinesCount = listBox1.Items.Count;
                //ResultText = listBox1.Text;
                //return true; 
*/
//======================================================================
/*
 //Записать Hash MD5 в конец файла. MD5 всегда 32 символа. 
        public static bool FileHashMD5Save(string FileName, string HashMD5)
        {                 
            try
            {   //FileName = @"E:\000_Travin\Projects C#\Проба дизайнер С#\Дизайнер C#\Sys\bin\Debug\Settings\test.txt";   //92892120238C10B22C797FAFB70C7C9B
                /*var f1 = new FileInfo(FileName);
                FileStream fstream = f1.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                var bw = new BinaryWriter(fstream);
                var input = Encoding.Default.GetBytes(HashMD5);
                fstream.Seek(0, SeekOrigin.End);
                bw.Write(input, 0, 32); 
                fstream.Close();
                return true; */        
            
                /*FileStream fstream = new FileStream(FileName, FileMode.OpenOrCreate);                                    
                byte[] array = System.Text.Encoding.Default.GetBytes(HashMD5); //преобразуем строку в байты                 
                fstream.Seek(0, SeekOrigin.End);
                fstream.Write(array, 0, array.Length);
                return true;                                                                
            }  catch (Exception ex)
            {
                sys.SM("Ошибка записи контрольной суммы в файл: " + FileName + Var.CR + ex.Message);
                return false;
            }                                           
        }
*/
//======================================================================
/*
      //Получить файл в виде Base64. Если SaveHashToEndFile, то в конец файла будет добавлен MD5 файла (32 байта).
        public static bool FileGetBase64(string FileName, bool SaveHashToEndFile, out string FileData, out string HashMD5)           
        {   
            FileData = "";
            HashMD5  = "";
            if (SaveHashToEndFile)
            {
               HashMD5 = Crypto.FileMD5(FileName);
               if (HashMD5 == "") return false;
               if (!Crypto.FileHashMD5Save(FileName, HashMD5)) return false;
            }   
            
            //FileStream fs = null;
            //fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);  //открываем файл
            //var fileBuffer = new byte[fs.Length];
            //fs.Read(fileBuffer, 0, (int)fs.Length);        //читаем в бинарный буфер
            //fs.Close();                   
            //FileData = Convert.ToBase64String(fileBuffer);
            if (!FileReadBase64(FileName, out FileData)) return false;
            return true;
        }  
*/
//======================================================================
/*
   //На входе строка Base64, переконвертирование её в массив байт и запись в файл на диск.
        public static bool FileWriteBase64(string FileName, string FileData)
        {
            try
            {  
                var fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                byte[] newBytes = Convert.FromBase64String(FileData);
                fs.Write(newBytes, 0, newBytes.Length);   
                fs.Close();               
                return true;
            }
            catch (Exception e)
            {
                sys.SM("Ошибка записи файла: " + FileName + Var.CR + e.Message);
                return false;
            }                               
        }
           
*/
//======================================================================
/*
      /*if ((ConnectionDirect) && (ServerType == "Postgre"))
                {
                    command1 = new NpgsqlCommand(SQL);
                    command1.Connection = connection1;
     
                    //Запись файла в БД. Чтение поля id вставленной записи
                    NpgsqlDataReader dr = command1.ExecuteReader();
                    dr.Read();               
                    if ((FormID == "") || (FormID == null))
                        if (dr.HasRows) FormID = dr[0].ToString();                                                            
                    dr.Close();
                }
               
                if ((ConnectionDirect) && (ServerType == "MSSQL"))
                {
                    command2 = new SqlCommand(SQL);
                    command2.Connection = connection2;
     
                    //Запись файла в БД. Чтение поля id вставленной записи
                    SqlDataReader dr = command2.ExecuteReader();
                    dr.Read();               
                    if ((FormID == "") || (FormID == null))
                        if (dr.HasRows) FormID = dr[0].ToString();                                                            
                    dr.Close();
                }
               
                if ((ConnectionDirect) && (ServerType == "SQLite"))
                {
                    command3 = new SQLiteCommand(SQL);
                    command3.Connection = connection3;
     
                    //Запись файла в БД. Чтение поля id вставленной записи
                    SQLiteDataReader dr = command3.ExecuteReader();
                    dr.Read();               
                    if ((FormID == "") || (FormID == null))
                        if (dr.HasRows) FormID = dr[0].ToString();                                                            
                    dr.Close();
                }
                
                if (!ConnectionDirect) 
                {
                    Exec(SQL, out FormID);                     
                }
                
                if (sys.ErrorCheck(((FormID == "") || (FormID == null)), "Ошибка записи формы!")) return false;
                return true;                    
            }
            catch (Exception e)
            {
                sys.SM(e.Message);
                FormID = "";
                return false;
            }
*/
//======================================================================
/*
            
            //string EXT = Path.GetExtension(FormName);
            //if (EXT == ".exe") FormType = "Main";
            //if (EXT == ".dll") FormType = "DLL";    
            //string TextCode1 = File.ReadAllText(TextCodePath, System.Text.Encoding.Default);
            //string FormCode1 = File.ReadAllText(FormCode, System.Text.Encoding.Default);                           
            //string TextAll = FormCode2 + TextCode2;
            //string FormName = this.Name;         
*/ 
//======================================================================
/*
 //Возвращает полный путь к форме (файлу DLL).
        public static bool GetPathForm(string FormName, out string FileName)
        {
            //string ApplicationDirectory = sys.PathMain; //System.Windows.Forms.Application.StartupPath;
            FileName = "";
            //if ((EnterMode == "Test") || (EnterMode == "Dev"))
            //{
            //    FileName = @"..\..\..\sys\bin\Debug\FormTest\" + FormName + ".dll";
            //    if (!File.Exists(FileName)) FileName = sys.PathMain + @"FormTest\" + FormName + ".DLL";  
            //    if (!File.Exists(FileName)) FileName = sys.PathMain + FormName + ".dll";                     
            //}
            
            //if (EnterMode == "Work") 
            //{
                FileName = @"..\..\..\sys\bin\Debug\FormWork\" + FormName + ".dll";
                if (!File.Exists(FileName)) FileName = sys.PathMain + @"FormWork\" + FormName + ".dll";
                if (!File.Exists(FileName)) FileName = sys.PathMain + FormName + ".dll";
            //}
                      
            //Функция GetFullPath возвращает полный путь относительно текущей папки.
            Directory.SetCurrentDirectory(sys.PathMain);
            string FileNameFull = System.IO.Path.GetFullPath(FileName);
            //if (ErrorCheck(!File.Exists(FileNameFull), "Не найден файл: " + FileName)) return false;     
            FileName = FileNameFull;
            return true;          
        }
*/ 
 //======================================================================
/*
             
            //Три типа DLL, FormMain и Form.
            //Действия, которые нужны:
            //Запуск главной формы FormMain - одноразовое действие при запуске главной формы приложения.
            //Получить объект Form.
            //Показать Form как Show.
            //Показать Form как ShowDialog.
            //Вызвать метод MethodName с параметрами Objects[] из DLL или Form или FormMain.
              
            /*if (FormType == "DLL") return null;
            Type type = assembly.GetType("FBA." + FormName);
            var Form1 = (FormCustom)Activator.CreateInstance(type);
            Form1.TextQuery = TextQuery;                      
            return Form1;
*/
//======================================================================
/*
         //Чтение формы из БД из кодировки Base64.        
        /*public static bool FormReadFromDataBase(string FileName, string FormName, string EnterMode)
        {               
            string FieldName = "";
            if (EnterMode == "Work") FieldName = "FormDLL";
                else FieldName = "FormDLLTest";
            
            string SQL = "SELECT " + FieldName + " FROM fbaProject WHERE Name = '" + FormName + "' ; ";  
            string FileData = Var.conSys.GetValue(SQL);   
            //Записываем форму на диск. Форма в виде текста в FileData в Base64. 
            string ErrorMes;
            const bool ShowMes = true;
            return sys.FileWriteFromBase64(FileData, FileName, out ErrorMes, ShowMes);           
        }    
*/
 //======================================================================
/*
 //Загрузка DLL прикладного приложения (подсистемы).
        public static Assembly ModuleLoad(string FormName, string EnterMode) //(string FormName, ref string FormType, out string TextQuery, out string FileName)
        {                      
            Assembly assembly; 
            string FileName = "";
            //Возможно сборка уже загружена. Если даже модуль изменился, 
            //мы все равно работаем в одном домене, поэтому замениь уже загруженную DLL нет возможности.
            //Она подменится при пере-открытии Клиента в следующий раз.
            if (sys.FindAssembly(FormName, out assembly)) return assembly;
            
            if (!FormReadFromDataBase(FormName, EnterMode, false, out FileName)) return null;
            //DLL модуля ещё не загружена - продолжаем:
            /*string HashMD5   = "";           
            string FormType  = "";
            
            //Если модуля нет в БД, то выходим.
            if (!CheckModuleExist(FormName, EnterMode, out FormType, out HashMD5)) return null;
                        
            string FileName;
            sys.GetPathForm(FormName, out FileName);
            bool FileExists = File.Exists(FileName);
            bool NeedLoad = false; //!FileExists;
            
            //Если файл на диске есть, и его MD5 совпадает с тем, что в БД, то не загружаем.
            //Если в режиме разработки, то если файл есть, то не проверяем версию и из БД не загружаем.
            if (FileExists)
            {                           
                if (Var.enterMode != "Dev") 
                {
                    string Hashmd5BD = Crypto.FileHashMD5Read(FileName); //Пример HashMD5: 9924E53BC7DC4584954601F15023F40C
                    NeedLoad = (Hashmd5BD != HashMD5);
                }
            }            
            else NeedLoad = true;
            
            if (NeedLoad) 
            {
                //Загрузка формы из БД 
                if(!(sys.FormReadFromDataBase(FileName, FormName, EnterMode))) return null;               
            }
             
            if (!File.Exists(FileName))
            {
                if ((FormType == "Form") || (FormType == "Main")) sys.SM("Ошибка загрузки формы: " + FileName);
                if (FormType == "DLL")  sys.SM("Ошибка загрузки модуля: " + FileName);
                return null;
            }*/ 
            
            //Если нет, то загружаем.
            /*if (FileName == "") return null;
            try
            { 
                assembly = Assembly.LoadFile(FileName);
                             
            }
            catch (Exception ex)
            {
                sys.SM("Ошибка загрузки сборки " + FileName + " " + ex.Message);
                return null;
            }                                         
            return assembly;            
        }
*/
//======================================================================
/*
//Событие. Удаление файлов кэша.
        private void BtnDeleteDLLClick(object sender, EventArgs e)
        {
            string SenderName = sys.GetSenderName(sender);
            string NotDeletedFiles = "";
            string PathDelete = "";
              
            NotDeletedFiles = DeleteCash(sys.PathMain);
            //System.Diagnostics.Process.Start(PathDelete);
            if (NotDeletedFiles != "") sys.SM("Не удаленные файлы: " + Var.CR + NotDeletedFiles);
            else sys.SM("Все файлы кэша успешно удалены!");
               
        } 
*/
//======================================================================
/*
   //Чтение пользовательского значения из таблицы настроек fbaSetting.  
        public static string LoadUserSetting(string SettingName)
        {                             
             const bool Global    = false;
             string SettingType   = "";
             string SettingValue  = "";
             if (!sys.LoadSetting("Remote", SettingName, Global,  out SettingValue, out SettingType)) return "";
             return SettingValue;
            //string Value = Var.con.GetValue("SELECT Value FROM fbaSetting WHERE Type = 'User' AND Name = '" + SettingName + "';");
            //return Value.FromBase64();                                                        
        } 
*/
//======================================================================
/*
    //Запись всех значений компонентов в таблицу fbaSetting.    
        public bool SaveSettings(string Direction)
        {                                
            SettingText = "";
            GetSettings(this.Controls);  
            string FormName = this.Name;
            string SQL = "DELETE FROM fbaSetting WHERE Name = '" + FormName + "'; " + Var.CR +
                "INSERT INTO fbaSetting (EntityID, Name, FormID, UserID, Global, Type, Value) VALUES (" +
                "9000," + //EntityID  (SELECT ID FROM fbaEntity WHERE Brief = 'Setting')
                "'" + FormName + "'," +     //Name
                "(SELECT ID FROM fbaProject WHERE Name = '" + FormName + "')," + //FormID
                Var.UserID  + "," +          //UserID
                "0," +                      //Global
                "'Form'," +                 //Type          
                "'" + SettingText + "') ";  //Value
            return sys.Exec(Direction, SQL);                            
        }
        
        //Чтение значений компонентов из fbaSetting.  
        public bool LoadSettings(string Direction)
        {             
            string SQL = "SELECT Global, Type, Value FROM fbaSetting WHERE Name = '" + this.Name + "' AND UserID = " + Var.UserID ;                       
            System.Data.DataTable DT;
            if (!sys.SelectDT1(Direction, SQL, out DT)) return false;
            string Global = sys.DTValue(DT, "Global");
            string Type   = sys.DTValue(DT, "Type");
            string Value  = sys.DTValue(DT, "Value");
            string[] DotArray = Value.Split('\n');
            for (int i = 0; i < DotArray.Count(); i++)
            {
                string s = DotArray[i].Trim();
                int N = s.IndexOf(':');
                if (N == -1) continue;
                string ControlName  = s.Substring(0, N);
                //string ControlValue = s.Substring(N + 1).Replace("<#*#>", Var.CR);
                string ControlValue = s.Substring(N + 1).FromBase64();
                Control control = this.Controls.Find(ControlName, true).FirstOrDefault();
                if (control != null) control.Text = ControlValue; //При этом присвоении вызовется ControlValueChanged автоматически.                                     
            }            
            return true;                                     
        }
         
*/
//======================================================================
/*
 void FilterToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormFBA FormFilter = new FormFilter();           
            Form Form1 = new FormMainFilter();
            
            Control pnlFilter1 = Form1.Controls.Find("pnlFilter", true).FirstOrDefault();
            Control pnlFilter2 = FormFilter.Controls.Find("pnlFilter", true).FirstOrDefault();;
            pnlFilter1.Parent  = pnlFilter2;
            FormFilter.Show();
             //this.panel1;
            //f1.Controls[1].Parent = this.panel1;              
            //object obj = panel1;
            //f1.MdiParent = (Form)obj;
            //f1.WindowState = FormWindowState.Maximized;
            //f1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //f1.ControlBox = false;
            //f1.Show();
        }
*/
//======================================================================
/*
                       
        //Контекстное меню для дерева сущностей.
        private void AddToolStripMenuItemClick(object sender, EventArgs e)
        {
           
            /*if (ComponentStrip == "dgvAttr")
            {
                var FAttr = new FormAttr();  
                //SetQueryEntity(QueryName, EntityBrief, ObjectID, StateDate, Direction = "Remote")
                FAttr.SetQueryEntity("Main2", "АтрибутСущности", "1982", "", "Remote");
                
                //SetQueryTable(QueryName, TableName, ObjectID, IDFieldName = "", StateDate = "", Direction = "Remote")
                FAttr.SetQueryTable("Main3", "fbaAttribute", "20", "AttributeID", "", "Remote");
                               
                //SetQueryDirect(QueryName, Lang, Query, Direction = "Remote")
                FAttr.SetQueryDirect("Main4", "MSQL", "select ДатаНачала from ДогСтрах where ИДОбъекта = 2284621", "Remote");
                                                                        
                FAttr.Read();             
                FAttr.ShowDialog();   
            }*/
             
            //var FormAttr = new FormAttr();               
            //FormAttr.ShowDialog();   
        //}  
//*/ 
//======================================================================
/*
   /*case Keys.Down:
                        //Console.WriteLine("Down Arrow Captured");
                        s = "";//s + "Down Arrow Captured" + Var.CR;
                        break;
                     
                     case Keys.Up:
                        Console.WriteLine("Up Arrow");
                        s = "";//s + "Up Arrow Captured";
                        break;
             
                     case Keys.Tab:
                        Console.WriteLine("Tab Key");
                        s = "";//s + "Tab Key Captured"; 
                        break;
             
                     case Keys.Control | Keys.M:
                        Console.WriteLine("<CTRL> + m");
                        s = "";//s + "<CTRL> + m Captured"; 
                        break;
             
                     case Keys.Alt | Keys.Z:
                        Console.WriteLine("<ALT> + z");
                        s = "";//s + "<ALT> + z Captured"; 
                        break;
                    case Keys.Alt | Keys.Control | Keys.S: 
                        s = s + "<ALT> + <CTRL> + S"; 
                        break; 
*/ 
 //======================================================================
/*
 public delegate void MyFunc(out double z, double x, double y, double c);
         
        
        private void TbCSharp1Click(object sender, EventArgs e)
        {
                                     
                                 
        }
        
*/
//======================================================================
/*
  void Button5Click(object sender, EventArgs e)
        {
              
             
            /*System.Windows.Forms.TableLayoutPanel Lp_N2 = new System.Windows.Forms.TableLayoutPanel();
            FBA.ComboBoxFBAcb3_N2 = new System.Windows.Forms.ComboBox();
            FBA.ComboBoxFBAcb2_N2 = new System.Windows.Forms.ComboBox();
            FBA.ComboBoxFBAcb4_N2 = new System.Windows.Forms.ComboBox();
            System.Windows.Forms.CheckBox cb1_N2 = new System.Windows.Forms.CheckBox();
            tabPage3.Controls.Add(Lp_N2);
                      //pnlFilterUni.
            // 
            // Lp_N2
            // 
            Lp_N2.ColumnCount = 4;
            Lp_N2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            Lp_N2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent,  40F));
            Lp_N2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            Lp_N2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent,  60F));
            Lp_N2.Controls.Add(cb3_N2, 2, 0);
            Lp_N2.Controls.Add(cb2_N2, 1, 0);
            Lp_N2.Controls.Add(cb4_N2, 3, 0);
            Lp_N2.Controls.Add(cb1_N2, 0, 0);
            Lp_N2.Location = new System.Drawing.Point(31, 183);
            Lp_N2.Name = "Lp_N2";
            Lp_N2.RowCount = 1;
            Lp_N2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            Lp_N2.Size = new System.Drawing.Size(707, 34);
            Lp_N2.TabIndex = 18;
            // 
            // cb3_N2
            // 
            cb3_N2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            cb3_N2.FormattingEnabled = true;
            //cb3_N2.Location = new System.Drawing.Point(263, 6);
            cb3_N2.Name = "cb3_N2";
            //cb3_N2.Size = new System.Drawing.Size(94, 26);
            cb3_N2.TabIndex = 16;
            // 
            // cb2_N2
            // 
            cb2_N2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            cb2_N2.FormattingEnabled = true;
            //cb2_N2.Location = new System.Drawing.Point(33, 6);
            cb2_N2.Name = "cb2_N2";
            //cb2_N2.Size = new System.Drawing.Size(224, 26);
            cb2_N2.TabIndex = 15;
            // 
            // cb4_N2
            // 
            cb4_N2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            cb4_N2.FormattingEnabled = true;
            //cb4_N2.Location = new System.Drawing.Point(363, 6);
            cb4_N2.Name = "cb4_N2";
            //cb4_N2.Size = new System.Drawing.Size(341, 26);
            cb4_N2.TabIndex = 14;
            // 
            // cb1_N2
            // 
            cb1_N2.Anchor = System.Windows.Forms.AnchorStyles.None;
            //cb1_N2.Location = new System.Drawing.Point(8, 10);
            cb1_N2.Name = "cb1_N2";
            //cb1_N2.Size = new System.Drawing.Size(13, 14);
            cb1_N2.TabIndex = 11;
            cb1_N2.Text = "Use the custom filter";
            cb1_N2.UseVisualStyleBackColor = true;
            Lp_N2.SuspendLayout();
        }
*/
 //======================================================================
/*
   /*
         * flowLayoutPanel1.Controls.Add(new RadioButton()    {Checked = false });
            flowLayoutPanel1.Controls.Add(new Button()    {Text = "Sample Button"});
            flowLayoutPanel1.Controls.Add(new RadioButton()    {Checked = false });
            flowLayoutPanel1.Controls.Add(new RadioButton()    {Checked = true });
            int IndexOfChecked = 0;
            foreach (Control pannelControl in  flowLayoutPanel1.Controls)
            {
                if (pannelControl is RadioButton)
                {
                    if (((RadioButton)pannelControl).Checked)
                    {
                        IndexOfChecked = flowLayoutPanel1.Controls.IndexOf(pannelControl);
                    }
                }
                
            }
            Text = IndexOfChecked.ToString();
*/
//======================================================================
/*
  void Button1Click(object sender, EventArgs e)
        {
            string Values = "";
            if (!sys.InputText("List of values", "Input values", ref Values)) return;
            sys.SM(Values);
        } 
*/
//======================================================================
/*
        //Добавление узла дерева сущностей.
        /*private void AddNodes(System.Data.DataTable DT, TreeNode node)
        {    
            foreach (DataRow dr in DT.Select("Attr_EntityID = " + node.Tag.ToString()))
            {
                var node1 = new TreeNode();
                //node1.
                node1.Text = dr["Attr_Brief"].ToString();
                node1.Tag = dr["Ref_EntityID"];
                node.Nodes.Add(node1);
                string AttrType = dr["Attr_Type"].ToString();
                if (AttrType == "2") AddNodes(DT, node1);
             }
        } 
*/
//======================================================================
/*
  /sys.LoadTreeFromDataTable(treeViewAttr, DTEnt, "ID", "ParentID", "Name", true);                                                 
            // TreeNode argentinaNode = new TreeNode { Text = "Аргентина", ImageIndex=0, SelectedImageIndex=0 };
                  
            
*/
//======================================================================
/*
 string SettingCustom = "";
            for (int i = FilterCount; i > 0; i--)
            {
                string N = i.ToString();
                string SettingLine = "";
                Control control = this.Controls.Find("LpN" + N, true).FirstOrDefault();
                if (control == null) continue;
                
                Control control1 = this.Controls.Find("cb1N" + N, true).FirstOrDefault();                                                            
                Control control2 = this.Controls.Find("cb2N" + N, true).FirstOrDefault();
                Control control3 = this.Controls.Find("cb3N" + N, true).FirstOrDefault();
                Control control4 = this.Controls.Find("cb4N" + N, true).FirstOrDefault(); 
                
                SettingLine = ((System.Windows.Forms.CheckBox)control1).Checked.ToInt().ToString() + ";" +
                              ((System.Windows.Forms.TextBox)control2).Text  + ";" +
                              ((System.Windows.Forms.ComboBox)control3).Text + ";" +
                              ((System.Windows.Forms.TextBox)control4).Text  + ";";
                SettingCustom = SettingCustom + SettingLine + Var.CR;                      
            }             
            return SettingCustom.ToBase64();
*/
//======================================================================
/*
  //Количество символа chr в строке.
        public static int CountChar(this string InputStr, char chr)
        {
            //If you're using .NET 3.5 you can do this in a one-liner with LINQ:
            //int count = source.Count(f => f == '/');
            
            //If you don't want to use LINQ you can do it with:
            return InputStr.Split(chr).Length - 1;
            
            //или вообще, по старому сермяжному способу, в цикле:      
            //string source = "/once/upon/a/time/";
            //int count = 0;
            //foreach (char c in source) 
            //  if (c == '/') count++;
        } 
*/ 
//======================================================================
/*
   /*class GradientLabelDesigner : ControlDesigner (
    DesignerVerb dverb; MenuCommand mc;
    public override void Initialize(IComponent component)
    {
    base.Initialize(component); // Получаем интерфейс сервиса
    IMenuCommandService mcs = (IMenuCommandService)component.Site.GetService(typeof(IMenuCommandService));
    // Добавляем меню
    dverb — new DesignerVerb("Глобальное меню",
    new EventHandler(OnGloball));
    dverb.Visible = true; dverb.Enabled = true; dverb.Supported = true; mcs.RemoveVerb(dverb); mcs.AddVerb(dverb);
    }
        private void OnGloball(object sender, System.EventArgs e) (
        System.Windows.Forms.MessageBox.Show("Вызвано меню Globall");
    }
    )*/
        
    //Дополнительные классы: InputBox,
    /*public class InputBox: Form
    {        
        //Пример использования:  
        //if (!InputBox.Query("Имя таблицы на сервере", "Введите имя таблицы:", ref ServerTableName)) return;
        //sys.SM(ServerTableName);
        
        private FBA.LabelFBA   label;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.Button  buttonOK;
        private System.Windows.Forms.Button  buttonCancel;
        
        private InputBox(string Caption, string Text)
        {
            this.label = new FBA.LabelFBA();
            this.textValue = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(9, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(31, 13);
            this.label.TabIndex = 1;
            this.label.Text = Text;
            this.textValue.Location = new System.Drawing.Point(12, 31);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(245, 20);
            this.textValue.TabIndex = 2;
            this.textValue.WordWrap = false;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(57, 67);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(138, 67);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(270, 103);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textValue);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //this.Text = Caption;
            this.ResumeLayout(false);
            this.PerformLayout();
        }       
    
        //Запрос ввода строки.
        public static bool Query(string Caption, string Text, ref string s_val)
        {
            var ib = new InputBox(Caption, Text);
            ib.textValue.Text = s_val;
            if (ib.ShowDialog() != DialogResult.OK) return false;
            s_val = ib.textValue.Text;
            return true;
        }
 
        //Запрос ввода числа Int32.
        public static bool InputValue(string Caption, string Text, string prefix, string format, ref int value, int min, int max)
        {
            int val = value;
 
            string s_val = prefix + value.ToString(format);
            bool OKVal;
            do
            {
                OKVal = true;
                if (!Query(Caption, Text, ref s_val)) return false;
 
                try
                {
                    string sTr = s_val.Trim();
 
                    if ((sTr.Length > 0) && (sTr[0] == '#'))
                    {
                        sTr = sTr.Remove(0, 1);
                        val = Convert.ToInt32(sTr, 16);
                    }
                    else if ((sTr.Length > 1) && ((sTr[1] == 'x') && (sTr[0] == '0')))
                    {
                        sTr = sTr.Remove(0, 2);
                        val = Convert.ToInt32(sTr, 16);
                    }
                    else
                        val = Convert.ToInt32(sTr, 10);
                }
                catch {sys.SM("Требуется ввести число!"); OKVal = false; }
                if ((val < min) || (val > max)) {sys.SM("Требуется число в диапазоне " + min.ToString() + "..." + max.ToString() + " !"); OKVal = false; }
            } while (!OKVal);
            value = val;
            return true;
        }                 
    }*/
                
    //Класс для показа в отдельной форме таблицы DataTable. 
    /*public class DataTableView: Form
    {        
        //Пример использования ниже: ViewDT, ViewArray. 
        
        private FBA.DataGridViewFBA dgv;
        
        private DataTableView(string Caption, System.Data.DataTable DT)
        {
            this.dgv = new FBA.DataGridViewFBA();
            this.SuspendLayout();
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dataGridView1";
            this.dgv.Size = new System.Drawing.Size(500, 319);
            this.dgv.TabIndex = 0;  
            this.dgv.DataSource = DT;
            this.ClientSize = new System.Drawing.Size(500, 319);
            this.Controls.Add(this.dgv);
            this.Name = "FormDataTable";
            //this.Text = "FormDataTable";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; 
            this.Text = Caption;
            this.ResumeLayout(false);
            this.PerformLayout();
        }   
        
        //Показ на форме таблицы DT. Пример: DataTableView.DTView("Шапка формы", DT);
        public static bool ViewDT(string CaptionForm, System.Data.DataTable DT)
        {
            var dtv = new DataTableView(CaptionForm, DT);            
            dtv.Show();             
            return true;
        }
        
        //Показ на форме значений массива Arr. Пример: DataTableView.ViewArray("0. Num;1. Lex; 2. Brace;", MySquareStringArray);
        public static bool ViewArray(string CaptionForm, string CaptionArray, string[,] Arr)
        {
            System.Data.DataTable DT;           
            sys.ArrayToDataTable(Arr, CaptionArray, out DT, 0, 0, false);           
            var dtv = new DataTableView(CaptionForm, DT);
            dtv.ShowDialog();             
            return true;
        }
    }
    
*/ 
 //======================================================================
/*
     
   /*
    // =============================================================================
function TDMS_Bill_T.GetFilter(Params: TVarParams; var ApplyFilter: boolean): string;
var
  //DateBillN, DateBillK, DatePayN, DatePayK, StartDateN, StartDateK, EndDateN, EndDateK : DateTime;
  //SummaBegin, SummaEnd : Float;
  //LPU, Metod, VidDoc, Area, TypePay, Org : Integer; // Тарасов К.Ю. 03/11/2010 Добавил переменные Org и isOrg
  //NumBillN, NumBillK, Status, ObjectIDStr : string;
  //isNumBill, isDateBill, isDatePay, isStartDate, isEndDate, isLPU, isMetod, isVidDoc, isStatus, isSumma, isArea, isTypePay, isOrg, isObjectID : Boolean;
  ButtonFilter, ParamStr: string;
  i, p: integer;
  ListA: TStringList;
  rbList1, rbList2, rbList3, rbList4, rbList5, rbList6, rbList7, rbList8, rbList9, rbList10, rbList11, rbList12, rbList13, rbList14: string;
  sFilter, FilterNum, FilterNumQ, FilterNumAll, FilterNumAllQ: string;
  cbWasAvansPay, cbNotMed, cbNotIns: string;
begin
  Result := '';
  ButtonFilter := ParamsDMU.ReadParam(Params, 'AddFilterParam', 'FALSE');
  ApplyFilter := ParamsDMU.StrToBool(ButtonFilter);
  if not ApplyFilter then exit;
  SQL :=  '(ИДОбъекта > 0) ';
  if ParamsDMU.CheckCondition(Params, 'cbObjectID', 'meObjectID', ParamStr) then
  begin
    if ParamStr <> '' then SQL := SQL + ' AND (ИДОБъекта = '        + ParamStr + ')';
  end;
  if ParamsDMU.CheckCondition(Params, 'cbOrg',     'olOrg',         ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (Организация = ' + ParamStr + ')';
  if ParamsDMU.CheckCondition(Params, 'cbNumBill',  'meNumBillN',   ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ПорядковыйНомер >= ' + ParamStr + ')';
  if ParamsDMU.CheckCondition(Params, 'cbNumBill',  'meNumBillK',   ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ПорядковыйНомер <= ' + ParamStr + ')';
  if ParamsDMU.CheckCondition(Params, 'cbNum',      'meNum',        ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (Номер = ''' + ParamStr + ''')';
  if ParamsDMU.CheckCondition(Params, 'cbDateBill', 'dteDateBillN', ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДатаДок >= '''    + ParamStr + ''')';
  if ParamsDMU.CheckCondition(Params, 'cbDateBill', 'dteDateBillK', ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДатаДок <= '''    + ParamStr + ''')';
  if ParamsDMU.CheckCondition(Params, 'cbDatePay',  'dteDatePayN',  ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДатаОплатыПлан >= '''    + ParamStr + ''')';
  if ParamsDMU.CheckCondition(Params, 'cbDatePay',  'dteDatePayK',  ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДатаОплатыПлан <= '''    + ParamStr + ''')';
  if ParamsDMU.CheckCondition(Params, 'cbVidDoc',   'olVidDoc',     ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ВидДок = ' + ParamStr + ')';
  if ParamsDMU.CheckCondition(Params, 'cbTypePayBill', 'cbTypePay', ParamStr) then if ParamStr <> '' then
  begin
    if ParamStr = '0' then  SQL := SQL + ' AND (IsNull(Прикрепление,0) = 0)'
      else SQL := SQL + ' AND (Прикрепление = 1)';
  end;
  if ParamsDMU.CheckCondition(Params, 'cbStatus',  'olStatus',  ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (СтатусОбъекта.Статус = ' + ParamStr + ')';
  if ParamsDMU.CheckCondition(Params, 'cbSumma',  'meSummaBegin', ParamStr) then if ParamStr <> '' then
  begin
    ParamStr := Trim(StringReplace(ParamStr, ',', '', MkSet(rfReplaceAll)));
    SQL := SQL + ' AND (Сумма >= ' + ParamStr + ')';
  end;
  if ParamsDMU.CheckCondition(Params, 'cbSumma',  'meSummaEnd',  ParamStr)  then if ParamStr <> '' then
  begin
    ParamStr := Trim(StringReplace(ParamStr, ',', '', MkSet(rfReplaceAll)));
    SQL := SQL + ' AND (Сумма <= ' + ParamStr + ')';
  end;
  if ParamsDMU.CheckCondition(Params, 'cbNumOrderPay', 'meNumOrderPay', ParamStr) then if ParamStr <> '' then
    SQL := SQL + ' AND (ДокНаИсхОплату.Номер = '''    + ParamStr + ''' and ДокНаИсхОплату.ВидДок = 7)'; //Распоряжение выплата
  if ParamsDMU.CheckCondition(Params, 'cbIDOrderPay', 'meIDOrderPay', ParamStr) then if ParamStr <> '' then
    SQL := SQL + ' AND (ДокНаИсхОплату = '        + ParamStr + ' and ДокНаИсхОплату.ВидДок = 7)'; //Распоряжение выплата
  if ParamsDMU.CheckCondition(Params, 'cbNumAllowance', 'meNumAllowance', ParamStr) then if ParamStr <> '' then
    SQL := SQL + ' AND (ДокНаИсхОплату.Номер = '''    + ParamStr + ''' and ДокНаИсхОплату.ВидДок = 8)'; //Служебная записка на списание
  if ParamsDMU.CheckCondition(Params, 'cbIDAllowance', 'meIDAllowance', ParamStr) then if ParamStr <> '' then
    SQL := SQL + ' AND (ДокНаИсхОплату = '        + ParamStr + ' and ДокНаИсхОплату.ВидДок = 8)'; //Служебная записка на списание
  if ParamsDMU.CheckCondition(Params, 'cbNumIn', 'meNumIn', ParamStr) then if ParamStr <> '' then
    SQL := SQL + ' AND (ВходящийНомер = '''    + ParamStr + ''')'; //Входящий номер.
  cbWasAvansPay       := ParamsDMU.ReadParam(Params, 'cbWasAvansPay',  'FALSE');
  cbNotMed       := ParamsDMU.ReadParam(Params, 'cbNotMed',  'FALSE');
  cbNotIns       := ParamsDMU.ReadParam(Params, 'cbNotIns',  'FALSE');
  if cbWasAvansPay = 'TRUE' then
  begin
    SQL := SQL + ' AND exists(select 1 from ДокНаИсхОплату d1 where d1.ВидДок = 7 and d1.СчетЛПУ = СчетЛПУ.ИДОбъекта and IsNull(d1.Сумма, 0) = 0) ' + CR +
                 ' AND exists(select 1 from ДокНаИсхОплату d1 where d1.ВидДок = 8 and d1.СчетЛПУ = СчетЛПУ.ИДОбъекта and IsNull(d1.Сумма, 0) > 0) ';
  end;
  if cbNotMed = 'TRUE' then
    SQL := SQL + ' AND exists(select 1 from ОказанныеУслуги d1 where d1.РеестрУслуг.СчетЛПУ = СчетЛПУ.ИДОбъекта and НеМедицинский = 1) ';
  if cbNotIns = 'TRUE' then
    SQL := SQL + ' AND exists(select 1 from ОказанныеУслуги d1 where d1.РеестрУслуг.СчетЛПУ = СчетЛПУ.ИДОбъекта and НеСтраховаяУслуга = 1) ';
  //Параметры Договора по счету
  //Даты Начала и окончания:
  if ParamsDMU.CheckCondition(Params, 'cbStartDate', 'dteStartDateN', ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДоговорЛПУ.ДатаНачала >= ''' + ParamStr + ''')';
  if ParamsDMU.CheckCondition(Params, 'cbStartDate', 'dteStartDateK', ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДоговорЛПУ.ДатаНачала <= ''' + ParamStr + ''')';
  if ParamsDMU.CheckCondition(Params, 'cbEndDate',   'dteEndDateN',   ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДоговорЛПУ.ДатаОкончания >= ''' + ParamStr + ''')';
  if ParamsDMU.CheckCondition(Params, 'cbEndDate',   'dteEndDateK',   ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДоговорЛПУ.ДатаОкончания <= ''' + ParamStr + ''')';
  // Регион ЛПУ
  if ParamsDMU.CheckCondition(Params, 'cbArea',   'olArea',     ParamStr) then if ParamStr <> '' then
    SQL := SQL + ' AND (ДоговорЛПУ.ЛПУ.Территория = ' + ParamStr +
                       ' OR ДоговорЛПУ.ЛПУ.Территория.РодительОбъекта = ' + ParamStr +
                       ' OR ДоговорЛПУ.ЛПУ.Территория.РодительОбъекта.РодительОбъекта = ' + ParamStr + ') ';
  //ЛПУ ЮЛ:
  if ParamsDMU.CheckCondition(Params, 'cbLPU',   'olLPU',       ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДоговорЛПУ.ЛПУ = ' + ParamStr + ')';
  //Метод расчета
  if ParamsDMU.CheckCondition(Params, 'cbMetod',   'olMetod',  ParamStr) then if ParamStr <> '' then SQL := SQL + ' AND (ДоговорЛПУ.МетодРасчета = ' + ParamStr + ')';
  if ParamsDMU.CheckCondition(Params, 'cbUseList',   'MEList',  ParamStr) then
  begin
    FilterNum     := '';
    FilterNumQ    := '';
    FilterNumAll  := '';
    FilterNumAllQ := '';
    ListA := TStringList.Create;
    ListA.Text := ParamStr;
    for i := 0 to ListA.Count - 1 do
    begin
      sFilter := Trim(ListA[i]);
      p := Pos(';', sFilter) - 1;
      if p = -1 then p := 1000;
      FilterNum := Copy(sFilter, 0, p);
      FilterNumQ := '''' + FilterNum + '''';
      if (FilterNumAll <> '') and (FilterNum <> '') then
      begin
        FilterNumAll  := FilterNumAll + ',';
        FilterNumAllQ := FilterNumAllQ + ',';
      end;
      if (FilterNum <> '') then
      begin
        FilterNumAll  := FilterNumAll + FilterNum;
        FilterNumAllQ := FilterNumAllQ + FilterNumQ;
      end;
    end;
    if (FilterNumAll <> '') or (FilterNumAllQ <> '') then
    begin
      rbList1       := ParamsDMU.ReadParam(Params, 'rbList1',  'FALSE');
      rbList2       := ParamsDMU.ReadParam(Params, 'rbList2',  'FALSE');
      rbList3       := ParamsDMU.ReadParam(Params, 'rbList3',  'FALSE');
      rbList4       := ParamsDMU.ReadParam(Params, 'rbList4',  'FALSE');
      rbList5       := ParamsDMU.ReadParam(Params, 'rbList5',  'FALSE');
      rbList6       := ParamsDMU.ReadParam(Params, 'rbList6',  'FALSE');
      rbList7       := ParamsDMU.ReadParam(Params, 'rbList7',  'FALSE');
      rbList8       := ParamsDMU.ReadParam(Params, 'rbList8',  'FALSE');
      rbList9       := ParamsDMU.ReadParam(Params, 'rbList9',  'FALSE');
      rbList10      := ParamsDMU.ReadParam(Params, 'rbList10',  'FALSE');
      rbList11      := ParamsDMU.ReadParam(Params, 'rbList11',  'FALSE');
      rbList12      := ParamsDMU.ReadParam(Params, 'rbList12',  'FALSE');
      rbList13      := ParamsDMU.ReadParam(Params, 'rbList13',  'FALSE');
      rbList14      := ParamsDMU.ReadParam(Params, 'rbList14',  'FALSE');
      if rbList1  = 'TRUE' then SQL := SQL + ' AND (ИДОбъекта in ( ' + FilterNumAll + '))' else
      if rbList2  = 'TRUE' then SQL := SQL + ' AND (Номер in ( ' + FilterNumAllQ + '))' else
      if rbList3  = 'TRUE' then SQL := SQL + ' AND (ДокНаИсхОплату.ВидДок = 7 and ДокНаИсхОплату.ИДОбъекта in ( ' + FilterNumAll + '))' else
      if rbList4  = 'TRUE' then SQL := SQL + ' AND (ДокНаИсхОплату.ВидДок = 7 and ДокНаИсхОплату.Номер in ( ' + FilterNumAllQ + '))'    else
      if rbList5  = 'TRUE' then SQL := SQL + ' AND (ДокНаИсхОплату.ВидДок = 8 and ДокНаИсхОплату.ИДОбъекта in ( ' + FilterNumAll + '))' else
      if rbList6  = 'TRUE' then SQL := SQL + ' AND (ДокНаИсхОплату.ВидДок = 8 and ДокНаИсхОплату.Номер in ( ' + FilterNumAllQ + '))'    else
      if rbList7  = 'TRUE' then SQL := SQL + ' AND (ЗаявлениеОбУбытке in ( ' + FilterNumAll + '))'                                      else
      if rbList8  = 'TRUE' then SQL := SQL + ' AND (ЗаявлениеОбУбытке.СтраховойАктВС in ( ' + FilterNumAll + '))'                       else
      if rbList9  = 'TRUE' then SQL := SQL + ' AND (СписаниеУбытковДСП in ( ' + FilterNumAll + '))'                                     else
      if rbList10 = 'TRUE' then SQL := SQL + ' AND (СписаниеУбытковДСП.ПлатежноеПоручение in ( ' + FilterNumAll + '))'                  else
      if rbList11 = 'TRUE' then SQL := SQL + ' AND (РеестрУслуг.ОказанныеУслуги.Убыток.ДогСтрах in ( ' + FilterNumAll + '))'            else
      if rbList12 = 'TRUE' then SQL := SQL + ' AND (РеестрУслуг.ОказанныеУслуги.Убыток.ДогСтрах.Номер in ( ' + FilterNumAllQ + '))'     else
      if rbList13 = 'TRUE' then SQL := SQL + ' AND (ДоговорЛПУ in ( ' + FilterNumAll + '))'            else
      if rbList14 = 'TRUE' then SQL := SQL + ' AND (ДоговорЛПУ.Номер in ( ' + FilterNumAllQ + '))';
      ;
    end;
  end;
  Result := SQL;
end;
   
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
  
*/ 
//======================================================================
/*
 
*/ 
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
 //======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/
//======================================================================
/*
 
*/ 