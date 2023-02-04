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
            style.backgroundImage = QuickAccess.LoadSpriteBg("ui/yazili");
            style.position = Position.Absolute;
            style.bottom = -179f;
            style.right = 54f;

            var shuffledSeats = thisLevel.Pickables.ToList().Shuffled().ToList();
            

            var n = 0;
            for (var i = 0; i < r; i++)
            {
                var thisRow = new VisualElement
                {
                    style =
                    {
                        height = 150f,
                        flexDirection = FlexDirection.Row,
                        position = Position.Absolute,
                        top = 121f + i * 206f,
                        alignItems = Align.Center,
                        justifyContent = Justify.SpaceBetween,
                        width = 498f,
                        left = 58
                    }
                };

                
                Add(thisRow);
                for (var j = 0; j < c; j++)
                {
                    var p = new HeadFrame(shuffledSeats[n],150f,150f,false);
                    p.FrameFunction = (name, state) =>
                    {
                        if (state == 1)
                        {
                            _headFrames.Where(x => x.Id != name && x.FrameState==1).ToList().ForEach(x => x.SetWhite());
                        }

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
                    top = 935f,
                    right = 60f,
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

        public void FalseGuessFunction(string id)
        {
            foreach (var headFrame in _headFrames.Where(x => x.Id == id))
            {
                headFrame.SetRed();
            }
        }

        public void UpDownAnimate(float alpha)
        {
            style.bottom = -179f - 1200f*(1f-alpha);
        }
    }
}