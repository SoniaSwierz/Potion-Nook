using Unity.VisualScripting;
using UnityEngine;

public class TrashCounter : BaseKicthenFurniture {

    public override void Interact(Player player) {
        if (player.HasKitchenObject()) {
            player.GetKitchenObject().DestroySelf();
        }
    }
}
