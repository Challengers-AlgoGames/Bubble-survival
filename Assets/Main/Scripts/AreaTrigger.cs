using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider) {
        if(collider.CompareTag("Bubble")) {
            Destroy(collider.gameObject);
        }
    }
}
