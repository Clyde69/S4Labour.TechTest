export interface User {
  title: string;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  age: number;
  emailAddress: string;
  userName: string;
  accountRegistered: string;
  accountAge: number;
  address: Address;
  picture: Picture;
  timezone: Timezone;
  favourite: boolean;
}
export interface UserResult {
  users: User[];
}

export interface Address {
  number: Number;
  street: string;
  city: string;
  state: string;
  country: string;
  postCode: string;
  coordinates: Coordinates;
}

export interface Picture {
  large: string;
  medium: string;
  thumbnail: string;
}

export interface Timezone {
  utC_Offset: string;
  description: string;
}

export interface Coordinates {

}

export interface FavouritePatchModel {
  newValue: boolean;
}

export interface NotePostModel {
  note: string;
}

export interface UserNote {
  userName: string;
  note: string;
  dateAndTime: string;
}
