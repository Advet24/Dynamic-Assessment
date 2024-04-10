import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MasterService } from '../../../Service/master.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-assessment-list',
  templateUrl: './assessment-list.component.html',
  styleUrls: ['./assessment-list.component.css'],
})
export class AssessmentListComponent implements OnInit {
  constructor(
    private master: MasterService,
    private http: HttpClient,
    private toastr: ToastrService,
    private route: Router
  ) {}
  Assessment: any[] = [];

  ngOnInit(): void {
    this.master.getasssessment().subscribe(
      (res) => {
        this.Assessment = res.response;
        console.log(res.response);
      },
      (error) => {
        console.log(error);
      }
    );
    this.fetchAssessments();
    this.fetcheditAssessments();
  }

  fetchAssessments(): void {
    this.master.getasssessment().subscribe(
      (res) => {
        this.Assessment = res.response;
        console.log(res.response);
      },
      (error) => {
        console.log(error);
      }
    );
  }


  // for edit
  fetcheditAssessments(): void {

    this.http.get<any>('https://localhost:7045/api/Dynamic/GetAssessmentupdate').subscribe(
      (data) => {
        
        this.Assessment = data;
        console.log(this.Assessment);
        
      },
      (error) => {
        console.error('Error fetching assessment data:', error);
 
      }
    );
  }


  editAssessment(assessmentId: number): void {
  
    this.route.navigate(['/edit', assessmentId]);
  }



  deleteAssessment(assessmentId: number): void {
    this.http
      .delete(
        `https://localhost:7045/api/Dynamic/DeleteAssessment/${assessmentId}`
      )
      .subscribe(
        () => {
          console.log('Assessment deleted successfully.');
          this.fetchAssessments(); // Reload assessments after deletion
          this.toastr.error("Deleted Successfully")

        },
        (error: HttpErrorResponse) => {
          console.error('Error deleting assessment:', error.message);
        }
      );
  }
}
