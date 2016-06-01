using UnityEngine;
using System.Collections.Generic;

public class InteractableObjectList : MonoBehaviour
{
    public List<List<GameObject>> resources = new List<List<GameObject>>();
    public List<GameObject> trees = new List<GameObject>();
    public List<GameObject> mines = new List<GameObject>();
    public List<GameObject> fields = new List<GameObject>();

    public List<List<GameObject>> importantBuildings = new List<List<GameObject>>();
    public List<GameObject> storehouses = new List<GameObject>();

    public List<GameObject> homes = new List<GameObject>();

    void Reset ()
    {
        foreach(GameObject tree in GameObject.FindGameObjectsWithTag(Tags.TREE))
        {
            trees.Add(tree);
        }
        resources.Add(trees);
        resources.Add(mines);
        resources.Add(fields);
    }
}
