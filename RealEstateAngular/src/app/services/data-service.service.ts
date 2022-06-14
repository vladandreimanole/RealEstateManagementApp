import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { User } from '../models/User';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { Landlord } from '../models/Landlord';
import { PropertyModel } from '../models/Property';

@Injectable({
    providedIn: 'root'
})
export class DataService {

    constructor(private http: HttpClient, private _snackBar: MatSnackBar) { }

    createUser(user: User) {
        return this.http.post<User>(environment.urlServices + "DataManager/CreateUser", user, {
            headers: new HttpHeaders({ "Content-Type": "application/json" })
        })
            .subscribe({
                next: (response: User) => {
                    const Email = response.email;
                    const Password = response.password;
                },
                error: (err: HttpErrorResponse) => {
                    this._snackBar.open('Cannot create user', 'Close', {
                        horizontalPosition: "right",
                        verticalPosition: "top",
                        duration: 3000
                    });
                }
            })
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
}
