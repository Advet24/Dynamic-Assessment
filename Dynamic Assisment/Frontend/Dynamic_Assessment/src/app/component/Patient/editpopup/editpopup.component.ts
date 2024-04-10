import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-editpopup',
  templateUrl: './editpopup.component.html',
  styleUrls: ['./editpopup.component.css']
})
export class EditpopupComponent implements OnInit {

  patient: any;
  apiUrl!: string;
  errorMessage: string = '';
  maxDate = new Date();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<EditpopupComponent>,
    private http: HttpClient,
    private builder: FormBuilder,
    private toastr : ToastrService
  ) {
    this.patient = { ...data.patient };
    console.log(data.patient.id);
    this.apiUrl = `https://localhost:7045/api/PatientCotroller/UpdatePatient/${this.patient.id}`;

    this.myform.patchValue({
      firstName: this.patient.firstName,
      lastName: this.patient.lastName,
      dob: this.patient.dob
    });
    
  }
  ngOnInit(): void {
    this.http.get('https://localhost:7045/api/PatientCotroller/Getall')
  }




  myform = this.builder.group({
    firstName: this.builder.control(''),
    lastName: this.builder.control(''),
    dob: this.builder.control(''),
  });

  updatePatient() {
    const updatedPatient = { ...this.myform.value, id: this.patient.id }; // Include the id property
    console.log(updatedPatient);
    
    this.http.put(this.apiUrl, updatedPatient).subscribe(response => {
      console.log('Patient updated successfully:', response);
      this.toastr.success("Update Successfully")
      this.closepopup();
      this.http.get('https://localhost:7045/api/PatientCotroller/Getall')
    }, error => {
      if (error.status === 404) {
        console.error('Patient not found:', error);
      } else {
        console.error('Error updating patient:', error);
      }
    });
  }
  

  closepopup() {
    this.dialogRef.close('Closed using Function');
  }
}
