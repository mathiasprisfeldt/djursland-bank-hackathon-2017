using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    [SerializeField] private Text _name;
    public void Setup(Duty duty)
    {
        _name.text = duty.Name;
    }
}
