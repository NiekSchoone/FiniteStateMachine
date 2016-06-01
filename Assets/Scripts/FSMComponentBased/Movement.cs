using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public bool reachedPosition;

    private float movementSpeed = 10;

    /// <summary>
    /// Initializes the MoveTowardsTargetLocation coroutine which will move an object to a gameobjects location.
    /// </summary>
    /// <param name="locationObject"></param>
    /// <param name="distanceFromLocation"></param>
    public void InitMoveToLocation(GameObject locationObject, float distanceFromLocation)
    {
        reachedPosition = false;
        Debug.Log(locationObject);
        StartCoroutine(MoveTowardsTargetLocation(locationObject, distanceFromLocation));
    }

	IEnumerator MoveTowardsTargetLocation (GameObject objectToMoveTo, float distance)
    {
        float distanceToPlace = Vector3.Distance(transform.position, objectToMoveTo.transform.position);
        while (distanceToPlace > distance)
        {
            distanceToPlace = Vector3.Distance(transform.position, objectToMoveTo.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, objectToMoveTo.transform.position, movementSpeed * Time.deltaTime);
            yield return null;
        }
        reachedPosition = true;
    }
	
	public IEnumerator MoveAroundInArea (Transform location)
    {
        while (transform.position != location.position)
        {
            yield return null;
        }
    }
}
