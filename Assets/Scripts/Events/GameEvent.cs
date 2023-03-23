using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "Game Event", menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RaisePosition(Vector3 position)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaisedPosition(position);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}