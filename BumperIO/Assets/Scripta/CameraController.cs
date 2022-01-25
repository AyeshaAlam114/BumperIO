using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<GameObject> target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Camera>().fieldOfView = GetGreatestDistance();
    }

    float GetGreatestDistance()
    {
        if (target.Count <= 1)
            return 0f;
        var bounds= new Bounds(target[0].transform.position, Vector3.zero);
        for (int i = 0; i < target.Count; i++)
            bounds.Encapsulate(target[i].transform.position);
        return bounds.size.z*5;
    }
}
