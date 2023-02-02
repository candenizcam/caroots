using DefaultNamespace;
using Punity.animations;
using UnityEngine;
using UnityEngine.UIElements;

namespace Punity.ObjectScripts
{
    public class MainScript: MonoBehaviour
    {
        protected Camera MainCamera;
        protected UIDocument UIDocument;
        protected TweenHolder TweenHolder;
        public float WorldHeight => MainCamera.orthographicSize*2f;
        public float WorldWidth => MainCamera.orthographicSize*MainCamera.aspect*2f;
        
        private void Awake()
        {
            AdjustCamera();
            InitializeUi();
            TweenHolder = new TweenHolder();
            InitializeMain();
            
        }

        private void Update()
        {
            
            UpdateMain();
        }

        private void LateUpdate()
        {
            TweenHolder.Update(Time.deltaTime);
        }


        private void InitializeUi()
        {
            UIDocument = gameObject.GetComponent<UIDocument>();
            UIDocument.panelSettings.referenceResolution = new Vector2Int((int)Constants.UiWidth, (int)Constants.UiHeight);
            UIDocument.panelSettings.scaleMode = PanelScaleMode.ScaleWithScreenSize;
            UIDocument.panelSettings.match = 1f;
        }

        protected void AdjustCamera()
        {
            MainCamera = Camera.main;
            MainCamera.orthographicSize = Constants.WorldHeight;
        }

        protected virtual void InitializeMain(){} // this function must be overriden in the main instead of unity awake
        protected virtual void UpdateMain(){}
        
    }
    
    
   
    
}