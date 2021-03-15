using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorSonido : MonoBehaviour
{
    public Renderer bolaDeteccion;
    public Material verde;
    public Material rojo;

    public bool obstaculosBloqueantes;//Determina si los collider bloquean el sonido
    public float distanciaDeteccionAndando;
    public float distanciaDeteccionCorriendo;
    public GameObject player;
    public float distanciaAlPlayer;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
   
    void Update()
    {
        //Si hay un obstaculo y hemos configurado los obstaculos como bloqueantes-->no te escucha
        if (obstaculosBloqueantes && hayAlgoEntreMedias())
        {
            CambiaMaterial(verde);
            return;
        }
        //Solo continuamos si no hay obstaculos entre enemigo y player
        distanciaAlPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (player.GetComponent<PlayerMover>().estado == PlayerMover.EstadoPlayer.Andando){
            if (distanciaAlPlayer<distanciaDeteccionAndando){
                CambiaMaterial(rojo);
            }
        } else if (player.GetComponent<PlayerMover>().estado == PlayerMover.EstadoPlayer.Corriendo){
            if (distanciaAlPlayer<distanciaDeteccionCorriendo){
                CambiaMaterial(rojo);
            }
        } else {
            CambiaMaterial(verde);
        }
    }
    
    bool hayAlgoEntreMedias(){
        RaycastHit rch;
        Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        bool hayAlgo = Physics.Raycast(ray, out rch);//rch recoge la información del impacto
        if (hayAlgo && rch.transform.gameObject.CompareTag("Player"))
        {
            hayAlgo = false;
        }
        return hayAlgo;
    }
    private void CambiaMaterial(Material m){
        bolaDeteccion.material = m;
    }
}
