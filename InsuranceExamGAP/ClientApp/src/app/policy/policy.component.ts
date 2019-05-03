import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material';

import { User, Policy } from '../_models';
import { AuthenticationService, PolicyService, AlertService, HeaderService } from '../_services';
import { DialogPolicyFormComponent } from '../dialogPolicyForm/';



@Component({ templateUrl: 'policy.component.html', styleUrls: ['policy.component.scss'] })
export class PolicyComponent implements OnInit, OnDestroy {


  constructor(
    private authenticationService: AuthenticationService,
    private policyService: PolicyService,
    private alertService: AlertService,
    private headerService: HeaderService,
    public dialog: MatDialog
  ) {
    this.currentUserSubscription = this.authenticationService.currentUser.subscribe(user => {
      this.currentUser = user;
    });

  }
  currentUser: User;
  currentUserSubscription: Subscription;
  policies: Policy[] = [];
  displayedColumns: string[] = ['name', 'description', 'policyType', 'riskType', 'policyDateBegin', 'policyMonthsPeriod', 'policyCost', 'options'];

  openDialog(action, item): void {
    if (action === 'add') {
      const dialogRef = this.dialog.open(DialogPolicyFormComponent, {
        width: '350px',
      });
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        if (result != null) {
          this.addPolicy(result);
        }
      });
    } else {
      const dialogRef = this.dialog.open(DialogPolicyFormComponent, {
        width: '350px',
        data: item
      });
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        if (result != null) {
          this.updatePolicy(result);
        }
      });
    }
  }

  ngOnInit() {
    this.headerService.setTitle('Polizas');
    this.loadAllPolicies();
  }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.currentUserSubscription.unsubscribe();
  }

  addPolicy(policy) {
    this.policyService.addPolicy(policy)
      .pipe(first())
      .subscribe(
        data => {
          this.loadAllPolicies();
        },
        error => {
          debugger;
          this.alertService.error('El tipo de poliza no puede ser alto si el riesgo es alto');
        });

  }

  updatePolicy(policy) {
    this.policyService.updatePolicy(policy)
      .pipe(first())
      .subscribe(
        data => {
          this.loadAllPolicies();
        },
        error => {
          
          this.alertService.error('El tipo de poliza no puede ser alto si el riesgo es alto');
        });
  }

  deletePolicy(policyId: number) {
    this.policyService.deletePolicy(policyId).pipe(first()).subscribe(policy => {
      this.loadAllPolicies();
    });
  }

  private loadAllPolicies() {
    this.policyService.getPolicies().pipe(first()).subscribe(policies => {
      this.policies = policies;
    });
  }
}
