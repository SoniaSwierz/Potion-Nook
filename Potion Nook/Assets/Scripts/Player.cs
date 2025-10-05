using System;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent {

    public static Player Instance { get; private set; }


    public event EventHandler<OnSelectedFurnitureChangedEventArgs> OnSelectedFurnitureChanged;
    public class OnSelectedFurnitureChangedEventArgs : EventArgs {
        public BaseKicthenFurniture selectedKitchenFurniture;
    }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float playerRadius = 0.3f;
    [SerializeField] private float playerHeight = 2f;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private Transform kitchenObjectHoldPoint;

    private bool canMove = true;
    private float moveDistance;
    private bool isWalking;
    private Vector3 lastInteractDir;
    private BaseKicthenFurniture selectedKitchenFurniture;
    private KitchenObject kitchenObject;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("More than one Player instance");
        }
        Instance = this;
    }

    private void Start () {
        gameInput.OnInteractAction += GemeInput_OnInteractAction;
        gameInput.OnSelectItemFromListAction += GameInput_OnSelectItemFromListAction;
    }

    private void Update() {
        HandleMovement();
        HandleInteractions();
    }

    private void GemeInput_OnInteractAction(object sender, System.EventArgs e) {
        if (selectedKitchenFurniture != null) {
            selectedKitchenFurniture.Interact(this);
        }
    }

    private void GameInput_OnSelectItemFromListAction(object sender, GameInput.SelectItemFromList_performedEventArgs e) {
        if (selectedKitchenFurniture != null) {
            selectedKitchenFurniture.SelectItemFromList(this, e.keyNumber);
        }
    }


    private void HandleInteractions() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero) {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask)) {
            if (raycastHit.transform.TryGetComponent(out BaseKicthenFurniture baseKitchenFurniture)) {
                // Counter is clear
                if (baseKitchenFurniture != selectedKitchenFurniture) {
                    SetSelectedCounter(baseKitchenFurniture);
                }
            } else {
                SetSelectedCounter(null);
            }
        } else {
            SetSelectedCounter(null);
        }
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        moveDistance = moveSpeed * Time.deltaTime;

        //collisions
        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                                       playerRadius, moveDir, moveDistance);

        if (!canMove) { // "Hugging a wall" while moving diagonally
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

            if (canMoveX || canMoveZ)
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

    private void SetSelectedCounter(BaseKicthenFurniture selectedCounter) {
        this.selectedKitchenFurniture = selectedCounter;

        OnSelectedFurnitureChanged?.Invoke(this, new OnSelectedFurnitureChangedEventArgs {
            selectedKitchenFurniture = selectedCounter
        });
    }

    public Transform GetKitchenObjectFollowTransform() {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
