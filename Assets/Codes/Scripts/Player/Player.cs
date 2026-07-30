using Runtime.Codes.Scripts.EventSO;
using UnityEngine;

namespace Runtime.Codes.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Received Events")] public Vector2EventSO onMoveEvent;
        public VoidEventSO onJumpEvent;
        public VoidEventSO onInteractEvent;
        public VoidEventSO onSprintEvent;

        private void OnEnable()
        {
            if (onInteractEvent != null)
                onMoveEvent.OnEvent += Move;
            if (onJumpEvent != null)
                onJumpEvent.OnEvent += Jump;
            if (onInteractEvent != null)
                onInteractEvent.OnEvent += Interact;
            if (onSprintEvent != null)
                onSprintEvent.OnEvent += Sprint;
        }

        private void OnDisable()
        {
            if (onMoveEvent != null)
                onMoveEvent.OnEvent -= Move;
            if (onJumpEvent != null)
                onJumpEvent.OnEvent -= Jump;
            if (onInteractEvent != null)
                onInteractEvent.OnEvent -= Interact;
            if (onSprintEvent != null)
                onSprintEvent.OnEvent -= Sprint;
        }


        private void Move(Vector2 input)
        {
        }

        private void Jump()
        {
        }

        private void Interact()
        {
        }

        private void Sprint()
        {
        }
    }
}