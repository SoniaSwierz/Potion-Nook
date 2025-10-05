using UnityEngine;

public class BaseKicthenFurniture : MonoBehaviour, IKitchenObjectParent {
    
 
    [SerializeField] private Transform furniturePoint;  //tu tez mozna potem zmieniac na tablice do ui regalu
                                                       
    private KitchenObject kitchenObject;

    public virtual void Interact(Player player) {
        Debug.LogError("BaseKicthenFurniture.Interact();");
    }

    public virtual void SelectItemFromList(Player player, int keyNumber) {
        Debug.LogError("BaseKicthenFurniture.SelectItemFromList();");
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
