using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SoapMotor))]
public class SoapPattern : MonoBehaviour
{
    public enum SoapPatternType {
        BREATH, SPIN, SLIDE, JUMP
    }
    public enum State {
        PERFORMING, THINKING, IDLE
    }

    private SoapMotor soapMotor;
    private SoapPatternType currentPattern;
    private State action = State.IDLE;

    [SerializeField] private GameObject target;
    [SerializeField] private float decisionMakingTime = 1.0f;

    private bool isMakeDecision = false;
    private bool isPerform = false;

    void Start() {
        Debug.Log("SoapPattern Start");
        soapMotor = GetComponent<SoapMotor>();
        action = State.THINKING;
    }

    void FixedUpdate()
    {
        switch(action) {
            case State.THINKING:
                if (!isMakeDecision) {
                    StartCoroutine(MakeDecision());
                }
                break;
            case State.PERFORMING:
                if(!isPerform) {
                    DoPatternAction();
                }
                break;
            case State.IDLE:
                break;
        }
    }

    IEnumerator MakeDecision() {
        isMakeDecision = true;
        // Time make descision
        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
       
        Debug.Log("Thinking...");

        yield return new WaitForSeconds(decisionMakingTime);

        // BREATH pattern
        if(distanceToTarget <= 5f) {
            Debug.Log("Decide do BREATH");
            currentPattern = SoapPatternType.BREATH;
        }
        // SPIN pattern
        else if(distanceToTarget <= 10f && distanceToTarget > 5f) {
            Debug.Log("Decide do BREATH");
            currentPattern = SoapPatternType.SPIN;
        }
        // JUMP pattern
        else if (distanceToTarget <= 15f && distanceToTarget > 10f) {
            Debug.Log("Decide do BREATH");
            currentPattern = SoapPatternType.JUMP;
        }

        action = State.PERFORMING;
        isMakeDecision = false;
    }

    void DoPatternAction() {
        isPerform = true;

        Debug.Log("Performing...");

        switch(currentPattern) {
            case SoapPatternType.BREATH:
                soapMotor.Breath();
                break;
            case SoapPatternType.SPIN:
                soapMotor.Spin();
                break;
            case SoapPatternType.SLIDE:
                break;
            case SoapPatternType.JUMP:
                soapMotor.JumpTo(target.transform.position);
                break;
        }

        action = State.THINKING;
        isPerform =false;
        Debug.Log("Action done");
    }
}
