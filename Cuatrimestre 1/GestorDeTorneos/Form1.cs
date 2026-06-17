using GestorDeTorneos.Clases;
using GestorDeTorneos.Vistas;
using System.Collections;

namespace GestorDeTorneos
{
    public partial class Form1 : Form
    {
        private Repository _repo;
        private BindingSource _bsTorneos;

        public Form1(Repository repo)
        {
            InitializeComponent();
            _repo = repo;

            _bsTorneos = new BindingSource();
            _bsTorneos.DataSource = _repo.Torneos;

            listBox1.DataSource = _bsTorneos;
            listBox1.DisplayMember = "Name";
        }
        private void btnNewTorneo_Click(object sender, EventArgs e)
        {
            NewTorneo form = new NewTorneo(_repo);
            form.ShowDialog();
            _bsTorneos.ResetBindings(false);
        }

        private void btnGestTorneo_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is not Torneo torneoSel)
            {
                MessageBox.Show("Seleccioná un torneo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GestionarTorneos form = new GestionarTorneos(torneoSel, _repo);
            form.ShowDialog();
        }
    }
}
