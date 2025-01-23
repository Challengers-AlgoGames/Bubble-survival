using System.Collections;
using UnityEngine;

public class BubbleProjections : MonoBehaviour, IMoveEffect
{
    [SerializeField] GameObject bubblePrefab;

    public void Do() {
        StartCoroutine(Perform());
    }

    IEnumerator Perform() {
        int bubbles = 12;
        float radius = 1f;
        int projectionsIteration = 3;
        float projectionsIterationIntervalTime = 0.25f;

        for(int i = 0; i < projectionsIteration; i++) {
            CircleFormation(bubbles, radius);
            yield return new WaitForSeconds(projectionsIterationIntervalTime);
        }
    }

    void CircleFormation(int numberOfObjects, float radius) {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector3 position = transform.position + new Vector3(x, y, 0);
            float angleDegrees = -angle*Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angleDegrees);
            Instantiate(bubblePrefab, position, rotation);
        }
    }
}
