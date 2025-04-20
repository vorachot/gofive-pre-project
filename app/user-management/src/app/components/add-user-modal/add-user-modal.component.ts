import { Component, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CreateUserRequest } from 'src/app/models/create-user-request';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-user-modal',
  templateUrl: './add-user-modal.component.html',
  styleUrls: ['./add-user-modal.component.css'],
})
export class AddUserModalComponent implements OnDestroy {
  model: CreateUserRequest;
  private createUserSubscription?: Subscription;

  constructor(private userService: UserService) {
    this.model = {
      firstName: '',
      lastName: '',
      email: '',
      phone: '',
      username: '',
      password: '',
    };
  }
  onSubmit(form: NgForm) {
    this.createUserSubscription = this.userService
      .createUser(this.model)
      .subscribe({
        next: (response) => {
          console.log('User created successfully:', response);
          form.reset();
          this.model = {
            firstName: '',
            lastName: '',
            email: '',
            phone: '',
            username: '',
            password: '',
          };
        },
        error: (error) => {
          console.error('Error creating user:', error);
        },
        complete: () => {
          console.log('User creation request completed');
        },
      });
  }

  roles = [
    { name: 'Super Admin', read: true, write: true, delete: true },
    { name: 'Admin', read: true, write: false, delete: false },
    { name: 'Employee', read: true, write: false, delete: false },
  ];

  ngOnDestroy(): void {
    this.createUserSubscription?.unsubscribe();
  }
}
