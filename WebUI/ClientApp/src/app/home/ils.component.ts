import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'ils',
  templateUrl: './ils.component.html',
})
export class ILSComponent {
  public Articles: articles[];

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<articles[]>(baseUrl + 'api/articles/8').subscribe(result => {
  //    this.Articles = result;
  //  }, error => console.error(error));
  //}


}

interface articles {
  Id: number;
  ArticleUrl: string;
  Article: string;
  Visible: boolean;

}
