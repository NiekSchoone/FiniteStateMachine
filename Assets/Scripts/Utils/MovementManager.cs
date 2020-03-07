using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MovementManager : MonoBehaviour
{
  [SerializeField]
  private SelectionManager selectionManager;
  [SerializeField]
  private MousePositionManager mousePositionManager;

  void Update() {
    if (Input.GetMouseButtonDown(1)) {
      List<ISelectable> selec = selectionManager.selected;
      for (int i = 0; i < selec.Count; i++)
      {
        MonoBehaviour mb = selec[i] as MonoBehaviour;
        Debug.Log(mb.gameObject.GetComponent<Humanoid>().TargetPosition = (Vector3)mousePositionManager.GetPositionOnLayer());
      }
    }
  }
  
}