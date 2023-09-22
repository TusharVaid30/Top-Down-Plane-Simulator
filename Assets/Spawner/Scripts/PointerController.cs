using UnityEngine;

public class PointerController : MonoBehaviour
{
    public Transform instance;
    
    [SerializeField] private GameObject pointerImage;
    [SerializeField] private float offset;
    
    private RectTransform _pointerRect;

    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;
    
    private void Start()
    {
        _pointerRect = GetComponent<RectTransform>();

        _minX = offset;
        _maxX = Screen.width - offset;
        _minY = offset;
        _maxY = Screen.height - offset;
    }

    private void Update()
    {
        if (!instance)
        {
            pointerImage.SetActive(false);
            return;
        }
        
        pointerImage.SetActive(true);
        if (Camera.main != null) _pointerRect.position = Camera.main.WorldToScreenPoint(instance.position);
        var pos = _pointerRect.position;
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
        _pointerRect.position = pos;
        
        if (pos.x < _maxX && pos.x > _minX && pos.y < _maxY && pos.y > _minY)
            pointerImage.SetActive(false);
    }
}
