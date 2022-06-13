import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FileInfo } from '@syncfusion/ej2-angular-inputs';
import { PropertyModel } from '../interfaces/property.model';
import { Landlord } from '../models/Landlord';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-list-property',
  templateUrl: './list-property.component.html',
  styleUrls: ['./list-property.component.css']
})
export class ListPropertyComponent implements OnInit {

    public path: Object = {
      saveUrl: 'https://localhost:7243/api/Image/Save',
      removeUrl: 'https://localhost:7243/api/Auth/Remove'
  };
  public tabIndex = 0;
  public propertyId? = 0;
  public isFirstTabDisabled = false;
  public isSecondTabDisabled = true;
  public buttons = { browse: "Alege imagini"};
  public dropElement!: HTMLElement;
  property: PropertyModel;
  constructor(private http: HttpClient, private dataService: DataService) {
    this.property = new PropertyModel();
  }
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    this.dropElement = document.getElementsByClassName('control_wrapper')[0] as HTMLElement;
}
  createProperty = async ( form: NgForm) => {
    if (form.valid) {
      const userId = Number(localStorage.getItem("userId"));
      const currentLandlord = await this.dataService.getLandlordByUserId(userId);
      this.property.LandlordId = currentLandlord!.landlordId;
      var result = await this.dataService.createProperty(this.property);
      this.propertyId = result?.propertyId;
      if(result){
        this.tabIndex = 1;
        this.isFirstTabDisabled = true;
        this.isSecondTabDisabled = false;
        this.path = {
          saveUrl: 'https://localhost:7243/api/Image/Save/' + this.propertyId,
          removeUrl: 'https://localhost:7243/api/Auth/Remove'
      };
      }
        
    }
  }
  fileName = '';
  uploadFile(fileInfo:FileInfo){
    
  }

  
}
