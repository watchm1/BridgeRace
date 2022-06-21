using UnityEngine;

namespace Game.Scripts.Core.Observer
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void OnNotify(NotificationType type);
    }
}