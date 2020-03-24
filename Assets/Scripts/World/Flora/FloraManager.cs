using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraManager : MonoBehaviour
{
  [SerializeField]
  private float radius;

  [SerializeField]
  private float minDistanceBetweenFlora;

  [SerializeField]
  private float timeBetweenGrowths;

  private float timeToNext;

  [SerializeField]
  private GameObject floraToGrow;

  [SerializeField]
  private int maxToGrow;

  private List<GameObject> grownFlora;

  void Start() {
    grownFlora = new List<GameObject>();
    timeToNext = 0;
  }

  void Update() {
    timeToNext -= Time.deltaTime;
    if (grownFlora.Count < maxToGrow && timeToNext <= 0) {
      Grow();
    }
  }

  void Grow() {
    timeToNext = timeBetweenGrowths;
    GameObject newGrowth = GameObject.Instantiate(floraToGrow, RandomPointInBox(this.transform.position, new Vector3(radius, 0, radius)), Quaternion.identity);
    grownFlora.Add(newGrowth);
  }

  Vector3 RandomPointInBox(Vector3 center, Vector3 size) {
    return center + new Vector3(
       (Random.value - 0.5f) * size.x,
       (Random.value - 0.5f) * size.y,
       (Random.value - 0.5f) * size.z
    );
  }
}
