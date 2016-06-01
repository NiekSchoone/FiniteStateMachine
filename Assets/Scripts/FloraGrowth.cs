using UnityEngine;
using System.Collections;

public class FloraGrowth : MonoBehaviour
{
    private Vector3 _baseScale;
    private Vector3 _targetScale;
    private Vector3 _currentScale;

    private float _growthModifier;

    void Start()
    {
        _baseScale = this.transform.localScale;
        _targetScale = _baseScale;

        _currentScale = new Vector3(_baseScale.x,0f,_baseScale.z);
        this.transform.localScale = _currentScale;

        _growthModifier = 0.1f;
    }

    void Update ()
    {
        _currentScale = Vector3.Lerp(_currentScale, _targetScale, _growthModifier * Time.deltaTime);

        this.transform.localScale = _currentScale;
	}
}
