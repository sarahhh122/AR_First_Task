using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
public class joltScript : ARInteractionsSc
{
    private Animator _animator;

  private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void SetState(State state)
    {
        base.SetState(state);

        if (_animator == null) return;

        
        _animator.Play("Armature|ArmatureAction"); 
    
       
    }
}
