using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; ++i)
                if (i != e.Index)
                    checkedListBox.SetItemChecked(i, false); // Проверяем элементы списка и отключаем все, кроме только что выбранного

            switch (e.Index)
            {
                // Выбран режим #1 (ECB)
                case 0:
                    // Отключаем элементы, которые не используются в этом режиме
                    vectTextBox.Enabled = false;
                    selectVectButton.Enabled = false;
                    canselSelectVectButton.Enabled = false;

                    break;

                // Выбран режим #2 (CBC)
                case 1:
                    // Включаем элементы, которые используются в этом режиме
                    vectTextBox.Enabled = true;
                    selectVectButton.Enabled = true;
                    canselSelectVectButton.Enabled = true;

                    // Переименование элемента управления
                    vectLabel.Text = "Модифицирующий вектор";

                    break;

                // Выбран режим #3 (CFB)
                case 2:
                    // Включаем элементы, которые используются в этом режиме
                    vectTextBox.Enabled = true;
                    selectVectButton.Enabled = true;
                    canselSelectVectButton.Enabled = true;

                    // Переименование элемента управления
                    vectLabel.Text = "Синхропосылка";

                    break;

                // Выбран режим #4 (OFB)
                case 3:
                    // Включаем элементы, которые используются в этом режиме
                    vectTextBox.Enabled = true;
                    selectVectButton.Enabled = true;
                    canselSelectVectButton.Enabled = true;

                    // Переименование элемента управления
                    vectLabel.Text = "Вектор инициализации";

                    break;

                // Обработка других случаев
                default:
                    break;
            } // В зависимости от выбираемого режима работы DES включаем необходимый элемент управления (например, поле под гамму)
            // ЗАМЕЧАНИЕ: в каждом кейсе добавить проверку на то, включается элемент или выкллючается (если это нужно для интерфейса)
        } // Выбор режима работы DES (элемента списка)

        private void setupDESButton_Click(object sender, EventArgs e)
        {
            if (checkedListBox.CheckedItems.Count != 0)
            {
                // Проверка ключа
                if (keyTextBox.Text.Length == 0)
                {
                    KeyWorker.GenerateKey(); // Вызов функции генерации ключа без параметров
                    MessageBox.Show("Ключ был сгенерирован автоматически и установлен!", "Ключ установлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    keyTextBox.Text = Encoding.ASCII.GetString(KeyWorker.GetInitializationKey()); // Выводим ключ на экран
                } // Поле пустое => возможна автоматическая генерация ключа
                else
                {
                    byte[] content = Encoding.ASCII.GetBytes(keyTextBox.Text); // Считываем ключ в виде байт в кодировке ASCII
                    var result = KeyWorker.GenerateKey(content); // Установка ключа, введенного пользователем

                    if (result.Item1)
                    {
                        MessageBox.Show(result.Item2, "Ключ установлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } // Вернулось true => ключ сгенерирован корректно
                    else
                    {
                        MessageBox.Show(result.Item2, "Ключ не установлен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } // Вернулось false => при генерации ключа произошла ошибка
                } // Поле не пустое => пользователь что-то вводил или выбирал ключ из файла


                // Проверка модифицирующего вектора/гаммы
                if (vectTextBox.Enabled == true)
                {
                    if (vectTextBox.Text.Length == 0)
                    {
                        MessageBox.Show("Вектор был сгенерирован автоматически и установлен!", "Вектор установлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vectTextBox.Text = Encoding.ASCII.GetString(DESAlgo.SetStartVector()); // Генерируем вектор без параметров и выводим его на экран
                    } // Поле пустое => автоматически генерируем вектор
                    else
                    {
                        byte[] content = Encoding.ASCII.GetBytes(vectTextBox.Text); // Считываем вектор в виде байт в кодировке ASCII
                        var result = DESAlgo.SetStartVector(content); // Установка вектора, введенного пользователем

                        if (result.Item1)
                            MessageBox.Show(result.Item2, "Вектор инициализации установлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            MessageBox.Show(result.Item2, "Вектор инициализации не установлен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        } // Вернулось false => при генерации вектора произошла ошибка
                    } // Получаем вектор на основе пользовательского ввода

                } // Проверяем включен ли элемент в принципе

                // Отключение элементов управления
                setupDESButton.Enabled = false;
                checkedListBox.Enabled = false;
                selectKeyButton.Enabled = false;
                cancelSelectKeyButton.Enabled = false;
                selectVectButton.Enabled = false;
                canselSelectVectButton.Enabled = false;
                keyTextBox.ReadOnly = true;
                vectTextBox.ReadOnly = true;

                // Включение элементов упраления
                resetDESButton.Enabled = true;
                messageRadioButton.Enabled = true;
                fileRadioButton.Enabled = true;

            } // Настройка ключа выполнится, если был выбран режим работы DES
            else
                MessageBox.Show("Выберите режим работы DES и повторите попытку!", "Не выбран режим DES", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } // Нажатие кнопки "настройки"

        private void messageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (messageRadioButton.Checked)
            {
                // Включаем элементы управления, которые применяются в этом режиме
                inputTextBox.Enabled = true;
                outputTextBox.Enabled = true;
                workWithMessageButton.Enabled = true;
                changeMessageOperationCheckBox.Enabled = true;

                // Отключаем элементы управления, которые не применяются в этом режиме
                filePathTextBox.Enabled = false;
                selectFileButton.Enabled = false;
                clearFilePathButton.Enabled = false;
                changeFileOperationCheckBox.Enabled = false;
                workWithFileButton.Enabled = false;
            }
        } // Включение работы с текстом

        private void fileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fileRadioButton.Checked)
            {
                // Включаем элементы управления, которые применяются в этом режиме
                filePathTextBox.Enabled = true;
                selectFileButton.Enabled = true;
                clearFilePathButton.Enabled = true;
                changeFileOperationCheckBox.Enabled = true;
                workWithFileButton.Enabled = true;

                // Отключаем элементы управления, которые не применяются в этом режиме
                inputTextBox.Enabled = false;
                outputTextBox.Enabled = false;
                workWithMessageButton.Enabled = false;
                changeMessageOperationCheckBox.Enabled = false;
            }
        } // Включение работы с файлами

        private void changeMessageOperationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (workWithMessageButton.Text == "Зашифровать")
                workWithMessageButton.Text = "Расшифровать";
            else workWithMessageButton.Text = "Зашифровать";
        } // Изменение режима работы с текстом (зашифровать/расшифровать)

        private void changeFileOperationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (workWithFileButton.Text == "Зашифровать")
                workWithFileButton.Text = "Расшифровать";
            else workWithFileButton.Text = "Зашифровать";
        } // Изменение режима работы с файлами (зашифровать/расшифровать)

        private void resetDESButton_Click(object sender, EventArgs e)
        {
            //Сбрасываем ключ шифрования
            KeyWorker.DeleteKeys();

            // Чистим MessageBox'ы
            keyTextBox.Clear();
            vectTextBox.Clear();
            inputTextBox.Clear();
            outputTextBox.Clear();
            filePathTextBox.Clear();
            vectTextBox.Clear();

            // Включаем элементы управления, которые применяются в этом режиме
            setupDESButton.Enabled = true;
            checkedListBox.Enabled = true;
            selectKeyButton.Enabled = true;
            cancelSelectKeyButton.Enabled = true;
            keyTextBox.ReadOnly = false;
            vectTextBox.ReadOnly = false;

            // Отключаем элементы управления, которые не применяются в этом режиме
            inputTextBox.Enabled = false;
            outputTextBox.Enabled = false;
            filePathTextBox.Enabled = false;
            selectFileButton.Enabled = false;
            clearFilePathButton.Enabled = false;
            changeMessageOperationCheckBox.Enabled = false;
            changeFileOperationCheckBox.Enabled = false;
            workWithFileButton.Enabled = false;
            workWithMessageButton.Enabled = false;
            messageRadioButton.Enabled = false;
            fileRadioButton.Enabled = false;
            resetDESButton.Enabled = false;

            MessageBox.Show("Параметры шифра были успешно сброшены!", "Сброс параметров шифра", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Сброс программы в начальное состояние (+ очистка параметров шифра)

        private void workWithMessageButton_Click(object sender, EventArgs e)
        {
            // Определяем какой режим DES был выбран
            int mode = 0;
            for (int i = 0; i < checkedListBox.Items.Count; ++i)
                if (checkedListBox.GetItemChecked(i))
                    mode = i;

            if (changeMessageOperationCheckBox.Checked)
            {
                int count = 0; // Переменная для хранения реального количества байт сообщения (без учета паддинга)
                bool lastBlock = false; // Фиксируем является ли блок последним
                string[] symbols = inputTextBox.Text.Split(' '); // Считываем шифр из текстбокса

                byte[] bytes = new byte[symbols.Length]; // Создаем массив для хранения байт зашифрованного сообщения
                for (int i = 0; i < symbols.Length; i++)
                    bytes[i] = Convert.ToByte(symbols[i], 10); // Заполняем массив байтами

                for (int i = 0; i < bytes.Length / 8; i++)
                {
                    if (i == bytes.Length / 8 - 1)
                        lastBlock = true; // Фиксируем, что посылаем на расшифрование последний блок

                    byte[] buffer = new byte[8];

                    for (int j = 0; j < buffer.Length; j++)
                        buffer[j] = bytes[i * 8 + j]; // Заполняем буффер байтами исходного текста

                    buffer = MessageWorker.DecryptMessage(buffer, mode, lastBlock); // Выполняем расшифрование буффера

                    count += buffer.Length; // Считаем общее количество расшифрованных байт (добавляем возвращенное количество)

                    for (int j = 0; j < buffer.Length; j++)
                        bytes[i * 8 + j] = buffer[j]; // Получаем полное расшифрованное сообщение
                }

                byte[] resultMessage = new byte[count]; // Массив для хранения расшифрованного сообщения
                for (int i = 0; i < resultMessage.Length; i++)
                    resultMessage[i] = bytes[i]; // Переносим все значения в массив для вывода

                outputTextBox.Text = Encoding.Default.GetString(resultMessage); // Выводим результат на экран
            } // Расшифрование сообщения
            else
            {
                bool lastBlock = false; // Фиксируем является ли блок последним
                string outText = "";
                byte[] content = Encoding.Default.GetBytes(inputTextBox.Text); // Считываем исходное сообщение
                byte[] resultMessage = null; // Массив для хранения зашифрованного сообщения

                if (content.Length % 8 != 0)
                    resultMessage = new byte[(content.Length / 8 + 1) * 8]; // Выбираем длину кратную 8, если сообщение не кратно
                else
                    resultMessage = new byte[content.Length]; // Длина совпадает с иходным текстом (т.к. начальная длина кратна 8)

                for (int i = 0; i < resultMessage.Length / 8; i++)
                {
                    if (i == resultMessage.Length / 8 - 1)
                        lastBlock = true; // Фиксируем, что посылаем на шифрование последний блок

                    byte[] buffer = null;

                    if (i != content.Length / 8)
                        buffer = new byte[8]; // Создаем буффер на 8 байт
                    else
                        buffer = new byte[content.Length - (content.Length / 8) * 8]; // Создаем буффер на оставшиеся байты

                    for (int j = 0; j < buffer.Length; j++)
                        buffer[j] = content[i * 8 + j]; // Заполняем буффер байтами исходного текста

                    buffer = MessageWorker.EncryptMessage(buffer, mode, lastBlock); // Выполняем шифрование буффера

                    for (int j = 0; j < buffer.Length; j++)
                        resultMessage[i * 8 + j] = buffer[j]; // Получаем полное зашифрованное сообщение

                }

                foreach (byte b in resultMessage)
                    outText += b.ToString() + " "; // Формируем шифр
                outText = outText.Substring(0, outText.Length - 1); // Убираем последний символ

                outputTextBox.Text = outText; // Выводим результат на экран
            } // Шифрование сообщения
        } // Выполнение операции шифрования/расшифрования сообщения

        private void workWithFileButton_Click(object sender, EventArgs e)
        {
            // Определяем какой режим DES был выбран
            int mode = 0;
            for (int i = 0; i < checkedListBox.Items.Count; ++i)
                if (checkedListBox.GetItemChecked(i))
                    mode = i;

            if (changeFileOperationCheckBox.Checked)
            {
                bool lastBlock = false; // Фиксируем является ли блок последним
                var fileParameters = FileWorker.GetFileParameters(); // Получаем параметры файла, с которым работаем

                if (fileParameters.Item1.Split('.').Last() == "des")
                {
                    var infile = File.OpenRead(fileParameters.Item1); // Открываем файл для чтения

                    var outputFilePath = fileParameters.Item3 + fileParameters.Item2 + ".deс"; // Получаем путь для выходного файла

                    var outfile = File.Create(outputFilePath); // Создаем файл для записи

                    while (true)
                    {
                        int count = 0; // Переменная для хранения реального количества байт сообщения (без учета паддинга)
                        var content = FileWorker.ReadFile(infile); // Считываем блок данных из файла (100 КБ)
                        byte[] bytes = new byte[content.Item2.Length]; // Массив для хранения зашифрованного сообщения

                        for (int i = 0; i < bytes.Length / 8; i++)
                        {
                            if (!content.Item1)
                            {
                                if (i == bytes.Length / 8 - 1)
                                    lastBlock = true; // Фиксируем, что посылаем на расшифрование последний блок (8 байт = 64 бит)
                            } // Фиксируем, что это последние 100 КБ или меньше

                            byte[] buffer = new byte[8];

                            for (int j = 0; j < buffer.Length; j++)
                                buffer[j] = content.Item2[i * 8 + j]; // Заполняем буффер байтами исходного текста

                            buffer = MessageWorker.DecryptMessage(buffer, mode, lastBlock); // Выполняем расшифрование буффера

                            count += buffer.Length; // Считаем общее количество расшифрованных байт (добавляем возвращенное количество)

                            for (int j = 0; j < buffer.Length; j++)
                                bytes[i * 8 + j] = buffer[j]; // Получаем полное расшифрованное сообщение
                        } // Шифруем сообщение в виде буферов по 8 байт

                        byte[] resultMessage = new byte[count]; // Массив для хранения расшифрованного сообщения
                        for (int i = 0; i < resultMessage.Length; i++)
                            resultMessage[i] = bytes[i]; // Переносим все значения в массив для вывода

                        FileWorker.WriteFile(outfile, resultMessage); // Записываем часть расшифрованного файла

                        if (!content.Item1)
                        {
                            infile.Close(); // Закрываем файл, т.к. он прочитан
                            outfile.Close(); // Закрываем файл, т.к. он полностью записан
                            break; // В случае, когда весь файл прочитан
                        }
                    }
                } // Если пользователь выбрал файл с расширением ".des" то выполняем расшифрование
                else
                {
                    MessageBox.Show("Для расшифрования нужно выбрать файл с расширением .des!", "Выбран файл с неверным расширением!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Расшифрование файла выполнено!", "Операция завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } // Расшифрование файла
            else
            {
                bool lastBlock = false; // Фиксируем является ли блок последним

                var fileParameters = FileWorker.GetFileParameters(); // Получаем параметры файла, с которым работаем

                var outputFilePath = fileParameters.Item3 + "DES" + fileParameters.Item2 + ".des"; // Получаем путь для выходного файла

                var infile = File.OpenRead(fileParameters.Item1); // Открываем файл для чтения
                var outfile = File.Create(outputFilePath); // Создаем файл для записи

                while (true)
                {
                    var content = FileWorker.ReadFile(infile); // Считываем блок данных из файла (100 КБ)
                    byte[] resultMessage = null; // Массив для хранения зашифрованного сообщения
                    if (content.Item2.Length % 8 != 0)
                        resultMessage = new byte[(content.Item2.Length / 8 + 1) * 8]; // Выбираем длину кратную 8, если сообщение не кратно
                    else
                        resultMessage = new byte[content.Item2.Length]; // Длина совпадает с иходным текстом (т.к. начальная длина кратна 8)

                    for (int i = 0; i < resultMessage.Length / 8; i++)
                    {
                        if (!content.Item1)
                        {
                            if (i == resultMessage.Length / 8 - 1)
                                lastBlock = true; // Фиксируем, что посылаем на шифрование последний блок (8 байт = 64 бит)
                        } // Фиксируем, что это последние 100 КБ или меньше

                        byte[] buffer = null;

                        if (i != content.Item2.Length / 8)
                            buffer = new byte[8]; // Создаем буффер на 8 байт
                        else
                            buffer = new byte[content.Item2.Length - (content.Item2.Length / 8) * 8]; // Создаем буффер на оставшиеся байты

                        for (int j = 0; j < buffer.Length; j++)
                            buffer[j] = content.Item2[i * 8 + j]; // Заполняем буффер байтами исходного текста

                        buffer = MessageWorker.EncryptMessage(buffer, mode, lastBlock); // Выполняем шифрование буффера

                        for (int j = 0; j < buffer.Length; j++)
                            resultMessage[i * 8 + j] = buffer[j]; // Получаем полное зашифрованное сообщение
                    } // Шифруем сообщение в виде буферов по 8 байт

                    FileWorker.WriteFile(outfile, resultMessage); // Записываем часть зашифрованного файла

                    if (!content.Item1)
                    {
                        infile.Close(); // Закрываем файл, т.к. он прочитан
                        outfile.Close(); // Закрываем файл, т.к. он полностью записан
                        break; // В случае, когда весь файл прочитан
                    }

                }
                MessageBox.Show("Шифрование файла выполнено!", "Операция завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } // Шифрование файла
        } // Выполнение операции шифрования/расшифрования файла

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (changeFileOperationCheckBox.Checked)
                openFileDialog.Filter = "Encrypted files(*.des)|*.des";
            else
                openFileDialog.Filter = "All files(*.*)|*.*|Encrypted files(*.des)|*.des";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return; // Если была нажата отмена, то ничего не происходит

            // Получаем путь до выбранного файла и его короткое имя
            FileWorker.SetFileParameters(openFileDialog.FileName, openFileDialog.SafeFileName);
            filePathTextBox.Text = FileWorker.GetFileParameters().Item1;

        } // Выбор файла для шифрования/расшифрования

        private void clearFilePathButton_Click(object sender, EventArgs e)
        {
            filePathTextBox.Clear();
            FileWorker.SetFileParameters("", "");
        } // Отмена выбора файла

        private void selectKeyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Key(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return; // Если была нажата отмена, то ничего не происходит

            StreamReader sr = new StreamReader(openFileDialog.FileName); //Открываем новый поток для чтения из файла

            keyTextBox.Text = sr.ReadLine(); // Считываем ключ в текст бокс

            sr.Close();
        } // Выбор "txt" файла для считывания ключа

        private void cancelSelectKeyButton_Click(object sender, EventArgs e)
        {
            keyTextBox.Clear();
        } // Отмена выбора файла с ключом

        private void selectVectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Vector(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return; // Если была нажата отмена, то ничего не происходит

            StreamReader sr = new StreamReader(openFileDialog.FileName); //Открываем новый поток для чтения из файла

            vectTextBox.Text = sr.ReadLine(); // Считываем ключ в текст бокс

            sr.Close();
        } // Выбор "txt" файла для считывания вектора/гаммы/синхропосылки

        private void canselSelectVectButton_Click(object sender, EventArgs e)
        {
            vectTextBox.Clear();
        } // Отмена выбора файла с вектором/гаммой
    }
}
