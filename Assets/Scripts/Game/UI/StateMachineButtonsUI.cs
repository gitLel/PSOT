using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StateMachineButtonsUI : MonoBehaviour 
{
    [Inject]
    private FiniteStateMachine finiteStateMachine;

    [SerializeField] private Button accomodationButton;
    private void Start()
    {
        accomodationButton.onClick.AddListener(() => finiteStateMachine.SetState<AccommodationState>());

        finiteStateMachine.SetState<IdleState>();
    }

    
   
    private void OnDestroy()
    {
        accomodationButton.onClick.RemoveListener(() => finiteStateMachine.SetState<AccommodationState>());
    }
    
}
