using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DES
{
    static class KeyWorker
    {
        private static string initializationKey = ""; // Ключ инициальзации (первичный ключ) - 56 бит (7 байт или 7 символов ASCII)
        private static string startKey = ""; // Стартовый ключ для получения раундовых - 64 бит (дополнили битами коррекции + сделали перестановку)
        private static string currentKey = ""; // Текущее состояние ключа шифрования (текущий вид ключа для формирования раундового)
        private const string c0 = "57|49|41|33|25|17|9|1|58|50|42|34|26|18|10|2|59|51|43|35|27|19|11|3|60|52|44|36"; // Начальная перестановка бит ключа (часть 1)
        private const string d0 = "63|55|47|39|31|23|15|7|62|54|46|38|30|22|14|6|61|53|45|37|29|21|13|5|28|20|12|4"; // Начальная перестановка бит ключа (часть 2)
        private const string numberOfShifts = "1|1|2|2|2|2|2|2|1|2|2|2|2|2|2|1"; // Число сдвигов для каждого раунда
        private const string bitsNumbersForRoundKey = "14|17|11|24|1|5|3|28|15|6|21|10|23|19|12|4|26|8|16|7|27|20|13|2|41|52|31|37|47|55|30|40|51|45|33|48|44|49|39|56|34|53|46|42|50|36|29|32"; // Биты, которые включаются в раундовый ключ


        public static void GenerateKey()
        {
            byte[] bytes = new byte[7]; // Массив для хранения байтов
            var numbers = RandomNumberGenerator.GetNumbersForKey(7, 128); // Получаем набор случайных чисел

            for (int i = 0; i < numbers.Count; i++)
                bytes[i] = (byte)numbers[i]; // Конвертируем каждый int в byte
            numbers.Clear(); // Очищаем список

            foreach (byte b in bytes)
                initializationKey += Convert.ToString(b, 2).PadLeft(8, '0'); // Получаем ключ инициалзации (первичный)

            for (int i = 0; i < 8; i++)
            {
                int count = 0;
                string buf = initializationKey.Substring(i * 7, 7);

                foreach (char bit in buf)
                    if (bit == '1')
                        count++;

                if (count % 2 == 0)
                    startKey += buf + "1"; // Дополняем битом коррекции "1"
                else
                    startKey += buf + "0"; // Дополняем битом коррекции "0"
            } // Получаем начальный ключ (добавляем проверочные биты к каждой последовательности по 7 бит, чтобы число единиц в каждом байте было нечетным)

            SetupKey(); // Выполняем начальную перестановку бит ключа
        } // Генерируем ключ для шифрования

        public static (bool, string) GenerateKey(byte[] key)
        {
            bool check = false; // Переменная для фиксирования результата генерации ключа
            string message = null; // Строка, содержащая комментарий для пользователя

            if (key.Length == 7)
            {
                check = true;
                message = "Ключ прошел проверку и был установлен!";

                foreach (byte b in key)
                    initializationKey += Convert.ToString(b, 2).PadLeft(8, '0'); // Получаем ключ инициализации (первичный)

                for (int i = 0; i < 8; i++)
                {
                    int count = 0;
                    string buf = initializationKey.Substring(i * 7, 7);

                    foreach (char bit in buf)
                        if (bit == '1')
                            count++;

                    if (count % 2 == 0)
                        startKey += buf + "1"; // Дополняем битом коррекции "1"
                    else
                        startKey += buf + "0"; // Дополняем битом коррекции "0"
                } // Получаем начальный ключ (добавляем проверочные биты к каждой последовательности по 7 бит, чтобы число единиц в каждом байте было нечетным)

                SetupKey(); // Выполняем начальную перестановку бит ключа
            } // Длина ключа = 7 байт => если получили от пользователя больше 7 байт, то ключ не подходит
            else
                message = "Ключ не прошел проверку! Убедитесь, что выбранный ключ содержит только 7 символов в кодировке ASCII и повторите попытку!";

            return (check, message);
        } // Устанавливаем ключ на основании пользовательского ввода (7 символов ASCII)

        private static void SetupKey()
        {
            int count = 0;

            char[] bits = startKey.ToCharArray(); // Конвертируем строку бит в массив char'ов, чтобы работать с каждым символом (0 или 1) отдельно

            string[] steps = c0.Split('|');
            foreach (string step in steps)
            {

                if ((count + 1) % 8 == 0)
                {
                    count++;
                    bits[count] = startKey[int.Parse(step) - 1];
                }
                else
                {
                    bits[count] = startKey[int.Parse(step) - 1];
                }

                count++;
            } // Выполняем начальную перестановку бит ключа (часть #1 - c0). ЗАМЕЧАНИЕ: игнорируем проверочные биты!!!

            steps = d0.Split('|');
            foreach (string step in steps)
            {

                if ((count + 1) % 8 == 0)
                {
                    count++;
                    bits[count] = startKey[int.Parse(step) - 1];
                }
                else
                {
                    bits[count] = startKey[int.Parse(step) - 1];
                }

                count++;
            } // Выполняем начальную перестановку бит ключа (часть #2 - d0). ЗАМЕЧАНИЕ: игнорируем проверочные биты!!!

            currentKey = new string(bits);
        } // Выполняем перестановки c0 и d0 для стартового ключа (выполняем подготовку ключа к использованию)

        public static byte[] GetInitializationKey()
        {
            byte[] key = new byte[7]; // Создаем ключ длинной 7 байт
            for (int i = 0; i < 7; i++)
            {
                string buf = initializationKey.Substring(i * 8, 8);
                key[i] = Convert.ToByte(buf, 2);
            } // Переводим ключ из битовой строки в массив байтов
            return key;
        } // Метод возвращает стартовый ключ (самый первый ключ на 56 бит = 7 символов ASCII)

        public static void DeleteKeys()
        {
            initializationKey = "";
            startKey = "";
            currentKey = "";
        } // Удаляем ключи

        public static string KeyForNextRound(int currentRound)
        {
            char[] outputKey = new char[48];
            int count = 0;

            string[] bitsNumbers = bitsNumbersForRoundKey.Split('|');
            string[] shifts = numberOfShifts.Split('|');
            string firstHalf = currentKey.Substring(0, currentKey.Length / 2);
            string secondHalf = currentKey.Substring(currentKey.Length / 2, currentKey.Length / 2);

            for (int i = 0; i < int.Parse(shifts[currentRound]); i++)
            {
                firstHalf = firstHalf.Substring(1, currentKey.Length / 2 - 1) + firstHalf[0];
                secondHalf = secondHalf.Substring(1, currentKey.Length / 2 - 1) + secondHalf[0];
            } // Выполняем циклические сдвиги блоков ключа

            currentKey = firstHalf + secondHalf; // Собираем ключ после сдвигов левой и правой половин

            foreach (string bit in bitsNumbers)
            {
                outputKey[count] = currentKey[int.Parse(bit) - 1];
                count++;
            } // Формируем ключ для раунда шифрования

            if (currentRound == shifts.Length - 1)
                SetupKey(); // После окончания 16-го раунда сбрасываем ключ в стартовое положение

            return (new string(outputKey)); // Возвращаем полученный ключ
        } // Рассчитываем ключ для следующего раунда

        public static string KeyForPrevRound(int currentRound)
        {
            char[] outputKey = new char[48];
            int count = 0;

            string[] bitsNumbers = bitsNumbersForRoundKey.Split('|');
            string[] shifts = numberOfShifts.Split('|');
            string firstHalf = currentKey.Substring(0, currentKey.Length / 2);
            string secondHalf = currentKey.Substring(currentKey.Length / 2, currentKey.Length / 2);

            if (currentRound != shifts.Length - 1)
            {
                for (int i = 0; i < int.Parse(shifts[currentRound + 1]); i++)
                {
                    firstHalf = firstHalf[firstHalf.Length - 1] + firstHalf.Substring(0, currentKey.Length / 2 - 1);
                    secondHalf = secondHalf[secondHalf.Length - 1] + secondHalf.Substring(0, currentKey.Length / 2 - 1);
                } // Выполняем циклические сдвиги блоков ключа
            }
            else
            {
                int summuryShift = 0;
                foreach (string shift in shifts)
                    summuryShift += int.Parse(shift); // Считаем общее количество сдвигов, выполняемых до 16 раунда включительно

                for (int i = 0; i < currentKey.Length / 2 - summuryShift; i++)
                {
                    firstHalf = firstHalf[firstHalf.Length - 1] + firstHalf.Substring(0, currentKey.Length / 2 - 1);
                    secondHalf = secondHalf[secondHalf.Length - 1] + secondHalf.Substring(0, currentKey.Length / 2 - 1);
                } // Выполняем циклические сдвиги блоков ключа
            }

            currentKey = firstHalf + secondHalf; // Собираем ключ после сдвигов левой и правой половин

            foreach (string bit in bitsNumbers)
            {
                outputKey[count] = currentKey[int.Parse(bit) - 1];
                count++;
            } // Формируем ключ для раунда шифрования

            if (currentRound == 0)
                SetupKey(); // После применения k1 ключ спбрасывается в начальное положение

            return (new string(outputKey)); // Возвращаем полученный ключ
        } // Рассчитываем ключ для предыдущего раунда
    }
}
