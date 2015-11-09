﻿namespace MusicInventoryManagement
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstInventory = new System.Windows.Forms.ListView();
            this.colArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlbum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGenre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pctAlbumArt = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(129, 22);
            this.txtArtist.Margin = new System.Windows.Forms.Padding(4);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(256, 31);
            this.txtArtist.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Artist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Album";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 4;
            // 
            // txtAlbum
            // 
            this.txtAlbum.Location = new System.Drawing.Point(129, 77);
            this.txtAlbum.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(256, 31);
            this.txtAlbum.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(44, 134);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(143, 62);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstInventory
            // 
            this.lstInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colArtist,
            this.colAlbum,
            this.colGenre,
            this.colDate});
            this.lstInventory.FullRowSelect = true;
            this.lstInventory.Location = new System.Drawing.Point(576, 22);
            this.lstInventory.Margin = new System.Windows.Forms.Padding(4);
            this.lstInventory.MultiSelect = false;
            this.lstInventory.Name = "lstInventory";
            this.lstInventory.Size = new System.Drawing.Size(741, 781);
            this.lstInventory.TabIndex = 9;
            this.lstInventory.UseCompatibleStateImageBehavior = false;
            this.lstInventory.View = System.Windows.Forms.View.Details;
            this.lstInventory.SelectedIndexChanged += new System.EventHandler(this.lstInventory_SelectedIndexChanged);
            // 
            // colArtist
            // 
            this.colArtist.Text = "Artist";
            this.colArtist.Width = 100;
            // 
            // colAlbum
            // 
            this.colAlbum.Text = "Album";
            this.colAlbum.Width = 100;
            // 
            // colGenre
            // 
            this.colGenre.Text = "Genre";
            this.colGenre.Width = 100;
            // 
            // colDate
            // 
            this.colDate.Text = "Date Added";
            this.colDate.Width = 89;
            // 
            // pctAlbumArt
            // 
            this.pctAlbumArt.Location = new System.Drawing.Point(44, 335);
            this.pctAlbumArt.Margin = new System.Windows.Forms.Padding(4);
            this.pctAlbumArt.Name = "pctAlbumArt";
            this.pctAlbumArt.Size = new System.Drawing.Size(467, 435);
            this.pctAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctAlbumArt.TabIndex = 10;
            this.pctAlbumArt.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1361, 823);
            this.Controls.Add(this.pctAlbumArt);
            this.Controls.Add(this.lstInventory);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAlbum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArtist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Songster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Enter += new System.EventHandler(this.btnAdd_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pctAlbumArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lstInventory;
        private System.Windows.Forms.ColumnHeader colArtist;
        private System.Windows.Forms.ColumnHeader colAlbum;
        private System.Windows.Forms.ColumnHeader colGenre;
        private System.Windows.Forms.PictureBox pctAlbumArt;
        private System.Windows.Forms.ColumnHeader colDate;
    }
}

