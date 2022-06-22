using Game.Scripts.Core.Singleton;

namespace Game.Scripts.Core.AI
{
    public abstract class NPC : Singleton<NPC>
    {
        private AIState _currentState;
        private bool _result;
        private void Update()
        {
            _currentState.Execute(this);
        }

        public void ChangeState(AIState state)
        {
            _currentState = state;
        }

        public bool BoxInRange()
        {
            // game logic
            return _result;
        }

        public bool CraftAreaInRange()
        {
            // game logic
            return _result;
        }
    }

}