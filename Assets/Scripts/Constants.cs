using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace System.Runtime.CompilerServices
{
    public class IsExternalInit
    {

    }
}

namespace DefaultNamespace
{
    

    
    public static class Constants
    {
        public const bool DeployMode = true; // true before deploy 


        public static (float width, float height) WorldSizeCalculator(float aspectRate = 16f/9f)
        {
            var h = (float)Screen.width / (float)Screen.height;
            if (h > aspectRate) // width bigger
            {
                Debug.Log("width bigger");
                return (1080f * h, 1080f);
            }
            else // width smaller
            {
                Debug.Log("width smaller");
                return (1920f, 1920f/h);
            }


        }


        public static readonly (float width, float height) WorldSize = WorldSizeCalculator();
        
        //public const float WorldHeight = 1080f / 200f; // orthographic size for the camera
        public static readonly float WorldHeight = WorldSize.height / 200f; // orthographic size for the camera
         
        
        //public static float UiWidth => 1080f / (float)Screen.height* (float)Screen.width;
        //public const float UiHeight = 1080f;
        public static readonly float UiWidth = WorldSize.width; 
        public static readonly  float UiHeight = WorldSize.height;
        
        public static float UnsafeTopUi => (Screen.height - Screen.safeArea.yMax)/ Screen.height * Constants.UiHeight;
        public static float UnsafeBottomUi => Screen.safeArea.yMin/ Screen.height * Constants.UiHeight;
        public static float UnsafeLeftUi => Screen.safeArea.xMin/ Screen.width * Constants.UiWidth;
        public static float UnsafeRightUi => (Screen.width -  Screen.safeArea.xMax)/ Screen.width * Constants.UiWidth;

        public const float WorldPickDistance = 1f;
    }
}