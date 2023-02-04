using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.GameData;
using Punity;
using Punity.animations;
using Punity.ObjectScripts;
using Punity.tools;
using Punity.ui;
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
        private float _nothingTimer = 0f;
        private float _nothingTrigger = 5f;
        private bool _nothingWaiter = false;
        private Tween _nothingTween = null;
        private VisualElement _bubbleLayer;
        
        protected override void InitializeMain()
        {
            
            
            
            UIDocument.rootVisualElement.style.paddingBottom = Constants.UnsafeBottomUi;
            UIDocument.rootVisualElement.style.paddingTop = Constants.UnsafeTopUi;
            UIDocument.rootVisualElement.style.marginLeft = (Constants.UiWidth-1920f) * 0.5f;
            UIDocument.rootVisualElement.style.marginRight = (Constants.UiWidth-1920f) * 0.5f;
            Application.targetFrameRate = 60;

            var frame = new VisualElement();
            frame.style.width = 1920f;
            frame.style.height = 1080f;
            frame.style.position = Position.Absolute;
            frame.style.backgroundImage = QuickAccess.LoadSpriteBg("ui/tv");

            _bubbleLayer = new VisualElement();
            _bubbleLayer.StretchToParentSize();
            UIDocument.rootVisualElement.Add(_bubbleLayer);
            
            UIDocument.rootVisualElement.Add(frame);

            DoLevel();

            
            
            jukebox.ayyuzlu.Play();
            _nothingWaiter = true;
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
                    TerminateNothinger();
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
                            //1,1,4.4
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
                            CameraPan(1f-alpha);
                        },exitAction: () =>
                        {
                            jukebox.ayyuzlu.Play();
                            _nothingWaiter = true;
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
            if (_nothingWaiter)
            {
                _nothingTimer += Time.deltaTime;

                if (_nothingTimer >= _nothingTrigger)
                {
                    Debug.Log("işsiz işsiz oturuyo");
                    _nothingTimer = 0f;
                    NothingAction();
                }
            }
            else
            {
                _nothingTimer = 0f;
            }
            
        }

        private void NothingAction()
        {
            var possibles = DataBase.FlavourTexts.Where(x =>
                x.PossibleLevels.Length == 0 || x.PossibleLevels.Any(y => y == _thisLevel.Id)).ToList();

            var random = possibles.PickRandom();
            Debug.Log($"{random.Id}");
            RecursiveTextBoxer(0,random);
            
        }

        private void RecursiveTextBoxer(int index, FlavourText flavius)
        {
            _nothingWaiter = false;
            if (flavius.FlavourTextBoxes.Length > index)
            {
                var n = new SpeechBubble(flavius.FlavourTextBoxes[index]);
                _bubbleLayer.Add(n);
                var nt = new Tween(4f,exitAction: () =>
                {
                    _bubbleLayer.Remove(n);
                    RecursiveTextBoxer(index+1,flavius);
                });
                _nothingTween = nt;
                TweenHolder.NewTween(nt);
            }
            else
            {
                _nothingWaiter = true;
            }
        }

        private void TerminateNothinger()
        {
            if (_nothingTween is not null)
            {
                TweenHolder.RemoveTween(_nothingTween);
                _bubbleLayer.Clear();
                _nothingTween = null;
            }
        }
        
        
    }
}