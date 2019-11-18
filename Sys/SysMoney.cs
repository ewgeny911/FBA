
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
//Не протестировано.
namespace FBA
{	
	              
    /// <summary>
    /// Валюты, с которыми мы умеем работать
    /// </summary>
	public enum enuSupportedCurrencies
	{				
		///Гривна			
		eiHryvna=1,
	  
		///Рубль	
		eiRoubles=2,
	  
		///Доллар		
		eiDollar,
	   
		///Евро 
		eiEURO
	}
			
	// <summary>
	// Деньги.	
    //Вызывать например так :
    // Сумма прописью для валюты 
    /*     
    /// <param name="p_decAmount">Сумма</param>
        /// <param name="p_enuCurrency">В какой валюте сумма</param>
        /// <param name="p_blnFirstLetterUppercase">С большой буквы ?</param>
        /// <returns>Сумма прописью</returns>
        public static string AmountInWords( decimal p_decAmount, 
                                            Money.enuSupportedCurrencies p_enuCurrency,
                                            bool p_blnFirstLetterUppercase)
        {
            string strAmountInWords=string.Empty;
            Money.Money oMoney=(Money.Money)(double)p_decAmount;
            
                switch (p_enuCurrency)
                {
                    case Money.enuSupportedCurrencies.eiDollar:
                    {
                        strAmountInWords=oMoney.ToString(new Money.DollarToStringProvider(false,false,true));
                        break;
                    }
                    case Money.enuSupportedCurrencies.eiEURO:
                    {
                        strAmountInWords=oMoney.ToString(new Money.EUROToStringProvider(false,false,true));
                        break;
                    }
                    case Money.enuSupportedCurrencies.eiHryvna:
                    {
                        strAmountInWords=oMoney.ToString(new Money.HryvnaToStringProvider(false,false,true));
                        break;
                    }
                    case Money.enuSupportedCurrencies.eiRoubles:
                    {
                        strAmountInWords=oMoney.ToString(new Money.RoubleToStringProvider(false,false,true));
                        break;
                    }
                }
                if (p_blnFirstLetterUppercase)
                {
                    strAmountInWords=strAmountInWords.Substring(0,1).ToUpper() + strAmountInWords.Substring(1);
                }
            return strAmountInWords;
        }   
    */
    	    	  
	/// <summary>
	/// Сумма прописью.
	/// </summary>
	public struct Money 
	{	
		//Внутреннее представление - количество копеек.	  
 		private long value;
		 		
		/// <summary>
		/// Конструкторы.
		/// </summary>
		/// <param name="value"></param>
		public Money(double value) 
		{
			this.value = (long) Math.Round(100 * value, 2);
		}
		
		/// <summary>
		/// Money
		/// </summary>
		/// <param name="high"></param>
		/// <param name="low"></param>
		public Money(long high, byte low) 
		{
			if (low < 0 || low > 99) 
				throw new ArgumentException();
			if (high >= 0) 
				value = 100 * high + low;
			else 
				value = 100 * high - low;
		}
					
		/// <summary>
		/// Вспомогательный конструктор.
		/// </summary>
		/// <param name="copecks"></param>
		private Money(long copecks)  
		{ 
			this.value = copecks; 
		}
		 
		/// <summary>
		/// Количество гривень.
		/// </summary>
 		public long High
		{
			get 
			{ 
				return value / 100; 
			}
		}
	   
		/// <summary>
		/// Количество копеек.
		/// </summary>	
 		public byte Low
		{
			get 
			{ 
				return (byte) (value % 100); 
			}
		}
		 		  
		/// <summary>
		/// Абсолютная величина.	
		/// </summary>
		/// <returns></returns>
 		public Money Abs()      
		{ 
			return new Money(Math.Abs(value)); 
		}
		
		/// <summary>
		/// Сложение - функциональная форма.	 
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
 		public Money Add(Money r)       
		{ 
			return new Money(value + r.value); 
		}
	 
		/// <summary>
		/// Вычитание - функциональная форма 
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
 		public Money Subtract(Money r)       
		{ 
			return new Money(value - r.value); 
		}	
		
		/// <summary>
		/// Умножение - функциональная форма.	
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
 		public Money Multiply(double value)       
		{ 
			return new Money((long) Math.Round(this.value * value, 2)); 	
		}

		/// <summary>
		/// Деление - функциональная форма.	
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
 		public Money Divide(double value)       
		{ 
			return new Money((long) Math.Round(this.value / value, 2)); 
		}
	  
		/// <summary>
		/// Остаток от деления нацело - функциональная форма.
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
 		public long GetRemainder(uint n)       
		{ 
			return value % n; 
		}
	  
		/// <summary>
		/// Сравнение - функциональная форма.
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
 		public int CompareTo(Money r)     
		{
			if (value < r.value) 
				return -1;
			else if (value == r.value) 
				return 0;
			else 
				return 1;
		}
		  
