import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'patient-comp',
  templateUrl: './patientadmission.component.html',
  styleUrls: ['./patientadmission.component.css']
})
export class PatientadmissionComponent implements OnInit {
//add patient
 
  patientNameAdd:string="";
  contactNoAdd:string="";
  icuIdIdAdd:string="";
  bedIdAdd:string="";

  //discharge
  patientIddischarge:string="";
  //get
  patientId1:string="";
  constructor() { }

  ngOnInit(): void {
  }
  //add patient details
 
  onPatientNameAddEdit(value){
    this.patientNameAdd=value;
  }
  onContactNoAddEdit(value){
    this.contactNoAdd=value;
  }
  onIcuIdAddEdit(value){
    this.icuIdIdAdd=value;
  }
  onBedIdAddEdit(value){
    this.bedIdAdd=value;
  }
  //discharge patient
  onPatientIddischargeEdit(value){
    this.patientIddischarge=value;
  }
  //get
  onPatientIdEdit1(value){
    this.patientId1=value;
  }



  AddPatientDetails(){
            var data = { Name: this.patientNameAdd, Contact:this.contactNoAdd,BedId:parseInt(this.bedIdAdd), IcuId:parseInt(this.icuIdIdAdd)};
  
           var json = JSON.stringify(data);
            var   httpReq = new XMLHttpRequest();
            httpReq.open("POST", "http://localhost:5000/api/patient/AddNewPatient/", true);
            httpReq.setRequestHeader('Content-type','application/json; charset=utf-8');
          
            //registering callback - to get updates on status of http request
            httpReq.onreadystatechange = function () {
            if (httpReq.readyState == 4) {
              if( httpReq.status==200) {
                document.getElementById("resultDashboardAddpatient").innerHTML= "Patient deatils added successfully";
                }
              else{
               document.getElementById("resultDashboardAddpatient").innerHTML="Request Status="+httpReq.status + "  Enter appropriate Details";
              }
             }
            }
            httpReq.send(json);

  }

  DischargePatient(){
    var searchKey=this.patientIddischarge;
    //AJAX Request - Asynchronous Http Request;
   var   httpReq = new XMLHttpRequest();
    httpReq.open("GET", "http://localhost:5000/api/patient/discharge/" + searchKey, true);
  
    //registering callback - to get updates on status of http request
    httpReq.onreadystatechange = function () {
        console.log("callback");
        if (httpReq.readyState == 4) {
          if(httpReq.responseText=="200"){
            document.getElementById("resultDashboarddischargepatient").innerHTML="Patient Discharged Successfully";
          }
          else{
            document.getElementById("resultDashboarddischargepatient").innerHTML="Request Status="+httpReq.responseText + "  Enter appropriate Patient Id";
          }
        }
    }
    httpReq.send();

  }

  GetPatientDetails(){
    var searchKey=this.patientId1;
    //AJAX Request - Asynchronous Http Request;
   var   httpReq = new XMLHttpRequest();
    httpReq.open("GET", "http://localhost:5000/api/patient/PatientDetails/" + searchKey, true);
  
    //registering callback - to get updates on status of http request
    httpReq.onreadystatechange = function () {
        console.log("callback");
        if (httpReq.readyState == 4) {
          if(httpReq.status==200){
            document.getElementById("resultDashboard1").innerHTML=httpReq.responseText;
          }
          else{
            document.getElementById("resultDashboard1").innerHTML="Request Status="+httpReq.status + "  Enter appropriate Patient Id";
          }
        }
    }
    httpReq.send();
  }

  GetAllPatientDetails(){
   var   httpReq = new XMLHttpRequest();
    httpReq.open("GET", "http://localhost:5000/api/patient/AllPatientDetails" , true);
  
    httpReq.onreadystatechange = function () {
        console.log("callback");
        if (httpReq.readyState == 4) {
          if(httpReq.status==200){
            document.getElementById("resultDashboardall").innerHTML=httpReq.responseText;
          }
          else{
            document.getElementById("resultDashboardall").innerHTML="Request Status="+httpReq.status + "  Enter appropriate Patient Id";
          }
        }
    }
    httpReq.send();
  }

  ResetDischargePatientDetails(){
    this.patientIddischarge="";
    document.getElementById("resultDashboarddischargepatient").innerHTML="";
    
  }
  ResetAddPatientDetails(){
    this.bedIdAdd="";
    this.icuIdIdAdd="";
    this.patientNameAdd="";
    this.contactNoAdd="";
    document.getElementById("resultDashboardAddpatient").innerHTML="";
  }
  ResetGetPatientDetails(){
    
    this.patientId1="";
    document.getElementById("resultDashboard1").innerHTML="";
  }
  ResetGetAllPatientDetails(){
    document.getElementById("resultDashboardall").innerHTML="";
  }
}
