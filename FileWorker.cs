using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DES
{
    static class FileWorker
    {
        private static string filePath = ""; // Статическая переменная для хранения полного пути к файлу, с которым работаем
        private static string directoryPath = ""; // Статическая переменная для хранения пути к директории, где хранится файл
        private static string shortFileName = ""; // Статическая переменная для хранения короткого имени файла

        public static void SetFileParameters(string filePath, string shortFileName)
        {
            // Сохраняем полный путь до файла
            FileWorker.filePath = filePath;

            // Сохраняем короткое имя файла без расширения
            FileWorker.shortFileName = ""; // Сбрасываем короткое имя файла
            foreach (string str in shortFileName.Split('.'))
                if (str != shortFileName.Split('.').Last())
                    FileWorker.shortFileName += str;

            // Сохраняем путь к директории, где находится файл
            FileWorker.directoryPath = ""; // Сбрасываем путь к директории
            for (int i = 0; i < filePath.Length - shortFileName.Length; i++)
                FileWorker.directoryPath += filePath[i];

        } // Сохраняем информацию о файле, с которым работаем

        public static (string, string, string) GetFileParameters()
        {
            return (FileWorker.filePath, FileWorker.shortFileName, FileWorker.directoryPath);
        } // Возвращаем информацию о файле

        public static (bool, byte[]) ReadFile(Stream stream)
        {
            int actuallyLength = 0; // Актуальная длина буфера байтов, для сжатия буфера до фактического размера
            bool status = true; // Маркер для проверки
            byte[] buf = new byte[102400]; // Максимальный размер буфера 100 КБ = 102400 Байт

            while (true)
            {
                int position = 0;

                while (actuallyLength < buf.Length)
                {
                    var actuallyRead = stream.Read(buf, position, buf.Length - position);
                    if (actuallyRead == 0)
                    {
                        status = false;
                        break;
                    }
                    position += actuallyRead;
                    actuallyLength += actuallyRead; // Перещитываем фактический размер прочитанного

                } // Пока текущая позиция для чтения меньше, чем размер буфера продолжаем чтение

                if (position == 0)
                    break;
            }

            if (actuallyLength < buf.Length)
            {
                byte[] temp = new byte[actuallyLength];
                for (int i = 0; i < temp.Length; i++)
                    temp[i] = buf[i]; // Копируем данные в временный массив

                buf = temp;
            } // Если количество реально считанных данных меньше максимальной длины буфера, то сжимаем буфер

            return (status, buf);

        } // Чтение файла по байтам

        public static void WriteFile(Stream stream, byte[] content)
        {
            stream.Write(content, 0, content.Length);
        } // Записываем файл после расшифровки

    }
}
