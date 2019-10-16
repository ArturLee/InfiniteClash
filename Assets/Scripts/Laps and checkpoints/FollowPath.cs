using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private PathLine path;
    [SerializeField] private float pathOffset = 0.71f;
    [SerializeField] private float prediction = 0.71f;
    private float currentParam = 0;

    private void Start()
    {
        Transform[] trans = GameObject.Find("WaypointsCircuit").GetComponentsInChildren<Transform>();
        Vector3[] nodes = new Vector3[trans.Length - 1];
        for (int i = 0; i < trans.Length - 1; i++)
        {
            nodes[i] = trans[i+1].position;
        }
        path.nodes = nodes;
    }

    void Update()
    {
        //SteeringData steering = new SteeringData();
        Vector3 targetPosition;
        if (path.nodes.Length == 1)
            targetPosition = path.nodes[0];
        else
        {
            Vector3 predictedTarget = transform.position + (GetComponent<Rigidbody>().velocity * prediction);

            currentParam = path.GetParam(predictedTarget);
            float targetParam = currentParam + pathOffset;
            targetPosition = path.GetPosition(targetParam);
            //steering.linear = targetPosition - transform.position;
            //steering.linear.Normalize();
            //steering.linear *= steeringbase.maxAcceleration;
        }
        //return steering;
    }

    void OnDrawGizmos()
    {
        path.Draw();
    }
}
