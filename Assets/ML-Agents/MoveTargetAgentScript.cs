using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class MoveTargetAgentScript : Agent
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private Renderer floor;
    [SerializeField] private Transform target;

    private Vector3 targetOriginalPosition;
    private Bounds floorBounds;

    public override void Initialize()
    {
        targetOriginalPosition = transform.localPosition;
        floorBounds = floor.localBounds;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(target.localPosition);
    }

    public override void OnEpisodeBegin()
    {
        RandomPlaceTarget(target);
        RandomPlaceTarget(transform);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        transform.Translate(Vector3.right * vectorAction[0] * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * vectorAction[1] * moveSpeed * Time.deltaTime);
        FloorBoundsCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddReward(1.0f);
            Debug.Log("Rewarded with 1!");
            EndEpisode();
        }
    }

    private void RandomPlaceTarget(Transform target)
    {
        float randX = Random.Range(floorBounds.min.x * (floor.transform.localScale.x - 1), floorBounds.max.x * (floor.transform.localScale.x - 1));
        float randZ = Random.Range(floorBounds.min.z * (floor.transform.localScale.z - 1), floorBounds.max.z * (floor.transform.localScale.z - 1));
        target.localPosition = new Vector3(randX, target.localPosition.y, randZ);
    }

    private void FloorBoundsCheck()
    {
        if ((transform.localPosition.x < floorBounds.min.x * floor.transform.localScale.x) || (transform.localPosition.x > floorBounds.max.x * floor.transform.localScale.x))
        {
            AddReward(-0.1f);
            Debug.LogWarning("Rewarded with -1 :(");
            EndEpisode();
        }
        else if ((transform.localPosition.z < floorBounds.min.z * floor.transform.localScale.z) || (transform.localPosition.z > floorBounds.max.z * floor.transform.localScale.z))
        {
            AddReward(-0.1f);
            Debug.LogWarning("Rewarded with -1 :(");
            EndEpisode();
        }

    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxisRaw("Horizontal");
        actionsOut[1] = Input.GetAxisRaw("Vertical");
    }
}
