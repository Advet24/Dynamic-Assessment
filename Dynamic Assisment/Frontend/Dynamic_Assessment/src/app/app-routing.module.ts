import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssessmentListComponent } from './component/Admin/assessment-list/assessment-list.component';
import { AddAssessmentComponent } from './component/Admin/add-assessment/add-assessment.component';
import { PatientTableComponent } from './component/Patient/patient-table/patient-table.component';
import { PatientAddassessmentComponent } from './component/Patient/patient-addassessment/patient-addassessment.component';
import { StartpageComponent } from './component/startpage/startpage.component';
import { EditassessmentComponent } from './component/Admin/editassessment/editassessment.component';
import { ViewdetailsComponent } from './component/Patient/viewdetails/viewdetails.component';

const routes: Routes = [
  {
    path:'',
    component:StartpageComponent
  },
  {
    path:'patient',
    component:PatientTableComponent
  },
  {
    path:'assessment',
    component:AssessmentListComponent
  },
  {
    path:'addassessment',
    component:AddAssessmentComponent
  },
  {
    path:'patientassess',
    component:PatientAddassessmentComponent
  },
  {
    path:'edit/:id',
    component:EditassessmentComponent
  },
  {
    path:'view',
    component:ViewdetailsComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
