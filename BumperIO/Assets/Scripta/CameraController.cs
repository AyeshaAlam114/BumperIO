using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Transform> target;
    public Vector3 offset;

    public float smoothTime = 0.5f;
    public float zoomMin = 40f;
    public float zoomMax = 10f;
    public float zoomLimit = 50f;


    Camera camera;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.GetChild(0).GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.Count == 0)
            return;
        CameraMovement();
        CameraZoom();

    }
    void CameraMovement()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position ,newPosition,ref velocity, smoothTime);
    }

    void CameraZoom()
    {
        float newZoom = Mathf.Lerp(zoomMax, zoomMin, GetGreatestDistance() / zoomLimit);
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, newZoom, Time.deltaTime);
    }

    Vector3 GetCenterPoint()
    {
        if (target.Count == 1)
            return target[0].position;
        Bounds bounds = new Bounds(target[0].position, Vector3.zero);
        for (int i = 0; i < target.Count; i++)
            bounds.Encapsulate(target[i].position);
        return bounds.center;
    }
    float GetGreatestDistance()
    {
        Bounds bounds = new Bounds(target[0].position, Vector3.zero);
        for (int i = 0; i < target.Count; i++)
            bounds.Encapsulate(target[i].position);
        return bounds.size.x ;
    }
}
