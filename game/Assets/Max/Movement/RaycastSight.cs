using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSight : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float distance = 5f;
    [SerializeField] GameObject hitTarget = null;
    [SerializeField] Material activeMaterial = null;
    [SerializeField] Material defaultMaterial = null;

    Mover mover;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.yellow);
            if (hitTarget)
            {
                ColorizeTarget(hitTarget, defaultMaterial);
            }

            hitTarget = hit.transform.gameObject;
            ColorizeTarget(hitTarget, activeMaterial);
            mover.SetTarget(hitTarget);
        }
        else
        {
            mover.SetTarget(null);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.green);
        }
    }

    void ColorizeTarget(GameObject go, Material material)
    {
        // Get the Renderer component from the new cube
       var renderer = go.GetComponent<MeshRenderer>();

       // Call SetColor using the shader property name "_Color" and setting the color to red
       renderer.material = material;
    }
}
