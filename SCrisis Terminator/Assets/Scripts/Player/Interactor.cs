using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
      [SerializeField] private float _interactionPointRadius = 0.5f;
        [SerializeField] private LayerMask _interactableMask;
        [SerializeField] private InteractionPromptUI _InteractionPromptUI;
    private readonly Collider[] _colliders = new Collider[3];
     [SerializeField] private int _numFound;

     private Iinteractable _interactable;

     //Find everything within layer mask and puts it into collider array
     private void Update(){
         _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,_interactableMask);
        
        if(_numFound > 0 )
        {
            _interactable = _colliders[0].GetComponent<Iinteractable>();
               if (!_InteractionPromptUI.IsDisplayed) _InteractionPromptUI.SetUp(_interactable.InteractionPrompt);
               if (Input.GetKeyDown(KeyCode.E)) _interactable.Interact(this);
            
            }
            else{
            _interactable = null;
             _InteractionPromptUI.Close();
            }
        }
     

     private void OnDrawGizmos() {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
         
     }

}
