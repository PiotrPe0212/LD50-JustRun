using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private Sprite[] cloudsSprites;
    [SerializeField] private GameObject cloudObject;
    [SerializeField] private GameObject parent;
    [SerializeField] private Camera cameraObject;
    private Vector3 worldCoord;
    void Start()
    {
        InvokeRepeating("cloudCreating", 2.0f, 3.0f);
    }

    void Update()
    {
        worldCoord = cameraObject.ViewportToWorldPoint(new Vector3(1, 1, 0));

    }

    private void cloudCreating()
    {

        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        if (PlayerController.Instance.notMoving) return;
        int rand = Random.Range(0, 2);
        if (rand == 0) return;
        GameObject cloud =Instantiate(cloudObject, new Vector3(worldCoord.x + 2 + Random.Range(0, 2), worldCoord.y - 1 - Random.Range(0, 2), 0), Quaternion.identity, parent.transform);
        cloud.GetComponent<SpriteRenderer>().sprite = cloudsSprites[Random.Range(0, cloudsSprites.Length)];
        cloud.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }
}
