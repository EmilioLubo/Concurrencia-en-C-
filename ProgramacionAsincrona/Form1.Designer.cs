namespace ProgramacionAsincrona
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button = new System.Windows.Forms.Button();
            this.loadingGif = new System.Windows.Forms.PictureBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.pgProcesamiento = new System.Windows.Forms.ProgressBar();
            this.btnCcl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(297, 83);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(186, 43);
            this.button.TabIndex = 0;
            this.button.Text = "Press";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadingGif
            // 
            this.loadingGif.Enabled = false;
            this.loadingGif.Image = ((System.Drawing.Image)(resources.GetObject("loadingGif.Image")));
            this.loadingGif.Location = new System.Drawing.Point(327, 175);
            this.loadingGif.Name = "loadingGif";
            this.loadingGif.Size = new System.Drawing.Size(129, 102);
            this.loadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingGif.TabIndex = 1;
            this.loadingGif.TabStop = false;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(383, 35);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 2;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.Location = new System.Drawing.Point(294, 35);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(66, 18);
            this.Nombre.TabIndex = 3;
            this.Nombre.Text = "Nombre:";
            // 
            // pgProcesamiento
            // 
            this.pgProcesamiento.Location = new System.Drawing.Point(23, 35);
            this.pgProcesamiento.Name = "pgProcesamiento";
            this.pgProcesamiento.Size = new System.Drawing.Size(221, 30);
            this.pgProcesamiento.TabIndex = 4;
            // 
            // btnCcl
            // 
            this.btnCcl.Location = new System.Drawing.Point(93, 93);
            this.btnCcl.Name = "btnCcl";
            this.btnCcl.Size = new System.Drawing.Size(75, 23);
            this.btnCcl.TabIndex = 5;
            this.btnCcl.Text = "Cancelar";
            this.btnCcl.UseVisualStyleBackColor = true;
            this.btnCcl.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCcl);
            this.Controls.Add(this.pgProcesamiento);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.loadingGif);
            this.Controls.Add(this.button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.PictureBox loadingGif;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.ProgressBar pgProcesamiento;
        private System.Windows.Forms.Button btnCcl;
    }
}

