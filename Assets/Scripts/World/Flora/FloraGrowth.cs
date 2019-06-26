using UnityEngine;
using System.Collections;

public class FloraGrowth : MonoBehaviour
{
    [SerializeField]
    private Vector3 baseScale;
    [SerializeField]
    private Vector3 targetScale;

    private Vector3 currentScale;
    [SerializeField]
    private float growth;
    [SerializeField]
    private float growthMod;

    void Start()
    {
        currentScale = baseScale;
        this.transform.localScale = currentScale;

        growth = 0f;
    }

    void Update ()
    {
        if(growth < 1) {
            growth += (growthMod * Time.deltaTime);
            currentScale = Vector3.Lerp(baseScale, targetScale, growth);
        }

        this.transform.localScale = currentScale;
	}
}
