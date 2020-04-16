import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/models/User';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })
  export class UserService {
    baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  updateUser(id: number, user: User) {
    return this.http.put(this.baseUrl + 'api/' +'users/' + id, user);
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'api/' + 'users/' + id);
  }

  }