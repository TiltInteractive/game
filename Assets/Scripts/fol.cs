using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fol : MonoBehaviour

{

  public float damping = 4f;
	public Vector2 offset = new Vector2(0.32f, 0f);
	public bool faceLeft;
	public Transform player;

	private int lastX;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(faceLeft);
    }

    public void FindPlayer(bool playerFaceLeft)
	{
		player =GameObject.Find("Player").transform;

		lastX = Mathf.RoundToInt(player.position.x);
		if(playerFaceLeft)
		{
			transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
		}
	}

    // Update is called once per frame
    void Update()
    {
        if(player)
		{

			if (Player.direction.x < 0) {

					faceLeft = true;
			}
			else if (Player.direction.x > 0) {

					faceLeft = false;
					
			}


			Vector3 target;
			if(faceLeft)
			{
				target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
			}
			else
			{
				target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
			}
			Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;

		}
    }
}
