using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
   private  Renderer objRenderer;
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == "Activated" &&
            gameObject.name != "RockUp"
            ) Invoke("InitAndDestroy", 2f);
        if (objRenderer.isVisible) return;
        if (PlayerController.Instance.xPlayerPos <= transform.position.x) return;
        InitAndDestroy();
        
    }

    private void InitAndDestroy()
    {
        Destroy(gameObject);
    }

}
