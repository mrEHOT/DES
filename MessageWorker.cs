using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    static class MessageWorker
    {
        private static byte[] Padding(byte[] content)
        {
            if (content.Length != 8)
            {
                byte[] result = new byte[8]; // Создаем новый массив байтов
                int numberOfNewBytes = result.Length - content.Length; // Вычисляем сколько байтов добавить

                for (int i = 0; i < content.Length; i++)
                    result[i] = content[i];

                for (int i = content.Length; i < numberOfNewBytes - 1; i++)
                    result[i] = 0; // Дополняем нулями

                result[result.Length - 1] = (byte)numberOfNewBytes; // В последний байт кладем количество дополняющих байт

                return result;
            }
            else
                return content;
        } // Дополнение блока данных нужным количеством байт (последний байт = количеству дополняющих байт, остальные - нулевые)

        private static byte[] DeletePadding(byte[] content)
        {
            byte[] result = new byte[content.Length - content[content.Length - 1]]; // Создаем новый массив байт, размер которого уменьшен на количество байт дополнения
            for (int i = content.Length - 2; i > result.Length - 1; i--)
                if (content[i] != 0) // Если один из байтов наполнения не равен нулю, то это обычный текст, а не паддинг
                    return content; // Возвращаем блок в исходном виде

            for (int i = 0; i < result.Length; i++)
                result[i] = content[i]; // Записываем байты, которые не являются байтами дополнения

            return result;
        } // Удаляем дополнение из блока данных (убираем padding)

        public static byte[] EncryptMessage(byte[] content, int mode, bool lastBlock)
        {
            content = Padding(content); // Выполняем дополнение блока данных (до 64 бит)
            string text = "";
            foreach (byte b in content)
                text += Convert.ToString(b, 2).PadLeft(8, '0'); // Конвертируем массив байт в string

            switch (mode)
            {
                // Вызов шифрования в режиме ECB (#1)
                case 0:
                    content = DESAlgo.ElectronicCodebookEncode(text); // Вызываем функцию шифрования одного блока
                    break;

                // Вызов шифрования в режиме CBC (#2)
                case 1:
                    content = DESAlgo.CipherBlockChainingEncode(text, lastBlock); // Вызываем функцию шифрования одного блока
                    break;

                // Вызов шифрования в режиме CFB (#3)
                case 2:
                    content = DESAlgo.CipherFeedbackEncode(text, lastBlock); // Вызываем функцию шифрования одного блока
                    break;

                // Вызов шифрования в режиме OFB (#4)
                case 3:
                    content = DESAlgo.OutputFeedbackEncode(text, lastBlock); // Вызываем функцию шифрования одного блока
                    break;

                default:
                    break;
            } // В зависимости от выбранного режима вызывается соответствующая функция шифрования

            return content;
        } // Функция, обеспечивает процесс шифрования сообщения в выбранном режиме DES

        public static byte[] DecryptMessage(byte[] content, int mode, bool lastBlock)
        {
            string text = "";
            foreach (byte b in content)
                text += Convert.ToString(b, 2).PadLeft(8, '0'); // Конвертируем массив байт в string

            switch (mode)
            {
                // Вызов расшифрования в режиме ECB (#1)
                case 0:
                    content = DESAlgo.ElectronicCodebookDecode(text); // Вызываем функцию расшифрования одного блока
                    break;

                // Вызов расшифрования в режиме CBC (#2)
                case 1:
                    content = DESAlgo.CipherBlockChainingDecode(text, lastBlock); // Вызываем функцию расшифрования одного блока
                    break;

                // Вызов расшифрования в режиме CFB (#3)
                case 2:
                    content = DESAlgo.CipherFeedbackDecode(text, lastBlock); // Вызываем функцию расшифрования одного блока
                    break;

                // Вызов расшифрования в режиме OFB (#4)
                case 3:
                    content = DESAlgo.OutputFeedbackDecode(text, lastBlock); // Вызываем функцию расшифрования одного блока
                    break;

                default:
                    break;
            } // В зависимости от выбранного режима вызывается соответствующая функция расшифрования

            if (lastBlock)
                content = DeletePadding(content); // Если расшифровываем последний блок => в нем может присутствовать дополнение => его нужно убрать

            return content;
        } // Функция, обеспечивает процесс расшифрования сообщения в выбранном режиме DES
    }
}
