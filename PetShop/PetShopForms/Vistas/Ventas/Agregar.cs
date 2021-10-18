using Entidades;
using Entidades.Enums;
using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopForms.Vistas.Ventas
{
    public partial class Agregar : Form
    {
        public VentaData ventaDataForm;
        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ventaDataForm = (VentaData)Inicio.AddFormToControl(pFullContainer.Controls, new VentaData());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Venta auxVenta;
            bool ventaOk;
            if (ventaDataForm.Unidades > 0)
            {
                try
                {
                    ventaOk = ((Empleado)Core.UsuarioLogueado).Vender(ventaDataForm.ProductoSeleccionado, ventaDataForm.ClienteSeleccionado,
                        ventaDataForm.Unidades, ventaDataForm.TipoEnvio, out auxVenta);
                    if (ventaOk)
                    {
                        Inicio.PlaySound(Inicio.SucessSoundPath);
                        MessageBox.Show("Venta guardada correctamente",
                                        "Operacion exitosa",
                                        MessageBoxButtons.OK);
                        Form form = new Ticket(auxVenta.Mostrar("PetShop S.A."));
                        DialogResult dialogRes = form.ShowDialog();
                        if (dialogRes != DialogResult.None)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar la venta",
                                          "Error",
                                          MessageBoxButtons.OK);
                    }
                }
                catch (ClienteSinDineroExcepcion ex)
                {
                    MessageBox.Show(ex.MensajeError,
                                      "Error",
                                      MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                      "Error",
                                      MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Ingrese una cantidad de unidades superior a 0",
                                      "Error",
                                      MessageBoxButtons.OK);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agregar_Paint(object sender, PaintEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Agregar_MouseClick(object sender, MouseEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }
    }
}
