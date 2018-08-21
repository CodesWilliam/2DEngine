using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;

namespace RBGameEngine
{
    public class Mesh2D
    {
        private int vboID;
        public int size;

        public Mesh2D(Vertex[] vertices)
        {
            vboID = GL.GenBuffer();
            size = vertices.Length;

            float[] data = Vertex.Process(vertices);

            //declars what type of buffer is to be used on vboID
            //in this case it is an ArrayBuffer type for the target of the buffer.
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);

            //Optimizing with OpenGL4
            //BufferUsageHint is telling OpenGL4 what type to expect
            //in this case it is a StaticDraw type.
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw);

            //unbinding
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Draw()
        {
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.VertexAttribPointer(0, Vertex.VertexSize, VertexAttribPointerType.Float, false, Vertex.VertexSize * 4, 0);

            GL.DrawArrays(PrimitiveType.Triangles, 0, size);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DisableVertexAttribArray(0);
        }
    }
}
