import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from '../models/User';
import { ResetPasswordService } from '../services/reset-password.service';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.css']
})
export class PasswordResetComponent implements OnInit {

  constructor(private resetService: ResetPasswordService, private _snackBar: MatSnackBar) { }
  user:User = new User();
  isTokenSend:boolean=false;
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
      await this.resetService.sendTokenEmail(this.user.email);
      this.isTokenSend = true;
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
    if(this.user.email != '')
    {
      await this.resetService.sendTokenEmail(this.user.email);
      this.isTokenSend = true;
    }else{
      this._snackBar.open('Please insert your email', 'Close', {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 3000
    });
    }
  }
}
