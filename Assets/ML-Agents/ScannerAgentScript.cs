using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class ScannerAgentScript : Agent
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private Transform target;
    [SerializeField] private float stealthDamage = 10f;
    [SerializeField] private float stealthRate = 1f;
    private float m_timeToAttack;
    private bool m_scanningPlayer = false;

    public override void CollectObservations(VectorSensor sensor)
    {
        if (transform != null)
            sensor.AddObservation(transform.localPosition);
        if (target != null)
            sensor.AddObservation(target.localPosition);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        transform.Translate(Vector3.right * vectorAction[0] * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * vectorAction[1] * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddReward(1.0f);
            m_scanningPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            m_scanningPlayer = false;
    }

    private void Update()
    {
        if (m_scanningPlayer)
            ScanPlayer();
    }

    void ScanPlayer()
    {
        if (Time.time >= m_timeToAttack)
        {
            m_timeToAttack = Time.time + 1 / stealthRate;
            SceneManagerScript.Instance.playerScript.TakeStealthDamage(stealthDamage);
        }
    }

}
