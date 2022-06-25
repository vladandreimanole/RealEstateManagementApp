import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class ResetPasswordService {

  constructor(private http: HttpClient) { }

  

  public sendTokenEmail(email: string) : Observable<boolean>{

  
    return  this.http.get<boolean>(environment.urlServices + "Reset/SendResetEmail?email=" + email);
}

public verifyAndUpdatePass(user:User) : Observable<boolean>{
  const url = environment.urlServices + 'Reset/VerifyAndUpdatePass';
  return this.http.post<boolean>(url,user);
}
}
