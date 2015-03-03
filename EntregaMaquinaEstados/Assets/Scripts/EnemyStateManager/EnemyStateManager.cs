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
    private Transform _enemy_body_tr;
    public Transform enemy_body_tr {
        get { return _enemy_body_tr; }
    }

    [SerializeField]
    private Transform _enemy_target;
    public Transform enemy_target {
        get { return _enemy_target; }
    }

    [SerializeField]
    private Transform _waypoint_tr;
    public Transform waypoint_tr {
        get { return _waypoint_tr; }
    }

    [SerializeField]
    private GameObject _player;
    public GameObject player {
        get { return _player; }
    }

    [SerializeField]
    private Transform _gun;
    public Transform gun {
        get { return _gun; }
    }

    [SerializeField]
    private GameObject _ammo;
    public GameObject ammo {
        get { return _ammo; }
    }

    [SerializeField]
    private int _fire_rate;
    public int fire_rate {
        get { return _fire_rate; }
    }

    private NavMeshAgent _agent;
    public NavMeshAgent agent {
        get { return _agent; }
    }

    private float _initial_stoppingDistance;
    public float initial_stoppingDistance {
        get { return _initial_stoppingDistance; }
    }

    void Start () {
        _agent = GetComponent<NavMeshAgent>();

        startStates();
        startState();
        _initial_stoppingDistance = agent.stoppingDistance;
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

    public void startPatrol() {
        cur_state.startPatrol();
    }

    public void startDetected() {
        cur_state.startDetected();
    }
    
    public void startAttackRanged() {
        cur_state.startAttackRanged();
    }

    public void startAttackMelee() {
        cur_state.startAttackMelee();
    }
}
