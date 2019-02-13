import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'BusinessDevelopment',
<<<<<<< HEAD
<<<<<<< HEAD
  templateUrl: './BusinessDevelopment/BusinessDevelopment.component.html'
=======
  templateUrl: './Business Development/BusinessDevelopment.component.html'
>>>>>>> intranet updates
=======
  templateUrl: './BusinessDevelopment.component.html'
>>>>>>> Updated without errors
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
   article: string;
   visible: boolean;
 }
