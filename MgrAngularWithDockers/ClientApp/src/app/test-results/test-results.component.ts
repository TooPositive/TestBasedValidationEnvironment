import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TestResultDto } from '../dtos/TestResultDto';

@Component({
  selector: 'app-test-results',
  templateUrl: './test-results.component.html',
  styleUrls: ['./test-results.scss']
})
export class TestResultComponent {
    
  public historyTestResults: TestResultDto[];  
  public inprogressTestResults: TestResultDto[];  
  public historyHeaders: string[] = ["TestName", "Execution Time", "Duration", "Result"];
  public inprogressHeaders: string[] = ["TestName", "Progress"];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.getHistoryTestResults(http, baseUrl);
    this.getInprogressTestResults(http, baseUrl);
  }



  private getHistoryTestResults(http: HttpClient, baseUrl: string) {
        http.get<TestResultDto[]>(baseUrl + `api/TestResult/Filter/?$filter=ResultName ne 'InProgress'`).subscribe(result => {
          this.historyTestResults = result;
        }, error => console.error(error));
  }

  private getInprogressTestResults(http: HttpClient, baseUrl: string) {
    http.get<TestResultDto[]>(baseUrl + `api/TestResult/Filter/?$filter=ResultName eq 'InProgress'`).subscribe(result => {
      this.inprogressTestResults = result;
    }, error => console.error(error));
  }

  showTimeSpan(testDuration) {
    console.log(testDuration);
    var min = testDuration.Minutes < 10 ? "0" + testDuration.Minutes : testDuration.Minutes;
    var sec = testDuration.Seconds < 10 ? "0" + testDuration.Seconds : testDuration.Seconds;
    var hour = testDuration.Hours < 10 ? "0" + testDuration.Hours : testDuration.Hours;
    return testDuration;
  }
}


