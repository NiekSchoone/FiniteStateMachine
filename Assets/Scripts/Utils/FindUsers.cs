using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class FindUsers
{
  public static List<T> Find<T>()
  {
    List<T> users = new List<T>();
    GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
    foreach (var rootGameObject in rootGameObjects)
    {
      T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>();
      foreach (var childInterface in childrenInterfaces)
      {
        users.Add(childInterface);
      }
    }
    return users;
  }
}
