import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from '../user/user.models';

@Component({
  selector: 'allUsers',
  templateUrl: './allUsers.component.html',
  standalone: false,
  styleUrl: '../user/user.component.css'
})
export class AllUsersComponent implements OnInit {
  public users: User[] = [];
  public activeUser: User = {} as User;
  public loadingComplete: boolean = false;
  public errored: boolean = false;
  public userSelected: boolean = false;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getUserList();
  }

  getUserList(): void {
    this.errored = false;
    this.http.get<User[]>('https://localhost:7013/api/User/GetAll').subscribe(
      (result) => {
        this.users = result;
        this.loadingComplete = true;
      },
      (error) => {
        console.error(error);
        this.errored = true;
      }
    );
  }

  onSearch(): void { }

  loadUser(userName: string): void {
    this.activeUser = this.users.find((user) => user.userName == userName)!;
    this.userSelected = true;
  }
}
