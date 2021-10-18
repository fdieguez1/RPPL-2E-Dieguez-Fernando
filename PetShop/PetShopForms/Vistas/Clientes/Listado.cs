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

namespace PetShopForms.Vistas.Clientes
{
    public partial class Listado : Form
    {
        bool botonesVisibles;
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            CargarClientes();
            botonesVisibles = Core.UsuarioLogueado.EsAdmin();
            btnAdd.Visible = botonesVisibles;
            btnEdit.Visible = botonesVisibles;
            btnDelete.Visible = botonesVisibles;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Agregar();
            DialogResult dialogRes = form.ShowDialog();
            if (dialogRes != DialogResult.None)
            {
                CargarClientes();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count > 0)
            {
                Form form = new Editar((Cliente)dgvClientes.CurrentRow.DataBoundItem);
                DialogResult dialogRes = form.ShowDialog();
                if (dialogRes != DialogResult.None)
                {
                    CargarClientes();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count > 0)
            {
                int selectedRowIndex = this.dgvClientes.SelectedCells[0].RowIndex;
                int selectedId = (int)dgvClientes.Rows[selectedRowIndex].Cells["Id"].Value;
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
                                MessageBox.Show("Cliente eliminado",
                                         "Operacion exitosa",
                                         MessageBoxButtons.OK);

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Cliente no eliminado",
                                           "Error",
                                           MessageBoxButtons.OK);
                                break;
                            }
                        }
                    }
                    CargarClientes();
                }
            }
        }

        void CargarClientes()
        {
            if (Core.ListaClientes.Count > 0)
            {
                dgvClientes.DataSource = new List<Cliente>(Core.ListaClientes);
            }
        }

        private void Listado_Paint(object sender, PaintEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Listado_MouseClick(object sender, MouseEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }
    }
}
