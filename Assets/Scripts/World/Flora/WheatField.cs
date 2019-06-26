using UnityEngine;
using System.Collections;

public class WheatField : MonoBehaviour
{
    public GameObject wheatPrefab;
    private float _wheatAmount;
    [SerializeField]
    private int _radius;

    void Awake()
    {
        _wheatAmount = _radius * 100;
        float tempRows = Mathf.Sqrt(_wheatAmount);

        CreateWheat();
    }

    void CreateWheat()
    {
        Vector3 center = transform.position;
        for (int i = 0; i < _wheatAmount; i++)
        {
            GameObject wheat = Instantiate(wheatPrefab, RandomCircle(_radius), Quaternion.identity) as GameObject;
            wheat.transform.parent = this.transform;
        }
    }
    
    Vector3 RandomCircle(float radius)
    {
        Vector3 pos;

        float pt_angle = Random.value * 2 * Mathf.PI;
        float pt_radius_sq = Random.value * radius * radius;
        float pt_x = Mathf.Sqrt(pt_radius_sq) * Mathf.Cos(pt_angle);
        float pt_y = Mathf.Sqrt(pt_radius_sq) * Mathf.Sin(pt_angle);

        pos.x = transform.position.x + pt_x;
        pos.z = transform.position.z + pt_y;
        pos.y = transform.position.y;
        return pos;
    }
}