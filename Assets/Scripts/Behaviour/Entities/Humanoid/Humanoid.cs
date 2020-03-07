using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour, ISelectable
{

  protected StackFSM brain;
  protected Vector3 targetPosition;
  public Animator anims;

  [SerializeField]
  protected float fatigue;
  [SerializeField]
  protected GameObject selectionMarker;

  protected virtual void Start() {    
    brain = new StackFSM();

    targetPosition = transform.position;

    brain.PushState(Idle);
  }

  protected virtual void Update() {
    brain.Update();
    fatigue += Time.fixedDeltaTime;
    if (fatigue >= 100) {
      brain.PushState(Idle);
    }
  }

  protected void Idle() {
    fatigue -= Time.fixedDeltaTime * 2.5f;

    if(fatigue <= 0) {
      brain.PopState();
    }
  }

  protected void Walk() {
    anims.SetBool("Walking", true);
    transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.05f);

    Vector3 targetDir = targetPosition - transform.position;
    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1, 0);

    transform.rotation = Quaternion.LookRotation(newDir);

    if (InPosition()) {
      brain.PopState();
      anims.SetBool("Walking", false);
    }
  }

  protected bool InPosition() {
    if (Vector3.Distance(transform.position, targetPosition) < 2) {
      return true;
    } else {
      return false;
    }
  }

  public void OnSelect() {
    selectionMarker.SetActive(true);
  }

  public void OnDeselect() {
    selectionMarker.SetActive(false);
  }

  public Vector3 TargetPosition
  {
    get { return targetPosition; }
    set { targetPosition = value; }
  }

}
