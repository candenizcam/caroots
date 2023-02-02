using System.Collections.Generic;
using UnityEngine;

namespace Punity.ObjectScripts
{
    public static class Extensions
    {
        
        public static void ReTransform(this GameObject mb, Vector3? generalPosition=null, Vector3? localPosition =null, Vector3? scale =null, Vector3? rotation = null)
        {
            var t = mb.transform;
            if (generalPosition is not null)
            {
                t.position = (Vector3)generalPosition;
            }else if (localPosition is not null)
            {
                t.localPosition = (Vector3)localPosition;
            }

            if (scale is not null)
            {
                t.localScale = (Vector3)scale;
            }

            if (rotation is not null)
            {
                var r = (Vector3) rotation;
                t.rotation = Quaternion.Euler(r.x,r.y,r.z);
            }
        }
        
        
        public static void ReTransform(this MonoBehaviour mb, Vector3? position=null, Vector3? localPosition =null, Vector3? scale =null, Vector3? rotation = null)
        {
            ReTransform(mb.gameObject,position,localPosition,scale,rotation);
        }


        public static void DestroyMembers<T>(this List<T> e) where T : GameWorldClass
        {
            foreach (var worldObject in e)
            {
                Object.Destroy(worldObject.gameObject);
            }
            e.Clear();
        }
        
    }
}