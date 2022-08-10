using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    static class BitString
    {
        public static string XOR(string str1, string str2)
        {
            string result = ""; // Строка для формирования результата сложения по модулю два

            for (int i = 0; i < str1.Length; i++)
                if (str1[i] == str2[i])
                    result += "0"; // Если символы на одной позиции в двух строках совпадают => результат их сложения по модулю два = 0
                else
                    result += "1"; // Результат сложения по модулю два = 1

            return result;
        } // Выполняем XOR для битовых строк

        public static int ConvertToInteger(string str1)
        {
            int result = Convert.ToInt32(str1, 2); // Преобразуем битовую строку в int32, если это возможно
            return result;
        } // Преобразование строки бит в int
    }
}
