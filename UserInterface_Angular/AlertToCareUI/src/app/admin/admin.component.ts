import { Component, OnInit } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'admin-comp',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
//add
  bedCountAdd:string;
  icuIdAdd:string;
//update 
  icuIdUpdate:string;
  bedCountUpdate:string;
//get
  bedCountGet:string;
  icuIdGet:string;

  
  constructor() { }

  ngOnInit(): void {
  }
//Add new icu id
  onIcuIdAddEdit(value){
    this.icuIdAdd=value;
  }
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
  
            var searchKey=this.icuIdAdd;
            var data = { icuId: this.icuIdAdd, bedsCount: parseInt(this.bedCountAdd), layout: "Normal" };
    
            var json = JSON.stringify(data);
            var   httpReq = new XMLHttpRequest();
            httpReq.open("POST", "http://localhost:53133/api/configuration/AddIcu/" + searchKey, true);
            httpReq.setRequestHeader('Content-type','application/json; charset=utf-8');
          
            //registering callback - to get updates on status of http request
            httpReq.onreadystatechange = function () {
                console.log("callback");
                if (httpReq.readyState == 4) {

                    var liTag = document.createElement("li");
                    liTag.innerText = httpReq.responseText;
                    document.getElementById("resultDashboard").appendChild(liTag);
                }
            }

            httpReq.send(json);
  }

  UpdateICUDetails(){
           var searchKey=this.icuIdUpdate;
            var data = { icuId: this.icuIdUpdate, bedsCount: parseInt(this.bedCountUpdate), layout: "Normal" };
    
            var json = JSON.stringify(data);
            var   httpReq = new XMLHttpRequest();
            httpReq.open("PUT", "http://localhost:53133/api/configuration/UpdateIcu/" + searchKey, true);
            httpReq.setRequestHeader('Content-type','application/json; charset=utf-8');
     //registering callback - to get updates on status of http request
            httpReq.onreadystatechange = function () {
            console.log("callback");
            if (httpReq.readyState == 4) {

            var liTag = document.createElement("li");
            liTag.innerText = httpReq.responseText;
            document.getElementById("resultDashboard").appendChild(liTag);
      }
  }

  httpReq.send(json);
  }
  GetICUDetails(){
    //var searchKey = window.document.getElementById('ICUIDTextBox');
    var searchKey=this.icuIdGet;
            //AJAX Request - Asynchronous Http Request;
           var   httpReq = new XMLHttpRequest();
            httpReq.open("GET", "http://localhost:53133/api/configuration/IcuDetails/" + searchKey, true);
          
            //registering callback - to get updates on status of http request
            httpReq.onreadystatechange = function () {
                console.log("callback");
                if (httpReq.readyState == 4) {

                    var liTag = document.createElement("li");
                    liTag.innerText = httpReq.responseText;
                    document.getElementById("resultDashboard").appendChild(liTag);
                }
            }
            //this.icuBedCount=httpReq.responseText[0];
            httpReq.send();
  }
  ResetDetails(){
    this.bedCountAdd="";
    this.icuIdAdd="";
  }
}
