using System.Collections.Generic;
using Punity.ObjectScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class DoorScript: GameWorldClass
    {
        public SpriteRenderer leftDoor;
        public SpriteRenderer rightDoor;

        public List<SpriteRenderer> guests;
        
        private const float StillPos = 1.4f;
        private const float OpenPos = 3.6f;
        private int _activeVisual=0;



        public void OpenAnimation(float alpha)
        {
            leftDoor.transform.localPosition = new Vector3(-(1f-alpha)*StillPos  - alpha*OpenPos, 0f, 0f);
            rightDoor.transform.localPosition = new Vector3((1f-alpha)*StillPos  + alpha*OpenPos, 0f, 0f);
        }

        public void RevealAnimation(float alpha, bool here)
        {
            guests[_activeVisual].color = new Color(1f, 1f, 1f, here ? alpha : 0f);
        }
        
        public void ActivateVisual(int index)
        {
            for (var i = 0; i < guests.Count; i++)
            {
                guests[i].color = new Color(1f, 1f, 1f, 0f);
                guests[i].enabled = index == i;
            }

            _activeVisual = index;
        }

    }
}