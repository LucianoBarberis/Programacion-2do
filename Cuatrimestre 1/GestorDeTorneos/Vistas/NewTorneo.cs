using GestorDeTorneos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeTorneos.Vistas
{
    public partial class NewTorneo : Form
    {
        private Repository _repo;

        public NewTorneo(Repository repo)
        {
            InitializeComponent();
            _repo = repo;
            inpGame.DisplayMember = "Nombre";
            inpGame.DataSource = _repo.Juegos;
            inpGame.SelectedIndex = 0;
            inpDate.MinDate = DateTime.Today;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(inpName.Text.Length == 0)
            {
                MessageBox.Show("Campo 'Nombre' Vacio", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (inpGame.SelectedItem is not Juego juegoSel)
            {
                MessageBox.Show("Seleccioná un juego", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newTorneo = new Torneo
            {
                Name = inpName.Text,
                Juego = juegoSel,
                FechaIni = inpDate.Value,
                PremioMonetario = inpPrice.Value
            };

            _repo.Torneos.Add(newTorneo);
            MessageBox.Show($"Torneo '{newTorneo.Name}' creado con éxito!", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
