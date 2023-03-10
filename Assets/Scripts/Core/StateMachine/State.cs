using System;

namespace Core.StateMachine
{
    public abstract class State
    {
        public event Action Launched;

        public virtual void Launch()
        {
            Launched?.Invoke();
        }

        public void SubscribeActionToLaunch(Action influence)
        {
            Launched += influence;
        }

        public void UnSubscribeActionToLaunch(Action influence)
        {
            Launched -= influence;
        }
    }
}