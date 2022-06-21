using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Core.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        #region ObserverVariables
        private List<Observer> _observers;
        [SerializeField] private NotificationType type;
        #endregion
        #region RegisterObserver
        public void RegisterObserver(Observer observer)
        {
            if (_observers == null)
                _observers = new List<Observer>();
            _observers.Add(observer);
        }
        #endregion

        #region NotifyToObservers

        protected void Notify(NotificationType _type)
        {
            foreach (var item in _observers)
            {
                item.OnNotify(_type);
            }
        }
        #endregion
    }
}
