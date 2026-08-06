import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-main-class',
  // standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './main-class.html',
  styleUrl: './main-class.css',
})
export class MainClass {

  classForm :FormGroup = new FormGroup({})

  constructor(private fb: FormBuilder){

  }

  openModal(){
    const classModal = document.getElementById('myModal');
    if(classModal != null){
      classModal.style.display= 'block';
    }else{
      console.error('Modal element not found');
    }
  }

  closeModal(){
    const classModal = document.getElementById('myModal');

    if(classModal != null){
      classModal.style.display= 'none';
    }else{
      console.error('Modal element not found');
    }
  }

  setFormState(){
    this.classForm = this.fb.group({  
      name:['',Validators.required],
      grade:['',Validators.required],
      isPassed:[false,Validators.required]
    })
  }
}
