using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopForms.Vistas.Ventas
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Agregar();
            DialogResult dialogRes = form.ShowDialog();
            if (dialogRes != DialogResult.None)
            {
                CargarVentas();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedCells.Count > 0)
            {
                int selectedRowIndex = this.dgvProductos.SelectedCells[0].RowIndex;
                int selectedId = (int)dgvProductos.Rows[selectedRowIndex].Cells["Id"].Value;
                if (MessageBox.Show($"Seguro que desea eliminar la venta de id: {selectedId}?",
                                         "Confirmacion",
                                         MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    foreach (Venta vta in Venta.ListaVentas)
                    {
                        if (vta.Id == selectedId)
                        {
                            if (Venta.ListaVentas - vta)
                            {
                                MessageBox.Show("Venta eliminada",
                                         "Operacion exitosa",
                                         MessageBoxButtons.OK);

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Venta no eliminada",
                                           "Error",
                                           MessageBoxButtons.OK);
                                break;
                            }
                        }
                    }
                    CargarVentas();
                }
            }
        }

        void CargarVentas()
        {
            if (Venta.ListaVentas.Count > 0)
            {
                dgvProductos.DataSource = Venta.ListarVentas();
            }
        }

        private void Listado_Paint(object sender, PaintEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }
    }
}
