namespace AsignadorTareas
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsuarioLabel = new System.Windows.Forms.Label();
            this.IngresarBtn = new System.Windows.Forms.Button();
            this.UsuarioText = new System.Windows.Forms.TextBox();
            this.ContrasenaText = new System.Windows.Forms.TextBox();
            this.ContrasenaLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsuarioLabel
            // 
            this.UsuarioLabel.AutoSize = true;
            this.UsuarioLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioLabel.Location = new System.Drawing.Point(97, 83);
            this.UsuarioLabel.Name = "UsuarioLabel";
            this.UsuarioLabel.Size = new System.Drawing.Size(102, 29);
            this.UsuarioLabel.TabIndex = 0;
            this.UsuarioLabel.Text = "&Usuario";
            // 
            // IngresarBtn
            // 
            this.IngresarBtn.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IngresarBtn.Location = new System.Drawing.Point(197, 211);
            this.IngresarBtn.Name = "IngresarBtn";
            this.IngresarBtn.Size = new System.Drawing.Size(134, 41);
            this.IngresarBtn.TabIndex = 1;
            this.IngresarBtn.Text = "&Ingresar";
            this.IngresarBtn.UseVisualStyleBackColor = true;
            this.IngresarBtn.Click += new System.EventHandler(this.IngresarBtn_Click);
            // 
            // UsuarioText
            // 
            this.UsuarioText.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioText.Location = new System.Drawing.Point(252, 77);
            this.UsuarioText.Name = "UsuarioText";
            this.UsuarioText.Size = new System.Drawing.Size(194, 35);
            this.UsuarioText.TabIndex = 2;
            // 
            // ContrasenaText
            // 
            this.ContrasenaText.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrasenaText.Location = new System.Drawing.Point(252, 137);
            this.ContrasenaText.Name = "ContrasenaText";
            this.ContrasenaText.Size = new System.Drawing.Size(194, 35);
            this.ContrasenaText.TabIndex = 4;
            // 
            // ContrasenaLbl
            // 
            this.ContrasenaLbl.AutoSize = true;
            this.ContrasenaLbl.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrasenaLbl.Location = new System.Drawing.Point(97, 143);
            this.ContrasenaLbl.Name = "ContrasenaLbl";
            this.ContrasenaLbl.Size = new System.Drawing.Size(144, 29);
            this.ContrasenaLbl.TabIndex = 3;
            this.ContrasenaLbl.Text = "&Contraseña";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.IngresarBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 332);
            this.Controls.Add(this.ContrasenaText);
            this.Controls.Add(this.ContrasenaLbl);
            this.Controls.Add(this.UsuarioText);
            this.Controls.Add(this.IngresarBtn);
            this.Controls.Add(this.UsuarioLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UsuarioLabel;
        private System.Windows.Forms.Button IngresarBtn;
        private System.Windows.Forms.TextBox UsuarioText;
        private System.Windows.Forms.TextBox ContrasenaText;
        private System.Windows.Forms.Label ContrasenaLbl;
    }
}

