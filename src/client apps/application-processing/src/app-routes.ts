import { PLATFORM } from 'aurelia-pal';

export const AppRoutes = [
  { route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home/home'), nav: true, title: 'Home' },
  { route: 'applicants', name: 'applicants', moduleId: PLATFORM.moduleName('applicants/applicant-list'), nav: true, title: 'applicants' },
]
