USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_CalculatePremium_Type]    Script Date: 10.01.2018 10:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	

/*drop table #PremCur
drop table #PremPrev

declare @IDIns     int,   --ИД Застрахованного.
	 @KolDayVar   int,      --Кол-во дней действия варианта у Застрахованного (Это именно ВариантДогСтрах, а не ВариантЗастрахованный!!!)
	 @DateCur     datetime, --Текущая дата расчета. Это дата начала допа, на котором расчитываем. Иди дата 01.01.1900 если расчет идет на дату Договора.
	 @DatePrev    datetime, --Дата предыдущего состояния. Это дата начала предыдущего допа (или Договора, если предыдущее состояние это и есть сам Договор.)
	 @UseUpdate   int,      --Создавать историчные состояния и обновлять премию в БД
	 @ResultTable int,      --Тестовый расчет одного застрахованного. Эта переменная должны быть =0, если расчет идет для более чем одного застрахованного.
	 @CountMonthToEnd int,  --Если до конца действия договора остается @CountMonthToEnd месяцев, то премию брать @PercentPrikToEnd процентов
	 @PercentPrikToEnd int, --Проценты по прикреплению, если до конца действия договора остается @CountMonthToEnd месяцев.
   @UseRVD int,           --Учитывать РВД при откреплении
   @UseLoss int,          --При откреплении учитывать убытки
   @UseContractKoef int,  --Использовать таблицу возрастных коэф. на реквизитах договора
   @UseEqualYears int,    --Не учитывать 29 февраля
   @UseRound int,         --Использовать алгоритм для коректировки округления.
   @VidDoc   int,         --Вид документа доп. соглашения (Пролонгация, Письмо на прикреп/откреп и т.д. , если = 0 значит это договор.) (Для расчета страховой суммы, для расчета премии не используется)
   @AID      int          --ИД Допсоглашения. (Для расчета страховой суммы, для расчета премии не используется)
   @PercentBack int 

 set @IDIns       = 748612
         set @KolDayVar   = 0
         set @DateCur     = '20140401 00:00:00'
         set @DatePrev    = '20140310 00:00:00'
         set @UseUpdate   = 1
         set @ResultTable = 1
         set @CountMonthToEnd = 3
         set @PercentPrikToEnd = 25
         set @UseRVD = 1
         set @UseLoss = 0
         set @UseContractKoef = 0
         set @UseEqualYears = 0
         set @UseRound = 0
         set @VidDoc = 12
         set @AID = 631316
         set @PercentBack = -1
*/



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spen_CalculatePremium_Type] 
	@IDIns     int,        --ИД Застрахованного.
	@KolDayVar   int,      --Кол-во дней действия варианта у Застрахованного (Это именно ВариантДогСтрах, а не ВариантЗастрахованный!!!)
	@DateCur     datetime, --Текущая дата расчета. Это дата начала допа, на котором расчитываем. Иди дата 01.01.1900 если расчет идет на дату Договора.
	@DatePrev    datetime, --Дата предыдущего состояния. Это дата начала предыдущего допа (или Договора, если предыдущее состояние это и есть сам Договор.)
	@UseUpdate   int,      --Создавать историчные состояния и обновлять премию в БД
	@ResultTable int,      --Тестовый расчет одного застрахованного. Эта переменная должны быть =0, если расчет идет для более чем одного застрахованного.
	@CountMonthToEnd int,  --Если до конца действия договора остается @CountMonthToEnd месяцев, то премию брать @PercentPrikToEnd процентов
	@PercentPrikToEnd int, --Проценты по прикреплению, если до конца действия договора остается @CountMonthToEnd месяцев.
  @UseRVD int,           --Учитывать РВД при откреплении
  @UseLoss int,          --При откреплении учитывать убытки
  @UseContractKoef int,  --Использовать таблицу возрастных коэф. на реквизитах договора
  @UseEqualYears int,    --Не учитывать 29 февраля
  @UseRound int,         --Использовать алгоритм для коректировки округления.
  @VidDoc   int,         --Вид документа доп. соглашения (Пролонгация, Письмо на прикреп/откреп и т.д. , если = 0 значит это договор.) (Для расчета страховой суммы, для расчета премии не используется)
  @AID      int,         --ИД Допсоглашения. (Для расчета страховой суммы, для расчета премии не используется)
  @PercentBack int = -1  --Используется для указания процента возврата для нетиповых договоров. Здесь (для типовых договоров) пока не используется, но может быть понадобится в будущем.
                         --В эту хранимку параметр включен также потому, что вызов spen_CalculatePremium_Type и spen_CalculatePremium_NotType должен происходить с одинаковвыми параметрами.
AS
BEGIN
--Тесты: IDIns 1446240 SD 10.07.2015   77050102-00286-00022  Ступка Тимур Альбертович    Открепление премия 792.4, возврат -25870.6.
--Тесты: IDIns 879561  SD 05.07.2015   63050101-00064-00090  Асташин Сергей Викторович   Открепление премия 2500, возврат 0.  
--Тесты: IDIns 879473  SD 02.09.2014   63050101-00064-00002  Алексеев Дмитрий Евгеньевич Открепление премия 808.22, возврат 4191.78. 
--Тесты: IDIns 1617727 SD 01.11.2015, должно быть 833,33.
--Тесты: IDIns 1572812 SD 15.12.2015   77050101-02566-08519  Хлыстова Евдокия Васильевна Открепление Изменение премии на периоде 11527 -520,21 премия 3213,13
--Тесты: IDIns 1842613 SD 25.01.2016 77050102-00397-00027    Жученко Александра Александровна Новая программа добавлена взамен старой на варинте. Премия 43912,01 Участвует в расчекте галка ProgNotUse. 

declare @HandChangePrem int -- Переменная показывающая что премия была изменена вручную и изменять её нельзя.
declare @days int --Вспомогательная переменная для определения кол-ва дней между датами
declare @yyyy int --Вспомогательная переменная для определения кол-ва лет между датами
declare @MethodCalcPrem   int --Метод расчета премии (0-по дням, 1-по месяцам)
declare @IDVarCur         int --ВариантЗастрахованныый текущий
declare @AlwaysCreateHist int --Если стоит 1, то создавать историчные значения на дату расчета всегда. 
                              --Если стоит 0, то создавать историчное значение только тогда когда есть отличие с предыдущим значением
declare @CountEqual1      int
declare @CountEqual2      int
declare @Operation        int --Операция на застрахованном. Нужно в виде отдельной переменной для алгоритма округления копеек, также 
                              --для ускорения расчета, чтобы не выполнять SQL запросы, которые не относятся к нужно операции.
declare @SumPercent       int --Поле чтобы отловить ситуацию когда галка "Предоплатная программа" стоит, но таблица процентовок не заполнена совсем.
                              --в этом случае будем считать что галка не стоит. Такая ситуация нужна (когда галка стоит, а таблица пустая) для
                              --того чтобы в каких то отчетах отображалось что программа предоплатная, но расчеты все равно осуществлялисьпо прежнему
                              --как будто галка не установлена.
declare @Loss             numeric(31,10) --Сумма убытков застрахованного                  
declare @SumPrem          numeric(31,10)
declare @InsEnd           datetime     
                             
set @AlwaysCreateHist = 1     --Устанавливаем по умолчанию, что не создаем историчные сосотяния, если нет отличия от предыдущего расчет а
set @UseContractKoef  = 1     --Использовать для расчета таблицу возрастных коэф. определенных на договоре. Сейчас пока отлючено всегда.
set @Operation        = 0     --Для ускорения расчета, чтобы не выполнять SQL запросы, которые не относятся к нужно операции.
set @Loss             = 0     --По умолчанию 0.

--set @UseRound = 1
--Это главные запрос. Из него получены следующие после них SQL запросы.
--SQL запросы менять нельзя. Только через изменение исходных MasterSQL запросов.
--При изменении нужно добавить INTO #PremCur, Далее заменить даты, далее заменить IDIns,
----заменить And (EOT_31.StateDate = (Select Max (StateDate) From RelContFace_Hist_FaceVariant Where (StateDate <= @DateCur) And (EOT_25.ID = ID)))
/*
--Данные на текущую датуИ
--Здесь Distinct нужен потому что могут быть задана процентовка, а затем убрана. Дублирование ID здесь может быть из-за процентовки.
Выбрать distinct  
  GetDate()       as DateCalc,
  ИДОбъекта       as ID,
  ПрограммаВариантДогСтрах                as IDProgram,
  ПрограммаВариантДогСтрах.ДогСтрах       as IDDog,
  ПрограммаВариантДогСтрах.ДогСтрах.ДатаНачала     as DogBeg,
  ПрограммаВариантДогСтрах.ДогСтрах.ДатаОкончания  as DogEnd,  
  Isnull(ПрограммаВариантДогСтрах.ДогСтрах.МетодРасчетаПремии, 0) as MethodCalcPrem,
  Isnull(ПрограммаВариантДогСтрах.ДогСтрах.РасчитыватьНеполныйПеродПоДням, 0) as FirstPeriodCalcByDays,
  Isnull(ПрограммаВариантДогСтрах.ДогСтрах.ПроцентПоПремии,    0) as RVDPrem,
  IsNull(ПрограммаВариантДогСтрах.Прикрепление,            0) as ProgramPercent,
  IsNull(ПрограммаВариантДогСтрах.Сумма,                   0) as ProgAmount,  --Поле информационное, при расчете не используется.
  IsNull(ПрограммаВариантДогСтрах.БезВозврата,             0) as WithoutPayBack,
  IsNull(ПрограммаВариантДогСтрах.БезРассрочки,            0) as WithoutTerm,
  IsNull(ПрограммаВариантДогСтрах.ВидСтрахРиска,           0) as VidRiska,
  IsNull(ПрограммаВариантДогСтрах.НеПрименятьВозрастКоэф,  0) as NoKoefAge,
  IsNull(ПрограммаВариантДогСтрах.НеПрименятьКоэфЗабол,    0) as NoKoefIll,
  IsNull(ПрограммаВариантДогСтрах.Процентовка,             0) as IDPercent,
  IsNull(ПрограммаВариантДогСтрах.Процентовка.Месяцев1,    0) as Month1,
  IsNull(ПрограммаВариантДогСтрах.Процентовка.Месяцев2,    0) as Month2,
  IsNull(ПрограммаВариантДогСтрах.Процентовка.Процент,     0) as Percent1,
  IsNull(ПрограммаВариантДогСтрах.НеУчВРасчетахИтого,      0) as NotCalcItogCur,
  ПрограммаВариантДогСтрах.СтрахПрог,                         as StProg,
  ОтношениеВариантЗастрахованныйПериодРассрочки                                             as IDRelVariantPeriod,
  
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах                     as Period,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах.ПериодНачисленияДогСтрах as AccrualPeriod,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах.ДатаНачала          as PeriodStart,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах.ДатаОкончания       as PeriodEnd,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах.КолвоДнейПериода    as KolDayPeriod,  
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах.НомерПериода        as NumPeriod,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах.КоличествоМесяцев   as Term,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах.КоличествоЛет       as NumYear,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПериодРассрочкиДогСтрах.КолвоМесяцевПериода as KolMonthPeriod,
    
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Премия                as VarCurPrem,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный        as IDIns,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Основание                               as IDReason,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ОснованиеОткрепления, 0)         as IDReasonOFF,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.Операция                 as Operation,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ДатаНачала               as InsStart ,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ДатаОкончания            as InsEnd,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.КоэффициентПоВозрасту    as KoefAge,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.КоэффициентПоЗаболеванию as KoefIll,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.Коэффициент              as Koef,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ФЛ.ДатаРождения          as BirthDate,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.РучноеИзменениеПремии, 0)  as HandChangePrem,
  
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.КоэффициентПоВозрасту    as KoefAgePrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.КоэффициентПоЗаболеванию as KoefIllPrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.Коэффициент              as KoefPrev,
  
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.Вариант.Наим            as IDVarNaim,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.ДатаНачала              as VarDogStart,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.ДатаОкончания           as VarDogEnd,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.ДатаНачала              as VarDogStartPrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.ДатаОкончания           as VarDogEndPrev,
  
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.Сумма                   as Amount,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.СуммаДМС                as AmountDMS,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.СуммаВЗР                as AmountVZR,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.СуммаНС                 as AmountNS,
  
  1234567890.1234567890                      as DiffPrem,     --Информационное поле показывающее разницу по сравнению с предыдущим расчетом премии... можно убрать совсем. На расчет не повлияет. Начисленная премия.
  1234567890.1234567890                      as DiffPremBack, --Информационное поле показывающее разницу по сравнению с предыдущим расчетом премии... можно убрать совсем. На расчет не повлияет. Премия к возврату.
  IsNull(Премия, 0)                          as Prem,         --Существующие значения на мемент расчета в БД. В принципе не используются, кроме как для вычисления DiffPrem.
  IsNull(ПремияКВозврату, 0)                 as PremBack,     --Существующие значения на мемент расчета в БД. В принципе не используются, кроме как для вычисления DiffPremBack.
  IsNull(ПрограммаВариантДогСтрах.Премия, 0) as ProgPrem,     --Премия по программе. Это из основнях полей для расчета.
  1234567890.1234567890                      as ProgPremPrev, --Премия по программе на дату предыдущего допа. 
  1234567890.1234567890                      as PremPrev,     --Значение премии на на дату предыдущего допа. 
  1234567890.1234567890                      as PremBackPrev, --Значение премии к возврату на на дату предыдущего допа. 
  1234567890.1234567890                      as MyPrem,       --Расчитанное значение премии без округления и внесения поправок. 
  1234567890.1234567890                      as MyPremBack,   --Расчитанное значение премии к возврату без округления и внесения поправок. 
  1234567890.1234567890                      as MyPremBack2,  --Премия к возврату. Вспомогательное поле для отлова копеек. 
  
  1234567890.1234567890                      as MyPremDMS,    --Это поле получается из MyPremRound для вида риска ДМС.
  1234567890.1234567890                      as MyPremVZR,    --Это поле получается из MyPremRound для вида риска ВЗР.
  1234567890.1234567890                      as MyPremNS,     --Это поле получается из MyPremRound для вида риска НС.
  1234567890.1234567890                      as MyPremSUM,    --Это MyPremDMS + MyPremVZR + MyPremNS. Это поле соответствует атрибуту Премия.  
  
  1234567890.1234567890                      as MyPremBackDMS,  --Это поле получается из MyPremBackRound для вида риска ДМС.
  1234567890.1234567890                      as MyPremBackVZR,  --Это поле получается из MyPremBackRound для вида риска ВЗР.
  1234567890.1234567890                      as MyPremBackNS,   --Это поле получается из MyPremBackRound для вида риска НС.
  1234567890.1234567890                      as MyPremBackSUM,  --Это MyPremBackDMS + MyPremBackVZR + MyPremBackNS 
  
  --Далее поля для алгоритма округления.
  --Далее поля для алгоритма округления Начисленная премия. Округление по MyPrem  (с цифрой 1)
  0                                          as RoundPeriodProgram1, --Округление по периодам. Программа в каждом периоде где премия > 0, на которую будем кидать копейки при округлении периорда. 
  0                                          as RoundYearPeriod1,    --Округление по годам.    Признак периода в году на который будем кидать копейки.
  0                                          as RoundYearProgram1,   --Округление по годам.    Признак программы в периоде для округления по годам.
  1234567890.1234567890                      as RoundRaznPeriod1,    --Округление по периодам. Помещается разница округления для алгоритма округления по периодам.
  1234567890.1234567890                      as RoundRaznYear1,      --Округление по годам.    Помещается разница округления для алгоритма округления по годам.  
  
  1234567890.1234567890                      as MyPremRound,     --Правильные значения премии после округления и внесения поправок. Именно из этого поля обнояются данные в БД. Это конечный результат расчета.
  1234567890.1234567890                      as MyPremBackRound, --Правильные значения премии после округления и внесения поправок. Именно из этого поля обнояются данные в БД. Это конечный результат расчета.

  
  1234567890.1234567890                      as MyPremVar,
  --Предыдущая премия по периодам рассрочки
  1234567890.1234567890                      as VarPremPrev,
  1234567890.1234567890                      as VarPremPrevDMS,
  1234567890.1234567890                      as VarPremPrevVZR,
  1234567890.1234567890                      as VarPremPrevNS,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный                              as IDVar,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный                              as IDVarCur,
  1234567890                                                                                       as IDVarPrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ДатаНачала    as InsStartPrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ДатаОкончания as InsEndPrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ДатаНачала                   as VarStartPrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ДатаОкончания                as VarEndPrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ДатаНачала                   as VarStartCur,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ДатаОкончания                as VarEndCur,

  1234567890             as KolMonthVar,      --Количество месяцев действия варианта.
  1234567890             as CurrentPeriod,    --Период расчета. Принимает значения 1,2,3. 1-период прошел. 2-текущий период, куда попадает дата начала допа. 3-период не наступил.
  1234567890             as KolDayIns,        --Количество дней действия страхования у застрахованного.
  1234567890             as KolDayInsRest,    --Количество дней от даты расчета до конца периода.
  1234567890             as KolMonthIns,      --Количество месяцев страхования у застрахованного.
  1234567890             as KolMonthInsRest,  --Количество месяцев от даты расчета до конца периода.
  1234567890.12          as MyRVDPrem,        
  365                    as KolDayVar,
  1234567890.12          as PercentPrik,
  1234567890.12          as TermPrev,
  1234567890.12          as TermPercent,
  1234567890.12          as TermPercentPrev,
  1234567890.1234567890  as Loss,
  123                    as Age,
  '20130801 00:00:00'    as StateDate,
  '20130801 00:00:00'    as DatePrev,
  'cur'                  as TypeDate,  
  1234567890.12          as AmountPrev,
  1234567890.12          as AmountPrevDMS,
  1234567890.12          as AmountPrevVZR,
  1234567890.12          as AmountPrevNS, 
  0                      as NotCalcItogPrev,  
  1234567890             as AID,        --ИД объекта доп. соглаения на котором считаем.
  1234567890             as VidDoc,     --ВидДок доп. соглаения на котором считаем.
  0                      as SameProg,   --Поле для проставления признака похожей программы
  0                      as ProgNotUse, --Признак что программа не имеет ЛПУ, поэтому для неё расчет премии будет = 0.
  'Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного' as FormulaPrem,
  'Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного' as FormulaDigitPrem,
  'Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного' as FormulaPremBack,
  'Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного' as FormulaDigitPremBack
  Из
    ОтношениеПрограммаСтрахованияПериодРассрочки
  где 1 = 1
    AND (ДатаСостОбъекта                                                                                     = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.Вариант.ДатаСостОбъекта  = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ДатаСостОбъекта                                       = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ДатаСостОбъекта                 = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ДатаСостОбъекта  = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.ДатаСостОбъекта = '20130801 00:00:00')
    AND (ПрограммаВариантДогСтрах.ДатаСостОбъекта                                                            = '20130801 00:00:00')
    AND (ПрограммаВариантДогСтрах.ДогСтрах.ДатаСостОбъекта                                                   = '20130801 00:00:00')
    AND (ПрограммаВариантДогСтрах.Премия > 0)
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный  = 472330)
 ORDER BY IDIns, PeriodStart, IDProgram
*/






