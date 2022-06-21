using System.Collections.Generic;
using Game.Scripts.Core.Singleton;
namespace Game.Scripts.Core.Observer
{
    public class ObserverManager : SingletonPersistent<ObserverManager>
    {
        #region Variables
        private List<Subject> _subjects;
        #endregion
        #region Register
        public void RegisterSubject(Subject subject)
        {
            if (_subjects == null) _subjects = new List<Subject>();
            _subjects.Add(subject);
        }
        public void RegisterObserver(Observer observer)
        {
            foreach (var item in _subjects)
            {
                item.RegisterObserver(observer);
            }
        }
        #endregion
    }

}