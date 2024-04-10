import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-patient-addassessment',
  templateUrl: './patient-addassessment.component.html',
  styleUrls: ['./patient-addassessment.component.css'],
})
export class PatientAddassessmentComponent {
  patientId!: number;
  fullName!: string;
  dob!: string;

  assessments: any[] = [];
  assessmentDetails: any;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private toastr: ToastrService,
    private router : Router
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      debugger;
      this.patientId = params['patientId'];
      this.fullName = params['fullName'];
      this.dob = params['dob'];
    });

    // Fetch assessment names
    this.http
      .get<any[]>('https://localhost:7045/api/PatientCotroller/all')
      .subscribe(
        (data) => {
          console.log('Assessment names:', data);
          this.assessments = data;
        },
        (error) => {
          console.error('Error fetching assessment names:', error);
        }
      );
  }

  getAssessmentDetails(assessmentId: number) {
    debugger;
    console.log('Assessment ID:', assessmentId);

    this.http
      .get<any>(
        `https://localhost:7045/api/Dynamic/GetAssessmentupdate/${assessmentId}`
      )
      .subscribe(
        (data: any) => {
          console.log('Assessment details:', data);
          if (data) {
            this.assessmentDetails = data;
          } else {
            this.assessmentDetails = [];
            alert('No questions found for this assessment.');
          }
        },
        (error) => {
          console.error('Error fetching assessment details:', error);
          alert('Failed to fetch assessment details.');
        }
      );
  }

  saveAllAnswers() {
    debugger;
    console.log('Assessment Details:', this.patientId);

    // if (!this.assessmentDetails || !this.assessmentDetails.updatedAssessmentName || !this.assessmentDetails.updatedAssessmentName.id) {
    //   console.error('Assessment details are not available or invalid.');
    //   return;
    // }

    const requestBody = {
      patientId: this.patientId,
      assessmentId: this.assessmentDetails.id,
      questionResponses: this.assessmentDetails.questions.map((detail: any) => {
        return {
          questionId: detail.id,
          response: detail.answer,
        };
      }),
    };

    this.http
      .post(
        'https://localhost:7045/api/PatientToAssement/PostResponse',
        requestBody
      )
      .subscribe(
        (response) => {
          console.log('Response saved successfully:', response);
          this.toastr.success("Response saved successfully");
          this.router.navigateByUrl("/patient")
        },
        (error) => {
          console.error('Error saving response:', error);
          // Optionally, you can show an error message to the user
        }
      );
  }
}
