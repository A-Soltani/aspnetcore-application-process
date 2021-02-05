import { inject } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';

import { Applicant } from './applicant-model';

@inject(HttpClient)
export class ApplicantService {
  applicants: Applicant[] = []
  applicant: Applicant

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
      .then(savedApplicant => {
        alert(`Saved Applicant. ID: ${savedApplicant.applicantId}`);
      })
      .catch(error => {
        alert('Error saving Applicant');
      });
  }

  updateApplicant(applicant) {

    return this.http
      .fetch('Applicant/update', {
        method: 'post',
        body: json(applicant)
      })
      .then(response => response.json())
      .then(savedApplicant => {
        alert(`Updated Applicant. ID: ${savedApplicant.applicantId}`);
      })
      .catch(error => {
        alert('Error updating Applicant');
      });
  }

  getApplicant(id) {
    return new Promise((resolve, reject) => {
      this.http.fetch(`Applicant/${id}`)
        .then(response => response.json())
        .then(fetchedApplicant => {
          alert(`Get Applicant. ID: ${fetchedApplicant.id}`);
        })
        .catch(error => {
          alert('Error geting Applicant');
        });
    });
  }

}



export class HttpError extends Error {
  constructor(public readonly response: Response) {
    super(`HTTP error code ${response.status} (${response.statusText})`);
  }
}
