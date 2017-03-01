using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCriteria {

    public List<Criteria> critters = new List<Criteria>();
    public WinCriteria( params Criteria[] criteria)
    {
        if(criteria !=null)
        critters.AddRange(criteria);
    }
    public void addCriteria(Criteria crit)
    {
        critters.Add(crit);
    }
    public bool criteriaMet()
    {
        bool isMet = false;
        foreach(Criteria c in critters)
        {
            if (!c()) return false;
            else isMet = true;
        }
        return isMet;
    }
}
