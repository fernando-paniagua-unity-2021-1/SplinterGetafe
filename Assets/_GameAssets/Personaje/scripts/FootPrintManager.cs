using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintManager : MonoBehaviour
{
    public GameObject prefabFootPrint;
    public Transform rightFootPrintTransform;
    public Transform leftFootPrintTransform;
    public Transform rightFootPrintTransformSigilo;
    public Transform leftFootPrintTransformSigilo;
    public void CreateRightFootPrint(){
        Instantiate (prefabFootPrint, rightFootPrintTransform.position, rightFootPrintTransform.rotation);
    }
    public void CreateLeftFootPrint(){
        GameObject leftFootprint = Instantiate (prefabFootPrint, leftFootPrintTransform.position, leftFootPrintTransform.rotation);
        leftFootprint.transform.localScale = new Vector3(
            leftFootprint.transform.localScale.x*-1,
            leftFootprint.transform.localScale.y,
            leftFootprint.transform.localScale.z
        );
    }

    public void CreateRightFootPrintSigilo(){
        Instantiate (prefabFootPrint, rightFootPrintTransformSigilo.position, rightFootPrintTransformSigilo.rotation);
    }
    public void CreateLeftFootPrintSigilo(){
        GameObject leftFootprint = Instantiate (prefabFootPrint, leftFootPrintTransformSigilo.position, leftFootPrintTransformSigilo.rotation);
        leftFootprint.transform.localScale = new Vector3(
            leftFootprint.transform.localScale.x*-1,
            leftFootprint.transform.localScale.y,
            leftFootprint.transform.localScale.z
        );
    }
}
