import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'BusinessDevelopment',
  templateUrl: './BusinessDevelopment.component.html'
})
export class BusinessDevelopmentcomponent {
  public articles: articles[];

constructor(http: HttpClient, @Inject('base_url') baseurl: string) {
    http.get<articles[]>(baseurl + 'api/articles/10').subscribe(result => {
      this.articles = result;
    }, error => console.error(error));
  }

}

 interface articles {
   id: number;
   articleurl: string;
   Article_text: string;
   visible: boolean;
 }