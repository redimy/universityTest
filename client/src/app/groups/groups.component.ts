import { Component, OnInit } from '@angular/core';
import { Group } from '../models/group';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss']
})
export class GroupsComponent implements OnInit {
  groups: Group[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadGroups();
  }

  loadGroups() {
    this.userService.getGroups().subscribe(response => {
      this.groups = response;
    })
  }

}
