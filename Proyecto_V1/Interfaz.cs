using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_V1
{
    public partial class Interfaz : Form
    {
        Socket server;
        Thread atender;
        List<String> anadir_partida = new List<String>();
        public string mensaje_invitados;
        bool connected = false;
        bool registrado = false;
        bool lobby = true;
        int contador = 0;
        public string username;
        string nombre_invitado;
        int mi_movimiento = 0;
        int ganador = 2;



        //VALORS IMPORTANTS PER A CONNEXIO
        //              LOCAL
        //         "192.168.56.102"

        //             GRIGORY 
        //          "10.211.55.5"

        //              SHIVA
        //          "10.4.119.5"
        //              50085


        //DEFINIM UNA RUTA IP I PORT
        string IPadd = "10.211.55.5";
        int puerto = 5065;



        Image[] images = new Image[]
        {
            Image.FromFile("goku.png"),
            Image.FromFile("Frieza.png"),
            Image.FromFile("vegeta.png")
        };

        delegate void DelegadoParaPonerTexto(string texto);

        List<LogIn> formularios = new List<LogIn>();
        List<SignIn> formularios3 = new List<SignIn>();
        public Interfaz()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //miPersonaje.Focus();
            //this.Focus();

        }
        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje;
                string[] verify;

                switch (codigo)
                {
                    case 1:  // SIGN IN

                        mensaje = trozos[1].Split('\0')[0];
                        verify = mensaje.Split(' ');
                        if (verify[0] == "Usuario")
                        {
                            username = verify[1];
                            registrado = true;
                        }
                        MessageBox.Show(mensaje);

                        break;

                    case 2:  //LOG IN

                        mensaje = trozos[1].Split('\0')[0];
                        if (trozos[1].Split(' ')[0] == "Sesion")
                        {
                            username = trozos[2];
                            registrado = true;

                        }
                        MessageBox.Show(mensaje);
                        break;

                    case 3: //HISTORIAL
                        //FALTA PER FER, COM HO PASSEM A UN ALTRE FORM?
                        //HO FEM A LA MATEIXA INTERFAÇ COM LA LLISTA DE CONNECTATS??
                        break;

                    case 4:      // LLISTA DE CONNECTATS
                        int rowcount = Convert.ToInt32(trozos[1]);
                        CONNAMES.RowCount = rowcount;
                        CONNAMES.ColumnCount = 1;
                        DataGridViewColumn column = CONNAMES.Columns["Conectados"];
                        int count = 0;
                        while( count < rowcount-1)
                        {           
                            CONNAMES.Rows[count].Cells[0].Value = trozos[count+2];
                            count++;
                        }
                        CONNAMES.Rows[count].Cells[0].Value = trozos[count+2].Split('\0')[0];
                        break;

                    case 5: //INVITAR A OTRO USUARIO

                        var result = MessageBox.Show("Quieres jugar con:" + trozos[1], "ACEPTAR", MessageBoxButtons.YesNo);
                        Invoke(new Action(() =>
                        {
                            if (result == DialogResult.Yes)
                            {      
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes("6/" + trozos[1] + "/" + trozos[2] + "/YES");
                                server.Send(msg);

                            }
                            if (result == DialogResult.No)
                            {
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes("6/" + trozos[1] + "/" + trozos[2] + "/NO");
                                server.Send(msg);
                            }
                        }));
                        break;

                    case 6: //RESPUESTA A LA INVITACIÓN

                        if (trozos[1] == "YES")
                        {

                            MessageBox.Show("Ha aceptado la invitación");

                            break;
                        }
                        else
                        {
                            MessageBox.Show("No ha aceptado la invitación");
                        }
                        break;

                    case 7://MENSAJE CHAT
                        mensaje = trozos[1].Split('\0')[0];

                        string usuario = trozos[2];
                        string texto= ">>" + usuario + "-" + mensaje + "\n";
                        labelChat.Text = texto;

                        break;

                    case 8: //MOVIMIENTO DEL RIVAL
                        int movimineto = Convert.ToInt32(trozos[1]);
                        switch (codigo)
                        {
                            case 1: //PIEDRA RIVAL
                                if(mi_movimiento == 1) //MI PIEDRA
                                {
                                    ganador = 0;
                                    Resultado();
                                }
                                else if(mi_movimiento == 2) //MI PAPEL
                                {
                                    ganador = 1;
                                    Resultado();
                                }
                                else // MI TIJERA
                                {
                                    ganador = -1;
                                    Resultado();
                                }
                            break;

                            case 2: //PAPEL RIVAL
                                if (mi_movimiento == 1) //MI PIEDRA
                                {
                                    ganador = -1;
                                    Resultado();
                                }
                                else if (mi_movimiento == 2) //MI PAPEL
                                {
                                    ganador = 0;
                                    Resultado();
                                }
                                else // MI TIJERA
                                {
                                    ganador = 1;
                                    Resultado();
                                }
                                break;

                            case 3: //TIJERA RIVAL
                                if (mi_movimiento == 1) //MI PIEDRA
                                {
                                    ganador = 1;
                                    Resultado();
                                }
                                else if (mi_movimiento == 2) //MI PAPEL
                                {
                                    ganador = -1;
                                    Resultado();
                                }
                                else // MI TIJERA
                                {
                                    ganador = 0;
                                    Resultado();
                                }
                                break;
                        }
                        break;

                }
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
            Image image = Image.FromFile("FONDO.png");
            pictureBox1.Image = image;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            SELECT.Visible = false;
            NEXT.Visible = false;
            PREVIOUS.Visible = false;
            ENVIAR.Visible = false;
            pictureBox2.Visible = false;
            LabelIntro.Visible = false; 
            miPersonaje.Visible = false;
            personajeRival.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            disconnect.Visible = false;
            if(registrado == true)
            {
                SELECT.Visible = true;
                NEXT.Visible = true;
                PREVIOUS.Visible = true;
                ENVIAR.Visible = true;
                pictureBox2.Visible = true;
                LabelIntro.Visible = true;
                labelChat.Visible = true;
                NombreChat.Visible = true;
                textoChat.Visible = true;

                pictureBox1.Image = Image.FromFile("FONDO4.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = this.images[this.contador];
            }
            if (lobby == false)
            {
                SELECT.Visible = false;
                NEXT.Visible = false;
                PREVIOUS.Visible = false;
                LabelIntro.Visible = false;
                pictureBox2.Visible = false;


                miPersonaje.Visible = true;
                miPersonaje.BackColor = Color.Red;
                personajeRival.Visible = true;
                personajeRival.BackColor = Color.Blue;

                pictureBox1.Image = Image.FromFile("FONDO4.png");

                miPersonaje.SizeMode = PictureBoxSizeMode.Zoom;
                personajeRival.SizeMode = PictureBoxSizeMode.Zoom;
                miPersonaje.Image = this.images[this.contador];
                if (this.contador >= this.images.Length)
                {
                    this.contador = 0;
                }
            }
            
            if (connected == true)
            {
                connect.Visible = false;
                disconnect.Visible = true;
                holi.BackColor = Color.Green;
            }

            if (connected == false)
            {
                disconnect.Visible = false;
                connect.Visible = true;
                holi.BackColor = Color.Red;
            }

        }

        //BOTON1
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate { PonerEnMarchaFormulario(); };
            Thread T = new Thread(ts);
            T.Start();
    }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Size = new Size((int)(button1.Width * 1.2f), (int)(button1.Height * 1.2f));
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new Size((int)(button1.Width / 1.2f), (int)(button1.Height / 1.2f));
        }


        //BOTON2
        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate { PonerEnMarchaFormulario2(); };
            Thread T = new Thread(ts);
            T.Start();
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Size = new Size((int)(button1.Width * 1.2f), (int)(button1.Height * 1.2f));
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Size = new Size((int)(button1.Width / 1.2f), (int)(button1.Height / 1.2f));
        }


        //DESCONECTAR
        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            MessageBox.Show("User disconnected successfully.");
            connected = false;
            if (connected == false)
            {
                disconnect.Visible = false;
                connect.Visible = true;
            }
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            disconnect.Size = new Size((int)(button1.Width * 1.2f), (int)(button1.Height * 1.2f));
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            disconnect.Size = new Size((int)(button1.Width / 1.2f), (int)(button1.Height / 1.2f));
        }

        //CONECTAR CON EL SERVIDOR
        private void button4_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(IPadd);
            IPEndPoint ipep = new IPEndPoint(direc, puerto);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                MessageBox.Show("User connected successfully.");
                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
                connected = true;

                if (connected == true)
                {
                    connect.Visible = false;
                    disconnect.Visible = true;
                    holi.BackColor = Color.Green;
                }

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            

        }

        private void PonerEnMarchaFormulario()
        {
            int cont = formularios.Count;
            LogIn f = new LogIn(cont, server);
            formularios.Add(f);
            f.ShowDialog();
        }
        private void PonerEnMarchaFormulario2()
        {
            int cont = formularios3.Count;
            SignIn f3 = new SignIn(cont, server);
            formularios3.Add(f3);
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form historial = new Historial(server, username);
            historial.Show();

        }

        private void NEXT_Click(object sender, EventArgs e)
        {
            this.contador++;

            if (this.contador >= this.images.Length)
            {
                this.contador = 0;
            }

            this.pictureBox2.Image = this.images[this.contador];
        }

        private void PREVIOUS_Click(object sender, EventArgs e)
        {
            this.contador--;

            if (this.contador < 0)
            {
                this.contador = this.images.Length - 1;
            }

            this.pictureBox2.Image = this.images[this.contador];
        }

        private void disconnect_Enter(object sender, EventArgs e)
        {
            disconnect.Size = new Size((int)(disconnect.Width * 1.2f), (int)(disconnect.Height * 1.2f));
        }

        private void disconnect_Leave(object sender, EventArgs e)
        {
            disconnect.Size = new Size((int)(disconnect.Width / 1.2f), (int)(disconnect.Height / 1.2f));
        }

        private void SELECT_Click(object sender, EventArgs e)
        {
            lobby = false;
            SELECT.Visible = false;
            NEXT.Visible = false;
            PREVIOUS.Visible = false;
            LabelIntro.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox3.Image = Image.FromFile("PIEDRA.png");
            pictureBox4.Visible = true;
            pictureBox4.Image = Image.FromFile("PAPEL.png");
            pictureBox5.Visible = true;
            pictureBox5.Image = Image.FromFile("TIJERA.png");


            miPersonaje.Visible = true;
            miPersonaje.BackColor = Color.Red;
            personajeRival.Visible = true;
            personajeRival.BackColor = Color.Blue;

            pictureBox1.Image = Image.FromFile("FONDO4.png");
            
            miPersonaje.SizeMode = PictureBoxSizeMode.Zoom;
            personajeRival.SizeMode = PictureBoxSizeMode.Zoom;
            miPersonaje.Image = this.images[this.contador];
            if (this.contador >= this.images.Length)
            {
                this.contador = 0;
            }
            //personajeRival.Image = this.images[this.contador+1];

        }

        public void Resultado()
        {
            if(ganador == -1) // He perdido
            {
                MessageBox.Show("HAS PERDIDO");
            }
            else if (ganador == 0) // Hemos empatado
            {
                MessageBox.Show("HABEIS EMPATADO");
            }
            else if (ganador == 1)// He ganado
            {
                MessageBox.Show("HAS GANADO");
            }
            ganador = 2;
            mi_movimiento = 0;
        }

        private void ENVIAR_Click(object sender, EventArgs e)
        {

            string mensaje = "5/" + username + "/" + nombre_invitado;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }


        private void CONNAMES_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.CONNAMES.Rows[e.RowIndex];
                nombre_invitado = row.Cells[0].Value.ToString();
                MessageBox.Show("The selected name is: " + nombre_invitado);

                string amigo = nombre_invitado;

                string mensaje = "5/" + username + "/" + amigo;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
                
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textoChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string texto = textoChat.Text;
                string chatNombre = NombreChat.Text;
                if (texto != "")
                {
                    string mensajeChat = texto;

                    string name = chatNombre;

                    textoChat.Text = "";
                    NombreChat.Text = "";
                    string mensaje = "7/" + mensajeChat + "/" + name;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)//PIEDRA
        {
            string mensaje = "8/1";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            mi_movimiento = 1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)//PAPEL
        {
            string mensaje = "8/2";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            mi_movimiento = 2;
        }

        private void pictureBox5_Click(object sender, EventArgs e)//TIJERA
        {
            string mensaje = "8/3";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            mi_movimiento = 3;
        }

        private void textoChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void NombreChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
