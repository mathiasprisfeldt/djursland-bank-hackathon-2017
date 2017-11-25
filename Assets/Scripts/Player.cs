using AcrylecSkeleton.Extensions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _targetPos;

    [SerializeField] private BoxCollider2D _container;
    [SerializeField] private float _speed = 500;
    [SerializeField] private float _distanceThreshold = 0.1f;

    public Interactable InteractableTarget { get; private set; }

    public Rigidbody2D RigidBody2D
    {
        get { return _rigidbody2D; }
    }

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _targetPos = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var prevTargetPos = _targetPos;

            _targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!_container.OverlapPoint(_targetPos))
                _targetPos = _container.bounds.ClosestPoint(_targetPos);

            if (InteractableTarget)
            {
                if (InteractableTarget.HitBox.OverlapPoint(_targetPos))
                    _targetPos = prevTargetPos;
                else
                {
                    if (InteractableTarget.IsInteracted)
                        InteractableTarget.OnExit(this);

                    InteractableTarget = null;
                }
            }
        }

        if (Vector2.Distance(transform.position, _targetPos) > _distanceThreshold)
            RigidBody2D.AddForce(
                transform.position.DirectionTo2D(_targetPos) * _speed * Time.deltaTime);
        
        if (InteractableTarget && Vector2.Distance(transform.position, _targetPos) <=
            InteractableTarget.DistanceBeforeEnter &&
            !InteractableTarget.IsInteracted)
        {
            InteractableTarget.OnEnter(this);
            _targetPos = transform.position;
        }
    }

    public void SetTarget(Interactable interactable)
    {
        _targetPos = interactable.transform.position;
        InteractableTarget = interactable;
    }
}
