using System.Threading;
using UnityEngine;

public class SoapMotor : MonoBehaviour
{
    [SerializeField] BubbleProjections bubbleProjections;
    [SerializeField] BreathOfBubbles breathOfBubbles;
    [SerializeField] float jumpSpeed = 5f;

    private Vector3 jupmTargetPosition = Vector3.zero;

    void FixedUpdate() {
        if(jupmTargetPosition != Vector3.zero) {
            transform.position = Vector3.MoveTowards(transform.position, jupmTargetPosition, jumpSpeed);
            if(Vector3.Distance(transform.position, jupmTargetPosition) < 0.1f) {
                jupmTargetPosition = Vector3.zero;
                bubbleProjections.Do();
            }
        }
    }

    public void Breath() {
        breathOfBubbles.Do();
    }

    public void JumpTo(Vector3 targetPosition) {
        jupmTargetPosition = targetPosition;
        Thread.Sleep(2000);
    }
}
