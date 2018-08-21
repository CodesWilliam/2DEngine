using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;

namespace RBGameEngine
{
    public class Vertex
    {

        public const int VertexSize = 2;
        private Vector2 position;

        //Properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vertex(Vector2 position)
        {
            this.position = position;
        }

        public Vertex(float x, float y) : this(new Vector2(x, y)) { }

        public static float[] Process(Vertex[] vertices)
        {
            float[] data = new float[vertices.Length * VertexSize];  //multiplying by 2 due to having 2 types in Vector2

            for(int i = 0; i < vertices.Length; i++)
            {
                data[i] = vertices[i].Position.X;
                data[i] = vertices[i].Position.Y;
            }

            return data;
        }
    }
}
