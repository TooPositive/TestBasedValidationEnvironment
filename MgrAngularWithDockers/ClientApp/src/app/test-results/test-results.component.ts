import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-results',
  templateUrl: './test-results.component.html',
  styleUrls: ['./test-results.scss']
})
export class TestResultComponent {
  public forecasts: TestResult[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TestResult[]>(baseUrl + 'TestResult').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface TestResult {
  guid: string;
  resultId: number;
  testGuid: string;
}

