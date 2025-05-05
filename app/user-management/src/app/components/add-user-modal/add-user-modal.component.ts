import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  Output,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CreateUserDto } from 'src/app/models/create-user-dto';
import { RoleDto, UserPermissionDto } from 'src/app/models/user-dto';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-user-modal',
  templateUrl: './add-user-modal.component.html',
  styleUrls: ['./add-user-modal.component.css'],
})
export class AddUserModalComponent implements OnDestroy {
  @Input() permissions: UserPermissionDto[] = [];
  @Input() roles: RoleDto[] = [];
  @Output() userCreated = new EventEmitter<void>();
  model: CreateUserDto;
  private createUserSubscription?: Subscription;

  constructor(private userService: UserService) {
    this.model = this.createUser;
  }
  private getEmptyUser(): CreateUserDto {
    return {
      firstName: '',
      lastName: '',
      email: '',
      phone: '',
      username: '',
      password: '',
      roleId: '',
      permissions: this.permissions.map((p) => ({
        permissionId: p.permissionId,
        isReadable: false,
        isWritable: false,
        isDeletable: false,
      })),
    };
  }
  createUser: CreateUserDto = {
    firstName: '',
    lastName: '',
    email: '',
    phone: '',
    username: '',
    password: '',
    roleId: '',
    permissions: [],
  };
  confirmPassword: string = '';

  onSubmit(form: NgForm) {
    if (form.invalid) {
      return;
    }
    if (this.model.password !== this.confirmPassword) {
      alert('Passwords do not match!');
      return;
    }
    console.log(this.model);
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
    this.model = this.getEmptyUser();
  }
  ngOnChanges() {
    this.model.permissions = this.permissions.map((p) => ({
      permissionId: p.permissionId,
      isReadable: false,
      isWritable: false,
      isDeletable: false,
    }));
  }
  ngOnDestroy(): void {
    this.createUserSubscription?.unsubscribe();
  }
}
