using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;
        public UnityEvent<Vector3> ResponsePosition;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }

        public void OnEventRaisedPosition(Vector3 position)
        {
            ResponsePosition.Invoke(position);
        }
    }
}