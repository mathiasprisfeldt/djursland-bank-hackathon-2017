using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChildIcon : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _nameText;

    public void Setup(Child child)
    {
        _nameText.text = child.Name;
    }
}
