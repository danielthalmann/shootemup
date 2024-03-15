using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameState startState = GameState.introduction;

    public UnityEvent onIntroduction;
    public UnityEvent onPlay;
    public UnityEvent onFinishWave;
    public UnityEvent onStartBoss;
    public UnityEvent onBoss;
    public UnityEvent onFinishBoss;
    public UnityEvent onWin;
    public UnityEvent onLose;
    public UnityEvent onLeave;


    private GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(startState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {

        ChangeState(GameState.in_play);

    }

    public void Win()
    {

        ChangeState(GameState.win);

    }

    public void Lose()
    {

        ChangeState(GameState.lose);

    }

    public void Leave()
    {

        ChangeState(GameState.leave);

    }

    public void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.introduction:
                onIntroduction?.Invoke();
                break;
            case GameState.in_play:
                onPlay?.Invoke();
                break;
            case GameState.win:
                onWin?.Invoke();
                break;
            case GameState.lose:
                onLose?.Invoke();
                break;
            case GameState.start_boss:
                onStartBoss?.Invoke();
                break;
            case GameState.boss:
                onBoss?.Invoke();
                break;
            case GameState.finish_boss:
                onFinishBoss?.Invoke();
                break;
            case GameState.leave:
                onLeave?.Invoke();
                break;
            default:
                throw(new System.Exception("invalid state"));
        }
        currentState = startState;
    }
}

public enum GameState
{
    introduction,
    in_play,
    start_boss,
    boss,
    finish_boss,
    win,
    lose,
    leave

}
