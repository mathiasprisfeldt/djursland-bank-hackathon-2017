using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class ChildGroup : MonoBehaviour
{
    private VerticalLayoutGroup _verticalLayoutGroup;

    [SerializeField] private GameObject __emptyIcon;
    [SerializeField] private GameObject __addIcon;
    [SerializeField] private ChildIcon __childIcon;
    [SerializeField] private GameObject __horizontalGroupPrefab;

    void Awake()
    {
        _verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
    }

    void Start()
    {
        FamilyManager.Instance.ChildAdded += OnChildAdded;
        StartCoroutine(UpdateList());
    }

    private void OnChildAdded(Child child)
    {
        StartCoroutine(UpdateList());
    }

    private void Clear()
    {
        for (int i = 0; i < _verticalLayoutGroup.transform.childCount; i++)
            Destroy(_verticalLayoutGroup.transform.GetChild(i).gameObject);
    }

    IEnumerator UpdateList()
    {
        yield return null;
        Clear();

        GameObject currLayoutGroup = null;

        for (var index = 0; index < FamilyManager.Instance.Children.Count + 1; index++)
        {
            if (currLayoutGroup == null || currLayoutGroup != null && currLayoutGroup.transform.childCount == 2)
                currLayoutGroup = Instantiate(__horizontalGroupPrefab, _verticalLayoutGroup.transform);

            if (index < FamilyManager.Instance.Children.Count)
            {
                Child instanceChild = FamilyManager.Instance.Children[index];
                Instantiate(__childIcon, currLayoutGroup.transform).Setup(instanceChild);
            }
        }

        //Create 'create' btn icon
        Instantiate(__addIcon, currLayoutGroup.transform);

        if (currLayoutGroup != null && currLayoutGroup.transform.childCount == 1)
            Instantiate(__emptyIcon, currLayoutGroup.transform);
    }
}
