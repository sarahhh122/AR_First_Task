using UnityEngine;

public class CarScript : ARInteractionsSc
{
    private Animator _animator;

    private void OnEnable(){
        _animator = GetComponent<Animator>();
    }

    protected override void SetState(State state){
        base.SetState(state);
        switch(state)
        {
            case State.Idle:
                _animator.SetTrigger("GoTradle");
                break;

            case State.Active:
                _animator.SetTrigger("StartInteraction");
                break;
        }
    } 
    
}
