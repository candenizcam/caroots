using System;
using System.Linq;
using DefaultNamespace.GameData;
using Punity.ui;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class HeadFrame : VisualElement
    {
        public readonly string Id;
        private PickableCharacters _charData;
        public Action<string, int> FrameFunction = (a,b)=>{};
        public int FrameState = 0;

        private VisualElement _image;
        private ButtonClickable _button;
        
        
        public HeadFrame(string id, float width, float height, bool showText)
        {
            Id = id;
            _charData = DataBase.PickableCharactersArray.First(x => x.Id == id);

            style.width = width;
            style.height = height;


            _image = new VisualElement
            {
                style =
                {
                    width = width,
                    height = width,
                    position = Position.Absolute,
                    left = 0f,
                    top = 0f,
                    backgroundImage = QuickAccess.LoadSpriteBg(_charData.FramePath)
                }
            };
            
            
            
            
            if (showText)
            {
                var bottomLabel = new Label()
                {
                    style =
                    {
                        width = width,
                        height = height-width,
                        position = Position.Absolute,
                        left = 0f,
                        bottom = 0f,
                        unityFontDefinition = QuickAccess.LoadFont("font/DMMono-Medium"),
                        fontSize = 24f,
                        unityTextAlign = TextAnchor.MiddleCenter,
                        whiteSpace = WhiteSpace.Normal,
                        color = new StyleColor(Color.black),
                        backgroundColor = new StyleColor(Color.cyan)
                    },
                    text = _charData.Name
                };
            
                Add(bottomLabel);
            }
            


            _button = new ButtonClickable("ui/button",Color.gray,FrameClick);
            _button.StretchToParentSize();
            _button.style.position = Position.Absolute;
            _image.style.top =  0f;
            _image.style.left =  0f;
            Add(_button);
            _button.Add(_image);

        }


        private void FrameClick()
        {
            UpdateState();
            FrameFunction(Id, FrameState);
        }

        private void UpdateState()
        {
            if (FrameState == 0)
            {
                SetGreen();
                
            }else if (FrameState == -1)
            {
                SetRed();
            }
            else
            {
                SetWhite();
                
            }
        }

        public void SetWhite()
        {
            if (FrameState != 0)
            {
                _image.style.unityBackgroundImageTintColor = new StyleColor(Color.white);
                _button.Disable(false);
                _button.style.backgroundImage = QuickAccess.LoadSpriteBg("ui/button");
                FrameState = 0;
                
            }
            
        }

        public void SetGreen()
        {
            if (FrameState != 1)
            {
                _image.style.unityBackgroundImageTintColor = new StyleColor(Color.green);
                _button.Disable(false);
                _button.style.backgroundImage = QuickAccess.LoadSpriteBg("ui/button_green");
                FrameState = 1;
                
            }
            
        }
        
        public void SetRed()
        {
            if (FrameState != -1)
            {
                _image.style.unityBackgroundImageTintColor = new StyleColor(new Color(.7f,.3f,.1f));
                _button.Disable(true);
                _button.style.backgroundImage = QuickAccess.LoadSpriteBg("ui/button_orange");
                
                FrameState = -1;
            }
            
        }
        
    }
}