using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnScreen : MonoBehaviour
{
    public static bool allTargetsDown;
    private TextMeshProUGUI shotsText;
    static int targets;

    void Start()
    {
        shotsText = GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Target").Length; i++)
        {
            targets++;
        }
    }

    void Update()
    {
        AllTargetsDown();
        TargetCount();
    }

    public void AllTargetsDown()
    {
        if (Target.killedTargets == 7)
        {
            allTargetsDown = true;
            shotsText.text = "All targets are down. Task completed!";
        }
    }

    public void TargetCount()
    {
        if (!allTargetsDown)
        {
            shotsText.text = "Remaining targets: " + (targets - Target.killedTargets);
        }
    }
}
