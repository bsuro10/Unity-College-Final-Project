using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBladeTrapScript : EnemyDamageScript
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;

    private bool movingDown = true;
    private float upperEdge;
    private float underEdge;

    private void Awake()
    {
        upperEdge = transform.position.y + movementDistance;
        underEdge = transform.position.y - movementDistance;
    }

    private void Update()
    {
        if (movingDown)
        {
            if (transform.position.y > underEdge)
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            else
                movingDown = false;
        }
        else
        {
            if (transform.position.y < upperEdge)
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            else
                movingDown = true;
        }
    }

}
