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
    public bool notMoving;
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
        notMoving = false;
        
    }

    private void StateChange(GameManager.GameState state)
    {
        if (state == GameManager.GameState.PlayGame) restartParams();
    }
 
    void FixedUpdate()
    {
        xPlayerPos = transform.position.x;

        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2 (transform.position.x+0.5f,transform.position.y-0.2f), Vector2.right);
        float distance = Mathf.Abs(hit.point.x - transform.position.x-0.5f);
        if (hit && distance < 0.1f) notMoving = true;
        else notMoving = false;
        if (notMoving) return;
        transform.Translate(transform.right * Time.deltaTime * playerSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Enemy") return;
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        GameManager.Instance.GameStateUpdate(GameManager.GameState.LoseGame);
    }

    private void restartParams()
    {
        transform.position = initPos;
        playerSpeed = initSpeed;
    }

}
