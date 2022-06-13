import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FileInfo } from '@syncfusion/ej2-angular-inputs';
import { PropertyModel } from '../interfaces/property.model';

@Component({
  selector: 'app-list-property',
  templateUrl: './list-property.component.html',
  styleUrls: ['./list-property.component.css']
})
export class ListPropertyComponent implements OnInit {

    public path: Object = {
      saveUrl: 'https://localhost:7243/api/Auth/Save',
      removeUrl: 'https://localhost:7243/api/Auth/Remove'
  };

  public buttons = { browse: "Alege imagini"};
  public dropElement!: HTMLElement;
  property: PropertyModel;
  constructor(private http: HttpClient) {
    this.property = new PropertyModel();
  }
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    this.dropElement = document.getElementsByClassName('control_wrapper')[0] as HTMLElement;
}
  createProperty = ( form: NgForm) => {

  }
  fileName = '';
  uploadFile(fileInfo:FileInfo){
    
  }

  
}
