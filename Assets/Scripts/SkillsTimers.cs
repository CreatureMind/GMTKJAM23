using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsTimers : MonoBehaviour
{
    [SerializeField]
    private float[] skillsTimers = new float[4];

    [SerializeField]
    private float[] skillsIntervals = new float[4];

    [SerializeField]
    public Image[] skillsImages = new Image[4];
    public AOE[] _AOE_Script = new AOE[4];

    public GameObject[] _SkillsProjectiles = new GameObject [4];
    public float _ActiveTimerFire;
    public float[] _ActiveTimerFireArray = new float [4];

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            
            if(_AOE_Script[i]._ShouldFireProjectile == true)
            {
                 if(_SkillsProjectiles[i].GetComponent<WaveProjectile>() != null) //Wave Attack
                 {
                _SkillsProjectiles[i].GetComponent<WaveProjectile>().expandCircle = true;
                _SkillsProjectiles[i].GetComponent<WaveProjectile>().enteredLoop = true;
                 }
                  if(_SkillsProjectiles[i].GetComponent<ScatterScript>() != null) //Wave Attack
                 {
                _SkillsProjectiles[i].GetComponent<ScatterScript>().activate = true;
                 }
                 _SkillsProjectiles[i].SetActive(true);
                 _AOE_Script[i]._ShouldFireProjectile = false;
            }

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
         
          if (_ActiveTimerFire >= _ActiveTimerFireArray[i])
                {
                    // Perform attack
                    // if(_SkillsProjectiles[i].GetComponent<WaveProjectile>() != null) //Wave Attack
                    // {
                    //  if(_SkillsProjectiles[i].GetComponent<WaveProjectile>().circleRadius >= _SkillsProjectiles[i].GetComponent<WaveProjectile>().circleMaxRadius)
                    //  {
                    // _SkillsProjectiles[i].GetComponent<WaveProjectile>().expandCircle = false;
                    // _SkillsProjectiles[i].SetActive(false);
                    //  }
                    // }
                     if(_SkillsProjectiles[i].GetComponent<WaveProjectile>() == null)
                     if(_SkillsProjectiles[i].GetComponent<ScatterScript>() == null)
                     _SkillsProjectiles[i].SetActive(false);
                    // Reset timer
                    _ActiveTimerFire = 0f;
                 
                }
         
         
                // Update timers
                skillsTimers[i] += Time.deltaTime;
                _ActiveTimerFire += Time.deltaTime;
            }
            else
            {
                if (!_AOE_Script[i]._AOE_IsFlashing)
                {
                     skillsImages[i].fillAmount = 0;
                    _AOE_Script[i]._AOE_IsFlashing = true;
                }
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

        //Wave Attack
        if (attackIndex == 1)
        {
            // print("Wave Attack");
        }

        //Slash Attack
        if (attackIndex == 2)
        {
            //   print("Slash Attack");
        }

        //Scattar Attack
        if (attackIndex == 3)
        {
            //    print("Scattar Attack");
        }
    }
}
