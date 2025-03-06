using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatantManager : MonoBehaviour
{
    [Serializable] public class CombatantTracker {
        [SerializeReference] public Combatant combatant;
        public int currentHealth;
        /// <summary>
        /// [0] = 0 is leftmost column; [1] = 0 is backmost row
        /// </summary>
        public int[] currentPosition = {-1, -1};

        public bool HasDied(){
            return currentHealth <= 0;
        }
    }
    [SerializeField] private List<CombatantTracker> _allCombatants = new();

    private Dictionary<String, CombatantTracker> _combatants = new();
    
    public void RegisterCombatant(Combatant combatant, int[] startPosition){
        if(_combatants.ContainsKey(combatant.CombatantTag)){
            Debug.LogWarning($"[WARN]: Trying to add already existing combatant {combatant.CombatantTag}");
            return;
        }

        CombatantTracker tracker = new(){
            combatant = combatant,
            currentPosition = startPosition
        };
        _allCombatants.Add(tracker);
        _combatants.Add(combatant.CombatantTag, tracker);


        SetStartHealth(combatant);
    }

    public void CloseCombatantManager(){
        _combatants.Clear();
    }

    /// <summary>
    /// Try to update a combatant's position
    /// </summary>
    /// <param name="combatant">The combatant to move</param>
    /// <returns>The updated position of the combatant. Null if failed</returns>
    public int[] TryMoveCombatant(Combatant combatant, MoveDirection direction){
        if(!_combatants.ContainsKey(combatant.CombatantTag)){
            Debug.LogWarning($"[WARN]: Trying to move unregistered combatant {combatant.CombatantTag}");
            return null;
        }

        CombatantTracker tracker = _combatants[combatant.CombatantTag];

        int[] futurePosition = new int[2]{
            tracker.currentPosition[0],
            tracker.currentPosition[1]
        };

        switch(direction){
            case MoveDirection.Left:
                futurePosition[0]--;
                break;
            case MoveDirection.Forward:
                futurePosition[1]++;
                break;
            case MoveDirection.Right:
                futurePosition[0]++;
                break;
            case MoveDirection.Backward:
                futurePosition[1]--;
                break;
        }

        // Fails to move if outside the battlefield
        if(
            futurePosition[0] <= -1 || futurePosition[1] <= -1 ||
            futurePosition[0] >= CombatManager.BATTLEFIELD_DIMENSIONS[0] || 
            futurePosition[1] >= CombatManager.BATTLEFIELD_DIMENSIONS[1]
        ){
            Debug.Log($"[DEBUG]: Failed moving {combatant.CombatantTag}, to out of bounds position {futurePosition}");
            return null;
        }
        
        // Fails to move if a combatant is already at the future position
        if(GetCombatantAt(futurePosition) != null){
            Debug.Log($"[DEBUG]: Failed moving {combatant.CombatantTag}, to occupied position {futurePosition}");
            return null;
        }

        Debug.Log($"[DEBUG]: Successfully moved {combatant.CombatantTag}, from {tracker.currentPosition} to {futurePosition}");
        tracker.currentPosition = futurePosition;
        return tracker.currentPosition;
    }

    /// <summary>
    /// Get a combatant at a position
    /// </summary>
    /// <param name="position"></param>
    /// <returns>The combatant tracker at a position. Null if none exists</returns>
    private CombatantTracker GetCombatantAt(int[] position){
        foreach(CombatantTracker tracker in _allCombatants){
            if(tracker.currentPosition == position)
                return tracker;
        }

        return null;
    }

    private void SetStartHealth(Combatant combatant){
        CombatantTracker tracker = _combatants[combatant.CombatantTag];
        tracker.currentHealth = combatant.Stats.MaxHealth;
    }

    void Start(){
        if(_sharedInstance != null)
            Destroy(this);
        else 
            _sharedInstance = this;
    }
    private static CombatantManager _sharedInstance;
    public static CombatantManager Instance {
        get {  
            return _sharedInstance;
        }
    }
}
