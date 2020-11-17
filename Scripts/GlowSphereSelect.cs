using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowSphereSelect : MonoBehaviour, ISelectionResponse
{
    public GameObject glowSphere;

    public void OnDeselect(Transform selection)
    {
        (glowSphere.GetComponent("Halo") as Behaviour).enabled = false;
    }

    public void OnSelect(Transform selection)
    {
        var offset = selection.transform.localScale.y;
        glowSphere.transform.position = new Vector3(selection.transform.position.x, offset * 2f, selection.transform.position.z);
        (glowSphere.GetComponent("Halo") as Behaviour).enabled = true;
    }
}
