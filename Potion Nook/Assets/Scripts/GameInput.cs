using UnityEngine;

public class GameInput : MonoBehaviour
{

    private InputSystemActions inputSystemActions;

    private void Awake() {
        inputSystemActions = new InputSystemActions();
        inputSystemActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = inputSystemActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
