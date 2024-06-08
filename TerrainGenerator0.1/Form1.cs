using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

// DirectX libraries
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace TerrainGenerator0._1
{
    public partial class Form1 : Form
    {
        private Device device = null;
        private VertexBuffer vb;
        private IndexBuffer ib = null;
        Camera camera = new Camera();

        private static int TerrainWidth = 1024;
        private static int TerrainLength = 1024;

        private static int VertCount = TerrainLength*TerrainWidth;
        private static int IndexCount = (TerrainWidth - 1) * (TerrainLength - 1) * 6;

        private static CustomVertex.PositionColored[] verts = null;
        private static int[] indices = null;

        private Bitmap heightmap = null;

        private static Form1 form1Instance;
        public Form1()
        {
            form1Instance = this;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
            InitializeComponent();

            InitializeGraphics();
            InitalizeEventHandler();
        }

        private void InitalizeEventHandler()
        {
            vb.Created += new EventHandler(OnVertexBufferCreate);
            ib.Created += new EventHandler(OnIndexBufferCreate);

            this.KeyDown += new KeyEventHandler(camera.OnKeyDown);
            this.KeyUp += new KeyEventHandler(camera.OnKeyUp);

            this.MouseDown += new MouseEventHandler(camera.OnMouseDown);
            this.MouseUp += new MouseEventHandler(camera.OnMouseUp);
            this.MouseMove += new MouseEventHandler(camera.OnMouseMove);
        }

        private void InitializeGraphics()
        {
            PresentParameters pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;

            pp.EnableAutoDepthStencil = true;
            pp.AutoDepthStencilFormat = DepthFormat.D16;

            device = new Device(0, DeviceType.Hardware, this, CreateFlags.HardwareVertexProcessing, pp);

            if (verts == null || indices == null)
            {
                GenerateVertex();
                GenerateIndex();
            }

            vb = new VertexBuffer(typeof(CustomVertex.PositionColored), VertCount, device, Usage.Dynamic | Usage.WriteOnly, CustomVertex.PositionColored.Format, Pool.Default);
            OnVertexBufferCreate(vb, null);

            ib = new IndexBuffer(typeof(int), IndexCount, device, Usage.WriteOnly, Pool.Default);
            OnIndexBufferCreate(ib, null);

            // initial camera position
            camera.CameraPosition = new Vector3(2, 4.5f, -3.5f);
            camera.CameraLookAt = new Vector3(2, 3.5f, -2.5f);
            camera.CameraUp = new Vector3(0, 1, 0);
        }

        private void OnIndexBufferCreate(object sender, EventArgs e)
        {
            IndexBuffer buffer = (IndexBuffer)sender;
            buffer.SetData(indices, 0, LockFlags.None);
        }

        private void OnVertexBufferCreate(object sender, EventArgs e)
        {
            VertexBuffer buffer = (VertexBuffer)sender;
            buffer.SetData(verts, 0, LockFlags.None);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1, 0);

            camera.SetupCamera(device, this.Width, this.Height);
            camera.Update();

            device.BeginScene();

            device.VertexFormat = CustomVertex.PositionColored.Format;
            device.SetStreamSource(0, vb, 0);
            device.Indices = ib;

            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, VertCount, 0, IndexCount/3);

            device.EndScene();

            device.Present();

            // Upper code will be invalidated (executed in loop)
            this.Invalidate();
        }

        private void GenerateVertex()
        {
            verts = new CustomVertex.PositionColored[VertCount];

            int k = 0;
            for (int z = 0; z < TerrainWidth; z++)
            {
                for (int x = 0; x < TerrainLength; x++)
                {
                    verts[k].Position = new Vector3(x, 0, z);
                    verts[k].Color = Color.White.ToArgb();
                    
                    k++;
                }
            }
        }

        private void GenerateIndex()
        {
            indices = new int[IndexCount];

            int k = 0;
            int l = 0;

            for (int i = 0; i < IndexCount; i += 6)
            {
                indices[i] = k;
                indices[i + 1] = k + TerrainLength;
                indices[i + 2] = k + TerrainLength + 1;
                indices[i + 3] = k;
                indices[i + 4] = k + TerrainLength + 1;
                indices[i + 5] = k + 1;

                k++;
                l++;
                if (l == TerrainLength - 1)
                {
                    l = 0;
                    k++;
                }
            }
        }

        private void LoadHeightmap()
        {
            verts = new CustomVertex.PositionColored[VertCount];

            int k = 0;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load Heightmap";
                ofd.Filter = "Bitmap files (*.bmp)|*.bmp";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    heightmap = new Bitmap(ofd.FileName);
                    Color pixelCol;

                    for (int z = 0; z < TerrainWidth; z++)
                    {
                        for (int x = 0; x < TerrainLength; x++)
                        {
                            if (heightmap.Size.Width > x && heightmap.Size.Height > z)
                            {
                                pixelCol = heightmap.GetPixel(x, z);                                
                                float result = (float)Math.Sqrt(pixelCol.R * pixelCol.R + pixelCol.G * pixelCol.G + pixelCol.B * pixelCol.B);
                                verts[k].Position = new Vector3(x, result / 4 - 100, z); 
                                verts[k].Color = pixelCol.ToArgb(); // Color.White.ToArgb();
                            }
                            else
                            {
                                verts[k].Position = new Vector3(x, 0, z);
                                verts[k].Color = Color.White.ToArgb();
                            }

                            k++;
                        }
                    }
                }
            }            
        }

        // Clicks

        private void toolStripMenuItem_BackToMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }

        private void toolStripMenuItem_LoadHeightMap_Click(object sender, EventArgs e)
        {
            LoadHeightmap();
            vb.SetData(verts, 0, LockFlags.None); 
        }

        private void toolStripMenuItem_SaveTerrain_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save Terrain Data";
                sfd.Filter = "Binary files (*.bin)|*.bin";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    SaveTerrainData(sfd.FileName);
                }
            }
        }

        private void toolStripMenuItem_Reset_Click(object sender, EventArgs e)
        {
            GenerateVertex();
            GenerateIndex();
            vb.SetData(verts, 0, LockFlags.None);
            ib.SetData(indices, 0, LockFlags.None);
        }


        // Save terrain
        private void SaveTerrainData(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(TerrainWidth);
                    writer.Write(TerrainLength);

                    writer.Write(VertCount);
                    for (int i = 0; i < VertCount; i++)
                    {
                        writer.Write(verts[i].Position.X);
                        writer.Write(verts[i].Position.Y);
                        writer.Write(verts[i].Position.Z);
                        writer.Write(verts[i].Color);
                    }

                    writer.Write(IndexCount);
                    for (int i = 0; i < IndexCount; i++)
                    {
                        writer.Write(indices[i]);
                    }
                }
            }
        }

        public static void SetTerrainData(int width, int length, CustomVertex.PositionColored[] vertexData, int[] indexData)
        {
            TerrainWidth = width;
            TerrainLength = length;
            verts = vertexData;
            indices = indexData;
            VertCount = vertexData.Length;
            IndexCount = indexData.Length;

            if (form1Instance != null)
            {
                form1Instance.InitializeGraphicsBuffers();
            }
        }

        public void InitializeGraphicsBuffers()
        {
            if (verts != null && indices != null)
            {
                vb.SetData(verts, 0, LockFlags.None);
                ib.SetData(indices, 0, LockFlags.None);
                this.Invalidate();
            }
        }
    }
}
