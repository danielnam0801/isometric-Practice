using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIBrain : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent<Vector2> AttackAndChaseStateChanged;
    public UnityEvent<Vector2,Vector2> IdleStateStateChanged;
    public UnityEvent OnFireButtonPress;
    
    [SerializeField]
    private AIState _currentState;

    [SerializeField]
    private Transform _target;
    public Transform Target
    {
        get => _target;
    }

    private AIActionData _aiActionData;
    public AIActionData AIActionData { get => _aiActionData; }

    private AIMovementData _aimovementData;
    public AIMovementData AIMovementData { get => _aimovementData; }

    IsoMetricEnemy enemy;
    public IsoMetricEnemy Enemy => enemy;

    protected virtual void Start()
    {
        _target = GameObject.Find("Player_Isometric_Witch").transform;
        _aiActionData = transform.Find("AI").GetComponent<AIActionData>();
        _aimovementData = transform.Find("AI").GetComponent<AIMovementData>();
        enemy = transform.GetComponent<IsoMetricEnemy>();
    }

    protected void Update()
    {
        if(_target == null)
        {
            OnMovementKeyPress?.Invoke(Vector2.zero);
            return;
        }
        else
        {
            _currentState.UpdateState();
        }
    }

    public void ChangeState(AIState state)
    {
        Debug.Log(state.ToString());
        _currentState = state;
    }

    public void Move(Vector2 direction, Vector3 targetPos)
    {
        OnMovementKeyPress?.Invoke(direction);
        if (!_aiActionData.isIdle)
                AttackAndChaseStateChanged?.Invoke(targetPos);
        else
            IdleStateStateChanged?.Invoke(_aimovementData.direction, _aimovementData.beforeDirection);
    }

    public virtual void Attack()
    {
        OnFireButtonPress?.Invoke();
    }
}
