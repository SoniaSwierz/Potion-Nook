using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StorageRack: BaseKicthenFurniture {

    [SerializeField] private KitchenObjectSO[] kitchenObjectSO;
    [SerializeField] private Image[] ingredientsOptionsImages;

    public void Start() {
        int i = 0;
        foreach (Image image in ingredientsOptionsImages) {
            if (image != null) {
                image.sprite = kitchenObjectSO[i].sprite;
                i++;
            }
            else {
                Debug.LogError("Array element set to none");
            }
        }
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
