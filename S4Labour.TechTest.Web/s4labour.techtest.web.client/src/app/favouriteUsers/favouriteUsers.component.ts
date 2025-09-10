import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from '../user/user.models';

@Component({
  selector: 'favouriteUsers',
  templateUrl: './favouriteUsers.component.html',
  standalone: false,
  styleUrl: '../user/user.component.css'
})
export class FavouriteUsersComponent implements OnInit {
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
    this.activeUser = {} as User;
    this.userSelected = false;
    this.http.get<User[]>('https://localhost:7013/api/User/Favourites').subscribe(
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

  loadUser(userName: string): void {
    this.activeUser = this.users.find((user) => user.userName == userName)!;
    this.userSelected = true;
  }
}
