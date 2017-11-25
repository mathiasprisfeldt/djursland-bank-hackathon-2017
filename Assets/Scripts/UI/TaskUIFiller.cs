using System.Linq;
using UnityEngine;

public class TaskUIFiller : MonoBehaviour
{
    [SerializeField] private TaskUI __taskPrefab;

    public void Setup(Child child)
    {
        Clean();

        if (child.Duties != null && child.Duties.Any())
            foreach (Duty duty in child.Duties)
            {
                Instantiate(__taskPrefab, transform).Setup(duty);
            }
    }

    private void Clean()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
