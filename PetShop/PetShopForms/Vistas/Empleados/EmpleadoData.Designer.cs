
namespace PetShopForms.Vistas.Empleados
{
    partial class EmpleadoData
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pIsAdmin = new System.Windows.Forms.Panel();
            this.chkIsSuperAdmin = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBono = new System.Windows.Forms.TextBox();
            this.chkIsAdmin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pIsAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pIsAdmin);
            this.panel1.Controls.Add(this.chkIsAdmin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSueldo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 169);
            this.panel1.TabIndex = 1;
            // 
            // pIsAdmin
            // 
            this.pIsAdmin.Controls.Add(this.chkIsSuperAdmin);
            this.pIsAdmin.Controls.Add(this.label2);
            this.pIsAdmin.Controls.Add(this.txtBono);
            this.pIsAdmin.Location = new System.Drawing.Point(4, 86);
            this.pIsAdmin.Name = "pIsAdmin";
            this.pIsAdmin.Size = new System.Drawing.Size(273, 78);
            this.pIsAdmin.TabIndex = 8;
            // 
            // chkIsSuperAdmin
            // 
            this.chkIsSuperAdmin.AutoSize = true;
            this.chkIsSuperAdmin.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkIsSuperAdmin.Location = new System.Drawing.Point(0, 50);
            this.chkIsSuperAdmin.Name = "chkIsSuperAdmin";
            this.chkIsSuperAdmin.Size = new System.Drawing.Size(110, 18);
            this.chkIsSuperAdmin.TabIndex = 10;
            this.chkIsSuperAdmin.Text = "Es super admin";
            this.chkIsSuperAdmin.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bono";
            // 
            // txtBono
            // 
            this.txtBono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBono.Location = new System.Drawing.Point(0, 21);
            this.txtBono.Name = "txtBono";
            this.txtBono.Size = new System.Drawing.Size(273, 23);
            this.txtBono.TabIndex = 8;
            this.txtBono.TextChanged += new System.EventHandler(this.txtBono_TextChanged);
            // 
            // chkIsAdmin
            // 
            this.chkIsAdmin.AutoSize = true;
            this.chkIsAdmin.Location = new System.Drawing.Point(4, 60);
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Size = new System.Drawing.Size(114, 19);
            this.chkIsAdmin.TabIndex = 7;
            this.chkIsAdmin.Text = "Es administrador";
            this.chkIsAdmin.UseVisualStyleBackColor = true;
            this.chkIsAdmin.CheckedChanged += new System.EventHandler(this.chkIsAdmin_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sueldo";
            // 
            // txtSueldo
            // 
            this.txtSueldo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSueldo.Location = new System.Drawing.Point(4, 30);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Size = new System.Drawing.Size(273, 23);
            this.txtSueldo.TabIndex = 6;
            this.txtSueldo.TextChanged += new System.EventHandler(this.txtSueldo_TextChanged);
            // 
            // EmpleadoData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 176);
            this.Controls.Add(this.panel1);
            this.Name = "EmpleadoData";
            this.Text = "EmpleadoData";
            this.Load += new System.EventHandler(this.EmpleadoData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pIsAdmin.ResumeLayout(false);
            this.pIsAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.CheckBox chkIsAdmin;
        private System.Windows.Forms.Panel pIsAdmin;
        private System.Windows.Forms.CheckBox chkIsSuperAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBono;
    }
}