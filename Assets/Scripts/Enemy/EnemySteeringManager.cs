using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySteeringManager : MonoBehaviour
{
    [SerializeField] private EnemySteeringScript[] enemies;

    public void ChangeAIStateForEnemies(AIStateComponent newState)
    {
        foreach(EnemySteeringScript enemy in enemies)
        {
            enemy.currentState = newState.state;
        }
    }
}
