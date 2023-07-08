using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterScript : MonoBehaviour
{
    float timer = 0;
    [SerializeField] private GameObject prefab;
    GameObject[] hitzone = new GameObject[8];
    bool isShowen = false;
    public bool activate = false;

    private void Update()
    {
        transform.position = GameObject.Find("Boss").transform.position;

        timer += Time.deltaTime;

        if(activate)
        {         
                for (int i = 0; i < 8; i++)
                {
                    Vector2 v = Random.insideUnitCircle * 300f;
                    Vector3 hitzonposition = new Vector3(v.x, 100f, v.y) + transform.position;
                    hitzone[i] = Instantiate(prefab, hitzonposition , Quaternion.identity);
                    hitzone[i].gameObject.transform.eulerAngles = new Vector3(
                     hitzone[i].gameObject.transform.eulerAngles.x + 90f,
                     hitzone[i].gameObject.transform.eulerAngles.y,
                     hitzone[i].gameObject.transform.eulerAngles.z
                            );
                            // hitzone[i].transform.LookAt(transform.position, Vector3.down);
                hitzone[i].GetComponent<Rigidbody>().AddForce(transform.up * -75f, ForceMode.Impulse);
                }
                activate = false;
               
            
        }
       
     
    }
    
}
