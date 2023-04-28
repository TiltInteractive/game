using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour

{

    public GameObject Bullet;
    static public int part = 1;
    static public int level = 1;
    public Sprite edge;
    public Sprite floor;
    public Sprite floor_edge_left_up;
    public Sprite floor_edge_left;
    public Sprite floor_edge_left_down;
    public Sprite floor_edge_down;
    public Sprite floor_edge_right_down;
    public Sprite floor_edge_right;
    public Sprite floor_edge_right_up;
    public Sprite floor_edge_up;
    public Sprite level_end;
    public float sizeF = 0.32f;
    public Sprite[] spriteArray;
    // Start is called before the first frame update
    public void Start()

    {

        spriteArray = Resources.LoadAll<Sprite>("Textures/room/room_sheet");
        edge = spriteArray[0];
        floor = spriteArray [5];
        floor_edge_left_up = spriteArray[1];
        floor_edge_left = spriteArray[4];
        floor_edge_left_down = spriteArray[7];
        floor_edge_down = spriteArray[8];
        floor_edge_right_down = spriteArray[9];
        floor_edge_right = spriteArray[6];
        floor_edge_right_up = spriteArray[3];
        floor_edge_up = spriteArray[2];
        level_end = floor_edge_right;
        RoomGen();
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

    private void create(Sprite sprite, Vector2 pos, string s) {
        Vector2 size = new Vector2(1, 1);
        pos.x = pos.x * sizeF;
        pos.y = pos.y * -sizeF + 0.64f;
        Vector2 position = pos;
        
        
        GameObject newBlock = new GameObject("roomComponent");
        newBlock.gameObject.tag = "roomComponent";
        newBlock.transform.position = position;
        newBlock.transform.localScale = size;
        if(s == "*") {
            newBlock.AddComponent<BoxCollider2D>();
            newBlock.GetComponent<BoxCollider2D>().size = new Vector2(sizeF, sizeF);

        }
        else if(s == "+") {
            newBlock.AddComponent<BoxCollider2D>();
            newBlock.GetComponent<BoxCollider2D>().offset = new Vector2(0.375f*sizeF, -0.5f*sizeF);
            newBlock.GetComponent<BoxCollider2D>().size = new Vector2(0.25f*sizeF, 2*sizeF);
            newBlock.GetComponent<BoxCollider2D>().isTrigger = true;
            newBlock.AddComponent<LevelEnd>();
            
        }
        SpriteRenderer renderer = newBlock.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        
    }

    public float randN() {
        return Random.Range(1.0f, 2.0f);
    }
    public void RoomGen()
    {
        Vector2 pos;

        float rand = randN();
        double lenght = 14 * Mathf.Pow(part * level* rand, 1.0f/3.0f), width = 8 * Mathf.Pow(part * level * rand, 1.0f / 3.0f);
        lenght = (int)(lenght);
        width = (int)(width);
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


    // Update is called once per frame

}
