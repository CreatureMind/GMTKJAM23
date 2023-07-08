using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsTimers : MonoBehaviour
{
    [SerializeField]
    private float[] skillsTimers = new float[1];

    [SerializeField]
    private float[] skillsIntervals = new float[1];

    [SerializeField]
    public Image[] skillsImages = new Image[1];
    public AOE _AOE_Script;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 1; i++)
        {
            if (skillsImages[i].fillAmount < 1)
            {
                skillsImages[i].fillAmount = skillsTimers[i] / skillsIntervals[i];
                if (skillsTimers[i] >= skillsIntervals[i])
                {
                    // Perform attack
                    PerformAttack(i);
                    // Reset timer
                    skillsTimers[i] = 0f;
                }
                // Update timers
                skillsTimers[i] += Time.deltaTime;
            }
            else
            {
                if (!_AOE_Script._AOE_IsFlashing)
                    _AOE_Script._AOE_IsFlashing = true;
            }
        }
    }

    public void PerformAttack(int attackIndex)
    {
        //Laser Attack
        if (attackIndex == 0)
        {
            //  print("Laser Attack");
        }

        // //Wave Attack
        // if (attackIndex == 1)
        // {
        //     // print("Wave Attack");
        // }

        // //Slash Attack
        // if (attackIndex == 2)
        // {
        //     //   print("Slash Attack");
        // }

        // //Scattar Attack
        // if (attackIndex == 3)
        // {
        //     //    print("Scattar Attack");
        // }
    }
}
