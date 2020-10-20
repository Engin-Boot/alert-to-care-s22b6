import { Component, OnInit } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'admin-comp',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  bedCount:string;
  icuId:string;
  icuBedCount:string;

  
  constructor() { }

  ngOnInit(): void {
  }

  onBedCountEdit(value){
    this.bedCount=value;
  }
  onICUIDEdit(value){
    this.icuId=value;
  }


  AddICUDetails(){
    //not working
    //send json body for post request
    var searchKey="ICU003";
            //AJAX Request - Asynchronous Http Request;
           var httpReq = new XMLHttpRequest();
            //this.icuBedCount=httpReq.responseText[0];
            var url = "http://localhost:53133/api/configuration/AddIcu/";

            var data = {};
           {
             data=this.bedCount;
           }

            
            var json = JSON.stringify(data);
            
            var xhr = new XMLHttpRequest();
            xhr.open("POST", url, true);
            xhr.setRequestHeader('Content-type','application/json; charset=utf-8');
            
            //registering callback - to get updates on status of http request
            httpReq.onreadystatechange = function () {
              console.log("callback");
              if (httpReq.readyState == 4) {

                  var liTag = document.createElement("li");
                  liTag.innerText = httpReq.responseText;
                  document.getElementById("resultDashboard").appendChild(liTag);
                  var users = JSON.parse(xhr.responseText);
              }
          }
            xhr.send(this.bedCount);
  }

  UpdateICUDetails(){
    alert("ICU details updated successfully");
  }
  GetICUDetails(){
    //var searchKey = window.document.getElementById('ICUIDTextBox');
    var searchKey=this.icuId;
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
    this.bedCount="";
  }
}
