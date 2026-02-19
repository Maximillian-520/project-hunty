using System;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private BaseState initialState;
    [SerializeField] private List<BaseState> stateList;

    private BaseState currentState;
    private Dictionary<string, BaseState> stateDictionary = new Dictionary<string, BaseState>();

    private void Start()
    {
        // Check state list
        if (stateList.Count == 0)
        {
            Debug.Log("State list is empty");
            return;
        }
        // Map all state
        foreach (BaseState state in stateList)
        {
            // Check key
            if (state.stateKey == "")
            {
                Debug.Log("State key is empty");
                continue;
            }
            if (stateDictionary.ContainsKey(state.stateKey))
            {
                Debug.Log("State key has duplicate");
                continue;
            }
            // Add key to dictionary
            stateDictionary.Add(state.stateKey, state);
        }
        // Check initial state
        if (!initialState)
        {
            Debug.Log("Initial state is empty, first state in state list is set as initial state");
            initialState = stateList[0];
        }
        if (!stateDictionary.ContainsKey(initialState.stateKey))
        {
            Debug.Log("Initial state is not mapped, first state in state list is set as initial state");
            initialState = stateList[0];
        }
        // Set initial state
        currentState = initialState;
        currentState.EnterState();
    }

    private void Update()
    {
        if(currentState) currentState.UpdateState();
    }

    private void FixedUpdate()
    {
        if(currentState) currentState.FixedUpdateState();
    }

    public void ChangeState(string newStateKey)
    {
        // Check if can change state
        if(newStateKey == GetCurrentStateKey()) return;
        if(!stateDictionary.ContainsKey(newStateKey))
        {
            Debug.Log("Change to a state that does not exist");
            return;
        }
        // Change state
        if (currentState) currentState.ExitState();
        currentState = stateDictionary[newStateKey];
        currentState.EnterState();
    }

    public string GetCurrentStateKey()
    {
        return currentState.stateKey;
    }
}