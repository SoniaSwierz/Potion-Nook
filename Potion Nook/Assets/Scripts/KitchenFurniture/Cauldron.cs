using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;


public class Cauldron : BaseKicthenFurniture
{

    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs {
        public KitchenObjectSO kitchenObjectSO;
    }


    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;
    private int cauldronCapacity = 6;


    private void Awake() {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO) {

        if (!validKitchenObjectSOList.Contains(kitchenObjectSO)) {
            // Not a valid ingredient
            return false;
        }

        if (kitchenObjectSOList.Count < cauldronCapacity) {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs {
                kitchenObjectSO = kitchenObjectSO
            });

            return true;
        } else {
            return false;
        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList() {
        return kitchenObjectSOList;
    }

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            //no kitchen object
            if (player.HasKitchenObject()) {
                //player is carrying something 
                if (TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
                    player.GetKitchenObject().DestroySelf();
                }
            } else {
                //player has nothing :(
            }
        } else {
            //there is a kitchen object here
            if (player.HasKitchenObject()) {
                //player is carrying something
            } else {
                //player is not carrying anything
                // GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
