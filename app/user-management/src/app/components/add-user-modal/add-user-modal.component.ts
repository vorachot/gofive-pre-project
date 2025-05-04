import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CreateUserDto } from 'src/app/models/create-user-dto';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-user-modal',
  templateUrl: './add-user-modal.component.html',
  styleUrls: ['./add-user-modal.component.css'],
})
export class AddUserModalComponent implements OnDestroy {
  model: CreateUserDto;
  private createUserSubscription?: Subscription;

  constructor(private userService: UserService) {
    this.model = this.createUser;
  }
  createUser: CreateUserDto = {
    firstName: '',
    lastName: '',
    email: '',
    phone: '',
    username: '',
    password: '',
    roleId: 'F50A827C-8691-4968-82DC-FAECF38E331B', //Developer
    permissions: [
      {
        permissionId: 'E1813DFF-10CA-43F7-AFD7-658102110F54', //Employee
        isReadable: true,
        isWritable: false,
        isDeletable: false,
      },
    ],
  };
  confirmPassword: string = '';
  @Output() userCreated = new EventEmitter<void>();
  onSubmit(form: NgForm) {
    if (form.invalid) {
      return;
    }
    if (this.model.password !== this.confirmPassword) {
      alert('Passwords do not match!');
      return;
    }
    this.createUserSubscription = this.userService
      .createUser(this.model)
      .subscribe({
        next: (response) => {
          console.log('User created successfully:', response);
          this.resetForm(form);
          this.userCreated.emit();
        },
        error: (error) => {
          console.error('Error creating user:', error);
        },
      });
  }
  resetForm(form: NgForm) {
    form.reset();
    this.model = this.createUser;
  }

  permissions = [
    { name: 'Super Admin', read: true, write: true, delete: true },
    { name: 'Admin', read: true, write: false, delete: false },
    { name: 'Employee', read: true, write: false, delete: false },
  ];

  ngOnDestroy(): void {
    this.createUserSubscription?.unsubscribe();
  }
}
