using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour 
{
    public void Throw()
    {
        GetComponentInChildren<Interactable>().OnExit(GameManager.Instance.Player);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(GameManager.Instance.Player.LookDir ? 1 : -1, 1) * 200);
    }
}
