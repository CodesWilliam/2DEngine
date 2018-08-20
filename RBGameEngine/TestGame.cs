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

        protected override void Initialize()
        {
            base.Initialize();
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
            base.Render();
        }

        protected override void ShutDown()
        {
            base.ShutDown();
        }
    }
}
