using DefaultNamespace.Punity;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestMainScript : MainScript 
    {
        protected override void InitializeMain()
        {
            UIDocument.rootVisualElement.style.paddingBottom = Constants.UnsafeBottomUi;
            UIDocument.rootVisualElement.style.paddingTop = Constants.UnsafeTopUi;
            Application.targetFrameRate = 60;
        }

        protected override void UpdateMain()
        {
            
            
        }
        
    }
}