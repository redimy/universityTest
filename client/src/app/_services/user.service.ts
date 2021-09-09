import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppUser } from '../models/appUser';
import { Assignment } from '../models/assignment';
import { Grade } from '../models/grade';
import { Group } from '../models/group';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get<AppUser[]>(this.baseUrl + 'admin/users-with-roles');
  }

  getGroups(){
    return this.http.get<Group[]>(this.baseUrl + 'group');
  }

  getAssignments(){
    return this.http.get<Assignment[]>(this.baseUrl + 'assignment');
  }

  getGrades(){
    return this.http.get<Grade[]>(this.baseUrl + 'grade');
  }
}
