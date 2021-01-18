using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{ // posibles etados del juego
    menu,
    inGame,
    GameOver
}



public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState = GameState.menu; // variable para saber en que estado del juego se encuentra y empieza en el menu principal
    private void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        BackToMenu();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }
    public void GameOver()
    {
        SetGameState(GameState.GameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    public void SetGameState(GameState newGameState)// metodo encargado de cambiar el estado del juego
    {
        if (newGameState == GameState.menu)
        {
            //Hay que preparar la escena de unity para el menu
        }else if(newGameState == GameState.inGame)
        {
            //Hay que preparar la escena de unity para jugar
        }else if(newGameState == GameState.GameOver)
        {
            //Hay que preparar la escena de unity para perder
        }


        this.currentGameState = newGameState;
    }
}
