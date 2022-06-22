using System;
using System.Collections.Generic;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Core.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        #region ObserverVariables
        private List<Observer> _observers;
        #endregion
        #region RegisterObserver
        public void RegisterObserver(Observer observer)
        {
            if (_observers == null)
                _observers = new List<Observer>();
            _observers.Add(observer);
        }
        #endregion

        protected virtual void Start()
        {
            ObserverManager.Instance.RegisterSubject(this);
        }

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
