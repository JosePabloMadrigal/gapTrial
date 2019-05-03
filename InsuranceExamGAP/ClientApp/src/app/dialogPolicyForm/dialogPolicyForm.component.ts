import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
import { Component, OnInit, Inject, Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { first } from 'rxjs/operators';
import { Policy, PolicyType, RiskType, } from '../_models';
import { PolicyTypeService, RiskTypeService } from '../_services';

@Injectable({ providedIn: 'root' })
@Component({ templateUrl: 'dialogPolicyForm.component.html' })
export class DialogPolicyFormComponent implements OnInit {
  title: string;
  isAddAction: boolean = false;
  policyForm: FormGroup;
  policyTypes: PolicyType[] = [];
  riskTypes: RiskType[] = [];
  minDate = new Date();
  constructor(
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<DialogPolicyFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Policy,
    private policyTypeService: PolicyTypeService,
    private riskTypeService: RiskTypeService
  ) {
    this.loadAllRiskTypes();
    this.loadAllPolicyTypes();
  }

  ngOnInit() {

    if (this.data === null) {
      this.title = 'Add Policy';
      this.isAddAction = true;
      this.policyForm = this.formBuilder.group({
        name: ['', Validators.compose([Validators.required, Validators.minLength(5)])],
        description: ['', Validators.compose([Validators.required, Validators.minLength(5)])],
        policyTypeId: ['', Validators.required],
        policyDateBegin: ['', Validators.required],
        policyMonthsPeriod: ['', Validators.required],
        policyCost: ['', Validators.required],
        riskTypeId: ['', Validators.required]
      });
    } else {
      this.title = 'Update Policy';
      this.policyForm = this.formBuilder.group({
        name: [this.data.name, Validators.compose([Validators.required, Validators.minLength(5)])],
        description: [this.data.description, Validators.compose([Validators.required, Validators.minLength(5)])],
        policyTypeId: [this.data.policyTypeId, Validators.required],
        policyDateBegin: [this.data.policyDateBegin, Validators.required],
        policyMonthsPeriod: [this.data.policyMonthsPeriod, Validators.required],
        policyCost: [this.data.policyCost, Validators.required],
        riskTypeId: [this.data.riskTypeId, Validators.required]
      });
    }


  }



  get f() { return this.policyForm.controls; }


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
  save() {
    let policyForm = this.policyForm.value;
    if (this.policyForm.errors && this.policyForm.invalid) {
      return;
    }
    var policyType = this.policyTypes.find(policyType => policyType.policyTypeId === this.policyForm.value.policyTypeId);
    this.policyForm.value.policyType = policyType;
    var riskType = this.riskTypes.find(riskType => riskType.riskTypeId === this.policyForm.value.riskTypeId);
    this.policyForm.value.riskType = riskType;


    if (this.isAddAction === false) {
      policyForm.policyId = this.data.policyId;
    }
    this.dialogRef.close(policyForm);
  }



  close() {
    this.dialogRef.close();
  }
}
