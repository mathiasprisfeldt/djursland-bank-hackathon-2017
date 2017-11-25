using UnityEngine;
using UnityEngine.UI;

public class UIChildSelected : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private TaskUIFiller _taskUiFiller;

    public void Setup(Child child)
    {
        _name.text = child.Name;
        _taskUiFiller.Setup(child);
    }
}
