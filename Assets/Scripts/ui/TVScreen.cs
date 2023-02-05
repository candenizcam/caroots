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
        private VisualElement _credits;

        public TVScreen()
        {
            style.width = 1920f;
            style.height = 1080f;
            style.position = Position.Absolute;
            

            var frame = new VisualElement();
            frame.style.width = 1920f;
            frame.style.height = 1080f;
            frame.style.backgroundImage = QuickAccess.LoadSpriteBg("ui/tv 1");
            frame.style.position = Position.Absolute;
            


            _dantel = new ButtonClickable("ui/credits", Color.gray, ButtonFunction);
            _dantel.style.position = Position.Absolute;
            _dantel.style.top = -300f;
            _dantel.style.left = 477f;


            _credits = new VisualElement();
            _credits.style.position = Position.Absolute;
            _credits.style.width = 1920f;
            _credits.style.height = 1080f;
            _credits.style.backgroundImage = QuickAccess.LoadSpriteBg("ui/credits2");
            _credits.visible = false;
            Add(_credits);
            Add(frame);
            
            Add(_dantel);
        }


        private void ButtonFunction()
        {
            _credits.visible = !_credits.visible;
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