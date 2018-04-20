/**/

using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino : MonoBehaviour {


	[SerializeField] public GameObject Object3d;
	[SerializeField] public Material material1;
	[SerializeField] public Material material2;
	[SerializeField] public Shader shader2;
	[SerializeField] public Shader shader1;

	private Renderer holoRenderer;

	SerialPort sp; //whatever COM arduino uses

	private void Awake()
	{
		try
		{
			sp = new SerialPort("COM3", 9600);
		}
		catch(System.Exception )
		{

		}
	}

	void Start()
	{

		holoRenderer = GetComponent<Renderer>();

		try
		{
			sp.Open();
			sp.ReadTimeout = 1;
		}
		catch(System.Exception)
		{

		}

	}

	// Update is called once per frame
	void Update () {

       

        if (sp.IsOpen)
		{
            try
			{
				int ByT3z = sp.ReadByte(); // DO WHATEVER THE *YOU WANT
				Debug.Log(ByT3z);
				holoRenderer.material = material1;

				switch(ByT3z)
				{
				case 1 :
					
					holoRenderer.material.shader = shader2;
					break;


				default :
					holoRenderer.material.shader = shader1;
					break;
				}

               

            }
			catch (System.Exception)
			{
				Debug.Log ("catch");
			}
		}
		else
		{

			if(Input.GetKeyDown(KeyCode.R))
			{
				//Do something
				Debug.Log("lee alterno");
			}
		}
	}




}