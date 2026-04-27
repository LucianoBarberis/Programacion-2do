using System.ComponentModel;

namespace AppDGV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = personasBinded;
        }
        public static List<Persona> personas = new List<Persona> {
                new Persona { Nombre = "Juan", Apellido = "Pérez", Edad = 30 },
                new Persona { Nombre = "Ana", Apellido = "García", Edad = 25 },
                new Persona { Nombre = "Luis", Apellido = "Martínez", Edad = 40 },
                new Persona { Nombre = "María", Apellido = "López", Edad = 35 },
                new Persona { Nombre = "Carlos", Apellido = "Sánchez", Edad = 28 },
                new Persona { Nombre = "Lucía", Apellido = "Fernández", Edad = 22 },
                new Persona { Nombre = "Pedro", Apellido = "Gómez", Edad = 33 },
                new Persona { Nombre = "Sofía", Apellido = "Díaz", Edad = 27 },
                new Persona { Nombre = "Miguel", Apellido = "Torres", Edad = 45 },
                new Persona { Nombre = "Elena", Apellido = "Ruiz", Edad = 31 }
        };

        private BindingList<Persona> personasBinded = new BindingList<Persona>(personas);
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormNewPerson formNewPerson = new FormNewPerson();
            formNewPerson.ShowDialog();
            Persona newPersona = formNewPerson.Persona;
            if (newPersona != null)
            {
                personasBinded.Add(newPersona);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectedRows.Clear();
        }
    }
}
