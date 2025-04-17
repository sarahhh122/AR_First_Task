using UnityEngine;
using System.Collections.Generic;

public abstract class ARInteractionsSc : MonoBehaviour
{
    private List<ARInteractionsSc> _interactables = new List<ARInteractionsSc>();

    protected enum State
    {
        Idle, Active
    }
    protected State ARObjectState = State.Idle;

    private void OnTriggerEnter(Collider other){
        if(other.TryGetComponent<ARInteractionsSc>(out var interactable)){
            AddInteractable(interactable);
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.TryGetComponent<ARInteractionsSc>(out var interactable)){
            RemoveInteractable(interactable);
        }
    }

    protected void AddInteractable(ARInteractionsSc interactable){
        _interactables.Add(interactable);
        SetState(State.Active);
    }

    protected void RemoveInteractable(ARInteractionsSc interactable){
        _interactables.Remove(interactable);
        if(_interactables.Count ==0) SetState(State.Idle);
    }

    private void OnDisable(){
        foreach(var interactable in _interactables){
            interactable.RemoveInteractable(this);
        }
        _interactables.Clear();
        SetState(State.Idle);
    }

    protected virtual void SetState(State state){
        ARObjectState = state;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
