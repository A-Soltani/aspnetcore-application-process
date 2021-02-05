import { Applicant } from './../../applicants/shared/applicant-model';
import { inject, bindable } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { ValidationRules, ValidationControllerFactory, validationMessages } from 'aurelia-validation'
import { DialogService } from 'aurelia-dialog';



import { ApplicantService } from 'applicants/shared/applicant-service';
import { Dialog } from 'shared/dialog';


@inject(Router, ApplicantService, ValidationControllerFactory, DialogService)
export class ApplicantForm {
  @bindable title;
  @bindable applicant: Applicant;
  controller: any

  constructor(private router: Router, private applicantService: ApplicantService, ValidationControllerFactory, private dialogService: DialogService) {
    this.controller = ValidationControllerFactory.createForCurrentScope();
  }

  reset(): void {
    this.openDialog('Reset page', 'Are you sure');
  }

  openDialog(title, message): void {
    this.dialogService.open({
      viewModel: Dialog,
      model: {
        message: message,
        title: title, action: this.action
      }
    });

    this.dialogService.open({
      viewModel: Dialog,
      model: {
        message: message,
        title: title, action: this.action
      }
    }).whenClosed(response => {
      if (response.wasCancelled) {
        const resetForm = <HTMLFormElement>document.getElementById("applicantForm");
        resetForm.reset();
      } 
    });
  }

  action(): void {
    alert('OK button pressed');
  }

  submit(): void {
    if (this.applicant.id > 0)
      this.updateApplicant();
    else
      this.addApplicant();
  }

  addApplicant() {
    this.applicantService.addApplicant(this.applicant)
      .then(applicant => {
        this.router.navigateToRoute('applicants')
      }).catch(err => console.log(err));
  }

  updateApplicant() {
    this.applicantService.updateApplicant(this.applicant)
      .then(applicant => {
        this.router.navigateToRoute('applicants')
      }).catch(err => console.log(err));
  }

  applicantChanged(newValue, oldValue): void {
    console.log(this.applicant);
    if (this.applicant) {
      validationMessages['required'] = `You must enter a \${$displayName}.`;

      ValidationRules
        .ensure('name')
        .displayName('Name').required()
        .minLength(5).withMessage('Name lenght must be at least 5.')
        .ensure('familyName')
        .displayName('Family Name').required()
        .minLength(5).withMessage('Family Name lenght must be at least 5.')
        .ensure('age')
        .displayName('Age').required()
        .between(20, 60).withMessage('Age should be between 20 and 60.')
        .ensure('emailAddress')
        .displayName('Email Address').required()
        .email().withMessage('Email Address format is invalid.')
        .ensure('countryOfOrigin')
        .displayName('Country Of Origin').required()
        .ensure('city')
        .displayName('City').required()
        .ensure('fullAddress')
        .displayName('Full Address').required()
        .minLength(10).withMessage('Full address lenght must be at least 10.')
        .on(this.applicant);

      this.controller.validate();

    }
  }
}
