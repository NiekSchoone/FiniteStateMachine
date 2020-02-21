using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSelectable : MonoBehaviour
{
  private bool selected;

  [SerializeField]
  private UnityEvent onSelect;

  public virtual void OnSelect() {
    onSelect.Invoke();
  }

  public bool Selected {
    get { return selected; }
    set { selected = value; }
  }
  
}
