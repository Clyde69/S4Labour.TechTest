import { Component, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { User, FavouritePatchModel, NotePostModel, UserNote } from './user.models';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'user',
  templateUrl: './user.component.html',
  imports: [BrowserModule, CommonModule, ReactiveFormsModule],
  styleUrl: '../user/user.component.css'
})
export class UserComponent implements OnChanges {
  @Input() activeUser: User = <User>{};
  @Output() favouriteStateChanged: EventEmitter<string> = new EventEmitter();

  userNotes: UserNote[] = [];

  addNoteForm = new FormGroup({
    note: new FormControl('')
  });

  constructor(private http: HttpClient) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.getNotes();
  }

  changeFavouriteStatus(): void {
    var newValue = !this.activeUser.favourite;
    this.http.patch<boolean>('https://localhost:7013/api/User/favourite/' + this.activeUser.userName,
      <FavouritePatchModel>{ newValue: newValue }).subscribe(
      (newState: boolean) => {
        this.activeUser.favourite = newState;

        //  This only emits the name as the only place it's used is when the favourites page is
        //    displayed and the user is being defavourited.
        this.favouriteStateChanged.emit(this.activeUser.userName);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getNotes(): void {
    this.http.get<UserNote[]>('https://localhost:7013/api/notes/GetNotesFor/' + this.activeUser.userName)
      .subscribe((results) => {
        this.userNotes = results;
      },
        (error) => {
          console.error(error);
        });
  }

  addNote(): void {
    var note: string | null | undefined = this.addNoteForm.value.note;

    if (note !== undefined && note !== null) {
      this.http.post<NotePostModel>('https://localhost:7013/api/notes/AddNoteFor/' + this.activeUser.userName,
        <NotePostModel>{ note: note }).subscribe(
          () => {
            this.addNoteForm = new FormGroup({
              note: new FormControl('')
            });
            this.getNotes();
          },
          (error) => {
            console.error(error);
          });
    } 
  }
}
