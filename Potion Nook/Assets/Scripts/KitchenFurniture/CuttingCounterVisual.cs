using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour {

    private const string CUT = "Cut";
    private const string KNIFE_UP = "KnifeUp";
    private const string KNIFE_DOWN = "KnifeDown";

    [SerializeField] private CuttingCounter cuttingCounter;

    private Animator animator;

    private void Awake() {
       animator = GetComponent<Animator>();
    }

    private void Start() {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
        cuttingCounter.OnKnifeUp += CuttingCounter_OnKnifeUp;
        cuttingCounter.OnKnifeDown += CuttingCounter_OnKnifeDown;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e) {
        animator.SetTrigger(CUT);
    }

    private void CuttingCounter_OnKnifeUp(object sender, System.EventArgs e) {
        animator.SetTrigger(KNIFE_UP);
    }

    private void CuttingCounter_OnKnifeDown(object sender, System.EventArgs e) {
        animator.SetTrigger(KNIFE_DOWN);
    }
}
