using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.GameData;
using Punity.tools;
using Punity.ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class HeadPicker : VisualElement
    {
        private List<HeadFrame> _headFrames = new();
        public Action<string> SelectedFunction;
        public HeadPicker(LevelRecord thisLevel, float width, float height)
        {
            var r = 4;
            var c = 3;

            style.width = width;
            style.height = height;
            style.flexDirection = FlexDirection.Column;
            style.backgroundImage = QuickAccess.LoadSpriteBg("ui/kumanda");

            var shuffledSeats = thisLevel.Pickables.ToList().Shuffled().ToList();
            

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
                        top = 74f + i * 206f,
                        alignItems = Align.Center,
                        justifyContent = Justify.SpaceAround
                    }
                };

                thisRow.StretchToParentWidth();
                Add(thisRow);
                for (var j = 0; j < c; j++)
                {
                    var p = new HeadFrame(shuffledSeats[n],150f,181f);
                    p.FrameFunction = (name, state) =>
                    {

                    };
                    n += 1;
                    _headFrames.Add(p);
                    thisRow.Add(p);
                }
            }



            var b = new ButtonClickable("ui/acalim", Color.gray, MainButtonFunction)
            {
                style =
                {
                    bottom = 27f,
                    right = 29f,
                    position = Position.Absolute
                }
            };


            Add(b);

        }

        private void MainButtonFunction()
        {
            var hf = _headFrames.Where(x => x.FrameState == 1).ToList();
            if (hf.Count != 1)
            {
                Debug.LogWarning("problem, not one selected");
            }
            else
            {
                var selected = hf.First();
                SelectedFunction(selected.Id);
            }
        }
    }
}