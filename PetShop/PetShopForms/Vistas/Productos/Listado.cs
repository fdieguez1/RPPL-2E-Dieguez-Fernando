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

namespace PetShopForms.Vistas.Productos
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Agregar();
            DialogResult dialogRes = form.ShowDialog();
            if (dialogRes != DialogResult.None)
            {
                CargarProductos();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedCells.Count > 0)
            {
                int selectedRowIndex = this.dgvProductos.SelectedCells[0].RowIndex;
                int selectedId = (int)dgvProductos.Rows[selectedRowIndex].Cells["Id"].Value;
                Form form = new Editar(selectedId);
                DialogResult dialogRes = form.ShowDialog();
                if (dialogRes != DialogResult.None)
                {
                    CargarProductos();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedCells.Count > 0)
            {
                int selectedRowIndex = this.dgvProductos.SelectedCells[0].RowIndex;
                int selectedId = (int)dgvProductos.Rows[selectedRowIndex].Cells["Id"].Value;
                if (MessageBox.Show($"Seguro que desea eliminar el cliente de id: {selectedId}?",
                                         "Confirmacion",
                                         MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    foreach (Cliente clt in Core.ListaClientes)
                    {
                        if (clt.Id == selectedId)
                        {
                            if (Core.ListaClientes - clt)
                            {
                                MessageBox.Show("Empleado eliminado",
                                         "Operacion exitosa",
                                         MessageBoxButtons.OK);

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Empleado no eliminado",
                                           "Error",
                                           MessageBoxButtons.OK);
                                break;
                            }
                        }
                    }
                    CargarProductos();
                }
            }
        }

        void CargarProductos()
        {
            if (Producto.ListaProductos.Count > 0)
            {
                dgvProductos.DataSource = new List<Entidades.Producto>(Producto.ListaProductos);
            }
        }
       
    }
}
