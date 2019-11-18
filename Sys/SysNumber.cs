
﻿/*
 * Создано в SharpDevelop.
 * Пользователь: Travin
 * Дата: 02.12.2017
 * Время: 18:43
 */
 
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace FBA
{  
    public static partial class sys
    {
     
        #region Region. Битовая маска.
        
        ///<summary>
        /// Возвращает бит в num байте val
        ///</summary>
        ///<param name="val">Входнойбайт</param>
        ///<param name="num">Номербита, начинаяс 0</param>
        ///<returns>true-битравен 1, false- битравен 0</returns>
        public static bool GetBit(int val, int num)
        {                 
             return ((val >> num) & 1) > 0;//собственно все вычисления
        }
        
        ///<summary>
        /// Устанавливает значение определенного бита в числе INT.
        ///</summary>
        ///<param name="val">Входное значение</param>
        ///<param name="num">Номер бита</param>
        ///<param name="bit">Значение бита: true-битравен 1, false-битравен 0 </param>
        ///<returns>INT с измененным значением бита</returns>
        public static int SetBit(int val, int num, bool bit)
        {          
            int tmpval = 1;
            tmpval = (int)(tmpval << num); //устанавливаем нужный бит в единицу
            val = (int)(val & (~tmpval)); //сбрасываем в 0 нужный бит       
            if (bit) //если бит требуется установить в 1
            {
               val = (int)(val | (tmpval));//то устанавливаем нужный бит в 1
            }
            return val;
        } 
        
        //HasFlag
        
        ///Конвертация в двоичную систему и вывод в виде строки.
        public static string IntConvertTo2(int N) 
        {
            return Convert.ToString(N, 2);
        }
        
        ///Конвертация в десятичную систему из двоичной.
        public static Int64 IntConvertFrom2(string TwoStr)
        {
            TwoStr = TwoStr.Trim();// + " ";
            return Convert.ToInt64(TwoStr, 2);
        }
                             
        #endregion Region. Битовая маска.   
        
        ///Проверка, что строка является числом INT.
        public static bool IsInteger(string NumberStr, out int NumberInt)
        {           
            //1. Способ:
            //if (!int.TryParse(NumberStr, out NumberInt)) return false; //Работает.
            
            //2. Способ:
            char symb;
            NumberInt = 0;
            bool DigitCheck = true;
            for (int i = 0; i < NumberStr.Length; i++)
            {
                symb = NumberStr[i];
                if (('0' > symb) || ('9' < symb)) DigitCheck = false;           
            }
            if (DigitCheck) NumberInt = NumberStr.ToInt();
            return DigitCheck;            
        }

        ///Проверка, что строка является числом c дробной частью.
        public static bool IsFloat(string NumberStr)
        {
            //1. Способ:
            //ValidationExpression = "^\d+$" — делает проверку на числовые значения
            //return System.Text.RegularExpressions.Regex.IsMatch(text, "[^0-9.-]+"); //"[0-9]*" Работает.
            //if (!int.TryParse(NumberStr, out NumberInt)) return false; //Работает.
            
            //2. Способ:
            char symb;
            bool DigitCheck = true;
            for (int i = 0; i < NumberStr.Length; i++)
            {
                symb = NumberStr[i];
                if ((('0' > symb) || ('9' < symb)) && (symb != '.')) DigitCheck = false;
            }
            return DigitCheck;                
        }

        ///Округление в большую сторону
        public static decimal RoundUp(this decimal Number, int Digits)
        {
            //Console.WriteLine(RoundUp(14.7848M, 2));    // 14.79
            //Console.WriteLine(RoundUp(14.78424M, 3));   // 14.785
            //Console.WriteLine(RoundUp(14.12M, 1));      // 14.2
            var factor = Convert.ToDecimal(Math.Pow(10, Digits));
            return Math.Ceiling(Number * factor) / factor;
        }

        ///Проверка на чётность числа.
        public static bool IsEven(this int Number)
        {
            return (Number & 1) == 0;
        }
    }
}
