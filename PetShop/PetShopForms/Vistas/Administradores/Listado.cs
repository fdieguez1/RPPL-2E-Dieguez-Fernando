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

namespace PetShopForms.Vistas.Administradores
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Empleados.Agregar();
            DialogResult dialogRes = form.ShowDialog();
            if (dialogRes != DialogResult.None)
            {
                CargarEmpleados();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvAdmins.SelectedCells.Count > 0)
            {
                Form form = new Empleados.Editar((Administrador)dgvAdmins.CurrentRow.DataBoundItem);
                DialogResult dialogRes = form.ShowDialog();
                if (dialogRes != DialogResult.None)
                {
                    CargarEmpleados();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvAdmins.SelectedCells.Count > 0)
            {
                int selectedRowIndex = this.dgvAdmins.SelectedCells[0].RowIndex;
                int selectedId = (int)dgvAdmins.Rows[selectedRowIndex].Cells["Id"].Value;
                if (MessageBox.Show($"Seguro que desea eliminar el empleado de id: {selectedId}?",
                                         "Confirmacion",
                                         MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    foreach (Empleado emp in Core.ListaEmpleados)
                    {
                        if (emp.Id == selectedId)
                        {
                            if (Core.ListaEmpleados - emp)
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
                    CargarEmpleados();
                }
            }
        }

        void CargarEmpleados()
        {
            if (Core.ListaEmpleados.Count > 0)
            {
                dgvAdmins.DataSource = Core.ListarAdministradores();
            }
        }
    }
}
