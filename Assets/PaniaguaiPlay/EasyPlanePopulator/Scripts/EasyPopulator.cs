using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        foreach (PopulationScriptableObject pso in populationScriptableObject){
            for(int i=0;i<pso.instances;i++){
                GameObject go = Instantiate(pso.prefab);
                go.transform.position = new Vector3(
                    Random.Range(xMin,xMax),
                    y,
                    Random.Range(zMin,zMax)
                );
            }
        }
    }
}
