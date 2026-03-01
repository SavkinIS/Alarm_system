using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private Path _path;

    private float _arrivalThreshold = 0.1f;
    private float _arrivalThresholdSqr;
    private Transform _target;
    private Vector3 _direction;

    private bool CanMove => _target != null;

    private void Awake()
    {
        _arrivalThresholdSqr = _arrivalThreshold * _arrivalThreshold;
        SetTarget(_path.GetPoint());
    }

    private void Update()
    {
        if (CanMove)
            Move();

        var distance = (_path.GetPoint().position - transform.position).sqrMagnitude;

        if (distance < _arrivalThresholdSqr)
        {
            _path.ChangePoint();
            SetTarget(_path.GetPoint());
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        _direction = (_target.position - transform.position).normalized;
        Vector3 moveDirection = _direction * _moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveDirection.x, 0, moveDirection.z), Space.World);
    }
}