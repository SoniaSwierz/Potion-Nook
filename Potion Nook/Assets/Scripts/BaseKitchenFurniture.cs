using UnityEngine;

public class BaseKicthenFurniture : MonoBehaviour, IKitchenObjectParent {
    
 
    [SerializeField] private Transform furnitureTakePoint;

    private KitchenObject kitchenObject;

    public virtual void Interact(Player player) {
        Debug.LogError("BaseKicthenFurniture.Interact();");
    }

    public Transform GetKitchenObjectFollowTransform() {
        return furnitureTakePoint;
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
