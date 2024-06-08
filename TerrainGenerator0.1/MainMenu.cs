using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

// DirectX:
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace TerrainGenerator0._1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void GenerateTerrain_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void LoadTerrainData(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int terrainWidth = reader.ReadInt32();
                    int terrainLength = reader.ReadInt32();

                    int vertCount = reader.ReadInt32();
                    CustomVertex.PositionColored[] verts = new CustomVertex.PositionColored[vertCount];
                    for (int i = 0; i < vertCount; i++)
                    {
                        float x = reader.ReadSingle();
                        float y = reader.ReadSingle();
                        float z = reader.ReadSingle();
                        int color = reader.ReadInt32();
                        verts[i] = new CustomVertex.PositionColored(new Vector3(x, y, z), color);
                    }

                    int indexCount = reader.ReadInt32();
                    int[] indices = new int[indexCount];
                    for (int i = 0; i < indexCount; i++)
                    {
                        indices[i] = reader.ReadInt32();
                    }

                    Form1.SetTerrainData(terrainWidth, terrainLength, verts, indices);
                }
            }
        }

        private void LoadTerrain_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load Terrain Data";
                ofd.Filter = "Binary files (*.bin)|*.bin";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    LoadTerrainData(filePath);

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
            }
        }
    }
}
