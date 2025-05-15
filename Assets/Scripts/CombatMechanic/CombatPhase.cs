
public abstract class CombatPhase {
    public string NextPhase;
    public bool WillExitPhase = false;
    public abstract void EnterPhase();    
    public abstract void PhaseLogic();
    public abstract void EndPhase();
}

public class StartCombatPhase : CombatPhase {
    public new string NextPhase = "StartRoundPhase";
    public override void EnterPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void PhaseLogic()
    {
        throw new System.NotImplementedException();
    }

    public override void EndPhase()
    {
        throw new System.NotImplementedException();
    }
}

public class EndCombatPhase : CombatPhase {
    public new string NextPhase = null;
    public override void EnterPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void PhaseLogic()
    {
        throw new System.NotImplementedException();
    }

    public override void EndPhase()
    {
        throw new System.NotImplementedException();
    }
}

public class StartRoundPhase : CombatPhase {
    public new string NextPhase = "UnitTurnPhase";
    public override void EnterPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void PhaseLogic()
    {
        throw new System.NotImplementedException();
    }

    public override void EndPhase()
    {
        throw new System.NotImplementedException();
    }
}

public class EndRoundPhase : CombatPhase {
    public new string NextPhase = "StartRoundPhase";
    public override void EnterPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void PhaseLogic()
    {
        throw new System.NotImplementedException();
    }

    public override void EndPhase()
    {
        throw new System.NotImplementedException();
    }
}

public class UnitTurnPhase : CombatPhase {
    public new string NextPhase = "EnemyActPhase";
    public override void EnterPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void PhaseLogic()
    {
        throw new System.NotImplementedException();
    }

    public override void EndPhase()
    {
        throw new System.NotImplementedException();
    }
}

public class EnemyActPhase : CombatPhase {
    public new string NextPhase = "ProcessMovesPhase";
    public override void EnterPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void PhaseLogic()
    {
        throw new System.NotImplementedException();
    }

    public override void EndPhase()
    {
        throw new System.NotImplementedException();
    }
}

public class ProcessMovesPhase : CombatPhase {
    public new string NextPhase = "EndRoundPhase";
    public override void EnterPhase()
    {
        throw new System.NotImplementedException();
    }

    public override void PhaseLogic()
    {
        throw new System.NotImplementedException();
    }

    public override void EndPhase()
    {
        throw new System.NotImplementedException();
    }
}
