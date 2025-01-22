using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector3 direction;

    void Start() {
        direction = transform.position;
    }
    
    void FixedUpdate()
    {
        transform.Translate(direction * Time.fixedDeltaTime * speed);
    }
}
