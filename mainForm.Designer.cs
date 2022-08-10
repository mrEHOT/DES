
namespace DES
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.selectKeyButton = new System.Windows.Forms.Button();
            this.cancelSelectKeyButton = new System.Windows.Forms.Button();
            this.keyLabel = new System.Windows.Forms.Label();
            this.vectLabel = new System.Windows.Forms.Label();
            this.canselSelectVectButton = new System.Windows.Forms.Button();
            this.selectVectButton = new System.Windows.Forms.Button();
            this.vectTextBox = new System.Windows.Forms.TextBox();
            this.resetDESButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.setupDESButton = new System.Windows.Forms.Button();
            this.changeFileOperationCheckBox = new System.Windows.Forms.CheckBox();
            this.workWithFileButton = new System.Windows.Forms.Button();
            this.clearFilePathButton = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.fileRadioButton = new System.Windows.Forms.RadioButton();
            this.messageRadioButton = new System.Windows.Forms.RadioButton();
            this.outputLabel = new System.Windows.Forms.Label();
            this.inputLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.changeMessageOperationCheckBox = new System.Windows.Forms.CheckBox();
            this.workWithMessageButton = new System.Windows.Forms.Button();
            this.DESModesLabel = new System.Windows.Forms.Label();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Режим №1 - Режим электронной кодовой книги (ECB)",
            "Режим №2 - Режим сцепления блоков шифротекста (CBC)",
            "Режим №3 - Режим обратной связи по шифротексту (CFB)",
            "Режим №4 - Режим обратной связи по выходу (OFB)"});
            this.checkedListBox.Location = new System.Drawing.Point(23, 30);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(413, 76);
            this.checkedListBox.TabIndex = 0;
            this.checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(28, 166);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(262, 20);
            this.keyTextBox.TabIndex = 1;
            // 
            // selectKeyButton
            // 
            this.selectKeyButton.Location = new System.Drawing.Point(301, 164);
            this.selectKeyButton.Name = "selectKeyButton";
            this.selectKeyButton.Size = new System.Drawing.Size(75, 23);
            this.selectKeyButton.TabIndex = 2;
            this.selectKeyButton.Text = "Обзор";
            this.selectKeyButton.UseVisualStyleBackColor = true;
            this.selectKeyButton.Click += new System.EventHandler(this.selectKeyButton_Click);
            // 
            // cancelSelectKeyButton
            // 
            this.cancelSelectKeyButton.Location = new System.Drawing.Point(382, 164);
            this.cancelSelectKeyButton.Name = "cancelSelectKeyButton";
            this.cancelSelectKeyButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSelectKeyButton.TabIndex = 3;
            this.cancelSelectKeyButton.Text = "Сброс";
            this.cancelSelectKeyButton.UseVisualStyleBackColor = true;
            this.cancelSelectKeyButton.Click += new System.EventHandler(this.cancelSelectKeyButton_Click);
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.keyLabel.Location = new System.Drawing.Point(25, 147);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(43, 17);
            this.keyLabel.TabIndex = 4;
            this.keyLabel.Text = "Ключ";
            // 
            // vectLabel
            // 
            this.vectLabel.AutoSize = true;
            this.vectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.vectLabel.Location = new System.Drawing.Point(25, 189);
            this.vectLabel.Name = "vectLabel";
            this.vectLabel.Size = new System.Drawing.Size(179, 17);
            this.vectLabel.TabIndex = 8;
            this.vectLabel.Text = "Модифицирующий вектор";
            // 
            // canselSelectVectButton
            // 
            this.canselSelectVectButton.Enabled = false;
            this.canselSelectVectButton.Location = new System.Drawing.Point(382, 206);
            this.canselSelectVectButton.Name = "canselSelectVectButton";
            this.canselSelectVectButton.Size = new System.Drawing.Size(75, 23);
            this.canselSelectVectButton.TabIndex = 7;
            this.canselSelectVectButton.Text = "Сброс";
            this.canselSelectVectButton.UseVisualStyleBackColor = true;
            this.canselSelectVectButton.Click += new System.EventHandler(this.canselSelectVectButton_Click);
            // 
            // selectVectButton
            // 
            this.selectVectButton.Enabled = false;
            this.selectVectButton.Location = new System.Drawing.Point(301, 206);
            this.selectVectButton.Name = "selectVectButton";
            this.selectVectButton.Size = new System.Drawing.Size(75, 23);
            this.selectVectButton.TabIndex = 6;
            this.selectVectButton.Text = "Обзор";
            this.selectVectButton.UseVisualStyleBackColor = true;
            this.selectVectButton.Click += new System.EventHandler(this.selectVectButton_Click);
            // 
            // vectTextBox
            // 
            this.vectTextBox.Enabled = false;
            this.vectTextBox.Location = new System.Drawing.Point(28, 208);
            this.vectTextBox.Name = "vectTextBox";
            this.vectTextBox.Size = new System.Drawing.Size(262, 20);
            this.vectTextBox.TabIndex = 5;
            // 
            // resetDESButton
            // 
            this.resetDESButton.Enabled = false;
            this.resetDESButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetDESButton.Location = new System.Drawing.Point(685, 176);
            this.resetDESButton.Name = "resetDESButton";
            this.resetDESButton.Size = new System.Drawing.Size(122, 34);
            this.resetDESButton.TabIndex = 48;
            this.resetDESButton.Text = "Сбросить";
            this.resetDESButton.UseVisualStyleBackColor = true;
            this.resetDESButton.Click += new System.EventHandler(this.resetDESButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageLabel.Location = new System.Drawing.Point(21, 294);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(184, 20);
            this.messageLabel.TabIndex = 47;
            this.messageLabel.Text = "1. Работа с текстом:";
            // 
            // setupDESButton
            // 
            this.setupDESButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setupDESButton.Location = new System.Drawing.Point(537, 176);
            this.setupDESButton.Name = "setupDESButton";
            this.setupDESButton.Size = new System.Drawing.Size(122, 34);
            this.setupDESButton.TabIndex = 46;
            this.setupDESButton.Text = "Установить";
            this.setupDESButton.UseVisualStyleBackColor = true;
            this.setupDESButton.Click += new System.EventHandler(this.setupDESButton_Click);
            // 
            // changeFileOperationCheckBox
            // 
            this.changeFileOperationCheckBox.AutoSize = true;
            this.changeFileOperationCheckBox.Enabled = false;
            this.changeFileOperationCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeFileOperationCheckBox.Location = new System.Drawing.Point(450, 434);
            this.changeFileOperationCheckBox.Name = "changeFileOperationCheckBox";
            this.changeFileOperationCheckBox.Size = new System.Drawing.Size(341, 19);
            this.changeFileOperationCheckBox.TabIndex = 45;
            this.changeFileOperationCheckBox.Text = "смена операции (зашифровать/расшифровать файл)";
            this.changeFileOperationCheckBox.UseVisualStyleBackColor = true;
            this.changeFileOperationCheckBox.CheckedChanged += new System.EventHandler(this.changeFileOperationCheckBox_CheckedChanged);
            // 
            // workWithFileButton
            // 
            this.workWithFileButton.Enabled = false;
            this.workWithFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workWithFileButton.Location = new System.Drawing.Point(451, 386);
            this.workWithFileButton.Name = "workWithFileButton";
            this.workWithFileButton.Size = new System.Drawing.Size(156, 40);
            this.workWithFileButton.TabIndex = 44;
            this.workWithFileButton.Text = "Зашифровать";
            this.workWithFileButton.UseVisualStyleBackColor = true;
            this.workWithFileButton.Click += new System.EventHandler(this.workWithFileButton_Click);
            // 
            // clearFilePathButton
            // 
            this.clearFilePathButton.Enabled = false;
            this.clearFilePathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearFilePathButton.Location = new System.Drawing.Point(797, 347);
            this.clearFilePathButton.Name = "clearFilePathButton";
            this.clearFilePathButton.Size = new System.Drawing.Size(69, 27);
            this.clearFilePathButton.TabIndex = 43;
            this.clearFilePathButton.Text = "Отмена";
            this.clearFilePathButton.UseVisualStyleBackColor = true;
            this.clearFilePathButton.Click += new System.EventHandler(this.clearFilePathButton_Click);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Enabled = false;
            this.selectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectFileButton.Location = new System.Drawing.Point(722, 347);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(69, 27);
            this.selectFileButton.TabIndex = 42;
            this.selectFileButton.Text = "Обзор";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileLabel.Location = new System.Drawing.Point(446, 294);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(183, 20);
            this.fileLabel.TabIndex = 41;
            this.fileLabel.Text = "2. Работа с файлом:";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Enabled = false;
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filePathTextBox.Location = new System.Drawing.Point(451, 349);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.Size = new System.Drawing.Size(265, 22);
            this.filePathTextBox.TabIndex = 40;
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startLabel.Location = new System.Drawing.Point(21, 252);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(303, 18);
            this.startLabel.TabIndex = 39;
            this.startLabel.Text = "Выберите режим работы программы:";
            // 
            // fileRadioButton
            // 
            this.fileRadioButton.AutoSize = true;
            this.fileRadioButton.Enabled = false;
            this.fileRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileRadioButton.Location = new System.Drawing.Point(494, 252);
            this.fileRadioButton.Name = "fileRadioButton";
            this.fileRadioButton.Size = new System.Drawing.Size(158, 22);
            this.fileRadioButton.TabIndex = 38;
            this.fileRadioButton.TabStop = true;
            this.fileRadioButton.Text = "Работа с файлами";
            this.fileRadioButton.UseVisualStyleBackColor = true;
            this.fileRadioButton.CheckedChanged += new System.EventHandler(this.fileRadioButton_CheckedChanged);
            // 
            // messageRadioButton
            // 
            this.messageRadioButton.AutoSize = true;
            this.messageRadioButton.Enabled = false;
            this.messageRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageRadioButton.Location = new System.Drawing.Point(337, 252);
            this.messageRadioButton.Name = "messageRadioButton";
            this.messageRadioButton.Size = new System.Drawing.Size(151, 22);
            this.messageRadioButton.TabIndex = 37;
            this.messageRadioButton.TabStop = true;
            this.messageRadioButton.Text = "Работа с текстом";
            this.messageRadioButton.UseVisualStyleBackColor = true;
            this.messageRadioButton.CheckedChanged += new System.EventHandler(this.messageRadioButton_CheckedChanged);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputLabel.Location = new System.Drawing.Point(175, 473);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(86, 16);
            this.outputLabel.TabIndex = 36;
            this.outputLabel.Text = "Результат";
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputLabel.Location = new System.Drawing.Point(142, 330);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(163, 16);
            this.inputLabel.TabIndex = 34;
            this.inputLabel.Text = "Исходное сообщение";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Enabled = false;
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputTextBox.Location = new System.Drawing.Point(21, 492);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(403, 111);
            this.outputTextBox.TabIndex = 33;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Enabled = false;
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextBox.Location = new System.Drawing.Point(21, 349);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputTextBox.Size = new System.Drawing.Size(403, 111);
            this.inputTextBox.TabIndex = 31;
            // 
            // changeMessageOperationCheckBox
            // 
            this.changeMessageOperationCheckBox.AutoSize = true;
            this.changeMessageOperationCheckBox.Enabled = false;
            this.changeMessageOperationCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeMessageOperationCheckBox.Location = new System.Drawing.Point(21, 670);
            this.changeMessageOperationCheckBox.Name = "changeMessageOperationCheckBox";
            this.changeMessageOperationCheckBox.Size = new System.Drawing.Size(373, 19);
            this.changeMessageOperationCheckBox.TabIndex = 50;
            this.changeMessageOperationCheckBox.Text = "смена операции (зашифровать/расшифровать сообщение)";
            this.changeMessageOperationCheckBox.UseVisualStyleBackColor = true;
            this.changeMessageOperationCheckBox.CheckedChanged += new System.EventHandler(this.changeMessageOperationCheckBox_CheckedChanged);
            // 
            // workWithMessageButton
            // 
            this.workWithMessageButton.Enabled = false;
            this.workWithMessageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workWithMessageButton.Location = new System.Drawing.Point(22, 622);
            this.workWithMessageButton.Name = "workWithMessageButton";
            this.workWithMessageButton.Size = new System.Drawing.Size(156, 40);
            this.workWithMessageButton.TabIndex = 49;
            this.workWithMessageButton.Text = "Зашифровать";
            this.workWithMessageButton.UseVisualStyleBackColor = true;
            this.workWithMessageButton.Click += new System.EventHandler(this.workWithMessageButton_Click);
            // 
            // DESModesLabel
            // 
            this.DESModesLabel.AutoSize = true;
            this.DESModesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DESModesLabel.Location = new System.Drawing.Point(22, 9);
            this.DESModesLabel.Name = "DESModesLabel";
            this.DESModesLabel.Size = new System.Drawing.Size(169, 18);
            this.DESModesLabel.TabIndex = 51;
            this.DESModesLabel.Text = "Выбор режима DES:";
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parametersLabel.Location = new System.Drawing.Point(22, 119);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(292, 18);
            this.parametersLabel.TabIndex = 52;
            this.parametersLabel.Text = "Настройка параметров шифра DES:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 699);
            this.Controls.Add(this.parametersLabel);
            this.Controls.Add(this.DESModesLabel);
            this.Controls.Add(this.changeMessageOperationCheckBox);
            this.Controls.Add(this.workWithMessageButton);
            this.Controls.Add(this.resetDESButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.setupDESButton);
            this.Controls.Add(this.changeFileOperationCheckBox);
            this.Controls.Add(this.workWithFileButton);
            this.Controls.Add(this.clearFilePathButton);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.fileRadioButton);
            this.Controls.Add(this.messageRadioButton);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.vectLabel);
            this.Controls.Add(this.canselSelectVectButton);
            this.Controls.Add(this.selectVectButton);
            this.Controls.Add(this.vectTextBox);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.cancelSelectKeyButton);
            this.Controls.Add(this.selectKeyButton);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.checkedListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Button selectKeyButton;
        private System.Windows.Forms.Button cancelSelectKeyButton;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Label vectLabel;
        private System.Windows.Forms.Button canselSelectVectButton;
        private System.Windows.Forms.Button selectVectButton;
        private System.Windows.Forms.TextBox vectTextBox;
        private System.Windows.Forms.Button resetDESButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button setupDESButton;
        private System.Windows.Forms.CheckBox changeFileOperationCheckBox;
        private System.Windows.Forms.Button workWithFileButton;
        private System.Windows.Forms.Button clearFilePathButton;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.RadioButton fileRadioButton;
        private System.Windows.Forms.RadioButton messageRadioButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.CheckBox changeMessageOperationCheckBox;
        private System.Windows.Forms.Button workWithMessageButton;
        private System.Windows.Forms.Label DESModesLabel;
        private System.Windows.Forms.Label parametersLabel;
    }
}

