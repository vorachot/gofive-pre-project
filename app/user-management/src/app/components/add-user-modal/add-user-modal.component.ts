import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  Output,
  SimpleChanges,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { CreateUserDto } from 'src/app/models/create-user-dto';
import { RoleDto, UserDto, UserPermissionDto } from 'src/app/models/user-dto';
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
  @Input() userToEdit?: UserDto;
  @Output() userUpdated = new EventEmitter<void>();
  model: CreateUserDto;
  isEditMode: boolean = false;
  userIdToUpdate: string = '';
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
  private mapUserDtoToCreateUserDto(user: UserDto): CreateUserDto {
    return {
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      phone: user.phone,
      username: user.username,
      password: '', // Keep this empty or set default
      roleId: user.role.roleId,
      permissions: user.permissions.map((p) => ({
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
    if (form.invalid) return;

    if (this.model.password !== this.confirmPassword && !this.isEditMode) {
      alert('Passwords do not match!');
      return;
    }

    const action$: Observable<void | UserDto> = this.isEditMode
      ? this.userService.updateUser(this.userIdToUpdate, this.model)
      : this.userService.createUser(this.model);

    this.createUserSubscription = action$.subscribe({
      next: (response) => {
        if (this.isEditMode) {
          this.userUpdated.emit();
        } else {
          this.userCreated.emit();
        }
        console.log('User created/updated successfully:', response);
        this.resetForm(form);
      },
      error: (err) => console.error(err),
    });
  }
  resetForm(form: NgForm) {
    form.reset();
    this.model = this.getEmptyUser();
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['userToEdit'] && this.userToEdit) {
      this.model = this.mapUserDtoToCreateUserDto(this.userToEdit);
      this.isEditMode = true;
      this.userIdToUpdate = this.userToEdit.id;
    }
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
