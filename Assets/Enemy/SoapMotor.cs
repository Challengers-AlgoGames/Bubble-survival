using UnityEngine;
using System.Collections;

public class SoapMotor : MonoBehaviour
{
    [SerializeField] 
    private GameObject bubblePrefab;

    void Awake() {
        bubblePrefab.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void DoCircleBubbleFormationMove() {
        // StartCoroutine(PerformCircleBubbleFormationMove());
        int bubbles = 12;
        float radius = 1f;
        CircleFormation(bubbles, radius);
    }

    GameObject[] CircleFormation(int numberOfObjects, float radius) {
        GameObject[] instantiatedObject = new GameObject[numberOfObjects];

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Debug.Log("angle: "+angle*Mathf.Rad2Deg);
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector3 position = transform.position + new Vector3(x, y, 0);
            float angleDegrees = -angle*Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angleDegrees);
            instantiatedObject[i] = Instantiate(bubblePrefab, position, rotation);
            
            if(i == 0) {
                instantiatedObject[i].GetComponent<CircleCollider2D>().enabled = true;
            }
        }

        return instantiatedObject;
    }
}
