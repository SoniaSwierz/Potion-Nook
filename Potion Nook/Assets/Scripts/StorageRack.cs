using UnityEngine;

public class StorageRack: BaseKicthenFurniture {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
  
    public override void Interact(Player player) {
       Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
       kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
    }

    
}
