using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private AIBrain _brain;
    [SerializeField]
    private List<AIAction> actions;
    [SerializeField]
    private List<AITransition> transitions;

    private void Awake()
    {
        _brain = transform.parent.parent.GetComponent<AIBrain>();
    }

    public void UpdateState()
    {
        foreach(AIAction action in actions)
        {
            action.TakeAction();
        }

        foreach(AITransition tr in transitions)
        {
            bool result = false;
            foreach(AIDecision d in tr.decisions)
            {
                result = d.MakeADecisions();
                if (result == false) break;
            }

            if(result == true)
            {
                if(tr.positiveState != null)
                {
                    _brain.ChangeState(tr.positiveState);
                    return;
                }
            }
            else
            {
                if (tr.negativeState != null)
                {
                    _brain.ChangeState(tr.negativeState);
                    return;
                }
            }
        }
    }

}
