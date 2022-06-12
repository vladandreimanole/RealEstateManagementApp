import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { SwitchComponent } from '@syncfusion/ej2-angular-buttons';
import { rippleMouseHandler } from '@syncfusion/ej2-buttons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],

})
export class HomeComponent implements OnInit {

  constructor(private jwtHelper: JwtHelperService) { 

  }

  ngOnInit(): void {
  }
  public path: Object = {
    saveUrl: 'C:\\',
    removeUrl: 'https://aspnetmvc.syncfusion.com/services/api/uploadbox/Remove'
};

public dropElement: HTMLElement = document.getElementsByClassName('control-fluid')[0] as HTMLElement;
isUserAuthenticated = (): boolean => {
  const token = localStorage.getItem("jwt");
  if (token && !this.jwtHelper.isTokenExpired(token)){
    return true;
  }
  return false;
}
  logOut = () => {
    localStorage.removeItem("jwt");
  }
}
