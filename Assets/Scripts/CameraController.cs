using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float timeOffset;

    [SerializeField] private Vector2 posOffset;
    private Vector3 initialPos;
    private bool correctInitPos;
    void Start()
    {
        initialPos = player.transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = player.transform.position;
            endPos.x += posOffset.x;
            endPos.y -= posOffset.y;
            endPos.z = gameObject.transform.position.z;

            transform.position = Vector3.Lerp(startPos, endPos, timeOffset* Time.deltaTime);
            correctInitPos = false;
        }
        else
        {
            if (!correctInitPos)
                InitialCamera();
        }
    }

    private void InitialCamera()
    {
        transform.position = Vector3.Lerp(transform.position, initialPos, timeOffset * Time.deltaTime);
        correctInitPos = true;
    }
}
