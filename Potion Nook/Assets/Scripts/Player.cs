using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float playerRadius = 0.3f;
    [SerializeField] private float playerHeight = 2f;

    private bool canMove = true;
    private float moveDistance;
    private bool isWalking;

    private void Update() {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        moveDistance = moveSpeed * Time.deltaTime;
        //collisions
        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,  
                                       playerRadius, moveDir, moveDistance);

        if (!canMove) {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;

            bool canMoveX = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, 
                                                playerRadius, moveDirX, moveDistance);
            bool canMoveZ = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, 
                                                playerRadius, moveDirZ, moveDistance);

            if (canMoveX) 
                moveDir = moveDirX;
            else if (canMoveZ)
                moveDir = moveDirZ;
            
            if(canMoveX || canMoveZ)
                canMove = true;
        }


        if (canMove)
            transform.position += moveDir * moveDistance;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking() {
        return isWalking;
    }
}
