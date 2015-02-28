using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class EnemyStateManager : MonoBehaviour, Context {
    private List<EnemyState> states;
    private EnemyState cur_state;
    private EnemyStateId cur_state_id;

    [SerializeField]
    private Transform _enemy_tr;
    public Transform enemy_tr {
        get { return _enemy_tr; }
    }

    [SerializeField]
    private Transform _enemy_target;
    public Transform enemy_target {
        get { return _enemy_target; }
    }

    [SerializeField]
    private Transform _nav_floor;
    public Transform nav_floor {
        get { return _nav_floor; }
    }

    [SerializeField]
    private GameObject _player;
    public GameObject player {
        get { return _player; }
    }

    private NavMeshAgent _agent;
    public NavMeshAgent agent {
        get { return _agent; }
    }

    void Start () {
        _agent = GetComponent<NavMeshAgent>();

        startStates();
        startState();
    }

    void Update () {
        cur_state.onUpdate();
    }

    public void updateState(EnemyStateId state) {
        cur_state.onLeave();
        cur_state = states[(int)state];
        cur_state.onEnter();
        cur_state_id = state;
    }

    void startState() {
        cur_state_id = EnemyStateId.PatrolState;
        cur_state = states[(int)cur_state_id];
        cur_state.onEnter();
    }

    void startStates() {
        string[] state_ids = Enum.GetNames(typeof(EnemyStateId));
        states = new List<EnemyState>();
        for (int i = 0; i < state_ids.Length ; i++) {
            object[] param = new [] { this };
            EnemyState parsedState = Activator.CreateInstance( Type.GetType(state_ids[i], true), param) as EnemyState;
            states.Add(parsedState);
        }
    }

    public EnemyStateId getCurStateId() {
        return cur_state_id;
    }
}
