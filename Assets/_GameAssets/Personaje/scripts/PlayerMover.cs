using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    
    public enum EstadoPlayer { Reposo, Andando, Corriendo }
    public EstadoPlayer estado = EstadoPlayer.Reposo;


    public Animator animator;

    public float rotationSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float stealthSpeed;
    private float x;
    private float z;  

    private const string PARAM_ANDAR = "Andar";
    private const string PARAM_CORRER = "Correr";
    private const string PARAM_STEALTH = "AndarSigilo";

    private void Update() {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        DesactivarAvance();
        Andar();
        IntentarCorrer();
    }

    private void Andar(){
        if (z>0) {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetButton("Fire3")){
                animator.SetBool(PARAM_STEALTH, true);
                transform.Translate(Vector3.forward * Time.deltaTime * stealthSpeed * z);
                transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
                estado = EstadoPlayer.Reposo;
            } else {
                animator.SetBool(PARAM_STEALTH, false);
                animator.SetBool(PARAM_ANDAR, true);
                transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed * z);
                transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
                estado = EstadoPlayer.Andando;
            }
        } else {
            animator.SetBool(PARAM_ANDAR, false);
            animator.SetBool(PARAM_STEALTH, false);
            transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
            estado = EstadoPlayer.Reposo;
        }
    }
    
    private void IntentarCorrer(){
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Fire2")){
            Correr();
        } 
        else {
            animator.SetBool(PARAM_CORRER, false);
        }
    }
    private void Correr(){
        transform.Translate(Vector3.forward * Time.deltaTime * runSpeed * z);
        if (z>0) {
            animator.SetBool(PARAM_CORRER, true);
            transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
            estado = EstadoPlayer.Corriendo;
        } else {
            animator.SetBool(PARAM_CORRER, false);
        }
    }
    private void DesactivarAvance(){
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name=="Fall Flat" 
            ||
            animator.GetCurrentAnimatorClipInfo(0)[0].clip.name=="Getting Up"){
            z=0;
        }
    }
}
