using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SelectionManager : MonoBehaviour {

  private List<ISelectable> selectables;

  void Start() {

    selectables = new List<ISelectable>();

    var ss = FindObjectsOfType<MonoBehaviour>().OfType<ISelectable>();
    Debug.Log(ss);
    foreach (ISelectable s in ss)
    {
      Debug.Log(s);
      selectables.Add(s);
    }
    Debug.Log(selectables[0].OnSelect());

    Debug.Log(Find<ISelectable>());
  }

  public static List<T> Find<T>()
  {
    List<T> interfaces = new List<T>();
    GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
    foreach (var rootGameObject in rootGameObjects)
    {
      T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>();
      foreach (var childInterface in childrenInterfaces)
      {
        interfaces.Add(childInterface);
      }
    }
    return interfaces;
  }

}