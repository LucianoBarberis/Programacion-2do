using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppDGV
{
    public partial class FormNewPerson : Form
    {
        public FormNewPerson()
        {
            InitializeComponent();
        }

        private Persona persona;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Persona Persona { get => persona; set => persona = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inpName.Text != null && inpSurName.Text != null && inpAge.Value > 0)
            {
                persona = new Persona();
                persona.Nombre = inpName.Text;
                persona.Apellido = inpSurName.Text;
                persona.Edad = (int)inpAge.Value;
                this.Close();
            }
            else
            {
                MessageBox.Show("Completa todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
