using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float initSpeed;
    [SerializeField] private Vector3 initPos;


    private float enemySpeed;
    private Quaternion targetplus = Quaternion.Euler(0, 0, 10);
    private Quaternion targetminus = Quaternion.Euler(0, 0, -10);
    private float timeCountPlus =0;
    private float timeCountMinus = 0;
    private float timeCount = 0;
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
        enemySpeed = initSpeed;
    }

    private void StateChange(GameManager.GameState state)
    {
        if (state == GameManager.GameState.LoseGame) restartParams();
    }
    void FixedUpdate()
    {
       
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;      
        transform.Translate(transform.right * Time.deltaTime * enemySpeed);
        speedUp();
    }

    private void restartParams()
    {
        transform.position = initPos;
        enemySpeed = initSpeed;
    }

    private void speedUp()
    {
        if (enemySpeed >= 18) return;
        enemySpeed = 1.5f + Mathf.Round(transform.position.x) / 18;
    }

    }
