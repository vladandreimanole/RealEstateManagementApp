import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subscription } from 'rxjs';
import { AuthenticatedResponse } from '../interfaces/auth-response.model';
import { LoginModel } from '../interfaces/login';

@Injectable({
    providedIn: 'root',
})
export class PropertyService {

    constructor(
        private router: Router,
        private http: HttpClient,
        private _snackBar: MatSnackBar) { }

        uploadFile(form_data: any) {
        this.http.post<AuthenticatedResponse>("https://localhost:7243/api/Auth/login", {
            headers: new HttpHeaders({ "Content-Type": "application/json" })
        })
            .subscribe({
                next: (response: AuthenticatedResponse) => {
                    const token = response.token;
                    const email = response.email;
                    localStorage.setItem("jwt", token);
                    localStorage.setItem("userEmail", email);
                    this.router.navigate(["/home"]);
                    return response;
                },
                error: (err: HttpErrorResponse) => {
                    this._snackBar.open('Email sau parola gresite', 'Close', {
                        horizontalPosition: "right",
                        verticalPosition: "top",
                        duration: 3000
                    });
                    return err;
                }
            })
    }

    unsubscribeAll(subs: Subscription[]){
        let sub_count = subs.length;
        for(let i=0; i < sub_count; i++){
          let current_sub = subs[i];
          if(!!current_sub){
            current_sub.unsubscribe();
          }
        }
      }
}