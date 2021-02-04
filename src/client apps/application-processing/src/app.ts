import { Router, RouterConfiguration } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

export class App {
  router: Router;

  // configureRouter(config: RouterConfiguration, router: Router){
  //   config.title = 'Contacts';
  //   config.options.pushState = true;
  //   config.options.root = '/';
  //   config.map([
  //     { route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('applicants/applicant-list'), nav: true, title: 'Home' },
  //     { route: ['applicants', 'applicants'], name: 'applicants', moduleId: PLATFORM.moduleName('applicants/applicant-list'), nav: true, title: 'Home' },

  //   ]);

  //   this.router = router;
  // }
  configureRouter(config, router): void {
    config.title = 'Application Process';
    config.options.pushState = true;
    config.options.root = '/';
    config.map([
      { route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home/home'), nav: true, title: 'Home' },
      { route: 'applicants', name: 'applicants', moduleId: PLATFORM.moduleName('applicants/applicant-list'), nav: true, title: 'applicants' },

    ]);
    this.router = router;
    console.log(this.router);
  }
}

