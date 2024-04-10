import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css'],
})
export class PopupComponent implements OnInit {
  constructor(
    private dialogref: MatDialogRef<PopupComponent>,
    private builder: FormBuilder
  ) {}

  questions!: FormGroup;

  ngOnInit(): void {
    this.questions = this.builder.group({
      name: [''],
    });
  }

  closepopup() {
    this.dialogref.close(this.questions.get('name')?.value);
  }
}
