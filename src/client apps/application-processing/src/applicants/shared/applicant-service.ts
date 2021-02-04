import {inject} from 'aurelia-framework';


import { HttpClient } from 'aurelia-fetch-client';
import { Applicant } from './applicant-model';

@inject(HttpClient)
export class ApplicantService {
  applicants: Applicant[] = []

  constructor(private http: HttpClient) {
    this.http = http;
  }

  getApplicants() {
    return this.http.fetch('Applicant/list')
      .then(response => response.json())
      .then(applicants => this.applicants = applicants);
  }

  // GetApplicant(id: number): Applicant {

  //   return this.applicant;
  // }



  

  
}



export class HttpError extends Error {
  constructor(public readonly response: Response) {
    super(`HTTP error code ${response.status} (${response.statusText})`);
  }
}