		/// <summary>
		/// Деление на одинаковые части.
		///  Количество частей должно быть не меньше 2.
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
 		public Money[] Share(uint n) 
		{
			if (n < 2) 
				throw new ArgumentException();
			Money lowResult = new Money(value / n);
			Money highResult = 
				lowResult.value >= 0 ? new Money(lowResult.value + 1) : new Money(lowResult.value - 1);
			Money[] results = new Money[n];
			long remainder = Math.Abs(value % n);
			for (long i = 0; i < remainder; i++) 
				results[i] = highResult;
			for (long i = remainder; i < n; i++) 
				results[i] = lowResult;
			return results;
		}
	 		
		/// <summary>
		/// Деление пропорционально коэффициентам.
		/// Количество коэффициентов должно быть не меньше 2.
		/// </summary>
		/// <param name="ratios"></param>
		/// <returns></returns>
		public Money[] Allocate(params uint[] ratios) 
		{
			if (ratios.Length < 2) 
				throw new ArgumentException();
			long total = 0;
			for (int i = 0; i < ratios.Length; i++) 
				total += ratios[i];
			long remainder = value;
			Money[] results = new Money[ratios.Length];
			for (int i = 0; i < results.Length; i++) 
			{
				results[i] = new Money(value * ratios[i] / total);
				remainder -= results[i].value;
			}
			if (remainder > 0)      
			{
				for (int i = 0; i < remainder; i++) 
					results[i].value++;
			}
			else
			{
				for (int i = 0; i > remainder; i--) 
					results[i].value--;
			}
			return results;
		}			
		
		/// <summary>
		/// Перекрытые методы Object
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool Equals(object value) 
		{
			try 
			{
				return this == (Money) value;
			} 
			catch 
			{
				return false;
			}
		}
		
		/// <summary>
		/// GetHashCode
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()       
		{ 
			return value.GetHashCode(); 
		}
		
		/// <summary>
		/// ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString() 
		{
			return ((double) this).ToString();
		}
			
		/// <summary>
		/// Преобразования в строку аналогично double.
		/// </summary>
		/// <param name="provider"></param>
		/// <returns></returns>
		public string ToString(IFormatProvider provider)
		{
			if (provider is IMoneyToStringProvider)
				
			    //здесь - формирование числа прописью
				return ((IMoneyToStringProvider) provider).MoneyToString(this);
			else
				//а здесь - обычный double с учетом стандартного провайдера
				return ((double) this).ToString(provider);
		}	
		
		/// <summary>
		/// ToString
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public string ToString(string format)
		{
			return ((double) this).ToString(format);
		}	
		
		/// <summary>
		/// ToString
		/// </summary>
		/// <param name="format"></param>
		/// <param name="provider"></param>
		/// <returns></returns>
		public string ToString(string format, IFormatProvider provider)
		{
			return ((double) this).ToString(format, provider);
		}
	
		/// <summary>
		/// Унарные операторы.
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static Money operator+(Money r)       
		{ 
			return r; 
		}
		
		/// <summary>
		/// operator-
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static Money operator-(Money r)       
		{ 
			return new Money(-r.value); 
		}
		
		/// <summary>
		/// operator++
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static Money operator++(Money r)       
		{ 
			return new Money(r.value++); 
		}
		
		/// <summary>
		/// operator--
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static Money operator--(Money r)       
		{ 
			return new Money(r.value--); 
		}
				
		/// <summary>
		/// Бинарные операторы.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Money operator+(Money a, Money b)       
		{ 
			return new Money(a.value + b.value); 
		}
		
		/// <summary>
		/// operator-
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Money operator-(Money a, Money b)       
		{ 	
			return new Money(a.value - b.value); 
		}
		
		/// <summary>
		/// operator*
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Money operator*(double a, Money b)       
		{ 	
			return new Money((long) Math.Round(a * b.value, 2)); 
		}
		
		/// <summary>
		/// operator*
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Money operator*(Money a, double b)       
		{ 
			return new Money((long) Math.Round(a.value * b, 2)); 
		}
		
		/// <summary>
		///  operator/
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Money operator/(Money a, double b)       
		{ 
			return new Money((long) Math.Round(a.value / b, 2)); 
		}
		
		/// <summary>
		///  operator%
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Money operator%(Money a, uint b)       
		{ 
			return new Money((long) (a.value % b)); 
		}
		
		/// <summary>
		/// operator==
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool operator==(Money a, Money b)       
		{ 
			return a.value == b.value; 
		}
		
		/// <summary>
		/// operator!=
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool operator!=(Money a, Money b)       
		{ 
			return a.value != b.value; 
		}
		
		/// <summary>
		/// operator>
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool operator>(Money a, Money b)       
		{ 
			return a.value > b.value; 
		}
		
