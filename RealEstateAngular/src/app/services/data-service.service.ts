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
        return await this.http.post<PropertyModel>(environment.urlServices + "DataManager/CreateProperty", property, {
            headers: new HttpHeaders({ "Content-Type": "application/json" })
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
}
