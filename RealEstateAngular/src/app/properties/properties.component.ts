import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { PropertyModel } from '../models/Property';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrls: ['./properties.component.scss']
})
export class PropertiesComponent implements OnInit {

  constructor(private dataService: DataService, private sanitizer: DomSanitizer, private router:Router) { }
  public properties?: PropertyModel[] = [];
  async ngOnInit(): Promise<void> {
    this.properties = await this.dataService.getProperties();
  }

  byteArrayToImage(data: string){
    let objectURL = 'data:image/png;base64,' + data;
    const res = this.sanitizer.bypassSecurityTrustUrl(objectURL);
    return res;
  }

  onCardClick(propertyId: number){
    this.router.navigate(["property/" + propertyId.toString()]);
  }

}
