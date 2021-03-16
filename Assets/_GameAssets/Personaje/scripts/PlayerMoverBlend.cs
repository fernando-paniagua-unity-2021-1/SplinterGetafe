using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverBlend : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private float z;
    private const string PARAM_ACELERACION = "Aceleracion";
    private void Update()
    {
        z = Input.GetAxis("Vertical");//-1 (cuando tecla 'back' está pulsada) +1 (cuando tecla 'forward' está pulsada)
        Moverse();
    }
    private void Moverse()
    {
        if (z > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * z * speed);
        }
        animator.SetFloat(PARAM_ACELERACION, z);
    }
}
