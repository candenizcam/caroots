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
        
        public HeadFrame(string id, float width, float height)
        {
            Id = id;
            _charData = DataBase.PickableCharactersArray.First(x => x.Id == id);

            style.width = width;
            style.height = height;
            style.backgroundImage = QuickAccess.LoadSpriteBg("ui/pickframe");


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
            
            Add(_image);
            
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


            var bc = new ButtonClickable(FrameClick);
            bc.StretchToParentSize();
            bc.style.position = Position.Absolute;
            bc.style.top = 0f;
            bc.style.left = 0f;
            Add(bc);

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
                _image.style.unityBackgroundImageTintColor = new StyleColor(Color.green);
                FrameState = 1;
            }else if (FrameState == 1)
            {
                _image.style.unityBackgroundImageTintColor = new StyleColor(Color.red);
                FrameState = 2;
            }
            else
            {
                _image.style.unityBackgroundImageTintColor = new StyleColor(Color.white);
                FrameState = 0;
            }
        }
        
    }
}