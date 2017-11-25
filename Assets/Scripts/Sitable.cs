using UnityEngine;

public class Sitable : Interactable
{
    private Vector2 _prevPosition;
    [SerializeField] private Transform _sitPosition;

    public override void OnEnter(Player ply)
    {
        ply.RigidBody2D.velocity = Vector2.zero;
        _prevPosition = ply.transform.position;
        ply.transform.position = _sitPosition.position;
        ply.Animator.SetTrigger("Sit");
        base.OnEnter(ply);
    }

    public override void OnExit(Player ply)
    {
        ply.transform.position = new Vector3(_sitPosition.position.x, _prevPosition.y);
        ply.Animator.SetTrigger("Walk");
        base.OnExit(ply);
    }
}
