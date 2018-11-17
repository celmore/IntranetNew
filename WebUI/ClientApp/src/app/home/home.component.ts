import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public Articles: articles[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<articles[]>(baseUrl + '/api/Articles/4').subscribe(result => {
      this.Articles = result;
    }, error => console.error(error));
  }
}

interface articles {
  Id: number;
  ArticleUrl: string;
  Article: string;
  Visible: boolean;

}
