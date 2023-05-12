using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RoomGeneration : MonoBehaviour

{
    static public int lenght_public, width_public;
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

    public Sprite box;
    int[,] occupied_cells = new int[1000, 1000];

    public float sizeF = 0.32f;
    double lenght;
    double width;
    public Sprite[] spriteArray;
    // Start is called before the first frame update
    public void Start()

    {
        box = Resources.Load<Sprite>("Textures/sprites/box");
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

    public void create(Sprite sprite, Vector2 pos, string s) {
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

    public void Create_ob(Sprite sprite, Vector2 pos)
    {
        Vector2 size = new Vector2(1, 1);
        pos.x = pos.x * sizeF;
        pos.y = pos.y * -sizeF + 0.64f;
        Vector2 position = pos;


        GameObject newBlock = new GameObject("roomComponent");
        newBlock.gameObject.tag = "roomComponent";
        newBlock.transform.position = position;
        newBlock.transform.localScale = size;

        newBlock.AddComponent<BoxCollider2D>();
        newBlock.GetComponent<BoxCollider2D>().size = new Vector2(sizeF, sizeF);

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

        for (int j = 2; j < width-3; j+=3)
        {
            for (int i = 2; i < lenght-3; i+=4)
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
