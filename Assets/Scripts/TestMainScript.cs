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
        private NextButton _nextButton;
        private LevelRecord _thisLevel;
        public SoundScript jukebox;
        public DoorScript door;
        public SofaScript sofaScript;
        private int _levelIndex = 0;
        private float _nothingTimer = 0f;
        private float _nothingTrigger = 5f;
        private bool _nothingWaiter = false;
        private Tween _nothingTween = null;
        private VisualElement _bubbleLayer;
        private int _pretextInDex = 0;
        private CarrotHolder _carrotHolder;
        private ButtonClickable _sadEnd;
        private ButtonClickable _happyEnd;
        private Action _otherNextAction;
        public BunScript bunScript;
        
        protected override void InitializeMain()
        {
            
            Debug.Log("warning, this game may not work in all browsers, we tried and it works on edge & safari, and we are sorry if it doesn't for you. Also hello, thanks for trying our game.");
            
            UIDocument.rootVisualElement.style.marginBottom = (Constants.UiHeight-1080f) * 0.5f;
            UIDocument.rootVisualElement.style.marginTop = (Constants.UiHeight-1080f) * 0.5f;
            UIDocument.rootVisualElement.style.marginLeft = (Constants.UiWidth-1920f) * 0.5f;
            UIDocument.rootVisualElement.style.marginRight = (Constants.UiWidth-1920f) * 0.5f;
            
            Debug.Log($"{Constants.WorldSize.width}, {Constants.WorldSize.height}");
            Application.targetFrameRate = 60;

            var frame = new TVScreen();
            frame.ButtonAction = () =>
            {
                /*
                TweenHolder.NewTween(1f,duringAction: alpha =>
                {
                    
                    
                    frame.UpDown(1f-alpha);
                },exitAction: () =>
                {
                    frame.DisableButton(false);
                    frame.GoinDown = !frame.GoinDown;
                });
                frame.DisableButton(true);
                */

                _textBox.visible = !_textBox.visible;
                _headPicker.visible = !_headPicker.visible;
                _nextButton.visible = !_nextButton.visible;
                _carrotHolder.visible = !_carrotHolder.visible;
            };
            

            _bubbleLayer = new VisualElement();
            _bubbleLayer.StretchToParentSize();
            UIDocument.rootVisualElement.Add(_bubbleLayer);
            
            UIDocument.rootVisualElement.Add(frame);

            _nextButton = new NextButton(614f,1215f);
            _nextButton.SelectedFunction = NextButtonPressed;
            _carrotHolder = new CarrotHolder();
            UIDocument.rootVisualElement.Add(_carrotHolder);
            DoLevel();

            
            
            jukebox.ayyuzlu.Play();
            //_nothingWaiter = true;
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
            sofaScript.ActivateVisual(-1);
            _thisLevel = DataBase.LevelRecordsArray[_levelIndex];

            
            _headPicker = new HeadPicker(_thisLevel,614f,1215f)
            {
                
                SelectedFunction = (selectedId) =>
                {
                    TerminateNothinger();
                    _nothingWaiter = false;
                    jukebox.ayyuzlu.Pause();
                    
                    
                    TweenHolder.NewTween(.5f,duringAction: (alpha) =>
                    {
                        _headPicker.UpDownAnimate(1f-alpha);
                        _textBox.UpDownAnimation(1f-alpha);
                    },exitAction: () =>
                    {
                        jukebox.gulpembe.Play();
                        
                    });
                    var rightGuess = _thisLevel.Answer == selectedId;
                    door.SetCloudVectors();
                    
                    
                    TweenHolder.NewTween(10f,exitAction: () =>
                    {
                        if (_thisLevel.Answer == selectedId)
                        {
                            jukebox.claps.Play();
                        }
                        else
                        {
                            jukebox.aaw.Play();
                        }
                    });
                    
                    TweenHolder.NewTween(15f,duringAction: alpha=>
                        {
                            //1,1,4.4
                            var a1 = Math.Clamp(alpha * 3f, 0f, 1f);
                            var a2 = Math.Clamp(alpha * 3f-0.8f, 0f, 1f);
                            var a3 = Math.Clamp(alpha * 3f-1.6f, 0f, 1f);
                            var a4 = Math.Clamp(alpha * 3f-1.2f, 0f, 1f);
                            CameraPan(a1);
                            door.OpenAnimation(a2);
                            door.RevealAnimation(a3,rightGuess);
                            door.CloudAnimation(a4);
                            
                            
                        },
                        exitAction: () =>
                    {
                        
                        
                        jukebox.gulpembe.Pause();

                        var t = "";
                        if (_thisLevel.Answer == selectedId)
                        {
                            _otherNextAction = () =>
                            {
                                _levelIndex += 1;
                                if (_levelIndex >= DataBase.LevelRecordsArray.Length)
                                {
                                    _happyEnd = new ButtonClickable("endings/good", Color.white, clickAction: () =>
                                    {
                                        UIDocument.rootVisualElement.Remove(_happyEnd);
                                        
                                        Replay();
                                    });
                                    _happyEnd.style.position = Position.Absolute;
                                    UIDocument.rootVisualElement.Add(_happyEnd);
                                }
                                else
                                {
                                    KillThisLevel();
                                    DoLevel();
                                }
                                door.RevealAnimation(0f,rightGuess);
                                
                                TweenHolder.NewTween(.5f,duringAction: (alpha) =>
                                {
                                    door.OpenAnimation(1f-alpha);
                                    _headPicker.UpDownAnimate(alpha);
                                    _textBox.UpDownAnimation(alpha);
                                    CameraPan(1f-alpha);
                                },exitAction: () =>
                                {
                                    jukebox.ayyuzlu.Play();
                                });
                            };


                            t = _thisLevel.WinFlavour;
                            

                        }
                        else
                        { // faiulre
                            _otherNextAction = () =>
                            {
                                _headPicker.FalseGuessFunction(selectedId);

                                if (_carrotHolder.CarrotNumber <= 0)
                                {
                                
                                    _sadEnd = new ButtonClickable("endings/sad", Color.white, clickAction: () =>
                                    {
                                        UIDocument.rootVisualElement.Remove(_sadEnd);
                                        Replay();
                                    });
                                    _sadEnd.style.position = Position.Absolute;
                                    UIDocument.rootVisualElement.Add(_sadEnd);
                                }
                                else
                                {
                                    _carrotHolder.ChangeCarrots(_carrotHolder.CarrotNumber-1);
                                }
                                
                                door.RevealAnimation(0f,rightGuess);
                                
                                
                                TweenHolder.NewTween(.5f,duringAction: (alpha) =>
                                {
                                    door.OpenAnimation(1f-alpha);
                                    _headPicker.UpDownAnimate(alpha);
                                    _textBox.UpDownAnimation(alpha);
                                    _textBox.ChangeText(_thisLevel.Clues);
                                    CameraPan(1f-alpha);
                                },exitAction: () =>
                                {
                                    jukebox.ayyuzlu.Play();
                                });
                            };
                            t = DataBase.NotFoundTexts.ToList().Shuffled().First();
                            
                        }
                        
                        
                        UIDocument.rootVisualElement.Add(_nextButton);
                        _textBox.ChangeText(t);
                        bunScript.GoTalk();
                        _textBox.UpDownAnimation(1f);
                        

                        

                    });
                    
                    
                }
            };

            

            _textBox = new TextBox(1214f, 264f)
            {
                style =
                {
                    backgroundColor = new Color(1f, 1f, 0.8f)
                }
            };
            
            _pretextInDex = -1;
            UIDocument.rootVisualElement.Add(_textBox);
            if (_thisLevel.PreText.Length > 0)
            {
                _pretextInDex = 0;
                StarterTexts();
            }
            else
            {
                
                UIDocument.rootVisualElement.Add(_headPicker);
            }
            
            
        }

        private void StarterTexts()
        {
            _nothingWaiter = false;
            if (_pretextInDex < 0)
            {
                UIDocument.rootVisualElement.Add(_headPicker);
                
                UIDocument.rootVisualElement.Remove(_nextButton);
                _textBox.ChangeText(_thisLevel.Clues);
                sofaScript.ActivateVisual(_levelIndex);
                door.ActivateVisual(_levelIndex);
                _nothingWaiter = true;
            }
            else
            {
                
                if (_pretextInDex == 0)
                {
                    UIDocument.rootVisualElement.Add(_nextButton);
                }

                if (_thisLevel.PreText.Length > _pretextInDex)
                {
                    _textBox.ChangeText(_thisLevel.PreText[_pretextInDex]);
                    bunScript.GoTalk();
                }
                else
                {
                    

                    _pretextInDex = -1;
                    StarterTexts();
                }
                
                
                
            }
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
            RecursiveTextBoxer(0,random);
            
        }

        private void RecursiveTextBoxer(int index, FlavourText flavius)
        {
            _nothingWaiter = false;
            if (flavius.FlavourTextBoxes.Length > index)
            {
                if (flavius.FlavourTextBoxes[index].TextPos == FlavourTextPos.Host)
                {
                    bunScript.GoTalk();
                }
                
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

        public void NextButtonPressed()
        {
            if (_pretextInDex >= 0)
            {
                _pretextInDex+=1;
                StarterTexts();
            }
            else
            {
                UIDocument.rootVisualElement.Remove(_nextButton);
                _otherNextAction();
                
            }
        }
        
        private void Replay()
        {
            _levelIndex = 0;
            _pretextInDex = 0;
            _carrotHolder.ChangeCarrots(3);
            KillThisLevel();
            DoLevel();
        }
    }
}