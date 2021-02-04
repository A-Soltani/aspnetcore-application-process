import { Applicant } from './applicant-model';

export class ApplicantService {
  applicant: Applicant = {
    city: "",
    age: 30,
    countryOfOrigin: "",
    emailAddress: "",
    familyName: "",
    fullAddress: "",
    id: 1,
    name: ""
  }   
  GetApplicants(): Applicant[] {
    return [this.applicant];
  }

  GetApplicant(id: number): Applicant {
     
    return this.applicant;
  }
}
