import { Component, EventEmitter, Input, Output, ChangeDetectionStrategy, OnChanges, SimpleChanges } from '@angular/core';
import { NgFor } from '@angular/common';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { User } from '../user/user.models';
import { debounceTime } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'userlist',
  templateUrl: 'userlist.component.html',
  imports: [NgFor, ReactiveFormsModule]
})
export class UserListComponent implements OnChanges {
  @Input() listItems: User[] = [];
  @Output() selectedValueChanged: EventEmitter<string> = new EventEmitter();

  public displayItems: User[] = [];

  private searchSubject = new Subject<string>();

  constructor() {
    this.searchSubject.pipe(debounceTime(500)).subscribe(query => {
      this.search(query);
    });
  }

  search(search: string): void {
    if (search == '') {
      this.displayItems = this.listItems;
    }
    else {
      this.displayItems = this.listItems.filter((item) => item.firstName.toLowerCase().startsWith(search.toLowerCase())
        || item.lastName.toLowerCase().startsWith(search.toLowerCase()));
    }
  }

  onSearch(event: Event): void {
    const query = (event.target as HTMLInputElement).value;
    this.searchSubject.next(query);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.displayItems = changes['listItems'].currentValue;
  }

  itemSelected(selectedValue: User): void {
    this.selectedValueChanged.emit(selectedValue.userName);
  }
}
