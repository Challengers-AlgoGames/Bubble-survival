using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SoapMotor))]
public class SoapPattern : MonoBehaviour
{
    public enum SoapPatternType {
        BEATH, SPIN, SLIDE, JUMP
    }

    private SoapMotor soapMotor;
    private SoapPatternType currentPattern;
    private bool readyForAction = false;

    [SerializeField] private GameObject target;
    [SerializeField] private float patternIntervalTime = 5f;
    [SerializeField] private float patternIntervalTimeModifier = 2f;

    void Awake() {
        soapMotor = GetComponent<SoapMotor>();
    }

    void Update()
    {
        if(readyForAction) {
            StartCoroutine(DoPatternAction());
        }
        else {
            MakeDecision();
        }
    }

    void MakeDecision() {
        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        // BREATH pattern
        if(distanceToTarget <= 5f) {
            currentPattern = SoapPatternType.BEATH;
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
        readyForAction = true;
    }

    void PerformPatternAction() {
        switch(currentPattern) {
            case SoapPatternType.BEATH:
                soapMotor.Breath();
                break;
            case SoapPatternType.SPIN:
                Debug.Log("SPIN");
                break;
            case SoapPatternType.SLIDE:
                Debug.Log("SLIDE");
                break;
            case SoapPatternType.JUMP:
                Debug.Log("JUMP");
                break;
        }
    }

    IEnumerator DoPatternAction() {
        // Randomize pattern interval time
        float intervalTime = patternIntervalTime;
        float random = Random.Range(0f, 1f);
        if(random < 0.125f) {
            intervalTime/=patternIntervalTimeModifier;
        }
        else if(random > 0.875f) {
            intervalTime*=patternIntervalTimeModifier;
        }
        yield return new WaitForSeconds(intervalTime);
        PerformPatternAction();
        readyForAction = false; //
    }
}
