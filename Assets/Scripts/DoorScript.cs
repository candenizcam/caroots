using Punity.ObjectScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class DoorScript: GameWorldClass
    {
        public SpriteRenderer leftDoor;
        public SpriteRenderer rightDoor;

        private const float StillPos = 1.4f;
        private const float OpenPos = 3.6f;



        public void OpenAnimation(float alpha)
        {
            leftDoor.transform.localPosition = new Vector3(-(1f-alpha)*StillPos  - alpha*OpenPos, 0f, 0f);
            rightDoor.transform.localPosition = new Vector3((1f-alpha)*StillPos  + alpha*OpenPos, 0f, 0f);
        }

    }
}