import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../_models';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }

  getById(id: number) {
    return this.http.get(`/api/User/` + id);
  }

  register(user: User) {
    return this.http.post(`/api/User/Register`, user);
  }

  delete(id: number) {
    return this.http.delete(`/users/` + id);
  }
}
