using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    private Ray ray;
    private RaycastHit2D hit;
    private bool CorrectHit;
    void Start()
    {

    }


    void Update()
    {
        if (hit.collider != null) print(hit.collider.name);
        if (hit.collider == null) RestartHit();
        if (!CorrectHit) CastRay();
        if (Input.GetMouseButtonDown(0) && CorrectHit) Interact();
        Invoke("RestartHit", 0.5f);

    }
    private void CastRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider == null) return;
        if (hit.collider.gameObject.tag == "ControlElement") CorrectHit = true;


    }
    private void Interact()
    {
        clickSound.Play();
        if (hit.collider == null) return;
        hit.collider.gameObject.tag = "Activated";
        RestartHit();
    }

    private void RestartHit()
    {
        CorrectHit = false;
    }
}
