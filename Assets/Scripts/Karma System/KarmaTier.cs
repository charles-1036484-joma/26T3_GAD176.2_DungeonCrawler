using UnityEngine;

 // THIS CLASS SHOULD ONLY DEAL WITH THE KARMA TIERS
 // I WANT TO USE PROGRAMMABLE OBJECTS
public class KarmaTier : MonoBehaviour
{
   

    [SerializeField]
    private int currentKarmaTier = 1;

    [SerializeField]
    private int MaxKarmaTier = 10;

    // I need Karma Tiers or Thresholds
    // What are those levels, how many tiers their ? 5 or maybe i make the number of tiers editable
    // Each Tier will 100 Karma points
    // Good & Bad Tier Thresholds
    // Tier 1 = 0 - 100
    // Tier 2 = 200 - 300
    // Tier 3 = 300 - 400
    // Tier 4 = 400 - 500
    // What will differentiate the two types of Karma points ?
    // A: A charge either negative of positive

    public int PublicCurrentKarmaTier
    {
        get { return currentKarmaTier; }
    }


    void Update()
    {
        
    }
}
