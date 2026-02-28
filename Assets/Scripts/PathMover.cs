using UnityEngine;

public class PathMover : Mover
{
    [SerializeField] private Path _path;

    private float _arrivalThreshold = 0.1f;
    private float _arrivalThresholdSqr;

    private void Awake()
    {
        _arrivalThresholdSqr = _arrivalThreshold * _arrivalThreshold;
        SetTarget(_path.GetPoint());
    }

    protected override void Update()
    {
        base.Update();

        var distance = (_path.GetPoint().position - transform.position).sqrMagnitude;

        if (distance < _arrivalThresholdSqr)
        {
            _path.ChangePoint();
            SetTarget(_path.GetPoint());
        }
    }
}