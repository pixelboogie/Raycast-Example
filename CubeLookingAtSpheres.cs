using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLookingAtSpheres : MonoBehaviour
{

    [SerializeField]
    private Color tintColor = Color.green;
    [SerializeField]
    private Color tintColorForRaycastAll = Color.yellow;
    [SerializeField]
    private bool multiple;


    // Update is called once per frame
    void Update()
    {
        if(multiple)
            RaycastMultiple();
        else
            RaycaSingle();
    }

    private void RaycaSingle()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origin, direction* 10f,Color.red);
        Ray ray = new Ray(origin, direction);

        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            raycastHit.collider.GetComponent<Renderer>().material.color = tintColor;
        }

    }

    private void RaycastMultiple()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origin, direction * 10f, Color.yellow);
        Ray ray = new Ray(origin, direction);

        var multipleHits = Physics.RaycastAll(ray);
        foreach(var raycastHit in multipleHits)
        {
            raycastHit.collider.GetComponent<Renderer>().material.color = tintColor;
        }
    }



}
