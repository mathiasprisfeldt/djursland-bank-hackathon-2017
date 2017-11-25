using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChildIcon : MonoBehaviour
{
    private Child _child;

    [SerializeField] private Image _icon;
    [SerializeField] private Text _nameText;

    public UIChildSelected ChildUI { get; set; }

    public ChildIcon Setup(Child child)
    {
        _child = child;
        _nameText.text = child.Name;
        return this;
    }

    public void Click()
    {
        ChildUI.gameObject.SetActive(true);
        ChildUI.Setup(_child);
    }
}
