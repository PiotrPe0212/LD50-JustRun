using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private GameObject[] objectList;
    [SerializeField] private GameObject parent;
    [SerializeField] private Camera cameraObject;
    private Vector3 worldCoord;
    [SerializeField] private float timeGeneration = 2;

  

    private void Awake()
    {

    }
    void Start()
    {
        InvokeRepeating("GenerateObject", 2.0f, timeGeneration);
    }

 
    void Update()
    {
        worldCoord = cameraObject.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
    }

    public  void GenerateObject()
    {
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        if (PlayerController.Instance.notMoving) return;
        int rand = Random.Range(0, 2);
        if (rand == 0) return;
         Instantiate(objectList[Random.Range(0, objectList.Length)], 
             new Vector3(worldCoord.x + 2 + Random.Range(0, 2), worldCoord.y - 1 - Random.Range(0, 2), 0), 
             Quaternion.identity, 
             parent.transform);
        //object.GetComponent<SpriteRenderer>().sprite = objectList[Random.Range(0, objectList.Length)];
       // object.GetComponent<SpriteRenderer>().sortingOrder = 20;
        //Instantiate(objectList[Random.Range(0, objectList.Length)], new Vector3(playerPos + 5+ Random.Range(-2,2), 4+Random.Range(0,1.1f), 0), Quaternion.identity, parent.transform);

    }
}
