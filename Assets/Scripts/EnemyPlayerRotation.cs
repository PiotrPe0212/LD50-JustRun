using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerRotation : MonoBehaviour
{
    [SerializeField] private Quaternion targetPlus;
    [SerializeField] private Quaternion targetMinus;
    [SerializeField] private float TimerControler;
    [SerializeField] private bool isItPlayer;
    private float timeCountPlus = 0;
    private float timeCountMinus = 0;
    

     void FixedUpdate()
    {
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        if (isItPlayer && PlayerController.Instance.notMoving) {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            return;
        }
     
        rotatingFunction();
    }
    private void rotatingFunction()
    {
        
      
        if (timeCountPlus < 1)
        {
            timeCountPlus += Time.deltaTime*TimerControler;
            transform.rotation = Quaternion.Slerp(targetMinus, targetPlus, timeCountPlus);
            timeCountMinus = 0;
        }
        else
        {
            timeCountMinus += Time.deltaTime*TimerControler;
            transform.rotation = Quaternion.Slerp(targetPlus, targetMinus, timeCountMinus);
            if (timeCountMinus >= 1) timeCountPlus = 0;
        }



    }
}
