using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverCorutina : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float deltaSpeed;//Incremento de velocidad en la corutina
    private float z;
    private const string PARAM_ACELERACION = "Aceleracion";
    private bool acelerando = false;
    private float currentSpeed = 0;
    private void Update()
    {
        Moverse();
    }
    private void Moverse()
    {
        z = Input.GetAxis("Vertical");
        if (z>0 && acelerando == false)
        {
            StartCoroutine("Acelerar");
            acelerando = true;
        } else if (z < 0.01f && acelerando == true)
        {
            StopCoroutine("Acelerar");
            currentSpeed = 0;
            acelerando = false;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed * speed);
        animator.SetFloat(PARAM_ACELERACION, currentSpeed);
    }
    IEnumerator Acelerar()
    {
        while (currentSpeed < 1)
        {
            currentSpeed += deltaSpeed;//Incremento de velocidad
            currentSpeed = Mathf.Min(1, currentSpeed);//Para que no sea mayor que 1
            yield return new WaitForSeconds(0.1f);//Pausa de 0.1 segundos entre iteracción
        }
    }
}
