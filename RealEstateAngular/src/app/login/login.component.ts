import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticatedResponse } from '../interfaces/auth-response.model';
import { LoginModel } from '../interfaces/login';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthenticationService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean | undefined;
  credentials: LoginModel = {email:'', password:''};
  constructor(private router: Router, private http: HttpClient, private _snackBar: MatSnackBar, private authService: AuthenticationService) { }

  ngOnInit(): void {
    if (this.authService.isUserAuthenticated()) {
      this.router.navigate(['/home']);
    }
  }
  login = ( form: NgForm) => {
    if (form.valid) {
      this.authService.login(this.credentials);
    }
  }
}
