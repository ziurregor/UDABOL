using AsignadorTareas.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsignadorTareas
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void IngresarBtn_Click(object sender, EventArgs e)
        {
            String usuario = UsuarioText.Text;
            String contrasena = ContrasenaText.Text;
            JObject objeto = new JObject();
            objeto.Add("usuario", usuario);
            objeto.Add("contrasena", contrasena);
            objeto=Utilidades.ConsumirREST("login", "post",objeto);
            if (objeto != null) {
                
                if (objeto.ContainsKey("texto")) {
                    MessageBox.Show(objeto.Value<String>("texto"));
                }
                if (objeto.ContainsKey("llave"))
                {
                    String llave = objeto.Value<String>("llave");
                    if (llave != null)
                    {
                        Configuracion.SessionId = llave;
                    }
                }
            }

        }
    }
}
