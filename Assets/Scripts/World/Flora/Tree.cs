using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
  [SerializeField]
  private float toppleAngle;

  [SerializeField]
  private bool chopped;

  private float fall;

  void Start() {
    this.transform.eulerAngles = new Vector3(
      this.transform.eulerAngles.x,
      this.transform.eulerAngles.y + Random.Range(0, 360),
      this.transform.eulerAngles.z
    );
  }

  private void Update() {
    if(this.chopped && fall < 1) {
      fall += Time.deltaTime/2;
      this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, Mathf.SmoothStep(0, toppleAngle, fall));
    }
  }
}
