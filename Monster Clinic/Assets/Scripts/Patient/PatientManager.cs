using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatientManager : MonoBehaviour {
	
	public List<Patient> patientsList = new List<Patient>();
	public Patient patientPrefab;
	
	// Use this for initialization
	void Start () {
		///lets spawn a new patient
		Patient patient = (Patient)Instantiate( patientPrefab, new Vector3(0,0,0), Quaternion.identity);
		patient.name = "Lisa";
		patientsList.Add(patient);
		
	}
	
}
