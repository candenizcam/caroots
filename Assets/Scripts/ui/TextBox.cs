using Punity.ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class TextBox: VisualElement
    {
        private Label _textLabel;
        
        
        public TextBox(float width, float height)
        {
            style.width = width;
            style.height = height;
            style.backgroundImage = QuickAccess.LoadSpriteBg("ui/rainbow");
            style.bottom = 60f;
            style.left = 138f;
            style.position = Position.Absolute;
            

            _textLabel = new Label
            {
                style =
                {
                    left = 26f,
                    top = 20f,
                    bottom = 20f,
                    height = 220f,
                    width = 1072,
                    unityFontDefinition = QuickAccess.LoadFont("font/DMMono-Medium"),
                    fontSize = 28f,
                    unityTextAlign = TextAnchor.MiddleCenter,
                    whiteSpace = WhiteSpace.Normal,
                    color = new StyleColor(Color.black)
                }
            };


            Add(_textLabel);
        }


        public void ChangeText(string t)
        {
            _textLabel.text = t;
        }

        public void UpDownAnimation(float alpha)
        {
            style.opacity = alpha;
        }
    }
}