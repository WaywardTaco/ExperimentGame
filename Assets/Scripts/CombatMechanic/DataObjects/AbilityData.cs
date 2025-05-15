using System.Collections.Generic;

public class AbilityData {
    
    public string 
        ReferenceTag,   // Reference tag for data connections
        Name,           // The display name for the ability
        Description,    // The display description for the ability
        Affinity,       // The affinity/element of the ability
        PotencyStat,    // The stat used to determine the potency of the ability (ie. ATK/SPA etc.)
        HitrateStat;    // The stat used to determine the accuracy/hitrate of the ability (ie. ATK/SPA etc.)

    public int
        BasePotency,    // Base potency of the ability
        BaseHitrate;    // Base accuracy/hitrate of the ability
    
    public List<string>
        Targets,        // The specific targets the ability may target
        TypeTags,       // Any special ability type tags the ability fulfullis 
        EffectTags,     // The tag to the equivalent in-game effects script
        Icons;          // The list of icons used for the look of the ability

}
