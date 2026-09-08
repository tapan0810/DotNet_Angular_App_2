import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { MainClass } from './main-class';

describe('MainClass', () => {
  let component: MainClass;
  let fixture: ComponentFixture<MainClass>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MainClass],
      providers: [provideHttpClient()],
    }).compileComponents();

    fixture = TestBed.createComponent(MainClass);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize an invalid form when required fields are empty', () => {
    component.setFormState();
    expect(component.classForm.invalid).toBe(true);
  });

  it('should reset the form when opening add mode', () => {
    component.classForm.patchValue({ name: 'Alice', grade: 'A', isPassed: true });
    component.openModal();
    expect(component.isEditMode).toBe(false);
    expect(component.selectedStudentId).toBe(0);
    expect(component.classForm.value).toEqual({ name: '', grade: '', isPassed: false });
  });
});
