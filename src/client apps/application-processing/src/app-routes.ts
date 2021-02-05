import { PLATFORM } from 'aurelia-pal';

export const AppRoutes = [
  { route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home/home'), nav: true, title: 'Home' },
  { route: 'applicants', name: 'applicants', moduleId: PLATFORM.moduleName('applicants/applicant-list'), nav: true, title: 'Applicants' },
  { route: 'applicants/add', name: 'applicants/add', moduleId: PLATFORM.moduleName('applicants/applicant-add'), nav: true, title: 'Add applicant' },
  { route: 'applicants/edit/:id', name: 'applicants/edit', moduleId: PLATFORM.moduleName('applicants/applicant-edit'), nav: false, title: 'Edit applicant' },
]
