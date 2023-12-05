using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueCheck_pg2 : MonoBehaviour
{
    public GameObject clue1;
    public GameObject clue2;
    public GameObject clue3;
    public GameObject clue4;
    public GameObject clue5;

    private int count = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "hDiary1")
            {
                count++;
            }else if(collision.tag == "hDiary2")
            {
                count++;

            }
            else if (collision.tag == "mMemo")
            {
                count++;

            }
            else if (collision.tag == "oMemo2")
            {
                count++;

            }
            else if (collision.tag == "hDiary__2")
            {
                count++;

            }
        }

        if(count == 5)
        {
            clue5.SetActive(true);
        }

    }
}
