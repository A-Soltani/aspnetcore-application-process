import {inject} from 'aurelia-framework';

import { Applicant } from './shared/applicant-model';
import { ApplicantService } from './shared/applicant-service';

@inject(ApplicantService)
export class ApplicantList {
  applicants: Applicant[] = []

  constructor(private applicantService: ApplicantService) {
    this.applicants = this.applicantService.GetApplicants();
    console.log(this.applicants);
  }

  
}
