import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ResetPasswordService {

  constructor(private http: HttpClient) { }

  

  async sendTokenEmail(email: string) {

    var response = await this.http.get(environment.urlServices + "Reset/SendResetEmail?email=" + email).toPromise();
    return response;
}
}
