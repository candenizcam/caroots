﻿using DefaultNamespace.GameData;
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
        
        protected override void InitializeMain()
        {
            UIDocument.rootVisualElement.style.paddingBottom = Constants.UnsafeBottomUi;
            UIDocument.rootVisualElement.style.paddingTop = Constants.UnsafeTopUi;
            Application.targetFrameRate = 60;


            _thisLevel = DataBase.LevelRecordsArray[0];
            _headPicker = new HeadPicker(_thisLevel,614f,1036f)
            {
                style =
                {
                    position = Position.Absolute,
                    bottom = 0f,
                    right = 54f
                },
                SelectedFunction = (selectedId) =>
                {
                    if (_thisLevel.Answer == selectedId)
                    {
                        Debug.Log("success");
                    }
                    else
                    {
                        Debug.Log("failure");
                    }
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