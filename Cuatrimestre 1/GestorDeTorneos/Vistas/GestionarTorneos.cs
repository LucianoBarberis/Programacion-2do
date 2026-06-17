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
    public partial class GestionarTorneos : Form
    {
        private Torneo _torneo;
        private Repository _repo;
        private BindingSource _bsEquipos = new BindingSource();
        private BindingSource _bsPartidas = new BindingSource();

        public GestionarTorneos(Torneo torneo, Repository repo)
        {
            InitializeComponent();
            _torneo = torneo;
            _repo = repo;
            lblTorneoName.Text = _torneo.Name;
            lblGame.Text = _torneo.Juego.Nombre;
            lblid.Text = _torneo.IdTorneo.ToString();
            lblPremio.Text = "$" + _torneo.PremioMonetario.ToString();
            lblDateInicio.Text = _torneo.FechaIni.ToShortDateString();
            if (_torneo.IsActive)
            {
                lblfechaFin.Text = "...";
            }
            else
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
                btnFinalizar.Enabled = false;
                lblfechaFin.Text = _torneo.FechaFin.ToShortDateString();
            }

            // bind teams
            _bsEquipos.DataSource = _torneo.Equipos;
            lbTeams.DataSource = _bsEquipos;
            lbTeams.DisplayMember = "Nombre";

            // bind partidas
            _bsPartidas.DataSource = _torneo.Partidas;
            lbPlays.DataSource = _bsPartidas;
            lbPlays.DisplayMember = "ToString";

            btnAddTeam.Click += BtnAddTeam_Click;
            btnAddPlayer.Click += BtnAddPlayer_Click;
            btnGestionarPlay.Click += BtnGestionarPlay_Click;
            btnUpdateTeam.Click += BtnUpdateTeam_Click;
        }

        private void BtnAddTeam_Click(object? sender, EventArgs e)
        {
            using var dlg = new Form();
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlg.ClientSize = new Size(300, 120);
            dlg.Text = "Nuevo Equipo";

            var lbl = new Label() { Text = "Nombre del equipo:", Left = 10, Top = 10, AutoSize = true };
            var txt = new TextBox() { Left = 10, Top = 30, Width = 280 };
            var btnOk = new Button() { Text = "Crear", Left = 110, Width = 80, Top = 60, DialogResult = DialogResult.OK };
            var btnCancel = new Button() { Text = "Cancelar", Left = 200, Width = 80, Top = 60, DialogResult = DialogResult.Cancel };

            dlg.Controls.Add(lbl);
            dlg.Controls.Add(txt);
            dlg.Controls.Add(btnOk);
            dlg.Controls.Add(btnCancel);
            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnCancel;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                var name = txt.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Nombre vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var equipo = new Equipo { Nombre = name, Juego = _torneo.Juego };
                _torneo.Equipos.Add(equipo);
                _bsEquipos.ResetBindings(false);
            }
        }

        private void BtnUpdateTeam_Click(object? sender, EventArgs e)
        {
            // placeholder
            MessageBox.Show("Funcionalidad de editar equipo no implementada todavía.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGestionarPlay_Click(object? sender, EventArgs e)
        {
            if (lbPlays.SelectedItem is not Partida partidaSel)
            {
                MessageBox.Show("Seleccioná una partida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // future: open a form to manage partida
            MessageBox.Show($"Partida seleccionada: {partidaSel}", "Partida", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAddPlayer_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Agregar jugador no implementado aún.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAddPlay_Click(object? sender, EventArgs e)
        {
            
            
            // refresh partidas binding
            _bsPartidas.ResetBindings(false);
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            _torneo.IsActive = false;
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            btnFinalizar.Enabled = false;
            _torneo.FechaFin = DateTime.Today;
            lblfechaFin.Text = _torneo.FechaFin.ToShortDateString();
        }
    }
}
