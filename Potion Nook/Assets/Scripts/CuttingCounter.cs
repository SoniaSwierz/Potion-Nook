using UnityEngine;

public class CuttingCounter : BaseKicthenFurniture {

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

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

    public override void InteractAlternate(Player player) {
        if(HasKitchenObject()) {
            //there is a KicthenObject here
            KitchenObjectSO outputGetKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputGetKitchenObjectSO, this);
        }
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSo) {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray) {
            if(cuttingRecipeSO.input == inputKitchenObjectSo) {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
}
