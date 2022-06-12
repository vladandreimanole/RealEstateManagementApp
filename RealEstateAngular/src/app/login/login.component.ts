import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticatedResponse } from '../interfaces/auth-response.model';
import { LoginModel } from '../interfaces/login';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean | undefined;
  credentials: LoginModel = {email:'', password:''};
  constructor(private router: Router, private http: HttpClient, private _snackBar: MatSnackBar) { }
  ngOnInit(): void {
    
  }
  login = ( form: NgForm) => {
    if (form.valid) {
      this.http.post<AuthenticatedResponse>("https://localhost:7243/api/Auth/login", this.credentials, {
        headers: new HttpHeaders({ "Content-Type": "application/json"})
      })
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.token;
          const email = response.email;
          localStorage.setItem("jwt", token);
          localStorage.setItem("userEmail", email);
          this.invalidLogin = false;
          this.router.navigate(["/home"]);
        },
        error: (err: HttpErrorResponse) => {
          this._snackBar.open('Email sau parola gresite', 'Close', {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 3000
          });
          this.invalidLogin = true}
      })
    }
  }
}
