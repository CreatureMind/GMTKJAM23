using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterScript : MonoBehaviour
{
    float timer = 0;
    [SerializeField] private GameObject prefab;
    GameObject[] hitzone = new GameObject[4];
    bool isShowen = false;

    private void Update()
    {
        timer += Time.deltaTime;
        if (!isShowen)
        {
            if (timer >= 3)
            {
            isShowen = true;
                for (int i = 0; i < 4; i++)
                {
                    Vector2 v = Random.insideUnitCircle * 200f;
                    Vector3 hitzonposition = new Vector3(v.x, 7.69f, v.y) + transform.position;
                    hitzone[i] = Instantiate(prefab, hitzonposition , Quaternion.identity);
                }
                timer = 0;
            }
        }
        else
        {
            if (timer >= 1.5f)
            {
                for (int i = 0; i < 4; i++)
                {
                    Destroy(hitzone[i]);
                }
                timer = 0;
                isShowen = false;
            }
        }
    }
}
