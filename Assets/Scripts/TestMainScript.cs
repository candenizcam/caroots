using DefaultNamespace.GameData;
using Punity;
using Punity.ObjectScripts;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class TestMainScript : MainScript 
    {
        protected override void InitializeMain()
        {
            UIDocument.rootVisualElement.style.paddingBottom = Constants.UnsafeBottomUi;
            UIDocument.rootVisualElement.style.paddingTop = Constants.UnsafeTopUi;
            Application.targetFrameRate = 60;


            var n = new HeadPicker(DataBase.LevelRecordsArray[0],572f,960f);
            n.style.position = Position.Absolute;
            n.style.top = 0f;
            n.style.right = 0f;
            n.style.backgroundColor = new StyleColor(Color.blue);
            
            UIDocument.rootVisualElement.Add(n);
            UIDocument.rootVisualElement.style.backgroundColor = new StyleColor(Color.red);
        }

        protected override void UpdateMain()
        {
            
            
        }
        
    }
}