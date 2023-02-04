using DefaultNamespace.GameData;
using Punity.ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class SpeechBubble : VisualElement
    {
        public SpeechBubble(FlavourTextBox thisTextBox)
        {
            style.width = 420f;
            style.height = 219f;

            style.position = Position.Absolute;

            if (thisTextBox.TextPos==FlavourTextPos.Guest)
            {
                style.backgroundImage = QuickAccess.LoadSpriteBg("ui/guest");
                style.left = 113f;
                style.top = 188f;
            }
            else
            {
                style.backgroundImage = QuickAccess.LoadSpriteBg("ui/host");
                style.left = 853f;
                style.top = 144f;
            }

            var b = new Label
            {
                style =
                {
                    position = Position.Absolute,
                    top = 17f,
                    height = 37f,
                    unityFontDefinition = QuickAccess.LoadFont("font/DMMono-Medium"),
                    fontSize = 28f,
                    unityTextAlign = TextAnchor.MiddleCenter,
                    whiteSpace = WhiteSpace.Normal,
                    color = new StyleColor(Color.black)
                },
                text = thisTextBox.L1
            };
            b.StretchToParentWidth();
            Add(b);
            
            b = new Label
            {
                style =
                {
                    position = Position.Absolute,
                    top = 17f + 37f,
                    height = 37f,
                    unityFontDefinition = QuickAccess.LoadFont("font/DMMono-Medium"),
                    fontSize = 28f,
                    unityTextAlign = TextAnchor.MiddleCenter,
                    whiteSpace = WhiteSpace.Normal,
                    color = new StyleColor(Color.black)
                },
                text = thisTextBox.L2
            };
            b.StretchToParentWidth();
            Add(b);
            
            b = new Label
            {
                style =
                {
                    position = Position.Absolute,
                    top = 17f + 37f*2f,
                    height = 37f,
                    unityFontDefinition = QuickAccess.LoadFont("font/DMMono-Medium"),
                    fontSize = 28f,
                    unityTextAlign = TextAnchor.MiddleCenter,
                    whiteSpace = WhiteSpace.Normal,
                    color = new StyleColor(Color.black)
                },
                text = thisTextBox.L3
            };
            b.StretchToParentWidth();
            Add(b);
            
            b = new Label
            {
                style =
                {
                    position = Position.Absolute,
                    top = 17f + 37f*3f,
                    height = 37f,
                    unityFontDefinition = QuickAccess.LoadFont("font/DMMono-Medium"),
                    fontSize = 28f,
                    unityTextAlign = TextAnchor.MiddleCenter,
                    whiteSpace = WhiteSpace.Normal,
                    color = new StyleColor(Color.black)
                },
                text = thisTextBox.L4
            };
            b.StretchToParentWidth();
            Add(b);
            

        }
    }
}