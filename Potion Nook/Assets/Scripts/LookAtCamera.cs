using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    private void LateUpdate() {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(-20, 180, 0);
    }
}
