import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "Admin/create",
  templateUrl: './article-edit.component.html',
  styleUrls: ['./article-edit.component.css']
})
   
export class ArticleEditComponent {
  title: string;
  article: Articles;

  editMode: boolean;

  constructor(private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {

    // create an empty object from the article interface
    this.article = <Articles>{};

    var id = +this.activatedRoute.snapshot.params["id"];
    if (id) {
      this.editMode = true;

      // fetch article from server
      var url = this.baseUrl + "api/articles/" + id;
      this.http.get<Articles>(url).subscribe(result => {
        this.article = result;
        this.title = "Edit - " + this.article.Title;
      }, error => console.error(error));
    }
    else {
      this.editMode = false;
      this.title = "Create a new Page";
    }
  }
   
  onSubmit(article: Articles) {
    var url = this.baseUrl + "api/articles";

    if (this.editMode) {
      this.http
        .post<Articles>(url, article)
        .subscribe(res => {
          var v = res;
          console.log("Article " + v.Id + " has been updated.");
          this.router.navigate(["home"]);
        }, error => console.log(error));
    }
    else {
      this.http.put<Articles>(url, article)
        .subscribe(res => {
          var a = res;
          console.log("Page " + a.Id + " has been created.");
          this.router.navigate(["home"]);
        }, error => console.log(error));
    }
  }

  onBack() {
    this.router.navigate(["home"]);
  }

}

