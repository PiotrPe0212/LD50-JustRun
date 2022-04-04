using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
   private  Renderer objRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == "Activated") Invoke("InitAndDestroy", 1.5f);
        if (objRenderer.isVisible) return;
        if (PlayerController.Instance.xPlayerPos <= transform.position.x) return;
        InitAndDestroy();
        
    }

    private void InitAndDestroy()
    {
       CreateObject.Instance.GenerateObject();
        Destroy(gameObject);
    }

}
