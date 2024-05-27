using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFridgeDoor : MonoBehaviour
{

	public Animator openandclose;
	public bool open;

	void Start()
	{
		open = false;
	}
        
    public IEnumerator opening()
	{
		openandclose.Play("Opening");
		open = true;
		yield return new WaitForSeconds(.5f);
	}

	public IEnumerator closing()
	{
		openandclose.Play("Closing");
		open = false;
		yield return new WaitForSeconds(.5f);
	}	
}
