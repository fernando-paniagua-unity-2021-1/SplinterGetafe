using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    public GameObject mapa;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapa.SetActive(!mapa.activeSelf);
        }
    }
}
