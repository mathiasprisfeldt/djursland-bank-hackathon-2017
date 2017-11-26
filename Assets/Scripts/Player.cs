using AcrylecSkeleton.Extensions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _targetPos;

    [SerializeField] private BoxCollider2D _container;
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _distanceThreshold = 0.1f;

    [SerializeField] private float _minMoveTime = 1;
    [SerializeField] private float _maxMoveTime = 3;
    [SerializeField] private float _passiveSpeed = 5;

    [SerializeField] private Puppet2D_GlobalControl _puppetMaster;

    public Animator Animator;


    private Vector2 _passiveDirection;
    private float _passiveTimer;
    private bool _moveToMouse;

    public Interactable InteractableTarget { get; set; }

    public Rigidbody2D RigidBody2D
    {
        get { return _rigidbody2D; }
    }

    public Vector2 PassiveDirection
    {
        get { return _passiveDirection; }
    }

    public bool LookDir
    {
        get { return _puppetMaster.flip; }
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
            _moveToMouse = true;

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
                }
            }
            Animator.speed = 2f;
            _passiveDirection = transform.position.DirectionTo2D(_targetPos);
        }

        if (Mathf.Abs(transform.position.x - _targetPos.x) > _distanceThreshold && _moveToMouse)
        {
            Vector2 direction = new Vector2(_targetPos.x > transform.position.x ? 1 : -1,0);
            RigidBody2D.AddForce(direction * _speed * Time.deltaTime,ForceMode2D.Impulse);
        }
        else if(_moveToMouse)
            _moveToMouse = false;

        if (InteractableTarget && Vector2.Distance(transform.position, _targetPos) <=
            InteractableTarget.DistanceBeforeEnter &&
            !InteractableTarget.IsInteracted)
        {
            InteractableTarget.OnEnter(this);
            _targetPos = transform.position;
        }

        if(!InteractableTarget && !_moveToMouse)
            HandlePassiveMovement();
        _puppetMaster.flip = PassiveDirection.x > 0;
        Animator.speed = 1f;
    }

    private void HandlePassiveMovement()
    {
        var hit = Physics2D.Raycast(transform.position, PassiveDirection,1,LayerMask.GetMask("Wall"));
        Debug.DrawRay(transform.position, PassiveDirection * 1);
        if (_passiveTimer <= 0 || hit.collider) 
        {
            var random = Random.Range(0, 2);
            if (hit.collider)
                _passiveDirection = -PassiveDirection;
            else
                _passiveDirection = new Vector2(random == 0 ? -1 : 1,0);
            _passiveTimer = Random.Range(_minMoveTime, _maxMoveTime);
        }
        else
        {
            RigidBody2D.AddForce(PassiveDirection * _passiveSpeed * Time.deltaTime,ForceMode2D.Impulse);
            _passiveTimer -= Time.deltaTime;
        }
    }

    public void SetTarget(Interactable interactable)
    {
        _targetPos = interactable.transform.position;
        InteractableTarget = interactable;
    }
}
