namespace Quetch_simulation
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
            this.lambdaITextBox = new System.Windows.Forms.TextBox();
            this.inputBox = new System.Windows.Forms.GroupBox();
            this.tmaxITextBox = new System.Windows.Forms.TextBox();
            this.tmaxLabel = new System.Windows.Forms.Label();
            this.kLabel = new System.Windows.Forms.Label();
            this.kITextBox = new System.Windows.Forms.TextBox();
            this.muITextBox = new System.Windows.Forms.TextBox();
            this.muLabel = new System.Windows.Forms.Label();
            this.lambdaLabel = new System.Windows.Forms.Label();
            this.buttonsBox = new System.Windows.Forms.GroupBox();
            this.jsqRButton = new System.Windows.Forms.RadioButton();
            this.roundrobinRButton = new System.Windows.Forms.RadioButton();
            this.randomRButton = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.GroupBox();
            this.averageCountOfRequestsInQueueOTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.averageCountOfRequestsInQuetchOTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.averageTimeOfIdleServerOTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.averageTimeOfProcessingOTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.averageTimeInQueueOTextBox = new System.Windows.Forms.TextBox();
            this.averageTimeInQuetchOTextBox = new System.Windows.Forms.TextBox();
            this.averageRequestsInQuetchOTextBox = new System.Windows.Forms.TextBox();
            this.countOfRequestsOTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inputBox.SuspendLayout();
            this.buttonsBox.SuspendLayout();
            this.outputBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lambdaITextBox
            // 
            this.lambdaITextBox.Location = new System.Drawing.Point(289, 19);
            this.lambdaITextBox.Name = "lambdaITextBox";
            this.lambdaITextBox.Size = new System.Drawing.Size(100, 20);
            this.lambdaITextBox.TabIndex = 0;
            // 
            // inputBox
            // 
            this.inputBox.Controls.Add(this.tmaxITextBox);
            this.inputBox.Controls.Add(this.tmaxLabel);
            this.inputBox.Controls.Add(this.kLabel);
            this.inputBox.Controls.Add(this.kITextBox);
            this.inputBox.Controls.Add(this.muITextBox);
            this.inputBox.Controls.Add(this.muLabel);
            this.inputBox.Controls.Add(this.lambdaLabel);
            this.inputBox.Controls.Add(this.lambdaITextBox);
            this.inputBox.Location = new System.Drawing.Point(12, 12);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(404, 131);
            this.inputBox.TabIndex = 1;
            this.inputBox.TabStop = false;
            this.inputBox.Text = "Ввод";
            // 
            // tmaxITextBox
            // 
            this.tmaxITextBox.Location = new System.Drawing.Point(289, 97);
            this.tmaxITextBox.Name = "tmaxITextBox";
            this.tmaxITextBox.Size = new System.Drawing.Size(100, 20);
            this.tmaxITextBox.TabIndex = 8;
            // 
            // tmaxLabel
            // 
            this.tmaxLabel.AutoSize = true;
            this.tmaxLabel.Location = new System.Drawing.Point(6, 102);
            this.tmaxLabel.Name = "tmaxLabel";
            this.tmaxLabel.Size = new System.Drawing.Size(204, 13);
            this.tmaxLabel.TabIndex = 7;
            this.tmaxLabel.Text = "Время окончания работы СМО (Tmax) -";
            // 
            // kLabel
            // 
            this.kLabel.AutoSize = true;
            this.kLabel.Location = new System.Drawing.Point(6, 74);
            this.kLabel.Name = "kLabel";
            this.kLabel.Size = new System.Drawing.Size(138, 13);
            this.kLabel.TabIndex = 6;
            this.kLabel.Text = "Количество приборов (k) -";
            // 
            // kITextBox
            // 
            this.kITextBox.Location = new System.Drawing.Point(289, 71);
            this.kITextBox.Name = "kITextBox";
            this.kITextBox.Size = new System.Drawing.Size(100, 20);
            this.kITextBox.TabIndex = 5;
            // 
            // muITextBox
            // 
            this.muITextBox.Location = new System.Drawing.Point(289, 45);
            this.muITextBox.Name = "muITextBox";
            this.muITextBox.Size = new System.Drawing.Size(100, 20);
            this.muITextBox.TabIndex = 4;
            // 
            // muLabel
            // 
            this.muLabel.AutoSize = true;
            this.muLabel.Location = new System.Drawing.Point(6, 48);
            this.muLabel.Name = "muLabel";
            this.muLabel.Size = new System.Drawing.Size(273, 13);
            this.muLabel.TabIndex = 3;
            this.muLabel.Text = "Интенсивность обслуживания каждого прибора (μ) -";
            // 
            // lambdaLabel
            // 
            this.lambdaLabel.AutoSize = true;
            this.lambdaLabel.Location = new System.Drawing.Point(6, 22);
            this.lambdaLabel.Name = "lambdaLabel";
            this.lambdaLabel.Size = new System.Drawing.Size(234, 13);
            this.lambdaLabel.TabIndex = 2;
            this.lambdaLabel.Text = "Интенсивность поступления требований (λ) -";
            // 
            // buttonsBox
            // 
            this.buttonsBox.Controls.Add(this.jsqRButton);
            this.buttonsBox.Controls.Add(this.roundrobinRButton);
            this.buttonsBox.Controls.Add(this.randomRButton);
            this.buttonsBox.Location = new System.Drawing.Point(422, 12);
            this.buttonsBox.Name = "buttonsBox";
            this.buttonsBox.Size = new System.Drawing.Size(200, 91);
            this.buttonsBox.TabIndex = 2;
            this.buttonsBox.TabStop = false;
            this.buttonsBox.Text = "Алгоритм распределения нагрузки";
            // 
            // jsqRButton
            // 
            this.jsqRButton.AutoSize = true;
            this.jsqRButton.Location = new System.Drawing.Point(6, 67);
            this.jsqRButton.Name = "jsqRButton";
            this.jsqRButton.Size = new System.Drawing.Size(45, 17);
            this.jsqRButton.TabIndex = 2;
            this.jsqRButton.Text = "JSQ";
            this.jsqRButton.UseVisualStyleBackColor = true;
            // 
            // roundrobinRButton
            // 
            this.roundrobinRButton.AutoSize = true;
            this.roundrobinRButton.Location = new System.Drawing.Point(6, 44);
            this.roundrobinRButton.Name = "roundrobinRButton";
            this.roundrobinRButton.Size = new System.Drawing.Size(88, 17);
            this.roundrobinRButton.TabIndex = 1;
            this.roundrobinRButton.Text = "Round-Robin";
            this.roundrobinRButton.UseVisualStyleBackColor = true;
            // 
            // randomRButton
            // 
            this.randomRButton.AutoSize = true;
            this.randomRButton.Checked = true;
            this.randomRButton.Location = new System.Drawing.Point(6, 22);
            this.randomRButton.Name = "randomRButton";
            this.randomRButton.Size = new System.Drawing.Size(65, 17);
            this.randomRButton.TabIndex = 0;
            this.randomRButton.TabStop = true;
            this.randomRButton.Text = "Random";
            this.randomRButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(422, 109);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(200, 34);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Запуск симуляции СМО";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // outputBox
            // 
            this.outputBox.Controls.Add(this.averageCountOfRequestsInQueueOTextBox);
            this.outputBox.Controls.Add(this.label8);
            this.outputBox.Controls.Add(this.averageCountOfRequestsInQuetchOTextBox);
            this.outputBox.Controls.Add(this.label3);
            this.outputBox.Controls.Add(this.averageTimeOfIdleServerOTextBox);
            this.outputBox.Controls.Add(this.label6);
            this.outputBox.Controls.Add(this.averageTimeOfProcessingOTextBox);
            this.outputBox.Controls.Add(this.label7);
            this.outputBox.Controls.Add(this.averageTimeInQueueOTextBox);
            this.outputBox.Controls.Add(this.averageTimeInQuetchOTextBox);
            this.outputBox.Controls.Add(this.averageRequestsInQuetchOTextBox);
            this.outputBox.Controls.Add(this.countOfRequestsOTextBox);
            this.outputBox.Controls.Add(this.label5);
            this.outputBox.Controls.Add(this.label4);
            this.outputBox.Controls.Add(this.label2);
            this.outputBox.Controls.Add(this.label1);
            this.outputBox.Location = new System.Drawing.Point(12, 149);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(610, 230);
            this.outputBox.TabIndex = 4;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "Вывод";
            // 
            // averageCountOfRequestsInQueueOTextBox
            // 
            this.averageCountOfRequestsInQueueOTextBox.Location = new System.Drawing.Point(504, 200);
            this.averageCountOfRequestsInQueueOTextBox.Name = "averageCountOfRequestsInQueueOTextBox";
            this.averageCountOfRequestsInQueueOTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageCountOfRequestsInQueueOTextBox.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(303, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Среднее число требований в очереди в единицу времени -";
            // 
            // averageCountOfRequestsInQuetchOTextBox
            // 
            this.averageCountOfRequestsInQuetchOTextBox.Location = new System.Drawing.Point(504, 174);
            this.averageCountOfRequestsInQuetchOTextBox.Name = "averageCountOfRequestsInQuetchOTextBox";
            this.averageCountOfRequestsInQuetchOTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageCountOfRequestsInQuetchOTextBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Среднее число требований в СМО в единицу времени -";
            // 
            // averageTimeOfIdleServerOTextBox
            // 
            this.averageTimeOfIdleServerOTextBox.Location = new System.Drawing.Point(504, 148);
            this.averageTimeOfIdleServerOTextBox.Name = "averageTimeOfIdleServerOTextBox";
            this.averageTimeOfIdleServerOTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageTimeOfIdleServerOTextBox.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Средняя длительность простоя прибора -";
            // 
            // averageTimeOfProcessingOTextBox
            // 
            this.averageTimeOfProcessingOTextBox.Location = new System.Drawing.Point(504, 122);
            this.averageTimeOfProcessingOTextBox.Name = "averageTimeOfProcessingOTextBox";
            this.averageTimeOfProcessingOTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageTimeOfProcessingOTextBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Средняя длительность обслуживания -";
            // 
            // averageTimeInQueueOTextBox
            // 
            this.averageTimeInQueueOTextBox.Location = new System.Drawing.Point(504, 96);
            this.averageTimeInQueueOTextBox.Name = "averageTimeInQueueOTextBox";
            this.averageTimeInQueueOTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageTimeInQueueOTextBox.TabIndex = 10;
            // 
            // averageTimeInQuetchOTextBox
            // 
            this.averageTimeInQuetchOTextBox.Location = new System.Drawing.Point(504, 70);
            this.averageTimeInQuetchOTextBox.Name = "averageTimeInQuetchOTextBox";
            this.averageTimeInQuetchOTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageTimeInQuetchOTextBox.TabIndex = 9;
            // 
            // averageRequestsInQuetchOTextBox
            // 
            this.averageRequestsInQuetchOTextBox.Location = new System.Drawing.Point(504, 44);
            this.averageRequestsInQuetchOTextBox.Name = "averageRequestsInQuetchOTextBox";
            this.averageRequestsInQuetchOTextBox.Size = new System.Drawing.Size(100, 20);
            this.averageRequestsInQuetchOTextBox.TabIndex = 7;
            // 
            // countOfRequestsOTextBox
            // 
            this.countOfRequestsOTextBox.Location = new System.Drawing.Point(504, 18);
            this.countOfRequestsOTextBox.Name = "countOfRequestsOTextBox";
            this.countOfRequestsOTextBox.Size = new System.Drawing.Size(100, 20);
            this.countOfRequestsOTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(309, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Средняя длительность пребывания требования в очереди -";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Средняя длительность пребывания требования в СМО -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество поступивших требований - ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество обслуженных требований -";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 384);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.buttonsBox);
            this.Controls.Add(this.inputBox);
            this.Name = "mainForm";
            this.Text = "Симуляция работы системы массового обслуживания";
            this.inputBox.ResumeLayout(false);
            this.inputBox.PerformLayout();
            this.buttonsBox.ResumeLayout(false);
            this.buttonsBox.PerformLayout();
            this.outputBox.ResumeLayout(false);
            this.outputBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox lambdaITextBox;
        private System.Windows.Forms.GroupBox inputBox;
        private System.Windows.Forms.Label lambdaLabel;
        private System.Windows.Forms.Label muLabel;
        private System.Windows.Forms.TextBox tmaxITextBox;
        private System.Windows.Forms.Label tmaxLabel;
        private System.Windows.Forms.Label kLabel;
        private System.Windows.Forms.TextBox kITextBox;
        private System.Windows.Forms.TextBox muITextBox;
        private System.Windows.Forms.GroupBox buttonsBox;
        private System.Windows.Forms.RadioButton jsqRButton;
        private System.Windows.Forms.RadioButton roundrobinRButton;
        private System.Windows.Forms.RadioButton randomRButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox outputBox;
        private System.Windows.Forms.TextBox averageTimeInQueueOTextBox;
        private System.Windows.Forms.TextBox averageTimeInQuetchOTextBox;
        private System.Windows.Forms.TextBox averageRequestsInQuetchOTextBox;
        private System.Windows.Forms.TextBox countOfRequestsOTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox averageTimeOfProcessingOTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox averageTimeOfIdleServerOTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox averageCountOfRequestsInQuetchOTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox averageCountOfRequestsInQueueOTextBox;
        private System.Windows.Forms.Label label8;
    }
}

