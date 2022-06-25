using Game.Scripts.Core.Singleton;
using Game.Scripts.Pool;

namespace Game.Scripts.Managers
{
    public class PoolManager : Singleton<PoolManager>
    {
        public ObjectPool pool;
        private void Start()
        {
            pool = FindObjectOfType<ObjectPool>();
        }
    }
}
