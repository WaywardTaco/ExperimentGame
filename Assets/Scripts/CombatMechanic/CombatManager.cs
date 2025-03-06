using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    /// <summary>
    /// The dimensions of one side of the battlefield ([0] = length; [1] = depth)
    /// </summary>
    public static readonly int[] BATTLEFIELD_DIMENSIONS = { 3, 2 };


    public void BeginCombat(){

    }

    private void EndCombat(){

    }

    private void ProcessTurn(Combatant combatant){
        if(combatant == null){
            Debug.LogWarning("[WARN]: Combatant missing!");
            return;
        }


    }

    public void CompleteMoveCallback(){

    }


    void Start(){
        if(_sharedInstance != null)
            Destroy(this);
        else 
            _sharedInstance = this;
    }
    private static CombatManager _sharedInstance;
    public static CombatManager Instance {
        get {  
            return _sharedInstance;
        }
    }
}
