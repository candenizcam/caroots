using System;
using Punity.ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class TVScreen : VisualElement
    {

        private ButtonClickable _dantel;
        public Action ButtonAction = () => { };
        public bool GoinDown = true;

        public TVScreen()
        {
            style.width = 1920f;
            style.height = 1080f;
            style.position = Position.Absolute;
            style.backgroundImage = QuickAccess.LoadSpriteBg("ui/tv");


            _dantel = new ButtonClickable("ui/credits", Color.gray, ButtonFunction);
            _dantel.style.position = Position.Absolute;
            _dantel.style.top = -300f;
            _dantel.style.left = 477f;


            Add(_dantel);
        }


        private void ButtonFunction()
        {
            ButtonAction();
        }

        public void UpDown(float alpha)
        {
            _dantel.style.top = -300f * (GoinDown ? alpha : (1f-alpha));
        }
        
        

        public void DisableButton(bool b)
        {
            _dantel.Disable(b);

        }
    }
}