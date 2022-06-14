import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { PropertyModel } from '../models/Property';

@Injectable({
    providedIn: 'root',
})
export class PropertyService {

    constructor(
        private router: Router,
        private http: HttpClient,
        private _snackBar: MatSnackBar) { }

        createProperty(credentials: PropertyModel) {
            
        }
}