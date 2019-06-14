namespace GraphApp
{
    partial class Form1
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
            this.layout = new System.Windows.Forms.PictureBox();
            this.addVertex = new System.Windows.Forms.Button();
            this.addEdge = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mCost = new System.Windows.Forms.Label();
            this.mTime = new System.Windows.Forms.Label();
            this.hCost = new System.Windows.Forms.Label();
            this.hTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mSpectrum = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.Location = new System.Drawing.Point(21, 39);
            this.layout.Name = "layout";
            this.layout.Size = new System.Drawing.Size(463, 465);
            this.layout.TabIndex = 0;
            this.layout.TabStop = false;
            this.layout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.layout_MouseClick);
            // 
            // addVertex
            // 
            this.addVertex.Location = new System.Drawing.Point(524, 109);
            this.addVertex.Name = "addVertex";
            this.addVertex.Size = new System.Drawing.Size(120, 47);
            this.addVertex.TabIndex = 1;
            this.addVertex.Text = "add vertex";
            this.addVertex.UseVisualStyleBackColor = true;
            this.addVertex.Click += new System.EventHandler(this.addVertex_Click);
            // 
            // addEdge
            // 
            this.addEdge.Location = new System.Drawing.Point(524, 162);
            this.addEdge.Name = "addEdge";
            this.addEdge.Size = new System.Drawing.Size(120, 47);
            this.addEdge.TabIndex = 2;
            this.addEdge.Text = "add edge";
            this.addEdge.UseVisualStyleBackColor = true;
            this.addEdge.Click += new System.EventHandler(this.addEdge_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(524, 215);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(120, 45);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Location = new System.Drawing.Point(524, 266);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(120, 44);
            this.deleteAllButton.TabIndex = 4;
            this.deleteAllButton.Text = "delete all";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            this.deleteAllButton.Click += new System.EventHandler(this.deleteAllButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(677, 57);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(229, 324);
            this.listBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "matrix";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonAdj_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(928, 57);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(228, 324);
            this.listBox1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(524, 417);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 46);
            this.button2.TabIndex = 9;
            this.button2.Text = "Huffman";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.huffman_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(524, 57);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(120, 46);
            this.selectButton.TabIndex = 10;
            this.selectButton.Text = "select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(450, 535);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(484, 26);
            this.textBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Frequency vector:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 624);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Matrix:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 664);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Huffman`s alg.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 584);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Optimal code cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(996, 584);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Time of processing";
            // 
            // mCost
            // 
            this.mCost.AutoSize = true;
            this.mCost.Location = new System.Drawing.Point(365, 624);
            this.mCost.Name = "mCost";
            this.mCost.Size = new System.Drawing.Size(14, 20);
            this.mCost.TabIndex = 17;
            this.mCost.Text = "-";
            // 
            // mTime
            // 
            this.mTime.AutoSize = true;
            this.mTime.Location = new System.Drawing.Point(996, 624);
            this.mTime.Name = "mTime";
            this.mTime.Size = new System.Drawing.Size(14, 20);
            this.mTime.TabIndex = 18;
            this.mTime.Text = "-";
            // 
            // hCost
            // 
            this.hCost.AutoSize = true;
            this.hCost.Location = new System.Drawing.Point(365, 664);
            this.hCost.Name = "hCost";
            this.hCost.Size = new System.Drawing.Size(14, 20);
            this.hCost.TabIndex = 19;
            this.hCost.Text = "-";
            // 
            // hTime
            // 
            this.hTime.AutoSize = true;
            this.hTime.Location = new System.Drawing.Point(996, 664);
            this.hTime.Name = "hTime";
            this.hTime.Size = new System.Drawing.Size(14, 20);
            this.hTime.TabIndex = 20;
            this.hTime.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(690, 584);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Spectrum";
            // 
            // mSpectrum
            // 
            this.mSpectrum.AutoSize = true;
            this.mSpectrum.Location = new System.Drawing.Point(694, 623);
            this.mSpectrum.Name = "mSpectrum";
            this.mSpectrum.Size = new System.Drawing.Size(14, 20);
            this.mSpectrum.TabIndex = 22;
            this.mSpectrum.Text = "-";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(677, 399);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(229, 64);
            this.listBox2.TabIndex = 23;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(928, 399);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(228, 64);
            this.listBox3.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 722);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.mSpectrum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hTime);
            this.Controls.Add(this.hCost);
            this.Controls.Add(this.mTime);
            this.Controls.Add(this.mCost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addEdge);
            this.Controls.Add(this.addVertex);
            this.Controls.Add(this.layout);
            this.Name = "Form1";
            this.Text = "Graph Application";
            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox layout;
        private System.Windows.Forms.Button addVertex;
        private System.Windows.Forms.Button addEdge;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label mCost;
        private System.Windows.Forms.Label mTime;
        private System.Windows.Forms.Label hCost;
        private System.Windows.Forms.Label hTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label mSpectrum;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
    }
}