--Данные на текущую дату
--drop table #PremCur
--drop table #PremPrev
--declare @DateCur datetime
--set @DateCur = '2013-12-30 00:00:00.000'
Select
Distinct
GetDate() "DateCalc",
EOT_1.RelVariantProgramCreditPeriodID "ID",
EOT_1.ContractVariantProgramID "IDProgram",
EOT_3.ContractID "IDDog",
EOT_11.StartDate "DogBeg",
EOT_10.EndDate "DogEnd",
IsNull(
EOT_7.methodcalcprem,
0) "MethodCalcPrem",
IsNull(
EOT_7.firstperiodcalcbydays,
0) "FirstPeriodCalcByDays",
IsNull(
EOT_7.PremPercent,
0) "RVDPrem",
IsNull(
EOT_3.Attach,
0) "ProgramPercent",
IsNull(
EOT_6.Amount,
0) "ProgAmount",
IsNull(
EOT_3.NoRest,
0) "WithoutPayBack",
IsNull(
EOT_3.NoCredit,
0) "WithoutTerm",
IsNull(
EOT_3.InsRiskTypeID,
2) "VidRiska",
IsNull(
EOT_3.NotFactorAge,
0) "NoKoefAge",
IsNull(
EOT_3.NotFactorIllness,
0) "NoKoefIll",
IsNull(
EOT_16.ID,
0) "IDPercent",
IsNull(
EOT_16.CountMonth1,
0) "Month1",
IsNull(
EOT_16.CountMonth2,
0) "Month2",
IsNull(
EOT_16.Pencent,
0) "Percent1",
IsNull(
EOT_5.NotCalcItog,
0) "NotCalcItogCur",
EOT_3.InsProgram "StProg",
EOT_1.RelFaceVariantCreditPeriodID "IDRelVariantPeriod",
EOT_17.ContractCreditPeriodID "Period",
EOT_19.DateStart "PeriodStart",
EOT_19.DateEnd "PeriodEnd",
EOT_19.PeriodDays "KolDayPeriod",
EOT_19.NumPeriod "NumPeriod",
EOT_19.MonthCount "Term",
EOT_19.YearCount "NumYear",
EOT_19.PeriodMonth "KolMonthPeriod",
EOT_19.ContractAccrualPeriodID "AccrualPeriod",
EOT_21.Prem "VarCurPrem",
EOT_20.FaceID "IDIns",
EOT_20.Reason "IDReason",
IsNull(
EOT_20.ReasonOFF,
0) "IDReasonOFF",
EOT_27.OperationType "Operation",
EOT_32.StartDate "InsStart",
EOT_34.EndDate "InsEnd",
EOT_29.FactorAge "KoefAge",
EOT_29.FactorIllness "KoefIll",
EOT_29.Factor "Koef",
EOT_35.BirthDate "BirthDate",
IsNull(
EOT_25.HandChangePrem,
0) "HandChangePrem",
EOT_29.FactorAge "KoefAgePrev",
EOT_29.FactorIllness "KoefIllPrev",
EOT_29.Factor "KoefPrev",
EOT_42.Name "IDVarNaim",
EOT_40.StartDate "VarDogStart",
EOT_41.EndDate "VarDogEnd",
EOT_40.StartDate "VarDogStartPrev",
EOT_41.EndDate "VarDogEndPrev",
EOT_38.Amount "Amount",
EOT_38.AmountDMS "AmountDMS",
EOT_38.AmountVZR "AmountVZR",
EOT_38.AmountNS "AmountNS",
1234567890.1234567890 "DiffPrem",
1234567890.1234567890 "DiffPremBack",
IsNull(
EOT_2.Prem,
0) "Prem",
IsNull(
EOT_2.RestPrem,
0) "PremBack",
IsNull(
EOT_5.Premium,
0) "ProgPrem",
1234567890.1234567890 "ProgPremPrev",
1234567890.1234567890 "PremPrev",
1234567890.1234567890 "PremBackPrev",
1234567890.1234567890 "MyPrem",
1234567890.1234567890 "MyPremBack",
1234567890.1234567890 "MyPremBack2",
1234567890.1234567890 "MyPremDMS",
1234567890.1234567890 "MyPremVZR",
1234567890.1234567890 "MyPremNS",
1234567890.1234567890 "MyPremSUM",
1234567890.1234567890 "MyPremBackDMS",
1234567890.1234567890 "MyPremBackVZR",
1234567890.1234567890 "MyPremBackNS",
1234567890.1234567890 "MyPremBackSUM",
0 "RoundPeriodProgram1",
0 "RoundYearPeriod1",
0 "RoundYearProgram1",
1234567890.1234567890 "RoundRaznPeriod1",
1234567890.1234567890 "RoundRaznYear1",
1234567890.1234567890 "MyPremRound",
1234567890.1234567890 "MyPremBackRound",
1234567890.1234567890 "MyPremVar",
EOT_17.FaceVariantID "IDVar",
EOT_17.FaceVariantID "IDVarCur",
1234567890 "IDVarPrev",
EOT_32.StartDate "InsStartPrev",
EOT_34.EndDate "InsEndPrev",
EOT_24.StartDate "VarStartPrev",
EOT_23.EndDate "VarEndPrev",
EOT_24.StartDate "VarStartCur",
EOT_23.EndDate "VarEndCur",
1234567890 "KolMonthVar",
1234567890 "CurrentPeriod",
1234567890 "KolDayIns",
1234567890 "KolDayInsRest",
1234567890 "KolMonthIns",
1234567890 "KolMonthInsRest",
1234567890.12 "MyRVDPrem",
365 "KolDayVar",
1234567890.12 "PercentPrik",
1234567890.12 "TermPrev",
1234567890.12 "TermPercent",
1234567890.12 "TermPercentPrev",
1234567890.1234567890 "Loss",
123 "Age",
@DateCur "StateDate",
@DateCur "DatePrev",
'cur' "TypeDate",
1234567890.12 "AmountPrev",
1234567890.12 "AmountPrevDMS",
1234567890.12 "AmountPrevVZR",
1234567890.12 "AmountPrevNS",
0             "NotCalcItogPrev", 
1234567890 "AID",
1234567890 "VidDoc",
1          "SameProg",  
0          "ProgNotUse",  
'Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного' "FormulaPrem",
'Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного' "FormulaDigitPrem",
'Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного' "FormulaPremBack",
'Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного Формула расчета премии, позволяющая определить каким образом расчитана премия для застрахованного' "FormulaDigitPremBack"
into #PremCur
From
RelVariantProgramCreditPeriod EOT_1
Left Outer Join RelVariantProgramCreditPeriod_Hist EOT_2 On (EOT_2.RelVariantProgramCreditPeriod_HistID = EOT_1.RelVariantProgramCreditPeriodID) And (EOT_2.StateDate = (Select Max (StateDate) From RelVariantProgramCreditPeriod_Hist Where (StateDate <= @DateCur) And (EOT_1.RelVariantProgramCreditPeriodID = RelVariantProgramCreditPeriod_HistID)))
Left Outer Join RelFaceVariantCreditPeriod EOT_17 On
EOT_17.RelFaceVariantCreditPeriodID
=
EOT_1.RelFaceVariantCreditPeriodID
Left Outer Join FaceVariant EOT_20
Left Outer Join FaceVariant_Hist_Prem EOT_21 On (EOT_21.ID = EOT_20.ID) And (EOT_21.StateDate = (Select Max (StateDate) From FaceVariant_Hist_Prem Where (StateDate <= @DateCur) And (EOT_20.ID = ID)))
Left Outer Join FaceVariant_Hist_EndDate EOT_23 On (EOT_23.ID = EOT_20.ID) And (EOT_23.StateDate = (Select Max (StateDate) From FaceVariant_Hist_EndDate Where (StateDate <= @DateCur) And (EOT_20.ID = ID)))
Left Outer Join FaceVariant_Hist_StartDate EOT_24 On (EOT_24.ID = EOT_20.ID) And (EOT_24.StateDate = (Select Max (StateDate) From FaceVariant_Hist_StartDate Where (StateDate <= @DateCur) And (EOT_20.ID = ID))) On
EOT_20.ID
=
EOT_17.FaceVariantID
Left Outer Join ContractVariant EOT_37
Left Outer Join ContractVariant_Hist_Amount EOT_38 On (EOT_38.ID = EOT_37.ID) And (EOT_38.StateDate = (Select Max (StateDate) From ContractVariant_Hist_Amount Where (StateDate <= @DateCur) And (EOT_37.ID = ID)))
Left Outer Join ContractVariant_Hist_StartDate EOT_40 On (EOT_40.ID = EOT_37.ID) And (EOT_40.StateDate = (Select Max (StateDate) From ContractVariant_Hist_StartDate Where (StateDate <= @DateCur) And (EOT_37.ID = ID)))
Left Outer Join ContractVariant_Hist_EndDate EOT_41 On (EOT_41.ID = EOT_37.ID) And (EOT_41.StateDate = (Select Max (StateDate) From ContractVariant_Hist_EndDate Where (StateDate <= @DateCur) And (EOT_37.ID = ID))) On
EOT_37.ID
=
EOT_20.ContractVariantID
Left Outer Join Variant EOT_42 On
EOT_42.ID
=
EOT_37.Variant_ID
Left Outer Join RelContFace EOT_25
Left Outer Join RelContFace_Hist_OperationType EOT_27 On (EOT_27.ID = EOT_25.ID) And (EOT_27.StateDate = (Select Max (StateDate) From RelContFace_Hist_OperationType Where (StateDate <= @DateCur) And (EOT_25.ID = ID)))
Left Outer Join RelContFace_Hist_Factor EOT_29 On (EOT_29.ID = EOT_25.ID) And (EOT_29.StateDate = (Select Max (StateDate) From RelContFace_Hist_Factor Where (StateDate <= @DateCur) And (EOT_25.ID = ID)))
Left Outer Join RelContFace_Hist_FaceVariant EOT_31 On (EOT_31.ID = EOT_25.ID) --And (EOT_31.StateDate = (Select Max (StateDate) From RelContFace_Hist_FaceVariant Where (StateDate <= @DateCur) And (EOT_25.ID = ID)))
Left Outer Join RelContFace_Hist_StartDate EOT_32 On (EOT_32.ID = EOT_25.ID) And (EOT_32.StateDate = (Select Max (StateDate) From RelContFace_Hist_StartDate Where (StateDate <= @DateCur) And (EOT_25.ID = ID)))
Left Outer Join RelContFace_Hist_EndDate EOT_34 On (EOT_34.ID = EOT_25.ID) And (EOT_34.StateDate = (Select Max (StateDate) From RelContFace_Hist_EndDate Where (StateDate <= @DateCur) And (EOT_25.ID = ID))) On
EOT_25.ID
=
EOT_20.FaceID
Left Outer Join FaceVariant EOT_43 On
EOT_43.ID
=
EOT_31.FaceVariant
Left Outer Join FacePerson EOT_35 On
EOT_35.FaceID
=
EOT_25.FaceID
Left Outer Join ContractCreditPeriod EOT_19 On
EOT_19.ContractCreditPeriodID
=
EOT_17.ContractCreditPeriodID
Left Outer Join ContractVariantProgram EOT_3
Left Outer Join ContractVariantProgram_Hist_Premium EOT_5 On (EOT_5.ID = EOT_3.ID) And (EOT_5.StateDate = (Select Max (StateDate) From ContractVariantProgram_Hist_Premium Where (StateDate <= @DateCur) And (EOT_3.ID = ID)))
Left Outer Join ContractVariantProgram_Hist_Amount EOT_6 On (EOT_6.ID = EOT_3.ID) And (EOT_6.StateDate = (Select Max (StateDate) From ContractVariantProgram_Hist_Amount Where (StateDate <= @DateCur) And (EOT_3.ID = ID))) On
EOT_3.ID
=
EOT_1.ContractVariantProgramID
Left Outer Join ContractVariantProgramPercent EOT_16 On
EOT_16.ContractVariantProgram = EOT_3.ID
Left Outer Join ContractIns EOT_7
Left Outer Join ContractIns_Hist_EndDate EOT_10 On (EOT_10.ID = EOT_7.CID) And (EOT_10.StateDate = (Select Max (StateDate) From ContractIns_Hist_EndDate Where (StateDate <= @DateCur) And (EOT_7.CID = ID)))
Left Outer Join ContractIns_Hist_StartDate EOT_11 On (EOT_11.ID = EOT_7.CID) And (EOT_11.StateDate = (Select Max (StateDate) From ContractIns_Hist_StartDate Where (StateDate <= @DateCur) And (EOT_7.CID = ID))) On
EOT_7.CID
=
EOT_3.ContractID
Where
1
=
1
AND
(
EOT_5.Premium
>
0)
AND
(
EOT_20.FaceID
=
@IDIns)
Order By
"IDIns"
,
"PeriodStart"
,
"IDProgram"

--select * from #PremCur

update #PremCur set 
  DiffPrem        = 0,
  DiffPremBack    = 0,
  ProgPremPrev    = 0,
  PremPrev        = 0,
  PremBackPrev    = 0,
  MyPrem          = 0,
  MyPremBack      = 0,
  MyPremBack2     = 0,
  MyPremDMS       = 0,
  MyPremVZR       = 0,
  MyPremNS        = 0,
  MyPremBackDMS   = 0,
  MyPremBackVZR   = 0,
  MyPremBackNS    = 0,
  IDVarPrev       = 0,
  CurrentPeriod   = 0,
  KolDayIns       = 0,
  KolDayInsRest   = 0,
  KolMonthIns     = 0,
  KolMonthInsRest = 0,
  AmountPrev      = 0,
  AmountPrevDMS   = 0,
  AmountPrevVZR   = 0,
  AmountPrevNS    = 0,  
  MyRVDPrem       = 1,
  KoefAgePrev     = 0,
  KoefIllPrev     = 0,
  KoefPrev        = 0,
  PercentPrik     = 0,
  TermPrev        = 0,
  TermPercent     = 1,
  TermPercentPrev = 1,
  FormulaPrem          = '',
  FormulaDigitPrem     = '',
  FormulaPremBack      = '',
  FormulaDigitPremBack = '',
  Loss            = 0,
  Age             = 0,
  MyPremSUM       = 0,
  MyPremBackSUM   = 0,
  MyPremRound     = 0,
  MyPremBackRound = 0,  
  RoundPeriodProgram1 = 0,
  RoundYearPeriod1    = 0,
  RoundYearProgram1   = 0,                                 
  RoundRaznPeriod1 = 0, --Округление по периодам. Помещается разница округления для алгоритма округления по периодам.
  RoundRaznYear1   = 0, --Округление по годам.    Помещается разница округления для алгоритма округления по годам.    
  AID             = @AID, 
  VidDoc          = @VidDoc 
     
  --Если риски больше чем 2,3,4 то:
  update #PremCur set #PremCur.VidRiska = t1.ParentInsRiskTypeID from
    (select InsRiskTypeID, ParentInsRiskTypeID from InsRiskType) t1
    where #PremCur.VidRiska = t1.InsRiskTypeID and #PremCur.VidRiska > 4

  --На всякий случай, например риск = 0 или 1.
  update #PremCur set VidRiska = 2 where VidRiska not in(2,3,4)


/*
--Данные на предыдущую дату
Выбрать
  ИДОбъекта                                                                                                   as ID,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ДатаНачала               as InsStart ,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ДатаОкончания            as InsEnd,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.КоэффициентПоВозрасту, 0)    as KoefAge,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.КоэффициентПоЗаболеванию, 0) as KoefIll,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.Коэффициент, 0)              as Koef,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.ДатаНачала              as VarDogStart,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.ДатаОкончания           as VarDogEnd,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.Сумма, 0)        as Amount,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.СуммаДМС, 0)     as AmountDMS,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.СуммаВЗР, 0)     as AmountVZR,
  IsNull(ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.СуммаНС, 0)      as AmountNS,
  IsNull(Премия, 0)                                                                                           as Prem,
  IsNull(ПремияКВозврату, 0)                                                                                  as PremBack,
  IsNull(ПрограммаВариантДогСтрах.Премия, 0)                                                                  as ProgPrem,
  IsNull(ПрограммаВариантДогСтрах.НеУчВРасчетахИтого,      0)                                                 as NotCalcItogPrev,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный                                         as IDVar,
  ОтношениеВариантЗастрахованныйПериодРассрочки.Премия                                                        as VarPrem,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияДМС                                                     as VarPremDMS,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияВЗР                                                     as VarPremVZR,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияНС                                                      as VarPremNS,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ДатаНачала                              as VarStart,
  ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ДатаОкончания                           as VarEnd
  Из
    ОтношениеПрограммаСтрахованияПериодРассрочки
  где 1 = 1
    --AND (ПрограммаВариантДогСтрах.Премия > 0)
    AND (ДатаСостОбъекта                                                                                     = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ДатаСостОбъекта                                       = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ДатаСостОбъекта                 = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.ДатаСостОбъекта  = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.ВариантДогСтрах.ДатаСостОбъекта = '20130801 00:00:00')
    AND (ПрограммаВариантДогСтрах.ДатаСостОбъекта                                                            = '20130801 00:00:00')
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный  =
         ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный.Вариант)
    AND (ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный.Застрахованный  = 490644)
 */
 
 
--Данные на предыдущую дату
--declare @DatePrev datetime
--declare @IDIns int
--set @DatePrev = '2013-09-01 00:00:00.000'
--set @IDIns = 778911
Select
EOT_1.RelVariantProgramCreditPeriodID "ID",
EOT_17.StartDate "InsStart",
EOT_19.EndDate "InsEnd",
IsNull(
EOT_14.FactorAge,
0) "KoefAge",
IsNull(
EOT_14.FactorIllness,
0) "KoefIll",
IsNull(
EOT_14.Factor,
0) "Koef",
EOT_23.StartDate "VarDogStart",
EOT_24.EndDate "VarDogEnd",
IsNull(
EOT_21.Amount,
0) "Amount",
IsNull(
EOT_21.AmountDMS,
0) "AmountDMS",
IsNull(
EOT_21.AmountVZR,
0) "AmountVZR",
IsNull(
EOT_21.AmountNS,
0) "AmountNS",
IsNull(
EOT_2.Prem,
0) "Prem",
IsNull(
EOT_2.RestPrem,
0) "PremBack",
IsNull(
EOT_27.Premium,
0) "ProgPrem",
IsNull(
EOT_27.NotCalcItog,
0) "NotCalcItog",
EOT_3.FaceVariantID "IDVar",
EOT_9.StartDate "VarStart",
EOT_8.EndDate "VarEnd"
into #PremPrev
From
RelVariantProgramCreditPeriod EOT_1
Left Outer Join RelVariantProgramCreditPeriod_Hist EOT_2 On (EOT_2.RelVariantProgramCreditPeriod_HistID = EOT_1.RelVariantProgramCreditPeriodID) And (EOT_2.StateDate = (Select Max (StateDate) From RelVariantProgramCreditPeriod_Hist Where (StateDate <= @DatePrev) And (EOT_1.RelVariantProgramCreditPeriodID = RelVariantProgramCreditPeriod_HistID)))
Left Outer Join ContractVariantProgram EOT_25
Left Outer Join ContractVariantProgram_Hist_Premium EOT_27 On (EOT_27.ID = EOT_25.ID) And (EOT_27.StateDate = (Select Max (StateDate) From ContractVariantProgram_Hist_Premium Where (StateDate <= @DatePrev) And (EOT_25.ID = ID))) On
EOT_25.ID
=
EOT_1.ContractVariantProgramID
Left Outer Join RelFaceVariantCreditPeriod EOT_3 On
EOT_3.RelFaceVariantCreditPeriodID
=
EOT_1.RelFaceVariantCreditPeriodID
Left Outer Join FaceVariant EOT_5
Left Outer Join FaceVariant_Hist_EndDate EOT_8 On (EOT_8.ID = EOT_5.ID) And (EOT_8.StateDate = (Select Max (StateDate) From FaceVariant_Hist_EndDate Where (StateDate <= @DatePrev) And (EOT_5.ID = ID)))
Left Outer Join FaceVariant_Hist_StartDate EOT_9 On (EOT_9.ID = EOT_5.ID) And (EOT_9.StateDate = (Select Max (StateDate) From FaceVariant_Hist_StartDate Where (StateDate <= @DatePrev) And (EOT_5.ID = ID))) On
EOT_5.ID
=
EOT_3.FaceVariantID
Left Outer Join ContractVariant EOT_20
Left Outer Join ContractVariant_Hist_Amount EOT_21 On (EOT_21.ID = EOT_20.ID) And (EOT_21.StateDate = (Select Max (StateDate) From ContractVariant_Hist_Amount Where (StateDate <= @DatePrev) And (EOT_20.ID = ID)))
Left Outer Join ContractVariant_Hist_StartDate EOT_23 On (EOT_23.ID = EOT_20.ID) And (EOT_23.StateDate = (Select Max (StateDate) From ContractVariant_Hist_StartDate Where (StateDate <= @DatePrev) And (EOT_20.ID = ID)))
Left Outer Join ContractVariant_Hist_EndDate EOT_24 On (EOT_24.ID = EOT_20.ID) And (EOT_24.StateDate = (Select Max (StateDate) From ContractVariant_Hist_EndDate Where (StateDate <= @DatePrev) And (EOT_20.ID = ID))) On
EOT_20.ID
=
EOT_5.ContractVariantID
Left Outer Join RelContFace EOT_10
Left Outer Join RelContFace_Hist_Factor EOT_14 On (EOT_14.ID = EOT_10.ID) And (EOT_14.StateDate = (Select Max (StateDate) From RelContFace_Hist_Factor Where (StateDate <= @DatePrev) And (EOT_10.ID = ID)))
Left Outer Join RelContFace_Hist_FaceVariant EOT_16 On (EOT_16.ID = EOT_10.ID) And (EOT_16.StateDate = (Select Max (StateDate) From RelContFace_Hist_FaceVariant Where (StateDate <= @DatePrev) And (EOT_10.ID = ID)))
Left Outer Join RelContFace_Hist_StartDate EOT_17 On (EOT_17.ID = EOT_10.ID) And (EOT_17.StateDate = (Select Max (StateDate) From RelContFace_Hist_StartDate Where (StateDate <= @DatePrev) And (EOT_10.ID = ID)))
Left Outer Join RelContFace_Hist_EndDate EOT_19 On (EOT_19.ID = EOT_10.ID) And (EOT_19.StateDate = (Select Max (StateDate) From RelContFace_Hist_EndDate Where (StateDate <= @DatePrev) And (EOT_10.ID = ID))) On
EOT_10.ID
=
EOT_5.FaceID
Where
1
=
1
AND
(
EOT_3.FaceVariantID
=
EOT_16.FaceVariant)
AND
(
EOT_5.FaceID
=
@IDIns)


--============================================================================
--Обновление текущих данных из предыдущих
UPDATE #PremCur SET
                   #PremCur.IDVarPrev           = #PremPrev.IDVar,
                   #PremCur.InsStartPrev        = #PremPrev.InsStart,
                   #PremCur.InsEndPrev          = #PremPrev.InsEnd,
                   #PremCur.VarStartPrev        = #PremPrev.VarStart,
                   #PremCur.VarEndPrev          = #PremPrev.VarEnd,

                   #PremCur.VarDogStartPrev     = #PremPrev.VarDogStart,
                   #PremCur.VarDogEndPrev       = #PremPrev.VarDogEnd,

                   #PremCur.ProgPremPrev        = #PremPrev.ProgPrem,
                   #PremCur.PremPrev            = #PremPrev.Prem,
                   #PremCur.PremBackPrev        = #PremPrev.PremBack,
                   #PremCur.KoefPrev            = #PremPrev.Koef,
                   #PremCur.KoefAgePrev         = #PremPrev.KoefAge,
                   #PremCur.KoefIllPrev         = #PremPrev.KoefIll,
                   #PremCur.AmountPrev          = #PremPrev.Amount,
				           #PremCur.AmountPrevDMS       = #PremPrev.AmountDMS,
 				           #PremCur.AmountPrevVZR       = #PremPrev.AmountVZR,
 				           #PremCur.AmountPrevNS        = #PremPrev.AmountNS,
 				           #PremCur.NotCalcItogPrev     = #PremPrev.NotCalcItog
                   FROM #PremPrev WHERE
                   #PremCur.ID = #PremPrev.ID
 --============================================================================                  
 --SELECT * INTO dbo.A_PremCurType2  FROM #PremCur
 
 --============================================================================   
--Если необходим расчет премии для расторжения договора, ещё до создания доп. соглашения на расторжение  
 IF (@ResultTable = 2) OR (@ResultTable = 3) --@ResultTable = 3 - Это тест расчета расторжения. В реальной работе не используется.
 BEGIN
   UPDATE #PremCur SET DogEnd    = @DateCur, 
                       InsEnd    = @DateCur-1, 
                       VarEndCur = @DateCur-1,
                       Operation = 2 
   WHERE (IDVar = IDVarCur)
 END
--============================================================================    
 
 --============================================================================
-- Проставляем кол-во дней действия страхования для застрахованных для каждого периода рассрочки
-- Для прикреплении, открпеления и др. (для всех действий)

--CurrentPeriod = 1 эти периоды уже прошли.
--CurrentPeriod = 2 это период на котором происходит действие допа.
--CurrentPeriod = 3 эти периоды ещё не наступили.

--Так как бывают ситуации, когда премия по программе или кооф. может измениться с некотого допа.
--То по дате начала варианта нельзя считать переходую точку.
--переходной период определяется по ДатеНачала допа - StateDate.
--Определяем переходную точку. - Это период в котором происходит изменение. CurrentPeriod = 2
  update #PremCur set CurrentPeriod = 1 where (StateDate > PeriodEnd)
  update #PremCur set CurrentPeriod = 2 where (StateDate >= PeriodStart) and (StateDate <= PeriodEnd)  
  update #PremCur set CurrentPeriod = 3 where (StateDate < PeriodStart)
  update #PremCur set CurrentPeriod = 2 where (YEAR(StateDate) = 1900) and (DogBeg = PeriodStart)
--============================================================================
 
 --============================================================================
