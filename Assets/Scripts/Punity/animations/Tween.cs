using System;

namespace Punity.animations
{
    public class Tween
    {
        private Phase _phase; // phase of the animation
        private readonly float _totalTime; // total time, written at first call
        private float _countTime; // time that holds dt
        private bool _callDuringWithStartFunction; // if true, during is called at start phase with 0f alpha, default is false
        private int _repeat; // if <=0 infinite, 1: once, 2: twice ...
        public Action StartAction; // called on the turn it is first added, 
        public Action ExitAction; // called after the turn time is up
        public Action<float> DuringAction; // called during the tween, after start and before exit
        public bool Dead => _phase == Phase.Dead;

        public Tween(float sec, Action startAction = null, Action exitAction= null, Action<float> duringAction= null, int repeat =1, bool callDuringWithStartFunction = false)
        {
            _totalTime = sec;
            _countTime = 0f;
            StartAction = startAction ??= () => { };
            ExitAction = exitAction ??= () => { };
            DuringAction = duringAction ??= (float alpha) => { };
            _repeat = repeat;
            _phase = Phase.Start;
            _callDuringWithStartFunction = callDuringWithStartFunction;
        }


        public void DoTheThing(float dt)
        {
            switch (_phase)
            {
                case Phase.Start:
                    _countTime = 0f;
                    StartFunction();
                    if(_callDuringWithStartFunction)
                    {
                        DuringFunction(0f);
                    }
                    _phase = Phase.During;
                    break;
                case Phase.Exit:
                    ExitFunction();
                    _phase = Phase.Dead;
                    break;
                case Phase.During:
                {
                    _countTime += dt;
                    if (_countTime >= _totalTime)
                    {
                        DuringFunction(1f);
                        switch (_repeat)
                        {
                            case > 1:
                                _repeat -= 1;
                                _phase = Phase.Start;
                                break;
                            case <= 0:
                                _phase = Phase.Start;
                                break;
                            default:
                                _phase = Phase.Exit;
                                break;
                        }
                    }
                    else
                    {
                        DuringFunction(_countTime/_totalTime);
                    }

                    break;
                }
                default:
                    break;
            }
        }

        private void ExitFunction()
        {
            ExitAction();

        }

        private void StartFunction()
        {
            StartAction();
        }

        private void DuringFunction(float alpha)
        {
            DuringAction(alpha);
        }
        
        public enum Phase
        {
            Start, During ,Exit, Dead
        };
    }
}