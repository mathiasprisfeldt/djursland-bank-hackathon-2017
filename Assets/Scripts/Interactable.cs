using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent Enter;
    [SerializeField] private UnityEvent Exit;

    [SerializeField] private BoxCollider2D _hitBox;
    [SerializeField] private float _distanceBeforeEnter = .25f;

    public float DistanceBeforeEnter
    {
        get { return _distanceBeforeEnter; }
        set { _distanceBeforeEnter = value; }
    }

    public bool IsInteracted { get; set; }

    public BoxCollider2D HitBox
    {
        get { return _hitBox; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.Player.SetTarget(this);
    }

    public virtual void OnEnter(Player ply)
    {
        IsInteracted = true;

        if (Enter != null)
            Enter.Invoke();
    }

    public virtual void OnExit(Player ply)
    {
        IsInteracted = false;

        if (Exit != null)
            Exit.Invoke();
    }
}
