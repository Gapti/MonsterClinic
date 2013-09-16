using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaffList : MonoBehaviour{
	
	public List<Octodoctor> _octodoctorList = new List<Octodoctor>(); //make 6 of each 
	public List<Cthuluburse> _ctuluburseList = new List<Cthuluburse>();
	public List<Yetitor> _yetitorList = new List<Yetitor>();
	
	public Octodoctor GetOctodoctor()
	{
		Octodoctor temp = _octodoctorList[0];
		_octodoctorList.RemoveAt(0);
		return temp;
	}
	
	public Cthuluburse GetCtuluburse()
	{
		Cthuluburse temp = _ctuluburseList[0];
		_ctuluburseList.RemoveAt(0);
		return temp;
	}
	
	public Yetitor GetYetitor()
	{
		Yetitor temp = _yetitorList[0];
		_yetitorList.RemoveAt(0);
		return temp;	
	}
	
	
	void Start()
	{
		MakeStaffct(6);
		MakeStaffOcto(6);
		MakeStaffYet(6);
	}
	
	void MakeStaffOcto(int amount)
	{
		for(int a= 0; a < amount; a++)
		{
			Octodoctor o = new Octodoctor();
			_octodoctorList.Add (o);
		}
	}
	
	void MakeStaffYet(int amount)
	{
		for(int a= 0; a < amount; a++)
		{
			Yetitor y = new Yetitor();
			_yetitorList.Add (y);
		}
	}
	
	void MakeStaffct(int amount)
	{
		for(int a= 0; a < amount; a++)
		{
			Cthuluburse c = new Cthuluburse();
			_ctuluburseList.Add (c);
		}
	}

}
