import { Router } from 'aurelia-router';
import { inject } from 'aurelia-dependency-injection';

import { Applicant } from "./shared/applicant-model";
import { ApplicantService } from './shared/applicant-service';

@inject(Router, ApplicantService)
export class ApplicantEdit {
  applicant

  constructor(private router: Router, private applicantService: ApplicantService) {
  }

  activate(parms): void {
    this.getApplicant(parms.id)
  }

  private getApplicant(id: number) {
    this.applicantService.getApplicant(id)
      .then(data => {
        this.applicant = data;
      })
      .catch(err => console.log(err));
      // this.router.navigateToRoute('applicant-form', {applicant: applicant})
  }
}
