using DG.Tweening;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float spinDuration = 1f;
    
    private void FixedUpdate()
    {
        SpinSpinner();
    }

    private void SpinSpinner()
    {
        transform.DORotate( new Vector3( 0f, -360f, 0f ), spinDuration, RotateMode.LocalAxisAdd)
            .SetLoops(-1)
            .SetEase(Ease.Linear);
    }
}
