import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { User } from '../models/User';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient,private _snackBar: MatSnackBar) { }

  createUser(user: User) {
    return this.http.post<User>(environment.urlServices+"CreateUser", user, {
        headers: new HttpHeaders({ "Content-Type": "application/json" })
    })
        .subscribe({
            next: (response: User) => {
                const Email = response.Email;
                const Password = response.Password;
            },
            error: (err: HttpErrorResponse) => {
                this._snackBar.open('Cannot create user', 'Close', {
                    horizontalPosition: "right",
                    verticalPosition: "top",
                    duration: 3000
                });
            }
        })
}
}
