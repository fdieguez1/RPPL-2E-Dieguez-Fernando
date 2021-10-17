
namespace PetShopForms.Vistas.Ventas
{
    partial class VentaData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.lblClienteTitle = new System.Windows.Forms.Label();
            this.lblProdTitle = new System.Windows.Forms.Label();
            this.lblUnits = new System.Windows.Forms.Label();
            this.txtUnidades = new System.Windows.Forms.TextBox();
            this.btnRemoveUnit = new System.Windows.Forms.Button();
            this.btnAddUnit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 31);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowTemplate.Height = 25;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(491, 106);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // dgvClientes
            // 
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(12, 163);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowTemplate.Height = 25;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(491, 91);
            this.dgvClientes.TabIndex = 1;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // lblClienteTitle
            // 
            this.lblClienteTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClienteTitle.AutoSize = true;
            this.lblClienteTitle.Location = new System.Drawing.Point(12, 145);
            this.lblClienteTitle.Name = "lblClienteTitle";
            this.lblClienteTitle.Size = new System.Drawing.Size(44, 15);
            this.lblClienteTitle.TabIndex = 2;
            this.lblClienteTitle.Text = "Cliente";
            // 
            // lblProdTitle
            // 
            this.lblProdTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProdTitle.AutoSize = true;
            this.lblProdTitle.Location = new System.Drawing.Point(12, 13);
            this.lblProdTitle.Name = "lblProdTitle";
            this.lblProdTitle.Size = new System.Drawing.Size(56, 15);
            this.lblProdTitle.TabIndex = 3;
            this.lblProdTitle.Text = "Producto";
            // 
            // lblUnits
            // 
            this.lblUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(13, 264);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(56, 15);
            this.lblUnits.TabIndex = 4;
            this.lblUnits.Text = "Unidades";
            // 
            // txtUnidades
            // 
            this.txtUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUnidades.Location = new System.Drawing.Point(47, 282);
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Size = new System.Drawing.Size(100, 23);
            this.txtUnidades.TabIndex = 5;
            this.txtUnidades.Text = "0";
            this.txtUnidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnidades.TextChanged += new System.EventHandler(this.txtUnidades_TextChanged);
            // 
            // btnRemoveUnit
            // 
            this.btnRemoveUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveUnit.BackColor = System.Drawing.Color.SlateBlue;
            this.btnRemoveUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUnit.ForeColor = System.Drawing.Color.White;
            this.btnRemoveUnit.Location = new System.Drawing.Point(13, 282);
            this.btnRemoveUnit.Name = "btnRemoveUnit";
            this.btnRemoveUnit.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveUnit.TabIndex = 6;
            this.btnRemoveUnit.Text = "-";
            this.btnRemoveUnit.UseVisualStyleBackColor = false;
            this.btnRemoveUnit.Click += new System.EventHandler(this.btnRemoveUnit_Click);
            // 
            // btnAddUnit
            // 
            this.btnAddUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddUnit.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUnit.ForeColor = System.Drawing.Color.White;
            this.btnAddUnit.Location = new System.Drawing.Point(154, 282);
            this.btnAddUnit.Name = "btnAddUnit";
            this.btnAddUnit.Size = new System.Drawing.Size(27, 23);
            this.btnAddUnit.TabIndex = 7;
            this.btnAddUnit.Text = "+";
            this.btnAddUnit.UseVisualStyleBackColor = false;
            this.btnAddUnit.Click += new System.EventHandler(this.btnAddUnit_Click);
            // 
            // VentaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 317);
            this.Controls.Add(this.btnAddUnit);
            this.Controls.Add(this.btnRemoveUnit);
            this.Controls.Add(this.txtUnidades);
            this.Controls.Add(this.lblUnits);
            this.Controls.Add(this.lblProdTitle);
            this.Controls.Add(this.lblClienteTitle);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.dgvProductos);
            this.Name = "VentaData";
            this.Text = "VentaData";
            this.Load += new System.EventHandler(this.VentaData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblClienteTitle;
        private System.Windows.Forms.Label lblProdTitle;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TextBox txtUnidades;
        private System.Windows.Forms.Button btnRemoveUnit;
        private System.Windows.Forms.Button btnAddUnit;
    }
}