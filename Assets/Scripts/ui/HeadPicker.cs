using DefaultNamespace.GameData;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class HeadPicker : VisualElement
    {
        public HeadPicker(LevelRecord thisLevel, float width, float height)
        {
            var r = 4;
            var c = 3;

            style.width = width;
            style.height = height;
            style.flexDirection = FlexDirection.Column;

            var n = 0;
            for (var i = 0; i < r; i++)
            {
                var thisRow = new VisualElement
                {
                    style =
                    {
                        height = height / 4f,
                        flexDirection = FlexDirection.Row,
                        position = Position.Absolute,
                        top = i * (height / 4f),
                        alignItems = Align.Center,
                        justifyContent = Justify.SpaceAround
                    }
                };

                thisRow.StretchToParentWidth();
                Add(thisRow);
                for (var j = 0; j < c; j++)
                {
                    var p = new HeadFrame(thisLevel.Pickables[n],150f,210f);
                    thisRow.Add(p);
                }
            }



        }
    }
}