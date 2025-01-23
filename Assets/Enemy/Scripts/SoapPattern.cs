using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SoapMotor))]
public class SoapPattern : MonoBehaviour
{
    public enum SoapPatternType {
        BREATH, SPIN, SLIDE, JUMP
    }
    public enum State {
        PERFORMING, THINKING
    }

    private SoapMotor soapMotor;
    private SoapPatternType currentPattern;
    private State action = State.THINKING;

    [SerializeField] private GameObject target;
    [SerializeField] private float decisionMakingTime = 2f;
    [SerializeField] private float decisionMakingTimeModifier = 2f;

    private bool isMakeDecision = false;
    private bool isPerform = false;

    void Awake() {
        soapMotor = GetComponent<SoapMotor>();
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
        }
    }

    IEnumerator MakeDecision() {
        isMakeDecision = true;
        // Time make descision
        float thinkTime = decisionMakingTime;
        float random = Random.Range(0f, 1f);
        if(random < 0.25f || random > 0.75f) {
            thinkTime*=decisionMakingTimeModifier;
        }
        yield return new WaitForSeconds(thinkTime);

        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        // BREATH pattern
        if(distanceToTarget <= 5f) {
            currentPattern = SoapPatternType.BREATH;
        }
        // SPIN pattern
        else if(distanceToTarget <= 10f && distanceToTarget > 5f) {
            currentPattern = SoapPatternType.SPIN;
        }
        // JUMP pattern
        else if (distanceToTarget <= 15f && distanceToTarget > 10f) {
            currentPattern = SoapPatternType.JUMP;
        }
        // SLIDE pattern
        else if(distanceToTarget > 15f) {
            currentPattern = SoapPatternType.SLIDE;
        }

        action = State.PERFORMING;
        isMakeDecision = false;
    }

    void DoPatternAction() {
        isPerform = true;

        switch(currentPattern) {
            case SoapPatternType.BREATH:
                soapMotor.Breath();
                break;
            case SoapPatternType.SPIN:
                break;
            case SoapPatternType.SLIDE:
                break;
            case SoapPatternType.JUMP:
                soapMotor.JumpTo(target.transform.position);
                break;
        }

        action = State.THINKING;
        isPerform =false;
    }
}
