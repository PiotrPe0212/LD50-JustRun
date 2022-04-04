using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGeneration : MonoBehaviour
{

    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] private Sprite[] buschSprites;
    [SerializeField] private Sprite[] grassSprites;
    [SerializeField] private Sprite[] hillsSprites;
    [SerializeField] private Sprite[] moutainsSprites;
    [SerializeField] private GameObject groundObject;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject hillParent;
    [SerializeField] private GameObject mountainsParent;
    private float initPos;
    private float actualPos;
    private float actulalPosBackground;
    private bool initCreated = false;
    // Start is called before the first frame update
    void Start()
    {
        initPos = -8.5f;
        actualPos = initPos;
        actulalPosBackground = initPos;
        InitialCreating();
        InvokeRepeating("CreatingGround", 2.0f, 1.0f);
        InvokeRepeating("BackgroundCreating", 2.0f, 2.0f);
    }

    private void CreatingGround()
    {if (GameManager.Instance.State != GameManager.GameState.PlayGame && initCreated) return;
        GameObject ground;
        float yPos = -1.5f;
        for (int i = 0; i < 3; i++)
        {
            ground = Instantiate(groundObject, new Vector3(actualPos, yPos, 0), Quaternion.identity, parentObject.transform);
            switch (i)
            {
                case (0):
                    ground.GetComponent<SpriteRenderer>().sprite = grassSprites[Random.Range(0, grassSprites.Length)];
                    ground.GetComponent<SpriteRenderer>().sortingOrder = 18;
                    yPos = -3;
                    break;
                case (1):
                    ground.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];
                    ground.GetComponent<SpriteRenderer>().sortingOrder = 19;
                    yPos = -4;
                    break;
                case (2):
                    ground.GetComponent<SpriteRenderer>().sprite = buschSprites[Random.Range(0, buschSprites.Length)];
                    ground.GetComponent<SpriteRenderer>().sortingOrder = 20;
                    break;
            }
        }
        actualPos += 1;
    }

    private void BackgroundCreating()
    {
        if (GameManager.Instance.State != GameManager.GameState.PlayGame && initCreated) return;
        GameObject background;
        float yPos = -0.65f;
        for (int i = 0; i < 2; i++)
        {
            
            switch (i)
            {
                case (0):
                    background = Instantiate(groundObject, new Vector3(actulalPosBackground, yPos, 0), Quaternion.identity, hillParent.transform);
                    background.GetComponent<SpriteRenderer>().sprite = hillsSprites[Random.Range(0, hillsSprites.Length)];
                    background.GetComponent<SpriteRenderer>().sortingOrder = 17;
                    yPos = 1.1f;
                    break;
                case (1):
                    background = Instantiate(groundObject, new Vector3(actulalPosBackground, yPos, 0), Quaternion.identity, mountainsParent.transform);
                    background.GetComponent<SpriteRenderer>().sprite = moutainsSprites[Random.Range(0, moutainsSprites.Length)];
                    background.GetComponent<SpriteRenderer>().sortingOrder = 16;
                    break;
               
            }
        }
        actulalPosBackground += 1;
    }
    
    private void InitialCreating()
    {
        for( int i =0; i<20; i++)
        {
            CreatingGround();
            BackgroundCreating();

        }
        initCreated = true;
    }

}
