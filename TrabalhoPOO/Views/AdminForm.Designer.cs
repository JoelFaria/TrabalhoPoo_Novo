namespace TrabalhoPOO.Views
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            textBox1 = new TextBox();
            button4 = new Button();
            comboBox1 = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            textName = new TextBox();
            label4 = new Label();
            textPrice = new TextBox();
            label3 = new Label();
            textStock = new TextBox();
            label2 = new Label();
            textBrand = new TextBox();
            label1 = new Label();
            textGuarantee = new TextBox();
            textDescription = new TextBox();
            textId = new TextBox();
            label9 = new Label();
            label8 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            textVRAM = new TextBox();
            textBaseClock = new TextBox();
            textBoostClock = new TextBox();
            VRAMlabel = new Label();
            Baselabel = new Label();
            Boostlabel = new Label();
            textCache = new TextBox();
            textSocket = new TextBox();
            textMem = new TextBox();
            CacheLabel = new Label();
            SocketLabel = new Label();
            MemoryLabel = new Label();
            FrequencyLabel = new Label();
            textFrequency = new TextBox();
            SocketLabelMB = new Label();
            MemorySupportLabelMB = new Label();
            FormFactorLabel = new Label();
            textSocketMB = new TextBox();
            textMemorySupport = new TextBox();
            textFormFactor = new TextBox();
            textCapacity = new TextBox();
            textType = new TextBox();
            textFrequencyRAM = new TextBox();
            textLatency = new TextBox();
            Capacitylabel = new Label();
            Typelabel = new Label();
            FrequencylabelRAM = new Label();
            Latencylabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textPrice);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textStock);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBrand);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textGuarantee);
            panel1.Controls.Add(textDescription);
            panel1.Controls.Add(textId);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(-5, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(226, 734);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LavenderBlush;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(49, 23);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(123, 22);
            textBox1.TabIndex = 2;
            textBox1.Text = "Admin's Page";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button4
            // 
            button4.BackColor = Color.Cyan;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(49, 653);
            button4.Name = "button4";
            button4.Size = new Size(118, 54);
            button4.TabIndex = 0;
            button4.Text = "Logout";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(31, 122);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 23);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(31, 512);
            label7.Name = "label7";
            label7.Size = new Size(82, 21);
            label7.TabIndex = 6;
            label7.Text = "Guarantee";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(31, 444);
            label6.Name = "label6";
            label6.Size = new Size(51, 21);
            label6.TabIndex = 5;
            label6.Text = "Brand";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 372);
            label5.Name = "label5";
            label5.Size = new Size(47, 21);
            label5.TabIndex = 4;
            label5.Text = "Stock";
            // 
            // textName
            // 
            textName.Location = new Point(31, 194);
            textName.Name = "textName";
            textName.Size = new Size(141, 23);
            textName.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 304);
            label4.Name = "label4";
            label4.Size = new Size(44, 21);
            label4.TabIndex = 3;
            label4.Text = "Price";
            // 
            // textPrice
            // 
            textPrice.Location = new Point(31, 328);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(141, 23);
            textPrice.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 240);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 2;
            label3.Text = "Description";
            // 
            // textStock
            // 
            textStock.Location = new Point(31, 396);
            textStock.Name = "textStock";
            textStock.Size = new Size(141, 23);
            textStock.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 170);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // textBrand
            // 
            textBrand.Location = new Point(31, 468);
            textBrand.Name = "textBrand";
            textBrand.Size = new Size(141, 23);
            textBrand.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 98);
            label1.Name = "label1";
            label1.Size = new Size(42, 21);
            label1.TabIndex = 0;
            label1.Text = "Type";
            // 
            // textGuarantee
            // 
            textGuarantee.Location = new Point(31, 536);
            textGuarantee.Name = "textGuarantee";
            textGuarantee.Size = new Size(141, 23);
            textGuarantee.TabIndex = 13;
            // 
            // textDescription
            // 
            textDescription.Location = new Point(31, 264);
            textDescription.Name = "textDescription";
            textDescription.Size = new Size(141, 23);
            textDescription.TabIndex = 15;
            // 
            // textId
            // 
            textId.Location = new Point(31, 589);
            textId.Name = "textId";
            textId.ReadOnly = true;
            textId.Size = new Size(141, 23);
            textId.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(31, 565);
            label9.Name = "label9";
            label9.Size = new Size(23, 21);
            label9.TabIndex = 22;
            label9.Text = "Id";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(826, 79);
            label8.Name = "label8";
            label8.Size = new Size(130, 25);
            label8.TabIndex = 16;
            label8.Text = "Manage Stock";
            // 
            // button1
            // 
            button1.BackColor = Color.Gold;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(250, 651);
            button1.Name = "button1";
            button1.Size = new Size(90, 40);
            button1.TabIndex = 17;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.YellowGreen;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(346, 651);
            button2.Name = "button2";
            button2.Size = new Size(80, 40);
            button2.TabIndex = 18;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightCoral;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(432, 651);
            button3.Name = "button3";
            button3.Size = new Size(80, 40);
            button3.TabIndex = 19;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(227, 129);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1244, 321);
            dataGridView1.TabIndex = 20;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textVRAM
            // 
            textVRAM.Location = new Point(594, 653);
            textVRAM.Name = "textVRAM";
            textVRAM.Size = new Size(100, 23);
            textVRAM.TabIndex = 23;
            // 
            // textBaseClock
            // 
            textBaseClock.Location = new Point(756, 653);
            textBaseClock.Name = "textBaseClock";
            textBaseClock.Size = new Size(100, 23);
            textBaseClock.TabIndex = 24;
            // 
            // textBoostClock
            // 
            textBoostClock.Location = new Point(891, 653);
            textBoostClock.Name = "textBoostClock";
            textBoostClock.Size = new Size(100, 23);
            textBoostClock.TabIndex = 25;
            // 
            // VRAMlabel
            // 
            VRAMlabel.AutoSize = true;
            VRAMlabel.Location = new Point(594, 629);
            VRAMlabel.Name = "VRAMlabel";
            VRAMlabel.Size = new Size(43, 15);
            VRAMlabel.TabIndex = 26;
            VRAMlabel.Text = "VRAM:";
            // 
            // Baselabel
            // 
            Baselabel.AutoSize = true;
            Baselabel.Location = new Point(756, 629);
            Baselabel.Name = "Baselabel";
            Baselabel.Size = new Size(64, 15);
            Baselabel.TabIndex = 27;
            Baselabel.Text = "BaseClock:";
            // 
            // Boostlabel
            // 
            Boostlabel.AutoSize = true;
            Boostlabel.Location = new Point(891, 629);
            Boostlabel.Name = "Boostlabel";
            Boostlabel.Size = new Size(70, 15);
            Boostlabel.TabIndex = 28;
            Boostlabel.Text = "BoostClock:";
            // 
            // textCache
            // 
            textCache.Location = new Point(594, 653);
            textCache.Name = "textCache";
            textCache.Size = new Size(100, 23);
            textCache.TabIndex = 29;
            // 
            // textSocket
            // 
            textSocket.Location = new Point(756, 653);
            textSocket.Name = "textSocket";
            textSocket.Size = new Size(100, 23);
            textSocket.TabIndex = 30;
            // 
            // textMem
            // 
            textMem.Location = new Point(891, 653);
            textMem.Name = "textMem";
            textMem.Size = new Size(100, 23);
            textMem.TabIndex = 31;
            // 
            // CacheLabel
            // 
            CacheLabel.AutoSize = true;
            CacheLabel.Location = new Point(594, 629);
            CacheLabel.Name = "CacheLabel";
            CacheLabel.Size = new Size(43, 15);
            CacheLabel.TabIndex = 32;
            CacheLabel.Text = "Cache:";
            // 
            // SocketLabel
            // 
            SocketLabel.AutoSize = true;
            SocketLabel.Location = new Point(756, 629);
            SocketLabel.Name = "SocketLabel";
            SocketLabel.Size = new Size(45, 15);
            SocketLabel.TabIndex = 33;
            SocketLabel.Text = "Socket:";
            // 
            // MemoryLabel
            // 
            MemoryLabel.AutoSize = true;
            MemoryLabel.Location = new Point(891, 629);
            MemoryLabel.Name = "MemoryLabel";
            MemoryLabel.Size = new Size(100, 15);
            MemoryLabel.TabIndex = 34;
            MemoryLabel.Text = "Memory Support:";
            // 
            // FrequencyLabel
            // 
            FrequencyLabel.AutoSize = true;
            FrequencyLabel.Location = new Point(1035, 629);
            FrequencyLabel.Name = "FrequencyLabel";
            FrequencyLabel.Size = new Size(65, 15);
            FrequencyLabel.TabIndex = 35;
            FrequencyLabel.Text = "Frequency:";
            // 
            // textFrequency
            // 
            textFrequency.Location = new Point(1035, 653);
            textFrequency.Name = "textFrequency";
            textFrequency.Size = new Size(100, 23);
            textFrequency.TabIndex = 36;
            // 
            // SocketLabelMB
            // 
            SocketLabelMB.AutoSize = true;
            SocketLabelMB.Location = new Point(594, 629);
            SocketLabelMB.Name = "SocketLabelMB";
            SocketLabelMB.Size = new Size(45, 15);
            SocketLabelMB.TabIndex = 37;
            SocketLabelMB.Text = "Socket:";
            // 
            // MemorySupportLabelMB
            // 
            MemorySupportLabelMB.AutoSize = true;
            MemorySupportLabelMB.Location = new Point(756, 629);
            MemorySupportLabelMB.Name = "MemorySupportLabelMB";
            MemorySupportLabelMB.Size = new Size(97, 15);
            MemorySupportLabelMB.TabIndex = 38;
            MemorySupportLabelMB.Text = "MemorySupport:";
            // 
            // FormFactorLabel
            // 
            FormFactorLabel.AutoSize = true;
            FormFactorLabel.Location = new Point(891, 629);
            FormFactorLabel.Name = "FormFactorLabel";
            FormFactorLabel.Size = new Size(71, 15);
            FormFactorLabel.TabIndex = 39;
            FormFactorLabel.Text = "FormFactor:";
            // 
            // textSocketMB
            // 
            textSocketMB.Location = new Point(594, 653);
            textSocketMB.Name = "textSocketMB";
            textSocketMB.Size = new Size(100, 23);
            textSocketMB.TabIndex = 40;
            // 
            // textMemorySupport
            // 
            textMemorySupport.Location = new Point(756, 653);
            textMemorySupport.Name = "textMemorySupport";
            textMemorySupport.Size = new Size(100, 23);
            textMemorySupport.TabIndex = 41;
            // 
            // textFormFactor
            // 
            textFormFactor.Location = new Point(891, 653);
            textFormFactor.Name = "textFormFactor";
            textFormFactor.Size = new Size(100, 23);
            textFormFactor.TabIndex = 42;
            // 
            // textCapacity
            // 
            textCapacity.Location = new Point(594, 653);
            textCapacity.Name = "textCapacity";
            textCapacity.Size = new Size(100, 23);
            textCapacity.TabIndex = 43;
            // 
            // textType
            // 
            textType.Location = new Point(756, 653);
            textType.Name = "textType";
            textType.Size = new Size(100, 23);
            textType.TabIndex = 44;
            // 
            // textFrequencyRAM
            // 
            textFrequencyRAM.Location = new Point(891, 653);
            textFrequencyRAM.Name = "textFrequencyRAM";
            textFrequencyRAM.Size = new Size(100, 23);
            textFrequencyRAM.TabIndex = 45;
            // 
            // textLatency
            // 
            textLatency.Location = new Point(1035, 653);
            textLatency.Name = "textLatency";
            textLatency.Size = new Size(100, 23);
            textLatency.TabIndex = 46;
            // 
            // Capacitylabel
            // 
            Capacitylabel.AutoSize = true;
            Capacitylabel.Location = new Point(594, 629);
            Capacitylabel.Name = "Capacitylabel";
            Capacitylabel.Size = new Size(56, 15);
            Capacitylabel.TabIndex = 47;
            Capacitylabel.Text = "Capacity:";
            // 
            // Typelabel
            // 
            Typelabel.AutoSize = true;
            Typelabel.Location = new Point(756, 629);
            Typelabel.Name = "Typelabel";
            Typelabel.Size = new Size(35, 15);
            Typelabel.TabIndex = 48;
            Typelabel.Text = "Type:";
            // 
            // FrequencylabelRAM
            // 
            FrequencylabelRAM.AutoSize = true;
            FrequencylabelRAM.Location = new Point(891, 629);
            FrequencylabelRAM.Name = "FrequencylabelRAM";
            FrequencylabelRAM.Size = new Size(65, 15);
            FrequencylabelRAM.TabIndex = 49;
            FrequencylabelRAM.Text = "Frequency:";
            // 
            // Latencylabel
            // 
            Latencylabel.AutoSize = true;
            Latencylabel.Location = new Point(1035, 629);
            Latencylabel.Name = "Latencylabel";
            Latencylabel.Size = new Size(51, 15);
            Latencylabel.TabIndex = 50;
            Latencylabel.Text = "Latency:";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(1520, 733);
            Controls.Add(Latencylabel);
            Controls.Add(FrequencylabelRAM);
            Controls.Add(Typelabel);
            Controls.Add(Capacitylabel);
            Controls.Add(textLatency);
            Controls.Add(textFrequencyRAM);
            Controls.Add(textType);
            Controls.Add(textCapacity);
            Controls.Add(textFormFactor);
            Controls.Add(textMemorySupport);
            Controls.Add(textSocketMB);
            Controls.Add(FormFactorLabel);
            Controls.Add(MemorySupportLabelMB);
            Controls.Add(SocketLabelMB);
            Controls.Add(textFrequency);
            Controls.Add(FrequencyLabel);
            Controls.Add(MemoryLabel);
            Controls.Add(SocketLabel);
            Controls.Add(CacheLabel);
            Controls.Add(textMem);
            Controls.Add(textSocket);
            Controls.Add(textCache);
            Controls.Add(Boostlabel);
            Controls.Add(Baselabel);
            Controls.Add(VRAMlabel);
            Controls.Add(textBoostClock);
            Controls.Add(textBaseClock);
            Controls.Add(textVRAM);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(panel1);
            Name = "AdminForm";
            Text = "AdminForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textDescription;
        private TextBox textGuarantee;
        private TextBox textBrand;
        private TextBox textStock;
        private TextBox textPrice;
        private TextBox textName;
        private Label label8;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private TextBox textId;
        private Label label9;
        private TextBox textBox1;
        private Button button4;
        private TextBox textVRAM;
        private TextBox textBaseClock;
        private TextBox textBoostClock;
        private Label VRAMlabel;
        private Label Baselabel;
        private Label Boostlabel;
        private TextBox textCache;
        private TextBox textSocket;
        private TextBox textMem;
        private Label CacheLabel;
        private Label SocketLabel;
        private Label MemoryLabel;
        private Label FrequencyLabel;
        private TextBox textFrequency;
        private Label SocketLabelMB;
        private Label MemorySupportLabelMB;
        private Label FormFactorLabel;
        private TextBox textSocketMB;
        private TextBox textMemorySupport;
        private TextBox textFormFactor;
        private TextBox textCapacity;
        private TextBox textType;
        private TextBox textFrequencyRAM;
        private TextBox textLatency;
        private Label Capacitylabel;
        private Label Typelabel;
        private Label FrequencylabelRAM;
        private Label Latencylabel;
    }
}