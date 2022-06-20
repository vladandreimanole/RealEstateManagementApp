import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticationService } from '../services/auth.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent implements OnInit {
  private _mobileQueryListener: () => void;
  mobileQuery: MediaQueryList;
  userName: string | null;
  constructor(
    private media: MediaMatcher, 
    private changeDetectorRef: ChangeDetectorRef, 
    private _snackBar: MatSnackBar, private router: Router, 
    private jwtHelper: JwtHelperService,
    private authService: AuthenticationService) { 
    this.mobileQuery = this.media.matchMedia('(max-width: 1000px)');
        this._mobileQueryListener = () => changeDetectorRef.detectChanges();
        // tslint:disable-next-line: deprecation
        this.mobileQuery.addListener(this._mobileQueryListener);
        this.userName = localStorage.getItem("userEmail"); 
  }

  ngOnInit(): void {
    if (!this.authService.isUserAuthenticated()) {
      //this.router.navigate(['/login']);
    }
  }
  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    return false;
  }
  logOut = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("userEmail");
  }

}
