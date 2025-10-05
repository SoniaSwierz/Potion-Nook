using UnityEngine;

public class SelectedFurnitureVisual : MonoBehaviour {


    [SerializeField] private BaseKicthenFurniture kitchenFurniture;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start() {
        Player.Instance.OnSelectedFurnitureChanged += Player_OnSelectedFurnitureChanged;
    }

    private void Player_OnSelectedFurnitureChanged(object sender, Player.OnSelectedFurnitureChangedEventArgs e) {
        if (e.selectedKitchenFurniture == kitchenFurniture) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        foreach (GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide() {
        foreach (GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(false);
        }
    }
}
