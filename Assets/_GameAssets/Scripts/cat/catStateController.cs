using UnityEngine;

public class catStateController : MonoBehaviour
{
    [SerializeField] private catState currentCatState = catState.Walking;


    private void Start()
    {
        changeState(catState.Walking);
    }

    public void changeState(catState newState)
    {
        if (currentCatState == newState) { return; }
        currentCatState = newState;
    }

    public catState getCurrentState()
    {
        return currentCatState;
    }
}
