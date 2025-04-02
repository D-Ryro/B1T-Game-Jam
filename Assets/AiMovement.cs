using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public Transform _target;
    public float _speed = 5f;
    public float detectionRage = 20f;

    private void Start()
    {
        FindNearestTarget();
    }

    private void Update()
    {
        if(_target == null)
        {
            FindNearestTarget();
            return;
        }

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

        _target = closestObject;

    }



}
