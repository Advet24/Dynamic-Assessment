import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-edit-assessment',
  templateUrl: './editassessment.component.html',
  styleUrls: ['./editassessment.component.css']
})
export class EditassessmentComponent implements OnInit {
  editForm!: FormGroup;
  assessmentId!: number;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.editForm = this.formBuilder.group({
      name: [''],
      questions: this.formBuilder.array([])
    });

    this.route.params.subscribe(params => {
      this.assessmentId = params['id'];
      this.fetchAssessmentDetails(this.assessmentId);
    });
  }

  fetchAssessmentDetails(assessmentId: number): void {
    this.http.get<any>('https://localhost:7045/api/Dynamic/GetAssessmentupdate/' + assessmentId).subscribe(
      (data) => {
        // Populate the form with assessment data
        this.editForm.patchValue({
          name: data.name
        });
        this.populateQuestions(data.questions);
      },
      (error) => {
        console.error('Error fetching assessment details:', error);
        // Handle error
      }
    );
  }

  get questions(): FormArray {
    return this.editForm.get('questions') as FormArray;
  }

  populateQuestions(questions: any[]): void {
    this.questions.clear();
    questions.forEach(question => {
      this.addQuestion(question.question, question.response);
    });
  }

  addQuestion(question: string = '', response: string = ''): void {
    const questionGroup = this.formBuilder.group({
      question: [question],
      response: [response]
    });
    this.questions.push(questionGroup);
  }

  onSubmit(): void {
    if (this.editForm.valid) {
      // Extract form values
      const formData = this.editForm.value;
      
      // Construct updated data object
      const updatedData = {
        name: formData.name,
        questions: formData.questions.map((q: any) => ({ question: q.question, response: q.response }))
      };

      // Call API to update assessment data
      this.http.put<any>('https://localhost:7045/api/Dynamic/UpdateAssessment/' + this.assessmentId, updatedData).subscribe(
        (response) => {
          console.log('Assessment updated successfully:', response);
         
          this.router.navigate(['/assessment']);
        },
        (error) => {
          console.error('Error updating assessment:', error);
         
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }
}
