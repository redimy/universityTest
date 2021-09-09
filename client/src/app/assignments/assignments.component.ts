import { Component, OnInit } from '@angular/core';
import { Assignment } from '../models/assignment';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-assignments',
  templateUrl: './assignments.component.html',
  styleUrls: ['./assignments.component.scss']
})
export class AssignmentsComponent implements OnInit {

  assignments: Assignment[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadAssignments();
  }

  loadAssignments() {
    this.userService.getAssignments().subscribe(response => {
      this.assignments = response;
    })
  }


}
