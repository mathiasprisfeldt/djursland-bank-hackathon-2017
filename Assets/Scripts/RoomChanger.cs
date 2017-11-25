using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spites = new List<Sprite>();

    [SerializeField] private SpriteRenderer _target;

    private int _index;

	// Use this for initialization
	void Start ()
	{
	    _target.sprite = _spites[_index];
	}

    public void NextSprite()
    {
        _index++;
        if (_index >= _spites.Count)
            _index = 0;
        _target.sprite = _spites[_index];
    }
}
