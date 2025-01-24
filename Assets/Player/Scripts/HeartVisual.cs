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
        AddHeart(1, 0);
        AddHeart(2, 0);
        AddHeart(3, 0);
    }

    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Simule des dégâts avec la touche Espace
        {
            FindObjectOfType<HeartVisual>().TakeDamage(1); // Enlever un cœur
        }
    }


    private void AddHeart(int index, int fragments)
    {
        float spacing = 25f; // Espacement entre les cœurs
        float startX = -Screen.width / 3 + spacing;
        float startY = Screen.height + 50;

        Vector2 position = new Vector2(startX + index * spacing, startY);

        HeartImage heart = CreateHeartImage(position);
        heartImageList.Add(heart);
        heart.SetHeart(fragments); // Initialise le cœur avec le niveau de fragment donné
    }

    private HeartImage CreateHeartImage(Vector2 position)
    {
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        heartGameObject.transform.SetParent(this.transform, false);

        RectTransform rectTransform = heartGameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(30, 30);

        Image heartImage = heartGameObject.GetComponent<Image>();
        heartImage.sprite = fullHeartSprite;

        return new HeartImage(this, heartImage);
    }

    // Méthode pour gérer les dégâts
    public void TakeDamage(int damageAmount)
    {
        int damageApplied = 0;
        for (int i = heartImageList.Count - 1; i >= 0; i--)
        {
            if (damageApplied >= damageAmount) break;
            if (heartImageList[i].IsFull())
            {
                heartImageList[i].SetHeart(1); // 1 = Cœur vide
                damageApplied++;
            }
        }
    }
    public void Heal(int healAmount)
    {
        int healApplied = 0;
        for (int i = 0; i < heartImageList.Count; i++)
        {
            if (healApplied >= healAmount) break;
            if (!heartImageList[i].IsFull())
            {
                heartImageList[i].SetHeart(0); // 0 = Cœur plein
                healApplied++;
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
