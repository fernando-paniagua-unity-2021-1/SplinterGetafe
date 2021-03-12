using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintDissolver : MonoBehaviour
{
    [SerializeField]
    private float timeToDissolve;
    Renderer fpRenderer;
    
    void Start()
    {
        fpRenderer = GetComponentInChildren<Renderer>();
        StartCoroutine("Fade");
    }

    IEnumerator Fade() 
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f) 
        {
            Color c = fpRenderer.material.color;
            c.a = ft;
            fpRenderer.material.color = c;
            yield return new WaitForSeconds(timeToDissolve/10);
        }
        Destroy(gameObject);
    }
}
