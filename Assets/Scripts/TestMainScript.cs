using DefaultNamespace.GameData;
using Punity;
using Punity.ObjectScripts;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class TestMainScript : MainScript
    {

        private TextBox _textBox;
        private HeadPicker _headPicker;
        
        protected override void InitializeMain()
        {
            UIDocument.rootVisualElement.style.paddingBottom = Constants.UnsafeBottomUi;
            UIDocument.rootVisualElement.style.paddingTop = Constants.UnsafeTopUi;
            Application.targetFrameRate = 60;


            var thisLevel = DataBase.LevelRecordsArray[0];
            _headPicker = new HeadPicker(thisLevel,572f,1029f)
            {
                style =
                {
                    position = Position.Absolute,
                    bottom = 0f,
                    right = 54f,
                    backgroundColor = new StyleColor(Color.gray)
                }
            };

            
            UIDocument.rootVisualElement.style.backgroundColor = new StyleColor(Color.red);


            _textBox = new TextBox(1214f, 264f)
            {
                style =
                {
                    bottom = 60f,
                    left = 138f,
                    position = Position.Absolute,
                    backgroundColor = new StyleColor(Color.magenta)
                }
            };
            _textBox.ChangeText(thisLevel.Clues[0]);
            
            UIDocument.rootVisualElement.Add(_textBox);
            UIDocument.rootVisualElement.Add(_headPicker);
        }

        protected override void UpdateMain()
        {
            
            
        }
        
    }
}