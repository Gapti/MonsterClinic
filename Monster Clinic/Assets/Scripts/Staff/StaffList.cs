using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaffList : MonoBehaviour{
	
	public static List<Octodoctor> _octodoctorList = new List<Octodoctor>();
	public static List<Cthuluburse> _ctuluburseList = new List<Cthuluburse>();
	public static List<Yetitor> _yetitorList = new List<Yetitor>();
	
	
	void Awake()
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
