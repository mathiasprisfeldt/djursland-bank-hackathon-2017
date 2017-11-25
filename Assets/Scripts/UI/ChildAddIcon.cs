using UnityEngine;

namespace ChildAddIcon
{
    /// <summary>
    /// Purpose:
    /// Creator:
    /// </summary>
    public class ChildAddIcon : MonoBehaviour 
    {
        public void AddChild()
        {
            FamilyManager.Instance.AddChild(new Child("Bivert"));
        }
    }
}