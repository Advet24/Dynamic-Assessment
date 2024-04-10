import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddpatientdialogComponent } from './addpatientdialog.component';

describe('AddpatientdialogComponent', () => {
  let component: AddpatientdialogComponent;
  let fixture: ComponentFixture<AddpatientdialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddpatientdialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddpatientdialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
