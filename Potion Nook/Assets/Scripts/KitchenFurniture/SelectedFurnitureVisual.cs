using UnityEngine;

public class SelectedFurnitureVisual : MonoBehaviour {


    [SerializeField] protected BaseKicthenFurniture kitchenFurniture;
    [SerializeField] protected GameObject[] visualGameObjectArray;


    private void Start() {
        Player.Instance.OnSelectedFurnitureChanged += Player_OnSelectedFurnitureChanged;
    }


    protected virtual void Player_OnSelectedFurnitureChanged(object sender, Player.OnSelectedFurnitureChangedEventArgs e) {
        if (e.selectedKitchenFurniture == kitchenFurniture) {
            Show();
        } else {
            Hide();
        }
    }

    protected void Show() {
        foreach (GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(true);
        }
    }

    protected void Hide() {
        foreach (GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(false);
        }
    }
}
