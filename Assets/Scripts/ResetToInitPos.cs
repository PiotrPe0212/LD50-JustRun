using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToInitPos : MonoBehaviour
{
    private Vector3 initPos;
    private void Awake()
    {
        GameManager.OnGameStateChange += StateChange;
 

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= StateChange;
    }
    void Start()
    {
        initPos = transform.position;
        
    }

 

    private void StateChange(GameManager.GameState state)
    {
        if (state != GameManager.GameState.LoseGame) return;
        transform.position = initPos;

    }
}
