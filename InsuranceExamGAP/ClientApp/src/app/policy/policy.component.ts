import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { User, Policy, PolicyType, RiskType, } from '../_models';
import { AuthenticationService, PolicyService, PolicyTypeService, RiskTypeService, AlertService } from '../_services';


@Component({ templateUrl: 'policy.component.html' })
export class PolicyComponent implements OnInit, OnDestroy {
  

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private policyService: PolicyService,
    private policyTypeService: PolicyTypeService,
    private riskTypeService: RiskTypeService,
    private alertService: AlertService
  ) {
    this.currentUserSubscription = this.authenticationService.currentUser.subscribe(user => {
      this.currentUser = user;
    });

  }
  currentUser: User;
  currentUserSubscription: Subscription;
  policies: Policy[] = [];
  policyTypes: PolicyType[] = [];
  riskTypes: RiskType[] = [];
  policyForm: FormGroup;
  loading = false;
  minDate = new Date();
  displayedColumns: string[] = ['name', 'description', 'policyType', 'riskType', 'policyDateBegin', 'policyMonthsPeriod', 'policyCost', 'options'];

  ngOnInit() {
    this.policyForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      policyTypeId: ['', Validators.required],
      policyDateBegin: ['', Validators.required],
      policyMonthsPeriod: ['', Validators.required],
      policyCost: ['', Validators.required],
      riskTypeId: ['', Validators.required]
    });
    this.loadAllPolicies();
    this.loadAllPolicyTypes();
    this.loadAllRiskTypes();
  }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.currentUserSubscription.unsubscribe();
  }

  get f() { return this.policyForm.controls; }

  addPolicy() {
    if (this.policyForm.invalid) {
      return;
    }
    this.loading = true;
    var policyType = this.policyTypes.find(policyType => policyType.policyTypeId === this.policyForm.value.policyTypeId);
    this.policyForm.value.policyType = policyType;
    var riskType = this.riskTypes.find(riskType => riskType.riskTypeId === this.policyForm.value.riskTypeId);
    this.policyForm.value.riskType = riskType;
    
    this.policyService.addPolicy(this.policyForm.value)
      .pipe(first())
      .subscribe(
      data => {
          this.loadAllPolicies();
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });

  }

  updatePolicy() {

  }

  deletePolicy(policyId: number) {
    this.policyService.deletePolicy(policyId).pipe(first()).subscribe(policy => {
      this.loadAllPolicies();
    });
  }

  private loadAllRiskTypes() {
    this.riskTypeService.getRiskTypes().pipe(first()).subscribe(riskTypes => {
      this.riskTypes = riskTypes;
    });
  }

  private loadAllPolicyTypes() {
    this.policyTypeService.getPolicyTypes().pipe(first()).subscribe(policyTypes => {
      this.policyTypes = policyTypes;
    });
  }

  private loadAllPolicies() {
    debugger;
    this.policyService.getPolicies().pipe(first()).subscribe(policies => {
      this.policies = policies;
    });
  }
}
