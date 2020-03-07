using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraManager : MonoBehaviour
{
  [SerializeField]
  private GameObject surface;

  [SerializeField]
  private float radius;

  [SerializeField]
  private float minDistanceBetweenFlora;

  [SerializeField]
  private float spreadRate;

  private float timeToNext;

  [SerializeField]
  private GameObject floraToGrow;

  private List<GameObject> grownFlora;

  void Start() {
    grownFlora = new List<GameObject>();

    GameObject firstToGrow = GameObject.Instantiate(floraToGrow, transform.position, Quaternion.identity);
  }

  void Update() {

  }

}
