using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuCanvas;
    [SerializeField]
    private GameObject LoseCanvas;
    public static GameManager Instance;

    public GameState State;
    public static event Action<GameState> OnGameStateChange;

    private void Awake()
    {
        Instance = this;        
    }
    void Start()
    {
        GameStateUpdate(State);
    }

    public void GameStateUpdate(GameState newState)
    {
        State = newState;
        
        switch (newState)
        {
            case GameState.MainMenu:
                MenuCanvas.SetActive(true);
                LoseCanvas.SetActive(false);
                break;
            case GameState.PlayGame:
                MenuCanvas.SetActive(false);
                LoseCanvas.SetActive(false);
                break;
            case GameState.LoseGame:
                LoseCanvas.SetActive(true);
                break;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChange?.Invoke(newState);
        print(newState);
    }
    

public enum GameState { 
    MainMenu,
    PlayGame,
    LoseGame
    
    }

    

}
