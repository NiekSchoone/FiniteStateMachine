//Created by: Niek Schoone

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private bool reachedPosition;

    private float movementSpeed = 10;

    public bool MovementCompleted
    {
        get
        {
            return reachedPosition;
        }
    }

    /// <summary>
    /// Initializes the MoveTowardsTargetLocation Coroutine and gives it it's vallues.
    /// </summary>
    /// <param name="locationObject"></param>
    /// <param name="distanceFromLocation"></param>
    public void InitMoveToLocation(GameObject locationObject, float distanceFromLocation)
    {
        reachedPosition = false;
        StartCoroutine(MoveTowardsTargetLocation(locationObject, distanceFromLocation));
    }

	/// <summary>
    /// Will move this object towards a GameObject' transform position.
    /// </summary>
    /// <param name="objectToMoveTo"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
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
	
	/// <summary>
    /// This function will move this object around randomly within a certain radius of a given transform.
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public IEnumerator MoveAroundInArea (Transform location, float radius)
    {
        return null;
    }
}
