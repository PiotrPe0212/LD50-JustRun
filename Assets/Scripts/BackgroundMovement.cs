using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float speedModifier;
    private float actualSpeed;
    private float prevPlayerSpeed = 0;
    private float playerPosX;
    private float prevPlayerPosX;

    void FixedUpdate()
    {
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        playerPosX = Mathf.Round(PlayerController.Instance.xPlayerPos*10)/10;
        print(playerPosX);
        if (prevPlayerPosX == playerPosX) return;
        float playerSpeed = PlayerController.Instance.playerSpeed;

        if (prevPlayerSpeed != playerSpeed)
        {
            actualSpeed = PlayerController.Instance.playerSpeed - speedModifier;
            prevPlayerSpeed = playerSpeed;
        }
        transform.Translate(transform.right * Time.deltaTime * actualSpeed);
        prevPlayerPosX = playerPosX;
    }
}
