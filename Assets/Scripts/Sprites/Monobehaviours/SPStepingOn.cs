using System.Collections;
using UnityEngine;

public class SPStepingOn : MonoBehaviour
{
    [SerializeField]
    string _tag = string.Empty;
    GameObject stepingOn = null;

    public void GetFloorFromRayCastHit(RaycastHit2D hit)
    {
        if (hit.collider.gameObject.tag == _tag) { 
            stepingOn = hit.collider.gameObject;
            Debug.Log("I am adding it " + stepingOn.name);
        }
    }


    public void DisableSteppingOn()
    {
        if (stepingOn != null)
        {
            stepingOn.GetComponent<Collider2D>().enabled = false;
        }
    }



}
