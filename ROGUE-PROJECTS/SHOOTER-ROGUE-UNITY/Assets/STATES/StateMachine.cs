using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    State currentState;

    public void NextState(State state)
    {
        currentState?.OnExit();
        currentState = state;
        currentState?.InStart();
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.InUpdate(Time.deltaTime);
    }
}
