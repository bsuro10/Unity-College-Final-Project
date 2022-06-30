using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOutScript : MonoBehaviour
{
    [SerializeField] private bool isZoomActive = false;
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    private Vector3 movePosition;

    private void Awake()
    {
        movePosition = new Vector3(cam.transform.position.x, 0, cam.transform.position.z);
    }

    private void LateUpdate()
    {
        if (isZoomActive)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, speed);
            if (cam.transform.position != movePosition)
            {
                Vector3 newPos = Vector3.MoveTowards(cam.transform.position, movePosition, speed);
                cam.transform.position = newPos;
            }
        }
    }

    public void ActivateZoom()
    {
        isZoomActive = true;
    }
}
