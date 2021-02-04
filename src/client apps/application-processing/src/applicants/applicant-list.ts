import {inject} from 'aurelia-framework';
import {Router, RouterConfiguration} from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

import { Applicant } from './shared/applicant-model';
import { ApplicantService } from './shared/applicant-service';

@inject(ApplicantService)
export class ApplicantList {
  applicants = []
  router: Router;

  configureRouter(config: RouterConfiguration, router: Router): void {
    config.title = 'Applicants';
    // config.options.pushState = true;
    // config.options.root = '/';
    config.map([
      { route: '', name: 'applicants', moduleId: PLATFORM.moduleName('applicants/applicant-list'), nav: true, title: 'Applicants' },
      { route: 'add', name: 'add', moduleId: PLATFORM.moduleName('applicants/applicant-add'), nav: true, title: 'add applicants' },
    ]);
    this.router = router;
  }
  constructor(private applicantService: ApplicantService) {    
    this.getApplicants();
  }

  private async getApplicants() {
    this.applicants = await this.applicantService.getApplicants();
  }

  
}
