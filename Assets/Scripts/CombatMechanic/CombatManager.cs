using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private readonly Dictionary<string, CombatPhase> _phases = new Dictionary<string, CombatPhase>{
        { "StartCombatPhase"    , new StartCombatPhase()    },
        { "StartRoundPhase"     , new StartRoundPhase()     },
        { "UnitTurnPhase"       , new UnitTurnPhase()       },
        { "EnemyActPhase"       , new EnemyActPhase()       },
        { "EndCombatPhase"      , new EndCombatPhase()      },
    };

    private CombatPhase _currentPhase;

    public void StartCombat(){
        SetPhase("StartCombatPhase");
    }

    public string GetPhaseTag(CombatPhase phase){
        foreach(var phasePair in _phases){
            if(phase == phasePair.Value)
                return phasePair.Key;
        }

        return null;
    }

    private void SetPhase(string phaseTag){
        if(phaseTag == null){
            _currentPhase?.EndPhase();
            _currentPhase = null;
        }

        if(!_phases.ContainsKey(phaseTag))
            return;

        _currentPhase?.EndPhase();

        _currentPhase = _phases[phaseTag];
        _currentPhase.EnterPhase();
    }

    void Update()
    {
        _currentPhase.PhaseLogic();
        if(_currentPhase.WillExitPhase)
            SetPhase(_currentPhase.NextPhase);
    }

    private void Initialize(){

    }

    public static CombatManager Instance { get; private set; } = null;
    void Start(){
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);

        Initialize();
    }
    void OnDestroy()
    {
        if(Instance == this)
            Instance = null;
    }
}
