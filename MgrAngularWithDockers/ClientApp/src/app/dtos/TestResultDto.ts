import { Moment } from "moment";

export interface TestResultDto {
  id: string;
  result: number;
  testId: string;
  testName: string;
  executionTime: Moment;
  testDuration: any;
}
