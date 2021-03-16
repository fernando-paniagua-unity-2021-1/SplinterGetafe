using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class NightVisionActivator : MonoBehaviour
{
    public PostProcessVolume ppv;
    private ColorGrading cg;
    private Grain g;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ppv.profile.TryGetSettings(out cg);
            ppv.profile.TryGetSettings(out g);
            cg.enabled.value = !cg.enabled.value;
            g.enabled.value = !g.enabled.value;
        }
    }
}
