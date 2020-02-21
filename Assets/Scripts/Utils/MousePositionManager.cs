using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionManager : MonoBehaviour
{
  private Camera mCam;
  private Vector3 lastMousePosition;

  public Vector3 hitPoint;

  // Start is called before the first frame update
  void Start()
  {
    mCam = Camera.main;
  }

  // Update is called once per frame
  void Update()
  {
    /*if (Input.mousePosition != lastMousePosition)
    {
      Ray ray = mCam.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Ground")))
      {
        hitPoint = hit.point;
      }
      lastMousePosition = Input.mousePosition;
    }*/
  }

  public Vector3? GetPositionOnLayer() {
    Ray ray = mCam.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Ground"))) {
      return hit.point;
    } else {
      return null;
    }
  }
}
