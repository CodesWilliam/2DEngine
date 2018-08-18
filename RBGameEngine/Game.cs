using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;

namespace RBGameEngine
{
    public abstract class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            Run();
        }

        protected override void OnLoad(EventArgs e)
        {
            Initialize();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Render();
        }

        protected override void OnClosed(EventArgs e)
        {
            ShutDown();
            Dispose();
        }

        //Virtual Methods Override the classes above to put our values into.
        protected virtual void Initialize()
        {

        }

        protected virtual void Update()
        {

        }

        protected virtual void Render()
        {

        }

        protected virtual void ShutDown()
        {

        }
    }
}
