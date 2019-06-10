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
            this.selectButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.Location = new System.Drawing.Point(12, 12);
            this.layout.Name = "layout";
            this.layout.Size = new System.Drawing.Size(777, 486);
            this.layout.TabIndex = 0;
            this.layout.TabStop = false;
            this.layout.MouseClick += new System.Windows.Forms.MouseEventHandler(this.layout_MouseClick);
            // 
            // addVertex
            // 
            this.addVertex.Location = new System.Drawing.Point(808, 87);
            this.addVertex.Name = "addVertex";
            this.addVertex.Size = new System.Drawing.Size(120, 47);
            this.addVertex.TabIndex = 1;
            this.addVertex.Text = "add vertex";
            this.addVertex.UseVisualStyleBackColor = true;
            this.addVertex.Click += new System.EventHandler(this.addVertex_Click);
            // 
            // addEdge
            // 
            this.addEdge.Location = new System.Drawing.Point(808, 151);
            this.addEdge.Name = "addEdge";
            this.addEdge.Size = new System.Drawing.Size(120, 47);
            this.addEdge.TabIndex = 2;
            this.addEdge.Text = "add edge";
            this.addEdge.UseVisualStyleBackColor = true;
            this.addEdge.Click += new System.EventHandler(this.addEdge_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(808, 217);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(120, 45);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Location = new System.Drawing.Point(808, 282);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(120, 44);
            this.deleteAllButton.TabIndex = 4;
            this.deleteAllButton.Text = "delete all";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            this.deleteAllButton.Click += new System.EventHandler(this.deleteAllButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(808, 25);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(120, 47);
            this.selectButton.TabIndex = 5;
            this.selectButton.Text = "select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(972, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(254, 304);
            this.listBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(808, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 54);
            this.button1.TabIndex = 7;
            this.button1.Text = "adjacency matrix";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonAdj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 510);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addEdge);
            this.Controls.Add(this.addVertex);
            this.Controls.Add(this.layout);
            this.Name = "Form1";
            this.Text = "Graph Application";
            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox layout;
        private System.Windows.Forms.Button addVertex;
        private System.Windows.Forms.Button addEdge;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button button1;
    }
}

