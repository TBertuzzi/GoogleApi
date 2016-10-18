namespace KBITS.Google.API.Sample.Calendar
{
    partial class frmCalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendar));
            this.btnCalendar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListarcalendarios = new System.Windows.Forms.Button();
            this.btnListarEventos = new System.Windows.Forms.Button();
            this.btnInserriEvento = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCalendar
            // 
            this.btnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.Image = ((System.Drawing.Image)(resources.GetObject("btnCalendar.Image")));
            this.btnCalendar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCalendar.Location = new System.Drawing.Point(769, 21);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(72, 56);
            this.btnCalendar.TabIndex = 1;
            this.btnCalendar.Text = "Sobre";
            this.btnCalendar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCalendar.UseVisualStyleBackColor = true;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 375);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Para utilizar a API é necessario realizar alguns passos descritos pelo google :";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(66, 339);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(357, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://console.developers.google.com/start/api?id=calendar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(730, 306);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wizard: ";
            // 
            // btnListarcalendarios
            // 
            this.btnListarcalendarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarcalendarios.Image = ((System.Drawing.Image)(resources.GetObject("btnListarcalendarios.Image")));
            this.btnListarcalendarios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListarcalendarios.Location = new System.Drawing.Point(769, 93);
            this.btnListarcalendarios.Name = "btnListarcalendarios";
            this.btnListarcalendarios.Size = new System.Drawing.Size(72, 74);
            this.btnListarcalendarios.TabIndex = 3;
            this.btnListarcalendarios.Text = "Listar Calendarios";
            this.btnListarcalendarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListarcalendarios.UseVisualStyleBackColor = true;
            this.btnListarcalendarios.Click += new System.EventHandler(this.btnListarcalendarios_Click);
            // 
            // btnListarEventos
            // 
            this.btnListarEventos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarEventos.Image = ((System.Drawing.Image)(resources.GetObject("btnListarEventos.Image")));
            this.btnListarEventos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListarEventos.Location = new System.Drawing.Point(769, 183);
            this.btnListarEventos.Name = "btnListarEventos";
            this.btnListarEventos.Size = new System.Drawing.Size(72, 74);
            this.btnListarEventos.TabIndex = 4;
            this.btnListarEventos.Text = "Listar Eventos";
            this.btnListarEventos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListarEventos.UseVisualStyleBackColor = true;
            this.btnListarEventos.Click += new System.EventHandler(this.btnListarEventos_Click);
            // 
            // btnInserriEvento
            // 
            this.btnInserriEvento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInserriEvento.Image = ((System.Drawing.Image)(resources.GetObject("btnInserriEvento.Image")));
            this.btnInserriEvento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInserriEvento.Location = new System.Drawing.Point(769, 276);
            this.btnInserriEvento.Name = "btnInserriEvento";
            this.btnInserriEvento.Size = new System.Drawing.Size(72, 74);
            this.btnInserriEvento.TabIndex = 5;
            this.btnInserriEvento.Text = "Inserir Evento";
            this.btnInserriEvento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInserriEvento.UseVisualStyleBackColor = true;
            this.btnInserriEvento.Click += new System.EventHandler(this.btnInserriEvento_Click);
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 401);
            this.Controls.Add(this.btnInserriEvento);
            this.Controls.Add(this.btnListarEventos);
            this.Controls.Add(this.btnListarcalendarios);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KBits Google API Exemplos - Agenda";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnListarcalendarios;
        private System.Windows.Forms.Button btnListarEventos;
        private System.Windows.Forms.Button btnInserriEvento;
    }
}