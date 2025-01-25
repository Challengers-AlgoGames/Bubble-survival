using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartVisual : MonoBehaviour
{
    [SerializeField] List<GameObject> hearts;
    [SerializeField] Sprite emptyHeart;

    void Awake() {
        UIManager.OnStartGame += DisplayHearts;
    }

    void OnDestroy() {
        UIManager.OnStartGame -= DisplayHearts;
    }

    void DisplayHearts() {
        Debug.Log("DisplayHearts");
        for(int i = 0; i < hearts.Count ; i++) {
            hearts[i].SetActive(true);
        }
    }

    public void ReduceHearts()
    {
        for(int i = hearts.Count - 1; i >= 0; i--) {
            if (hearts[i].activeInHierarchy) {
                hearts[i].GetComponent<Image>().sprite = emptyHeart;
                hearts.RemoveAt(i);
                break;
            }
        }
    }
}