using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float movementSpeed = 3f;
    private int currentPatrolIndex = 0;

    private void Start()
    {
        transform.position = patrolPoints[currentPatrolIndex].position;
    }

    private void Update()
    {
        Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
}