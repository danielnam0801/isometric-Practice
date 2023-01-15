using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    private AIActionData actionData;
    private AIMovementData movementData;
    private AIBrain _aiBrain;

    private void Awake()
    {
        actionData = transform.parent.GetComponent<AIActionData>();
        movementData = transform.parent.GetComponent<AIMovementData>();
        _aiBrain = transform.parent.parent.GetComponent<AIBrain>();
    }

    public abstract void TakeAction();
}
