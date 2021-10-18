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

namespace PetShopForms.Vistas.Empleados
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
            Form form = new Agregar();
            DialogResult dialogRes = form.ShowDialog();
            if (dialogRes != DialogResult.None)
            {
                CargarEmpleados();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvEmpleados.SelectedCells.Count > 0)
            {
                Form form = new Editar((Empleado)dgvEmpleados.CurrentRow.DataBoundItem);
                DialogResult dialogRes = form.ShowDialog();
                if (dialogRes != DialogResult.None)
                {
                    CargarEmpleados();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvEmpleados.SelectedCells.Count > 0)
            {
                int selectedRowIndex = this.dgvEmpleados.SelectedCells[0].RowIndex;
                int selectedId = (int)dgvEmpleados.Rows[selectedRowIndex].Cells["Id"].Value;
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
                dgvEmpleados.DataSource = Core.ListarEmpleados();
            }
        }

        private void Listado_Paint(object sender, PaintEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }
    }
}
