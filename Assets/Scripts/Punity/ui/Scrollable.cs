using UnityEngine;
using UnityEngine.UIElements;

namespace Punity.ui
{
    public class Scrollable : ScrollView
    {
        public bool Locked = false;
        private Vector2 _lastPosition = new Vector2(0f,0f);
        public Scrollable()
        {
            verticalScrollerVisibility = ScrollerVisibility.Hidden;
            horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            scrollDecelerationRate = 0f;
            
            verticalScroller.valueChanged += f =>
            {
                if (Locked)
                {
                    scrollOffset = _lastPosition;
                }
                else
                {
                    _lastPosition = scrollOffset;
                }
            };
            
            horizontalScroller.valueChanged += f =>
            {
                if (Locked)
                {
                    scrollOffset = _lastPosition;
                }
                else
                {
                    _lastPosition = scrollOffset;
                }
            };
            
        }
    }
}