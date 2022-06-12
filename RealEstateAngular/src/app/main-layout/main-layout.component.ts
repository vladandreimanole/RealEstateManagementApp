import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent implements OnInit {
  private _mobileQueryListener: () => void;
  mobileQuery: MediaQueryList;
  userName: string | null;
  constructor(private media: MediaMatcher, private changeDetectorRef: ChangeDetectorRef) { 
    this.mobileQuery = this.media.matchMedia('(max-width: 1000px)');
        this._mobileQueryListener = () => changeDetectorRef.detectChanges();
        // tslint:disable-next-line: deprecation
        this.mobileQuery.addListener(this._mobileQueryListener);
        this.userName = localStorage.getItem("userEmail"); 
  }

  ngOnInit(): void {
  }

  logOut = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("userEmail");
  }

}
