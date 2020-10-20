import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'patient-comp',
  templateUrl: './patientadmission.component.html',
  styleUrls: ['./patientadmission.component.css']
})
export class PatientadmissionComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  AddPatientDetails(){
    alert("Patient Details Added Successfully");
  }
  DischargePatient(){
    alert("Discharge");
  }
  GetPatientDetails(){
    alert("Patient Details Shown Successfully");
  }

}
