import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { ClientService, ClientPolicyService, PolicyService, HeaderService, AlertService } from '../_services';
import { Policy, Client, ClientPolicy } from '../_models';

@Component({ templateUrl: 'policyClient.component.html', styleUrls: ['policyClient.component.scss'] })
export class PolicyClientComponent implements OnInit, OnDestroy {
  policyList: Policy[] = [];
  clients: Client[] = [];
  clientPolicies: ClientPolicy[] = [];
  displayedColumns: string[] = ['fullName', 'options'];
  policyClientForm: FormGroup;

  constructor(
    private clientService: ClientService,
    private clientPolicyService: ClientPolicyService,
    private policyService: PolicyService,
    private headerService: HeaderService,
    private formBuilder: FormBuilder,
    private alertService: AlertService) {


  }
  ngOnInit() {
    this.headerService.setTitle('Asignar Polizas a clientes');
    this.clientService.getClients().pipe(first()).subscribe(clients => {
      this.clients = clients;
    });

    this.policyService.getPolicies().pipe(first()).subscribe(policies => {
      this.policyList = policies;
    });

    this.policyClientForm = this.formBuilder.group({
      clients: ['', Validators.required],
      policies: ['', Validators.required]
    });
  }

  get f() { return this.policyClientForm.controls; }

  select(client) {
    console.log(client);
  }

  clientChange(clientId) {
    //getPolicyClients ids[]
    debugger;
    this.clientPolicyService.getClientPolicies(clientId).pipe(first()).subscribe(policies => {
      debugger;
      this.policyClientForm.controls['policies'].setValue(policies);
    });
    console.log('change');
  }

  save() {
    debugger;
    //savePolicyClients {clientId, policiesIds[]}
    if (this.policyClientForm.errors && this.policyClientForm.invalid) {
      return;
    }
    this.clientPolicyService.addUpdateClientPolicy(this.policyClientForm.controls['clients'].value, this.policyClientForm.controls['policies'].value)
      .pipe(first())
      .subscribe(
        data => {
          debugger;
        },
        error => {
          debugger;
          this.alertService.error(error);
        });

  }

  ngOnDestroy() { }
}
