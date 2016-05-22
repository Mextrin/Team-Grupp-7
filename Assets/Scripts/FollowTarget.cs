using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
    public float timeToGoal;
    public Transform target;
    Vector3 targetPosition;
    Vector3 velocity = Vector3.zero;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetPosition = new Vector3(target.position.x, target.position.y, -10f);
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, timeToGoal);
    }
}
