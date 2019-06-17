using UnityEngine;
using System.Collections;

public class FloraGrowth : MonoBehaviour
{
    private Vector3 _baseScale;
    private Vector3 _targetScale;
    private Vector3 _currentScale;
    [SerializeField]
    private float _growth;
    [SerializeField]
    private float _growthMod;

    void Start()
    {
        _baseScale = this.transform.localScale;
        _targetScale = _baseScale;

        _currentScale = new Vector3(_baseScale.x,0f,_baseScale.z);
        this.transform.localScale = _currentScale;

        _growth = 0f;
    }

    void Update ()
    {
        if(_growth < 1) {
            _growth += (_growthMod * Time.deltaTime);
            _currentScale = Vector3.Lerp(new Vector3(1, 0, 1), _targetScale, _growth);
        }

        this.transform.localScale = _currentScale;
	}
}
