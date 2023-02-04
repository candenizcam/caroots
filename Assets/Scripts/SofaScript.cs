using System.Collections.Generic;
using Punity.ObjectScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class SofaScript : GameWorldClass
    {
        public SpriteRenderer sofa;
        public List<SpriteRenderer> guests;
        
        public void ActivateVisual(int index)
        {
            for (var i = 0; i < guests.Count; i++)
            {
                guests[i].enabled = index == i;
            }
        }
    }
    
    
    
}