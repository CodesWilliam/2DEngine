using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBGameEngine
{

    /*TestGame.cs
     * this is to test the methods and override anything that may need to be overridden for testing purposes.
     */
    class TestGame : Game
    {
        public TestGame(int width, int height, string title) : base(width, height, title) { }

        private Mesh2D mesh2D;

        protected override void Initialize()
        {
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(-1f, -1f),
                new Vertex(1f, -1f),
                new Vertex(0f, 1f),
            };

            mesh2D = new Mesh2D(vertices);
        }

        protected override void Update()
        {

            //testing the input system and changing colors via button press on the keyboard.
            if (Input.GetKeyDown(OpenTK.Input.Key.G))
            {
                RenderingSystem.SetClearColor(0, 1);  //sets to green
            }
            else if (Input.GetKeyDown(OpenTK.Input.Key.B))
            {
                RenderingSystem.SetClearColor(0, 0, 1);     //sets to blue
            }
            else if (Input.GetKeyDown(OpenTK.Input.Key.R))
            {
                RenderingSystem.SetClearColor(1);       //sets to red
            }
        }

        protected override void Render()
        {
            mesh2D.Draw();
        }

        protected override void ShutDown()
        {
            base.ShutDown();
        }
    }
}
