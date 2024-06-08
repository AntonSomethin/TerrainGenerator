using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


// DirectX libraries
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace TerrainGenerator0._1
{
    public class Camera
    {
        private float MoveSpeed = 0.2f;
        private float TurnSpeed = 0.05f;
        private float RotationY = 0;
        private float RotationXZ = 0;

        private float TemporarY = 0;
        private float TemporarXZ = 0;

        private float NearPlane = 0.1f;
        private float FarPlane = 2000f;


        bool isRightMouseDown = false;

        public Vector3 CameraPosition;
        public Vector3 CameraLookAt;
        public Vector3 CameraUp;

        private List<Keys> pressedKeys = new List<Keys>();

        public Camera()
        {
            CameraPosition = new Vector3(2, 4.5f, -3.5f);
            CameraLookAt = new Vector3(2, 3.5f, -2.5f);
            CameraUp = new Vector3(0, 1, 0);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!pressedKeys.Contains(e.KeyCode))
            {
                pressedKeys.Add(e.KeyCode);
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (pressedKeys.Contains(e.KeyCode))
            {
                pressedKeys.Remove(e.KeyCode);
            }
        }

        public void Update()
        {
            foreach (Keys key in pressedKeys)
            {
                switch (key)
                {
                    case Keys.W:
                        CameraPosition.X += MoveSpeed * (float)Math.Sin(RotationY);
                        CameraPosition.Z += MoveSpeed * (float)Math.Cos(RotationY);
                        break;
                    case Keys.D:
                        CameraPosition.X += MoveSpeed * (float)Math.Sin(RotationY + Math.PI / 2);
                        CameraPosition.Z += MoveSpeed * (float)Math.Cos(RotationY + Math.PI / 2);
                        break;
                    case Keys.A:
                        CameraPosition.X += MoveSpeed * (float)Math.Sin(RotationY - Math.PI / 2);
                        CameraPosition.Z += MoveSpeed * (float)Math.Cos(RotationY - Math.PI / 2);
                        break;
                    case Keys.S:
                        CameraPosition.X -= MoveSpeed * (float)Math.Sin(RotationY);
                        CameraPosition.Z -= MoveSpeed * (float)Math.Cos(RotationY);
                        break;
                    case Keys.Space:
                        CameraPosition.Y += MoveSpeed;
                        break;
                    case Keys.ShiftKey:
                        CameraPosition.Y -= MoveSpeed;
                        break;
                    case Keys.Q:
                        RotationY -= TurnSpeed;
                        break;
                    case Keys.E:
                        RotationY += TurnSpeed;
                        break;
                    case Keys.Up:
                        if (RotationXZ < Math.PI / 2)
                        {
                            RotationXZ += TurnSpeed;
                        }
                        break;
                    case Keys.Down:
                        if (RotationXZ > -Math.PI / 2)
                        {
                            RotationXZ -= TurnSpeed;
                        }
                        break;
                    case Keys.PageUp:
                        if (FarPlane <= 4000f)
                        {
                           FarPlane += 10f;

                        }
                        break;
                    case Keys.PageDown:
                        if (FarPlane >= 100.0f)
                        {
                            FarPlane -= 10f;

                        }
                        break;
                }
            }
        }
        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        TemporarY = RotationY - e.X * TurnSpeed;
                        TemporarXZ = RotationXZ + e.Y * TurnSpeed / 4;
                        isRightMouseDown = true;
                        break;
                    }
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isRightMouseDown = false;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isRightMouseDown)
            {
                RotationY = TemporarY + e.X * TurnSpeed;

                float temp = TemporarXZ - e.Y * TurnSpeed / 4;
                if (temp < Math.PI / 2 && temp > -Math.PI / 2)
                {
                    RotationXZ = temp;
                }                
            }
        }

        public void SetupCamera(Device device, int width, int height)
        {
            CameraLookAt.X = (float) Math.Sin(RotationY) + CameraPosition.X + (float)(Math.Sin(RotationXZ) * Math.Sin(RotationY));
            CameraLookAt.Y = (float) Math.Sin(RotationXZ) + CameraPosition.Y - 1;
            CameraLookAt.Z = (float) Math.Cos(RotationY) + CameraPosition.Z + (float)(Math.Sin(RotationXZ) * Math.Cos(RotationY));

            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 3, (float)width / height, NearPlane, FarPlane);
            device.Transform.View = Matrix.LookAtLH(CameraPosition, CameraLookAt, CameraUp);

            device.RenderState.Lighting = false;
            device.RenderState.CullMode = Cull.CounterClockwise;
            device.RenderState.FillMode = FillMode.Solid;
        }
    }
}
