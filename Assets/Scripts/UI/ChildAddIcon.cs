using UnityEngine;

public class ChildAddIcon : MonoBehaviour 
{
    public AddChild ChildAdder { get; set; }

    public void AddChild()
    {
        ChildAdder.gameObject.SetActive(true);
    }
}
