using UnityEngine;

public class StorageRack: BaseKicthenFurniture {

    [SerializeField] private KitchenObjectSO[] kitchenObjectSO;   //tu sie zrobi tablice jak bedzie ui
                                                                // do wybierania rzeczy z regalu
    public override void Interact(Player player) {
        if(!player.HasKitchenObject()) {
            //player is not carrying anything
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO[0].prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
    }

    public override void SelectItemFromList(Player player, int keyNumber) {
        if (!player.HasKitchenObject()) {
            //player is not carrying anything
            Debug.Log(keyNumber);
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO[keyNumber - 1].prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
    }
}
