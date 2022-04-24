using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControll : MonoBehaviour
{
    [SerializeField] private AudioSource clickButton;
    public void PLayButtonClicked()
    {
        clickButton.Play();
        GameManager.Instance.GameStateUpdate(GameManager.GameState.PlayGame);
    }

    public void MainMenuButtonClicked()
    {
        clickButton.Play();
        GameManager.Instance.GameStateUpdate(GameManager.GameState.MainMenu);
    }

    public void ExitButtonClicked()
    {
        clickButton.Play();
        Application.Quit();
    }

}
