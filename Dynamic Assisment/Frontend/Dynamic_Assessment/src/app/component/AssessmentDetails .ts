export interface AssessmentDetails {
    id: number;
    isScorable: number;
    name: string;
    questions: Question[];
  }
  
  export interface Question {
    id: number;
    questions: string;
    responseType: string;
    isRequired: boolean;
    assessmentId: number;
  }
  