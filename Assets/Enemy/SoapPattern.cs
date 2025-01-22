using System;
using UnityEngine;

[RequireComponent(typeof(SoapMotor))]
public class SoapPattern : MonoBehaviour
{
    public enum SoapPatternType {
        BEATH, SPRIN, SLIDE, JUMP, PAUSE
    }
    [Serializable]
    public struct SoapPatternStruct {
        public SoapPatternType patternType;
        public int iteration;
    }

    private SoapMotor soapMotor;
    private SoapPatternType currentPattern;
    private int leftIteration;
    private bool readyNextIteration = false;
    public SoapPatternStruct[] soapPatterns = new SoapPatternStruct[] {
        new SoapPatternStruct { patternType = SoapPatternType.BEATH, iteration = 3 },
        new SoapPatternStruct { patternType = SoapPatternType.SPRIN, iteration = 1 },
        new SoapPatternStruct { patternType = SoapPatternType.SLIDE, iteration = 1 },
        new SoapPatternStruct { patternType = SoapPatternType.JUMP, iteration = 1 },
        new SoapPatternStruct { patternType = SoapPatternType.PAUSE, iteration = 1 }
    };

    void Awake() {
        soapMotor = GetComponent<SoapMotor>();
    }

    void Start() {
        currentPattern = soapPatterns[0].patternType;
        leftIteration = soapPatterns[0].iteration;
        soapMotor.DoCircleBubbleFormationMove();
    }

    void Update()
    {
        if(leftIteration > 0) {
            if(readyNextIteration) {
                Debug.Log("Ready for next move");
                soapMotor.DoCircleBubbleFormationMove();
                readyNextIteration = false;
                leftIteration--;
            }  
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Trigger Exit");
        if(collider.gameObject.tag == "Bubble") {
            collider.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            readyNextIteration = true;
        }
    }
}
