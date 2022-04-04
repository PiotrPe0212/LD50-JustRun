using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float initSpeed;
    [SerializeField] private Vector3 initPos;

    public static PlayerController Instance;
    public float xPlayerPos;
    public float playerSpeed;
    private Quaternion targetplus = Quaternion.Euler(0, 0, 10);
    private Quaternion targetminus = Quaternion.Euler(0, 0, -10);
    private float timeCount = 0;
    private void Awake()
    {
        Instance = this;
        GameManager.OnGameStateChange += StateChange;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= StateChange;
    }

  
    void Start()
    {
        initPos = transform.position;
        playerSpeed = initSpeed;
        
    }

    private void StateChange(GameManager.GameState state)
    {
        if (state == GameManager.GameState.PlayGame) restartParams();
    }
 
    void FixedUpdate()
    {
        xPlayerPos = transform.position.x;

        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;

        transform.Translate(transform.right * Time.deltaTime * playerSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Enemy") return;

        GameManager.Instance.GameStateUpdate(GameManager.GameState.LoseGame);
    }

    private void restartParams()
    {
        transform.position = initPos;
        playerSpeed = initSpeed;
    }

}
