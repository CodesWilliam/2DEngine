using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace RBGameEngine
{
    public class RenderingSystem
    {
        //set defaults initial values for colors
        public static void Init(float red = 0.0f, float green = 0.0f, float blue = 0.0f, float alpha = 0.0f)
        {
            GL.ClearColor(red, green, blue, alpha);

            GL.CullFace(CullFaceMode.Back);
            GL.Enable(EnableCap.DepthTest);

            //Auto correct colors
            GL.Enable(EnableCap.FramebufferSrgb);
        }

        public static void SetClearColor(float red = 0.0f, float green = 0.0f, float blue = 0.0f, float alpha = 0.0f)
        {
            GL.ClearColor(red, green, blue, alpha);
        }

        //clears the screen
        public static void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        
    }
}
