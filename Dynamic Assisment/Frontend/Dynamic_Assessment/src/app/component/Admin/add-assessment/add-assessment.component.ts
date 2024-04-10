import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MasterService } from 'src/app/Service/master.service';
import { PopupComponent } from '../popup/popup.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-assessment',
  templateUrl: './add-assessment.component.html',
  styleUrls: ['./add-assessment.component.css'],
})
export class AddAssessmentComponent implements OnInit {
  ques: any;
  routeSub: any;
  editid: any;
  assessmentDate!: Date;

  constructor(
    private master: MasterService,
    private builder: FormBuilder,
    private dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) { }

  response = ['Text', 'TextArea', 'Radio', 'DateofBirth'];
  form!: FormGroup;

  ngOnInit() {
    this.form = this.builder.group({
      name: [''],
      isScorable: [false],
      questions: this.builder.array([]),
    });

    this.routeSub = this.route.params.subscribe((params) => {
      console.log(params['id']);
      if (params['id'] > 0) {
        this.editid = params['id'];
      }
    });
  }

  get getQuestion() {
    return this.form.get('questions') as FormArray;
  }

  addassess() {
    this.openPopup();
  }

  openPopup() {
    const _popup = this.dialog.open(PopupComponent, {
      width: '60%',
      height: '280px',
      enterAnimationDuration: '1000ms',
      exitAnimationDuration: '1000ms',
    });

    _popup.afterClosed().subscribe((items) => {debugger
      console.log(items); // Check the value of items emitted by the dialog
      if (items) { // Ensure items is not undefined
        this.ques = items;
        this.pushArray();
      } else {
        console.log('No items received from the dialog.'); // Log a message if items is undefined
      }
    });
  }

  pushArray() {
    const questionGroup = this.builder.group({
      question: [this.ques],
      responseType: [''],
      isRequired: true,
    });
    this.questions.push(questionGroup);
  }

  get questions() {
    return this.form.get('questions') as FormArray;
  }


  onSubmit() {debugger
    const data = {
      assessmentDto: {
        name: this.form.value.name,
        isScorable: Number(this.form.value.isScorable),
        questions: this.form.value.questions.map((question: any) => ({
          questions: question.question,
          responseType: question.responseType,
          isRequired: question.isRequired,
          // assessmentId: 0 
        })),
      },
    };
  
    // Send HTTP POST request with data to backend
    this.master.postassessment(data).subscribe(
      (res: any) => {
        console.log(res);
        console.log('success');
        this.router.navigate(['/assessment']);
        this.toastr.success("Add Assessment Successfully");
      },
      (err) => {
        console.log(err);
        // Handle error
      }
    );
    }
  }
  
  



