using UnityEngine;

public class ParallaxBackgroundScript : MonoBehaviour
{

    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;

    private float length;
    private float startPos;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float xMovementBounds = cam.transform.position.x * (1 - parallaxEffect); // How far we have moved relative to the camera
        float xMovement = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + xMovement, transform.position.y, transform.position.z);
        if (xMovementBounds > startPos + length)
            startPos += length;
        else if (xMovementBounds < startPos - length)
            startPos -= length;
    }
}
