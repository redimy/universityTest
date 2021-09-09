import { Component, OnInit } from '@angular/core';
import { Grade } from '../models/grade';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrls: ['./grade.component.scss']
})
export class GradeComponent implements OnInit {

  grades: Grade[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadGrades();
  }

  loadGrades() {
    this.userService.getGrades().subscribe(response => {
      this.grades = response;
    })
  }

}
