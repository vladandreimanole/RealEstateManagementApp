import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { PropertyModel } from '../models/Property';
import { UploadedImages } from '../models/UploadedImages';
import { User } from '../models/User';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyComponent implements OnInit {
  public property?: PropertyModel;
  public propertyId: number = 0;
  public uploadedImages: SafeUrl[] = [];
  public landlord?: User;
  public isDataLoaded: boolean = false;
  constructor(private sanitizer: DomSanitizer, private _Activatedroute:ActivatedRoute, private dataService: DataService) { }
  async ngOnInit(): Promise<void> {
    this._Activatedroute.paramMap.subscribe(params => { 
      this.propertyId = Number(params.get('propertyId')); 
  });
  this.property = await this.dataService.getPropertyById(this.propertyId);
  const res = (await this.dataService.getImagesByPropertyId(this.propertyId))!;
  for(let img of res){
    this.uploadedImages.push(this.byteArrayToImage(img.imageData!));
  }
  this.landlord = await this.dataService.getUserById(Number(this.property?.userId));
  this.isDataLoaded = true;
  }

  byteArrayToImage(data: string){
    let objectURL = 'data:image/png;base64,' + data;
    const res = this.sanitizer.bypassSecurityTrustUrl(objectURL);
    return res;
  }

}
