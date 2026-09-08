import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Class } from '../Model/class';

@Injectable({ providedIn: 'root' })
export class ClassService {
  private readonly apiUrl = 'https://localhost:7027/api/Class';

  constructor(private readonly http: HttpClient) {}

  getAllStudents(): Observable<Class[]> {
    return this.http.get<Class[]>(this.apiUrl);
  }

  getStudentById(id: number): Observable<Class> {
    return this.http.get<Class>(`${this.apiUrl}/${id}`);
  }

  addStudent(student: Class): Observable<Class> {
    return this.http.post<Class>(this.apiUrl, student);
  }

  updateStudent(id: number, student: Class): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, student);
  }

  deleteStudent(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
