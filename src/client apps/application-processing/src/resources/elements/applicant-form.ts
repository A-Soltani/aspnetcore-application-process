import { inject, bindable } from 'aurelia-framework';
import { EventAggregator } from "aurelia-event-aggregator";
import { Router } from 'aurelia-router';
import { ValidationRules, ValidationControllerFactory, validationMessages } from 'aurelia-validation'

import { ApplicantService } from 'applicants/shared/applicant-service';


@inject(Router, EventAggregator, ApplicantService, ValidationControllerFactory)
export class ApplicantForm {
  @bindable title;
  @bindable applicant;
  controller: any

  constructor(private router: Router, private ea: EventAggregator, private applicantService: ApplicantService, ValidationControllerFactory) {
    this.controller = ValidationControllerFactory.createForCurrentScope();
  }

  submit(): void {
    this.applicantService.addApplicant(this.applicant)
    .then(applicant => {
      this.router.navigateToRoute('applicants')
      // this._ea.publish(new ContactCreated(applicant));
    }).catch(err => console.log(err));
  }

  valueChanged(newValue, oldValue) {
    //
  }

  applicantChanged(newValue, oldValue): void {
    console.log(this.applicant);
    if (this.applicant) {
      console.log(this.applicant);
    }
  }
}
