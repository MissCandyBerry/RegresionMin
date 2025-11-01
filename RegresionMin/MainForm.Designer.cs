namespace RegresionMinCuadUI
{
 partial class MainForm
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
            dataGridViewPoints = new DataGridView();
            radioPolinomial = new RadioButton();
            radioRLM = new RadioButton();
            numericDegree = new NumericUpDown();
            labelDegree = new Label();
            buttonLoadLinea = new Button();
            buttonLoadParabola = new Button();
            buttonLoadRLM = new Button();
            buttonCalculate = new Button();
            textBoxOutput = new TextBox();
            labelVars = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericDegree).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPoints
            // 
            dataGridViewPoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPoints.Location = new Point(12, 12);
            dataGridViewPoints.Name = "dataGridViewPoints";
            dataGridViewPoints.Size = new Size(480, 300);
            dataGridViewPoints.TabIndex = 0;
            // 
            // radioPolinomial
            // 
            radioPolinomial.AutoSize = true;
            radioPolinomial.Checked = true;
            radioPolinomial.Location = new Point(510, 20);
            radioPolinomial.Name = "radioPolinomial";
            radioPolinomial.Size = new Size(107, 19);
            radioPolinomial.TabIndex = 1;
            radioPolinomial.TabStop = true;
            radioPolinomial.Text = "Polinomial (x,y)";
            radioPolinomial.UseVisualStyleBackColor = true;
            radioPolinomial.CheckedChanged += radioMode_CheckedChanged;
            // 
            // radioRLM
            // 
            radioRLM.AutoSize = true;
            radioRLM.Location = new Point(510, 50);
            radioRLM.Name = "radioRLM";
            radioRLM.Size = new Size(158, 19);
            radioRLM.TabIndex = 2;
            radioRLM.Text = "Regresión Lineal Múltiple";
            radioRLM.UseVisualStyleBackColor = true;
            radioRLM.CheckedChanged += radioMode_CheckedChanged;
            // 
            // numericDegree
            // 
            numericDegree.Location = new Point(610, 90);
            numericDegree.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericDegree.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericDegree.Name = "numericDegree";
            numericDegree.Size = new Size(60, 23);
            numericDegree.TabIndex = 3;
            numericDegree.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericDegree.ValueChanged += numericDegree_ValueChanged;
            // 
            // labelDegree
            // 
            labelDegree.Location = new Point(510, 90);
            labelDegree.Name = "labelDegree";
            labelDegree.Size = new Size(100, 23);
            labelDegree.TabIndex = 4;
            labelDegree.Text = "Grado / Vars";
            // 
            // buttonLoadLinea
            // 
            buttonLoadLinea.Location = new Point(510, 130);
            buttonLoadLinea.Name = "buttonLoadLinea";
            buttonLoadLinea.Size = new Size(160, 25);
            buttonLoadLinea.TabIndex = 5;
            buttonLoadLinea.Text = "Cargar Línea";
            buttonLoadLinea.Click += buttonLoadLinea_Click;
            // 
            // buttonLoadParabola
            // 
            buttonLoadParabola.Location = new Point(510, 165);
            buttonLoadParabola.Name = "buttonLoadParabola";
            buttonLoadParabola.Size = new Size(160, 25);
            buttonLoadParabola.TabIndex = 6;
            buttonLoadParabola.Text = "Cargar Parábola";
            buttonLoadParabola.Click += buttonLoadParabola_Click;
            // 
            // buttonLoadRLM
            // 
            buttonLoadRLM.Location = new Point(510, 200);
            buttonLoadRLM.Name = "buttonLoadRLM";
            buttonLoadRLM.Size = new Size(160, 25);
            buttonLoadRLM.TabIndex = 7;
            buttonLoadRLM.Text = "Cargar RLM (2 var.)";
            buttonLoadRLM.Click += buttonLoadRLM_Click;
            // 
            // buttonCalculate
            // 
            buttonCalculate.Location = new Point(510, 240);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new Size(160, 40);
            buttonCalculate.TabIndex = 8;
            buttonCalculate.Text = "Calcular";
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(12, 320);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(760, 220);
            textBoxOutput.TabIndex = 9;
            // 
            // labelVars
            // 
            labelVars.Location = new Point(680, 90);
            labelVars.Name = "labelVars";
            labelVars.Size = new Size(100, 23);
            labelVars.TabIndex = 10;
            // 
            // MainForm
            // 
            ClientSize = new Size(784, 561);
            Controls.Add(dataGridViewPoints);
            Controls.Add(radioPolinomial);
            Controls.Add(radioRLM);
            Controls.Add(numericDegree);
            Controls.Add(labelDegree);
            Controls.Add(buttonLoadLinea);
            Controls.Add(buttonLoadParabola);
            Controls.Add(buttonLoadRLM);
            Controls.Add(buttonCalculate);
            Controls.Add(textBoxOutput);
            Controls.Add(labelVars);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "RegresionMin";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericDegree).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPoints;
 private System.Windows.Forms.RadioButton radioPolinomial;
 private System.Windows.Forms.RadioButton radioRLM;
 private System.Windows.Forms.NumericUpDown numericDegree;
 private System.Windows.Forms.Label labelDegree;
 private System.Windows.Forms.Button buttonLoadLinea;
 private System.Windows.Forms.Button buttonLoadParabola;
 private System.Windows.Forms.Button buttonLoadRLM;
 private System.Windows.Forms.Button buttonCalculate;
 private System.Windows.Forms.TextBox textBoxOutput;
 private System.Windows.Forms.Label labelVars;
 }
}
