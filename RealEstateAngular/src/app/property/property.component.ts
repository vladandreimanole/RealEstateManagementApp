import { NumberInput } from '@angular/cdk/coercion';
import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { ChartTheme, DateTimeCategoryService, DateTimeService, ILoadedEventArgs } from '@syncfusion/ej2-angular-charts';
import { Browser } from '@syncfusion/ej2-base';
import { Observable, of } from 'rxjs';
import { ChatModel } from '../models/Chat';
import { ContractModel } from '../models/Contract';
import { PropertyModel } from '../models/Property';
import { PropertyVisualization } from '../models/PropertyVisualization';
import { UploadedImages } from '../models/UploadedImages';
import { User } from '../models/User';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss'],
  providers: [DatePipe, DateTimeCategoryService]
})
export class PropertyComponent implements OnInit {
  public property?: PropertyModel;
  public propertyId: number = 0;
  public uploadedImages: SafeUrl[] = [];
  public landlord?: User;
  public isDataLoaded: boolean = false;
  public propertyViews?: PropertyVisualization[];
  public chartData: Object[] = [];

  public data: Object[] = [
    { x: new Date(2022, 5, 1), y: 21 }, { x: new Date(2022, 5, 5), y: 24 },
    { x: new Date(2022, 5, 2), y: 36 }, { x: new Date(2022, 5, 6), y: 38 },
    { x: new Date(2022, 5, 3), y: 54 }, { x: new Date(2022, 5, 7), y: 57 },
    { x: new Date(2022, 5, 4), y: 70 }
  ];
  constructor(protected sanitizer: DomSanitizer, protected _Activatedroute: ActivatedRoute, protected dataService: DataService, protected dialog: MatDialog, private datePipe: DatePipe) { }
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
    this.dataService.createOrUpdatePropertyVisualization(this.propertyId);
    this.propertyViews = await this.dataService.getPropertyVisualizationsByPropertyId(this.propertyId);
    this.propertyViews = this.propertyViews!.sort((b, a) => new Date(b.date!).getTime() - new Date(a.date!).getTime());
    for(let view of this.propertyViews!){
      this.chartData.push(new Object(
        {
          x: view.date,
          y: view.views
        }
      )
      );
    }
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


   WithoutTime(dateTime: Date) {
    var date = new Date(dateTime.getTime());
    date.setHours(0, 0, 0, 0);
    return date;
}



//Initializing Primary X Axis
public primaryXAxis: Object = {
  valueType: 'DateTime',
            labelFormat: 'dd MMMM',
        intervalType: 'Days',
            rangePadding: 'None'
};
//Initializing Primary Y Axis
public primaryYAxis: Object = {
    labelFormat: '{value}',
    rangePadding: 'None',
    lineStyle: { width: 0 },
    majorTickLines: { width: 0 },
    minorTickLines: { width: 0 }
};
public chartArea: Object = {
    border: {
        width: 0
    }
};
public width: string = Browser.isDevice ? '100%' : '60%';
public marker: Object = {
    visible: true,
    height: 10,
    width: 10
};
public tooltip: Object = {
    enable: true
};


// custom code start
public load(args: ILoadedEventArgs): void {
    let selectedTheme: string = location.hash.split('/')[1];
    selectedTheme = selectedTheme ? selectedTheme : 'Material';
    args.chart.theme = <ChartTheme>(selectedTheme.charAt(0).toUpperCase() + selectedTheme.slice(1)).replace(/-dark/i, "Dark");
};
// custom code end
public title: string = 'Property views chart';

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