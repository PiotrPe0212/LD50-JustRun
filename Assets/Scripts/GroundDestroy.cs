using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour
{
    private Renderer objRenderer;
    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.LoseGame)  Destroy(gameObject);
        if (GameManager.Instance.State != GameManager.GameState.PlayGame) return;
        if (objRenderer.isVisible) return;
        if (PlayerController.Instance.xPlayerPos <= transform.position.x) return;
        Destroy(gameObject);
    }
}
