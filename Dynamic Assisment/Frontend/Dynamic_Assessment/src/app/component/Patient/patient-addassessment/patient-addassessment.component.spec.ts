import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientAddassessmentComponent } from './patient-addassessment.component';

describe('PatientAddassessmentComponent', () => {
  let component: PatientAddassessmentComponent;
  let fixture: ComponentFixture<PatientAddassessmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientAddassessmentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientAddassessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
