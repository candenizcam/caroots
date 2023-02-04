using System;
using System.Collections.Generic;
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
        private int _levelIndex = 0;
        protected override void InitializeMain()
        {
            
            
            
            UIDocument.rootVisualElement.style.paddingBottom = Constants.UnsafeBottomUi;
            UIDocument.rootVisualElement.style.paddingTop = Constants.UnsafeTopUi;
            UIDocument.rootVisualElement.style.marginLeft = (Constants.UiWidth-1920f) * 0.5f;
            UIDocument.rootVisualElement.style.marginRight = (Constants.UiWidth-1920f) * 0.5f;
            Application.targetFrameRate = 60;
            DoLevel();

            
            
            jukebox.ayyuzlu.Play();
        }


        private void KillThisLevel()
        {
            UIDocument.rootVisualElement.Remove(_textBox);
            UIDocument.rootVisualElement.Remove(_headPicker);
        }

        private void DoLevel()
        {
            if (_levelIndex >= DataBase.LevelRecordsArray.Length)
            {
                Application.Quit();
                return;
            }
            
            _thisLevel = DataBase.LevelRecordsArray[_levelIndex];
            _headPicker = new HeadPicker(_thisLevel,614f,1215f)
            {
                
                SelectedFunction = (selectedId) =>
                {
                    jukebox.ayyuzlu.Pause();
                    
                    
                    TweenHolder.NewTween(.5f,duringAction: (alpha) =>
                    {
                        _headPicker.UpDownAnimate(1f-alpha);
                        _textBox.UpDownAnimation(1f-alpha);
                    },exitAction: () =>
                    {
                        jukebox.gulpembe.Play();
                        
                    });
                    
                    TweenHolder.NewTween(15f,duringAction: alpha=>
                        {
                            //2,2,3.4
                            var a1 = Math.Clamp(alpha * 3f, 0f, 1f);
                            var a2 = Math.Clamp(alpha * 3f-0.8f, 0f, 1f);
                            CameraPan(a1);
                            door.OpenAnimation(a2);
                            
                            
                        },
                        exitAction: () =>
                    {
                        
                        jukebox.gulpembe.Pause();
                        if (_thisLevel.Answer == selectedId)
                        {
                            KillThisLevel();
                            _levelIndex += 1;
                            DoLevel();

                        }
                        else
                        {
                            _headPicker.FalseGuessFunction(selectedId);
                            Debug.Log("failure");
                        }
                        
                        
                        TweenHolder.NewTween(.5f,duringAction: (alpha) =>
                        {
                            door.OpenAnimation(1f-alpha);
                            _headPicker.UpDownAnimate(alpha);
                            _textBox.UpDownAnimation(alpha);
                        },exitAction: () =>
                        {
                            jukebox.ayyuzlu.Play();
                        });
                        
                    });
                    
                    
                }
            };

            

            _textBox = new TextBox(1214f, 264f)
            {
                
            };
            _textBox.ChangeText(_thisLevel.Clues);
            
            UIDocument.rootVisualElement.Add(_textBox);
            UIDocument.rootVisualElement.Add(_headPicker);
        }

        private void CameraPan(float alpha)
        {
            MainCamera.orthographicSize = Constants.WorldHeight*(1f-alpha) + 4.4f*alpha;
            MainCamera.transform.position = new Vector3(1f*alpha,1f*alpha,-10f);
        }

            protected override void UpdateMain()
        {
            
            
        }
        
    }
}