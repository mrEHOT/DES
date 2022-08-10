using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    static class DESAlgo
    {
        #region Базовые функции DES и константы

        private static string startVect = ""; // Статитческая переменная, хранящая вектор инициализации (64 бит)

        private static string currentVect = ""; // Статическая переменная, хранящая текущий вектор

        // Начальная переастановка бит в блоке данных
        private const string initialPermutationTable = "58|50|42|34|26|18|10|2|60|52|44|36|28|20|12|4|62|54|46|38|30|22|14|6|64|56|48|40|32|24|16|8|57|49|41|33|25|17|9|1|59|51|43|35|27|19|11|3|61|53|45|37|29|21|13|5|63|55|47|39|31|23|15|7";

        // Финальная перестановка бит в блоке данных
        private const string finalPermutationTable = "40|8|48|16|56|24|64|32|39|7|47|15|55|23|63|31|38|6|46|14|54|22|62|30|37|5|45|13|53|21|61|29|36|4|44|12|52|20|60|28|35|3|43|11|51|19|59|27|34|2|42|10|50|18|58|26|33|1|41|9|49|17|57|25";

        // Таблица для выполнения расширения половины блока до размера ключа
        private const string extensionTable = "32|1|2|3|4|5|4|5|6|7|8|9|8|9|10|11|12|13|12|13|14|15|16|17|16|17|18|19|20|21|20|21|22|23|24|25|24|25|26|27|28|29|28|29|30|31|32|1";

        // Перестановка бит в раунде сети Фейстеля
        private const string permutationTableForFeistel = "16|7|20|21|29|12|28|17|1|15|23|26|5|18|31|10|2|8|24|14|32|27|3|9|19|13|30|6|22|11|4|25";


        private static int[,] ReturnConversionTable(int blockNumber, int[,] conversionTable)
        {
            switch (blockNumber)
            {
                case 0:
                    conversionTable = new int[4, 16]
                    {
                        {14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7},
                        {0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8},
                        {4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
                        {15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13}
                    };
                    break;

                case 1:
                    conversionTable = new int[4, 16]
                    {
                        {15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10},
                        {3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5},
                        {0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15},
                        {13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9}
                    };
                    break;

                case 2:
                    conversionTable = new int[4, 16]
                    {
                        {10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8},
                        {13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1},
                        {13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7},
                        {1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12}
                    };
                    break;

                case 3:
                    conversionTable = new int[4, 16]
                    {
                        {7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15},
                        {13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9},
                        {10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4},
                        {3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14}
                    };
                    break;

                case 4:
                    conversionTable = new int[4, 16]
                    {
                        {2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9},
                        {14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6},
                        {4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14},
                        {11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3}
                    };
                    break;

                case 5:
                    conversionTable = new int[4, 16]
                    {
                        {12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11},
                        {10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8},
                        {9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6},
                        {4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13}
                    };
                    break;

                case 6:
                    conversionTable = new int[4, 16]
                    {
                        {4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1},
                        {13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6},
                        {1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2},
                        {6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12}
                    };
                    break;

                case 7:
                    conversionTable = new int[4, 16]
                    {
                        {13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7},
                        {1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2},
                        {7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8},
                        {2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11}
                    };
                    break;

                default:
                    break;
            }
            return conversionTable;
        } // Функция, возращающающая таблицу для преобразования S-блока с определенным номером (у каждого блока она своя)

        private static void InitialPermutation(string text)
        {
            int count = 0;
            char[] bits = text.ToCharArray(); // Можно инициалзировать пустым?
            string[] permutations = initialPermutationTable.Split('|');

            foreach (string permutation in permutations)
            {
                bits[count] = text[int.Parse(permutation) - 1];
                count++;
            }

            text = new string(bits); // Формируем входной блок
        } // Функция, реализующая начальную перестановку

        private static string FeistelFunction(string halfOfText, string roundKey)
        {
            #region 1)Реализуем функцию расширения

            int count = 0;
            char[] bits = new char[48];
            string[] bitsNumbers = extensionTable.Split('|');

            foreach (string bitNumber in bitsNumbers)
            {
                bits[count] = halfOfText[int.Parse(bitNumber) - 1];
                count++;
            }

            halfOfText = new string(bits); // Формируем входной блок

            #endregion

            halfOfText = BitString.XOR(halfOfText, roundKey); // 2)Выполняем сложение по модулю два расширенной правой половины и ключа

            #region 3)Выполняем преобразование S (для 8 S-блоков длиной в 6 бит)

            string[] blocks = new string[8]; // Массив для хранения S-блоков
            for (int i = 0; i < 8; i++)
                blocks[i] = halfOfText.Substring(i * 6, 6); // Делим правую половину на 8 S-блоков длиной 6 бит

            for (int i = 0; i < blocks.Length; i++)
            {
                string content = null;
                int[,] conversionTable = null;

                conversionTable = ReturnConversionTable(i, conversionTable); // Получаем таблицу для преобразования S-блока с номером i
                content = blocks[i][0].ToString() + blocks[i][5].ToString();

                int a = BitString.ConvertToInteger(content); // Получаем номер строки для поиска по таблицы преобразования

                content = "" + blocks[i].Substring(1, 4);
                int b = BitString.ConvertToInteger(content); // Получаем номер столбца для поиска по таблицы преобразования

                blocks[i] = Convert.ToString(conversionTable[a, b], 2).PadLeft(4, '0'); // Дополняем длину блока незначащими нулями => длина каждого блока именно 4 бита
            }

            halfOfText = "";
            foreach (string block in blocks)
                halfOfText += block; // Собираем новую половину блока

            #endregion

            #region 4)Перестановка P

            count = 0;
            bits = new char[32];
            bitsNumbers = permutationTableForFeistel.Split('|');

            foreach (string bitNumber in bitsNumbers)
            {
                bits[count] = halfOfText[int.Parse(bitNumber) - 1];
                count++;
            }

            halfOfText = "";
            halfOfText = new string(bits); // Результирующий блок функции Фейстеля

            #endregion

            return halfOfText;
        } // Основная функция шифрования (функция Фейстеля)

        private static void FinalPermutation(string text)
        {
            int count = 0;
            char[] bits = text.ToCharArray();
            string[] permutations = finalPermutationTable.Split('|');

            foreach (string permutation in permutations)
            {
                bits[count] = text[int.Parse(permutation) - 1];
                count++;
            }

            text = new string(bits); // Формируем входной блок
        } // Функция, реализующая обратную перестановку

        private static string EncodeDESOneRound(string text, string key)
        {
            string leftHalfOfText = text.Substring(0, text.Length / 2);
            string rightHalfOfText = text.Substring(text.Length / 2, text.Length / 2);

            return (rightHalfOfText + BitString.XOR(leftHalfOfText, FeistelFunction(rightHalfOfText, key)));
        } // Один раунд шифрования

        private static string DecodeDESOneRound(string text, string key)
        {
            string leftHalfOfText = text.Substring(0, text.Length / 2);
            string rightHalfOfText = text.Substring(text.Length / 2, text.Length / 2);

            return (BitString.XOR(FeistelFunction(leftHalfOfText, key), rightHalfOfText) + leftHalfOfText);
        } // Один раунд расшифрования

        public static byte[] SetStartVector()
        {
            byte[] bytes = new byte[8]; // Массив для хранения байтов
            var numbers = RandomNumberGenerator.GetNumbersForKey(8, 128); // Получаем набор случайных чисел

            for (int i = 0; i < numbers.Count; i++)
                bytes[i] = (byte)numbers[i]; // Конвертируем каждый int в byte
            numbers.Clear(); // Очищаем список

            foreach (byte b in bytes)
                startVect += Convert.ToString(b, 2).PadLeft(8, '0'); // Получаем начальный вектор

            SetCurrentVector(startVect);
            return bytes;
        } // Генерируем начальный вектор + сразу устанавливаем значение текущего

        public static (bool, string) SetStartVector(byte[] text)
        {
            startVect = ""; // Сбрасываем стартовый вектор
            bool check = false; // Переменная для фиксирования установки вектора
            string message = null; // Строка, содержащая комментарий для пользователя

            if (text.Length == 8)
            {
                check = true;
                message = "Вектор инициализации прошел проверку и был установлен!";

                foreach (byte b in text)
                    startVect += Convert.ToString(b, 2).PadLeft(8, '0'); // Получаем вектор инициализации

                SetCurrentVector(startVect); // Устанавливаем значение текущего вектора

            } // Длина ключа = 8 байт => если получили от пользователя что-то другое, то вектор инициализации не подходит
            else
                message = "Вектор инициализации не прошел проверку! Убедитесь, что выбранный вектор содержит только 8 байт и повторите попытку!";

            return (check, message);
        } // Устанавливаем начальный вектор на основе пользовательского ввода + сразу устанавливаем значение текущего

        private static void SetCurrentVector(string text)
        {
            currentVect = text;
        } // Устанавливаем значение текущего вектора

        #endregion

        #region Режимы работы DES

        #region Режим #1 - Режим электронной кодовой книги (ECB)

        public static byte[] ElectronicCodebookEncode(string block)
        {
            byte[] encodedText = new byte[8]; // Создаем контейнер для байт (в нем позднее разместим результат шифрования)

            InitialPermutation(block); // Выполняем начальную перестановку для блока

            for (int i = 0; i < 16; i++)
            {
                string key = KeyWorker.KeyForNextRound(i);
                block = EncodeDESOneRound(block, key);
            } // Выполняем 16 циклов шифрования

            FinalPermutation(block); // Выполняем конечную перестановку битов

            for (int i = 0; i < encodedText.Length; i++)
            {
                string buf = block.Substring(i * 8, 8);
                encodedText[i] = Convert.ToByte(buf, 2); // Конвертируем битовую строку в байт
            } // Приводим зашифрованный текст к нужному формату вывода

            return encodedText;
        } // Шифрование в режиме ECB (#1)

        public static byte[] ElectronicCodebookDecode(string block)
        {
            byte[] decodedText = new byte[8]; // Создаем контейнер для байт (в нем позднее разместим результат шифрования)

            InitialPermutation(block); // Выполняем начальную перестановку для блока

            for (int i = 15; i >= 0; i--)
            {
                string key = KeyWorker.KeyForPrevRound(i);
                block = DecodeDESOneRound(block, key);
            } // Выполняем 16 циклов расшифрования

            FinalPermutation(block); // Выполняем конечную перестановку битов

            for (int i = 0; i < decodedText.Length; i++)
            {
                string buf = block.Substring(i * 8, 8);
                decodedText[i] = Convert.ToByte(buf, 2); // Конвертируем битовую строку в байт
            } // Приводим расшифрованный текст к нужному формату вывода

            return decodedText;
        } // Расшифрование в режиме ECB (#1)

        #endregion

        #region Режим #2 - Режим сцепления блоков шифротекста (CBC)

        public static byte[] CipherBlockChainingEncode(string block, bool lastBlock)
        {
            byte[] encodedText = new byte[8]; // Создаем контейнер для байт (в нем позднее разместим результат шифрования)

            block = BitString.XOR(block, currentVect); // Складываем текст с текущим вектором для модификации (предыдущий зашифрованный блоком текста)

            InitialPermutation(block); // Выполняем начальную перестановку для блока

            for (int i = 0; i < 16; i++)
            {
                string key = KeyWorker.KeyForNextRound(i);
                block = EncodeDESOneRound(block, key);
            } // Выполняем 16 циклов шифрования

            FinalPermutation(block); // Выполняем конечную перестановку битов

            if (lastBlock)
                SetCurrentVector(startVect); // Т.к. выполняем шифрование последнего блока, то нужно сбросить текущий модифицирующий вектор в начальное состояние
            else
                SetCurrentVector(block); // Меняем текущий модифицирующий вектор, на только что зашифрованный блок

            for (int i = 0; i < encodedText.Length; i++)
            {
                string buf = block.Substring(i * 8, 8);
                encodedText[i] = Convert.ToByte(buf, 2); // Конвертируем битовую строку в байт
            } // Приводим зашифрованный текст к нужному формату вывода

            return encodedText;
        } // Шифрование в режиме CBC (#2)

        public static byte[] CipherBlockChainingDecode(string block, bool lastBlock)
        {
            string temp = block; // Сохраняем значение битовой строки до расшифрования

            byte[] decodedText = new byte[8]; // Создаем контейнер для байт (в нем позднее разместим результат шифрования)

            InitialPermutation(block); // Выполняем начальную перестановку для блока

            for (int i = 15; i >= 0; i--)
            {
                string key = KeyWorker.KeyForPrevRound(i);
                block = DecodeDESOneRound(block, key);
            } // Выполняем 16 циклов расшифрования

            FinalPermutation(block); // Выполняем конечную перестановку битов

            block = BitString.XOR(block, currentVect); // Сложение по модулю два (убираем влияние модифицирующего вектора)

            if (lastBlock)
                SetCurrentVector(startVect); // Т.к. выполняем шифрование последнего блока, то нужно сбросить текущий модифицирующий вектор в начальное состояние
            else
                SetCurrentVector(temp); // Меняем текущий модифицирующий вектор, на начальный вид расшифровываемого блока

            for (int i = 0; i < decodedText.Length; i++)
            {
                string buf = block.Substring(i * 8, 8);
                decodedText[i] = Convert.ToByte(buf, 2); // Конвертируем битовую строку в байт
            } // Приводим расшифрованный текст к нужному формату вывода

            return decodedText;
        } // Расшифрование в режиме CBC (#2)

        #endregion

        #region Режим #3 - Режим обратной связи по шифротексту (CFB)

        public static byte[] CipherFeedbackEncode(string block, bool lastBlock)
        {
            byte[] encodedText = new byte[8]; // Создаем контейнер для байт (в нем позднее разместим результат шифрования)

            InitialPermutation(currentVect); // Выполняем начальную перестановку синхропосылки

            for (int i = 0; i < 16; i++)
            {
                string key = KeyWorker.KeyForNextRound(i);
                currentVect = EncodeDESOneRound(currentVect, key);
            } // Выполняем 16 циклов шифрования для синхропосылки

            FinalPermutation(currentVect); // Выполняем конечную перестановку битов синхропосылки

            block = BitString.XOR(block, currentVect); // Складываем текст с текущим видом синхропосылки => получаем зашифрованный блок

            if (lastBlock)
                SetCurrentVector(startVect); // Т.к. выполняем шифрование последнего блока, то нужно сбросить текущий модифицирующий вектор в начальное состояние
            else
                SetCurrentVector(block); // Меняем текущий модифицирующий вектор, на только что зашифрованный блок

            for (int i = 0; i < encodedText.Length; i++)
            {
                string buf = block.Substring(i * 8, 8);
                encodedText[i] = Convert.ToByte(buf, 2); // Конвертируем битовую строку в байт
            } // Приводим зашифрованный текст к нужному формату вывода

            return encodedText;
        } // Шифрование в режиме CFB (#3)

        public static byte[] CipherFeedbackDecode(string block, bool lastBlock)
        {
            string temp = block; // Сохраняем значение битовой строки до расшифрования

            byte[] decodedText = new byte[8]; // Создаем контейнер для байт (в нем позднее разместим результат шифрования)

            InitialPermutation(currentVect); // Выполняем начальную перестановку синхропосылки

            for (int i = 0; i < 16; i++)
            {
                string key = KeyWorker.KeyForNextRound(i);
                currentVect = EncodeDESOneRound(currentVect, key);
            } // Выполняем 16 циклов шифрования для синхропосылки

            FinalPermutation(currentVect); // Выполняем конечную перестановку битов синхропосылки

            block = BitString.XOR(block, currentVect); // Сложение по модулю два (убираем влияние синхропосылки)

            if (lastBlock)
                SetCurrentVector(startVect); // Т.к. выполняем шифрование последнего блока, то нужно сбросить текущий модифицирующий вектор в начальное состояние
            else
                SetCurrentVector(temp); // Меняем текущий модифицирующий вектор, на начальный вид расшифровываемого блока

            for (int i = 0; i < decodedText.Length; i++)
            {
                string buf = block.Substring(i * 8, 8);
                decodedText[i] = Convert.ToByte(buf, 2); // Конвертируем битовую строку в байт
            } // Приводим расшифрованный текст к нужному формату вывода

            return decodedText;
        } // Расшифрование в режиме CFB (#3)

        #endregion

        #region Режим #4 - Режим обратной связи по выходу (OFB)

        public static byte[] OutputFeedbackEncode(string block, bool lastBlock)
        {
            byte[] encodedText = new byte[8]; // Создаем контейнер для байт (в нем позднее разместим результат шифрования)

            InitialPermutation(currentVect); // Выполняем начальную перестановку для вектора

            for (int i = 0; i < 16; i++)
            {
                string key = KeyWorker.KeyForNextRound(i);
                currentVect = EncodeDESOneRound(currentVect, key);
            } // Выполняем 16 циклов шифрования для вектора

            FinalPermutation(currentVect); // Выполняем конечную перестановку битов для вектора

            if (lastBlock)
                SetCurrentVector(startVect); // Т.к. выполняем шифрование последнего блока, то нужно сбросить текущий вектор в начальное состояние
            else
                SetCurrentVector(currentVect); // Меняем текущий вектор, на вектор, полученный в результате шифрования

            block = BitString.XOR(block, currentVect); // Складываем текст с текущим видом вектора => получаем зашифрованный блок

            for (int i = 0; i < encodedText.Length; i++)
            {
                string buf = block.Substring(i * 8, 8);
                encodedText[i] = Convert.ToByte(buf, 2); // Конвертируем битовую строку в байт
            } // Приводим зашифрованный текст к нужному формату вывода

            return encodedText;
        } // Шифрование в режиме OFB (#4)

        public static byte[] OutputFeedbackDecode(string block, bool lastBlock)
        {
            byte[] decodedText = new byte[8]; // Создаем контейнер для байт (в нем позднее разместим результат шифрования)

            InitialPermutation(currentVect); // Выполняем начальную перестановку для вектора

            for (int i = 0; i < 16; i++)
            {
                string key = KeyWorker.KeyForNextRound(i);
                currentVect = EncodeDESOneRound(currentVect, key);
            } // Выполняем 16 циклов шифрования для вектора

            FinalPermutation(currentVect); // Выполняем конечную перестановку битов для вектора

            if (lastBlock)
                SetCurrentVector(startVect); // Т.к. выполняем шифрование последнего блока, то нужно сбросить текущий модифицирующий вектор в начальное состояние
            else
                SetCurrentVector(currentVect); // Меняем текущий вектор, на вектор, полученный в результате шифрования

            block = BitString.XOR(block, currentVect); // Складываем текст с текущим видом вектора => получаем расшифрованный блок

            for (int i = 0; i < decodedText.Length; i++)
            {
                string buf = block.Substring(i * 8, 8);
                decodedText[i] = Convert.ToByte(buf, 2); // Конвертируем битовую строку в байт
            } // Приводим расшифрованный текст к нужному формату вывода

            return decodedText;
        } // Расшифрование в режиме OFB (#4)

        #endregion

        #endregion
    }
}
