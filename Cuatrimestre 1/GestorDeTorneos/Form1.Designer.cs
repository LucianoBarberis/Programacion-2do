namespace GestorDeTorneos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            listBox1 = new ListBox();
            label2 = new Label();
            btnNewTorneo = new Button();
            btnGestTorneo = new Button();
            btnAboutUs = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter Medium", 15F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(237, 36);
            label1.TabIndex = 0;
            label1.Text = "Gestor de Torneos";
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 12F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 28;
            listBox1.Location = new Point(285, 66);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(332, 368);
            listBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(285, 43);
            label2.Name = "label2";
            label2.Size = new Size(132, 20);
            label2.TabIndex = 2;
            label2.Text = "Listado de torneos";
            // 
            // btnNewTorneo
            // 
            btnNewTorneo.Font = new Font("Segoe UI", 10F);
            btnNewTorneo.Location = new Point(12, 66);
            btnNewTorneo.Name = "btnNewTorneo";
            btnNewTorneo.Size = new Size(248, 46);
            btnNewTorneo.TabIndex = 3;
            btnNewTorneo.Text = "Crear Torneo";
            btnNewTorneo.UseVisualStyleBackColor = true;
            btnNewTorneo.Click += btnNewTorneo_Click;
            // 
            // btnGestTorneo
            // 
            btnGestTorneo.Font = new Font("Segoe UI", 10F);
            btnGestTorneo.Location = new Point(12, 118);
            btnGestTorneo.Name = "btnGestTorneo";
            btnGestTorneo.Size = new Size(248, 46);
            btnGestTorneo.TabIndex = 4;
            btnGestTorneo.Text = "Gestionar Torneo";
            btnGestTorneo.UseVisualStyleBackColor = true;
            // 
            // btnAboutUs
            // 
            btnAboutUs.Font = new Font("Segoe UI", 9F);
            btnAboutUs.Location = new Point(12, 405);
            btnAboutUs.Name = "btnAboutUs";
            btnAboutUs.Size = new Size(248, 29);
            btnAboutUs.TabIndex = 5;
            btnAboutUs.Text = "Creditos";
            btnAboutUs.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 451);
            Controls.Add(btnAboutUs);
            Controls.Add(btnGestTorneo);
            Controls.Add(btnNewTorneo);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor de Torneos | Inicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private Label label2;
        private Button btnNewTorneo;
        private Button btnGestTorneo;
        private Button btnAboutUs;
    }
}
