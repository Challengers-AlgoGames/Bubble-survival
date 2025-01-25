using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // Utilise une plage correcte pour les valeurs aléatoires
            float offsetX = Random.Range(-1f, 1f) * magnitude; // Génère des offsets positifs ou négatifs
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null; // Attend la prochaine frame
        }

        // Réinitialise la position originale de la caméra
        transform.localPosition = originalPosition;
    }
}
