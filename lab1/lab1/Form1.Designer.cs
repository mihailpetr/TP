namespace lab1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ll = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_radius = new System.Windows.Forms.TextBox();
            this.textBox_res = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(877, 293);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Щелкните правой кнопкой мыши для указания координат";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 16);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(871, 274);
            this.webBrowser2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Координаты поиска";
            // 
            // textBox_ll
            // 
            this.textBox_ll.Location = new System.Drawing.Point(130, 326);
            this.textBox_ll.Name = "textBox_ll";
            this.textBox_ll.Size = new System.Drawing.Size(189, 20);
            this.textBox_ll.TabIndex = 3;
            this.textBox_ll.TextChanged += new System.EventHandler(this.textBox_ll_TextChanged);
            this.textBox_ll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ll_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Радиус поиска";
            // 
            // textBox_radius
            // 
            this.textBox_radius.Location = new System.Drawing.Point(631, 326);
            this.textBox_radius.Name = "textBox_radius";
            this.textBox_radius.Size = new System.Drawing.Size(93, 20);
            this.textBox_radius.TabIndex = 5;
            this.textBox_radius.TextChanged += new System.EventHandler(this.textBox_radius_TextChanged);
            this.textBox_radius.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_radius_KeyPress);
            // 
            // textBox_res
            // 
            this.textBox_res.Location = new System.Drawing.Point(19, 364);
            this.textBox_res.Multiline = true;
            this.textBox_res.Name = "textBox_res";
            this.textBox_res.ReadOnly = true;
            this.textBox_res.Size = new System.Drawing.Size(870, 295);
            this.textBox_res.TabIndex = 7;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(743, 324);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(146, 23);
            this.button_search.TabIndex = 8;
            this.button_search.Text = "Начать поиск";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Категория";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "Кинотеатр",
            "Высшее учебное заведение",
            "Музей",
            "Бильярдная",
            "Кафе и рестораны",
            "Ночное заведение",
            "Заведения на свежем воздухе",
            "Поликлиника",
            "Магазины и услуги"});
            this.comboBox1.Location = new System.Drawing.Point(407, 326);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 683);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_res);
            this.Controls.Add(this.textBox_radius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Поиск мест поблизости";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_radius;
        private System.Windows.Forms.TextBox textBox_res;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

