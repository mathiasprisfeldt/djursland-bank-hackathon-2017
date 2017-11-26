using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BalanceText : MonoBehaviour
{
    [SerializeField] private Text _text;

    void Update()
    {
        var sum = FamilyManager.Instance.Children.Sum(child => child.RealCurrency);

        _text.text = (sum == 0 ? "" : "-" ) + sum + "kr";
    }
}
