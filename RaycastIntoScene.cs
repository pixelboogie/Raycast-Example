using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastIntoScene : MonoBehaviour
{

    [SerializeField]
    private Camera camera;

    private void OnValidate()
    {
        if(camera == null)
            camera = Camera.main;
    }



    void Update()
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mouseScreenPosition);

        Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.green);

        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            raycastHit.collider.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
