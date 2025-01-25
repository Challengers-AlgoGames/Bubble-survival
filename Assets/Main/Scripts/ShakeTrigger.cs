using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    public CameraManager cameraManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(cameraManager.Shake(0.5f, 0.3f));
        }
    }
}
