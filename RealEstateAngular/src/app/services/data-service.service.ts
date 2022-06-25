import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { User } from '../models/User';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { Landlord } from '../models/Landlord';
import { PropertyModel } from '../models/Property';
import { Role } from '../models/Role';
import { UploadedImages } from '../models/UploadedImages';
import { ContractModel } from '../models/Contract';
import { ChatModel } from '../models/Chat';
import { ChatLogModel } from '../models/ChatLog';
import { MessageDto } from '../models/MessageDto';
import { PropertyVisualization } from '../models/PropertyVisualization';

@Injectable({
    providedIn: 'root'
})
export class DataService {

    constructor(private http: HttpClient, private _snackBar: MatSnackBar) { }

    createUser(user: User) {
        return this.http.post<User>(environment.urlServices + "DataManager/CreateUser", user)
            .subscribe({
                error: (err: HttpErrorResponse) => {
                    this._snackBar.open('Cannot create user' + err.message, 'Close', {
                        horizontalPosition: "right",
                        verticalPosition: "top",
                        duration: 3000
                    });
                }
            })
    }

     public GetActiveRoles() : Observable<Role[]>{
        const url = environment.urlServices + 'DataManager/GetCurrentRoles';
        return this.http.get<Role[]>(url);
    }

    async createProperty(property: PropertyModel) {
        let jwt = localStorage.getItem('jwt');
        return await this.http.post<PropertyModel>(environment.urlServices + "DataManager/CreateProperty", property, {
            headers: new HttpHeaders({ "Content-Type": "application/json", 'Authorization': 'Bearer ' + jwt })
        }).toPromise();
    }

     async getLandlordByUserId(userId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<Landlord>(environment.urlServices + "DataManager/GetLandlordByUserId/" + userId.toString(), { headers: reqHeader }).toPromise();
        return response;
        
    }

    async getProperties() {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<PropertyModel[]>(environment.urlServices + "DataManager/GetAllProperties/", { headers: reqHeader }).toPromise();
        return response;
        
    }

    async getPropertyById(propertyId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<PropertyModel>(environment.urlServices + "DataManager/GetPropertyById/" + propertyId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    async getUserById(userId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<User>(environment.urlServices + "DataManager/GetUserById/" + userId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    async getImagesByPropertyId(propertyId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<UploadedImages[]>(environment.urlServices + "DataManager/GetImagesByPropertyId/" + propertyId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    getPropertiesTest() {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = this.http.get<PropertyModel[]>(environment.urlServices + "DataManager/GetAllProperties/", { headers: reqHeader });
        return response;
        
    }


    createContract(contract: ContractModel) {
        let jwt = localStorage.getItem('jwt');
        return this.http.post<ContractModel>(environment.urlServices + "DataManager/CreateContract", contract, {
            headers: new HttpHeaders({ "Content-Type": "application/json", 'Authorization': 'Bearer ' + jwt })
        })
            .subscribe({
                error: (err: HttpErrorResponse) => {
                    this._snackBar.open('Cannot create contract' + err.message, 'Close', {
                        horizontalPosition: "right",
                        verticalPosition: "top",
                        duration: 3000
                    });
                }
            })
    }

    createOrUpdatePropertyVisualization(propertyId: number) {
        let jwt = localStorage.getItem('jwt');
        return this.http.post<PropertyVisualization>(environment.urlServices + "DataManager/CreateOrUpdatePropertyVisualization/" + propertyId, {
            headers: new HttpHeaders({ "Content-Type": "application/json", 'Authorization': 'Bearer ' + jwt })
        })
            .subscribe({
                error: (err: HttpErrorResponse) => {
                    this._snackBar.open('Cannot create property visualization' + err.message, 'Close', {
                        horizontalPosition: "right",
                        verticalPosition: "top",
                        duration: 3000
                    });
                }
            })
    }
    deleteContract(contractId: number){
        
    }

    createChat(chat: ChatModel) {
        let jwt = localStorage.getItem('jwt');
        return this.http.post<ChatModel>(environment.urlServices + "DataManager/CreateChat", chat, {
            headers: new HttpHeaders({ "Content-Type": "application/json", 'Authorization': 'Bearer ' + jwt })
        })
            .subscribe({
                error: (err: HttpErrorResponse) => {
                    this._snackBar.open('Cannot create chat' + err.message, 'Close', {
                        horizontalPosition: "right",
                        verticalPosition: "top",
                        duration: 3000
                    });
                }
            })
    }

    async getContractByLandlordId(landlordId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<ContractModel[]>(environment.urlServices + "DataManager/GetContractsByLandlordId/" + landlordId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    async getContractByTenantId(tenantId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<ContractModel[]>(environment.urlServices + "DataManager/GetContractsByTenantId/" + tenantId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    async getPropertyVisualizationsByPropertyId(propertyId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<PropertyVisualization[]>(environment.urlServices + "DataManagerGgetPropertyVisualizationsByPropertyId/" + propertyId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    async getContractById(contractId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<ContractModel>(environment.urlServices + "DataManager/GetContractById/" + contractId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    async getChat(tenantId: number, landlordId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<ChatModel>(environment.urlServices + "DataManager/GetChat/" + tenantId.toString() + "/" + landlordId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }


    async getChatLogByChatId(chatId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.get<MessageDto[]>(environment.urlServices + "DataManager/GetChatLogsByChatId/" + chatId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    async signContract(contractId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.put<ContractModel>(environment.urlServices + "DataManager/SignContract/" + contractId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    async unlistProperty(propertyId: number) {
        let jwt = localStorage.getItem('jwt');
        var reqHeader = new HttpHeaders({ 
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + jwt
         });
        var response = await this.http.put<PropertyModel>(environment.urlServices + "DataManager/UnlistProperty/" + propertyId.toString(), { headers: reqHeader }).toPromise();
        return response;
    }

    
}
