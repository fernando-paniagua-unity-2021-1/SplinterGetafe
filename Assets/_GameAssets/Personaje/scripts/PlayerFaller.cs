using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaller : MonoBehaviour
{
    public Animator animator;
    private const string PARAM_CAIDA_PLANO = "Neymar";
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("ObstaculoSuelo")){
            animator.SetTrigger(PARAM_CAIDA_PLANO);
        }
    }
}
