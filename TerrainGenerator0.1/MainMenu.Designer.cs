namespace TerrainGenerator0._1
{
    partial class MainMenu
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
        /// 
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Terrain = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateTerrain = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadTerrain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Terrain});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Terrain
            // 
            this.Terrain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerateTerrain,
            this.LoadTerrain});
            this.Terrain.Name = "Terrain";
            this.Terrain.Size = new System.Drawing.Size(54, 20);
            this.Terrain.Text = "Terrain";
            // 
            // GenerateTerrain
            // 
            this.GenerateTerrain.Name = "GenerateTerrain";
            this.GenerateTerrain.Size = new System.Drawing.Size(180, 22);
            this.GenerateTerrain.Text = "Generate Terrain";
            this.GenerateTerrain.Click += new System.EventHandler(this.GenerateTerrain_Click);
            // 
            // LoadTerrain
            // 
            this.LoadTerrain.Name = "LoadTerrain";
            this.LoadTerrain.Size = new System.Drawing.Size(180, 22);
            this.LoadTerrain.Text = "Load Terrain";
            this.LoadTerrain.Click += new System.EventHandler(this.LoadTerrain_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem Terrain;
        private System.Windows.Forms.ToolStripMenuItem GenerateTerrain;
        private System.Windows.Forms.ToolStripMenuItem LoadTerrain;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}