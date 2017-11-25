using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private float _zoomFacor = 2;

    private Vector3 _oldPosition;
    private float _oldZoomFactor;

    public void Zoom()
    {
        if(!_camera)
            _camera = Camera.main;

        _oldZoomFactor = _camera.orthographicSize;
        _oldPosition = _camera.transform.position;

        //if (transform is RectTransform)
        //{
        //    _camera.orthographicSize = _zoomFacor;
        //    Vector3 position = (transform as RectTransform).transform.position;
        //    Vector3 worldPosition = (transform as RectTransform).
        //        TransformVector((transform as RectTransform).rect.center);
        //    RectTransformUtility.ScreenPointToWorldPointInRectangle((RectTransform) transform, 
        //        (transform as RectTransform).rect.center,_camera, out position);
        //    _camera.transform.position = new Vector3(worldPosition.x, worldPosition.y,
        //        _camera.transform.position.z);
        //}
        //else
        //{
            _camera.orthographicSize = _zoomFacor;
            _camera.transform.position = new Vector3(transform.position.x, transform.position.y,
                _camera.transform.position.z);
        //}

        
    }

    public void ZoomOut()
    {
        _camera.orthographicSize = _oldZoomFactor;
        _camera.transform.position = _oldPosition;
    }
}
