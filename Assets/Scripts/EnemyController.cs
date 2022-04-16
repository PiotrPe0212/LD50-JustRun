using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float initSpeed;
    [SerializeField] private Vector3 initPos;
    [SerializeField] private int speedLimit = 18;

    public float enemySpeed;
    private bool notMoving;
    public bool speedBonus = false;
    public bool slowBonus= false;
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
        ReycastTest();
        if (notMoving) return;
        transform.Translate(transform.right * Time.deltaTime * enemySpeed);
        if (transform.position.y != -1) transform.position = new Vector3(transform.position.x, -1, 0);
        speedUp();
        
    }

    private void restartParams()
    {
        transform.position = initPos;
        enemySpeed = initSpeed;
    }

    private void speedUp()
    {
       
        float speedAdd = Mathf.Round(transform.position.x) / 19;
        if (speedAdd >= speedLimit) speedAdd = speedLimit;
        if (speedAdd < 0) speedAdd = 0;
        enemySpeed = initSpeed + speedAdd;
       
        if (slowBonus)
        {
            enemySpeed = initSpeed + speedAdd - 0.3f - speedAdd / 10;
            Invoke("slowDeactivation", 2);
        }
        if (speedBonus)
        {
            enemySpeed = initSpeed + speedAdd + 1 + speedAdd / 10;
            Invoke("bonusDeactivation", 2);
        }
    }


    private void ReycastTest()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f), Vector2.right);
        float distance = Mathf.Abs(hit.point.x - transform.position.x - 0.5f);
        if (hit && distance < 0.1f)
        {
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