		/// <summary>
		/// operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool operator<(Money a, Money b)       
		{ 
			return a.value < b.value; 
		}
		
		/// <summary>
		/// operator>=
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool operator>=(Money a, Money b)       
		{ 
			return a.value >= b.value; 
		}
		
		/// <summary>
		/// operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool operator<=(Money a, Money b)       
		{ 
			return a.value <= b.value; 
		}
				
		/// <summary>
		/// Операторы преобразования.
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static implicit operator double(Money r)       
		{ 
			return (double) r.value / 100; 
		}
		
		/// <summary>
		/// explicit operator
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static explicit operator Money(double d)       
		{ 
			return new Money(d); 
		}
			 
	}       
	
	/// <summary>
	/// Интерфейс специализированного провайдера преобразования денег в строковое представление
	/// </summary>
 	public interface IMoneyToStringProvider: IFormatProvider 
	{
		/// <summary>
		/// MoneyToString
		/// </summary>
		/// <param name="m"></param>
		/// <returns></returns>
 		string MoneyToString(Money m);
	}
   	
	/// <summary>
	/// Преобразование числа в строку = число прописью
	/// </summary>
 	public static class NumberToRussianString 
	{			 	
		///Род единицы измерения.
 		public enum WordGender  
		{		   
			///мужской		  
			Masculine, 
	  
			///женский	 
			Feminine,
		   
			///средний		 
			Neuter
		};
	    
		///Варианты написания единицы измерения. 
 		public enum WordMode
		{	   
			///рубль	  
			Mode1,   
		  
			///рубля		 
			Mode2_4, 		 
			
			///рублей
			Mode0_5  
		};
		 
		#region Private Declarations Здесь можно поменять названия чисел
		
		///Строковые представления чисел.
		private const string number0 = "нуль";
		
		private static readonly string[,] number1_2 =
    	{
    	    { "один", "два" },
    	    { "одна", "дві" },
    	    { "однє", "два" }
    	};
		
		private static readonly string[] number3_9 = {"три", "чотири", "п'ять", "шість", "сімь", "вісімь", "дев'ять"};
		
		private static readonly string[] number10_19 =
	    {
			"десять", "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять",
		    "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять" };
		
		private static readonly string[] number20_90 =
	    {"двадцять", "тридцять", "сорок", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто" };
		
		private static readonly string[] number100_900 =
	    {"сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот" };
		
		private static readonly string[,] ternaries =
    	{
    	    {"тисяча", "тисячи", "тисяч"},
    	    {"мільон", "мільона", "мільонів"},
    	    {"мільярд", "мільярда", "мільярдів"},
    	    {"трилліон", "трилліонa", "трилліонів"},
    	    {"білліон", "білліона", "білліонів"}
    	};
		
		private static readonly WordGender[] TernaryGenders =
    	{
    		WordGender.Feminine,	// тысяча - женский
    		WordGender.Masculine, // миллион - мужской
    		WordGender.Masculine, // миллиард - мужской
    		WordGender.Masculine, // триллион - мужской
    		WordGender.Masculine  // биллион - мужской
    	};
		
		#endregion Private Declarations Здесь можно поменять названия чисел	
		 
		///Функция преобразования 3-значного числа, заданного в виде строки,
		///с учетом рода (мужской, женский или средний).
		///Род учитывается для корректного формирования концовки:
		///"один" (рубль) или "одна" (тысяча)		
 		private static string TernaryToString(long ternary, WordGender gender)
		{
			string s = "";
			
			//учитываются только последние 3 разряда, т.е. 0..999
			long t = ternary % 1000;
			int digit2 = (int) (t / 100);
			int digit1 = (int) ((t % 100) / 10);
			int digit0 = (int) (t % 10);
			
			//сотни
			if (digit2 > 0) 
				s = number100_900[digit2 - 1] + " ";
			if (digit1 > 1)
			{
				s += number20_90[digit1 - 2] + " ";
				if (digit0 >= 3) 
					s += number3_9[digit0 - 3] + " ";
				else if (digit0 > 0) 
					//s += number1_2[digit0 - 1, (int) gender] + " ";
					s += number1_2[(int) gender,digit0 - 1] + " ";
			}
			else if (digit1 == 1) 
				s += number10_19[digit0] + " ";
			else
			{
				if (digit0 >= 3) 
					s += number3_9[digit0 - 3] + " ";
				else if (digit0 > 0) 
					//s += number1_2[digit0 - 1, (int) gender] + " ";
					s += number1_2[(int) gender,digit0 - 1] + " ";
					//!!! Чтобы писАл "нуль" раскоментировать следующие 2 строки :
				/*else 
					s += number0 + " ";*/
			}
			return s.TrimEnd();
		}
		 		
		private static string TernaryToString(long value, byte ternaryIndex)
		{
			long ternary = value;
			for (byte i = 0; i < ternaryIndex; i++) 
				ternary /= 1000;
			if (ternary == 0) 
				return "";
			else 
			{
				ternaryIndex--;
				return TernaryToString(ternary, TernaryGenders[ternaryIndex]) + " " +
					ternaries[ternaryIndex, (int) GetWordMode(ternary)] + " ";
			}
		}
		 
		///Функция возвращает число прописью с учетом рода единицы измерения 		
		public static string NumberToString(long value, WordGender gender)
		{
			if (value <= 0) 
				return "";
			else 
				return TernaryToString(value, 5) +
					TernaryToString(value, 4) +
					TernaryToString(value, 3) +
					TernaryToString(value, 2) +
					TernaryToString(value, 1) +
					TernaryToString(value, gender);
		}
		 
		///Определение варианта написания единицы измерения по 3-х значному числу 		 
		public static WordMode GetWordMode(long number)
		{
			//достаточно проверять только последние 2 цифры,
			//т.к. разные падежи единицы измерения раскладываются
			//0 рублей, 1 рубль, 2-4 рубля, 5-20 рублей, 
			//дальше - аналогично первому десятку		
			int digit1 = (int) (number % 100) / 10;
			int digit0 = (int) (number % 10);
			if (digit1 == 1) 
				return WordMode.Mode0_5;
			else if (digit0 == 1) 
				return WordMode.Mode1;
			else if (2 <= digit0 && digit0 <= 4) 
				return WordMode.Mode2_4;
			else 
				return WordMode.Mode0_5;
		}			
	}
 
