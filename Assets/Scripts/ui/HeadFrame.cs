using System.Linq;
using DefaultNamespace.GameData;
using Punity.ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class HeadFrame : VisualElement
    {
        public readonly string Id;
        private PickableCharacters _charData;

        public HeadFrame(string id, float width, float height)
        {
            Id = id;
            _charData = DataBase.PickableCharactersArray.First(x => x.Id == id);

            style.width = width;
            style.height = height;
            style.backgroundImage = QuickAccess.LoadSpriteBg("ui/pickframe");


            var image = new VisualElement
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
            
            Add(image);
            
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
            Debug.Log("because of man");
        }
    }
}