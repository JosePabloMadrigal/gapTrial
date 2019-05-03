import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ClientPolicy } from '../_models';

@Injectable({ providedIn: 'root' })
export class ClientPolicyService {
  constructor(private http: HttpClient) { }

  getClientPolicies(clientId: number) {
    return this.http.get('/api/ClientPolicy/getClientPolicies/' + clientId);
  }

  addUpdateClientPolicy(clientId: number, policies: any) {
    debugger;
    return this.http.post(`/api/ClientPolicy/CreatePolicyClients`, { clientId: clientId, policiesIds: policies });
  }
}
