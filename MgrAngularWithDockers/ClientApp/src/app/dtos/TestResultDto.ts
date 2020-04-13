import { Moment } from "moment";

export interface TestResultDto {
  id: string;
  result: number;
  resultName: string;
  testId: string;
  testName: string;
  executionTime: Moment;
  testDuration: any;
}
