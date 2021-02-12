import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChangepasswordService {
  private myUrl = 'https://localhost:44333/api/users';
  constructor(private http: HttpClient) { }

  changepass(id: string, userpassword: string): Observable<string> {

    var obj = { emailId: id, password: userpassword };
    return this.http.get<string>(this.myUrl);
  
  }
}
