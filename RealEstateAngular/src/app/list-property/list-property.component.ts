import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PropertyModel } from '../interfaces/property.model';

@Component({
  selector: 'app-list-property',
  templateUrl: './list-property.component.html',
  styleUrls: ['./list-property.component.css']
})
export class ListPropertyComponent implements OnInit {

    public path: Object = {
      saveUrl: 'C:\\',
      removeUrl: 'https://aspnetmvc.syncfusion.com/services/api/uploadbox/Remove'
  };
  
  public dropElement: HTMLElement = document.getElementsByClassName('control-fluid')[0] as HTMLElement;
  property: PropertyModel;
  constructor(private http: HttpClient) {
    this.property = new PropertyModel();
  }
  ngOnInit(): void {
  }

  createProperty = ( form: NgForm) => {

  }
  fileName = '';

  
}
