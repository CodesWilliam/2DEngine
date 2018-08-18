using OpenTK.Input;
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

        public static bool focused { get; set;}

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
        }

        public static bool GetKey(Key key)
        {   
            //Check if not focused Than nothing can be pressed
            if (!focused)
            {
                return false;
            }
            //Get if the key 'keyCode' is down
            return Keyboard.GetState().IsKeyDown((short)key);
        }

        public static bool GetKeyDown(Key key)
        {
            //Check if not focused than nothing can be pressed
            if (!focused)
            {
                return false;
            }
            //return weather our downKeys list contains the key 'keyCode' in a bool format
            return downKeys.Contains(key);
        }

        public static bool GetKeyUp(Key key)
        {
            //Check if not focused than nothing can be pressed
            if (!focused)
            {
                return false;
            }
            //return wether our upKeys list contians the key 'keyCode' in bool format.
            return upKeys.Contains(key);
        }
    }
}
