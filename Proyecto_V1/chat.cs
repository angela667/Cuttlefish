using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_V1
{
    public partial class chat : Form
    {
        public static chat instance;
        public TextBox text;
        public chat()
        {
            InitializeComponent();
            instance = this;
            text = textBox1;
          
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Interfaz.instance.enviarMensaje();
            textBox1.Clear();
        }
    }
    
}
