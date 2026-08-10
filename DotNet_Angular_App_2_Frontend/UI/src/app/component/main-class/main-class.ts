import { CommonModule } from '@angular/common';

import { Component, OnInit } from '@angular/core';

import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { ClassService } from '../../Services/class';
import { Class } from '../../Model/class';

@Component({
  selector: 'app-main-class',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './main-class.html',
  styleUrl: './main-class.css'
})
export class MainClass implements OnInit {

<<<<<<< HEAD

  classForm :FormGroup = new FormGroup({})
=======
  // Form
  classForm!: FormGroup;
>>>>>>> 82e559e (Implement Angular CRUD and configure CORS)

  // List of students
  students: Class[] = [];

  // Used to determine Add or Edit
  isEditMode: boolean = false;

  // ID of student currently being edited
  selectedStudentId: number = 0;

  // Loading indicator
  isLoading: boolean = false;

  // Error message
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private classService: ClassService
  ) {}

  ngOnInit(): void {

    this.setFormState();

    this.getAllStudents();

  }

  // --------------------------------
  // CREATE FORM
  // --------------------------------

  setFormState(): void {

    this.classForm = this.fb.group({

      name: ['', Validators.required],

      grade: ['', Validators.required],

      isPassed: [false]

    });

  }

  // --------------------------------
  // GET ALL
  // --------------------------------

  getAllStudents(): void {

    this.isLoading = true;

    this.classService.getAllStudents()
      .subscribe({

        next: (response: Class[]) => {

          this.students = response;

          this.isLoading = false;

        },

        error: (error) => {

          console.error('Error getting students:', error);

          this.errorMessage = 'Unable to load students.';

          this.isLoading = false;

        }

      });

  }

  // --------------------------------
  // OPEN ADD MODAL
  // --------------------------------

  openModal(): void {

    this.isEditMode = false;

    this.selectedStudentId = 0;

    this.setFormState();

    const classModal = document.getElementById('myModal');

    if (classModal) {

      classModal.style.display = 'block';

    }

  }

  // --------------------------------
  // CLOSE MODAL
  // --------------------------------

  closeModal(): void {

    const classModal = document.getElementById('myModal');

    if (classModal) {

      classModal.style.display = 'none';

    }

    this.classForm.reset({
      name: '',
      grade: '',
      isPassed: false
    });

  }

  // --------------------------------
  // ADD / UPDATE
  // --------------------------------

  saveStudent(): void {

    // Check validation
    if (this.classForm.invalid) {

      this.classForm.markAllAsTouched();

      return;

    }

    const student: Class = {

      id: this.selectedStudentId,

      name: this.classForm.value.name,

      grade: this.classForm.value.grade,

      isPassed: this.classForm.value.isPassed

    };

    // UPDATE
    if (this.isEditMode) {

      this.classService
        .updateStudent(this.selectedStudentId, student)
        .subscribe({

          next: () => {

            console.log('Student updated successfully');

            this.getAllStudents();

            this.closeModal();

          },

          error: (error) => {

            console.error('Error updating student:', error);

          }

        });

    }

    // ADD
    else {

      this.classService
        .addStudent(student)
        .subscribe({

          next: (response) => {

            console.log('Student added successfully:', response);

            this.getAllStudents();

            this.closeModal();

          },

          error: (error) => {

            console.error('Error adding student:', error);

          }

        });

    }

  }

  // --------------------------------
  // EDIT
  // --------------------------------

  editStudent(student: Class): void {

    this.isEditMode = true;

    this.selectedStudentId = student.id;

    this.classForm.patchValue({

      name: student.name,

      grade: student.grade,

      isPassed: student.isPassed

    });

    const classModal = document.getElementById('myModal');

    if (classModal) {

      classModal.style.display = 'block';

    }

  }

  // --------------------------------
  // DELETE
  // --------------------------------

  deleteStudent(id: number): void {

    const confirmed = confirm(
      'Are you sure you want to delete this student?'
    );

    if (!confirmed) {

      return;

    }

    this.classService
      .deleteStudent(id)
      .subscribe({

        next: () => {

          console.log('Student deleted successfully');

          this.getAllStudents();

        },

        error: (error) => {

          console.error('Error deleting student:', error);

        }

      });

  }

}