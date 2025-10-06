using UnityEngine;

public class CuttingCounter : BaseKicthenFurniture {

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            //no kitchen object
            if (player.HasKitchenObject()) {
                //player is carrying something 
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                //player has nothing :(
            }
        } else {
            //there is a kitchen object here
            if (player.HasKitchenObject()) {
                //player is carrying something
            } else {
                //player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
