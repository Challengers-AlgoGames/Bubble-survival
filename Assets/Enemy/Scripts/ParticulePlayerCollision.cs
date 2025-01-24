using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit");

            PlayerHit();
        }
    }
    private void PlayerHit()
    {
        Debug.Log("event");
    }
}
