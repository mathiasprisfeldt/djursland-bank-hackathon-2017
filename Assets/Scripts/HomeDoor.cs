using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class HomeDoor : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool _useCollision = true;
    [SerializeField] private bool _useClick;
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_useCollision && collision.CompareTag("Player"))
            GoTo();
    }

    public void GoTo()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_useClick)
            GoTo();
    }
}
