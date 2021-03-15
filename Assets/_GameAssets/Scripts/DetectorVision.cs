using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorVision : MonoBehaviour
{
    public Renderer bolaDeteccion;
    public Material verde;
    public Material rojo;

    public float distanciaMaximaVision;//A partir de esta distancia no se le ve.
    public GameObject player;
    public float distanciaAlPlayer;
    public float anguloMaximo;
    public float angulo;

    public LayerMask layerMask;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CambiaMaterial(verde);
    }

    // Update is called once per frame
    void Update()
    {
        distanciaAlPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanciaAlPlayer > distanciaMaximaVision)
        {
            CambiaMaterial(verde);
            return;
        }
        if (hayAlgoEntreMedias())
        {
            CambiaMaterial(verde);
            return;
        }
        //A partir de aquí puede ser que lo esté viendo
        Vector3 forwardEnemy = transform.forward.normalized;
        Vector3 playerPosition = new Vector3(
            player.transform.position.x, 
            transform.position.y, 
            player.transform.position.z);
        Vector3 direccionHaciaElPlayer = Vector3.Normalize(playerPosition - transform.position);
        angulo = Vector3.Angle(forwardEnemy, direccionHaciaElPlayer);
        if (angulo < anguloMaximo)
        {
            CambiaMaterial(rojo);
        } else
        {
            CambiaMaterial(verde);
        }
        
    }

    bool hayAlgoEntreMedias()
    {
        RaycastHit rch;
        Vector3 playerPosition = new Vector3(
            player.transform.position.x,
            transform.position.y,
            player.transform.position.z);
        Ray ray = new Ray(transform.position, playerPosition - transform.position);
        bool hayAlgo = Physics.Raycast(ray, out rch, distanciaMaximaVision, layerMask);//rch recoge la información del impacto
        if (hayAlgo && rch.transform.gameObject.CompareTag("Player"))
        {
            hayAlgo = false;
        }
        return hayAlgo;
    }
    private void CambiaMaterial(Material m)
    {
        bolaDeteccion.material = m;
    }
}
