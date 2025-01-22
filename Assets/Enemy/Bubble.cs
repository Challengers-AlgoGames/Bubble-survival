using UnityEngine;

/* Tire V1 (exploitable)
direction = transform.position.normalized;
transform.Translate(direction * Time.fixedDeltaTime * speed);
*/

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    
    void FixedUpdate()
    {
        transform.position += transform.position.normalized * Time.fixedDeltaTime * speed;
    }


}
