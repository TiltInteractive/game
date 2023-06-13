using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInit : MonoBehaviour
{

    public GameObject FirstGun;
    public GameObject SecondGun;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("handgun") == 1)
        {
            FirstGun = Resources.Load<GameObject>("Prefab/Weapons/handgun");
            AddGun(0);
        }
        if(PlayerPrefs.GetInt("SmokeGun") == 1)
        {
            SecondGun = Resources.Load<GameObject>("Prefab/Weapons/SmokeGun");
            AddGun(1);
        }
    }
    public GameObject LoadGun(int id)
    {
        GameObject Gun = null;
        switch (id)
        {
            case 0:
                Gun = Resources.Load<GameObject>("Prefab/Weapons/handgun");
                break;

            case 1:
                Gun = Resources.Load<GameObject>("Prefab/Weapons/SmokeGun");
                break;
        }


        return Gun;
    }
    public void AddGun(int id)
    {
        if (FirstGun == null)
        {
            
            FirstGun = Init(LoadGun(id));
        }
        else if (FirstGun != null)
        {
            SecondGun = Init(LoadGun(id));
            FirstGun.SetActive(false);
        }
        else
        {
            Debug.Log("Нету места");
        }
    }

    public GameObject Init(GameObject Gun)
    {
        Vector2 pos;
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        GameObject gun = Instantiate(Gun, pos, Quaternion.identity);
        gun.transform.SetParent(GameObject.Find("Gun").transform);

        return gun;
    } 

    public void Change()
    {
        
            if (FirstGun.active)
            {
                SecondGun.SetActive(true);
                FirstGun.SetActive(false);
            }
            else
            {
                FirstGun.SetActive(true);
                SecondGun.SetActive(false);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Change();
            Debug.Log("смена");
        }


    }
}
