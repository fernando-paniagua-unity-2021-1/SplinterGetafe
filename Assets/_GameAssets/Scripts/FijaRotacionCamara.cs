using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FijaRotacionCamara : MonoBehaviour
{
    public bool rotacionActiva;
    Quaternion rotacion;
    void Start()
    {
        rotacion = transform.rotation;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!rotacionActiva)
        {
            transform.rotation = rotacion;
        }
    }
}
