import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Class} from '../Model/class';

@Injectable({
<<<<<<< HEAD
  providedIn: 'root',

=======
  providedIn: 'root'
>>>>>>> 82e559e (Implement Angular CRUD and configure CORS)
})
export class ClassService {

  private apiUrl = 'https://localhost:7027/api/Class';

  constructor(private http: HttpClient) {}

  // GET: api/Class
  getAllStudents(): Observable<Class[]> {
    return this.http.get<Class[]>(this.apiUrl);
  }

  // GET: api/Class/{id}
  getStudentById(id: number): Observable<Class> {
    return this.http.get<Class>(`${this.apiUrl}/${id}`);
  }

  // POST: api/Class
  addStudent(student: Class): Observable<Class> {
    return this.http.post<Class>(this.apiUrl, student);
  }

  // PUT: api/Class/{id}
  updateStudent(id: number, student: Class): Observable<void> {
    return this.http.put<void>(
      `${this.apiUrl}/${id}`,
      student
    );
  }

  // DELETE: api/Class/{id}
  deleteStudent(id: number): Observable<void> {
    return this.http.delete<void>(
      `${this.apiUrl}/${id}`
    );
  }
}