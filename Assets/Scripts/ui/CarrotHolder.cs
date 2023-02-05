using System.Collections.Generic;
using Punity.ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class CarrotHolder: VisualElement
    {
        public int CarrotNumber = 3;
        private List<VisualElement> _carrots = new();
        
        public CarrotHolder()
        {
            style.position = Position.Absolute;
            style.left = 18f;
            style.top = 18f;

            for (int i = 0;i<CarrotNumber;i++)
            {

                var n = new VisualElement
                {
                    style =
                    {
                        width = 88f,
                        height = 88f,
                        position = Position.Absolute,
                        top = i*88f,
                        left = 0f,
                        backgroundImage = QuickAccess.LoadSpriteBg("ui/live")
                        
                    }
                    
                    
                };
                Add(n);
                _carrots.Add(n);
            }
            
        }


        public void ChangeCarrots(int newNumber)
        {
            CarrotNumber = newNumber;

            for (var i = 0; i < _carrots.Count; i++)
            {
                _carrots[i].style.backgroundImage = QuickAccess.LoadSpriteBg(i < newNumber ? "ui/live" : "ui/lostlive");
            }
        }
    }
}