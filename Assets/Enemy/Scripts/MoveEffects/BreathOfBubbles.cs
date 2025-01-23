using System.Collections;
using UnityEngine;

public class BreathOfBubbles : MonoBehaviour, IMoveEffect
{
    [SerializeField] GameObject breathOfbubblesParticlepPrefab;

    public void Do() {
        StartCoroutine(Perform());
    }

    IEnumerator Perform() {
        breathOfbubblesParticlepPrefab.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        breathOfbubblesParticlepPrefab.SetActive(false);
    }
}
