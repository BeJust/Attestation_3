namespace GraphTask2
{
    partial class MainWindow
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
            this.saveToFile_btn = new System.Windows.Forms.Button();
            this.loadFromFile_btn = new System.Windows.Forms.Button();
            this.groupBox_gb = new System.Windows.Forms.GroupBox();
            this.moveNode_rb = new System.Windows.Forms.RadioButton();
            this.deleteEdge_rb = new System.Windows.Forms.RadioButton();
            this.addEdge_rb = new System.Windows.Forms.RadioButton();
            this.deleteNode_rb = new System.Windows.Forms.RadioButton();
            this.addNode_rb = new System.Windows.Forms.RadioButton();
            this.inputNodeName_lbl = new System.Windows.Forms.Label();
            this.inputNodeName_txt = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox_pb = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.deletedEdges_lbl = new System.Windows.Forms.Label();
            this.sepatedName_lbl = new System.Windows.Forms.Label();
            this.separatedNodes_lbl = new System.Windows.Forms.Label();
            this.groupBox_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // saveToFile_btn
            // 
            this.saveToFile_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveToFile_btn.Location = new System.Drawing.Point(780, 46);
            this.saveToFile_btn.Name = "saveToFile_btn";
            this.saveToFile_btn.Size = new System.Drawing.Size(206, 36);
            this.saveToFile_btn.TabIndex = 0;
            this.saveToFile_btn.Text = "Сохранить в файл";
            this.saveToFile_btn.UseVisualStyleBackColor = true;
            this.saveToFile_btn.Click += new System.EventHandler(this.saveToFile_btn_Click);
            // 
            // loadFromFile_btn
            // 
            this.loadFromFile_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadFromFile_btn.Location = new System.Drawing.Point(1024, 44);
            this.loadFromFile_btn.Name = "loadFromFile_btn";
            this.loadFromFile_btn.Size = new System.Drawing.Size(206, 38);
            this.loadFromFile_btn.TabIndex = 1;
            this.loadFromFile_btn.Text = "Загрузить из файла";
            this.loadFromFile_btn.UseVisualStyleBackColor = true;
            this.loadFromFile_btn.Click += new System.EventHandler(this.loadFromFile_btn_Click);
            // 
            // groupBox_gb
            // 
            this.groupBox_gb.Controls.Add(this.moveNode_rb);
            this.groupBox_gb.Controls.Add(this.deleteEdge_rb);
            this.groupBox_gb.Controls.Add(this.addEdge_rb);
            this.groupBox_gb.Controls.Add(this.deleteNode_rb);
            this.groupBox_gb.Controls.Add(this.addNode_rb);
            this.groupBox_gb.Location = new System.Drawing.Point(12, 12);
            this.groupBox_gb.Name = "groupBox_gb";
            this.groupBox_gb.Size = new System.Drawing.Size(558, 36);
            this.groupBox_gb.TabIndex = 2;
            this.groupBox_gb.TabStop = false;
            this.groupBox_gb.Text = "Функции";
            // 
            // moveNode_rb
            // 
            this.moveNode_rb.AutoSize = true;
            this.moveNode_rb.Location = new System.Drawing.Point(436, 13);
            this.moveNode_rb.Name = "moveNode_rb";
            this.moveNode_rb.Size = new System.Drawing.Size(119, 17);
            this.moveNode_rb.TabIndex = 4;
            this.moveNode_rb.TabStop = true;
            this.moveNode_rb.Text = "Переместить узел";
            this.moveNode_rb.UseVisualStyleBackColor = true;
            // 
            // deleteEdge_rb
            // 
            this.deleteEdge_rb.AutoSize = true;
            this.deleteEdge_rb.Location = new System.Drawing.Point(328, 13);
            this.deleteEdge_rb.Name = "deleteEdge_rb";
            this.deleteEdge_rb.Size = new System.Drawing.Size(101, 17);
            this.deleteEdge_rb.TabIndex = 3;
            this.deleteEdge_rb.TabStop = true;
            this.deleteEdge_rb.Text = "Удалить ребро";
            this.deleteEdge_rb.UseVisualStyleBackColor = true;
            // 
            // addEdge_rb
            // 
            this.addEdge_rb.AutoSize = true;
            this.addEdge_rb.Location = new System.Drawing.Point(213, 13);
            this.addEdge_rb.Name = "addEdge_rb";
            this.addEdge_rb.Size = new System.Drawing.Size(108, 17);
            this.addEdge_rb.TabIndex = 2;
            this.addEdge_rb.TabStop = true;
            this.addEdge_rb.Text = "Добавить ребро";
            this.addEdge_rb.UseVisualStyleBackColor = true;
            // 
            // deleteNode_rb
            // 
            this.deleteNode_rb.AutoSize = true;
            this.deleteNode_rb.Location = new System.Drawing.Point(113, 13);
            this.deleteNode_rb.Name = "deleteNode_rb";
            this.deleteNode_rb.Size = new System.Drawing.Size(94, 17);
            this.deleteNode_rb.TabIndex = 1;
            this.deleteNode_rb.TabStop = true;
            this.deleteNode_rb.Text = "Удалить узел";
            this.deleteNode_rb.UseVisualStyleBackColor = true;
            // 
            // addNode_rb
            // 
            this.addNode_rb.AutoSize = true;
            this.addNode_rb.Location = new System.Drawing.Point(6, 13);
            this.addNode_rb.Name = "addNode_rb";
            this.addNode_rb.Size = new System.Drawing.Size(101, 17);
            this.addNode_rb.TabIndex = 0;
            this.addNode_rb.TabStop = true;
            this.addNode_rb.Text = "Добавить узел";
            this.addNode_rb.UseVisualStyleBackColor = true;
            // 
            // inputNodeName_lbl
            // 
            this.inputNodeName_lbl.AutoSize = true;
            this.inputNodeName_lbl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputNodeName_lbl.Location = new System.Drawing.Point(9, 65);
            this.inputNodeName_lbl.Name = "inputNodeName_lbl";
            this.inputNodeName_lbl.Size = new System.Drawing.Size(134, 14);
            this.inputNodeName_lbl.TabIndex = 3;
            this.inputNodeName_lbl.Text = "Введите название узла:";
            // 
            // inputNodeName_txt
            // 
            this.inputNodeName_txt.Location = new System.Drawing.Point(149, 62);
            this.inputNodeName_txt.Name = "inputNodeName_txt";
            this.inputNodeName_txt.Size = new System.Drawing.Size(100, 20);
            this.inputNodeName_txt.TabIndex = 5;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pictureBox_pb
            // 
            this.pictureBox_pb.Location = new System.Drawing.Point(13, 88);
            this.pictureBox_pb.Name = "pictureBox_pb";
            this.pictureBox_pb.Size = new System.Drawing.Size(1260, 579);
            this.pictureBox_pb.TabIndex = 7;
            this.pictureBox_pb.TabStop = false;
            this.pictureBox_pb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_pb_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Найти лучшее разделение ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Количество ребер, которое необходимо удалить: ";
            // 
            // deletedEdges_lbl
            // 
            this.deletedEdges_lbl.AutoSize = true;
            this.deletedEdges_lbl.Location = new System.Drawing.Point(673, 65);
            this.deletedEdges_lbl.Name = "deletedEdges_lbl";
            this.deletedEdges_lbl.Size = new System.Drawing.Size(0, 13);
            this.deletedEdges_lbl.TabIndex = 10;
            // 
            // sepatedName_lbl
            // 
            this.sepatedName_lbl.AutoSize = true;
            this.sepatedName_lbl.Location = new System.Drawing.Point(574, 23);
            this.sepatedName_lbl.Name = "sepatedName_lbl";
            this.sepatedName_lbl.Size = new System.Drawing.Size(218, 13);
            this.sepatedName_lbl.TabIndex = 11;
            this.sepatedName_lbl.Text = "Узлы, отделенные в отдельный подграф:";
            // 
            // separatedNodes_lbl
            // 
            this.separatedNodes_lbl.AutoSize = true;
            this.separatedNodes_lbl.Location = new System.Drawing.Point(798, 23);
            this.separatedNodes_lbl.Name = "separatedNodes_lbl";
            this.separatedNodes_lbl.Size = new System.Drawing.Size(0, 13);
            this.separatedNodes_lbl.TabIndex = 12;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 679);
            this.Controls.Add(this.separatedNodes_lbl);
            this.Controls.Add(this.sepatedName_lbl);
            this.Controls.Add(this.deletedEdges_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox_pb);
            this.Controls.Add(this.inputNodeName_txt);
            this.Controls.Add(this.inputNodeName_lbl);
            this.Controls.Add(this.groupBox_gb);
            this.Controls.Add(this.loadFromFile_btn);
            this.Controls.Add(this.saveToFile_btn);
            this.Name = "MainWindow";
            this.Text = "Task2";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox_gb.ResumeLayout(false);
            this.groupBox_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveToFile_btn;
        private System.Windows.Forms.Button loadFromFile_btn;
        private System.Windows.Forms.GroupBox groupBox_gb;
        private System.Windows.Forms.Label inputNodeName_lbl;
        private System.Windows.Forms.RadioButton moveNode_rb;
        private System.Windows.Forms.RadioButton deleteEdge_rb;
        private System.Windows.Forms.RadioButton addEdge_rb;
        private System.Windows.Forms.RadioButton deleteNode_rb;
        private System.Windows.Forms.RadioButton addNode_rb;
        private System.Windows.Forms.TextBox inputNodeName_txt;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox pictureBox_pb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label deletedEdges_lbl;
        private System.Windows.Forms.Label sepatedName_lbl;
        private System.Windows.Forms.Label separatedNodes_lbl;
    }
}

