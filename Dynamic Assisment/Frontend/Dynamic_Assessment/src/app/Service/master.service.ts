import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MasterService {
  constructor(private http: HttpClient) {}

  private geturl = 'https://localhost:7045/api/Dynamic/GetAssessment';
  private posturl = 'https://localhost:7045/api/Dynamic/AddQuestions';
  private updateurl = 'https://localhost:7045/api/Dynamic';
  private viewurl = 'https://localhost:7045/api';

  getasssessment(): Observable<any> {
    return this.http.get(this.geturl);
  }

  postassessment(data: any): Observable<any> {
    return this.http.post(this.posturl, data);
  }

  getpatient(): Observable<any> {
    return this.http.get('https://localhost:7045/api/PatientCotroller/Getall');
  }

  Postpatient(data: any): Observable<any> {
    return this.http.post(
      'https://localhost:7045/api/PatientCotroller/AddPatient',
      data
    );
  }

  updateAssessment(id: number, updatedAssessment: any): Observable<any> {
    const url = `${this.updateurl}/${id}`;
    return this.http.put<any>(url, updatedAssessment);
  }

  getAssessmentDetails(assessmentId: number) {
    return this.http.get(
      `https://localhost:7045/api/Dynamic/GetAssessmentupdate/${assessmentId}`
    );
  }

  getPatientById(patientId: number): Observable<any> {
    return this.http.get<any>(`${this.viewurl}/patients/${patientId}`);
  }
  
}
