import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToolbarModule } from '@syncfusion/ej2-angular-navigations';
import { FileManagerSettingsModel, QuickToolbarSettingsModel, RichTextEditorComponent,ToolbarService, LinkService, ImageService, MarkdownEditorService, HtmlEditorService } from '@syncfusion/ej2-angular-richtexteditor';
import { addClass, Browser, removeClass } from '@syncfusion/ej2-base';
import { ContractModel } from '../models/Contract';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css']
})
export class ContractComponent implements OnInit {

  constructor(private dataService:DataService, protected _Activatedroute:ActivatedRoute) { }
  public _clientViewText: any;
  public tools: ToolbarModule = {
    items: ['Bold', 'Italic', 'Underline', 'StrikeThrough',
        'FontName', 'FontSize', 'FontColor', 'BackgroundColor',
        'LowerCase', 'UpperCase','SuperScript', 'SubScript', '|',
        'Formats', 'Alignments', 'NumberFormatList', 'BulletFormatList',
        'Outdent', 'Indent', '|',
        'CreateTable', 'CreateLink', 'Image', 'FileManager', '|', 'ClearFormat', 'Print',
        'SourceCode', 'FullScreen', '|', 'Undo', 'Redo']
};
private hostUrl: string = 'https://ej2-aspcore-service.azurewebsites.net/';
public maxLength = 1000;
public fileManagerSettings: FileManagerSettingsModel = {
  enable: true,
  path: '/Pictures/Food',
  ajaxSettings: {
      url: this.hostUrl + 'api/FileManager/FileOperations',
      getImageUrl: this.hostUrl + 'api/FileManager/GetImage',
      uploadUrl: this.hostUrl + 'api/FileManager/Upload',
      downloadUrl: this.hostUrl + 'api/FileManager/Download'
  }
};
public quickToolbarSettings: QuickToolbarSettingsModel = {
  table: ['TableHeader', 'TableRows', 'TableColumns', 'TableCell', '-', 'BackgroundColor', 'TableRemove', 'TableCellVerticalAlign', 'Styles']
};
public contract?:ContractModel;
public contractId: number = 0;
  async ngOnInit(): Promise<void> {
    this._Activatedroute.paramMap.subscribe(params => { 
      this.contractId = Number(params.get('contractId')); 
  });
    this.contract = await this.dataService.getContractById(this.contractId);
    this._clientViewText = this.contract?.contractHTML;
  }
  public handleFullScreen(e: any): void {
    const sbCntEle: HTMLElement = document.querySelector('.sb-content.e-view')!;
    const sbHdrEle: HTMLElement = document.querySelector('.sb-header.e-view')!;
    const leftBar: HTMLElement = document.querySelector('#left-sidebar')!;
    if (e.targetItem === 'Maximize') {
        if (Browser.isDevice && Browser.isIos) {
            addClass([sbCntEle, sbHdrEle], ['hide-header']);
        }
        addClass([leftBar], ['e-close']);
        removeClass([leftBar], ['e-open']);
    } else if (e.targetItem === 'Minimize') {
        if (Browser.isDevice && Browser.isIos) {
            removeClass([sbCntEle, sbHdrEle], ['hide-header']);
        }
        removeClass([leftBar], ['e-close']);
        if (!Browser.isDevice) {
            addClass([leftBar], ['e-open']);
        }
    }
}

public path: Object = {
  saveUrl: 'https://ej2.syncfusion.com/services/api/uploadbox/Save',
  removeUrl: 'https://ej2.syncfusion.com/services/api/uploadbox/Remove' 
};
public buttons = { browse: "Alege pdf"};
public dropElement!: HTMLElement;
}
