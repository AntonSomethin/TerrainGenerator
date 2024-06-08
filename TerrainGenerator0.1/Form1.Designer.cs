namespace TerrainGenerator0._1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_BackToMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_LoadHeightMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SaveTerrain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_BackToMainMenu,
            this.toolStripMenuItem_LoadHeightMap,
            this.toolStripMenuItem_Reset,
            this.toolStripMenuItem_SaveTerrain});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_BackToMainMenu
            // 
            this.toolStripMenuItem_BackToMainMenu.Name = "toolStripMenuItem_BackToMainMenu";
            this.toolStripMenuItem_BackToMainMenu.Size = new System.Drawing.Size(122, 20);
            this.toolStripMenuItem_BackToMainMenu.Text = "Back to Main Menu";
            this.toolStripMenuItem_BackToMainMenu.Click += new System.EventHandler(this.toolStripMenuItem_BackToMainMenu_Click);
            // 
            // toolStripMenuItem_LoadHeightMap
            // 
            this.toolStripMenuItem_LoadHeightMap.Name = "toolStripMenuItem_LoadHeightMap";
            this.toolStripMenuItem_LoadHeightMap.Size = new System.Drawing.Size(109, 20);
            this.toolStripMenuItem_LoadHeightMap.Text = "Load height map";
            this.toolStripMenuItem_LoadHeightMap.Click += new System.EventHandler(this.toolStripMenuItem_LoadHeightMap_Click);
            // 
            // toolStripMenuItem_Reset
            // 
            this.toolStripMenuItem_Reset.Name = "toolStripMenuItem_Reset";
            this.toolStripMenuItem_Reset.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem_Reset.Text = "Reset";
            this.toolStripMenuItem_Reset.Click += new System.EventHandler(this.toolStripMenuItem_Reset_Click);
            // 
            // toolStripMenuItem_SaveTerrain
            // 
            this.toolStripMenuItem_SaveTerrain.Name = "toolStripMenuItem_SaveTerrain";
            this.toolStripMenuItem_SaveTerrain.Size = new System.Drawing.Size(81, 20);
            this.toolStripMenuItem_SaveTerrain.Text = "Save Terrain";
            this.toolStripMenuItem_SaveTerrain.Click += new System.EventHandler(this.toolStripMenuItem_SaveTerrain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terrain Generator";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_BackToMainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LoadHeightMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SaveTerrain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Reset;
    }
}

