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

    public bool stopped;

    public Resource resource;

    void Start()
    {
        currentScale = baseScale;
        this.transform.localScale = currentScale;

        if (resource) {
            
        }

        growth = 0f;
    }

    void Update ()
    {
        if(growth < 1 && !stopped) {
            growth += (growthMod * Time.deltaTime);
            currentScale = Vector3.Lerp(baseScale, targetScale, growth);
        }

        if(resource.value <= resource.maxValue) {
            resource.value = (int)(resource.maxValue * growth);
        }

        this.transform.localScale = currentScale;
	}
}
