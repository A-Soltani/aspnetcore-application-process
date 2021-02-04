import {inject} from 'aurelia-framework';
import {Router, RouterConfiguration} from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

import { Applicant } from './shared/applicant-model';
import { ApplicantService } from './shared/applicant-service';

@inject(ApplicantService)
export class ApplicantList {
  applicants = []
  
  constructor(private applicantService: ApplicantService) {    
    
  }

  activate(): void {
    this.getApplicants();
  }

  private async getApplicants() {
    this.applicants = await this.applicantService.getApplicants();
  }

  
}
