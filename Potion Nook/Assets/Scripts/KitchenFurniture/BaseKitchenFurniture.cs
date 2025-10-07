using UnityEngine;

public class BaseKicthenFurniture : MonoBehaviour, IKitchenObjectParent {
    
 
    [SerializeField] private Transform furniturePoint;  
                                                       
    private KitchenObject kitchenObject;

    public virtual void Interact(Player player) {
        Debug.LogError("BaseKicthenFurniture.Interact();");
    }

    public virtual void InteractAlternate(Player player) {
        Debug.LogError("BaseKicthenFurniture.InteractAlternate();");
    }

    public virtual void SelectItemFromList(Player player, int keyNumber) {
        Debug.Log("BaseKicthenFurniture.SelectItemFromList();");
    }

    public Transform GetKitchenObjectFollowTransform() {
        return furniturePoint;
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
