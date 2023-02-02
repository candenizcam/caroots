using System;
using Punity.tools;
using UnityEngine;

namespace Punity.ObjectScripts
{
    public class GameWorldClass: MonoBehaviour
    {
        protected Vector3 RecordedPositionVector;
        protected Vector3 RecordedScaleVector;


        public Vector3 RecorderPosition => RecordedPositionVector;
        public Vector3 RecordedScale => RecordedScaleVector;

        public void SetScale(float? x = null, float? y = null, float? z = null, bool updateRecord = true)
        {
            gameObject.transform.localScale = gameObject.transform.localScale.MutateVector(x,y,z);
            if (updateRecord)
            {
                RecordedScaleVector = gameObject.transform.localScale;
            }
        }
        
        public void SetPosition(float? x = null, float? y = null, float? z = null, bool updateRecord = true)
        {
            gameObject.transform.position = gameObject.transform.position.MutateVector(x,y,z);
            if (updateRecord)
            {
                RecordedPositionVector = gameObject.transform.position;
            }
        }

        public void SetRelativePosition(float? x = null, float? y = null, float? z = null, bool updateRecord = true)
        {
            gameObject.transform.localPosition = gameObject.transform.localPosition.MutateVector(x,y,z);
            if (updateRecord)
            {
                RecordedPositionVector = gameObject.transform.position;
            }
        }

        public void RestoreTransform(bool position = true, bool scale = true)
        {
            if (position)
            {
                gameObject.transform.position = RecordedPositionVector;
            }

            if (scale)
            {
                gameObject.transform.localScale = RecordedScaleVector;
            }
        }


        public float WorldDistance2D(Vector2 v)
        {
            return ((Vector2) gameObject.transform.position - v).magnitude;
        }

        
        private void Awake()
        {
            RecordedPositionVector = gameObject.transform.localScale;
            RecordedScaleVector = gameObject.transform.position;
            AwakeFunction();
        }

        private void Update()
        {
            UpdateFunction();
        }

        protected virtual void AwakeFunction(){}
        protected virtual void UpdateFunction(){}
        

        public static T Instantiate<T>(string name, Transform parent = null, Action<T> apply = null) where T : GameWorldClass, new()
        {
            var g = new GameObject(name);
            g.transform.parent = parent;
            var c = g.AddComponent<T>();
            apply?.Invoke(c);
            return c;
        }
        
    }
}