using UnityEngine;

public class FollowWithoutRotate : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    private Vector3 localOffset;
    private Quaternion initialLocalRotation;

    void Start()
    {
        localOffset = transform.position - ballTransform.position;
        
        initialLocalRotation = transform.localRotation;
    }

    void LateUpdate()
    {
        transform.position = ballTransform.position + localOffset;
        
        transform.localRotation = initialLocalRotation;
    }
}