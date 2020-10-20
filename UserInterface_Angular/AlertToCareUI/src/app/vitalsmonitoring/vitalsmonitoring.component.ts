import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'vitals-comp',
  templateUrl: './vitalsmonitoring.component.html',
  styleUrls: ['./vitalsmonitoring.component.css']
})
export class VitalsmonitoringComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  AddPatientDetails(){
    alert("Vitals Added Successfully");
  }

}
