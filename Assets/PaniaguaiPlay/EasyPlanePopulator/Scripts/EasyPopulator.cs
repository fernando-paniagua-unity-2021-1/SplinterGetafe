using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EasyPopulator : MonoBehaviour
{
    [SerializeField]
    PopulationScriptableObject[] populationScriptableObject;
    private MeshRenderer planeMeshRenderer;
    private float xMin,xMax,zMin,zMax,y;
    private void Awake() {
        planeMeshRenderer = GetComponent<MeshRenderer>();
        xMin = planeMeshRenderer.bounds.min.x;
        xMax = planeMeshRenderer.bounds.max.x;
        zMin = planeMeshRenderer.bounds.min.z;
        zMax = planeMeshRenderer.bounds.max.z;
        y = planeMeshRenderer.bounds.min.y;
    }
    void Start()
    {
        //Creamos un padre común y se lo asignamos a todos los objetos
        GameObject goContainer = new GameObject();
        goContainer.name="PopulationParent";
        foreach (PopulationScriptableObject pso in populationScriptableObject){
            for(int i=0;i<pso.instances;i++){
                //Creamos los objetos y le asignamos el padre común
                GameObject go = Instantiate(pso.prefab);
                go.transform.SetParent(goContainer.transform);
                //Posición
                go.transform.position = new Vector3(
                    Random.Range(xMin,xMax),
                    y,
                    Random.Range(zMin,zMax)
                );
                //Rotación
                if (pso.randomRotation){
                    go.transform.Rotate(0,Random.Range(0,360),0);
                }
                //YOffset
                go.transform.Translate(0, go.transform.position.y+pso.yOffset, 0);
                //Escala
                float newScale = Random.Range(pso.minScale, pso.maxScale);
                go.transform.localScale = new Vector3(newScale, newScale, newScale);
            }
        }
    }
}
