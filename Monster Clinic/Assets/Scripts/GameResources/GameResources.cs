using UnityEngine;
using System.Collections;

public class GameResources : MonoBehaviour {
	
	public UILabel glitterLabel;
	public UILabel powerLabel;
	public UILabel techologyLabel;
	
	private int _glitter;
	private int _power;
	private int _technologyPoints;
		
	
	void Start()
	{
		Glitter = 300;///starting money
		Power = 100;
		TechnologyPoints = 20;
	}
	
	public int Glitter
	{
		get
		{
			return _glitter;
		}
		
		set
		{
			_glitter = value;
			UpdateValues();
		}
	}
	
	public int OffordItemCheck(int a)
	{
			return (_glitter - a);
	}
	
	
	public int Power
	{
		get
		{
			return _power;	
		}
		
		set
		{
			_power = value;
			UpdateValues();
		}
	}
	
	public int TechnologyPoints
	{
		get
		{
			return _technologyPoints;	
		}
		
		set
		{
			_technologyPoints = value;
			UpdateValues();
		}
	}
		
	private void UpdateValues ()
	{
		glitterLabel.text = _glitter.ToString();
		powerLabel.text = _power.ToString();
		techologyLabel.text = _technologyPoints.ToString();
	}	
	
}
