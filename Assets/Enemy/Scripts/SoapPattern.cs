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
    [SerializeField] private float patternIntervalTime = 5f;
    [SerializeField] private float patternIntervalTimeModifier = 2f;

    private bool isPerforming = false;

    void Awake() {
        soapMotor = GetComponent<SoapMotor>();
    }

    void FixedUpdate()
    {
        switch(action) {
            case State.THINKING:
                MakeDecision();
                action = State.PERFORMING;
                break;
            case State.PERFORMING:
                if (!isPerforming) {
                    StartCoroutine(DoPatternAction());
                }
                break;
        }
    }

    void MakeDecision() {
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
    }

    void PerformPatternAction() {
        switch(currentPattern) {
            case SoapPatternType.BREATH:
                soapMotor.Breath();
                break;
            case SoapPatternType.SPIN:
                break;
            case SoapPatternType.SLIDE:
                break;
            case SoapPatternType.JUMP:
                break;
        }

        action = State.THINKING;
    }

    IEnumerator DoPatternAction() {
        // Randomize pattern interval time
        isPerforming = true;

        float intervalTime = patternIntervalTime;
        float random = Random.Range(0f, 1f);
        if(random < 0.25f || random > 0.75f) {
            intervalTime*=patternIntervalTimeModifier;
        }

        yield return new WaitForSeconds(intervalTime);

        PerformPatternAction();
        isPerforming = false;
    }
}
