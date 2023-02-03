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


            _textLabel = new Label
            {
                style =
                {
                    left = 26f,
                    right = 26f,
                    top = 20f,
                    bottom = 20f
                }
            };


            Add(_textLabel);
        }


        public void ChangeText(string t)
        {
            _textLabel.text = t;
        }
    }
}