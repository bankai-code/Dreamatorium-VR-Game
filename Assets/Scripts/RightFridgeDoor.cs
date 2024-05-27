using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFridgeDoor : MonoBehaviour
{
    public Animator openandclose1;
	public bool open;

	void Start()
	{
		open = false;
	}

	public IEnumerator opening()
	{
	    openandclose1.Play("Opening 1");
		open = true;
		yield return new WaitForSeconds(.5f);
	}

	public IEnumerator closing()
	{
		openandclose1.Play("Closing 1");
		open = false;
		yield return new WaitForSeconds(.5f);
	}
}
