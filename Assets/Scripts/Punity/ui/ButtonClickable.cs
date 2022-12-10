using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Classes
{
    public class ButtonClickable: VisualElement
    {
        public Action OnTouchDown = () => {};
        public Action OnTouchUp = () => {};
        public Action OnLeave = () => { };
        public Action ClickAction = () => {};

        
        
        public string Text
        {
            get => _textLabel.text;
            set => _textLabel.text = value;
        }

        public float Width => width;
        public float Height => height;
        protected float width;
        protected float height;
        private readonly Label _textLabel;
        public bool DisableButton => _disableButton;
        private bool _disableButton = false;

        private StyleBackground _regularBg;
        private StyleBackground _inactiveBg;
        
        
        public ButtonClickable(Action clickAction = null) : base()
        {
            ClickAction = clickAction ??= () => {};
            style.borderBottomColor = Color.clear;
            style.borderTopColor = Color.clear;
            style.borderRightColor = Color.clear;
            style.borderLeftColor = Color.clear;
            _textLabel = new Label();
            _textLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
            _textLabel.StretchToParentSize();
            Add(_textLabel);
            
            RegisterCallback<MouseLeaveEvent>(TouchLeave);
            RegisterCallback<MouseDownEvent>(TouchDown);
            RegisterCallback<MouseUpEvent>(TouchUp);
            RegisterCallback<ClickEvent>(Click);
        }

        public ButtonClickable(string imagePath, Color? pressedTint = null, Action clickAction = null, string inactivePath = null): this(clickAction)
        {
            ChangeImage(imagePath);
            if (inactivePath is not null)
            {
                _inactiveBg = new StyleBackground(Resources.Load<Sprite>(inactivePath));
            }
            else
            {
                _inactiveBg =  new StyleBackground(Resources.Load<Sprite>(imagePath));
            }
            
            style.backgroundColor = Color.clear;
            
            OnTouchDown = () =>
            {
                style.unityBackgroundImageTintColor = pressedTint ??= Color.gray;
            };
            
            OnTouchUp = () =>
            {
                style.unityBackgroundImageTintColor = Color.white;
            };
            OnLeave = () =>
            {
                style.unityBackgroundImageTintColor = Color.white;
            };
        }

        public void Disable(bool b, Color? disabledColour = null)
        {
            _disableButton = b;
            style.backgroundImage = b ? _inactiveBg : _regularBg;
            if (disabledColour is not null)
            {
                style.unityBackgroundImageTintColor = b ? new StyleColor((Color)disabledColour) : new StyleColor(Color.white);
            }
            
        }

        public void ChangeImage(string imagePath)
        {
            var s2 = Resources.Load<Sprite>(imagePath);
            _regularBg = new StyleBackground( s2);
            width = s2.rect.width;
            height = s2.rect.height;
            style.width = width;
            style.height = height;
            style.backgroundImage = _regularBg;
        }

        protected virtual void TouchLeave(MouseLeaveEvent e)
        {
            if (!DisableButton)
            {
                OnLeave();
            }
        }
        
        protected virtual void TouchDown(MouseDownEvent e)
        {
            
            
            
            if (!DisableButton)
            {
                OnTouchDown();
            }
        }

        protected virtual void TouchUp(MouseUpEvent e)
        {
            if (!DisableButton)
            {
                OnTouchUp();
            }
        }

        protected virtual void Click(ClickEvent e)
        {
            if (!DisableButton)
            {
                ClickAction();
            }
        }

    }
}