	/// <summary>
	/// Преобразование денег в сумму прописью.
	/// </summary>
 	public abstract class MoneyToStringProviderBase
	{
 		
 		/// <summary>
 		/// GetGender
 		/// </summary>
 		/// <param name="high"></param>
 		/// <returns></returns>
		protected abstract NumberToRussianString.WordGender GetGender(bool high);
		
		/// <summary>
		/// Функция возвращает наименование денежной единицы в соответствующей форме
		/// (1) рубль / (2) рубля / (5) рублей
		/// </summary>
		/// <param name="wordMode"></param>
		/// <param name="high"></param>
		/// <returns></returns>
		protected abstract string GetName(NumberToRussianString.WordMode wordMode, bool high);
			
		/// <summary>
		/// Функция возвращает сокращенное наименование денежной единицы
		/// </summary>
		/// <param name="high"></param>
		/// <returns></returns>
		protected abstract string GetShortName(bool high);
		
		//сокращенное написание рублей ? - рублей/руб.
		bool shortHigh = false;
		
		//сокращенное написание копеек ? - копеек/коп.
		bool shortLow = false;
		
		//отображение копеек в виде цифр ? - 00
		bool digitLow = true;
			
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="shortHigh"></param>
		/// <param name="shortLow"></param>
		/// <param name="digitLow"></param>
		public MoneyToStringProviderBase(bool shortHigh, bool shortLow, bool digitLow)
		{
			this.shortHigh = shortHigh;
			this.shortLow = shortLow;
			this.digitLow = digitLow;
		}
		
		/// <summary>
		/// Реализация интерфейса IMoneyToStringProvider
		/// Метод родительского интерфейса IFormatProvider
		/// </summary>
		/// <param name="formatType"></param>
		/// <returns></returns>
		public object GetFormat(Type formatType)
		{
			if (formatType != typeof(RoubleToStringProvider)) 
				return null;
			else
				return this;
		}
		
		/// <summary>
		/// Функция возвращает число рублей и копеек прописью
		/// </summary>
		/// <param name="m"></param>
		/// <returns></returns>
		public string MoneyToString(Money m)
		{
			long r = m.High;
			long c = m.Low;
			return string.Format("{0} {1} {2} {3}",
				NumberToRussianString.NumberToString(r, GetGender(true)),
				shortHigh ? 
				GetShortName(true) : 
				GetName(NumberToRussianString.GetWordMode(r), true),
				digitLow ? 
				string.Format("{0:d2}", c) : 
				NumberToRussianString.NumberToString(c, GetGender(false)),
				shortLow ? 
				GetShortName(false) : 
				GetName(NumberToRussianString.GetWordMode(c), false));
		}
	}
 
 	/// <summary>
 	/// Преобразование европейских денег (евро + центы) в сумму прописью.
 	/// </summary>
	public class EuroToStringProvider: MoneyToStringProviderBase
	{
		
		/// <summary>
		/// EUROToStringProvider
		/// </summary>
		/// <param name="shortEURO"></param>
		/// <param name="shortCent"></param>
		/// <param name="digitCent"></param>
		public EuroToStringProvider(bool shortEURO, bool shortCent, bool digitCent) :
			base(shortEURO, shortCent, digitCent) {}
		
	    //Варианты написания долларов.
		private static readonly string[] dollars = {"євро", "євро", "євро" };
		
