import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'vitals-comp',
  templateUrl: './vitalsmonitoring.component.html',
  styleUrls: ['./vitalsmonitoring.component.css']
})
export class VitalsmonitoringComponent implements OnInit {
  bedIdVital:string="";
  icuIdVital:string="";
  spo2Vital:string="";
  bpmVital:string="";
  respVital:string="";


  constructor() { }

  ngOnInit(): void {
  }
  
  onBedIdVitalEdit(value){
    this.bedIdVital=value;
  }
  onIcuIdVitalEdit(value){
    this.icuIdVital=value;
  }
  onSpo2VitalEdit(value){
    this.spo2Vital=value;
  }
  onBpmVitalEdit(value){
    this.bpmVital=value;
  }
  onRespVitalEdit(value){
    this.respVital=value;
  }

  AddVitalsDetails(){
    
     var data=
     {
         IcuId:parseInt(this.icuIdVital),
         BedId:parseInt(this.bedIdVital),
         Vital:
         {
             Bpm: parseFloat(this.bpmVital),
             Spo2:parseFloat(this.spo2Vital),
             RespRate:parseFloat(this.respVital)
         }
        
      };

    var json = JSON.stringify(data);
     var   httpReq = new XMLHttpRequest();
     httpReq.open("POST", "http://localhost:5000/api/vitals/Monitor", true);
     httpReq.setRequestHeader('Content-type','application/json; charset=utf-8');
   
     //registering callback - to get updates on status of http request
     httpReq.onreadystatechange = function () {
         console.log("callback");
         if (httpReq.readyState == 4)
          {
            if(httpReq.status==200)
            {
              document.getElementById("resultvitals").innerHTML=httpReq.responseText;
            }
            else{
              document.getElementById("resultvitals").innerHTML="Request Status="+httpReq.status+" Enter appropriate Details";
            }
            
         }
     }

     httpReq.send(json);

      
  }
  ResetVitalsDetails(){
    this.icuIdVital="";
    this.bedIdVital="";
    this.bpmVital="";
    this.spo2Vital="";
    this.respVital="";
    document.getElementById("resultvitals").innerHTML="";
  }

}
