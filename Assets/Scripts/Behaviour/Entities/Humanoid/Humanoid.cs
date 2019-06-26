using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour
{
  protected StackFSM brain;
  protected Transform target;
  public Animator anims;

  [SerializeField]
  protected float fatigue;

  protected virtual void Start()
  {    
    brain = new StackFSM();

    brain.PushState(Idle);
  }

  protected virtual void Update()
  {
    brain.Update();
    fatigue += Time.fixedDeltaTime;
    if(fatigue >= 100) {
        brain.PushState(Idle);
    }
  }

  protected void Idle()
  {
    fatigue -= Time.fixedDeltaTime * 2.5f;

    if(fatigue <= 0) {
        brain.PopState();
    }
  }

  protected void Walk()
  {
    anims.SetBool("Walking", true);
    transform.position = Vector3.MoveTowards(transform.position, target.position, 0.05f);

    Vector3 targetDir = target.position - transform.position;
    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1, 0);

    transform.rotation = Quaternion.LookRotation(newDir);

    if (InPosition())
    {
      brain.PopState();
      anims.SetBool("Walking", false);
    }
  }

  protected bool InPosition()
  {
    if (Vector3.Distance(transform.position, target.position) < 2)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}
