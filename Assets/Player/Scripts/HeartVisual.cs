using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartVisual : MonoBehaviour
{
    [SerializeField] public Sprite emptyHeartSprite; // Sprite pour un cœur vide
    [SerializeField] public Sprite fullHeartSprite;  // Sprite pour un cœur plein

    private List<HeartImage> heartImageList; // Liste pour stocker les cœurs

    private void Start()
    {
        heartImageList = new List<HeartImage>();

        // Initialiser avec 3 cœurs pleins
        AddHeart(new Vector2(100, 350), 0);
        AddHeart(new Vector2(120, 350), 0);
        AddHeart(new Vector2(140, 350), 0);
    }

    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Simule des dégâts avec la touche Espace
        {
            FindObjectOfType<HeartVisual>().TakeDamage(1); // Enlever un cœur
        }
    }

    private void AddHeart(Vector2 position, int fragments)
    {
        HeartImage heart = CreateHeartImage(position);
        heartImageList.Add(heart);
        heart.SetHeart(fragments); // Initialiser l'état du cœur
    }

    private HeartImage CreateHeartImage(Vector2 position)
    {
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        heartGameObject.transform.SetParent(this.transform, false);

        RectTransform rectTransform = heartGameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(20, 20);

        Image heartImage = heartGameObject.GetComponent<Image>();
        heartImage.sprite = fullHeartSprite;

        return new HeartImage(this, heartImage);
    }

    // Méthode pour gérer les dégâts
    public void TakeDamage(int damageAmount)
    {
        // Parcourir les cœurs pour appliquer les dégâts
        for (int i = 0; i < damageAmount; i++)
        {
            // Trouver le premier cœur plein et le vider
            for (int j = heartImageList.Count - 1; j >= 0; j--)
            {
                if (heartImageList[j].IsFull())
                {
                    heartImageList[j].SetHeart(1); // 1 = Cœur vide
                    break;
                }
            }
        }
    }
    public void Heal(int healAmount)
    {
        // Parcourir les cœurs pour appliquer les dégâts
        for (int i = 0; i < healAmount; i++)
        {
            // Trouver le premier cœur plein et le vider
            for (int j = 0; j < heartImageList.Count; j++)
            {
                if (!heartImageList[j].IsFull())
                {
                    heartImageList[j].SetHeart(0); // 0 = Cœur Full
                    break;
                }
            }
        }
    }
}

public class HeartImage
{
    private Image heartImage;
    private HeartVisual heartVisual;
    private bool isFull; // État du cœur

    public HeartImage(HeartVisual heartVisual, Image heartImage)
    {
        this.heartVisual = heartVisual;
        this.heartImage = heartImage;
        isFull = true; // Par défaut, le cœur est plein
    }

    public void SetHeart(int fragments)
    {
        if (heartImage == null || heartVisual == null)
        {
            Debug.LogError("HeartImage or HeartVisual is null!");
            return;
        }

        switch (fragments)
        {
            case 0:
                heartImage.sprite = heartVisual.fullHeartSprite;
                isFull = true; // Cœur plein
                break;
            case 1:
                heartImage.sprite = heartVisual.emptyHeartSprite;
                isFull = false; // Cœur vide
                break;
            default:
                Debug.LogWarning("Invalid fragment value. Expected 0 or 1.");
                break;
        }
    }

    public bool IsFull()
    {
        return isFull; // Retourne si le cœur est plein
    }
}
