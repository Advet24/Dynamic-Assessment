import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MasterService } from 'src/app/Service/master.service';
import { AddpatientdialogComponent } from '../addpatientdialog/addpatientdialog.component';
import { EditpopupComponent } from '../editpopup/editpopup.component';

@Component({
  selector: 'app-patient-table',
  templateUrl: './patient-table.component.html',
  styleUrls: ['./patient-table.component.css']
})
export class PatientTableComponent implements OnInit {
  patientdata: any[] = [];
  displayedColumns = ['id', 'firstname', 'lastname', 'dateofbirth', 'action'];
  patientdatasource = new MatTableDataSource(this.patientdata);
  @ViewChild(MatSort) sort !: MatSort;
  @ViewChild(MatPaginator) paginator !: MatPaginator;

  constructor(
    private patient: MasterService,
    private dialog: MatDialog,
    private router: Router) {
    }

    ngOnInit(){
      this.loadpatient();
    }
 

  loadpatient() {
    this.patient.getpatient()
      .subscribe(res => {
        this.patientdata = res.response;
        this.patientdatasource = new MatTableDataSource(this.patientdata);
        this.patientdatasource.sort = this.sort;
        this.patientdatasource.paginator = this.paginator;
        console.log(this.patientdata);

      })
  }


  // EDIT PATIENT
  editPatient(patient: any) {
    const dialogRef = this.dialog.open(EditpopupComponent, {
      width: '400px',
      data: { patient }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Edit dialog closed');
      this.loadpatient();
    });
  }

    
  // ADD PATIENT
  addpatient(){
    this.Openpopup(0, 'Add Student',AddpatientdialogComponent)
  }


   // for popup
   Openpopup(code:any,title:any, component:any){
    var _popup =this.dialog.open(component,{
      width:'40%',
      enterAnimationDuration:'900ms',
      exitAnimationDuration:'1000ms',
      data:{
        title:title,
        code:code
      }
    })
    _popup.afterClosed().subscribe(item=>{
      // console.log(item);
      this.loadpatient();
      
    })
  }

  //add assessment
  addAssessment(patient: any): void {
    this.router.navigate(['/patientassess'], { queryParams: { patientId: patient.id, fullName: patient.firstName + ' ' + patient.lastName, dob: patient.dob } });
  }

  viewPatient(patientId: any): void {
    
        this.router.navigate(['/view'], { queryParams: { patientId: patientId.id, fullName: patientId.firstName + ' ' + patientId.lastName, dob: patientId.dob } });
      }
  }
  

