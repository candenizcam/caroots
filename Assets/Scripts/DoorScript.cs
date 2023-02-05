using System.Collections.Generic;
using System.Linq;
using Punity.ObjectScripts;
using Punity.tools;
using UnityEngine;

namespace DefaultNamespace
{
    public class DoorScript: GameWorldClass
    {
        public SpriteRenderer leftDoor;
        public SpriteRenderer rightDoor;

        public List<SpriteRenderer> guests;
        public List<SpriteRenderer> bulutlar;
        private List<Vector3> _directions = new List<Vector3>()
        {
            new Vector3(-1.5f,0f,.5f),
            new Vector3(-1f,0f,.5f),
            new Vector3(-.5f,0f,.5f),
            new Vector3(.5f,0f,.5f),
            new Vector3(1f,0f,.5f),
            new Vector3(1.5f,0f,.5f),
            
        };
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

        public void SetCloudVectors()
        {
            _directions = _directions.Shuffled().ToList();
        }

        public void CloudAnimation(float alpha)
        {
            for (var i = 0; i < bulutlar.Count; i++)
            {
                bulutlar[i].color = new Color(1f, 1f, 1f, 1f - alpha);
                bulutlar[i].transform.localPosition =
                    bulutlar[i].transform.localPosition.MutateVector(x: _directions[i].x * alpha);
            }
        
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