import { NumberInput } from '@angular/cdk/coercion';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { ChatModel } from '../models/Chat';
import { ContractModel } from '../models/Contract';
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
  constructor(protected sanitizer: DomSanitizer, protected _Activatedroute: ActivatedRoute, protected dataService: DataService, protected dialog: MatDialog) { }
  async ngOnInit(): Promise<void> {
    this._Activatedroute.paramMap.subscribe(params => {
      this.propertyId = Number(params.get('propertyId'));
    });
    this.property = await this.dataService.getPropertyById(this.propertyId);
    const res = (await this.dataService.getImagesByPropertyId(this.propertyId))!;
    for (let img of res) {
      this.uploadedImages.push(this.byteArrayToImage(img.imageData!));
    }
    this.landlord = await this.dataService.getUserById(Number(this.property?.userId));
    this.isDataLoaded = true;
  }

  byteArrayToImage(data: string) {
    let objectURL = 'data:image/png;base64,' + data;
    const res = this.sanitizer.bypassSecurityTrustUrl(objectURL);
    return res;
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(DialogAnimationsExampleDialog, {
      width: '400px',
    });
    dialogRef.componentInstance.propertyId = this.propertyId;
    dialogRef.componentInstance.landlordId = this.property?.userId;
  }
}
@Component({
  selector: 'confirm-rent-dialog',
  templateUrl: 'confirm-rent-dialog.html'
})
export class DialogAnimationsExampleDialog {
  public contract: ContractModel = new ContractModel;
  public propertyId?: number
  public landlordId?: number
  constructor(public dialogRef: MatDialogRef<DialogAnimationsExampleDialog>, private dataService: DataService) {

  }
  confirmRent() {
    this.contract.propertyId = this.propertyId!;
    this.contract.signed = false;
    this.contract.tenantId = Number(localStorage.getItem("userId"));
    this.dataService.createContract(this.contract);
    let chat = new ChatModel();
    chat.landlordId = this.landlordId;
    chat.tenantId = this.contract.tenantId;
    this.dataService.createChat(chat);
    this.dialogRef.close();
  }
}