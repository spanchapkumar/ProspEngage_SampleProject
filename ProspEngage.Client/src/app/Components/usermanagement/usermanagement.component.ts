import { Component, OnInit } from '@angular/core';
import { UserManagementService } from '../../Services/user-management.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-usermanagement',
  standalone: true,
  templateUrl: './usermanagement.component.html',
  styleUrls: ['./usermanagement.component.css'],
  imports: [FormsModule,CommonModule]
})
export class UserManagementComponent implements OnInit {
  users: any[] = [];
  newUser = {
    firstName: '',
    lastName: '',
    email: '',
  };

  constructor(private apiService: UserManagementService) {}

  ngOnInit(): void {
    debugger;
    this.getUsers();
  }

  getUsers(): void {
    this.apiService.getUsers().subscribe((data) => {
      this.users = data;
    });
  }

  createUser(): void {
    this.apiService.createUser(this.newUser).subscribe(() => {
      this.getUsers();
      this.newUser = { firstName: '', lastName: '', email: '' };
    });
  }
}
