using UnityEngine;

public class SoapMotor : MonoBehaviour
{
    [SerializeField] BubbleProjections bubbleProjections;
    [SerializeField] BreathOfBubbles breathOfBubbles;

    public void Breath() {
        breathOfBubbles.Do();
    }

    public void JumpTo(Vector3 targetPosition) {
        bubbleProjections.Do();
    }
}
