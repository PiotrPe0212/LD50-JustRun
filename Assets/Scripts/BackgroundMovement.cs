using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float speedModifier;
    private float actualSpeed;


    void FixedUpdate()
    {
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        if (PlayerController.Instance.notMoving) return;
            actualSpeed = PlayerController.Instance.playerSpeed - speedModifier; 
        transform.Translate(transform.right * Time.deltaTime * actualSpeed);
        
    }
}
