namespace Proyecto_V1
{
    partial class Interfaz
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.holi = new System.Windows.Forms.Label();
            this.SELECT = new System.Windows.Forms.Button();
            this.NEXT = new System.Windows.Forms.Button();
            this.PREVIOUS = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LabelIntro = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CONNAMES = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miPersonaje = new System.Windows.Forms.PictureBox();
            this.personajeRival = new System.Windows.Forms.PictureBox();
            this.ENVIAR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textoChat = new System.Windows.Forms.TextBox();
            this.labelChat = new System.Windows.Forms.Label();
            this.NombreChat = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CONNAMES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miPersonaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personajeRival)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.LightSalmon;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.Location = new System.Drawing.Point(44, 277);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(278, 102);
            this.button1.TabIndex = 1;
            this.button1.Text = "LOG IN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.AutoSizeChanged += new System.EventHandler(this.Form1_Load);
            this.button1.FontChanged += new System.EventHandler(this.Form1_Load);
            this.button1.LocationChanged += new System.EventHandler(this.Form1_Load);
            this.button1.TextChanged += new System.EventHandler(this.Form1_Load);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.Move += new System.EventHandler(this.Form1_Load);
            this.button1.Resize += new System.EventHandler(this.Form1_Load);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Coral;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button2.Location = new System.Drawing.Point(44, 171);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(278, 96);
            this.button2.TabIndex = 2;
            this.button2.Text = "SIGN IN";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.FontChanged += new System.EventHandler(this.Form1_Load);
            this.button2.LocationChanged += new System.EventHandler(this.Form1_Load);
            this.button2.TextChanged += new System.EventHandler(this.Form1_Load);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // disconnect
            // 
            this.disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnect.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold);
            this.disconnect.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.disconnect.Location = new System.Drawing.Point(150, 27);
            this.disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(354, 96);
            this.disconnect.TabIndex = 3;
            this.disconnect.Text = "DESCONECTAR";
            this.disconnect.UseVisualStyleBackColor = false;
            this.disconnect.FontChanged += new System.EventHandler(this.Form1_Load);
            this.disconnect.LocationChanged += new System.EventHandler(this.Form1_Load);
            this.disconnect.TabStopChanged += new System.EventHandler(this.Form1_Load);
            this.disconnect.Click += new System.EventHandler(this.button3_Click);
            this.disconnect.Enter += new System.EventHandler(this.disconnect_Enter);
            this.disconnect.Leave += new System.EventHandler(this.disconnect_Leave);
            this.disconnect.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.disconnect.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // connect
            // 
            this.connect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.connect.AutoSize = true;
            this.connect.BackColor = System.Drawing.Color.Aquamarine;
            this.connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.connect.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.connect.Location = new System.Drawing.Point(150, 27);
            this.connect.Margin = new System.Windows.Forms.Padding(4);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(368, 102);
            this.connect.TabIndex = 4;
            this.connect.Text = "CONECTAR";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.button4_Click);
            // 
            // holi
            // 
            this.holi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.holi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.holi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holi.Location = new System.Drawing.Point(44, 27);
            this.holi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.holi.Name = "holi";
            this.holi.Size = new System.Drawing.Size(96, 96);
            this.holi.TabIndex = 14;
            // 
            // SELECT
            // 
            this.SELECT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SELECT.BackColor = System.Drawing.Color.Coral;
            this.SELECT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SELECT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SELECT.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.SELECT.ForeColor = System.Drawing.SystemColors.MenuText;
            this.SELECT.Location = new System.Drawing.Point(918, 667);
            this.SELECT.Margin = new System.Windows.Forms.Padding(4);
            this.SELECT.Name = "SELECT";
            this.SELECT.Size = new System.Drawing.Size(338, 88);
            this.SELECT.TabIndex = 17;
            this.SELECT.Text = "SELECT";
            this.SELECT.UseVisualStyleBackColor = false;
            this.SELECT.Click += new System.EventHandler(this.SELECT_Click);
            // 
            // NEXT
            // 
            this.NEXT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NEXT.BackColor = System.Drawing.Color.Coral;
            this.NEXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NEXT.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.NEXT.ForeColor = System.Drawing.SystemColors.MenuText;
            this.NEXT.Location = new System.Drawing.Point(1300, 667);
            this.NEXT.Margin = new System.Windows.Forms.Padding(4);
            this.NEXT.Name = "NEXT";
            this.NEXT.Size = new System.Drawing.Size(150, 88);
            this.NEXT.TabIndex = 18;
            this.NEXT.Text = "→";
            this.NEXT.UseVisualStyleBackColor = false;
            this.NEXT.Click += new System.EventHandler(this.NEXT_Click);
            // 
            // PREVIOUS
            // 
            this.PREVIOUS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PREVIOUS.BackColor = System.Drawing.Color.Coral;
            this.PREVIOUS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PREVIOUS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PREVIOUS.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.PREVIOUS.ForeColor = System.Drawing.SystemColors.MenuText;
            this.PREVIOUS.Location = new System.Drawing.Point(736, 667);
            this.PREVIOUS.Margin = new System.Windows.Forms.Padding(4);
            this.PREVIOUS.Name = "PREVIOUS";
            this.PREVIOUS.Size = new System.Drawing.Size(150, 88);
            this.PREVIOUS.TabIndex = 19;
            this.PREVIOUS.Text = "←";
            this.PREVIOUS.UseVisualStyleBackColor = false;
            this.PREVIOUS.Click += new System.EventHandler(this.PREVIOUS_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(736, 171);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(714, 446);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // LabelIntro
            // 
            this.LabelIntro.AutoSize = true;
            this.LabelIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelIntro.Location = new System.Drawing.Point(726, 104);
            this.LabelIntro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelIntro.Name = "LabelIntro";
            this.LabelIntro.Size = new System.Drawing.Size(718, 61);
            this.LabelIntro.TabIndex = 30;
            this.LabelIntro.Text = "ESCOGE A TU PERSONAJE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2056, 1171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CONNAMES
            // 
            this.CONNAMES.AllowUserToDeleteRows = false;
            this.CONNAMES.ColumnHeadersHeight = 29;
            this.CONNAMES.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.CONNAMES.Location = new System.Drawing.Point(44, 502);
            this.CONNAMES.Margin = new System.Windows.Forms.Padding(4);
            this.CONNAMES.Name = "CONNAMES";
            this.CONNAMES.ReadOnly = true;
            this.CONNAMES.RowHeadersWidth = 51;
            this.CONNAMES.Size = new System.Drawing.Size(448, 496);
            this.CONNAMES.TabIndex = 34;
            this.CONNAMES.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CONNAMES_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // miPersonaje
            // 
            this.miPersonaje.Location = new System.Drawing.Point(150, 1350);
            this.miPersonaje.Margin = new System.Windows.Forms.Padding(4);
            this.miPersonaje.Name = "miPersonaje";
            this.miPersonaje.Size = new System.Drawing.Size(260, 187);
            this.miPersonaje.TabIndex = 35;
            this.miPersonaje.TabStop = false;
            // 
            // personajeRival
            // 
            this.personajeRival.Location = new System.Drawing.Point(2468, 1350);
            this.personajeRival.Margin = new System.Windows.Forms.Padding(4);
            this.personajeRival.Name = "personajeRival";
            this.personajeRival.Size = new System.Drawing.Size(260, 187);
            this.personajeRival.TabIndex = 36;
            this.personajeRival.TabStop = false;
            // 
            // ENVIAR
            // 
            this.ENVIAR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ENVIAR.BackColor = System.Drawing.Color.Coral;
            this.ENVIAR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ENVIAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENVIAR.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.ENVIAR.ForeColor = System.Drawing.SystemColors.MenuText;
            this.ENVIAR.Location = new System.Drawing.Point(44, 1052);
            this.ENVIAR.Margin = new System.Windows.Forms.Padding(4);
            this.ENVIAR.Name = "ENVIAR";
            this.ENVIAR.Size = new System.Drawing.Size(338, 88);
            this.ENVIAR.TabIndex = 37;
            this.ENVIAR.Text = "ENVIAR";
            this.ENVIAR.UseVisualStyleBackColor = false;
            this.ENVIAR.Click += new System.EventHandler(this.ENVIAR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 421);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 61);
            this.label1.TabIndex = 38;
            this.label1.Text = "ONLINE USERS";
            // 
            // textoChat
            // 
            this.textoChat.Location = new System.Drawing.Point(1762, 650);
            this.textoChat.Margin = new System.Windows.Forms.Padding(6);
            this.textoChat.Name = "textoChat";
            this.textoChat.Size = new System.Drawing.Size(196, 31);
            this.textoChat.TabIndex = 39;
            this.textoChat.TextChanged += new System.EventHandler(this.textoChat_TextChanged);
            this.textoChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textoChat_KeyPress);
            // 
            // labelChat
            // 
            this.labelChat.AutoSize = true;
            this.labelChat.Location = new System.Drawing.Point(1757, 381);
            this.labelChat.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChat.Name = "labelChat";
            this.labelChat.Size = new System.Drawing.Size(103, 25);
            this.labelChat.TabIndex = 40;
            this.labelChat.Text = "labelChat";
            this.labelChat.Click += new System.EventHandler(this.label2_Click);
            // 
            // NombreChat
            // 
            this.NombreChat.Location = new System.Drawing.Point(1520, 650);
            this.NombreChat.Margin = new System.Windows.Forms.Padding(6);
            this.NombreChat.Name = "NombreChat";
            this.NombreChat.Size = new System.Drawing.Size(196, 31);
            this.NombreChat.TabIndex = 41;
            this.NombreChat.TextChanged += new System.EventHandler(this.NombreChat_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(315, 242);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(391, 323);
            this.pictureBox3.TabIndex = 42;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(814, 242);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(391, 323);
            this.pictureBox4.TabIndex = 43;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(1325, 242);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(391, 323);
            this.pictureBox5.TabIndex = 44;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // Interfaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2056, 1171);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.NombreChat);
            this.Controls.Add(this.labelChat);
            this.Controls.Add(this.textoChat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ENVIAR);
            this.Controls.Add(this.personajeRival);
            this.Controls.Add(this.miPersonaje);
            this.Controls.Add(this.CONNAMES);
            this.Controls.Add(this.LabelIntro);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.PREVIOUS);
            this.Controls.Add(this.NEXT);
            this.Controls.Add(this.SELECT);
            this.Controls.Add(this.holi);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Interfaz";
            this.Text = "Interfaz";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CONNAMES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miPersonaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personajeRival)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label holi;
        private System.Windows.Forms.Button SELECT;
        private System.Windows.Forms.Button NEXT;
        private System.Windows.Forms.Button PREVIOUS;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LabelIntro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView CONNAMES;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.PictureBox miPersonaje;
        private System.Windows.Forms.PictureBox personajeRival;
        private System.Windows.Forms.Button ENVIAR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textoChat;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.TextBox NombreChat;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

