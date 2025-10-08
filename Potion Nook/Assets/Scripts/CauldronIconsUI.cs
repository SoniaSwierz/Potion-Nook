using UnityEngine;

public class CauldronIconsUI : MonoBehaviour
{

    [SerializeField] private Cauldron cauldron;
    [SerializeField] private Transform iconTemplate;

    private void Awake() {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        cauldron.OnIngredientAdded += Cauldron_OnIngredientAdded;
    }

    private void Cauldron_OnIngredientAdded(object sender, Cauldron.OnIngredientAddedEventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        foreach (Transform child in transform) {
            if (child == iconTemplate)
                continue;

            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in cauldron.GetKitchenObjectSOList()) {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<CauldronIconSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}
