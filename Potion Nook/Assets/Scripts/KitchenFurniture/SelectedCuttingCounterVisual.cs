using UnityEngine;

public class SelectedCuttingCounterVisual : SelectedFurnitureVisual {
   
    [SerializeField] private CuttingCounter cuttingCounter;
    

    private void Start() {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
        cuttingCounter.OnKnifeUp += CuttingCounter_OnKnifeUp;
        cuttingCounter.OnKnifeDown += CuttingCounter_OnKnifeDown;
        Player.Instance.OnSelectedFurnitureChanged += Player_OnSelectedFurnitureChanged;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e) {
         Hide();
    }
    private void CuttingCounter_OnKnifeUp(object sender, System.EventArgs e) {
         Hide();
    }
    private void CuttingCounter_OnKnifeDown(object sender, System.EventArgs e) {
        Show();
    }

    protected override void Player_OnSelectedFurnitureChanged(object sender, Player.OnSelectedFurnitureChangedEventArgs e) {
        if (e.selectedKitchenFurniture == kitchenFurniture) {
            Show();
        } else {
            Hide();
        }
    }
}
