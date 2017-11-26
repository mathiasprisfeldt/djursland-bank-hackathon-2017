using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    [SerializeField] private Text _moneyTxt;
    [SerializeField] private Image _moneyImage;
    [SerializeField] private Image _image;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;
    [SerializeField] private Text _name;
    public void Setup(Duty duty)
    {
        _moneyTxt.text = duty.RealReward + "kr";
        _name.text = duty.Name;
        _moneyImage.color = duty.IsCompleted ? _inactiveColor : _activeColor;
        _image.color = duty.IsCompleted ? _inactiveColor : _activeColor;
    }
}