		//Варианты написания центов.
		private static readonly string[] cents = {"євро цент", "євро цента", "євро центів"};
		
		/// <summary>
		/// GetGender
		/// </summary>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override NumberToRussianString.WordGender GetGender(bool high)
		{ 
			return NumberToRussianString.WordGender.Neuter; 
		}
		
		
		/// <summary>
		/// GetName
		/// </summary>
		/// <param name="wordMode"></param>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override string GetName(NumberToRussianString.WordMode wordMode, bool high)
		{ 
			return high ? dollars[(int) wordMode] : cents[(int) wordMode]; 
		}
		
		/// <summary>
		/// GetShortName
		/// </summary>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override string GetShortName(bool high)
		{ 
			return high ? "євро." : "євро ц."; 
		}
	}
	
	/// <summary>
	/// Преобразование украинских денег (грн + копейки) в сумму прописью
	/// </summary>
	public class HryvnaToStringProvider: MoneyToStringProviderBase
	{
		/// <summary>
		/// HryvnaToStringProvider
		/// </summary>
		/// <param name="shortHrn"></param>
		/// <param name="shortCopecks"></param>
		/// <param name="digitCopecks"></param>
		public HryvnaToStringProvider(bool shortHrn, bool shortCopecks, bool digitCopecks) :
			base(shortHrn, shortCopecks, digitCopecks) {}
		
	    //Варианты написания рублей.
		private static readonly string[] roubles = {"гривня", "гривні", "гривень"};
		
		//Варианты написания копеек.
		private static readonly string[] copecks = {"копійка", "копійки", "копійок"};
		
		/// <summary>
		/// GetGender
		/// </summary>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override NumberToRussianString.WordGender GetGender(bool high)
		{ 
			return high ? NumberToRussianString.WordGender.Feminine : NumberToRussianString.WordGender.Feminine;
		}
		
		/// <summary>
		/// GetName
		/// </summary>
		/// <param name="wordMode"></param>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override string GetName(NumberToRussianString.WordMode wordMode, bool high)      
		{ 
			return high ? roubles[(int) wordMode] : copecks[(int) wordMode]; 
		}
		
		/// <summary>
		/// GetShortName
		/// </summary>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override string GetShortName(bool high)      
		{ 
			return high ? "грн." : "коп."; 
		}
	}
  
	/// <summary>
	/// Преобразование русских денег (рубли + копейки) в сумму прописью. 
	/// </summary>
 	public class RoubleToStringProvider: MoneyToStringProviderBase
	{
		/// <summary>
		/// RoubleToStringProvider
		/// </summary>
		/// <param name="shortRoubles"></param>
		/// <param name="shortCopecks"></param>
		/// <param name="digitCopecks"></param>
 		public RoubleToStringProvider(bool shortRoubles, bool shortCopecks, bool digitCopecks) :
			base(shortRoubles, shortCopecks, digitCopecks) {}
		
 	    //варианты написания рублей
		private static readonly string[] roubles = {"рубль", "рубля", "рублів"};
		
		//Варианты написания копеек.
		private static readonly string[] copecks = {"копійка", "копійки", "копійок"};
		
		/// <summary>
		/// GetGender
		/// </summary>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override NumberToRussianString.WordGender GetGender(bool high)
		{ 
			return high ? NumberToRussianString.WordGender.Masculine : NumberToRussianString.WordGender.Feminine;
		}
		
		/// <summary>
		/// GetName
		/// </summary>
		/// <param name="wordMode"></param>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override string GetName(NumberToRussianString.WordMode wordMode, bool high)
		{ 
			return high ? roubles[(int) wordMode] : copecks[(int) wordMode]; 
		}
		
		/// <summary>
		/// GetShortName
		/// </summary>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override string GetShortName(bool high)
		{ 
			return high ? "руб." : "коп."; 
		}
	}
   
	/// <summary>
	/// Преобразование американских денег (доллары + центы) в сумму прописью.
	/// </summary>
 	public class DollarToStringProvider: MoneyToStringProviderBase
	{
		/// <summary>
		/// DollarToStringProvider
		/// </summary>
		/// <param name="shortDollar"></param>
		/// <param name="shortCent"></param>
		/// <param name="digitCent"></param>
 		public DollarToStringProvider(bool shortDollar, bool shortCent, bool digitCent) :
			base(shortDollar, shortCent, digitCent) {}
		
 	    ///варианты написания долларов
		private static readonly string[] dollars = {"долар", "долара", "доларів"};
		
	    ///варианты написания центов	
	    private static readonly string[] cents = {"цент", "цента", "центів"};
		
	    
	    /// <summary>
	    /// GetGender
	    /// </summary>
	    /// <param name="high"></param>
	    /// <returns></returns>
	    protected override NumberToRussianString.WordGender GetGender(bool high)
		{ 
			return NumberToRussianString.WordGender.Masculine; 
		}
	    
