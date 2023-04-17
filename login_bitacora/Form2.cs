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
    public partial class Form2 : Form
    {
        private List<Historial> historial;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            historial = Database.ObtenerBitacora();

            historial.ForEach(x =>
            {
                DataGrid.Rows.Add(x.usuario, x.fecha);
            });
        }
    }
}
