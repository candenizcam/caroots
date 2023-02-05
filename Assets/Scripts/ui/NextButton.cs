using System;
using Punity.ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class NextButton : VisualElement
    {
        public Action SelectedFunction;
        
        
        public NextButton(float width, float height)
        {
            var r = 4;
            var c = 3;

            style.width = width;
            style.height = height;
            style.flexDirection = FlexDirection.Column;
            style.backgroundImage = QuickAccess.LoadSpriteBg("ui/kumanda");
            style.position = Position.Absolute;
            style.bottom = -179f;
            style.right = 54f;
            
            
            
            var b = new ButtonClickable("ui/devamet", Color.gray, MainButtonFunction)
            {
                style =
                {
                    top = 935f,
                    right = 187f,
                    position = Position.Absolute
                }
            };


            Add(b);
        }

        private void MainButtonFunction()
        {
            SelectedFunction();
        }
    }
}