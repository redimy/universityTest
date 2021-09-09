import { Component, OnInit } from '@angular/core';
import { AppUser } from '../models/appUser';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.scss']
})
export class AdministrationComponent implements OnInit {
  users: AppUser[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe(response => {
      this.users = response;
    })
  }

}
