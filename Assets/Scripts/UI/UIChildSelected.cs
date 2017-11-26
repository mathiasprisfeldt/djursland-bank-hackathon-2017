using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIChildSelected : MonoBehaviour
{
    private Child _child;

    [SerializeField] private Text _balance;
    [SerializeField] private Text _name;
    [SerializeField] private TaskUIFiller _taskUiFiller;

    public void Setup(Child child)
    {
        _child = child;
        _name.text = child.Name;
        _taskUiFiller.Setup(child);
    }

    void Update()
    {
        if (_child != null)
            _balance.text = _child.RealCurrency + "kr";
    }
}
