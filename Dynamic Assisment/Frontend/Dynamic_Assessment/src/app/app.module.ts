import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './MaterialModule';
import { AssessmentListComponent } from './component/Admin/assessment-list/assessment-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddAssessmentComponent } from './component/Admin/add-assessment/add-assessment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PopupComponent } from './component/Admin/popup/popup.component';
import { PatientTableComponent } from './component/Patient/patient-table/patient-table.component';
import { AddpatientdialogComponent } from './component/Patient/addpatientdialog/addpatientdialog.component';
import { EditpopupComponent } from './component/Patient/editpopup/editpopup.component';
import { PatientAddassessmentComponent } from './component/Patient/patient-addassessment/patient-addassessment.component';
import { StartpageComponent } from './component/startpage/startpage.component';
import { ToastrModule } from 'ngx-toastr';
import { EditassessmentComponent } from './component/Admin/editassessment/editassessment.component';
import { ViewdetailsComponent } from './component/Patient/viewdetails/viewdetails.component';



@NgModule({
  declarations: [
    AppComponent,
    AssessmentListComponent,
    AddAssessmentComponent,
    PopupComponent,
    PatientTableComponent,
    AddpatientdialogComponent,
    EditpopupComponent,
    PatientAddassessmentComponent,
    StartpageComponent,
    EditassessmentComponent,
    ViewdetailsComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot()
  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
