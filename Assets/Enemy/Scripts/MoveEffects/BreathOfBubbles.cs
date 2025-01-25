using System.Collections;
using UnityEngine;

public class BreathOfBubbles : MonoBehaviour, IMoveEffect
{
    [SerializeField] GameObject breathOfbubblesParticlepPrefab;
    [SerializeField] float duration = 3f;

    public void Do() {
        if(!breathOfbubblesParticlepPrefab.activeSelf) {
            StartCoroutine(Perform());
        }
    }

    IEnumerator Perform() {
        breathOfbubblesParticlepPrefab.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        breathOfbubblesParticlepPrefab.SetActive(false);
    }
}
