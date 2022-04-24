using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivationScript : MonoBehaviour
{
    [SerializeField] private float gravityScale;
    [SerializeField] private float movingDistance;
    [SerializeField] private bool goUp;
    [SerializeField] private bool goRight;

    private Vector3 goRightPos;
    private Vector3 goUpPos;
    private Vector3 goDownPos;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        goRightPos = new Vector3(transform.position.x + movingDistance, transform.position.y, transform.position.z);
        goUpPos = new Vector3(transform.position.x, transform.position.y + movingDistance, transform.position.z);
        goDownPos = new Vector3(transform.position.x, transform.position.y - movingDistance, transform.position.z);
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag != "Activated") return;
        MovingFunction();


    }

    private void MovingFunction()
    {
        if (goRight) GoRightFunction();
        else UpDown();


    }

    private void GoRightFunction()
    {
        transform.position = Vector3.Lerp(transform.position, goRightPos, time);
        time += Time.deltaTime;

    }
    private void UpDown()
    {

        if (!goUp)
        {
            transform.position = Vector3.Lerp(transform.position, goDownPos, time);
            time += Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, goUpPos, time);
            time += Time.deltaTime;

        }
    }

}
