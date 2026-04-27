namespace AppDGV
{
    partial class FormNewPerson
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
            label1 = new Label();
            button1 = new Button();
            inpName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            inpSurName = new TextBox();
            inpAge = new NumericUpDown();
            label4 = new Label();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)inpAge).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 9);
            label1.Name = "label1";
            label1.Size = new Size(243, 28);
            label1.TabIndex = 0;
            label1.Text = "Agregar Nueva Persona";
            // 
            // button1
            // 
            button1.Font = new Font("Inter", 10F);
            button1.Location = new Point(12, 278);
            button1.Name = "button1";
            button1.Size = new Size(269, 52);
            button1.TabIndex = 1;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // inpName
            // 
            inpName.Font = new Font("Inter", 10F);
            inpName.Location = new Point(12, 78);
            inpName.MaxLength = 40;
            inpName.Name = "inpName";
            inpName.Size = new Size(269, 28);
            inpName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(67, 22);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 125);
            label3.Name = "label3";
            label3.Size = new Size(68, 22);
            label3.TabIndex = 5;
            label3.Text = "Apellido";
            // 
            // inpSurName
            // 
            inpSurName.Font = new Font("Inter", 10F);
            inpSurName.Location = new Point(12, 148);
            inpSurName.MaxLength = 40;
            inpSurName.Name = "inpSurName";
            inpSurName.Size = new Size(269, 28);
            inpSurName.TabIndex = 4;
            // 
            // inpAge
            // 
            inpAge.Font = new Font("Inter", 10F);
            inpAge.Location = new Point(12, 222);
            inpAge.Name = "inpAge";
            inpAge.Size = new Size(269, 28);
            inpAge.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(11, 197);
            label4.Name = "label4";
            label4.Size = new Size(45, 22);
            label4.TabIndex = 7;
            label4.Text = "Edad";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(12, 334);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(269, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormNewPerson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 375);
            Controls.Add(btnCancel);
            Controls.Add(label4);
            Controls.Add(inpAge);
            Controls.Add(label3);
            Controls.Add(inpSurName);
            Controls.Add(label2);
            Controls.Add(inpName);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "FormNewPerson";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormNewPerson";
            ((System.ComponentModel.ISupportInitialize)inpAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox inpName;
        private Label label2;
        private Label label3;
        private TextBox inpSurName;
        private NumericUpDown inpAge;
        private Label label4;
        private Button btnCancel;
    }
}