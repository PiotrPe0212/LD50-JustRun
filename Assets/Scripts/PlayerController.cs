using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float initSpeed;
    [SerializeField] private Vector3 initPos;
    [SerializeField] private int speedLimit=16;
    public static PlayerController Instance;
    public float xPlayerPos;
    public float playerSpeed;
    public bool notMoving;
    private bool speedBonus;
    private bool slowBonus;
    private void Awake()
    {
        GameManager.OnGameStateChange += StateChange;
        Instance = this;
   
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
        if (state == GameManager.GameState.LoseGame) restartParams();
    }
 
    void FixedUpdate()
    {
        xPlayerPos = transform.position.x;

        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        ReycastTest();
        if (notMoving) return;
        transform.Translate(transform.right * Time.deltaTime * playerSpeed);
        if (transform.position.y != -1.5f) transform.position = new Vector3(transform.position.x, -1.5f, 0);
        speedUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        if (collision.collider.tag == "Enemy")
        GameManager.Instance.GameStateUpdate(GameManager.GameState.LoseGame);
        
    }

    private void restartParams()
    {
        transform.position = initPos;
        playerSpeed = initSpeed;
    }

    private void speedUp()
    {
        float speedAdd = Mathf.Round(xPlayerPos) / 20;
     
        if (speedAdd >= speedLimit) speedAdd = speedLimit;
        playerSpeed = initSpeed + speedAdd;
        if (slowBonus) {
            playerSpeed = initSpeed + speedAdd - 0.3f- speedAdd / 10;
                 Invoke("slowDeactivation", 2);
        }
        if (speedBonus) {
            playerSpeed = initSpeed + speedAdd + 1+ speedAdd/10;
                 Invoke("bonusDeactivation", 2);
        }
       
    }

    private void ReycastTest()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f), Vector2.right);
        float distance = Mathf.Abs(hit.point.x - transform.position.x - 0.5f);
        if (hit && distance < 0.1f)
        {
            print(hit.collider.gameObject.name);
            bonusAdding(hit.collider.gameObject);
            notMoving = true;
            StartCoroutine(DetectedObjectDestroy(hit.collider.gameObject));
        }
        else notMoving = false;
    }
 
    private void bonusDeactivation()
    {
        speedBonus = false;
       
    }
    private void slowDeactivation()
    {
        slowBonus = false;
    }

    private IEnumerator DetectedObjectDestroy(GameObject detectedObject)
    {
        yield return new WaitForSeconds(2);
        Destroy(detectedObject);
    }
    private void bonusAdding(GameObject type)
    {
        if (type.name == "Apple")
        {
            speedBonus = true;
            Destroy(type);
        }
        else if (type.name == "Bird")
        {
            slowBonus = true;
            Destroy(type);
        }
        else return;
    }

}

