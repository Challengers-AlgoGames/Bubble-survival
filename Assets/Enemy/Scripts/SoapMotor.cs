using UnityEngine;

public class SoapMotor : MonoBehaviour
{
    [SerializeField] BubbleProjections bubbleProjections;
    [SerializeField] BreathOfBubbles breathOfBubbles;
    [SerializeField] float jumpSpeed = 10f;

    private Vector3 impactPoint = Vector3.zero;
    private Vector3 outOfSceen = new Vector3(0, 12, 0);
    private bool isOutIfSceen = false;

    void FixedUpdate() {
        
        if(impactPoint != Vector3.zero) 
        {
            float speed = jumpSpeed*2f;

            if(isOutIfSceen) 
            {
                transform.position = Vector3.MoveTowards(transform.position, impactPoint, speed * Time.fixedDeltaTime);
                if(Vector3.Distance(transform.position, impactPoint) < 0.1f) 
                {
                    bubbleProjections.Do();
                    impactPoint = Vector3.zero;
                    isOutIfSceen = false;
                }
            } 
            else 
            {
                transform.position = Vector3.MoveTowards(transform.position, outOfSceen, speed * Time.fixedDeltaTime);
                if(Vector3.Distance(transform.position, outOfSceen) < 0.1f) 
                    isOutIfSceen = true;
            }
        }
    }

    public void Breath() {
        breathOfBubbles.Do();
    }

    public void JumpTo(Vector3 targetPosition) {
        if(impactPoint == Vector3.zero) {
            impactPoint = targetPosition;
        }
    }
}
