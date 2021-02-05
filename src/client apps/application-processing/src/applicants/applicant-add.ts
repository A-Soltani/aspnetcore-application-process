import { inject } from 'aurelia-framework';
import { EventAggregator } from "aurelia-event-aggregator";

import { Applicant } from './shared/applicant-model';
import { ApplicantService } from './shared/applicant-service';


@inject(EventAggregator, ApplicantService)
export class ApplicantAdd {
  applicant: Applicant

  constructor(private ea: EventAggregator, private applicantService: ApplicantService) {
  }

  activate(): void {
    this.applicant = new Applicant();
  }

  create(): void {
    // const applicant = JSON.parse(JSON.stringify(this.applicant));
    // console.log(applicant);
    
    this.applicantService.addApplicant(this.applicant)
      .then(applicant => {
        console.log(applicant)
        // this._ea.publish(new ContactCreated(applicant));
      }).catch(err => console.log(err));
  }




}
