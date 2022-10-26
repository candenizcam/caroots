using UnityEngine;

namespace Punity.ui
{
    public static class QuickAccess
    {
        public static Sprite LoadSprite(string path) 
        {
            return Resources.Load<Sprite>(path);
        }
        
    }
}