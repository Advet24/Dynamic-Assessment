import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-viewdetails',
  templateUrl: './viewdetails.component.html',
  styleUrls: ['./viewdetails.component.css'],
})
export class ViewdetailsComponent implements OnInit {
  patientId!: number;
  fullName!: string;
  dob!: string;

  displayedColumns: string[] = ['question', 'response'];

  assessments: any[] = [];
  assessmentDetails: any;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.patientId = params['patientId'];
      this.fullName = params['fullName'];
      this.dob = params['dob'];

      // Fetch patient details including assessments
      this.http
        .get<any>('https://localhost:7045/api/PatientToAssement/Getdetails' + this.patientId)
        .subscribe(
          (data) => {
            if (data && data.patientDetails) {
              // Extract assessments from patientDetails
              this.assessments = data.patientDetails.map((detail: any) => {
                return {
                  id: detail.ptA_Id,
                  name: detail.assessmentName,
                  assessment_date:detail.assessment_date
                };
              });
            } else {
              console.error('No data found for patient ID:', this.patientId);
            }
          },
          (error) => {
            console.error('Error fetching patient details:', error);
          }
        );
    });
  }

getAssessmentDetails(assessmentId: number) {
  console.log('Assessment ID:', assessmentId);

  this.http
    .get<any[]>(`https://localhost:7045/api/PatientToAssement/${assessmentId}`)
    .subscribe(
      (data) => {
        console.log('Assessment details:', data);
        this.assessmentDetails = data.map((detail: any) => {
          return {
            question: detail.question,
            response: detail.response,
            date: detail.savedDateTime,// Use savedDateTime property for the date
          };
        });
      },
      (error) => {
        console.error('Error fetching assessment details:', error);
        this.assessmentDetails = [];
        alert('Failed to fetch assessment details.');
      }
    );
}

}
