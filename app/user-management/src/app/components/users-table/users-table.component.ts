import { Component } from '@angular/core';
import { UserDto } from 'src/app/models/user-dto';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css'],
})
export class UsersTableComponent {
  // users = [
  //   {
  //     name: 'David Wagner',
  //     email: 'david.wagner@example.com',
  //     date: '24 Oct, 2015',
  //     role: 'Super Admin',
  //   },
  //   {
  //     name: 'Ina Hogan',
  //     email: 'windler.warren@runte.net',
  //     date: '24 Oct, 2015',
  //     role: 'Admin',
  //   },
  //   {
  //     name: 'Devin Harmon',
  //     email: 'winifred.snoey@yahoo.com',
  //     date: '18 Dec, 2015',
  //     role: 'HR Admin',
  //   },
  //   {
  //     name: 'Lena Page',
  //     email: 'camila.lechner@gmail.com',
  //     date: '8 Oct, 2016',
  //     role: 'Employee',
  //   },
  //   {
  //     name: 'Eula Horton',
  //     email: 'eula.horton1221@gmail.com',
  //     date: '15 Jun, 2017',
  //     role: 'Super Admin',
  //   },
  //   {
  //     name: 'Victoria Perez',
  //     email: 'terri.lwa@hotmail.com',
  //     date: '12 Jan, 2019',
  //     role: 'HR Admin',
  //   },
  //   {
  //     name: 'Cora Medina',
  //     email: 'hagens.ssi@hotmail.com',
  //     date: '21 July, 2020',
  //     role: 'Employee',
  //   },
  // ];

  users: UserDto[] | undefined;
  constructor(private userService: UserService) {}

  ngOnInit() {
    this.fetchUsers();
  }

  fetchUsers() {
    this.userService
      .getUsers()
      .subscribe({
        next: (data) => {
          this.users = data;
          console.log('User data:', this.users);
        },
        error: (err) => {
          console.error('Error fetching users:', err);
        },
      });
  }
  // fetchUser() {
  //   this.userService
  //     .getUserById('55123B91-7F2F-4B38-9C0C-08DD8A4723B0') //Alice
  //     .subscribe({
  //       next: (data) => {
  //         this.user = data;
  //         console.log('User data:', this.user);
  //       },
  //       error: (err) => {
  //         console.error('Error fetching users:', err);
  //       },
  //     });
  // }
}
