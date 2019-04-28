import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Client } from '../_models';
@Injectable({ providedIn: 'root' })
export class ClientService {
  constructor(private http: HttpClient) { }

  getClients() {
    return this.http.get<Client[]>(`/api/Client/` );
  }
}
