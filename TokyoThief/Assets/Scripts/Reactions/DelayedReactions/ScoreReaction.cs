using UnityEngine;
using UnityEngine.UI;

// This Reaction is for turning Behaviours on and
// off.  Behaviours are a subset of Components
// which have the enabled property, for example
// all MonoBehaviours are Behaviours as well as
// Animators, AudioSources and many more.
public class ScoreReaction : DelayedReaction
{
    public int moneyToAdd;     // The Behaviour to be turned on or off.
    Text moneyText;
    int moneyAmt;


    protected override void ImmediateReaction()
    {
        moneyText = (GameObject.Find("MoneyText")).GetComponent<Text>();
        moneyAmt = int.Parse(moneyText.text);
        moneyAmt += moneyToAdd;
        moneyText.text = moneyAmt.ToString();
    }
}