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
import { Role } from '../models/Role';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public roles:Role[]=[];
  public selectedRole='';
  invalidLogin: boolean | undefined;
  credentials: LoginModel = {email:'', password:''};
  user:User = new User();
  constructor(private router: Router, private http: HttpClient, private _snackBar: MatSnackBar, private authService: AuthenticationService,
              private dataService: DataService) { }

  ngOnInit(): void {
    if (this.authService.isUserAuthenticated()) {
      this.router.navigate(['properties']);   
    }
    this.dataService.GetActiveRoles().subscribe(values=>{
      this.roles = values;
    });
  }
  login = ( form: NgForm) => {
    if (form.valid) {
      this.authService.login(this.credentials);
    }
  } 

  resetPassword=(even:any)=>{
    
  }
  signUp = ( form: NgForm) => {
    
    if (form.valid) {
      this.user.roleId = this.roles.find(x=>x.roleName == this.selectedRole)?.roleId;
      console.log(this.user.roleId);
      var result = this.dataService.createUser(this.user);
    }
  }
}
