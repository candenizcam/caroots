using System.Collections.Generic;
using Punity.ObjectScripts;
using UnityEngine;

namespace DefaultNamespace
{
    
    public class BunScript : GameWorldClass
    {
        public SpriteRenderer baseVisual;
        //public SpriteRenderer talkie;
        public List<SpriteRenderer> talkLoop;
        private readonly float _talkTime = .5f;
        private float _talkCounter = -1f;


        public void GoTalk()
        {
            _talkCounter = _talkTime;
        }


        protected override void UpdateFunction()
        {
            if (_talkCounter > 0)
            {
                _talkCounter -= Time.deltaTime;
                var koyun = _talkCounter * 15f;


                if (_talkCounter <= 0)
                {
                    foreach (var spriteRenderer in talkLoop)
                    {
                        spriteRenderer.enabled = false;
                    }
                    baseVisual.enabled = true;
                    return;
                }
                
                int v = (int)koyun % talkLoop.Count ;
                for (var i = 0; i < talkLoop.Count; i++)
                {
                    talkLoop[i].enabled = i == v;
                }

            }
            else
            {
                baseVisual.enabled = true;
                _talkCounter = -1f;
            }
        }
    }
    
    
    
}