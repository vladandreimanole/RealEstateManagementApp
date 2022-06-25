import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToolbarModule } from '@syncfusion/ej2-angular-navigations';
import { FileManagerSettingsModel, QuickToolbarSettingsModel, RichTextEditorComponent, ToolbarService, LinkService, ImageService, MarkdownEditorService, HtmlEditorService } from '@syncfusion/ej2-angular-richtexteditor';
import { addClass, Browser, removeClass } from '@syncfusion/ej2-base';
import { ChatModel } from '../models/Chat';
import { ContractModel } from '../models/Contract';
import { MessageDto } from '../models/MessageDto';
import { PropertyModel } from '../models/Property';
import { ChatService } from '../services/chat.service';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css']
})
export class ContractComponent implements OnInit {

  constructor(private dataService: DataService, protected _Activatedroute: ActivatedRoute, private chatService: ChatService) { }
  public _clientViewText: any;
  public tools: ToolbarModule = {
    items: ['Bold', 'Italic', 'Underline', 'StrikeThrough',
      'FontName', 'FontSize', 'FontColor', 'BackgroundColor',
      'LowerCase', 'UpperCase', 'SuperScript', 'SubScript', '|',
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
  public contract?: ContractModel;
  public contractId: number = 0;
  public chat?: ChatModel;
  public property?: PropertyModel;
  public chatLogs?: MessageDto[];
  public currentUserId?: number;
  async ngOnInit(): Promise<void> {
    this._Activatedroute.paramMap.subscribe(params => {
      this.contractId = Number(params.get('contractId'));
    });
    this.currentUserId = Number(localStorage.getItem("userId"));
    this.contract = await this.dataService.getContractById(this.contractId);
    this._clientViewText = this.contract?.contractHtml;
    this.property = await this.dataService.getPropertyById(this.contract?.propertyId!);
    this.chat = await this.dataService.getChat(this.contract?.tenantId!, this.property?.userId!);
    this.chatLogs = await this.dataService.getChatLogByChatId(this.chat?.chatId!);
    for (let log of this.chatLogs!){
      this.addToInbox(log);
    }
    this.chatService.addUserToGroup(this.chat?.chatId.toString()!);
    this.chatService.retrieveMappedObject().subscribe((receivedObj: MessageDto) => 
    { this.addToInbox(receivedObj); });
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
  public buttons = { browse: "Alege pdf" };
  public dropElement!: HTMLElement;


  msgDto: MessageDto = new MessageDto();
  msgInboxArray: MessageDto[] = [];

  send(): void {
    this.msgDto.chatId = this.chat?.chatId.toString()!;
    this.msgDto.landlordId = this.chat?.landlordId;
    this.msgDto.tenantId = this.chat?.tenantId;
    this.msgDto.sentTime = new Date(Date.now());
    this.msgDto.sentByUserId = this.currentUserId;
    if (this.msgDto) {
        this.chatService.broadcastMessage(this.msgDto);
    }
    this.msgDto.msgText = "";
  }

  addToInbox(obj: MessageDto) {
    this.msgInboxArray.push(obj);

  }
}
