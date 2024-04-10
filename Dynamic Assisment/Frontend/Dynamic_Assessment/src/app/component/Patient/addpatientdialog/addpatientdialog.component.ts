import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MasterService } from 'src/app/Service/master.service';

@Component({
  selector: 'app-addpatientdialog',
  templateUrl: './addpatientdialog.component.html',
  styleUrls: ['./addpatientdialog.component.css']
})
export class AddpatientdialogComponent {

  inputdata: any;
  
  maxDate = new Date();

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private ref: MatDialogRef<AddpatientdialogComponent>,
    private builder: FormBuilder,
    private patientservice: MasterService) { }



  myform = this.builder.group({
    firstName: this.builder.control(''),
    lastName: this.builder.control(''),
    dob: this.builder.control(''),
  });


  SavePatient() {
    this.patientservice.Postpatient(this.myform.value)
      .subscribe(res => {
        this.closepopup()
      });
  }

  closepopup() {
    this.ref.close('Closed using Function');
  }

}
