using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControll : MonoBehaviour
{
    public void PLayButtonClicked()
    {
        GameManager.Instance.GameStateUpdate(GameManager.GameState.PlayGame);
    }

    public void MainMenuButtonClicked()
    {
       GameManager.Instance.GameStateUpdate(GameManager.GameState.MainMenu);
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }

}
