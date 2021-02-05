import { inject } from 'aurelia-framework';
import { EventAggregator } from "aurelia-event-aggregator";
import { Router } from 'aurelia-router';

import { Applicant } from './shared/applicant-model';
import { ApplicantService } from './shared/applicant-service';


@inject(Router, EventAggregator, ApplicantService)
export class ApplicantAdd {
  title: string
  controller: any
  applicant: Applicant

  constructor(private ea: EventAggregator, private applicantService: ApplicantService) {
  }

  attached() {
    this.title = "Add Applicant"
    this.applicant = new Applicant();
  }

  sendApplicant(): void {

    // this.applicantService.addApplicant(this.applicant)
    //   .then(applicant => {
    //     this.router.navigateToRoute('applicants')
    //     // this._ea.publish(new ContactCreated(applicant));
    //   }).catch(err => console.log(err));
  }

}
