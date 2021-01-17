import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpClient) {}

  ngOnInit() {
  }
  
  public getToken(email: string, password: string){
    this.http.post('api/login', { email, password}, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'responseType': 'text' })
   })
      .subscribe((data) => console.log("token response: " + data));
  }
}
