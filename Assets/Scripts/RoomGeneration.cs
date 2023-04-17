using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour

{
    public GameObject Bullet;
    public int part = 1;
    public int level = 1;
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
    public float sizeF = 0.32f;

    // Start is called before the first frame update
    void Start()
    {
        RoomGen();
    }

    public void roomPlacement(string s, Vector2 pos)
    {
        GameObject tileIns;
        switch (s)
        {
            case "*":

                Debug.Log(pos);
                create(edge, pos, s);
                break;
            case "+":
                Debug.Log(pos);
                break;
            case "-":
                Debug.Log(pos);

                break;
            case " ":
                Debug.Log(pos);
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
        pos.y = pos.y * -sizeF;
        Vector2 position = pos;
        
        
        GameObject newBlock = new GameObject("roomComponent");
        newBlock.transform.position = position;
        newBlock.transform.localScale = size;
        if(s == "*") {
            newBlock.AddComponent<BoxCollider2D>();
            newBlock.GetComponent<BoxCollider2D>().size = new Vector2(sizeF, sizeF);
        }
        SpriteRenderer renderer = newBlock.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        
    }


    public void RoomGen()
    {
        Vector2 pos;
        

        double lenght = 14 * Mathf.Sqrt(part * level), width = 8 * Mathf.Sqrt(part * level);
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
                    else if ((i == lenght - 1) && (j == width - 3 || j == width - 4))
                    {
                        pos.x = i;
                        pos.y = j;
                        roomPlacement("+", pos);
                    }
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
