using UnityEngine;
using System.Collections;

public class SpawnWheat : MonoBehaviour
{
    public GameObject wheatPrefab;

    private GameObject _wheat;
    private float _wheatAmount;
    private int _rowAmount;

    void Awake()
    {
        _wheatAmount = 600;
        float tempRows = Mathf.Sqrt(_wheatAmount);
        _rowAmount = (int)Mathf.Ceil(tempRows);

        CreateWheat();
    }

    void CreateWheat()
    {
        Vector3 center = transform.position;
        for (int l = 0; l < _rowAmount; l++)
        {
            for (int i = 0; i < _wheatAmount / _rowAmount; i++)
            {
                _wheat = Instantiate(wheatPrefab, RandomCircle(center, 25), Quaternion.identity) as GameObject;
                _wheat.transform.parent = this.transform;
            }
        }
    }
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        Vector3 pos;
        pos.x = Mathf.Cos(Random.value) * radius;
        pos.z = Mathf.Sin(Random.value) * radius;
        pos.y = transform.position.y;
        return pos;
    }
}