using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOE : MonoBehaviour
{
    public float _AOE_Flash;
    public float _AOE_Flash_Timer;
    public float _AOE_Flash_Speed;
    public bool _AOE_IsFlashing;
    public int _AOE_FlashCounter = 0;
    public int _AOE_Max_FlashCounter = 3;
    public SkillsTimers _SkillsTimers_Script;

    // Start is called before the first frame update
    void Start()
    {
        _AOE_IsFlashing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_AOE_IsFlashing && _AOE_FlashCounter < _AOE_Max_FlashCounter)
        {
            if (shouldResetTimer())
            {
                // Reset timer
                _AOE_Flash = 0f;
                _AOE_FlashCounter++;
            }
            // Update timers
            _AOE_Flash += Time.deltaTime * _AOE_Flash_Speed;
            // Perform Flash
            PerformFlash();
        }
        if (_AOE_FlashCounter == _AOE_Max_FlashCounter)
        {
            _AOE_IsFlashing = false;
            _SkillsTimers_Script.skillsImages[0].fillAmount = 0;
        }
    }

    private bool shouldResetTimer()
    {
        return _AOE_Flash >= _AOE_Flash_Timer;
    }

    public void PerformFlash()
    {
        foreach (Transform child in transform)
        {
            // if(child.gameObject.name == "Lazer")
            //  {
            var image = child.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = _AOE_Flash / 100; //0f;
            image.color = tempColor;
            // }
        }
    }
}