--В зависимости от типа расчета MethodCalcPrem рассчитываем премию.
--поле MethodCalcPrem имеет одно значение во всей таблице #PremCur
--поэтому здесь top 1
--set @MethodCalcPrem = (
select top 1 @MethodCalcPrem = MethodCalcPrem, @Operation = Operation, @InsEnd = InsEnd from #PremCur 
--============================================================================
  
--============================================================================
--@Operation нужно для алгоритма округления копеек и ускорения расчета премии
--set @Operation  = (select top 1 Operation from #PremCur)
--============================================================================  
   
    
                  
--============================================================================
--Получение текущего варианта (ВариантЗастрахованный) и списка программ на дату расчета. В первом запросе не определить текущий вариант, так как 
--там снято ограничениt, вот это: --And (EOT_31.StateDate = (Select Max (StateDate) From RelContFace_Hist_FaceVariant
--Снято для того чтобы в таблицу попадали все варианты, так как нам нужно оба варианта - и предыдущий и текущий 
--по идее можно было бы просто поставить доп. условие в WHERE запроса выше, но почему то
--скорость выполнения запроса в этом случае падает почти вдвое, примерно на 0.4 сек.
--быстрее работает если получить список программ отдельным запросом и потом удалить лишние.
--Это запрос на MasterSQL 
  /* select Distinct Вариант, Вариант.ВариантДогСтрах.Содержимое.ПрограммаВариантДогСтрах as IDProgram 
     From Застрахованный
     where ИДОбъекта = 472330 and
           ДатаСостОбъекта = '20130801 00:00:00' and
           ISNULL(Вариант.ВариантДогСтрах.Содержимое.ПрограммаВариантДогСтрах.Депозит, 0) = 0 AND
           '20130801 00:00:00' between  Вариант.ВариантДогСтрах.Содержимое.ДатаПрикрепления and
           ISNULL(Вариант.ВариантДогСтрах.Содержимое.ДатаОткрепления, '20130801 00:00:00')  
  */


 Select
  Distinct
  EOT_7.FaceVariant,            --Текущий ВариантЗастрахованный
  EOT_21.ContractVariantProgram --Программы ВариантДогСтрах
  into #VarAndProgCur
From
  RelContFace EOT_1
  Left Outer Join RelContFace_Hist_FaceVariant EOT_7
    On (EOT_7.ID = EOT_1.ID) And (EOT_7.StateDate = (
      Select
        Max(StateDate)
      From
        RelContFace_Hist_FaceVariant
      Where
        (StateDate <= @DateCur) And (EOT_1.ID = ID)
    ))
  Left Outer Join FaceVariant EOT_11
    On EOT_11.ID = EOT_7.FaceVariant
  Left Outer Join ContractVariant EOT_16
    On EOT_16.ID = EOT_11.ContractVariantID
  Left Outer Join ContractVariantContent EOT_21
    On EOT_21.Rel_ContractVariant = EOT_16.ID
  Left Outer Join ContractVariantProgram EOT_22
    On EOT_22.ID = EOT_21.ContractVariantProgram
Where
  EOT_1.ID = @IDIns and IsNull(EOT_22.Deposit, 0)
  = 0 AND @DateCur between EOT_21.DateStart and IsNull(EOT_21.DateEnd, @DateCur)
 
 
 --Проставление текущего варианта
 select top 1 @IDVarCur = FaceVariant from #VarAndProgCur
 update #PremCur set IDVarCur = @IDVarCur 
 
 update #PremCur set ProgNotUse = 1 where IDVar = IDVarCur and IDProgram not in (select ContractVariantProgram from #VarAndProgCur)
 --Удаление программ, в текущем варианте, которые не должны учавствовать в расчете, т.к. были откреплены ранее.
 --delete from #PremCur where IDVar = IDVarCur and IDProgram not in (select ContractVariantProgram from #VarAndProgCur)
--============================================================================
 

 
--============================================================================
 --Далее удаляем все варианты, кроме текущего и предыдущего
-- Удаляем варианты не нужные для вычисления .
-- Нас интересует только текущий вариант и предыдущий вариант.
-- Если застрахованный менял вариант например 10 раз, то все остальные варианты - по ним изменений нет никаких,
-- Расчетов не проводится, поэтому эти 8 вариантов удаляются.
-- Нужны только последниые два - текущий и предыдущий.
-- Установка по умолчанию если ничео нет.
  Delete from #PremCur where (IDVar <> IDVarCur) and (IDVar <> IDVarPrev)
--============================================================================

--============================================================================ 
--Если операция замены варианта и эта замена произошла не на данном допе, то удаляем предыдущий вариант. 
  Delete from #PremCur where (IDVar <> IDVarCur) and (Operation = 3) AND (IDReasonOFF <> @AID)
--============================================================================ 

--============================================================================ 
--Код закоментирован так как проблема тут в том что действительно по тем периодам которые прошли мы ничего не рассчитываем, но
--нам нужно знать сколько начислено в предлыдущих периодах для того чтобы посчитать итоговую премию по варианту.
--Поэтому этот код включать не нужно.

--Удаляем записи по тем периодам, которые прошли. 
 --Delete from #PremCur where (CurrentPeriod = 1)
--============================================================================ 

--============================================================================
--Если у нас просто изменение премии на варианте, а Операция стоит Замена варианта. 
--Тогда все алгоритмы должны работатьб как Прикрепление   
update #PremCur set Operation = 1, @Operation = 1 where Operation = 3 and not exists (select 1 from #PremCur where IDVar <> IDVarCur)
--============================================================================ 

 --===========================================================================
 --Если выставлена галка одинаковый расчет високосных годов и обычных, то
 --в том периоде куда попадает 28.02.YYYY года окончания периода,  уменьшается кол-во дней на 1.
 --если этот год високосный.
 IF (@UseEqualYears = 1) 
 BEGIN
   set DATEFORMAT ymd
   update #PremCur  set 
   PeriodEnd = PeriodEnd - 1, 
   KolDayPeriod = KolDayPeriod - 1 
   where
     --Это цикл в dbo.fn_CheckPeriodVisokYear по всем дням и это не очень хорошо, т.к. медленно работает.
     (KolDayPeriod > 1) and dbo.fn_CheckPeriodVisokYear(PeriodStart, PeriodEnd) = 1    
     --Дата YYYY-28-02 существует в любом году - эта строчка безопасна для выполнения.
     --К сожалению это не решение, так как если   PeriodStart - не високосный и  PeriodEnd тоже не высокосный, а между ними высокосный, то не сработает код.
     --Это будет если договор действует например 3 года, 1 и 3 не высокосный, а 2 високосный.    
     --and ((CONVERT(date, (CAST(YEAR(PeriodStart) as varchar(4)) + '-02-28'), 23) between PeriodStart and PeriodEnd) or
     --     (CONVERT(date, (CAST(YEAR(PeriodEnd) as varchar(4)) + '-02-28'), 23) between PeriodStart and PeriodEnd))          
     --and (ISDATE(CAST(YEAR(PeriodEnd) as varchar(4)) + '-02-29 00:00:00.000') = 1) --здесь если Дата 02-29 сществует, то ISDATE = 1  
 END
 
--============================================================================   
 
 
--============================================================================  
--Расчет коэффициентов. 
IF (@UseContractKoef = 1) AND (@Operation in (1,5)) 
BEGIN 
  --Проставление возраста Застрахованного, как кол-во лет между BirthDate и PeriodStart
  --В MSSQL нет функции позволяющей вычислить кол-во лет, между датами, поэтому как то так...
  --Здесь возраст вычисляется как разница между ДР и датой начала страхования застрахованного (т.е. датой Прикрепления)
  /*UPDATE #PremCur  
  SET Age = (CASE 
               WHEN MONTH(InsStart) >= MONTH(BirthDate) AND DAY(InsStart) >= DAY(BirthDate) THEN YEAR(InsStart) - YEAR(BirthDate) 
               WHEN MONTH(InsStart) > MONTH(BirthDate) THEN YEAR(InsStart) - YEAR(BirthDate) 
               ELSE (YEAR(InsStart) - YEAR(BirthDate) - 1) 
             END)

  --Если на застрахованном не указан коэф. по возрасту (он равен по умолчанию 1) то если на договоре 
  --определены возрастные коэф.-ты то выставляем возрастной коэф. с договора.
  UPDATE #PremCur SET KoefAge = ContractAgeCoefficient.Coef, KoefAgePrev = ContractAgeCoefficient.Coef  
  FROM ContractAgeCoefficient
  WHERE ContractInsID = IDDog AND Age BETWEEN ContractAgeCoefficient.StartAge AND ISNULL(ContractAgeCoefficient.EndAge, 1000) AND KoefAge = 1
  */
  UPDATE #PremCur SET Koef = KoefAge WHERE KoefAge > Koef 
  UPDATE #PremCur SET Koef = 1 WHERE NoKoefAge = 1  
  
  UPDATE #PremCur SET KoefPrev = Koef         
END
--============================================================================


--============================================================================
--Смысл следующего ограничения в том, что если от допа к допу ничего в не изменилось, а именно: 
--1. Премия страховых программ
--2. Страховая сумма программ (если это не допс по пролонгации! Потому что по пролонгации нужно увеличивать страховую сумму.)
--3. Коэффициенты на застрахованном.
--то НИЧЕГО рассчитывать не нужно, и никаких изменений в БД вносить не нужно.
--Это все если 
--Список полей:
--1. Премия страховых программ: ProgPrem, ProgPremPrev.
--2. Страховая сумма программ: Amount, AmountPrev
--3. Коэффициенты на застрахованном: Koef, KoefIll, KoefAge, KoefPrev, KoefIllPrev, KoefAgePrev.
IF (@VidDoc <> 16) AND (@ResultTable <> 2)
BEGIN
  SELECT @CountEqual1 = count(*) FROM #PremCur WHERE 
  (ProgPrem = ProgPremPrev) AND
  (Amount = AmountPrev)     AND
  (Koef = KoefPrev)         AND
  (KoefAge = KoefAgePrev)   AND
  (KoefIll = KoefIllPrev)   AND
  (IDReason <> @AID)        AND
  (IDReasonOFF <> @AID)     
  SELECT @CountEqual2 = Count(*) from #PremCur
  IF @CountEqual1 = @CountEqual2 
  BEGIN
    --EXEC  spen_DeleteHist @IDIns, 0, 1, 1, 1, 1, @DateCur
    SELECT 'Расчет отменён т.к. на данное состояние договора никакая операция с застрахованным не проведена, премия по варианту и коэф. не изменены.' as Result  
    RETURN
  END
END


IF ((@InsEnd <= @DateCur) and (@Operation in(1,3,5)))
BEGIN
   SELECT 'Расчет отменён т.к. на данное состояние договора у застрахованного кончился срок страхования.' as Result  
   RETURN
END
--============================================================================







--============================================================================
--Признак ручного изменения премии на засстрахованном.
--Если премия была изменена вручную, то её автоматически не обновляем.
--Пока функционал отключен
--set @HandChangePrem = (select top 1 HandChangePrem from #PremCur)
--============================================================================

--============================================================================
--Если расчет по дням
--всего может быть 4 варианта
--Сколько дней застрахованный застрахован в периоде.
--DateDiff - это функция вычитания дат в MSSQL, y-день, m-месяц
--VarIns.        |--------|
--DatePeriod.          |-----------------|
  update #PremCur set KolDayIns = DateDiff(y, PeriodStart, VarEndCur) + 1 where  (VarStartCur <= PeriodStart) and (VarEndCur <= PeriodEnd)

--VarIns.            |--------|
--DatePeriod.     |-----------------|
  update #PremCur set KolDayIns = DateDiff(y, VarStartCur, VarEndCur) + 1 where (VarStartCur >= PeriodStart) and (VarEndCur <= PeriodEnd)

--VarIns.               |-------------|
--DatePeriod.       |------------|
  update #PremCur set KolDayIns = DateDiff(y, VarStartCur, PeriodEnd) + 1 where (VarStartCur >= PeriodStart) and (VarEndCur >= PeriodEnd) 

--VarIns.        |---------------------|
--DatePeriod.           |-----------|
  update #PremCur set KolDayIns = DateDiff(y, PeriodStart, PeriodEnd) + 1 where (VarStartCur <= PeriodStart) and (VarEndCur >= PeriodEnd)
  
  
  --KolDayInsRest - количество дней от ДатыНачала допа(это дата на которую производится расчет) до конца страхования в ТЕКУЩЕМ периоде
  --Пример:
  --DatePeriod.     |-----------------|
  --KolDayIns       |----------------|
  --KolDayInsRest       |------------|
  --Дата начала KolDayInsRest - это всегда StateDate, дата окончания чаще всего - это конец периода.
  --KolDayIns - это срок страхования в периоде у застрахованного.
  --В принципе можно оставить что-то одно или KolDayIns или KolDayInsRest, потому что KolDayIns используется в перодах CurrentPeriod = 3,
  --KolDayInsRest используется в периоде CurrentPeriod = 2. а CurrentPeriod = 1 вообще нигде не используется.
  update #PremCur set KolDayInsRest = DateDiff(y, StateDate, PeriodEnd) + 1 where (CurrentPeriod = 2) --AND (VarEndCur >= PeriodEnd) --AND (IDVar = IDVarCur)
  update #PremCur set KolDayInsRest = DateDiff(y, DogBeg, PeriodEnd) + 1 where (CurrentPeriod = 2)  AND (YEAR(StateDate) = 1900) --AND (VarEndCur >= PeriodEnd) --AND (IDVar = IDVarCur)

 
  --update #PremCur set KolDayInsRest = DateDiff(y, StateDate, VarEndCur) + 1 where (CurrentPeriod = 2) --AND (VarEndCur < PeriodEnd)  --AND (IDVar = IDVarCur)
  
  --update #PremCur set KolDayInsRest = DateDiff(y, StateDate, PeriodEnd) + 1 where (CurrentPeriod = 2) AND (VarEndPrev >= PeriodEnd) AND (IDVar = IDVarPrev)
  --update #PremCur set KolDayInsRest = DateDiff(y, StateDate, VarEndPrev) + 1 where (CurrentPeriod = 2) AND (VarEndPrev < PeriodEnd) AND (IDVar = IDVarPrev)

  --На всякий случай чтобы не было ошибки. Премия с минусом это тоже конечно неправильно, но по крайне мере минус сразу бросается в глаза и ясно что премия рассчитана неправильно.
  --KolDayIns может быть равен 0 когда даты стоят на варианте неправильно. И минус нужен для того чтобы проще было увидеть что что-то не так с исходными данными.
  update #PremCur set KolDayIns     = 0  where KolDayIns     < 0 and CurrentPeriod in(1,3)
  update #PremCur set KolDayIns     = -1 where KolDayIns     < 0 and CurrentPeriod = 2  
  
  update #PremCur set KolDayInsRest = 0  where KolDayInsRest < 0 
  --update #PremCur set KolDayIns     = KolDayInsRest  where KolDayIns     < 0 and KolDayInsRest > 0
  
  
  --update #PremCur set KolDayInsRest = 0  where KolDayInsRest < 0 and CurrentPeriod = 3 

  
--Период действия варианта. Если в параметре передан 0, то используем период варианта застрахованного.
--К этому моменту 365 уже записано в колонке #PremCur.KolDayVar
  update #PremCur set KolDayVar = @KolDayVar where @KolDayVar > 0 and @KolDayVar <> 365
  --update #PremCur set KolDayVar = DateDiff(y, VarDogStart, VarDogEnd) + 1 where @KolDayVar = 0 and (VarDogStart is not null)
  
 --Если на программе процентовка, то KolDayIns и KolDayVar, KolDayInsRest нужно поставить = 1, т.к. премия в этом случае будет не зависить от количества дней действия застрахованного
--это множители в формуле расчета
--Второе условие (...and KolDayIns > 0) нужно потому что может быть ситуация, когда срок действия варианта застрахованный вообще не распрастраняется на период, и если там будет =1
--то премия посчитается, и это будет ошибкой.
  update #PremCur set KolDayIns     = 1  where IDPercent > 0 and KolDayIns > 0 and Operation in(1,3,5)
  update #PremCur set KolDayInsRest = 1  where IDPercent > 0 and KolDayInsRest > 0 and Operation in(1,3,5)
  update #PremCur set KolDayVar     = 1  where IDPercent > 0 and KolDayVar > 0 and Operation in(1,3,5)
--============================================================================


--============================================================================
IF @MethodCalcPrem = 1
BEGIN
  --Если расчет по месяцам
  --Это простое округление до целого. Пример: 1.995456 должно = 2 или 0.995456 должно = 1 или 2.015456 должно = 2.  Проще не получается: 
  --Было: update #PremCur set KolMonthVar = DateDiff(m, VarDogStart, VarDogEnd) + 1
  update #PremCur set KolMonthVar = 12 --(ROUND((DateDiff(y, VarDogStart, VarDogEnd)  * 12.1234) / (30 * 12.1234) / 10, 1)) * 10 

  --Сколько месяцев застрахованный застрахован в периоде.
  --DateDiff - это функция вычитания дат в MSSQL, y-день, m-месяц
  --К сожалению реально функция DateDiff не вычисляет кол-во месяцев, а лишь количество переходов через границу месяца.
  --например между датами 30.09.2010 и 02.10.2010 - эта функция вернет 1 мес. хотя всего прошло 3 дня.
  
  --Было: update #PremCur set KolMonthIns = DateDiff(m, PeriodStart, VarEndCur) + 1 where  (VarStartCur <= PeriodStart) and (VarEndCur <= PeriodEnd)
  --update #PremCur set KolMonthIns = (ROUND((DateDiff(y, PeriodStart, VarEndCur) * 12.1234) / (30 * 12.1234) / 10, 1)) * 10 where  (VarStartCur <= PeriodStart) and (VarEndCur <= PeriodEnd)

  --Было: update #PremCur set KolMonthIns = DateDiff(m, PeriodStart, PeriodEnd) + 1 where (VarStartCur <= PeriodStart) and (VarEndCur >= PeriodEnd)
  --update #PremCur set KolMonthIns = (ROUND((DateDiff(y, PeriodStart, PeriodEnd) * 12.1234) / (30 * 12.1234) / 10, 1)) * 10 where (VarStartCur <= PeriodStart) and (VarEndCur >= PeriodEnd)
  update #PremCur set KolMonthIns = (ROUND((DateDiff(y, PeriodStart, PeriodEnd + 1) * 12.1234) / (30 * 12.1234) / 10, 1)) * 10 -- where  (VarStartCur <= PeriodStart) and (VarEndCur <= PeriodEnd)
 
  
  --KolDayMonthRest - количество месяцев от ДатыНачала допа до конча ТЕКУЩЕГО периода, в котором происходит расчет.  
  --Было: update #PremCur set KolMonthInsRest  = DateDiff(m, StateDate, PeriodEnd) + 1 where (CurrentPeriod = 2) AND (VarEndPrev >= PeriodEnd)
  --update #PremCur set KolMonthInsRest = (ROUND((DateDiff(y, StateDate, PeriodEnd) * 12.1234) / (30 * 12.1234) / 10, 1)) * 10 where (CurrentPeriod = 2) AND (VarEndPrev >= PeriodEnd)

  --Было: update #PremCur set KolMonthInsRest = DateDiff(m, StateDate, VarEndPrev) + 1 where (CurrentPeriod = 2) AND (VarEndPrev < PeriodEnd)
  --update #PremCur set KolMonthInsRest = (ROUND((DateDiff(y, StateDate, VarEndPrev) * 12.1234) / (30 * 12.1234) / 10, 1)) * 10 where (CurrentPeriod = 2) AND (VarEndPrev < PeriodEnd)
  --Застр. 1617727 StatDate 01.11.2015, должно быть 833,33.
   
  update #PremCur set KolMonthInsRest = (ROUND((DateDiff(y, StateDate, PeriodEnd + 1) * 12.1234) / (30 * 12.1234) / 10, 1)) * 10 where (YEAR(StateDate) > 1900) --where (CurrentPeriod = 2) AND (VarEndPrev < PeriodEnd)  
  update #PremCur set KolMonthInsRest = (ROUND((DateDiff(y, DogBeg, PeriodEnd + 1) * 12.1234) / (30 * 12.1234) / 10, 1)) * 10 where (YEAR(StateDate) = 1900) 
  
  --========================================================================== 
   
  --На всякий случай чтобы не было ошибки. Премия с минусом это тоже конечно неправильно
  update #PremCur set KolMonthIns     = -1  where KolDayIns     = 0 and CurrentPeriod in(1,2) 
  update #PremCur set KolMonthInsRest = -1  where KolDayInsRest = 0 and CurrentPeriod in(1,2) 

  --Период действия варианта. Если в параметре передан 0, то используем период варианта застрахованного.
  --update #PremCur set KolMonthVar = @KolDayVar where @KolDayVar > 0
  --update #PremCur set KolMonthVar = DateDiff(m, VarDogStart, VarDogEnd) + 1 where @KolDayVar = 0    

  --Если на программе процентовка, то KolDayIns и KolDayVar, KolDayInsRest нужно поставить = 1, т.к. премия в этом случае будет не зависить от количества дней действия застрахованного
  --это множители в формуле расчета
  update #PremCur set KolMonthIns     = 1  where IDPercent > 0 and KolMonthIns > 0
  update #PremCur set KolMonthInsRest = 1  where IDPercent > 0 and KolMonthInsRest > 0
  update #PremCur set KolMonthVar     = 1  where IDPercent > 0 and KolMonthVar > 0
END  
--============================================================================


 
--============================================================================
-- Выставляем процент по периодам для программ с процентовкой.
-- данный запрос ТОЛЬКО для программ с процентовкой.
-- TermPercent определяет процент по программе с процентовкой.
-- Для программ у которых процентовки нет TermPercent = 1.
  SELECT @SumPercent = SUM(Percent1) FROM #PremCur
  IF @SumPercent > 0 
  BEGIN
    UPDATE #PremCur SET FormulaPrem = FormulaPrem + 'TP1;', TermPercent = 0 WHERE IDPercent > 0

    --У нас всегда на любом застрахованном будут все периоды рассрочек договора, независимо от того в каком периоде застрахованный прикрепился.
    --Хоть в последнем - это неважно, записи в БД создаются для каждого застрахованного для всех
    --периодов рассрочки договора, но премия на всех периодах где он не был застрахован будет = 0.
    --Term рассчитывается для всех периодов сначала.

    -- Если на програмее указан признак "Без рассрочки", то мы берем всю премию по программе в первом периоде единовременно, на остальных периодах берем ставим 0.
    -- В этом случае проценты доложны идти по возрастающей. Если все действие договора разделить на года по 12 мес. то кол-во месяце означает
    -- кол-во месяце прошедшее с начала действия договора. Новый год действия договора начинается опять с 1.
    -- 1-3:   100%
    -- 4-6:   75%
    -- 7-9:   50%
    -- 10-12: 25%

    -- Если на програмее НЕ указан признак "Без рассрочки", то проценты должны быть например вот такие. Это означает что
    -- брать два раза в год по 50%.
    -- 1-6:   50%
    -- 7-12:  50%
    -- Если на програмее НЕ указан признак "Без рассрочки" и проценты указаны вот так, то это тоже самое что если бы признак "Без рассрочки" был указан - все равно
    -- премия возьмется один раз в год при прикреплении все 100%. (И последующие года в первый период рассрочки). За тем исключением
    -- что даже если до конца действия договора остается например 1 мес, премия возьмется все 100%.
    -- 1-12:  100%.

    --==== Если галка "БЕЗ рассрочки" стоит ====:
    -- Чтобы брать премию один раз в год.
    --Нужно брать премию для программ с процентовкой без рассрочки для тех периодов,
    --где NumPeriod = 1 и застрахованный был застрахован на каком то из предыдущихъ периодов.
    UPDATE #PremCur SET FormulaPrem = FormulaPrem + 'TP2;', TermPercent = (Percent1 / 100) WHERE
      (Percent1 > 0)                 and
      (TermPercent = 0)              and
      (WithoutTerm = 1)              and
      (CurrentPeriod = 2)            and  -- Берём премию в текущем периоде-
      --(VarStartCur <= PeriodStart)   and --Было InsStart
      (Term >= Month1)               and
      (Term <= Month2)               and
      (CurrentPeriod > 1)            and
      (IDPercent > 0)



    --Если в договоре уже существовала другая программа с процентовкой и по ней уже была взята премия на одном из предыдущих периодов, то
    --Повторный пересчет на застрахованном, когда операции нет, а лишь изменился вариант по договору (например добавилась какая то программа)
    --приведет в повторному взятию премии. Поэтому тут проверяется по каким программам в предыдущих периодах была посчитана премия, 
    --и это все записывается в таблицу @TablePrevPremExists. После этого по таким программам выставляется TermPercent = 0. 
    --По сути это костыль и работает он не для всех случаев. И это по любому аукнется в будущем. Как сделать лучше пока что-то придумать не могу.
    DECLARE @TablePrevPremExists TABLE (IDProgram2 INT, IDPeriod2 INT, PrevPremExists INT)
    INSERT INTO  @TablePrevPremExists
      SELECT IDProgram AS IDProgram2, Period AS IDPeriod2,
        (SELECT top 1 1 FROM #PremCur p2 WHERE 
              p2.IDProgram = p1.IDProgram
          AND p2.Period < p1.Period 
          AND p2.PremPrev > 0
          AND p2.IDPercent > 0) AS PrevPremExists
      FROM #PremCur p1  
   
   UPDATE #PremCur SET TermPercent = 0 FROM @TablePrevPremExists t2 
     WHERE Operation not in(2,4) AND 
       (IDProgram = t2.IDProgram2) AND 
       (Period = t2.IDPeriod2)     AND 
       (t2.PrevPremExists = 1)     AND
       (IDPercent > 0)
   
   
    -- ИЛИ
    --В периоде в который попадает ДатаНачала страхования застрахованного.
    --UPDATE #PremCur SET TermPercent = (Percent1 / 100) WHERE
    --(Percent1 > 0)                   and
    --(TermPercent = 0)                and
    --(WithoutTerm = 1)                and
    --(InsStart >= PeriodStart)        and
    --(InsStart <= PeriodEnd)          and
    --(Term >= Month1)                 and
    --(Term <= Month2)


    --==== Если галка БЕЗ рассрочки НЕ стоит ====:
    --Нужно брать премию столько раз в год, сколько строк в таблице процентовки:
    --На номере периода, который равен Month1.
    --Например у нас ситуация
    -- 1-6:   50%
    -- 7-12:  50%
    --где премия будет начисляться в 1-ый и 7-ой месяца.
    --Второе условие Term должен входить в указанный период Month1 и Month2.
    --Потому что у нас в исходной таблице Prem
    --Процентовка выводится полностью для в каждом периоде.
    UPDATE #PremCur SET FormulaPrem = FormulaPrem + 'TP3;', TermPercent = (Percent1 / 100) WHERE
    (Percent1 > 0)                  and
    --(TermPercent = 0)               and
    (WithoutTerm = 0)               and
    --(NumPeriod = Month1)            and
    (VarStartCur <= PeriodStart)    and  --Было InsStart
    (Term >= Month1)                and
    (Term <= Month2)                and
    (CurrentPeriod > 1)             and
    (IDPercent > 0)

    -- ИЛИ
    --В периоде в который попадает ДатаНачала страхования застрахованного.
    --Например если застрахованный прикрепился в 5-ый месяц, то
    --Премия будет начислена в 5 и 7 месяца.
    UPDATE #PremCur SET FormulaPrem = FormulaPrem + 'TP4;', TermPercent = (Percent1 / 100) WHERE
    (Percent1 > 0)                  and
    --(TermPercent = 0)               and
    (WithoutTerm = 0)               and
    --(NumPeriod = Month1)            and
    (VarStartCur >= PeriodStart)    and --Было InsStart
    (VarStartCur <= PeriodEnd)      and --Было InsStart
    (Term >= Month1)                and
    (Term <= Month2)                and
    (CurrentPeriod > 1)             and
    (IDPercent > 0)

    --Чтобы предыдущая премия по процентовке также светилась правильно по периодам.
    --Если этого не сделать то если например у нас 25 процентов и 4 периода, то в каждом будет отображаться.
    --UPDATE #PremCur SET PremPrev = 0 where TermPercent = 0
  END
--===========================================================================

--===========================================================================
--Далее условие: НеУчитыватьПроцентовкуНаСходныхПрограммах
IF @Operation = 3 
BEGIN
  /*select t1.IDProgram,  
         t1.Month1,
		 t1.Month2,
		 t1.Percent1--,
         --t2.IDProgram 
     into #SameProg from #PremCur t1 where 
     t1.IDVar = t1.IDVarCur and 
     t1.ProgramPercent = 1  and
     --t1.WithoutTerm = 1     and
     t1.TermPercent > 0     and
     t1.CurrentPeriod = 2   and
  exists (select 1 from #PremCur t2 where 
          t2.IDVar = t2.IDVarPrev        and 
          t2.ProgramPercent = 1          and 
          --t2.WithoutTerm = 1             and
          t2.ProgPrem    = t1.ProgPrem   and
          t2.ProgAmount  = t1.ProgAmount and
          t2.VidRiska    = t1.VidRiska   and
          t2.NoKoefAge   = t1.NoKoefAge  and
          t2.NoKoefIll   = t1.NoKoefIll  and
          t2.Month1      = t1.Month1     and
          t2.Month2      = t1.Month2     and
          t2.Percent1    = t1.Percent1   and
          t2.StProg      = t1.StProg     and
          t2.Percent1    > 0             --Это для того чтобы определить что вообще что-то заполнено.
          ) */
	
	
	select IDProgram,  
         Month1,
		     Month2,
		     Percent1,
		     StProg,
		     CurrentPeriod,
		     sum(PremPrev) as PremPrev
	  into #SameProg 
	from
	(	  
	select t1.IDProgram,  
         t1.Month1,
		     t1.Month2,
		     t1.Percent1,
		     t1.PremPrev,
		     t1.StProg,
         (case t1.CurrentPeriod
		      when 1 then 2 
          else t1.CurrentPeriod			 
			    end) as CurrentPeriod		       
	 from #PremCur t1 where 
     t1.IDVar = t1.IDVarPrev and 
     t1.ProgramPercent = 1  and
  exists (select 1 from #PremCur t2 where 
          t2.IDVar = t2.IDVarCur        and 
          t2.ProgramPercent = 1          and 
          t2.ProgPrem    = t1.ProgPrem   and
          t2.ProgAmount  = t1.ProgAmount and
          t2.VidRiska    = t1.VidRiska   and
          t2.NoKoefAge   = t1.NoKoefAge  and
          t2.NoKoefIll   = t1.NoKoefIll  and
          t2.Month1      = t1.Month1     and
          t2.Month2      = t1.Month2     and
          t2.Percent1    = t1.Percent1   and
          t2.StProg      = t1.StProg     and
          t2.Percent1    > 0) 
		) t3
		group by
		   IDProgram,  
       Month1,
		   Month2,
		   Percent1,
		   StProg,
		   CurrentPeriod  				  
		   
  --update #PremCur set SameProg = 0 from #SameProg where #PremCur.IDProgram = #SameProg.IDProgram

     update #PremCur set #PremCur.SameProg = 0  from #SameProg where             
		      #PremCur.StProg        = #SameProg.StProg  
		  and #PremCur.Month1        = #SameProg.Month1
		  and #PremCur.Month2        = #SameProg.Month2
		  and #PremCur.Percent1      = #SameProg.Percent1
		  and #PremCur.CurrentPeriod = #SameProg.CurrentPeriod
		  and #PremCur.IDVar         = #PremCur.IDVarCur		

  --delete from  #PremCur    
END
--===========================================================================



--===========================================================================
-- Расчет значения RVDPrem.
-- Например RVD = 20%.  MyRVDPrem = (100 - 20) / 100 = 0.8
-- Только где Operation = 2, и иных случаях MyRVDPrem = 1 по умолчанию.
  UPDATE #PremCur SET MyRVDPrem = ((100 - RVDPrem) / 100) where Operation = 2 and @UseRVD = 1
--===========================================================================


--============================================================================
-- Получение премии по застрахованному по периодам рассрочки:
-- Прикрепление - 1
-- Открепление  - 2
-- Замена варианта - 3
-- Одновременное открепление - 4
-- Одновременное прикрепление - 5

-- Вид страхового риска (VidRiska):
-- ДМС = 2
-- ВЗР = 3
-- НС  = 4

--В PremCur содержатся все варианты, которые были у застрахованого. Например если он 4 раза менял вариант, то будут все 4.
--Премия расчитывается для текущего варианта (MyPrem), для предыдущего расчитывается только возврат (MyPremBack).
--Для тех вариатнтов коотрое были до этих двух - ничего не расчитывается.
--Периоды которые уже прошли премия не меняется.
--MyPremBack выставляется = 0 потому что например если было две замены варианта подряд, 
--или сначала Замена варианта, затем открепление, то сумма к возврату не должна повторяться.
  UPDATE #PremCur SET MyPrem = PremPrev, FormulaPrem = FormulaPrem + '(S0.1)=PremPrev ', FormulaDigitPrem = FormulaDigitPrem + '(S0.1)=' + CAST(PremPrev as varchar(max)) + ' '  
  UPDATE #PremCur SET MyPremBack = 0, FormulaPremBack = FormulaPremBack + '(S0.2)=0 ', FormulaDigitPremBack = FormulaDigitPremBack + '(S0.2)=0 '

--Это для того чтобы PremPrev не дублировалась. У нас на ОтношениеПрограммаСтрахованиеПериодРассрочки нет ссылки на процентовку,по которой была взята премия
--поэтому уже после расчета не определить по какой из строк из таблицы процентоки была взята премия.
--В таблице процентовки например
--1-3   25%
--4-6   50%
--7-9   75%
--10-12 100%  Какая строка была использована для расчета премии на предыдущем допе? Такого ответа нет...
--Поэтому тут либо делать ссылку... либо как то так:
--UPDATE #PremCur SET PremPrev = 0 where IDPercent > 0 and TermPercent = 0


--============================================================================
--Галка учитывать убытки по застрахованному лицу
--Запрос 
--SELECT Sum(IsNull(СуммаВыплаты, 0)) as Loss FROM ОказанныеУслуги WHERE СтрахПолис.Застрахованный = 78979
IF @UseLoss = 1
BEGIN
  --Подсчитываенм сумму убытков
  Select @Loss = IsNull(Sum(IsNull(EOT_1.SumAccepted, 0)), 0) From ServicesRendered EOT_1
    Left Outer Join InsPolicy EOT_2 On EOT_2.ID = EOT_1.Policy Where EOT_2.RelContFace = @IDIns
  update #PremCur set Loss = @Loss
END


--В принципе что @MethodCalcPrem = 0 что @MethodCalcPrem = 1 расчет одинаков.
--разделено по большому счету только потому чтобы в полях Formula были отличия.
IF @MethodCalcPrem = 0 
BEGIN
--============================================================================
--============ Прикрепление: Operation = 1 (MethodCalcPrem = 0) ===============
--============================================================================
  IF (@Operation = 1) OR (@Operation = 5) --По дням
  BEGIN
    --Возврат премии также расчитывается потому что на допе мог измениться кооф. или премия по программе.
    --Если ничего не изменилось, то Премия также не должна измениться в результате этих расчетов.
    --(ProgPremPrev / KolDayVar * KoefPrev * KolDayInsRest * TermPercent) - Это рассчитанная премия к возврату,
    --(ProgPrem / KolDayVar * Koef * KolDayInsRest * TermPercent) - Это рассчитанная премия к начислению. На возврат мы ставим разницу между ними.
    UPDATE #PremCur SET MyPremBack2 = ((ProgPremPrev / KolDayVar) * KoefPrev * KolDayInsRest * TermPercent), --- (ProgPrem / KolDayVar * Koef * KolDayInsRest * TermPercent),
      FormulaPremBack = FormulaPremBack + ';(P1)MyPremBack2=(ProgPremPrev / KolDayVar * KoefPrev * KolDayInsRest * TermPercent) ',
      FormulaDigitPremBack = FormulaDigitPremBack + ';(P1)MyPremBack2=(' + CAST(ProgPremPrev as Varchar(max)) + '/' + CAST(KolDayVar as Varchar(max)) + 
                             '*' + CAST(KoefPrev as Varchar(max)) + '*' + CAST(KolDayInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ') '
      WHERE (CurrentPeriod = 2) AND (ProgPrem > 0) AND (IDVar = IDVarCur) AND (ProgPremPrev > 0) AND (PremPrev > 0) 

 
    --Здесь PremPrev - Премия рассчитанная на предыдущем допе.
    --MyPremBack - премия к возврату.
    --(ProgPrem / KolDayVar * Koef * KolDayInsRest * TermPercent) - Это рассчитанная премия.
    UPDATE #PremCur SET MyPrem = PremPrev - MyPremBack2 + ((ProgPrem / KolDayVar) * Koef * KolDayInsRest * TermPercent),
      FormulaPrem = ';(P2)=PremPrev - MyPremBack2 + (ProgPrem / KolDayVar * Koef * KolDayInsRest * TermPercent) ',
      FormulaDigitPrem = FormulaDigitPrem + ';(P2)=' + CAST(PremPrev as Varchar(max)) + '-' + CAST(MyPremBack2 as Varchar(max)) + 
                             '+ (' + CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolDayVar as Varchar(max)) + '*'  + CAST(Koef as Varchar(max)) + 
                             '*' + CAST(KolDayInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ') '
      WHERE (CurrentPeriod = 2) AND (ProgPrem > 0) AND (IDVar = IDVarCur) AND (ProgPremPrev > 0) AND (PremPrev > 0) 
  
    --Это для программ, колтрые больше должны участвовать в расчете
    UPDATE #PremCur SET MyPrem = PremPrev - MyPremBack2,
                        FormulaPrem = ';(P2)=PremPrev - MyPremBack2' WHERE ProgNotUse = 1 AND  
                        (CurrentPeriod = 2) AND (ProgPrem > 0) AND (IDVar = IDVarCur) AND (ProgPremPrev > 0) AND (PremPrev > 0) 
                             
    --Не очень красивое решение - нужно как то по другому. 
    --UPDATE #PremCur SET MyPremBack = 0,
    --FormulaPremBack = '(№1.3)=0'
    --WHERE (CurrentPeriod = 2) AND (ProgPremPrev > 0) AND (IDVar = IDVarCur)

    --Далее это обычное прикрепление, т.е. при первоначальное.
    --Как оказалось необходимо рассчитывать премию и по периодам, которые прошли. т.к. 
    --может быть ситуация, когда программы где ProgPrem > 0 были удалены, а новые программы с ProgPrem > 0 добавлены.  
    --Пожалуй здесь можно поставить KolDayIns вместо KolDayInsRest. Это не должно что-то изменить. 
    UPDATE #PremCur SET MyPrem = ((ProgPrem / KolDayVar) * Koef * KolDayInsRest * TermPercent), 
      FormulaPrem = FormulaPrem + ';(P3)=(ProgPrem / KolDayVar * Koef * KolDayInsRest * TermPercent) ',
      FormulaDigitPrem = FormulaDigitPrem + ';(P3)=(' + CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolDayVar as Varchar(max)) + 
                         '*' + CAST(Koef as Varchar(max)) + '*' + CAST(KolDayInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ') '
      WHERE (CurrentPeriod =2) AND (ProgPrem > 0) AND (IDVar = IDVarCur) AND (PremPrev = 0)

    UPDATE #PremCur SET MyPrem = ((ProgPrem / KolDayVar) * Koef * KolDayIns * TermPercent), 
      FormulaPrem = FormulaPrem + ';(P4)=(ProgPrem / KolDayVar * Koef * KolDayIns * TermPercent) ',
      FormulaDigitPrem = FormulaDigitPrem + ';(P4)=(' + CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolDayVar as Varchar(max)) + 
                         '*' + CAST(Koef as Varchar(max)) + '*' + CAST(KolDayIns as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ') '
      WHERE (CurrentPeriod =3) AND (ProgPrem > 0) AND (IDVar = IDVarCur) --AND (PremPrev = 0)
  END    
  --============================================================================== 

  --==============================================================================
  --============ Открепление: Operation = 2 (MethodCalcPrem = 0) =================
  --==============================================================================
  IF (@Operation = 2) OR (@Operation = 4) --По дням
  BEGIN
    --По умолчанию возврат = 0. Это Сделано для того что если какая то строка по условиям фильтра не попадет в один из следующих запросов,
    --то в последствии запросом S7 она останется в колонке начисленной премии.
    UPDATE #PremCur SET 
      MyPrem = 0, 
      MyPremBack = 0, 
      FormulaPrem = FormulaPrem + ';(B0)=0 ', FormulaDigitPrem = FormulaDigitPrem + ';(B0)=0 ',
      FormulaPremBack = FormulaPremBack + ';(B0)=0 ', FormulaDigitPremBack = FormulaDigitPremBack + ';(B0)=0 '
    --Расчитываем и премию по прикреплению и возврат.
    --Предыдущий доп:
    -- |-------------------|  Период по договору.
    --   |-------------|      Предыдущий доп - Период обслуживания.
    --   |---------|          Текущий доп    - Период обслуживания.
    --             |---|      Разница (кол-во дней KolDayInsRest) - Период обслуживания.

    --Чтобы вычислить сколько нужно возвратить нужно расчитать разницу (учитывая программы по которым нет возврата и РВД)
    --и вычесть эту разницу из суммы премии расчитанной на дату предыдущего допа.
    --Просто рассчитать сумму премии на текущий период по кол-ву дгней при открплении нельзя, т.к. она зависит от суммы премии возврата.
    --Эта сумма премии возврата зависит от программ без возврата и суммы РВД.

    --MyPrem в данном случае - это возврат. Ниже мы поменяем MyPrem на MyPremBack.
    --Так сделано потому что ниже должен отработать алгоритм округления точно также как если бы это было обычное прикреление.
    --Поэтому логика такая: открепление считаем  как прикрепление, и округляем так же, а потом, все что начислили, запихиваем в возврат.
    --Единственное исключение - это программы которые не подлежат возврату и Убытки.
    --Обратите внимание что пишем MyPrem, а формулу записываем в FormulaPremBack.
    UPDATE #PremCur SET MyPrem = ((ProgPremPrev / KolDayVar) * KoefPrev * KolDayInsRest * TermPercent * MyRVDPrem), 
      FormulaPremBack = FormulaPremBack + ';(B1)=(ProgPrem / KolDayVar * Koef * KolDayInsRest * TermPercent * MyRVDPrem) ',
      FormulaDigitPremBack = FormulaDigitPremBack + '(B1)=(' + CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolDayVar as Varchar(max)) + '*' + CAST(Koef as Varchar(max)) + 
                             '*' + CAST(KolDayInsRest as Varchar(max))  + '*' + CAST(TermPercent as Varchar(max)) + '*' + CAST(MyRVDPrem as Varchar(max))+ ') ' 
    WHERE (CurrentPeriod = 2) AND (ProgPremPrev > 0) AND (IDVar = IDVarCur) AND (WithoutPayBack = 0) 

    --Это возврат обычных программ, которые не с процентовкой по ненаступившим периодам.
    UPDATE #PremCur SET MyPrem = ((ProgPremPrev / KolDayVar) * KoefPrev * KolDayPeriod * TermPercent), 
      FormulaPremBack = FormulaPremBack + ';(B2)=(ProgPrem / KolDayVar * KoefPrev * KolDayPeriod * TermPercent) ',
      FormulaDigitPremBack = FormulaDigitPremBack + '(B2)=(' + CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolDayVar as Varchar(max)) + 
                             '*' + CAST(Koef as Varchar(max)) + '*' + CAST(KolDayPeriod as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ' ) '
    WHERE (CurrentPeriod = 3) AND (ProgPremPrev > 0) AND (IDVar = IDVarCur) AND (IDPercent = 0) 
    
    --Для всех программ (в том числе и для предоплатных) по ненаступившим периодам возвращаем как есть. Параметра WithoutPayBack нет в фильтре! 77050102-00286/01 Ступка. Возврат такой: 23753/366*91 = 5905,80 руб.
    UPDATE #PremCur SET MyPrem = (ProgPremPrev * KoefPrev * TermPercent * MyRVDPrem), 
      FormulaPremBack = FormulaPremBack + ';(B3)=(ProgPremPrev * KoefPrev * TermPercent * MyRVDPrem) ',
      FormulaDigitPremBack = FormulaDigitPremBack + '(B3)=(' + CAST(ProgPrem as Varchar(max)) + '*' + CAST(KoefPrev as Varchar(max)) + 
                             '*' + CAST(TermPercent as Varchar(max)) + '*' + CAST(MyRVDPrem as Varchar(max))+ ') ' 
    WHERE (CurrentPeriod = 3) AND (ProgPremPrev > 0) AND (IDVar = IDVarCur) and (IDPercent > 0)


    --На допсе по пролонгации (VidDoc = 16) возврат при откреплени всегда = 0. Пример договора 63050101-00064/10.
    UPDATE #PremCur SET MyPrem = 0, FormulaPremBack = FormulaPremBack + ';(B4)=0 ', FormulaDigitPremBack = FormulaDigitPremBack + ';(B4)=0 ' WHERE VidDoc = 16

    --Если предыдущая премия на периоде не рассчитана, например если был в последствии допс. по пролонгации, 
    --то возвращать нечего, так как сумма уйдет в минус. Пример договора 63050101-00064/01. 
    UPDATE #PremCur SET MyPrem = 0, FormulaPremBack = FormulaPremBack + ';(B5)=0 ', FormulaDigitPremBack = FormulaDigitPremBack + ';(B5)=0 ' WHERE PremPrev = 0

    --В текущем периоде галка "Без возврата" работает всегда (CurrentPeriod = 2):
    UPDATE #PremCur SET MyPrem = 0, FormulaPremBack = FormulaPremBack + ';(B6)=0 ', FormulaDigitPremBack = FormulaDigitPremBack + ';(B6)=0 ' WHERE (CurrentPeriod = 2) AND (WithoutPayBack = 1)
  
    --Если стоит галка Учитывать убытки по Затрахованному лицу, то учитываем...
    --Здесь Loss = 0 если галка не стоит (устанавливается выше по тексту кода)
    --Именно потому что MyPrem потом будет записан как PremBack (т.е. возврат мы плюсуем, а не вычитаем).    
    --UPDATE #PremCur SET MyPrem = MyPrem - Loss,
    --FormulaPremBack = FormulaPremBack + ';(№2.6)=MyPrem - Loss' 
    --WHERE (CurrentPeriod in (2,3)) AND (IDVar = IDVarCur) AND (Loss <> 0) AND (WithoutPayBack = 0)   

    --============================================================================
    --Галка учитывать убытки по застрахованному лицу
    IF @UseLoss = 1
    BEGIN
      SELECT @SumPrem = SUM(MyPrem) FROM #PremCur 
      UPDATE #PremCur SET MyPrem = 0, FormulaPremBack = FormulaPremBack + ';(B6)=0 ', FormulaDigitPremBack = FormulaDigitPremBack + ';(B6)=0 '
      UPDATE #PremCur SET 
        MyPrem = @SumPrem - @Loss, 
        FormulaPremBack = FormulaPremBack + ';(B7)=@SumPrem-@Loss ', 
        FormulaDigitPremBack = FormulaDigitPremBack + ';(B8)=' + CAST(@SumPrem as Varchar(max)) + '-' + CAST(@Loss as Varchar(max)) + ' '
        WHERE CurrentPeriod = 2 and ID = (SELECT MIN(ID) FROM #PremCur WHERE CurrentPeriod = 2)
	                        and IDPercent = (SELECT MIN(IDPercent) FROM #PremCur WHERE CurrentPeriod = 2)   
      UPDATE #PremCur SET MyPrem = 0 WHERE MyPrem < 0
    END
  --============================================================================

    --Страховая сумма при откреплении должна быть равна нулю.
    UPDATE #PremCur SET Amount = 0, AmountDMS = 0, AmountVZR = 0, AmountNS = 0
  END
  
--==============================================================================
--============ Смена варианта: Operation = 3 (MethodCalcPrem = 0) ==============
--==============================================================================
  IF (@Operation = 3) --По дням
  BEGIN
    --update #PremCur set SameProg = 1
    --Смена варианта расчитывается как последовательное открепление на одном варианта (без учета RVD), а затем прикрепление на другом варианте.
    --Открепление пишется в объекты предыдущего варианта, а прикрепление пишется в текущий вариант - это разные записи в таблицах!
    --При смене варианта в предыдущем варианта на тех периодах которые прошли, ставим ранее расчитанную премию, возврат = 0.
    --На том периоде в который попала смена варианта часть расчитываем, и часть возвращаем.
    --На тех периодах, которые ещё не наступили, ставим только возврат, сама премия = 0.

    --Это Открепление:
    --Возврат расчитывается также как и при откреплении, за исключением возврата по RVD.
    --По текущему периоду
    UPDATE #PremCur SET MyPremBack = ((ProgPremPrev / KolDayVar) * KoefPrev * KolDayInsRest * TermPercent),
    FormulaPremBack = FormulaPremBack + '(Z3.1)=(ProgPremPrev / KolDayVar * KoefPrev * KolDayInsRest * TermPercent) ',
    FormulaDigitPremBack = FormulaPremBack + '(Z3.1)=(' + CAST(ProgPremPrev as Varchar(max)) + '/' + CAST(KolDayVar as Varchar(max)) + 
                      '*' + CAST(KoefPrev as Varchar(max)) + '*' + CAST(KolDayInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ') ' 
    WHERE (CurrentPeriod = 2) AND (ProgPremPrev > 0) AND (WithoutPayBack = 0) AND (PremPrev > 0) AND (IDVar = IDVarPrev)

    --По не наступившим периодам возвращаем как есть, без RVD.
    UPDATE #PremCur SET MyPremBack = PremPrev, 
    FormulaPremBack = FormulaPremBack + '(Z3.2)=MyPremBack = PremPrev ',
    FormulaDigitPremBack = FormulaPremBack + '(Z3.2)=' + CAST(MyPremBack as Varchar(max)) + '=' + CAST(PremPrev as Varchar(max)) + ' '  
    WHERE (CurrentPeriod = 3) AND (WithoutPayBack = 0) AND (IDVar = IDVarPrev)
    
    --Чтобы поймать расхождение в копейку на последнем периоде. Эту разницу нужно кинуть на текущий период..
    --UPDATE #PremCur SET MyPremBack2 = ROUND(((ProgPremPrev / KolDayVar) * KoefPrev * KolDayPeriod * TermPercent), 2) 
    --WHERE (CurrentPeriod = 3) AND (ProgPremPrev > 0) AND (WithoutPayBack = 0) AND  (IDVar = IDVarCur) AND (PremPrev > 0)
       
    --Это часть премии по прикреплению, расчитанной по предыдущему варианту
    --По текущему периоду
    UPDATE #PremCur SET MyPrem = PremPrev - MyPremBack, 
      FormulaPrem = FormulaPrem + '(Z3.3)=PremPrev - MyPremBack ',
      FormulaDigitPrem = FormulaDigitPrem  + '(Z3.3)=' + CAST(PremPrev as Varchar(max)) +'-' + CAST(MyPremBack as Varchar(max)) + ' '  
      WHERE (CurrentPeriod = 2) AND (IDVar = IDVarPrev) 
   
    --По периодам, которые ещё не наступили
    UPDATE #PremCur SET MyPrem = 0, 
      FormulaPrem = FormulaPrem + '(Z3.4)=0 ',
      FormulaDigitPrem = FormulaDigitPrem + '(Z3.4)=0 '
      WHERE (CurrentPeriod = 3) AND (IDVar = IDVarPrev) 

    --По периодам, которые ещё не наступили
    --UPDATE #PremCur SET MyPrem = MyPrem - PremPrev, 
    --  FormulaPrem = FormulaPrem + '(Z3.4)=MyPrem - PremPrev ',
    -- FormulaDigitPrem = FormulaDigitPrem + '(Z3.4)= ' + CAST(MyPrem as Varchar(max)) +'-' + CAST(PremPrev as Varchar(max)) + '  '
    --  WHERE (CurrentPeriod = 3) AND (IDVar = IDVarPrev) 

    --Это Прикрепление:
    UPDATE #PremCur SET MyPremBack = ((ProgPremPrev / KolDayVar) * KoefPrev * KolDayInsRest * TermPercent), --- (ProgPrem / KolDayVar * Koef * KolDayInsRest * TermPercent),
      FormulaPremBack = FormulaPremBack + '(Z3.5)=(ProgPremPrev / KolDayVar * KoefPrev * KolDayInsRest * TermPercent) ',
      FormulaDigitPremBack = FormulaDigitPremBack + '(Z3.5)=((' + CAST(ProgPremPrev as Varchar(max)) + '/' + CAST(KolDayVar as Varchar(max)) + ')*' + CAST(KoefPrev as Varchar(max)) + 
                                        '*' + CAST(KolDayInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ') '    
    WHERE (CurrentPeriod = 2) AND (PremPrev > 0) AND (IDVar = IDVarCur)
    
    --Премия по прикреплению, расчитанная по текущему варианту.
    UPDATE #PremCur SET MyPrem = PremPrev - MyPremBack + (ProgPrem / KolDayVar) * Koef * KolDayInsRest * TermPercent * SameProg, 
      FormulaPrem = FormulaPrem + '(Z3.6)=PremPrev - MyPremBack + (ProgPrem / KolDayVar) * Koef * KolDayInsRest * TermPercent * SameProg ',
      FormulaDigitPrem = FormulaDigitPrem + '(Z3.6)=' + CAST(PremPrev as Varchar(max)) + '-' + CAST(MyPremBack as Varchar(max)) + '+(' + CAST(ProgPrem as Varchar(max)) + 
                                '/' + CAST(KolDayVar as Varchar(max)) + ')*' + CAST(Koef as Varchar(max)) + '*' + CAST(KolDayInsRest as Varchar(max)) + 
                                '*' + CAST(TermPercent as Varchar(max)) + '*' + CAST(SameProg as Varchar(max)) + ' ' 
    WHERE (CurrentPeriod = 2) AND (ProgPrem > 0) AND (IDVar = IDVarCur)
   
    UPDATE #PremCur SET MyPrem = PremPrev - MyPremBack + (ProgPrem / KolDayVar) * Koef * KolDayIns * TermPercent * SameProg, 
      FormulaPrem = FormulaPrem + '(Z3.7)=PremPrev - MyPremBack + (ProgPrem / KolDayVar) * Koef * KolDayIns * TermPercent * SameProg ',
      FormulaDigitPrem = FormulaDigitPrem + '(Z3.7)=' + CAST(PremPrev as Varchar(max)) + '-' + CAST(MyPremBack as Varchar(max)) + '+(' + CAST(ProgPrem as Varchar(max)) + 
                                '/' + CAST(KolDayVar as Varchar(max)) + ')*' + CAST(Koef as Varchar(max)) + '*' + CAST(KolDayIns as Varchar(max)) + 
                                '*' + CAST(TermPercent as Varchar(max)) + '*' + CAST(SameProg as Varchar(max)) + ' '  
    WHERE (CurrentPeriod = 3) AND (ProgPrem > 0) AND (IDVar = IDVarCur)
     


  --Отключено потому что премия за программу бралась два раза. Договор 1 год. 77050102-00346-00251 Панченко Андрей Валентинович
  --Замена варианта на 77050102-00346/01/3. должно быть 20906,56 общая премия на застрахованном после смены варианта.
  --Отключено потому что всего должно было взяться 500 руб., а бралась 1000. 500 в открепляемом оставалось, и 500 бралось в новом.
  --Условие ниже тоже нужно в каких то случаях, только забыл в каких, поэтому пока отключено, но как только возникнет ошибка 
  --придется разбираться и включать заново, возможно с какми то изменениями. Поэтому код ниже удалять нельзя - он нужен.
  ---КОД КОТОРЫЙ ПРАВИЛЬНЫЙ, НО НЕ ВСЕГДА:
  --Значит что это такое... При замене варианта (и только при замене) 
	--выше SameProg = 0 у тех программ с процентовкой которые совпадают по названию и процентовке.
	--поэтому там выставится 0.
	--А этот запрос выставляет значение премии у программы нового варианта ТОЧНО ТАКИЕ ЖЕ как и у старого.
	--Совпадение по периодам также есть обязательно.
	--Это значит, что несмотря на то что новый вариант действет например с начала 3-го периода.
	--по программам которые совпадают может быть начислена премия и по прошедшим периодам.
   	/*update #PremCur set #PremCur.MyPrem = #SameProg.PremPrev, 
      FormulaPrem = FormulaPrem + '(Z3.8)=#SameProg.PremPrev ', 
      FormulaDigitPrem = FormulaDigitPrem + '(Z3.8)=' + CAST(#SameProg.PremPrev as Varchar(max)) + ' '
      from #SameProg where             
		      #PremCur.StProg   = #SameProg.StProg  
		  and #PremCur.Month1   = #SameProg.Month1
		  and #PremCur.Month2   = #SameProg.Month2
		  and #PremCur.Percent1 = #SameProg.Percent1
		  and #PremCur.CurrentPeriod = #SameProg.CurrentPeriod
		  and #PremCur.IDVar = #PremCur.IDVarCur */
  END 
--============ Конец расчета по изменению варианта =============================
END


--Метод расчета премии по месяцам
IF @MethodCalcPrem = 1 
BEGIN
    --Галка При прикреплении/откреплении/смене варианта не в первый деньмесяца считать по дням.
  UPDATE #PremCur SET 
    KolMonthVar = KolDayVar, 
    KolMonthIns = KolDayIns,
    KolMonthInsRest = KolDayInsRest,
	  KolMonthPeriod = KolDayPeriod
  WHERE (CurrentPeriod = 2) AND (FirstPeriodCalcByDays = 1) AND (DAY(StateDate) <> 1) 

--==============================================================================
--============ Прикрепление: Operation = 1 (MethodCalcPrem = 1) ================
--==============================================================================
  IF (@Operation = 1) OR (@Operation = 5) --По месяцам
  BEGIN
    --Возврат премии также расчитывается потому что на допе мог измениться кооф. или премия по программе.
    --Если ничего не изменилось, то Премия также не должна измениться в результате этих расчетов.

    UPDATE #PremCur SET MyPremBack = (ProgPremPrev / KolMonthVar * KoefPrev * KolMonthInsRest * TermPercent),
      FormulaPremBack = FormulaPremBack + ';(MP1)=(ProgPremPrev / KolMonthVar * Koef * KolMonthInsRest * TermPercent) ',
      FormulaDigitPremBack = FormulaDigitPremBack + '(' + CAST(ProgPremPrev as Varchar(max)) + '/' + CAST(KolMonthVar as Varchar(max)) + '*' + 
                             CAST(Koef as Varchar(max)) + '*' + CAST(KolMonthInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ' '
    WHERE (CurrentPeriod = 2) AND (ProgPremPrev > 0) AND (IDVar = IDVarCur)

    --UPDATE #PremCur SET MyPrem = PremPrev - MyPremBack + (ProgPrem / KolMonthVar * Koef * KolMonthInsRest * TermPercent),
    --  FormulaPrem = FormulaPrem + ';(MP2)=PremPrev-MyPremBack+(ProgPrem/KolMonthVar*Koef*KolMonthInsRest*TermPercent ', 
    --  FormulaDigitPrem = FormulaDigitPrem + ';(MP2)=' + CAST(PremPrev as Varchar(max)) + '-' + CAST(MyPremBack as Varchar(max)) + '+(' + 
    --                     CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolMonthVar as Varchar(max)) + '*' + CAST(Koef as Varchar(max)) + '*' + 
    --                     CAST(KolMonthInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max))   
    --WHERE (CurrentPeriod = 2) AND (ProgPrem > 0) AND (IDVar = IDVarCur) AND (PremPrev > 0)

    UPDATE #PremCur SET MyPrem = (ProgPrem / KolMonthVar * Koef * KolMonthInsRest * TermPercent),
      FormulaPrem = FormulaPrem + ';(MP3)=ProgPrem / KolMonthVar * Koef * KolMonthInsRest * TermPercent ',
      FormulaDigitPrem = FormulaDigitPrem + CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolMonthVar as Varchar(max)) + '*' + CAST(Koef as Varchar(max)) + '*' + 
                         CAST(KolMonthInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ' '   
    WHERE (CurrentPeriod = 2) AND (ProgPrem > 0) AND (IDVar = IDVarCur) AND (PremPrev = 0)
 

    UPDATE #PremCur SET MyPrem = (ProgPrem / KolMonthVar * Koef * KolMonthIns * TermPercent), 
      FormulaPrem = FormulaPrem + ';(MP4)=(ProgPrem / KolMonthVar * Koef * KolMonthIns * TermPercent) ',
      FormulaDigitPrem = FormulaDigitPrem + CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolMonthVar as Varchar(max)) + '*' + CAST(Koef as Varchar(max)) + '*' + 
                         CAST(KolMonthIns as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ' '    
    WHERE (CurrentPeriod = 3) AND (ProgPrem > 0) AND (IDVar = IDVarCur)

    --Если до конца действия договора остается меньше указанного кол-ва месяцев, то премия по программе PercentPrik процентов.
    --PercntPrik <> 0 только в этом случае, в остальных = 0.  Интересно что select (25 / 100) дает 0! :)
    --UPDATE #PremCur SET MyPrem = ((PercentPrik / 100) * ProgPrem * Koef), 
    --FormulaPrem = '(№11.5)=(PercentPrik / 100) * ProgPrem * Koef)'
    --WHERE (PercentPrik > 0) AND (IDVar = IDVarCur)
  END


  --==============================================================================
  --============ Открепление: Operation = 2 (MethodCalcPrem = 1) =================
  --==============================================================================
  IF (@Operation = 2) OR (@Operation = 4) --По месяцам
  BEGIN
    --Расчитываем и премию по прикреплению и возврат.
    --Предыдущий доп:
    -- |-------------------|  Период по договору.
    --   |-------------|      Предыдущий доп - Период обслуживания.
    --   |---------|          Текущий доп    - Период обслуживания.
    --             |---|      Разница (кол-во дней KolMonthInsRest) - Период обслуживания.

    --Чтобы вычислить сколько нужно возвратить нужно расчитать разницу (учитывая программы по которым нет возврата и РВД)
    --и вычесть эту разницу из суммы премии расчитанной на дату предыдущего допа.
    --Просто рассчитать сумму премии на текущий период по кол-ву дгней при открплении нельзя, т.к. она зависит от суммы премии возврата.
    --Эта сумма премии возврата зависит от программ без возврата и суммы РВД.

    --Это сумма возврата:
    --WithoutPayBack если 1, то премию по этой программе не считаем.
    --TermPercent - процентовка на программе, это не историчные денные, не зависят от допа.

	--Здесь MyPrem - это то что к возврату. Ниже потом поменяем. Это сделано для алгоритма округления.
	--т.е. открепление считаем как прикрепление.
--MyPrem в данном случае - это возврат. Ниже мы поменяем MyPrem на MyPremBack.
    --Так сделано потому что ниже должен отработать алгоритм округления точно также как если бы это было обычное прикреление.
    --Поэтому логика такая: открепление считаем  как прикрепление, и округляем так же, а потом, все что начислили, запихиваем в возврат.
    --Единственное исключение - это программы которые не подлежат возврату и Убытки.
    --Обратите внимание что пишем MyPrem, а формулу записываем в FormulaPremBack.
    UPDATE #PremCur SET MyPrem = ((ProgPremPrev / KolMonthVar) * KoefPrev * KolMonthInsRest * TermPercent * MyRVDPrem), 
      FormulaPremBack = FormulaPremBack + ';(MB1)=(ProgPrem / KolMonthVar * KoefPrev * KolMonthInsRest * TermPercent * MyRVDPrem) ',
      FormulaDigitPremBack = FormulaDigitPremBack + ';(MB1)=(' + CAST(ProgPrem as Varchar(max)) + '/' + CAST(KolMonthVar as Varchar(max)) + '*' + CAST(KoefPrev as Varchar(max)) + '*' + 
                             CAST(KolMonthInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + '*' + CAST(MyRVDPrem as Varchar(max)) + ') '
    WHERE (CurrentPeriod = 2) AND (ProgPremPrev > 0) AND (IDVar = IDVarCur) AND (WithoutPayBack = 0)

    UPDATE #PremCur SET MyPrem = ((ProgPremPrev / KolMonthVar) * KoefPrev * KolMonthPeriod * TermPercent), 
      FormulaPremBack = FormulaPremBack + ';(MB2)=((ProgPremPrev / KolMonthVar) * KoefPrev * KolMonthPeriod * TermPercent) ',
      FormulaDigitPremBack = FormulaDigitPremBack + ';(MB2)=(' + CAST(ProgPremPrev as Varchar(max)) + '/' + CAST(KolMonthVar as Varchar(max)) + ')*' + CAST(KoefPrev as Varchar(max)) + '*' + 
                             CAST(KolMonthPeriod as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ' '
    WHERE (CurrentPeriod = 3) AND (ProgPremPrev > 0) AND (IDVar = IDVarCur) AND (WithoutPayBack = 0)
    
    --В текущем периоде галка "Без возврата" работает всегда:
    --UPDATE #PremCur SET
    --  MyPrem = 0, 
    --  FormulaPremBack = FormulaPremBack + ';(MB3)=0 ',
    --  FormulaDigitPremBack = FormulaDigitPremBack + ';(MB3)=0 '
   -- WHERE (CurrentPeriod = 2) AND (WithoutPayBack = 0)

    --============================================================================
    --Галка учитывать убытки по застрахованному лицу
    IF @UseLoss = 1
    BEGIN
      SELECT @SumPrem = SUM(MyPrem) FROM #PremCur
  
      UPDATE #PremCur set MyPrem = 0
      UPDATE #PremCur set MyPrem = @SumPrem - @Loss 
        WHERE CurrentPeriod = 2 and ID = (SELECT MIN(ID) FROM #PremCur WHERE CurrentPeriod = 2)
	                        and IDPercent = (SELECT MIN(IDPercent) FROM #PremCur WHERE CurrentPeriod = 2)   
      UPDATE #PremCur set MyPrem = 0 WHERE MyPrem < 0
    END
    --============================================================================

    --Страховая сумма при откреплении должна быть равна нулю.
    UPDATE #PremCur SET Amount = 0, AmountDMS = 0, AmountVZR = 0, AmountNS = 0 WHERE Operation in (2,4) 
  END
  
  
--==============================================================================
--============ Смена варианта: Operation = 3 (MethodCalcPrem = 1) ==============
--==============================================================================
  IF (@Operation = 3) --По месяцам
  BEGIN
    --Смена варианта расчитывается как последовательное открепление на одном варианта (без учета RVD), а затем прикрепление на другом варианте.
    --Открепление пишется в объекты предыдущего варианта, а прикрепление пишется в текущий вариант - это разные записи в таблицах!
    --При смене варианта в предыдущем варианта на тех периодах которые прошли, ставим ранее расчитанную премию, возврат = 0.
    --На том периоде в который попала смена варианта часть расчитываем, и часть возвращаем.
    --На тех периодах, которые ещё не наступили, ставим только возврат, сама премия = 0.
    --Галка При прикреплении не в первый деньмесяца считать по дням.
    --UPDATE #PremCur SET 
    --KolMonthVar = KolDayVar, 
    --KolMonthIns = KolDayIns,
    --KolMonthInsRest = KolDayInsRest
    --WHERE (CurrentPeriod = 2) AND  (FirstPeriodCalcByDays = 1) 


    --Это Открепление:
    --Возврат расчитывается также как и при откреплении, за исключением возврата по RVD.
    --По текущему периоду
    UPDATE #PremCur SET MyPremBack = (ProgPremPrev / KolMonthVar * KoefPrev * KolMonthInsRest * TermPercent),
      FormulaPremBack = FormulaPremBack + ';(MZ1)=(ProgPremPrev / KolMonthVar * KoefPrev * KolMonthInsRest * TermPercent) ',
      FormulaDigitPremBack = FormulaDigitPremBack + ';(MZ1)=' + CAST(ProgPremPrev as Varchar(max)) + '/' + CAST(KolMonthVar as Varchar(max)) + 
                             '*' + CAST(KoefPrev as Varchar(max)) + '*' + CAST(KolMonthInsRest as Varchar(max)) + '*' + CAST(TermPercent as Varchar(max)) + ' '
    WHERE (CurrentPeriod = 2) AND (ProgPremPrev > 0) AND (WithoutPayBack = 0) AND (PremPrev > 0) AND (IDVar = IDVarPrev) AND (PremPrev > 0)

    --По не наступившим периодам возвращаем как есть, без RVD.
    UPDATE #PremCur SET 
      MyPremBack = PremPrev, 
      FormulaPremBack = FormulaPremBack + ';(MZ2)=PremPrev ',
      FormulaDigitPrem = FormulaDigitPrem +CAST(PremPrev as Varchar(max)) + ' '
    WHERE (CurrentPeriod = 3) AND (WithoutPayBack = 0) AND (IDVar = IDVarPrev)

    --Это часть премии по прикреплению, расчитанной по предыдущему варианту
    --По текущему периоду
    UPDATE #PremCur SET 
      MyPrem = PremPrev - MyPremBack, 
      FormulaPrem = FormulaPrem + ';(MZ3)=PremPrev-MyPremBack ',
      FormulaDigitPrem = FormulaDigitPrem + ';(MZ3)=' + CAST(PremPrev as Varchar(max)) + '-' + CAST(MyPremBack as Varchar(max)) + ' '
    WHERE (CurrentPeriod = 2) AND (IDVar = IDVarPrev) AND (PremPrev > 0)
   
    --По периодам, которые ещё не наступили
    UPDATE #PremCur SET 
      MyPrem = 0,  
      FormulaPrem = FormulaPrem + ';(MZ4)=0 ',
      FormulaDigitPrem = FormulaDigitPrem + ';(MZ4)=0 '
    WHERE (CurrentPeriod = 3) AND (IDVar = IDVarPrev)
     
    --Это Прикрепление:
    --Премия по прикреплению, расчитанная по текущему варианту. 
    UPDATE #PremCur SET MyPrem = PremPrev - PremBack + (ProgPrem / KolMonthVar) * Koef * KolMonthInsRest * TermPercent * SameProg, 
      FormulaPrem = FormulaPrem + ';(MZ5)=PremPrev-PremBack+(ProgPrem/KolMonthVar) * Koef * KolMonthInsRest * TermPercent * SameProg ',
      FormulaDigitPrem = FormulaDigitPrem + ';(MZ5)=' + CAST(PremPrev as Varchar(max)) + '-' + CAST(PremBack as Varchar(max)) + '+(' + CAST(ProgPrem as Varchar(max)) + '/' + 
                         CAST(KolMonthVar as Varchar(max)) + ') * ' + CAST(Koef as Varchar(max)) + '*' + CAST(KolMonthInsRest as Varchar(max)) + '*' + 
                         CAST(TermPercent as Varchar(max)) + '*' + CAST(SameProg as Varchar(max)) + ' '
    WHERE (CurrentPeriod = 2) AND (ProgPrem > 0) AND (IDVar = IDVarCur)
   
    UPDATE #PremCur SET MyPrem = PremPrev - PremBack + (ProgPrem / KolMonthVar) * Koef * KolMonthIns * TermPercent * SameProg, 
      FormulaPrem = FormulaPrem + ';(MZ6)=PremPrev - PremBack + (ProgPrem / KolMonthVar) * Koef * KolMonthIns * TermPercent * SameProg ',
      FormulaDigitPrem = FormulaDigitPrem + ';(MZ6)=' + CAST(PremPrev as Varchar(max)) + '-' + CAST(PremBack as Varchar(max)) + '+(' + CAST(ProgPrem as Varchar(max)) + '/' + 
                         CAST(KolMonthVar as Varchar(max)) + ') * ' + CAST(Koef as Varchar(max)) + '*' + CAST(KolMonthIns as Varchar(max)) + '*' + 
                         CAST(TermPercent as Varchar(max)) + '*' + CAST(SameProg as Varchar(max)) + ' '
    WHERE (CurrentPeriod = 3) AND (ProgPrem > 0) AND (IDVar = IDVarCur) 


    --Значит что это такое... При замене варианта (и только при замене) 
	--выше SameProg = 0 у тех программ с процентовкой которые совпадают по названию и процентовке.
	--поэтому там выставится 0.
	--А этот запрос выставляет значение премии у программы нового варианта ТОЧНО ТАКИЕ ЖЕ как и у старого.
	--Совпадение по периодам также есть обязательно.
	--Это значит, что несмотря на то что новый вариант действет например с начала 3-го периода.
	--по программам которые совпадают может быть начислена премия и по прошедшим периодам.
   	update #PremCur set #PremCur.MyPrem = #SameProg.PremPrev, 
           FormulaPrem = FormulaPrem + ';(MZ7)= #SameProg.PremPrev ', 
           FormulaDigitPrem = FormulaDigitPrem + ';(MZ7)=' + CAST(#SameProg.PremPrev as Varchar(max)) + ' '
      from #SameProg where             
		      #PremCur.StProg   = #SameProg.StProg  
		  and #PremCur.Month1   = #SameProg.Month1
		  and #PremCur.Month2   = #SameProg.Month2
		  and #PremCur.Percent1 = #SameProg.Percent1
		  and #PremCur.CurrentPeriod = #SameProg.CurrentPeriod
		  and #PremCur.IDVar = #PremCur.IDVarCur 
    --============ Конец расчета по изменению варианта =============================
  END
END


--===============================================================================
  --Код одинаков и для расчета по дням и для расчета по месяцам.
  --Если до конца действия договора остается меньше указанного кол-ва месяцев, то премия по программе PercentPrik процентов.
  --PercntPrik <> 0 только в этом случае, в остальных = 0. Интересно что этот запрос дает 0: select (25 / 100)
  --Расчет только для текущего периода и всех следующих (т.е. CurrentPeriod in (2,3))
  UPDATE #PremCur SET PercentPrik = @PercentPrikToEnd  
  UPDATE #PremCur SET MyPrem = ((PercentPrik / 100) * ProgPrem * Koef ), 
    FormulaPrem = FormulaPrem + ';(F4)=(PercentPrik / 100) * ProgPrem * Koef) ',
    FormulaDigitPrem = FormulaDigitPrem + ';(F4)=(' + CAST(PercentPrik as Varchar(max)) + '/100)*' + CAST(ProgPrem as Varchar(max)) + '*' + CAST(Koef as Varchar(max)) + ' '
  WHERE (Operation = 1)     AND
        (CurrentPeriod in (2,3)) AND 
        (IDVar = IDVarCur)  AND
        (PercentPrik > 0)   AND 
        dbo.fnMonthBetweenDates(VarStartCur, DogEnd) <= @CountMonthToEnd AND --Функция рачета месяцев между датами (Букрин А.)
        (WithoutTerm = 0)   AND --Если не стоит условие "Без рассрочки"
        (IDReason = @AID)   AND
        (IDPercent = 0)

update #PremCur set MyPrem     = 0, FormulaPrem     = FormulaPrem     + ';(F5)=0', 
                    MyPremBack = 0, FormulaPremBack = FormulaPremBack + ';(F5)=0' where ProgNotUse = 1  AND (CurrentPeriod = 3)


                   
--===============================================================================



/*
IF (@ResultTable = 1) OR (@ResultTable = 3)
BEGIN
--Заполнение формулы в цифрах
--PremPrev
--PremBackPrev
--ProgPremPrev
--KolDayVar
--Koef
--KolDayInsRest
--TermPercent
--MyPremBack
--ProgPrem
--PercentPrik
--KoefPrev
--KolDayIns
--MyPrem
  UPDATE #PremCur SET FormulaDigitPremBack  = FormulaPremBack, FormulaDigitPrem  = FormulaPrem
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'ProgPremPrev',    CAST(ProgPremPrev    AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'PremPrev',        CAST(PremPrev        AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'PremBackPrev',    CAST(PremBackPrev    AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'ProgPremPrev',    CAST(ProgPremPrev    AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'KolDayVar',       CAST(KolDayVar       AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'KolDayInsRest',   CAST(KolDayInsRest   AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'TermPercent',     CAST(TermPercent     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'ProgPrem',        CAST(ProgPrem        AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'PercentPrik',     CAST(PercentPrik     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'KoefPrev',        CAST(KoefPrev        AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'Koef',            CAST(Koef            AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'KolDayIns',       CAST(KolDayIns       AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'MyPremBack2',     CAST(MyPremBack2     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'MyPremBack',      CAST(MyPremBack      AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'MyPrem',          CAST(MyPrem          AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'KolMonthVar',     CAST(KolMonthVar     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'KolMonthInsRest', CAST(KolMonthInsRest AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'KolMonthIns',     CAST(KolMonthIns     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'MyRVDPrem',       CAST(MyRVDPrem       AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPremBack = REPLACE(FormulaDigitPremBack, 'KolDayPeriod',    CAST(KolDayPeriod    AS varchar(20)))

  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'ProgPremPrev',    CAST(ProgPremPrev    AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'PremPrev',        CAST(PremPrev        AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'PremBackPrev',    CAST(PremBackPrev    AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'ProgPremPrev',    CAST(ProgPremPrev    AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'KolDayVar',       CAST(KolDayVar       AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'KolDayInsRest',   CAST(KolDayInsRest   AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'TermPercent',     CAST(TermPercent     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'ProgPrem',        CAST(ProgPrem        AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'PercentPrik',     CAST(PercentPrik     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'KoefPrev',        CAST(KoefPrev        AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'Koef',            CAST(Koef            AS varchar(20)))  
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'KolDayIns',       CAST(KolDayIns       AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'MyPremBack',      CAST(MyPremBack      AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'MyPrem',          CAST(MyPrem          AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'KolMonthVar',     CAST(KolMonthVar     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'KolMonthInsRest', CAST(KolMonthInsRest AS varchar(20)))  
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'KolMonthIns',     CAST(KolMonthIns     AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'MyRVDPrem',       CAST(MyRVDPrem       AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'SameProg',        CAST(SameProg        AS varchar(20)))
  UPDATE #PremCur SET FormulaDigitPrem = REPLACE(FormulaDigitPrem, 'KolDayPeriod',    CAST(KolDayPeriod    AS varchar(20)))
END
*/
--==============================================================================


--1. Округляем премию
  update #PremCur set 
  MyPremRound = ROUND(MyPrem, 2),
  MyPremBackRound = ROUND(MyPremBack, 2)
    
--Если использовать алгоритм округления...   
IF @UseRound = 1
BEGIN
--==============================================================================
  -- Определим нужные периоды и нужные программы в периоде (для каждого года), куда будем добавлять разницу в копейках после округления.
  --   a) Это должен быть период для округления начисленной премии. 
  --   b) Это должен быть текущий период для округления премии возврата. 
  -- Здесь везде по два запроса для начисленной премии и для премии возврата.
  --============================================================================== 
  --1. (RoundPeriodProgram) Определим по одной программе в каждом периоде с минимальной премией но >0.
  --Для операций прикрепления поле MyPrem 
   
  SELECT AccrualPeriod, IDVar, Period, VidRiska, MIN(IDProgram) AS IDProgram into #RoundPeriodProgram1 FROM #PremCur 
  WHERE MyPrem > 0 AND CurrentPeriod IN(2,3) 
  GROUP BY AccrualPeriod, IDVar, Period, VidRiska
 
  --1.2. Проставляем признак = 1. Это та программа куда будем кидать копейки. Начисленная премия
  update #PremCur set RoundPeriodProgram1 = 1 from #RoundPeriodProgram1 
  where  #PremCur.AccrualPeriod   = #RoundPeriodProgram1.AccrualPeriod   and
         #PremCur.Period          = #RoundPeriodProgram1.Period    and 
         #PremCur.IDProgram       = #RoundPeriodProgram1.IDProgram and
         #PremCur.IDVar           = #RoundPeriodProgram1.IDVar      
         
  --2. (RoundYearPeriod)Нужно определить период где (где премия рассчитана Prem > 0
  --т.е. один период в каждом году. PeriodRound вспомогательное поле для расчета ProgramRoundYear 
  SELECT AccrualPeriod, IDVar, MAX(Period) as Period into #RoundYearPeriod1 from #PremCur 
  where MyPrem > 0 and CurrentPeriod > 1 GROUP BY AccrualPeriod, IDVar 
  
  --2.1. Проставляем признак = 1. --PeriodRound вспомогательное поле для расчета ProgramRoundYear 
  update  #PremCur set RoundYearPeriod1 = 1 from #RoundYearPeriod1 
    where #PremCur.AccrualPeriod = #RoundYearPeriod1.AccrualPeriod and
          #PremCur.Period        = #RoundYearPeriod1.Period and
          #PremCur.IDVar         = #RoundYearPeriod1.IDVar 
          
  --3. (RoundYearProgram) Далее для округления по ГОДАМ для каждого вида риска определим одну программу каждого вида риска
  -- в том периоде в котором будем добавлять копейки. 
  SELECT  AccrualPeriod, IDVar, Period, VidRiska, MIN(IDProgram) AS IDProgram INTO #RoundYearProgram1 FROM #PremCur
    WHERE
      RoundYearPeriod1 = 1 AND 
      MyPrem > 0 
    GROUP BY AccrualPeriod, IDVar, Period, VidRiska   
                           
  --3.2. Проставляем признак = 1. ProgramRoundYear.
  update #PremCur set #PremCur.RoundYearProgram1 = 1 from #RoundYearProgram1 
   where #PremCur.AccrualPeriod   = #RoundYearProgram1.AccrualPeriod and
         #PremCur.Period          = #RoundYearProgram1.Period  and 
         #PremCur.IDProgram       = #RoundYearProgram1.IDProgram 
  --==============================================================================



  --==============================================================================
  --3. Округление премии по периодам 
  --==============================================================================
  SELECT
    AccrualPeriod, Period, IDVar, VidRiska, RoundRaznPeriod1, 
    SUM(MyPrem)          AS MyPrem, 
    SUM(MyPremRound)     AS MyPremRound 
    INTO #RoundRaznPeriod1  
    FROM #PremCur
    GROUP BY AccrualPeriod, Period, IDVar, VidRiska, RoundRaznPeriod1
  
  --3.1. Получаем разницу в копейках по периодам.
  UPDATE #RoundRaznPeriod1 SET MyPrem     = ROUND(MyPrem,     2) 
  UPDATE #RoundRaznPeriod1 SET RoundRaznPeriod1 = MyPrem - MyPremRound
 
  --3.2. добавляем полученные копейки на программу 
  UPDATE #PremCur SET #PremCur.RoundRaznPeriod1 = #RoundRaznPeriod1.RoundRaznPeriod1
  FROM   #RoundRaznPeriod1 
  WHERE  #PremCur.AccrualPeriod           = #RoundRaznPeriod1.AccrualPeriod  and
         #PremCur.Period                  = #RoundRaznPeriod1.Period   and 
         #PremCur.VidRiska                = #RoundRaznPeriod1.VidRiska and    
         #PremCur.RoundPeriodProgram1     = 1                          and
         #PremCur.IDVar                   = #RoundRaznPeriod1.IDVar    and
         #RoundRaznPeriod1.RoundRaznPeriod1 <> 0
     
  --3.3. Добавляем копейки     
  UPDATE #PremCur SET MyPremRound     = ROUND(MyPremRound     + RoundRaznPeriod1, 2) WHERE RoundRaznPeriod1 <> 0              
  --==============================================================================
    
       
  --==============================================================================
  --4.Округление премии по годам
  --==============================================================================  
  SELECT
     AccrualPeriod, 
     IDVar,
     RoundRaznYear1, 
     VidRiska, 
     SUM(MyPrem)          AS MyPrem, 
     SUM(MyPremRound)     AS MyPremRound
     INTO #RoundRaznYear1
     FROM #PremCur
     GROUP BY AccrualPeriod, IDVar, RoundRaznYear1, VidRiska 
  
  --4.1. Получаем разницу в копейках по годам.
  UPDATE #RoundRaznYear1 SET MyPrem = ROUND(MyPrem, 2) 
  UPDATE #RoundRaznYear1 SET RoundRaznYear1 = MyPrem - MyPremRound
  
  --4.2. Добавляем полученные копейки на нужную программу нужного периода
  UPDATE #PremCur SET #PremCur.RoundRaznYear1 = #RoundRaznYear1.RoundRaznYear1 
  FROM  #RoundRaznYear1 
  WHERE #PremCur.AccrualPeriod     = #RoundRaznYear1.AccrualPeriod  and
        #PremCur.VidRiska          = #RoundRaznYear1.VidRiska and
        #PremCur.RoundYearPeriod1  = 1  and
        #PremCur.RoundYearProgram1 = 1  and
        #PremCur.IDVar             = #RoundRaznYear1.IDVar and
        #PremCur.MyPremRound       <> 0 
   
  --4.3. Добавляем копейки      
  UPDATE #PremCur SET MyPremRound     = ROUND(MyPremRound     + RoundRaznYear1, 2) WHERE RoundRaznYear1 <> 0   
  
  
  --4.4. Добавляем копейки которые получаются в процессе открепления.
  --Это разница которая получается между Застрахованным который прикрепляется и Застрахованным который открепляется.
  --У нас весь модуль - это расчет одного Застрахованного. MyPremBack2 - это поле которое показывает сколько было бы начислено премии
  --если бы человек прикреплялся. Часто получается такая ситуация когда премия к возврату в периоде не равна премии (на 1 коп.) которая начислена в этом же периоде
  --у другого застрахованного который прикреплется. Это происходит из-за того что кидается копейка на последний период, разница округления.
  --Но мы не можем сделать возврат премии другой нежели тот который был начислен при прикреплении застрахованного по тем периодам которые ещё не наступили!!!
  --Поэтому премия к возврату по тем периодам которые ещё не наступили всегда равна той же которую начислили.
  --Из за этого нужно отлавливать разницу между премией в периоде при откреплении и премией в этом же периоде как если бы человек прикреплялся изначально,
  --и эту разницу кидать на тот период в котором происходит открепление.
  --UPDATE #PremCur SET MyPremRound = MyPremRound + ISNULL((select SUM(MyPremBack - MyPremBack2) from #PremCur WHERE MyPremBack2 <> 0), 0)
  --WHERE (CurrentPeriod = 2) AND (RoundYearProgram1 = 1) 

  --==============================================================================
  --4. Округление премии по периодам. Дополнение. 
  --==============================================================================
  --Возможно это неправильно, но поживем - увидим.
  --Здесь идет сравнение с предыдущим расчетом премии в группировке по периодам.
  --И если не совпадает на несколько копеек, то заменяем из предыдущих значений. Нижеследующий алгоритм фактически отменяет дествие предыдущего...
  --Но что делать пока не ясно. Это сделано по заявке 77050103-00021-04105 Халина Ирина Анатольевна Замена варианта, разница при замене варианта должна быть 0. 
  --Однако она отличается на 1 коп. Этот алгоритм отменяет действие предыдущих. Но суть в том что предыдущие округляют 
  --премию ориентируясь только на собственные расчеты (т.е. считается разница Razn = ROUND(MyPrem) - MyPrem, не беря во внимание предыдущие расчты.
  --Здесь идет сравнение с предыдущим значением и если разница менее 5 коп. то записывается то, что было. 
  --Данный алгорим будет работать и для Замены варианта, так как здесь нет в списке полей группировки ИД Варианта.
  /*SELECT
    AccrualPeriod, Period,  VidRiska, RoundRaznPeriod1, --IDVar,
    SUM(MyPrem)          AS MyPrem, 
    SUM(MyPremRound)     AS MyPremRound,
    SUM(PremPrev)        AS PremPrev,
    SUM(PremPrev - MyPremRound) AS RaznP1 
    INTO #RoundRaznPeriod2  
    FROM dbo.A_PremCurType
    GROUP BY AccrualPeriod, Period, VidRiska, RoundRaznPeriod1 --IDVar,   

  UPDATE #PremCur SET #PremCur.MyPremRound = #RoundRaznPeriod2.PremPrev
  FROM   #RoundRaznPeriod2 
  WHERE  #PremCur.AccrualPeriod           = #RoundRaznPeriod2.AccrualPeriod  and
         #PremCur.Period                  = #RoundRaznPeriod2.Period   and 
         #PremCur.VidRiska                = #RoundRaznPeriod2.VidRiska and  
         ABS(#PremCur.MyPremRound - #RoundRaznPeriod2.PremPrev) < 0.05  
  
 
   
  UPDATE #PremCur SET 
    #PremCur.MyPremRound      = t1.PremPrev,
    #PremCur.FormulaPrem      = #PremCur.FormulaPrem  + ';(K1)=t1.PremPrev ', 
    #PremCur.FormulaDigitPrem = #PremCur.FormulaDigitPrem + ';(K1)=' + CAST(t1.PremPrev as Varchar(max)) + ' '
  FROM    
    (SELECT
    AccrualPeriod, Period,  VidRiska,
    SUM(MyPrem)          AS MyPrem, 
    SUM(MyPremRound)     AS MyPremRound,
    SUM(PremPrev)        AS PremPrev
    FROM #PremCur
    GROUP BY AccrualPeriod, Period, VidRiska) t1        
  WHERE  #PremCur.AccrualPeriod           = t1.AccrualPeriod  and
         #PremCur.Period                  = t1.Period   and 
         #PremCur.VidRiska                = t1.VidRiska and  
         ABS(#PremCur.MyPremRound - t1.PremPrev) < 0.05  
         
  */                                                               
END





--============ Продолжение расчета ============================
--Это нужно сделать сейчас после округления. Округляем мы все суммы для открепления как будто это прикрепление.
--Код одинаков для расчета по месяцам и дням.
--И меняем только сейчас: 
IF (@Operation = 2) OR (@Operation = 4) 
BEGIN
  UPDATE #PremCur SET MyPremBack       = MyPrem,
                      MyPremBackRound  = MyPremRound, 
                      FormulaPremBack  = FormulaPremBack + ';(S7)=MyPrem ',
                      FormulaDigitPremBack = FormulaDigitPremBack + ';(S7)=' + CAST(MyPrem as Varchar(max)) + ' '
  WHERE CurrentPeriod in(2,3) AND TermPercent > 0                                     
      
  UPDATE #PremCur SET 
    MyPrem       = PremPrev - MyPremBack, 
    MyPremRound  = PremPrev - MyPremBackRound,
    FormulaPrem  = FormulaPrem + ';(S8)=PremPrev - MyPremBack ', 
    FormulaDigitPrem  = FormulaDigitPrem + ';(S8)=' + CAST(PremPrev as Varchar(max)) + '-' + CAST(MyPremBack as Varchar(max)) + ' '
  WHERE (CurrentPeriod = 2) AND TermPercent > 0    
  
  
  UPDATE #PremCur SET 
    MyPrem = PremPrev - MyPrem, MyPremRound =  PremPrev - MyPremRound, 
    FormulaPrem           = FormulaPrem + ';(S9)= PremPrev - MyPrem ',
    FormulaDigitPrem      = FormulaDigitPrem + ';(S9)= ' + CAST(PremPrev as Varchar(max)) + '-' + CAST(MyPrem as Varchar(max)) + ' '
  WHERE (CurrentPeriod = 3) AND TermPercent > 0    
  
END

--===============================================================================
--Далее по всем периодам расрочки которые созданы позже по допам по пролонгации, 
--для того чтобы они не участвовали в расчете.
  UPDATE #PremCur SET MyPrem = 0, MyPremBack = 0, 
    FormulaPrem = FormulaPrem  + ';(S10)=0 ', FormulaDigitPrem = FormulaDigitPrem + ';(S10)=0 ',
    FormulaPremBack = FormulaPremBack + ';(S10)=0 ', FormulaDigitPremBack = FormulaDigitPremBack + ';(S10)=0 ' 
    WHERE Operation in(1,3,5) AND (PeriodStart > VarEndCur) 
--===============================================================================

--============ Расчет если ничего не изменилось =================================
--Далее если предыдущий вариант и текущий полностью совпадают - это может быть когда например затрахованный  поменял
--вариант в 1-ом допе, а мы расчитываем например 4-ый. Какой у него был предыдущий вариант выясняем на дату 3-го допа.
--Понятно, что и на 3-ем и на 4-ом допе вариант одинаков. Но расчитывать все равно нужно т.к. могут быть
--другие изменения, например изменился коэффициент или добавилась программа в вариант, или изменилась сумма премия
--по варианту и др. Так вот - если предыдущий и текущий вариант совпадают и премия не изменилась,
--(у нас после расчета оказалось что сумма к возврату = начисленной премии и = предыдущей премии)
--то в этом случае возврат не пишем, ставим его = 0.
  --UPDATE #PremCur SET 
  --  MyPremBack = 0, 
  --  FormulaPremBack = FormulaPremBack + ';(S11)=0 ', 
  --  FormulaDigitPremBack = FormulaDigitPremBack + ';(S11)=0 '
  --WHERE (MyPrem = MyPremBack) AND (IDPercent = 0)
--===============================================================================


--===============================================================================
--Если вариант текущий (IDVar = IDVarCur) то возврата быть не может.
  UPDATE #PremCur SET MyPremBack = 0, 
    FormulaPremBack = FormulaPremBack + ';(S12)=0 ',
    FormulaDigitPremBack = FormulaDigitPremBack + ';(S12)=0 '
  WHERE (Operation = 3) AND (IDVar = IDVarCur)
 --==============================================================================  
   
   
--============ Ситуация когда ничего не изменилось №2 ===========================
--Может быть ситуация, когда открепление было в 1-ом допе, а мы расчитываем на 4-ом.
--Предыдущий вариант и премию смотрим соответственно на 3-ем. В этом случае ВООБЩЕ ничего расчитывать не нужно,
--т.к. открпление произошло раньше и если даже вариант был изменён (добавлиась программа, изменилась премия)
--то менять премию на застрахованном не нужно - даже если премия предыдущим запросами расчиталась по другому
--мы ни в коем случае не должны это учитывать. Поэтому по таким записям ставим предыдущую премию.
--Если Операция - Открепление, и ДатаОткрепления мнешьше чем расчетная дата-1 день, то НИЧЕГО не меняем.
  UPDATE #PremCur SET MyPrem = PremPrev, MyPremBack = PremBackPrev,    
    FormulaPrem = FormulaPrem + ';(S13)= PremPrev ', FormulaDigitPrem = FormulaDigitPrem + '(S13)= PremPrev ',   
    FormulaPremBack = FormulaPremBack + ';(S14)=PremBackPrev ', FormulaDigitPremBack = FormulaDigitPremBack + '(S14)=PremBackPrev '
  WHERE (Operation = 2) AND  DateDiff(y, VarEndCur, StateDate) > 1
--==============================================================================



--============ Чтобы потом проще было суммировать ============================
  UPDATE #PremCur SET MyPremDMS  = MyPremRound WHERE VidRiska = 2 
  UPDATE #PremCur SET MyPremVZR  = MyPremRound WHERE VidRiska = 3 
  UPDATE #PremCur SET MyPremNS   = MyPremRound WHERE VidRiska = 4 
  UPDATE #PremCur SET MyPremDMS  = (-1 * MyPremRound) where (NotCalcItogCur  = 1) and (IDVar = IDVarCur)  --AND CurrentPeriod > 1
  UPDATE #PremCur SET MyPremDMS  = (-1 * MyPremRound) where (NotCalcItogPrev = 1) and (IDVar = IDVarPrev)  --AND CurrentPeriod > 1
  UPDATE #PremCur SET MyPremSUM  = MyPremDMS + MyPremVZR + MyPremNS
  
  UPDATE #PremCur SET MyPremBackDMS = MyPremBackRound WHERE VidRiska = 2 
  UPDATE #PremCur SET MyPremBackVZR = MyPremBackRound WHERE VidRiska = 3 
  UPDATE #PremCur SET MyPremBackNS  = MyPremBackRound WHERE VidRiska = 4 
  UPDATE #PremCur SET MyPremBackDMS = (-1 * MyPremBackRound) where (NotCalcItogCur = 1) and (IDVar = IDVarCur)
  UPDATE #PremCur SET MyPremBackDMS = (-1 * MyPremBackRound) where (NotCalcItogPrev = 1)  and (IDVar = IDVarPrev)
  UPDATE #PremCur SET MyPremBackSUM = MyPremBackDMS + MyPremBackVZR + MyPremBackNS
--============================================================================






--============================================================================
--Сложение страховой суммы:
--Если расчет идет на допе типа Пролонгация, то Страховая сумма у застрахованного должна складываться.
--только на тех застрахованных которые активные (не открепленные - Operation not in(2,4)) 
--нет смены варианта на допе, на котором рассчитываем (IDReason <> @AID)
--увеличение страховой суммы только на текущем вариенте (IDVar = IDVarCur) т.к. у него могла быть смена вариента, давно - несколько допов назад, то допа по пролонгации.
--и только если рассчитываем на допсе по пролонгации - ВидДокумента = 16 это ПролонгацияДогСтрах.
  UPDATE #PremCur SET Amount = Amount + AmountPrev, 
                      AmountDMS = AmountDMS + AmountPrevDMS, 
                      AmountVZR = AmountVZR + AmountPrevVZR, 
                      AmountNS = AmountNS + AmountPrevNS  
   WHERE (Operation not in(2,4)) AND (IDVar = IDVarCur) AND (@VidDoc = 16)                     
--============================================================================


--==============================================================================
-- Удаляем те записи, которые обновлять не нужно. Т.е. после расчета оказалось
-- что ничего не изменилось.
--IF @ResultTable = 0
--  DELETE FROM #PremCur where (PremPrev = MyPrem) AND (PremBackPrev = MyPremBack)
--==============================================================================

IF @UseUpdate = 1 --and  (@HandChangePrem = 0)
BEGIN
--==============================================================================
-- Обновить премию на периодах застрахованного.
-- Сущность: ОтношениеПрограммаСтрахованияПериодРассрочки
-- Здесь также нужно суммировать, т.к. если в программе есть процентовка, то будет дублирование поля ID в #PremCur
-- Прикрепление и Открепление
  SELECT
  ID,
  StateDate,
  SUM(MyPremRound)     as MyPremRound,
  SUM(MyPremBackRound) as MyPremBackRound
  INTO #Table0 FROM #PremCur where CurrentPeriod > 1 
  GROUP BY ID, StateDate

  
  --Создание историчного состояния для каждого объекта ОтношениеПрограммаСтрахованияПериодРассрочки (RelVariantProgramCreditPeriod_Hist) 
  --возможные случаи:
  --№ 1. ID и StateDate не найдены, и по предыдущему историчному состоянию премия НЕ совпадает.
  --№ 2. ID и StateDate не найдены, и по предыдущему историчному состоянию премия совпадает.
  --№ 3. ID и StateDate найдены,    и по предыдущему историчному состоянию премия НЕ совпадает.
  --№ 4. ID и StateDate найдены,    и по предыдущему историчному состоянию премия совпадает.
  
  --Если историчное состояние НЕ найдено (текущие ID, StateDate), то новое вставляется только тогда если премия НЕ совпадает.
  --Если историчное состояние найдено, то оно просто обновляется, то новое НЕ вставляется и неважно совпадает премия или нет.
  --Итого: историчное сосотояние создается только для варианта № 1, для всех останых случаев историчное сосотояние НЕ создается.
  IF @AlwaysCreateHist = 1 
  BEGIN
    insert into RelVariantProgramCreditPeriod_Hist (RelVariantProgramCreditPeriod_HistID, StateDate, EntityID) --, Prem, RestPrem 
    (Select distinct ID, StateDate, 1812 from #Table0 ts where  
    not exists(select 1 from RelVariantProgramCreditPeriod_Hist td where 
              td.RelVariantProgramCreditPeriod_HistID = ts.ID and
              td.StateDate                            = ts.StateDate)            
    ) 
  END ELSE
  BEGIN
    insert into RelVariantProgramCreditPeriod_Hist (RelVariantProgramCreditPeriod_HistID, StateDate, EntityID) --, Prem, RestPrem 
    (Select distinct ID, StateDate, 1812 from #Table0 ts where  
    not exists(select 1 from RelVariantProgramCreditPeriod_Hist td where 
              td.RelVariantProgramCreditPeriod_HistID = ts.ID and
              td.StateDate                            = ts.StateDate) 
             
    and not exists
    (select 1 from RelVariantProgramCreditPeriod_Hist r1 where 
     r1.RelVariantProgramCreditPeriod_HistID = ts.ID And
     r1.StateDate = (Select Max (r2.StateDate) From RelVariantProgramCreditPeriod_Hist r2 Where r2.StateDate <= ts.StateDate and r2.RelVariantProgramCreditPeriod_HistID = ts.ID) and
     IsNull(r1.Prem, 0)      = ts.MyPremRound --and 
     --IsNull(r1.RestPrem, 0)  = ts.MyPremBackRound
     ) 
    )   
  END
  
  --Это обновление уже существующих состояний
  UPDATE RelVariantProgramCreditPeriod_Hist SET
  RelVariantProgramCreditPeriod_Hist.Prem     = #Table0.MyPremRound,
  RelVariantProgramCreditPeriod_Hist.RestPrem = #Table0.MyPremBackRound
  FROM #Table0
  WHERE RelVariantProgramCreditPeriod_Hist.RelVariantProgramCreditPeriod_HistID = #Table0.ID
  AND RelVariantProgramCreditPeriod_Hist.StateDate = #Table0.StateDate
--==============================================================================


--==============================================================================
-- Обновить премию на периодах застрахованного.
-- Сущность: ОтношениеВариантЗастрахованныйПериодРассрочки
-- StateDate - здесь всегда одна, но её нужно вынести в выбираемые поля.
  SELECT
  IDRelVariantPeriod,
  StateDate,
  SUM(MyPremSUM)   as MyPremSUM,
  SUM(MyPremDMS)   as MyPremDMS,
  SUM(MyPremVZR)   as MyPremVZR,
  SUM(MyPremNS)    as MyPremNS, 
  SUM(MyPremBackSUM) as MyPremBackSUM,
  SUM(MyPremBackDMS) as MyPremBackDMS,
  SUM(MyPremBackVZR) as MyPremBackVZR,
  SUM(MyPremBackNS)  as MyPremBackNS
  INTO #Table1 FROM #PremCur where CurrentPeriod > 1 
  GROUP BY IDRelVariantPeriod, StateDate

  --Вставка историчных состояний
  IF @AlwaysCreateHist = 1 
  BEGIN
     insert into RelFaceVariantCreditPeriod_Hist (RelFaceVariantCreditPeriod_HistID, StateDate, EntityID) --, Prem, PremVZR, PremNS, PremDMS, PremBack, PremBackVZR, PremBackNS, PremBackDMS
    (Select distinct IDRelVariantPeriod, StateDate, 1810 from #Table1 ts where  --, MyPrem, MyPremVZR, MyPremNS, MyPremDMS, MyPremBack, MyPremBackVZR, MyPremBackNS, MyPremBackDMS
    not exists(select 1 from RelFaceVariantCreditPeriod_Hist td where 
              td.RelFaceVariantCreditPeriod_HistID = ts.IDRelVariantPeriod and 
              td.StateDate                         = ts.StateDate)  
    )
  END ELSE
  BEGIN
     --Отличие только во втором условии and not exists...
     insert into RelFaceVariantCreditPeriod_Hist (RelFaceVariantCreditPeriod_HistID, StateDate, EntityID) --, Prem, PremVZR, PremNS, PremDMS, PremBack, PremBackVZR, PremBackNS, PremBackDMS
    (Select distinct IDRelVariantPeriod, StateDate, 1810 from #Table1 ts where  --, MyPrem, MyPremVZR, MyPremNS, MyPremDMS, MyPremBack, MyPremBackVZR, MyPremBackNS, MyPremBackDMS
    not exists(select 1 from RelFaceVariantCreditPeriod_Hist td where 
              td.RelFaceVariantCreditPeriod_HistID = ts.IDRelVariantPeriod and 
              td.StateDate                         = ts.StateDate)  
    and not exists(select 1 from RelFaceVariantCreditPeriod_Hist r1 where 
                r1.RelFaceVariantCreditPeriod_HistID = ts.IDRelVariantPeriod and 
                r1.StateDate = (select max(r2.StateDate) from RelFaceVariantCreditPeriod_Hist r2 where r2.StateDate <= ts.StateDate and r2.RelFaceVariantCreditPeriod_HistID = ts.IDRelVariantPeriod) and
                isnull(r1.Prem, 0)        = ts.MyPremSUM     and
                isnull(r1.PremVZR, 0)     = ts.MyPremVZR     and
                isnull(r1.PremNS, 0)      = ts.MyPremNS      and
                isnull(r1.PremDMS, 0)     = ts.MyPremDMS     --and 
                --isnull(r1.PremBack, 0)    = ts.MyPremBackSUM and 
                --isnull(r1.PremBackVZR, 0) = ts.MyPremBackVZR and 
                --isnull(r1.PremBackNS, 0)  = ts.MyPremBackNS  and 
                --isnull(r1.PremBackDMS, 0) = ts.MyPremBackDMS
                )
    )  
  END

  UPDATE RelFaceVariantCreditPeriod_Hist SET
  RelFaceVariantCreditPeriod_Hist.Prem        = #Table1.MyPremSUM,
  RelFaceVariantCreditPeriod_Hist.PremDMS     = #Table1.MyPremDMS, 
  RelFaceVariantCreditPeriod_Hist.PremVZR     = #Table1.MyPremVZR, 
  RelFaceVariantCreditPeriod_Hist.PremNS      = #Table1.MyPremNS, 
  
  RelFaceVariantCreditPeriod_Hist.PremBack    = #Table1.MyPremBackSUM, 
  RelFaceVariantCreditPeriod_Hist.PremBackDMS = #Table1.MyPremBackDMS, 
  RelFaceVariantCreditPeriod_Hist.PremBackVZR = #Table1.MyPremBackVZR, 
  RelFaceVariantCreditPeriod_Hist.PremBackNS  = #Table1.MyPremBackNS
  
  FROM #Table1
  WHERE RelFaceVariantCreditPeriod_Hist.RelFaceVariantCreditPeriod_HistID = #Table1.IDRelVariantPeriod
  AND RelFaceVariantCreditPeriod_Hist.StateDate = #Table1.StateDate
--==============================================================================




--==============================================================================
-- Обновить ИЗМЕНЕНИЕ премии на периодах застрахованного.
-- Сущность: ОтношениеВариантЗастрахованныйПериодРассрочки
/*Select
  1234567890 as IDRelVariantPeriod,
  ПериодРассрочкиДогСтрах Period,
  (SUM(IsNull(О1.Премия, 0)) - SUM(IsNull(О2.Премия, 0))) as RaznSUM,
  (SUM(IsNull(О1.ПремияДМС, 0)) - SUM(IsNull(О2.ПремияДМС, 0))) as RaznDMS,
  (SUM(IsNull(О1.ПремияВЗР, 0)) - SUM(IsNull(О2.ПремияВЗР, 0))) as RaznVZR,
  (SUM(IsNull(О1.ПремияНС, 0)) - SUM(IsNull(О2.ПремияНС, 0))) as RaznNS
From
  ОтношениеВариантЗастрахованныйПериодРассрочки О1
  LEFT JOIN ОтношениеВариантЗастрахованныйПериодРассрочки О2
    On О2.ИДОбъекта = О1.ИДОбъекта AND О2.ДатаСостОбъекта = '02.11.2013'
Where
  О1.ДатаСостОбъекта = '15.11.2013'
  AND О1.ВариантЗастрахованный.Застрахованный = 622187
  AND О2.ВариантЗастрахованный.Застрахованный = О1.ВариантЗастрахованный.Застрахованный
Group By ПериодРассрочкиДогСтрах
*/

Select
  1234567890 "IDRelVariantPeriod",
  EOT_1.ContractCreditPeriodID "Period",
  (Sum(IsNull(EOT_2.Prem, 0))
  - Sum(IsNull(EOT_4.Prem, 0))) "RaznSUM",
  (Sum(IsNull(EOT_2.PremDMS, 0))
  - Sum(IsNull(EOT_4.PremDMS, 0))) "RaznDMS",
  (Sum(IsNull(EOT_2.PremVZR, 0))
  - Sum(IsNull(EOT_4.PremVZR, 0))) "RaznVZR",
  (Sum(IsNull(EOT_2.PremNS, 0))
  - Sum(IsNull(EOT_4.PremNS, 0))) "RaznNS"
into #Razn1  
From
  RelFaceVariantCreditPeriod EOT_1
  Left Outer Join RelFaceVariantCreditPeriod_Hist EOT_2
    On (EOT_2.RelFaceVariantCreditPeriod_HistID = EOT_1.RelFaceVariantCreditPeriodID) And (EOT_2.StateDate = (
      Select
        Max(StateDate)
      From
        RelFaceVariantCreditPeriod_Hist
      Where
        (StateDate <= @DateCur) And (EOT_1.RelFaceVariantCreditPeriodID = RelFaceVariantCreditPeriod_HistID)
    ))
  Left Outer Join FaceVariant EOT_5
    On EOT_5.ID = EOT_1.FaceVariantID
  LEFT JOIN RelFaceVariantCreditPeriod EOT_3 Left Outer Join RelFaceVariantCreditPeriod_Hist EOT_4
    On (EOT_4.RelFaceVariantCreditPeriod_HistID = EOT_3.RelFaceVariantCreditPeriodID) And (EOT_4.StateDate = (
      Select
        Max(StateDate)
      From
        RelFaceVariantCreditPeriod_Hist
      Where
        (StateDate <= @DatePrev) And (EOT_3.RelFaceVariantCreditPeriodID = RelFaceVariantCreditPeriod_HistID)
    ))
    On EOT_3.RelFaceVariantCreditPeriodID = EOT_1.RelFaceVariantCreditPeriodID
  Left Outer Join FaceVariant EOT_10
    On EOT_10.ID = EOT_3.FaceVariantID
Where
  EOT_5.FaceID = @IDIns AND EOT_10.FaceID = EOT_5.FaceID
Group By
  EOT_1.ContractCreditPeriodID


--drop table dbo.A_Razn1
--select @IDVarCur as IDVarCur, @DateCur as DateCur, * into dbo.A_Razn1 from #Razn1
--select * into dbo.A_Razn1 from #Razn1
update #Razn1 set #Razn1.IDRelVariantPeriod = #PremCur.IDRelVariantPeriod 
from #PremCur where 
#Razn1.Period = #PremCur.Period and #PremCur.IDVar = @IDVarCur



UPDATE RelFaceVariantCreditPeriod_Hist SET
    RelFaceVariantCreditPeriod_Hist.Change        = #Razn1.RaznSUM,
    RelFaceVariantCreditPeriod_Hist.ChangeDMS     = #Razn1.RaznDMS, 
    RelFaceVariantCreditPeriod_Hist.ChangeVZR     = #Razn1.RaznVZR, 
    RelFaceVariantCreditPeriod_Hist.ChangeNS      = #Razn1.RaznNS 
  FROM #Razn1
    WHERE RelFaceVariantCreditPeriod_Hist.RelFaceVariantCreditPeriod_HistID = #Razn1.IDRelVariantPeriod
    AND RelFaceVariantCreditPeriod_Hist.StateDate = @DateCur

--==============================================================================




--==============================================================================
-- Обновить премию на самих застрахованных
-- Сущность: ВариантЗастрахованный
  /*SELECT
  IDVar,
  StateDate,
  SUM(MyPremSUM)     as MyPremSUM,
  SUM(MyPremDMS)     as MyPremDMS,
  SUM(MyPremVZR)     as MyPremVZR,
  SUM(MyPremNS)      as MyPremNS,
  SUM(MyPremBackSUM) as MyPremBackSUM,
  SUM(MyPremBackDMS) as MyPremBackDMS,
  SUM(MyPremBackVZR) as MyPremBackVZR,
  SUM(MyPremBackNS)  as MyPremBackNS 
  INTO #Table2 FROM #PremCur GROUP BY IDVar, StateDate
  */
  
  
  /*Select
  ВариантЗастрахованный as IDVar,
  --@DateCur as StateDate,
  SUM(IsNull(Премия, 0))    as MyPremSUM,
  SUM(IsNull(ПремияДМС, 0)) as MyPremDMS,
  SUM(IsNull(ПремияВЗР, 0)) as MyPremVZR,
  SUM(IsNull(ПремияНС, 0))  as MyPremNS,
  SUM(IsNull(ПремияКВозврату, 0))    as MyPremBackSUM,
  SUM(IsNull(ПремияКВозвратуДМС, 0)) as MyPremBackDMS,
  SUM(IsNull(ПремияКВозвратуВЗР, 0)) as MyPremBackVZR,
  SUM(IsNull(ПремияКВозвратуНС, 0))  as MyPremBackNS
  --into #Table2
  From
    ОтношениеВариантЗастрахованныйПериодРассрочки
  Where
    ДатаСостОбъекта = '15.11.2013'
    AND ВариантЗастрахованный.Застрахованный = 622187
  --and ВариантЗастрахованный in(select IDVar from #PremCur)
  Group By ВариантЗастрахованный
  */


  --Здесь получение данных из БД чтобы их суммировать
  Select
  EOT_1.FaceVariantID "IDVar",
  @DateCur "StateDate",
  Sum(IsNull(EOT_2.Prem, 0))
  "MyPremSUM",
  Sum(IsNull(EOT_2.PremDMS, 0))
  "MyPremDMS",
  Sum(IsNull(EOT_2.PremVZR, 0))
  "MyPremVZR",
  Sum(IsNull(EOT_2.PremNS, 0))
  "MyPremNS",
  Sum(IsNull(EOT_2.PremBack, 0))
  "MyPremBackSUM",
  Sum(IsNull(EOT_2.PremBackDMS, 0))
  "MyPremBackDMS",
  Sum(IsNull(EOT_2.PremBackVZR, 0))
  "MyPremBackVZR",
  Sum(IsNull(EOT_2.PremBackNS, 0))
  "MyPremBackNS"
  into #Table2
From
  RelFaceVariantCreditPeriod EOT_1
  Left Outer Join RelFaceVariantCreditPeriod_Hist EOT_2
    On (EOT_2.RelFaceVariantCreditPeriod_HistID = EOT_1.RelFaceVariantCreditPeriodID) And (EOT_2.StateDate = (
      Select
        Max(StateDate)
      From
        RelFaceVariantCreditPeriod_Hist
      Where
        (StateDate <= @DateCur) And (EOT_1.RelFaceVariantCreditPeriodID = RelFaceVariantCreditPeriod_HistID)
    ))
  Left Outer Join FaceVariant EOT_3
    On EOT_3.ID = EOT_1.FaceVariantID
Where
  EOT_3.FaceID = @IDIns
Group By
  EOT_1.FaceVariantID




  --Вставка историчных состояний премии
  IF @AlwaysCreateHist = 1 
  BEGIN
    insert into FaceVariant_Hist_Prem (ID, StateDate, EntityID) --, Prem, RestPrem 
    (Select distinct IDVar, StateDate, 1711 from #Table2 ts where  --, MyPrem, MyPremBack
    not exists(select 1 from FaceVariant_Hist_Prem td where 
              td.ID        = ts.IDVar and 
              td.StateDate = ts.StateDate)
    ) 
  END ELSE
  BEGIN
    insert into FaceVariant_Hist_Prem (ID, StateDate, EntityID) --, Prem, RestPrem 
      (Select distinct IDVar, StateDate, 1711 from #Table2 ts where  --, MyPrem, MyPremBack
      not exists(select 1 from FaceVariant_Hist_Prem td where 
                td.ID        = ts.IDVar and 
                td.StateDate = ts.StateDate) 
    and not exists
    (select 1 from FaceVariant_Hist_Prem r1 where 
     r1.ID = ts.IDVar And   
     r1.StateDate = (Select Max (r2.StateDate) From FaceVariant_Hist_Prem r2 Where r2.StateDate <= ts.StateDate and r2.ID = ts.IDVar) and 
     isnull(r1.Prem, 0)        = ts.MyPremSUM     and
     isnull(r1.PremVZR, 0)     = ts.MyPremVZR     and
     isnull(r1.PremNS, 0)      = ts.MyPremNS      and
     isnull(r1.PremDMS, 0)     = ts.MyPremDMS     --and 
     --isnull(r1.PremBack, 0)    = ts.MyPremBackSUM and 
     --isnull(r1.PremBackVZR, 0) = ts.MyPremBackVZR and 
     --isnull(r1.PremBackNS, 0)  = ts.MyPremBackNS  and 
     --isnull(r1.PremBackDMS, 0) = ts.MyPremBackDMS
     )
    )    
  END

  
  --Страховая премия
  UPDATE FaceVariant_Hist_Prem SET
  Prem        = #Table2.MyPremSUM, 
  PremDMS     = #Table2.MyPremDMS, 
  PremVZR     = #Table2.MyPremVZR, 
  PremNS      = #Table2.MyPremNS, 
  
  PremBack    = #Table2.MyPremBackSUM, 
  PremBackDMS = #Table2.MyPremBackDMS,
  PremBackVZR = #Table2.MyPremBackVZR, 
  PremBackNS  = #Table2.MyPremBackNS
  
  FROM #Table2
  WHERE FaceVariant_Hist_Prem.ID = #Table2.IDVar
  AND FaceVariant_Hist_Prem.StateDate = #Table2.StateDate



  --Страховая сумма 
  SELECT DISTINCT IDVar, Amount, AmountDMS, AmountVZR, AmountNS, StateDate INTO #Table3 FROM #PremCur 
  
  --Вставка историчных состояний суммы
  IF @AlwaysCreateHist = 1 
  BEGIN
    INSERT INTO FaceVariant_Hist_Amount (ID, StateDate, EntityID) 
    (SELECT DISTINCT IDVar, StateDate, 1711 FROM #Table3 ts WHERE 
    not exists(SELECT 1 FROM FaceVariant_Hist_Amount td WHERE 
              td.ID        = ts.IDVar and 
              td.StateDate = ts.StateDate)
    ) 
  END ELSE
  BEGIN
     INSERT INTO FaceVariant_Hist_Amount (ID, StateDate, EntityID) 
    (SELECT DISTINCT IDVar, StateDate, 1711 FROM #Table3 ts WHERE 
    not exists(SELECT 1 FROM FaceVariant_Hist_Amount td WHERE 
              td.ID        = ts.IDVar and 
              td.StateDate = ts.StateDate) 
    and not exists
    (select 1 from FaceVariant_Hist_Amount r1 where 
     r1.ID = ts.IDVar and   
     r1.StateDate = (Select Max (r2.StateDate) From FaceVariant_Hist_Amount r2 Where r2.StateDate <= ts.StateDate and r2.ID = ts.IDVar) and 
     isnull(r1.Amount, 0)        = ts.Amount        and
     isnull(r1.AmountVZR, 0)     = ts.AmountVZR     and
     isnull(r1.AmountNS, 0)      = ts.AmountNS      and
     isnull(r1.AmountDMS, 0)     = ts.AmountDMS)
    )  
  END
  
  
  UPDATE FaceVariant_Hist_Amount SET
  Amount    = #Table3.Amount,
  AmountDMS = #Table3.AmountDMS, 
  AmountVZR = #Table3.AmountVZR, 
  AmountNS  = #Table3.AmountNS
  FROM #Table3
  WHERE FaceVariant_Hist_Amount.ID = #Table3.IDVar
  AND FaceVariant_Hist_Amount.StateDate = #Table3.StateDate
END
--==============================================================================


--==============================================================================
-- Обновить ИЗМЕНЕНИЕ премии на самих застрахованного.
-- Сущность: ВариантЗастрахованный
/*Select
  (SUM(IsNull(О1.Премия, 0)) - SUM(IsNull(О2.Премия, 0))) as RaznSUM,
  (SUM(IsNull(О1.ПремияДМС, 0)) - SUM(IsNull(О2.ПремияДМС, 0))) as RaznDMS,
  (SUM(IsNull(О1.ПремияВЗР, 0)) - SUM(IsNull(О2.ПремияВЗР, 0))) as RaznVZR,
  (SUM(IsNull(О1.ПремияНС, 0)) - SUM(IsNull(О2.ПремияНС, 0))) as RaznNS
From
  ВариантЗастрахованный О1
  LEFT JOIN ВариантЗастрахованный О2
    On О2.ИДОбъекта = О1.ИДОбъекта AND О2.ДатаСостОбъекта = '02.11.2013'
Where
  О1.ДатаСостОбъекта = '15.11.2013'
  AND О1.Застрахованный = 622187
  AND О2.Застрахованный = О1.Застрахованный
*/

Select
  (Sum(IsNull(EOT_2.Prem, 0))
  - Sum(IsNull(EOT_7.Prem, 0))) "RaznSUM",
  (Sum(IsNull(EOT_2.PremDMS, 0))
  - Sum(IsNull(EOT_7.PremDMS, 0))) "RaznDMS",
  (Sum(IsNull(EOT_2.PremVZR, 0))
  - Sum(IsNull(EOT_7.PremVZR, 0))) "RaznVZR",
  (Sum(IsNull(EOT_2.PremNS, 0))
  - Sum(IsNull(EOT_7.PremNS, 0))) "RaznNS"
into #Razn2  
From
  FaceVariant EOT_1
  Left Outer Join FaceVariant_Hist_Prem EOT_2
    On (EOT_2.ID = EOT_1.ID) And (EOT_2.StateDate = (
      Select
        Max(StateDate)
      From
        FaceVariant_Hist_Prem
      Where
        (StateDate <= @DateCur) And (EOT_1.ID = ID)
    ))
  LEFT JOIN FaceVariant EOT_6 Left Outer Join FaceVariant_Hist_Prem EOT_7
    On (EOT_7.ID = EOT_6.ID) And (EOT_7.StateDate = (
      Select
        Max(StateDate)
      From
        FaceVariant_Hist_Prem
      Where
        (StateDate <= @DatePrev) And (EOT_6.ID = ID)
    ))
    On EOT_6.ID = EOT_1.ID
  Where
  EOT_1.FaceID = @IDIns AND EOT_6.FaceID = EOT_1.FaceID
  

  UPDATE FaceVariant_Hist_Prem SET
    Change        = #Razn2.RaznSUM, 
    ChangeDMS     = #Razn2.RaznDMS, 
    ChangeVZR     = #Razn2.RaznVZR, 
    ChangeNS      = #Razn2.RaznNS  
  FROM #Razn2
  WHERE FaceVariant_Hist_Prem.ID = @IDVarCur
  AND FaceVariant_Hist_Prem.StateDate = @DateCur
  
--==============================================================================


--============================================================================
-- Для тестирования. @ResultTable - параметр для тестирования, если 1 или 3, то это тест
IF (@ResultTable = 1) OR (@ResultTable = 3)
BEGIN
  UPDATE #PremCur SET Prem = 0 WHERE TermPercent = 0 AND IDPercent > 0
  UPDATE #PremCur SET DiffPrem = (Prem - MyPrem)
  UPDATE #PremCur SET DiffPremBack = (PremBack - MyPremBack)
  
  DROP TABLE dbo.A_PremCurType --Пока для режима разработки, потому что постоянно меняется нобор полей.
  --DROP TABLE  dbo.A_PremPrevType
  
  SELECT * INTO dbo.A_PremCurType  FROM #PremCur
  --SELECT * INTO dbo.A_PremPrevType FROM #PremPrev
  
  --TRUNCATE TABLE dbo.A_PremCurType
  --TRUNCATE TABLE dbo.A_PremPrevType
  
  --INSERT INTO dbo.A_PremCurType SELECT * FROM #PremCur
  --INSERT INTO dbo.A_PremPrevType SELECT * FROM #PremPrev
  --SELECT * FROM #PremCur
    SELECT 
         FormulaPrem          as "Формулы расчета премии|(FormulaPrem) Премия",
         FormulaDigitPrem     as "Формулы расчета премии|(FormulaDigitPrem) Премия - цифры",
         FormulaPremBack      as "Формулы расчета премии|(FormulaPremBack) Премия к возврату",
         FormulaDigitPremBack as "Формулы расчета премии|(FormulaDigitPremBack) Премия к возврату - цифры",
         
         DiffPrem       as "Отличие от предыдущего расчета|(DiffPrem) Премия",
         DiffPremBack   as "Отличие от предыдущего расчета|(DiffPremBack) Возврат премии",         
         Prem           as "Премия рассчитанная ранее|(Prem) Премия",
         PremBack       as "Премия рассчитанная ранее|(PremBack) Премия к возврату",
         PremPrev       as "Премия предыдущая|(PremPrev) Премия",
         PremBackPrev   as "Премия предыдущая|(PremBackPrev) Премия к возврату",
         
         MyPrem         as "Рассчитанная премия|(MyPrem) Премия без округления", 
         MyPremRound    as "Рассчитанная премия|(MyPremRound) Округленная Премия", 
         MyPremSUM      as "Рассчитанная премия|(MyPremSUM) Премия отображаемая",        
         MyPremDMS      as "Рассчитанная премия|(MyPremDMS) Премия ДМС",
         MyPremVZR      as "Рассчитанная премия|(MyPremVZR) Премия ВЗР",
         MyPremNS       as "Рассчитанная премия|(MyPremNS) Премия НС",
                 
         MyPremBack      as "Рассчитанная премия к возврату|(MyPremBack) Премия к возврату",
         MyPremBack2     as "Рассчитанная премия к возврату|(MyPremBack2) Премия к возврату",
         MyPremBackRound as "Рассчитанная премия к возврату|(MyPremBackRound) Премия к возврату Округленная", 
         MyPremBackSUM   as "Рассчитанная премия к возврату|(MyPremBackSUM) Премия к возврату отображаемая", 
         MyPremBackDMS   as "Рассчитанная премия к возврату|(MyPremBackDMS) Премия к возврату ДМС",
         MyPremBackVZR   as "Рассчитанная премия к возврату|(MyPremBackVZR) Премия к возврату ВЗР",
         MyPremBackNS    as "Рассчитанная премия к возврату|(MyPremBackNS) Премия к возврату НС",
                             
         RoundPeriodProgram1 as "Округление|Начисленная премия|(RoundPeriodProgram1) Округление по периодам - программа", 
         RoundYearPeriod1    as "Округление|Начисленная премия|(RoundYearPeriod1) Округление по годам - период", 
         RoundYearProgram1   as "Округление|Начисленная премия|(RoundYearProgram1) Округление по годам - программа", 
         RoundRaznPeriod1    as "Округление|Начисленная премия|(RoundRaznPeriod1) Округление по периодам - копейки",
         RoundRaznYear1      as "Округление|Начисленная премия|(RoundRaznYear1) Округление по годам - копейки",           
         
         DateCalc       as "(DateCalc) Дата и время расчета",
         ID             as "(ID) ИДОбъекта Отношение программа страхования период рассрочки",
         IDRelVariantPeriod as "(IDRelVariantPeriod) ИДОбъекта Отношение вариант застрахованный период рассрочки",
         
         IDDog          as "Договор страхования|(IDDog) ИДОбъекта",
         DogBeg         as "Договор страхования|(DogEnd) Дата начала",
         DogEnd         as "Договор страхования|(DogEnd) Дата окончания",
         MethodCalcPrem as "Договор страхования|(MethodCalcPrem) Метод расчета премии",
         FirstPeriodCalcByDays as "Договор страхования|(FirstPeriodCalcByDays) Расчитывать неполный период по дням", 
         RVDPrem        as "Договор страхования|(RVDPrem) РВД",
         
         IDProgram        as "Программа страхования|(IDProgram) ИДОбъекта",
         StProg           as "Программа страхования|(StProg) Программа в справочнике",
         ProgramPercent   as "Программа страхования|(ProgramPercent) Прикрепление",
         ProgPrem         as "Программа страхования|(ProgPrem) Премия",
         ProgAmount       as "Программа страхования|(ProgAmount) Сумма",         
         ProgPremPrev     as "Программа страхования|(ProgPremPrev) Премия предыдущая",           
         WithoutPayBack   as "Программа страхования|(WithoutPayBack) Без возврата",
         WithoutTerm      as "Программа страхования|(WithoutTerm) Без рассрочки", 
         VidRiska         as "Программа страхования|(VidRiska)Вид риска", 
         NoKoefAge        as "Программа страхования|(NoKoefAge) Не применять возраст. коэф",
         NoKoefIll        as "Программа страхования|(NoKoefIll) Не применять коэф. забол",
         NotCalcItogCur   as "Программа страхования|(NotCalcItogCur) Не уч.в расчетах итого тек.",
         NotCalcItogPrev  as "Программа страхования|(NotCalcItogPrev) Не уч.в расчетах итого пред.",
         TermPercent      as "Программа страхования|(TermPercent) Процент по процентовке",
         TermPercentPrev  as "Программа страхования|(TermPercentPrev) Процент по процентовке предыдущий",
         SameProg         as "Программа страхования|(SameProg) Сходная по параметрам программа",

         IDPercent      as "Процентовка|(IDPercent) ИДОбъекта",
         Month1         as "Процентовка|(Month1) Месяцев1",
         Month2         as "Процентовка|(Month2) Месяцев2",
         Percent1       as "Процентовка|(Percent1) Процент",
                 
         IDIns           as "Застрахованный|(IDIns) ИДОбъекта",
         Operation       as "Застрахованный|(Operation) Операция",         
         InsStart        as "Застрахованный|(InsStart) ДатаНачала",
         InsEnd          as "Застрахованный|(InsEnd) ДатаОкончания",
         InsStartPrev    as "Застрахованный|(InsStartPrev) ДатаНачала предыдущий",
         InsEndPrev      as "Застрахованный|(InsEndPrev) ДатаОкончания предыдущий",
                
         KoefAge         as "Застрахованный|(KoefAge) Коэф. по возрасту",
         KoefIll         as "Застрахованный|(KoefIll) Коэф. по забол.",
         Koef            as "Застрахованный|(Koef) Коэф.",
         KoefAgePrev     as "Застрахованный|(KoefAgePrev) Коэф. по возрасту предыдущий",
         KoefIllPrev     as "Застрахованный|(KoefIllPrev) Коэф. по забол. предыдущий",
         KoefPrev        as "Застрахованный|(KoefPrev) Коэф. предыдущий",
         BirthDate       as "Застрахованный|(BirthDate) Дата рождения",      
         Age             as "Застрахованный|(Age) Возраст",               
         
         IDVarNaim       as "Вариант по договору|(IDVarNaim) ИДОбъекта",
         VarDogStart     as "Вариант по договору|(VarDogStart) Дата начала ",
         VarDogEnd       as "Вариант по договору|(VarDogEnd) Дата окончания",
         VarDogStartPrev as "Вариант по договору|(VarDogStartPrev) ИДОбъекта",
         VarDogEndPrev   as "Вариант по договору|(VarDogEndPrev) ИДОбъекта",        
         KolMonthVar     as "Вариант по договору|(KolMonthVar) Кол-во месяцев",
         Amount          as "Вариант по договору|(Amount) Сумма",
         AmountDMS       as "Вариант по договору|(AmountDMS) Сумма ДМС",
         AmountVZR       as "Вариант по договору|(AmountVZR) Сумма ВЗР",
         AmountNS        as "Вариант по договору|(AmountNS) Сумма НС",
         AmountPrev      as "Вариант по договору|(AmountPrev) Сумма предыдущаая",
         AmountPrevDMS   as "Вариант по договору|(AmountPrevDMS) Сумма ДМС предыдущаая",
         AmountPrevVZR   as "Вариант по договору|(AmountPrevVZR) Сумма ВЗР предыдущаая",
         AmountPrevNS    as "Вариант по договору|(AmountPrevNS) Сумма НС предыдущаая",
                                                  
         IDVar          as "Вариант застрахованный|(IDVar) ИДОбъекта",         
         IDVarCur       as "Вариант застрахованный|(IDVarCur) Вариант застрахованный текущий",
         IDVarPrev      as "Вариант застрахованный|(IDVarPrev) Вариант застрахованный предыдущий",            
         VarStartCur    as "Вариант застрахованный|(VarStartCur) Дата начала текущий",
         VarEndCur      as "Вариант застрахованный|(VarEndCur) Дата окончания текущий",                       
         VarStartPrev   as "Вариант застрахованный|(VarStartPrev) ДатаНачала предыдущий",
         VarEndPrev     as "Вариант застрахованный|(VarEndPrev) ДатаОкончания предыдущий",      
         VarCurPrem     as "Вариант застрахованный|(VarCurPrem) Премия",
         IDReason       as "Вариант застрахованный|(IDReason) Основание прикрепления",
         IDReasonOFF    as "Вариант застрахованный|(IDReasonOFF) Основание открепления",
         
         Period          as "Период рассрочки|(Period) ИДОбъекта",
         AccrualPeriod   as "Период рассрочки|(AccrualPeriod) Период начисления",
         PeriodStart     as "Период рассрочки|(PeriodStart) Дата начала",
         PeriodEnd       as "Период рассрочки|(PeriodEnd) Дата окончания",
         KolDayPeriod    as "Период рассрочки|(KolDayPeriod) Кол-во дней периода",        
         NumPeriod       as "Период рассрочки|(NumPeriod) Номер периода в году",
         Term            as "Период рассрочки|(Term) КоличествоМесяцев",
         NumYear         as "Период рассрочки|(NumYear) Количество лет",
         KolMonthPeriod  as "Период рассрочки|(KolMonthPeriod) КолвоМесяцевПериода",
                   
         CurrentPeriod    as "(CurrentPeriod) Перриод. 1-Прошедший, 2-Текущий, 3-НеНаступивший",
         KolDayIns        as "(KolDayIns) Кол-во дней страхования застрахованнеого в периоде",
         KolDayInsRest    as "(KolDayInsRest) Кол-во дней от даты допа до конца периода",    
         KolMonthInsRest  as "(KolMonthInsRest) Кол-во месяцев от даты допа до конца периода",            
         MyRVDPrem        as "(MyRVDPrem) РВД посчитанное",        
         KolDayVar        as "(KolDayVar) Кол-во дней действия варианта",
         PercentPrik      as "(PercentPrik) Проценты по прекреплению за 3 мес.",
         Loss             as "(Loss) Убыток",         
         StateDate        as "(StateDate) Дата состояния",
         @DatePrev        as "(DatePrev) Предыдущая дата состояния",
         IDReason         as "(IDReason) ВариантЗастрахованный Основание",
         AID              as "(AID) ID Доп.согл.",
         VidDoc           as "(VidDoc) Вид доп.согл."
         from #PremCur order by IDVar, PeriodStart
END

--Возвращать что-то нужно
IF @ResultTable = 0
  SELECT 1 AS Result

--Данный возврат нужен для того чтобы рассчитать сумму возврата перед расторжением договора.
IF @ResultTable = 2
BEGIN  
  --DECLARE @ResultCancel NUMERIC(31,10)  
  --SELECT @ResultCancel = SUM(MyPremBackSUM) from #PremCur
  --SELECT (CASE WHEN SUM(MyPremBackSUM) < 0 THEN 0 ELSE SUM(MyPremBackSUM) END) as Result from #PremCur
  
  SELECT SUM(MyPremBackSUM) as Result from #PremCur where CurrentPeriod < 3
  --IF @ResultCancel < 0 
  --  SET @ResultCancel = 0
  --SELECT @ResultCancel as Result   
END  
 
--Данный возврат нужен для того чтобы показать сумма начисленной премии (для  юнит тестов).
IF @ResultTable = 3
BEGIN   
  SELECT SUM(MyPremSUM) as Result from #PremCur where CurrentPeriod > 1
END 
 
END
--SELECT * from dbo.A_PremCurType
--SELECT * from dbo.A_PremPrevType


