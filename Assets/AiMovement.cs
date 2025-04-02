using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public Transform _target;
    public float _speed = 5f;
    public float detectionRage = 20f;
    public float _targetUpdate = 0.5f;
    private float nextTargetUpdateTime;

    private void Start()
    {
        FindNearestTarget();
    }

    private void Update()
    {
        if (Time.time >= nextTargetUpdateTime)
        {
            FindNearestTarget();
            nextTargetUpdateTime = Time.time + _targetUpdate;
        }

        if (_target != null)
        {
            MoveTowardTarget();
        }
    }

    void MoveTowardTarget()
    { 

        Vector3 direction = (_target.position - transform.position).normalized;

        transform.position += direction * _speed * Time.deltaTime;

    }

    void FindNearestTarget()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Example");
        float closestDistance = Mathf.Infinity;
        Transform closestObject = null;
        

        foreach(GameObject obj in objects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if(distance < detectionRage && distance  < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj.transform;

            }
        }
        if (closestObject != null && (_target == null) || closestDistance < Vector3.Distance(transform.position, _target.position))
        {
            _target = closestObject;
        }
    }



}
