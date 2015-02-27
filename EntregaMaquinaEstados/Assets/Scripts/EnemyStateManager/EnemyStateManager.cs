using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class EnemyStateManager : MonoBehaviour {
    private Hashtable states = new Hashtable();
    private EnemyState cur_state;
    private string cur_state_string = "Patrol";

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

    void startStates() {
        // object[] param = new [] {this};
        // EnemyState parsedState = newActivator.CreateInstance( Type.GetType(PatrolState, true), param) as EnemyState;
        states.Add("Patrol", new PatrolState(this));
    }

    public void updateState(String state) {
        cur_state.onLeave();
        cur_state_string = state;
        startState();
    }

    void startState() {
        Debug.Log(cur_state_string);
        cur_state = (EnemyState)states[cur_state_string];

        cur_state.onEnter();
    }

    public string getCurState() {
        return cur_state_string;
    }
}
