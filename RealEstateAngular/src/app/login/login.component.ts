import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticatedResponse } from '../interfaces/auth-response.model';
import { LoginModel } from '../interfaces/login';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthenticationService } from '../services/auth.service';
import { DataService } from '../services/data-service.service';
import { User } from '../models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public roles:String[]=['Landlord','Tenant'];
  public selected='';
  invalidLogin: boolean | undefined;
  credentials: LoginModel = {email:'', password:''};
  user:User = new User();
  constructor(private router: Router, private http: HttpClient, private _snackBar: MatSnackBar, private authService: AuthenticationService,
              private dataService: DataService) { }

  ngOnInit(): void {
    if (this.authService.isUserAuthenticated()) {
      this.router.navigate(['properties']);
    }
  }
  login = ( form: NgForm) => {
    if (form.valid) {
      this.authService.login(this.credentials);
    }
  } 

  signUp = ( form: NgForm) => {
    if (form.valid) {
      var result = this.dataService.createUser(this.user);
    }
  }
}
