namespace GestorDeTorneos.Vistas
{
    partial class NewTorneo
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
            inpName = new TextBox();
            lblTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            inpPrice = new NumericUpDown();
            btnAdd = new Button();
            btnCancel = new Button();
            inpGame = new ComboBox();
            label3 = new Label();
            inpDate = new DateTimePicker();
            label4 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)inpPrice).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // inpName
            // 
            inpName.Location = new Point(8, 28);
            inpName.MaxLength = 40;
            inpName.Name = "inpName";
            inpName.Size = new Size(281, 27);
            inpName.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Inter", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(61, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(196, 40);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Crear Torneo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 3;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 206);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 5;
            label2.Text = "Premio";
            // 
            // inpPrice
            // 
            inpPrice.DecimalPlaces = 2;
            inpPrice.Location = new Point(8, 229);
            inpPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            inpPrice.Name = "inpPrice";
            inpPrice.Size = new Size(281, 27);
            inpPrice.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 344);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(298, 51);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Crear";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 401);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(298, 30);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // inpGame
            // 
            inpGame.FormattingEnabled = true;
            inpGame.Location = new Point(8, 93);
            inpGame.Name = "inpGame";
            inpGame.Size = new Size(281, 28);
            inpGame.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 70);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 10;
            label3.Text = "Juego";
            // 
            // inpDate
            // 
            inpDate.Location = new Point(8, 162);
            inpDate.MinDate = new DateTime(2026, 6, 9, 0, 0, 0, 0);
            inpDate.Name = "inpDate";
            inpDate.Size = new Size(281, 27);
            inpDate.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 139);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 12;
            label4.Text = "Fecha de inicio";
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(inpDate);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(inpGame);
            panel1.Controls.Add(inpPrice);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(inpName);
            panel1.Location = new Point(12, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(298, 266);
            panel1.TabIndex = 13;
            // 
            // NewTorneo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 443);
            Controls.Add(panel1);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(lblTitle);
            MaximumSize = new Size(340, 490);
            MinimumSize = new Size(340, 490);
            Name = "NewTorneo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestor de Torneos | Nuevo Torneo";
            ((System.ComponentModel.ISupportInitialize)inpPrice).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inpName;
        private Label lblTitle;
        private Label label1;
        private Label label2;
        private NumericUpDown inpPrice;
        private Button btnAdd;
        private Button btnCancel;
        private ComboBox inpGame;
        private Label label3;
        private DateTimePicker inpDate;
        private Label label4;
        private Panel panel1;
    }
}