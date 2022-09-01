import { Injectable, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';          // import signalR
import { HttpClient } from '@angular/common/http';
import { MessageDto } from '../models/MessageDto';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

   private  connection: any = new signalR.HubConnectionBuilder().withUrl("https://localhost:7243/chatsocket")   // mapping to the chathub as in startup.cs
                                         .configureLogging(signalR.LogLevel.Information)
                                         .build();
   readonly POST_URL = "https://localhost:7243/api/chat/send"

  private receivedMessageObject: MessageDto = new MessageDto();
  private sharedObj = new Subject<MessageDto>();

  constructor(private http: HttpClient) { 
    this.connection.onclose(async () => {
      await this.start();
    });
   this.connection.on("ReceiveOne", (user: string, message: string, chatId: string) => { this.mapReceivedMessage(user, message, chatId); });
   this.start();                 
  }


  // Strart the connection
  public async start() {
    try {
      await this.connection.start();
      console.log("connected");
    } catch (err) {
      console.log(err);
      setTimeout(() => this.start(), 5000);
    } 
  }

  private mapReceivedMessage(user: string, message: string, chatId: string): void {
    this.receivedMessageObject.sentByUserId = Number(user);
    this.receivedMessageObject.msgText = message;
    this.receivedMessageObject.chatId = chatId;
    this.sharedObj.next(this.receivedMessageObject);
 }

  /* ****************************** Public Mehods **************************************** */

  // Calls the controller method
  public broadcastMessage(msgDto: any) {
    this.http.post(this.POST_URL, msgDto).subscribe(data => console.log(data));
    //this.connection.invoke("SendMessage1", msgDto.user, msgDto.msgText).catch((err: string) => console.error(err));    // This can invoke the server method named as "SendMethod1" directly.
  }

  public addUserToGroup(chatId: string){
    this.connection.invoke("JoinGroup", chatId).catch((err: string) => console.error(err));
  }

  public retrieveMappedObject(): Observable<MessageDto> {
    return this.sharedObj.asObservable();
  }


}