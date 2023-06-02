using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RoomGeneration : MonoBehaviour

{
    public bool shop = false;
    static public int lenght_public, width_public;
    public GameObject Bullet;
    static public int part = 1;
    static public int level = 1;
    public GameObject edge;
    public GameObject floor;
    public GameObject floor_edge_left_up;
    public GameObject floor_edge_left;
    public GameObject floor_edge_left_down;
    public GameObject floor_edge_down;
    public GameObject floor_edge_right_down;
    public GameObject floor_edge_right;
    public GameObject floor_edge_right_up;
    public GameObject floor_edge_up;
    public GameObject level_end;
    public int gapVertical = 4;
    public int gapHorizontal = 3;
    public GameObject box;
    int[,] occupied_cells = new int[1000, 1000];
    public int n = 1;
    public float sizeF = 0.32f;
    double lenght;
    double width;
    // Start is called before the first frame update
    public void Start()

    {
        box = Resources.Load<GameObject>("Prefab/RoomComponents/box");
        edge = Resources.Load<GameObject>("Prefab/RoomComponents/edge");
        floor = Resources.Load<GameObject>("Prefab/RoomComponents/floor");
        floor_edge_left_up = Resources.Load<GameObject>("Prefab/RoomComponents/floor_edge_left_up");
        floor_edge_left = Resources.Load<GameObject>("Prefab/RoomComponents/floor_edge_left");   
        floor_edge_left_down = Resources.Load<GameObject>("Prefab/RoomComponents/floor_edge_left_down");
        floor_edge_down = Resources.Load<GameObject>("Prefab/RoomComponents/floor_edge_down");
        floor_edge_right_down = Resources.Load<GameObject>("Prefab/RoomComponents/floor_edge_right_down");
        floor_edge_right = Resources.Load<GameObject>("Prefab/RoomComponents/floor_edge_right");
        floor_edge_right_up = Resources.Load<GameObject>("Prefab/RoomComponents/floor_edge_right_up");
        floor_edge_up = Resources.Load<GameObject>("Prefab/RoomComponents/floor_edge_up");
        level_end = Resources.Load<GameObject>("Prefab/RoomComponents/level_end");




        RoomGen();
        /*int[,] occupied_cells = new int[width_public, lenght_public];*/
        ObsticleGeneration();

        
    }

    public void roomPlacement(string s, Vector2 pos)
    {
        GameObject tileIns;
        switch (s)
        {
            case "*":
                create(edge, pos, s);
                break;
            case "+":
                create(level_end, pos, s);
                break;
            case "-":

                break;
            case " ":
                create(floor, pos, s);
                break;
            case "|‾":
                create(floor_edge_left_up, pos, s);
                break;

            case "‾|":
                create(floor_edge_right_up, pos, s);
                break;

            case "‾":
                create(floor_edge_up, pos, s);
                break;

            case "|-":
                create(floor_edge_left, pos, s);
                break;

            case "|_":
                create(floor_edge_left_down, pos, s);
                break;

            case "_":
                create(floor_edge_down, pos, s);
                break;

            case "_|":
                create(floor_edge_right_down, pos, s);
                break;

            case "-|":
                create(floor_edge_right, pos, s);
                break;

        }

    }

    public void create(GameObject newBlock, Vector2 pos, string s) {
        Vector2 size = new Vector2(1, 1);
        pos.x = pos.x * sizeF;
        pos.y = pos.y * -sizeF;
        Vector2 position = pos;

        if (s == "+")
        {
            pos.y -= 0.16f;
            newBlock.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        newBlock.tag = "roomComponent";
        Instantiate(newBlock, pos, Quaternion.identity);

        /*GameObject newBlock = new GameObject("roomComponent");
        newBlock.gameObject.tag = "roomComponent";
        newBlock.transform.position = position;
        newBlock.transform.localScale = size;
        newBlock.layer = LayerMask.NameToLayer("Mesh");*/


        /* if (s == "*") {
             Instantiate(gameobj, pos, Quaternion.identity);

         }*/


        /*else if(s == "+") {
            newBlock.AddComponent<BoxCollider2D>();
            newBlock.GetComponent<BoxCollider2D>().offset = new Vector2(0.375f*sizeF, -0.5f*sizeF);
            newBlock.GetComponent<BoxCollider2D>().size = new Vector2(0.25f*sizeF, 2*sizeF);
            newBlock.GetComponent<BoxCollider2D>().isTrigger = true;
            newBlock.AddComponent<LevelEnd>();
            
        }
        SpriteRenderer renderer = newBlock.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;*/

    }

    public void Create_ob(GameObject newBlock, Vector2 pos)
    {
        Vector2 size = new Vector2(1, 1);
        pos.x = pos.x * sizeF;
        pos.y = pos.y * -sizeF;
        Vector2 position = pos;

        newBlock.tag = "roomComponent";
        Instantiate(newBlock, pos, Quaternion.identity);

    }

    public float randN() {
        return Random.Range(1.0f, 2.0f);
    }
    public void RoomGen()
    {
        Vector2 pos;

        float rand = randN();
        lenght = 14 * Mathf.Pow(part * level * rand, 1.0f / 3.0f);
        width = 8 * Mathf.Pow(part * level * rand, 1.0f / 3.0f);
        lenght = (int)(lenght);
        width = (int)(width);
        lenght_public = (int)(lenght);
        width_public = (int)(width);
        for (int j = 0; j < width; j++)
        {
            for (int i = 0; i < lenght; i++)
            {
                if (j == 0 || j == width - 1)
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("*", pos);
                } 
                
                else if (i == 0 || i == lenght - 1)
                {
                    if (((i == 0) && (j == 2 || j == 3)))
                    {
                        pos.x = i;
                        pos.y = j;
                        roomPlacement("-", pos);
                    }
                    else if ((i == lenght - 1) && (j == width - 4))
                    {
                        pos.x = i;
                        pos.y = j;
                        roomPlacement("+", pos);
                    }
                    else if((j == width - 3) && (i == lenght - 1)){}
                    else
                    {
                        pos.x = i;
                        pos.y = j;
                        roomPlacement("*", pos);
                    }
                }

                else if (j == 1 && i == 1)
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("|‾", pos);
                }

                else if (j == 1 && i == lenght - 2)
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("‾|", pos);
                }

                else if (j == 1 && (i > 1 && i < lenght - 2))
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("‾", pos);
                }

                else if (j > 1 && j < width - 2 && i == 1)
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("|-", pos);
                }

                else if (j == width - 2 && i == 1)
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("|_", pos);
                }

                else if (j == width - 2 && (i > 1 && i < lenght - 2))
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("_", pos);
                }

                else if (j == width - 2 && i == lenght - 2)
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("_|", pos);
                }

                else if (j > 1 && j < width - 2 && i == lenght - 2)
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement("-|", pos);
                }

                else
                {
                    pos.x = i;
                    pos.y = j;
                    roomPlacement(" ", pos);
                }
            }
        }

    }


    void ObsticleGeneration()
    {
        

        void Obsticle1(int y, int x) {
            Vector2 pos = new Vector2(x, y);
            occupied_cells[y, x] = 1;
            Create_ob(box, pos);
            pos.y += 1;
            occupied_cells[y+1, x] = 1;
            Create_ob(box, pos);
            pos.y += 1;
            occupied_cells[y+2, x] = 1;
            Create_ob(box, pos);
            
        }

        void Obsticle2(int y, int x)
        {
            Vector2 pos = new Vector2(x, y);
            occupied_cells[y, x] = 1;
            Create_ob(box, pos);
            pos.x += 1;
            occupied_cells[y, x+1] = 1;
            Create_ob(box, pos);
            pos.x += 1;
            occupied_cells[y, x+2] = 1;
            Create_ob(box, pos);
        }

        void Obsticle3(int y, int x)
        {
            Vector2 pos = new Vector2(x, y);
            occupied_cells[y, x] = 1;
            Create_ob(box, pos);
            pos.x += 1;
            occupied_cells[y, x + 1] = 1;
            Create_ob(box, pos);
            pos.y += 1;
            occupied_cells[y + 1, x + 1] = 1;
            Create_ob(box, pos);
        }

        for (int j = 2; j < width-3; j+=gapVertical)
        {
            for (int i = 2; i < lenght-3; i+=gapHorizontal)
            {
/*                float gen_or_non = Random.Range(0.0f, 1.0f);*/
                if (Random.Range(0.0f, 1.0f) < 0.6f)
                {
                    int why_gen = Random.Range(0, 3);
                    if (why_gen == 0) Obsticle1(j, i);
                    else if (why_gen == 1) Obsticle2(j, i);
                    else if (why_gen == 2) Obsticle3(j, i);
                }
                else
                {
                    /*Vector2 pos = new Vector2(i, j);
                    create(edge, pos, "*");*/
                }
            }
        }


    }


    // Update is called once per frame

}
