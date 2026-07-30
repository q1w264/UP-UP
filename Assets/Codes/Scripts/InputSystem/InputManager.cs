using Runtime.Codes.Scripts.EventSO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Codes.Scripts.InputSystem
{
    public class InputManager : MonoBehaviour, GameInputAction.IPlayerActions
    {
        [Header("Broadcasted Events")]
        public Vector2EventSO onMoveEvent;
        public VoidEventSO onJumpEvent;
        public VoidEventSO onInteractEvent;
        public VoidEventSO onSprintEvent;
        public VoidEventSO onMenuEvent;
        
        private GameInputAction _inputAction;
        private GameInputAction.PlayerActions _playerActions;

        private void Awake()
        {
            _inputAction = GetComponent<GameInputAction>();
            _playerActions = _inputAction.Player;
            _playerActions.AddCallbacks(this);
        }

        private void OnDestroy()
        {
            _inputAction.Dispose();
        }

        private void OnEnable()
        {
            _inputAction.Enable();
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }


        public void OnMove(InputAction.CallbackContext context)
        {
            onMoveEvent.Invoke(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            onInteractEvent.Invoke();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            onJumpEvent.Invoke();
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            onSprintEvent.Invoke();
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            onMenuEvent.Invoke();
        }
    }
}