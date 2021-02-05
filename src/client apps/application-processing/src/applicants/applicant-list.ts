import {inject} from 'aurelia-framework';

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
