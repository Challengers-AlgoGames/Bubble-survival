using System.Collections;
using UnityEngine;

public class SoapMotor : MonoBehaviour
{
    [SerializeField] BubbleProjections bubbleProjections;
    [SerializeField] BreathOfBubbles breathOfBubbles;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float spinTime = 1.5f;

    private Vector3 impactPoint = Vector3.zero;
    private Vector3 outOfSceen = new Vector3(0, 12, 0);
    private bool isOutIfSceen = false;

    private bool spin = false;

    void FixedUpdate()
    {
        if (impactPoint != Vector3.zero) {
           performJump();
        }

        if (spin) {
            PerformSpin();
        }
    }

    public void Breath() {
        breathOfBubbles.Do();
    }

    public void JumpTo(Vector3 targetPosition) {
        if (impactPoint == Vector3.zero)
        {
            impactPoint = targetPosition;
        }
    }

    void performJump() {
        float speed = jumpSpeed * 2f;

        if (isOutIfSceen)
        {
            transform.position = Vector3.MoveTowards(transform.position, impactPoint, speed * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, impactPoint) < 0.1f)
            {
                bubbleProjections.Do();
                impactPoint = Vector3.zero;
                isOutIfSceen = false;
                StartCoroutine(cameraManager.Shake(0.5f, 0.3f));
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, outOfSceen, speed * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, outOfSceen) < 0.1f)
                isOutIfSceen = true;
        }
    }

    public void Spin() {
        spin = true;
        StartCoroutine(SpinFor(1.5f));
    }

    void PerformSpin() {
        // 360 * 3 -> 1080 -> 3 round
        transform.Rotate(new Vector3(0, 0, 1), 1080f * Time.fixedDeltaTime / spinTime);
    }

    IEnumerator SpinFor(float time) {
        yield return new WaitForSeconds(time);
        spin = false;
    }
}