	    /// <summary>
	    /// GetName
	    /// </summary>
	    /// <param name="wordMode"></param>
	    /// <param name="high"></param>
	    /// <returns></returns>
		protected override string GetName(NumberToRussianString.WordMode wordMode, bool high)      
		{ 
			return high ? dollars[(int) wordMode] : cents[(int) wordMode]; 
		}
		
		/// <summary>
		/// GetShortName
		/// </summary>
		/// <param name="high"></param>
		/// <returns></returns>
		protected override string GetShortName(bool high)      
		{ 
			return high ? "дол." : "ц."; 
		}
	}
	
    
	
	
/*	========================================================================
//=============================================================
// Сумма прописью (по русски, предел 2,14 миллиардов)
// В.Устинов, 21.06.2002
// параметры:
//    1. Value  (real)    - сумма
//    2. FundID (integer) - ИД валюты. Может быть 0 - тогда будет просто число и тогда можно только целое
//=============================================================
function ValueSpelled(Value:real; FundID:integer):string;
var
  PartNum, TruncNum, NumTMP, D: real;
  NumStr, s, int1,int2,int5,flo1,flo2,flo5 : string;
  i, R   : byte;
  Flag11 : boolean;
  Fund : TenObject;
label lbPartNum;
begin
  Result := '';
  if not (Value<2147483648.0) then begin
    //MMessageDlg('[Сумма прописью] сумма должна быть в пределах 2147483648', mmtError, mmbOk, 0);
    Result := 'рублей';
    exit;
  end;
  if Value < 0.0 then begin
    MMessageDlg('[Сумма прописью] сумма должна быть положительной', mmtError, mmbOk, 0);
    exit;
  end;
  if FundID <> 0 then
  begin
    Fund := enManager.OByB['Валюта',FundID];
    if Fund = NULL then  begin
      MMessageDlg('[Сумма прописью] валюта #'+IntToStr(FundID)+' не найдена', mmtError, mmbOk, 0);
      exit;
    end;
    s := Fund.AByB['Написание'].AsString;
    //разбор вариантов написания валюты
    i := pos(';', s);
    if i>0 then begin int1 := copy(s, 1, i - 1); s := copy(s, i + 1, Length(s) - i); end
           else int1 := s;
    i := pos(';', s);
    if i>0 then begin int2 := copy(s, 1, i - 1); s := copy(s, i + 1, Length(s) - i); end
           else int2 := s;
    i := pos(';', s);
    if i>0 then begin int5 := copy(s, 1, i - 1); s := copy(s, i + 1, Length(s) - i); end
           else int5 := s;
    i := pos(';', s);
    if i>0 then begin flo1 := copy(s, 1, i - 1); s := copy(s, i + 1, Length(s) - i); end
           else flo1 := s;
    i := pos(';', s);
    if i>0 then begin flo2 := copy(s, 1, i - 1); s := copy(s, i + 1, Length(s) - i); end
           else flo2 := s;
    i := pos(';', s);
    if i>0 then begin flo5 := copy(s, 1, i - 1); s := copy(s, i + 1, Length(s) - i); end
           else flo5 := s;
  end
  else
  begin
    int1 := '';
    int2 := '';
    int5 := '';
  end;
  PartNum:=Round(Frac(Value)*100);
  if PartNum=100 then
    Value := Int(Value)+1;
  NumStr:='';
  D := 1000000000;
  R := 5;
  TruncNum:=Int(Value); //выделяем рубли
  if TruncNum<>0
    then
      repeat
        PartNum:=TruncNum div D;
        Dec(R);
        D:=D div 1000;
      until PartNum<>0
    else
      R:=0;
  if R = 0 then begin
    NumStr:='ноль '+int5+' ';
    goto lbPartNum;
  end;
  // перевод рублей
  FOR i:=R DOWNTO 1 DO
  BEGIN
    Flag11:=False;
    NumTMP:=PartNum div 100; //выделение цифры сотен
    case NumTMP of
      1: NumStr:=NumStr+'сто ';
      2: NumStr:=NumStr+'двести ';
      3: NumStr:=NumStr+'триста ';
      4: NumStr:=NumStr+'четыреста ';
      5: NumStr:=NumStr+'пятьсот ';
      6: NumStr:=NumStr+'шестьсот ';
      7: NumStr:=NumStr+'семьсот ';
      8: NumStr:=NumStr+'восемьсот ';
      9: NumStr:=NumStr+'девятьсот ';
    end;
    NumTMP:=(PartNum mod 100) div 10; //выделение цифры десятков
    case NumTMP of
      1: begin
           NumTMP:=PartNum mod 100;
           case NumTMP of
            10: NumStr:=NumStr+'десять ';
            11: NumStr:=NumStr+'одиннадцать ';
            12: NumStr:=NumStr+'двенадцать ';
            13: NumStr:=NumStr+'тринадцать ';
            14: NumStr:=NumStr+'четырнадцать ';
            15: NumStr:=NumStr+'пятнадцать ';
            16: NumStr:=NumStr+'шестнадцать ';
            17: NumStr:=NumStr+'семнадцать ';
            18: NumStr:=NumStr+'восемнадцать ';
            19: NumStr:=NumStr+'девятнадцать ';
           end;
           case i of
             4: NumStr:=NumStr+'миллиардов ';
             3: NumStr:=NumStr+'миллионов ';
             2: NumStr:=NumStr+'тысяч ';
             1: NumStr:=NumStr+int5+' ';
           end;
           Flag11:=True;
         end;
      2: NumStr:=NumStr+'двадцать ';
      3: NumStr:=NumStr+'тридцать ';
      4: NumStr:=NumStr+'сорок ';
      5: NumStr:=NumStr+'пятьдесят ';
      6: NumStr:=NumStr+'шестьдесят ';
      7: NumStr:=NumStr+'семьдесят ';
      8: NumStr:=NumStr+'восемьдесят ';
      9: NumStr:=NumStr+'девяносто ';
    end;
    NumTMP:=PartNum mod 10; //выделение цифры единиц
    if not Flag11 then
      begin
        case NumTMP of
          1: if i=2 then NumStr:=NumStr+'одна ' else NumStr:=NumStr+'один ';
          2: if i=2 then NumStr:=NumStr+'две ' else NumStr:=NumStr+'два ';
          3: NumStr:=NumStr+'три ';
          4: NumStr:=NumStr+'четыре ';
          5: NumStr:=NumStr+'пять ';
          6: NumStr:=NumStr+'шесть ';
          7: NumStr:=NumStr+'семь ';
          8: NumStr:=NumStr+'восемь ';
          9: NumStr:=NumStr+'девять ';
        end;
        case i of
          4: case NumTMP of
               1    : NumStr:=NumStr+'миллиард ';
               2,3,4: NumStr:=NumStr+'миллиарда ';
               else NumStr:=NumStr+'миллиардов ';
             end;
          3: case NumTMP of
               1    : NumStr:=NumStr+'миллион ';
               2,3,4: NumStr:=NumStr+'миллиона ';
               else if PartNum<>0 then NumStr:=NumStr+'миллионов ';
             end;
          2: case NumTMP of
               1    : NumStr:=NumStr+'тысяча ';
               2,3,4: NumStr:=NumStr+'тысячи ';
               else if PartNum<>0 then NumStr:=NumStr+'тысяч ';
             end;
          1: case NumTMP of
               1    : NumStr:=NumStr+int1+' ';
               2,3,4: NumStr:=NumStr+int2+' ';
               else NumStr:=NumStr+int5+' ';
             end;
        end;
      end;
    if i>1 then begin
                 PartNum:=(TruncNum mod (D*1000)) div D;
                 D:=D div 1000;
                end;
  END;
lbPartNum: //перевод копеек
  if FundID <> 0 then
  begin
    PartNum:=Round(Frac(Value)*100);
    if PartNum=0 then
      begin
        Result := NumStr+'00 '+flo5;
        Result[1] := AnsiUpperCase(Result[1]);
        Exit;
      end;
    NumTMP:=PartNum div 10; //выделение цифры десятков
    if NumTMP=0 then NumStr:=NumStr+'0'+IntToStr(PartNum)+' '
                else NumStr:=NumStr+IntToStr(PartNum)+' ';
    NumTMP:=PartNum mod 10; //выделение цифры единиц
    case NumTMP of
      1: if PartNum<>11 then NumStr:=NumStr+flo1
                        else NumStr:=NumStr+flo5;
      2,3,4: if (PartNum<5) or (PartNum>14)
                then NumStr:=NumStr+flo2
                else NumStr:=NumStr+flo5;
      else NumStr:=NumStr+flo5;
    end;
  end;
  NumStr[1] := AnsiUpperCase(NumStr[1]);
  Result:=NumStr;
end;
//=============================================================
// Сумма вида "ххх-хх"
// С. Кривцов, 30.09.2002
// параметры:
//    1. Value  (real)    - сумма
//    2. Delimiter        - разделитель
//    3. FundID (integer) - ИД валюты
//=============================================================
function ValueDelimited(Value:real; Delimiter: string; FundID:integer):string;
var
  PartNum, TruncNum: integer;
  PartStr: string;
  Fund : TenObject;
  Precision, PrecisionFactor: integer;
  i: integer;
begin
  Result:='';
  Fund := enManager.OByB['Валюта',FundID];
  if Fund = NULL then  begin
    MMessageDlg('Валюта #'+IntToStr(FundID)+' не найдена', mmtError, mmbOk, 0);
    exit;
  end;
  try
    TruncNum := Int(Value);
    Precision := Fund.AByB['Точность'].AsInteger;
    PrecisionFactor := Power(10, Precision);
    PartNum:=Round(Frac(Value)* PrecisionFactor);
    if PartNum = PrecisionFactor then TruncNum := TruncNum + 1;
    PartStr := IntToStr(PartNum);
    if Length(PartStr) < Precision then
      for i := 1 to Precision - Length(PartStr) do PartStr := '0' + PartStr;
    Result := IntToStr(TruncNum) + Delimiter + PartStr;
  finally
    Fund.Free;
  end;
end;
//=============================================================
// Сумма цифрами и прописью вида: "202 (двести два) руб. 35 коп."
// Кувайский Д., 1.06.2010
// параметры:
//    1. Value  (real)    - сумма
//=============================================================
function ValueNumbersAndSpelledRUR(Value : Real) : String;
var
  TruncStr, PartStr : String;
  TruncNum, PartNum : Integer;
  i : Integer;
  srub: string;
begin
  TruncNum := Int(Value);
  PartNum  := Round(Frac(Value)* 100);
  if PartNum = 100 then
  begin
    TruncNum := TruncNum + 1;
    PartNum  := 0;
  end;
  TruncStr := FormatFloat('### ### ### ### ##0', TruncNum);
  PartStr  := IntToStr(PartNum);
  if Length(PartStr) < 2 then
    for i := 1 to 2 - Length(PartStr) do
      PartStr := '0' + PartStr;
  UseUnit('StrUtilsSU');
  srub := ValueSpelled(Value, 0);
  Result := '';
  if srub <> 'рублей' then
    Result := TruncStr + ' (' + AnsiUpperCaseFirst(Trim(srub)) + ') ' + RublesCorrectEnding(TruncNum) + ' '
                       + PartStr + ' ' + CopeeksCorrectEnding(PartNum)
    else Result := TruncStr + ' рублей';
  Result := Trim(Result);
end;
{  Колесниченко И.В.    02.02.2012}
function ValueNumbersAndSpelledRURGenitiv(Value : Real) : String;
var
  TruncStr, PartStr : String;
  TruncNum, PartNum : Integer;
  i : Integer;
begin
  TruncNum := Int(Value);
  PartNum  := Round(Frac(Value)* 100);
  if PartNum = 100 then
  begin
    TruncNum := TruncNum + 1;
    PartNum  := 0;
  end;
  TruncStr := FormatFloat('### ### ### ##0', TruncNum);
  PartStr  := IntToStr(PartNum);
  if Length(PartStr) < 2 then
    for i := 1 to 2 - Length(PartStr) do
      PartStr := '0' + PartStr;
  UseUnit('StrUtilsSU');
  Result := TruncStr + ' (' + AnsiUpperCaseFirst(Trim(ValueSpelled(Value, 0))) + ') ' + RublesCorrectEndingGenitiv(TruncNum) + ' '
                     + PartStr + ' ' + CopeeksCorrectEndingGenitiv(PartNum);
  Result := Trim(Result);
end;
//Преобразование числа к виду с разрядами 123456789,99 > 123 456 789,99
function ValueNumbers(Value : Real) : String;
var
  TruncStr, PartStr : String;
  TruncNum, PartNum : Integer;
  i : Integer;
begin
  TruncNum := Int(Value);
  PartNum  := Round(Frac(Value)* 100);
  if PartNum = 100 then
  begin
    TruncNum := TruncNum + 1;
    PartNum  := 2;
  end;
  TruncStr := FormatFloat('### ### ### ##0', TruncNum);
  PartStr  := IntToStr(PartNum);
  PartStr:=StringReplace(PartStr,'-','',(rfReplaceAll));
  if Length(PartStr) < 2 then
    for i := 1 to 2 - Length(PartStr) do
      PartStr := '0' + PartStr;
  PartStr := ',' + PartStr;
  Result := TruncStr+PartStr;
end;
//=============================================================
// На сервере есть функции dbo.NumPhrase, dbo.RubPhrase, dbo.UsdPhrase
// Которые возвращают сумму прописью. Здесь на клиенте проблема с большими числами.
// Например команды mod, div не работают, также нельзя задать переменной занчение 10 миллиардов.
// Поэтому получение суммы пропитсью сделано через сервер.
//=============================================================
function GetRub(N: Float): string;
var
  m: TmccMemTable;
  s: string;
  N2: integer;
  Sep: string;
begin
  UseUnit('MemTableUtilSU');
  sep := DecimalSeparator;
  DecimalSeparator := '.';
  s := FloatToStr(N);
  DecimalSeparator := sep;
  m := TmccMemTable.Create(nil);
  MemTableUtilSU.SelectSQL('select dbo.RubPhrase(' + s + ') as RubStr', m);
  N2 := Int(N);
  Result := FormatFloat('### ### ### ##0', N2) + ' ' + m.FieldByName('RubStr').AsString;
end;
//***********************************************************************
*/
	
}
