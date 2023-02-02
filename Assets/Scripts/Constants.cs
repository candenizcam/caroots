using UnityEngine.Device;

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
        
        
        public const float WorldHeight = 2532f / 200f; // orthographic size for the camera
         
        
        public static float UiWidth => 2532f / (float)Screen.height* (float)Screen.width;
        public const float UiHeight = 2532f;
        
        public static float UnsafeTopUi => (Screen.height - Screen.safeArea.yMax)/ Screen.height * Constants.UiHeight;
        public static float UnsafeBottomUi => Screen.safeArea.yMin/ Screen.height * Constants.UiHeight;
        public static float UnsafeLeftUi => Screen.safeArea.xMin/ Screen.width * Constants.UiWidth;
        public static float UnsafeRightUi => (Screen.width -  Screen.safeArea.xMax)/ Screen.width * Constants.UiWidth;

        public const float WorldPickDistance = 1f;
    }
}