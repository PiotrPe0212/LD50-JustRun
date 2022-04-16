using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private GameObject[] objectList;
    [SerializeField] private GameObject parent;
    [SerializeField] private Camera cameraObject;
    private Vector3 worldCoord;
    private float initPlayerPos;
    [SerializeField] private float timeGeneration = 1.5f;

  

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
        initPlayerPos = PlayerController.Instance.xPlayerPos;
        InvokeRepeating("GenerateObject", 0, timeGeneration);
    }

 
    void Update()
    {
        worldCoord = cameraObject.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
    }

    public  void GenerateObject()
    {
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        if (PlayerController.Instance.notMoving) return;
        int rand = Random.Range(0, 3);
        if (rand == 0) return;
        int randomObject = Random.Range(0, objectList.Length);
        float yCord=0;
        switch (randomObject)
        {
            case (0):
                yCord = -0.6f;
                break;
            case (1):
                yCord = -0.6f;
                break;
            case (2):
                yCord = -2.8f;
                break;
            case (3):
                yCord = -1.55f;
               break;

        }
         Instantiate(objectList[randomObject], 
             new Vector3(worldCoord.x + 2 + Random.Range(0, 2), yCord, 0), 
             Quaternion.identity, 
             parent.transform);
       

    }

    private void StateChange(GameManager.GameState state)
    {
        if (state != GameManager.GameState.PlayGame) return;
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
            print("dest");
        }
        InitCreate();
    }
    private void InitCreate()
    {
        print("gener");
        for(int i=0; i<4; i++)
        {
            worldCoord = new Vector3(initPlayerPos+1+i*2, 0, 0);
            GenerateObject();
        }
    }
}
