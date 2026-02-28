using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Transform _target;
    private Vector3 _direction;

    private bool CanMove => _target != null;

    protected virtual void Update()
    {
        if (CanMove)
            Move();
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