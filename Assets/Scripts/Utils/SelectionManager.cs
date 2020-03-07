using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour
{

  private List<ISelectable> selectables;

  public List<ISelectable> selected;

  void Start()
  {
    selectables = Find<ISelectable>();
    selected = new List<ISelectable>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      DeselectAll();
      selected = ObjectsToSelect();
      if (selected != null)
      {
        for (int i = 0; i < selected.Count; i++)
        {
          selected[i].OnSelect();
        }
      }
    }
  }

  public List<T> Find<T>()
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

  public List<ISelectable> ObjectsToSelect()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    List<ISelectable> objectsHit = new List<ISelectable>();

    if (Physics.Raycast(ray, out hit, 100))
    {
      objectsHit.Add(hit.transform.gameObject.GetComponent<ISelectable>());
      for (int i = 0; i < objectsHit.Count; i++)
      {
        if (!selectables.Contains(objectsHit[i])) {
          objectsHit.Remove(objectsHit[i]);
        }
      }
    }
    return objectsHit;
  }

  public void DeselectAll()
  {
    for (int i = 0; i < selectables.Count; i++)
    {
      selectables[i].OnDeselect();
    }
  }
}