using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIBrain : MonoBehaviour
{
    [SerializeField] AIState currentState;


    public void ChangeState(AIState state)
    {
        currentState = state;
    }
}
