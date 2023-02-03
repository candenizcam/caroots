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




            var bc = new ButtonClickable(FrameClick);
            bc.StretchToParentSize();
            Add(bc);

        }


        private void FrameClick()
        {
            Debug.Log("because of man");
        }
    }
}