using OpenTK.Input;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBGameEngine
{
    public class Input
    {
        //key lists
        private static List<Key> currentKeys = new List<Key>();
        private static List<Key> downKeys = new List<Key>();
        private static List<Key> upKeys = new List<Key>();

        //Mouse List
        private static List<MouseButton> currentMouseButtons = new List<MouseButton>();
        private static List<MouseButton> downMouseButtons = new List<MouseButton>();
        private static List<MouseButton> upMouseButtons = new List<MouseButton>();

        internal static void Update()
        {
            downKeys.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(Key)).Length; i++){
                if(GetKey((Key)i)  && !currentKeys.Contains((Key)i))
                {
                    downKeys.Add((Key)i);
                }
            }

            upKeys.Clear();
            for (int j = 0; j < Enum.GetNames(typeof(Key)).Length; j++)
            {
                if (!GetKey((Key)j) && currentKeys.Contains((Key)j))
                {
                    upKeys.Add((Key)j);
                }
            }

            currentKeys.Clear();
            for(int k = 0; k < Enum.GetNames(typeof(Key)).Length; k++)
            {
                if (GetKey((Key)k))
                {
                    currentKeys.Add((Key)k);
                }
            }

            downMouseButtons.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(MouseButton)).Length; i++)
            {
                if (GetMouseButton((MouseButton)i) && !currentMouseButtons.Contains((MouseButton)i))
                {
                    downMouseButtons.Add((MouseButton)i);
                }
            }

            upMouseButtons.Clear();
            for (int j = 0; j < Enum.GetNames(typeof(MouseButton)).Length; j++)
            {
                if (!GetMouseButton((MouseButton)j) && currentMouseButtons.Contains((MouseButton)j))
                {
                    upMouseButtons.Add((MouseButton)j);
                }
            }

            currentMouseButtons.Clear();
            for (int k = 0; k < Enum.GetNames(typeof(MouseButton)).Length; k++)
            {
                if (GetMouseButton((MouseButton)k))
                {
                    currentMouseButtons.Add((MouseButton)k);
                }
            }
        }

        public static bool GetKey(Key keyCode)
        {   
            //Check if not focused Than nothing can be pressed
            if (!Game.Instance.Focused)
            {
                return false;
            }
            //Get if the key 'keyCode' is down
            return Keyboard.GetState().IsKeyDown((short)keyCode);
        }

        public static bool GetKeyDown(Key keyCode)
        {
            //Check if not focused than nothing can be pressed
            if (!Game.Instance.Focused)
            {
                return false;
            }
            //return weather our downKeys list contains the key 'keyCode' in a bool format
            return downKeys.Contains(keyCode);
        }

        public static bool GetKeyUp(Key keyCode)
        {
            //Check if not focused than nothing can be pressed
            if (!Game.Instance.Focused)
            {
                return false;
            }
            //return wether our upKeys list contians the key 'keyCode' in bool format.
            return upKeys.Contains(keyCode);
        }


        //these methods check for mouse button state
        public static bool GetMouseButton(MouseButton mouseButton)
        {
            if (!Game.Instance.Focused)
            {
                return false;
            }

            return Mouse.GetState().IsButtonDown(mouseButton);
        }

        public static bool GetMouseButtonDown(MouseButton mouseButton)
        {
            if (!Game.Instance.Focused)
            {
                return false;
            }

            return downMouseButtons.Contains(mouseButton);
        }

        public static bool GetMouseButtonUp(MouseButton mouseButton)
        {
            if (!Game.Instance.Focused)
            {
                return false;
            }

            return upMouseButtons.Contains(mouseButton);
        }

        public static Vector2 GetMousePosition()
        {
            //return the mouse position in the form of a Vector2
            return new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        //sets mouse position via Vector2
        public static void SetMousePosition(Vector2 position)
        {
            Mouse.SetPosition(position.X, position.Y);
        }

        public static void SetMousePositionFloat(float x, float y)
        {
            Mouse.SetPosition(x, y);
        }

        public static void ShowCursor(bool visiblitiy)
        {
            Game.Instance.CursorVisible = visiblitiy;
        }
    }
}
