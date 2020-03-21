import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-results',
  templateUrl: './test-results.component.html',
  styleUrls: ['./test-results.scss']
})
export class TestResultComponent {
  public testResults: TestResult[];
  public historyHeaders: string[] = ["GUID", "TestName", "Time", "Result"];
  public something: string = "hello";


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(baseUrl + 'api/TestResult/Filter');
    http.get<TestResult[]>(baseUrl + 'api/TestResult/Filter').subscribe(result => {
      this.testResults = result;
      console.log(this.testResults);
    }, error => console.error(error));
  }


}


