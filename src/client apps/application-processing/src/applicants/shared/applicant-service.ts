import {inject} from 'aurelia-framework';
import {HttpClient, json} from 'aurelia-fetch-client';

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

  addApplicant(applicant) {

    return this.http
    .fetch('Applicant/add', {
      method: 'post',
      body: json(applicant)
    })
    .then(response => response.json())
    .then(savedComment => {
      alert(`Saved comment! ID: ${savedComment.id}`);
    })
    .catch(error => {
      alert('Error saving comment!');
    });
  

  
    return this.http.post('Applicant/add', applicant)
      .then(response => response.json());
      // .then(applicants => this.applicants = applicants);
  }

  // getApplicant(id: number): Applicant {

  //   return this.applicant;
  // }



  

  
}



export class HttpError extends Error {
  constructor(public readonly response: Response) {
    super(`HTTP error code ${response.status} (${response.statusText})`);
  }
}
