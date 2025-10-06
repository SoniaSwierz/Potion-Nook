using System;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler<SelectItemFromList_performedEventArgs> OnSelectItemFromListAction;

    private InputSystemActions inputSystemActions;

    public class SelectItemFromList_performedEventArgs : EventArgs {
        public int keyNumber;
    }

    private void Awake() {
        inputSystemActions = new InputSystemActions();
        inputSystemActions.Player.Enable();

        inputSystemActions.Player.Interact.performed += Interact_performed;
        inputSystemActions.Player.SelectItemFromList.performed += SelectItemFromList_performed;
        inputSystemActions.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void SelectItemFromList_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnSelectItemFromListAction?.Invoke(this, new SelectItemFromList_performedEventArgs {
            keyNumber = int.Parse(obj.control.name)
        });
    }


    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = inputSystemActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
