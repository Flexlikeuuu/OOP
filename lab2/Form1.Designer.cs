namespace lab2
{
    partial class Form1
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
            comboBoxFigures = new ComboBox();
            buttonFilling = new Button();
            colorDialog1 = new ColorDialog();
            colorDialog2 = new ColorDialog();
            buttonColor = new Button();
            trackBarThickness = new TrackBar();
            buttonBack = new Button();
            buttonForward = new Button();
            buttonClear = new Button();
            comboBoxLines = new ComboBox();
            pictureBoxDrawing = new PictureBox();
            toolStrip1 = new ToolStrip();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            lblThickness = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarThickness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDrawing).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxFigures
            // 
            comboBoxFigures.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFigures.FormattingEnabled = true;
            comboBoxFigures.Items.AddRange(new object[] { "Линия", "Прямоугольник", "Эллипс", "Многоугольник", "Ломаная" });
            comboBoxFigures.Location = new Point(12, 12);
            comboBoxFigures.Name = "comboBoxFigures";
            comboBoxFigures.Size = new Size(180, 28);
            comboBoxFigures.TabIndex = 0;
            // 
            // buttonFilling
            // 
            buttonFilling.BackColor = Color.White;
            buttonFilling.FlatStyle = FlatStyle.Flat;
            buttonFilling.Location = new Point(549, 13);
            buttonFilling.Name = "buttonFilling";
            buttonFilling.Size = new Size(120, 30);
            buttonFilling.TabIndex = 2;
            buttonFilling.Text = "Цвет заливки";
            buttonFilling.UseVisualStyleBackColor = false;
            // 
            // buttonColor
            // 
            buttonColor.BackColor = Color.Black;
            buttonColor.FlatStyle = FlatStyle.Flat;
            buttonColor.ForeColor = Color.White;
            buttonColor.Location = new Point(400, 13);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(120, 30);
            buttonColor.TabIndex = 3;
            buttonColor.Text = "Цвет линии";
            buttonColor.UseVisualStyleBackColor = false;
            // 
            // trackBarThickness
            // 
            trackBarThickness.Location = new Point(200, 12);
            trackBarThickness.Maximum = 20;
            trackBarThickness.Minimum = 1;
            trackBarThickness.Name = "trackBarThickness";
            trackBarThickness.Size = new Size(150, 56);
            trackBarThickness.TabIndex = 4;
            trackBarThickness.Value = 2;
            // 
            // buttonBack
            // 
            buttonBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.Location = new Point(1000, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(40, 40);
            buttonBack.TabIndex = 5;
            buttonBack.Text = "<-";
            buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonForward
            // 
            buttonForward.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonForward.FlatStyle = FlatStyle.Flat;
            buttonForward.Location = new Point(1050, 12);
            buttonForward.Name = "buttonForward";
            buttonForward.Size = new Size(40, 40);
            buttonForward.TabIndex = 6;
            buttonForward.Text = "->";
            buttonForward.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Location = new Point(1100, 12);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(100, 40);
            buttonClear.TabIndex = 7;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // comboBoxLines
            // 
            comboBoxLines.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLines.FormattingEnabled = true;
            comboBoxLines.Items.AddRange(new object[] { "Сплошная", "Пунктир", "Точечная", "Штрих-пунктир" });
            comboBoxLines.Location = new Point(12, 50);
            comboBoxLines.Name = "comboBoxLines";
            comboBoxLines.Size = new Size(180, 28);
            comboBoxLines.TabIndex = 8;
            // 
            // pictureBoxDrawing
            // 
            pictureBoxDrawing.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxDrawing.BackColor = Color.White;
            pictureBoxDrawing.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxDrawing.Location = new Point(12, 90);
            pictureBoxDrawing.Name = "pictureBoxDrawing";
            pictureBoxDrawing.Size = new Size(1188, 498);
            pictureBoxDrawing.TabIndex = 9;
            pictureBoxDrawing.TabStop = false;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator1, toolStripSeparator2, toolStripSeparator3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1212, 25);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // lblThickness
            // 
            lblThickness.AutoSize = true;
            lblThickness.Location = new Point(200, 50);
            lblThickness.Name = "lblThickness";
            lblThickness.Size = new Size(107, 20);
            lblThickness.TabIndex = 11;
            lblThickness.Text = "Толщина: 2 px";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1212, 600);
            Controls.Add(lblThickness);
            Controls.Add(pictureBoxDrawing);
            Controls.Add(comboBoxLines);
            Controls.Add(buttonClear);
            Controls.Add(buttonForward);
            Controls.Add(buttonBack);
            Controls.Add(trackBarThickness);
            Controls.Add(buttonColor);
            Controls.Add(buttonFilling);
            Controls.Add(comboBoxFigures);
            Controls.Add(toolStrip1);
            MinimumSize = new Size(800, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Графический редактор";
            ((System.ComponentModel.ISupportInitialize)trackBarThickness).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDrawing).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxFigures;
        private Button buttonFilling;
        private ColorDialog colorDialog1;
        private ColorDialog colorDialog2;
        private Button buttonColor;
        private TrackBar trackBarThickness;
        private Button buttonBack;
        private Button buttonForward;
        private Button buttonClear;
        private ComboBox comboBoxLines;
        private PictureBox pictureBoxDrawing;
        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private Label lblThickness;
    }
}