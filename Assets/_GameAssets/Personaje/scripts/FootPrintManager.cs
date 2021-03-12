using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrintManager : MonoBehaviour
{
    public GameObject prefabFootPrint;
    public Transform rightFootPrintTransform;
    public Transform leftFootPrintTransform;
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
}
