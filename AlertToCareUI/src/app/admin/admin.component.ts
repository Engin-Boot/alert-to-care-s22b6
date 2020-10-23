import { Component, OnInit } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'admin-comp',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
//add
  bedCountAdd:string="";
//update 
  icuIdUpdate:string="";
  bedCountUpdate:string="";
//get
  bedCountGet:string="";
  icuIdGet:string="";

  
  constructor() { }

  ngOnInit(): void {
  }

//Add new icu id
  onBedCountAddEdit(value){
    this.bedCountAdd=value;
  }
  //update
  onIcuIdUpdateEdit(value){
    this.icuIdUpdate=value;
  }
  onBedCountUpdateEdit(value){
    this.bedCountUpdate=value;
  }
  //get
  onIcuIdGetEdit(value){
    this.icuIdGet=value;
  }
 


  AddICUDetails(){
  
            var searchKey=this.bedCountAdd;

            var   httpReq = new XMLHttpRequest();
            httpReq.open("POST", "http://localhost:5000/api/admin/AddIcu/" + searchKey, true);
    
            httpReq.onreadystatechange = function () {
            
                if (httpReq.readyState == 4) {
                  if( httpReq.status==200) {
                    document.getElementById("resultDashboardAddIcu").innerHTML= "ICU deatils added successfully";
                    }
                  else{
                   document.getElementById("resultDashboardAddIcu").innerHTML="Request Status="+httpReq.status + "  Enter appropriate Bed count";
                  }
            }
            }

            httpReq.send();
  }

  UpdateICUDetails(){
           var searchKey=this.icuIdUpdate;
            var data = { id: parseInt(this.icuIdUpdate), bedCount: parseInt(this.bedCountUpdate), occupiedBeds: "" };
            var json = JSON.stringify(data);
            var   httpReq = new XMLHttpRequest();
            httpReq.open("PUT", "http://localhost:5000/api/admin/UpdateIcu/", true);
            httpReq.setRequestHeader('Content-type','application/json; charset=utf-8');
            httpReq.onreadystatechange = function () {

            if (httpReq.readyState == 4){
              if(httpReq.status==200) {
                document.getElementById("resultDashboardUpdateIcu").innerHTML="ICU deatils updated successfully";
               }
               else{
               document.getElementById("resultDashboardUpdateIcu").innerHTML="Request Status="+httpReq.status+" Enter appropriate Icu Id";
               }
          }
  }

  httpReq.send(json);
  }

  GetICUDetails(){

           var searchKey=this.icuIdGet;
           var   httpReq = new XMLHttpRequest();
            httpReq.open("GET", "http://localhost:5000/api/admin/IcuDetails/" + parseInt(searchKey), true);
          
            httpReq.onreadystatechange = function () {
                console.log("callback");
                if (httpReq.readyState == 4){
                if(httpReq.status==200) {
                 
                    var obj = JSON.parse(httpReq.responseText);
                    document.getElementById("resultDashboardICUbyid").innerHTML="ICU Id="+obj.id +"  Bed Count="+obj.bedCount +"  Occupied Bed Count=" +obj.occupiedBeds;
                }
                else{
                  document.getElementById("resultDashboardICUbyid").innerHTML="Request Status="+httpReq.status+" Enter appropriate Icu Id";
                }
                }
            }
            httpReq.send();
  }
  GetAllICUDetails(){

           var   httpReq = new XMLHttpRequest();
            httpReq.open("GET", "http://localhost:5000/api/admin/AllIcuDetails" , true);
          
            //registering callback - to get updates on status of http request
            httpReq.onreadystatechange = function () {
                console.log("callback");
                if (httpReq.readyState == 4 && httpReq.status==200) {
                  
                    document.getElementById("resultDashboardAllICU").innerHTML=httpReq.responseText;
                }
            }
            httpReq.send();
  }
  ResetAddDetails(){
    this.bedCountAdd="";
    document.getElementById("resultDashboardAddIcu").innerHTML="";
  }
  ResetUpdateDetails(){
    this.icuIdUpdate="";
    this.bedCountUpdate="";
    document.getElementById("resultDashboardUpdateIcu").innerHTML="";
  }
  ResetGetDetails(){
    this.icuIdGet="";
    this.bedCountGet="";
    document.getElementById("resultDashboardICUbyid").innerHTML="";
  }
  ResetGetAllDetails(){
    document.getElementById("resultDashboardAllICU").innerHTML="";

  }
}
