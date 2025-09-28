using System;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private catStateController catStateController;

    private PlayableDirector director;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();

    }

    void Start()
    {
        catStateController = catStateController.GetComponent<catStateController>();
    }

    [Obsolete]
    void OnEnable()
    {
        director.Play();
        gameManager.changeGameState(gameState.cutScene);
        catStateController.changeState(catState.Idle);
        director.stopped += OnPlayableDirectorStopped;

    }

    [Obsolete]
    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        if (GameManager.Instance.currentGameState != gameState.pause)
        {
            gameManager.changeGameState(gameState.play);
        }
    }
}
