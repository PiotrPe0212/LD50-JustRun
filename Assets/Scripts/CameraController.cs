using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private float timeOffset;

    [SerializeField] private Vector2 posOffset;
    private Vector3 initialPos;
    private bool correctInitPos;
    private ColorGrading colorGrading;
    private Grain grain;
    void Start()
    {
        initialPos = player.transform.position;
        volume.profile.TryGetSettings(out colorGrading);
        volume.profile.TryGetSettings(out grain);
    }

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
            colorGrading.hueShift.value = player.transform.position.x/6;
            grain.intensity.value =1.5f/ Mathf.Abs(enemy.transform.position.x - player.transform.position.x);
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
