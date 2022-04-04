using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private GameObject[] objectList;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject parent;
    private float  playerPos;

    public static CreateObject Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public  void GenerateObject()
    {
        playerPos = PlayerController.Instance.xPlayerPos;
        Instantiate(objectList[Random.Range(0, objectList.Length)], new Vector3(playerPos + 5+ Random.Range(-2,2), 4+Random.Range(0,1.1f), 0), Quaternion.identity, parent.transform);

    }
}
