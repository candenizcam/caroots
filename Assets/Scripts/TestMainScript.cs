﻿using System;
using DefaultNamespace.GameData;
using Punity;
using Punity.ObjectScripts;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class TestMainScript : MainScript
    {

        private TextBox _textBox;
        private HeadPicker _headPicker;
        private LevelRecord _thisLevel;
        public SoundScript jukebox;
        public DoorScript door;
        protected override void InitializeMain()
        {
            
            
            
            UIDocument.rootVisualElement.style.paddingBottom = Constants.UnsafeBottomUi;
            UIDocument.rootVisualElement.style.paddingTop = Constants.UnsafeTopUi;
            UIDocument.rootVisualElement.style.marginLeft = (Constants.UiWidth-1920f) * 0.5f;
            UIDocument.rootVisualElement.style.marginRight = (Constants.UiWidth-1920f) * 0.5f;
            Application.targetFrameRate = 60;


            _thisLevel = DataBase.LevelRecordsArray[0];
            _headPicker = new HeadPicker(_thisLevel,614f,1215f)
            {
                
                SelectedFunction = (selectedId) =>
                {
                    jukebox.ayyuzlu.Pause();
                    
                    
                    TweenHolder.NewTween(.5f,duringAction: (alpha) =>
                    {
                        _headPicker.UpDownAnimate(1f-alpha);
                    },exitAction: () =>
                    {
                        jukebox.gulpembe.Play();
                        if (_thisLevel.Answer == selectedId)
                        {
                            Debug.Log("success");
                        }
                        else
                        {
                            _headPicker.FalseGuessFunction(selectedId);
                            Debug.Log("failure");
                        }
                    });
                    
                    TweenHolder.NewTween(15f,duringAction: alpha=>
                        {
                            var a1 = Math.Clamp(alpha * 3f, 0f, 1f);
                            door.OpenAnimation(a1);
                            
                            
                        },
                        exitAction: () =>
                    {
                        
                        jukebox.gulpembe.Pause();
                        TweenHolder.NewTween(.5f,duringAction: (alpha) =>
                        {
                            door.OpenAnimation(1f-alpha);
                            _headPicker.UpDownAnimate(alpha);
                        },exitAction: () =>
                        {
                            jukebox.ayyuzlu.Play();
                        });
                        
                    });
                    
                    
                }
            };

            

            _textBox = new TextBox(1214f, 264f)
            {
                style =
                {
                    bottom = 60f,
                    left = 138f,
                    position = Position.Absolute
                }
            };
            _textBox.ChangeText(_thisLevel.Clues);
            
            UIDocument.rootVisualElement.Add(_textBox);
            UIDocument.rootVisualElement.Add(_headPicker);
            
            jukebox.ayyuzlu.Play();
        }

        protected override void UpdateMain()
        {
            
            
        }
        
    }
}