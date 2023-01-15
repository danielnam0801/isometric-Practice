using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    private AIActionData actionData;
    private AIMovementData movementData;
    private AIBrain _aiBrain;

    private void Awake()
    {
        _aiBrain = transform.parent.parent.parent.GetComponent<AIBrain>();
        actionData = _aiBrain.transform.Find("AI").GetComponent<AIActionData>();
        movementData = _aiBrain.transform.Find("AI").GetComponent<AIMovementData>();
    }

    public abstract bool MakeADecisions();
}
