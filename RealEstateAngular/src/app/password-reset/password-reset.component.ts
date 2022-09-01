import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { User } from '../models/User';
import { ResetPasswordService } from '../services/reset-password.service';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.css']
})
export class PasswordResetComponent implements OnInit {

  constructor(private resetService: ResetPasswordService, private _snackBar: MatSnackBar, private router:Router) { }
  user:User = new User();
  isTokenSend:boolean=false;
  isTokenCorrect:boolean=false;
  ngOnInit(): void {
  }
  reset = ( form: NgForm) => {
    if (form.valid) {
      
    }
  } 

  public handleTokenClick=async (event:any)=>
  {
    if(this.user.email != '')
    {
      this.resetService.sendTokenEmail(this.user.email).subscribe(values=>{
        this.isTokenSend = values;
        
    if(this.isTokenSend == false)
    {
      this._snackBar.open('Could not send reset email. Please contact administrator', 'Close', {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 3000
    })
    }

      });
    }else{
      this._snackBar.open('Please insert your email', 'Close', {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 3000
    });
    }

  }

  public handlePassReset=async (event:any)=>
  {
      this.resetService.verifyAndUpdatePass(this.user).subscribe(values=>{
        this.isTokenCorrect = true;
        this.router.navigate(["login"]);
      });
    
    //if(this.isTokenCorrect == false){
    //  this._snackBar.open('Incorrect token. Try again or send another token', 'Close', {
     //   horizontalPosition: "right",
     //   verticalPosition: "top",
     //   duration: 3000
   // });
  //  }
  }
}
