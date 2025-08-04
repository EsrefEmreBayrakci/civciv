using UnityEngine;

public class stateController : MonoBehaviour
{
    private playerState currentState = playerState.idle;


    private void Start()
    {
        changeState(playerState.idle);
    }

    public void changeState(playerState newState)
    {
        if (currentState == newState) return;


        currentState = newState;
    }


    public playerState getState()
    {
        return currentState;
    }
}
