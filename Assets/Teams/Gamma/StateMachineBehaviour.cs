using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateBase : StateMachineBehaviour
{
    public GammaTeam.GammaController gammaController;
    public event Action<StateMachineBehaviour, string, string> OnStateChanged;
    public void RaiseStateChanged(string stateName, string stateChanged)
    {
        OnStateChanged?.Invoke(this, stateName, stateChanged);
    }
}
