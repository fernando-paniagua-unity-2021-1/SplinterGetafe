using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PaniaguaItem", menuName = "PaniaguaIPlay/PopulationObject", order = 1)]

public class PopulationScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public int instances;
    public bool randomRotation = false;
    public float minScale=1;
    public float maxScale=1;
    public float yOffset=0;
}
