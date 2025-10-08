using UnityEngine;

public class SelectedCuttingCounterVisual : SelectedFurnitureVisual {
   
    [SerializeField] private CuttingCounter cuttingCounter;
     private int visualGameObjectArraylen;


    private void Start() {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
        cuttingCounter.OnKnifeUp += CuttingCounter_OnKnifeUp;
        Player.Instance.OnSelectedFurnitureChanged += Player_OnSelectedFurnitureChanged;
        visualGameObjectArraylen = visualGameObjectArray.Length;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e) {
        visualGameObjectArray[visualGameObjectArraylen-1].SetActive(false);
    }
    private void CuttingCounter_OnKnifeUp(object sender, System.EventArgs e) {
        visualGameObjectArray[visualGameObjectArraylen-1].SetActive(false);
    }

    protected override void Player_OnSelectedFurnitureChanged(object sender, Player.OnSelectedFurnitureChangedEventArgs e) {
        if (e.selectedKitchenFurniture == kitchenFurniture) {
            Show();
        } else {
            Hide();
        }
    }
}
