using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StorageRack: BaseKicthenFurniture {

    [SerializeField] private KitchenObjectSO[] kitchenObjectSO;

    public void Start() {
    }

    public override void Interact(Player player) {
        if(!player.HasKitchenObject()) {
            //player is not carrying anything
        }
    }

    public override void SelectItemFromList(Player player, int keyNumber) {
        if (!player.HasKitchenObject()) {
            //player is not carrying anything
            if (keyNumber <= kitchenObjectSO.Length) {
                KitchenObject.SpawnKitchenObject(kitchenObjectSO[keyNumber - 1], player);
            }
        }
    }
}
