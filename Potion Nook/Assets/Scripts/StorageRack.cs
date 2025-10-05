using UnityEngine;

public class StorageRack: BaseKicthenFurniture {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;   //tu sie zrobi tablice jak bedzie ui
                                                                // do wybierania rzeczy z regalu
    public override void Interact(Player player) {
        if(!player.HasKitchenObject()) {
            //player is not carrying anything
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
    }
}
