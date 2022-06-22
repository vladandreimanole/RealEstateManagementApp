import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../models/User';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.css']
})
export class PasswordResetComponent implements OnInit {

  constructor() { }
  user:User = new User();
  isTokenSend:boolean=false;
  ngOnInit(): void {
  }
  reset = ( form: NgForm) => {
    if (form.valid) {
      
    }
  } 

  public handleTokenClick=(event:any)=>
  {

  }
}
