import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import {HomeComponent} from './home/home.component';
import { PatientadmissionComponent } from './patientadmission/patientadmission.component';
import { VitalsmonitoringComponent } from './vitalsmonitoring/vitalsmonitoring.component';

const routes: Routes = [
  {path:"" , redirectTo:'home', pathMatch:'full'},
  {path:'home',component:HomeComponent, children:[
    {path:'admin',component:AdminComponent},
    {path:'patientadmission',component:PatientadmissionComponent},
    {path:'vitalsmonitoring',component:VitalsmonitoringComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
