using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_bitacora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = usuarioText.Text;
            string pass = passText.Text;

            bool logeado = Database.doLogin(usuario, pass);

            if(logeado)
            {
                MessageBox.Show($"Bienvenido te has logeado a las: {DateTime.Now.ToShortTimeString()}");
                //abrir el nuevo form.
                this.Hide();
                var form2 = new Form2();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                MessageBox.Show($"Usuario y contraseña no encontrados!");
            }
        }
    }
}
