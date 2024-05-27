using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		// public Transform Player;

		void Start()
		{
			open = false;
		}

		// void OnMouseOver()
		// {
		// 	{
		// 		if (Player)
		// 		{
		// 			float dist = Vector3.Distance(Player.position, transform.position);
		// 			if (dist < 15)
		// 			{
		// 				if (open == false)
		// 				{
		// 					if (Input.GetMouseButtonDown(0))
		// 					{
		// 						StartCoroutine(opening());
		// 					}
		// 				}
		// 				else
		// 				{
		// 					if (open == true)
		// 					{
		// 						if (Input.GetMouseButtonDown(0))
		// 						{
		// 							StartCoroutine(closing());
		// 						}
		// 					}

		// 				}

		// 			}
		// 		}

		// 	}

		// }

		void OnCollisionEnter(Collision collision)
		{
			Debug.Log("Door Left");
			if(Input.GetKeyDown(KeyCode.X))
			{
				if(open)
				{
					StartCoroutine(closing());
				}
				else
				{
					StartCoroutine(opening());
				}
			}
		}

		public IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		public IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}